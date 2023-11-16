using Microsoft.EntityFrameworkCore;
using VoceaUniversitatii.Helpers;
using VoceaUniversitatii.Models;
using VoceaUniversitatii.Models.DTOs;
using VoceaUniversitatii.Models.DTOs.StudentCohortDTOs;
using VoceaUniversitatii.Services.StudyProgramService;

namespace VoceaUniversitatii.Services.StudentCohortService;

public class StudentCohortService : IStudentCohortService
{
    private readonly DatabaseContext _context;
    private readonly IStudyProgramService _studyProgramService;
    
    public StudentCohortService(DatabaseContext context, IStudyProgramService studyProgramService)
    {
        _context = context;
        _studyProgramService = studyProgramService;
    }

    public async Task<StudentCohortSendDTO> StudentCohortToStudentCohortSendDtoAsync(StudentCohort studentCohort)
    {
        if (studentCohort == null)
        {
            return null!;
        }
        return new StudentCohortSendDTO()
        {
            Id = studentCohort.Id,
            Size = studentCohort.Size,
            Name = studentCohort.Name,
            AcademicYear = new AcademicYearSendDTO()
            {
                Id = studentCohort.AcademicYear.Id,
                StartYear = studentCohort.AcademicYear.StartYear,
                EndYear = studentCohort.AcademicYear.EndYear
            },
            StudyProgram =
                await _studyProgramService.StudyProgramToStudyProgramSendDtoAsync(studentCohort.StudyProgram),
            CohortType = new CohortSendDTO()
            {
                Id = studentCohort.CohortType.Id,
                CohortName = studentCohort.CohortType.CohortName
            },
            ParentStudentCohort = await StudentCohortToStudentCohortSendDtoAsync(studentCohort.ParentStudentCohort),
        };
    }

    private async Task<StudentCohort> StudentCohortCreateDtoToStudentCohort(
        StudentCohortCreateDTO studentCohortCreateDto)
    {
        return await Task.FromResult( new StudentCohort()
        {
            Name = studentCohortCreateDto.Name,
            Size = studentCohortCreateDto.Size,
            AcademicYearId = studentCohortCreateDto.AcademicYearId,
            StudyProgramId = studentCohortCreateDto.StudyProgramId,
            StudyYearId = studentCohortCreateDto.StudyYearId,
            CohortTypeId = studentCohortCreateDto.CohortTypeId,
            ParentStudentCohortId = studentCohortCreateDto.ParentStudentCohortId
        });
    }
    
    public async Task<List<StudentCohortSendDTO>> GetAllStudentCohortsAsync()
    {
        var databaseStudentCohorts = await _context.StudentCohorts
            .Include(sc => sc.AcademicYear)
            .Include(sc => sc.StudyProgram)
            .ThenInclude(sp => sp.Language)
            .Include(sc => sc.StudyYear)
            .Include(sc => sc.CohortType)
            .Include(sc => sc.ParentStudentCohort)
            .ToListAsync();
        var StudentCohortsTasks =  databaseStudentCohorts.Select(sp => StudentCohortToStudentCohortSendDtoAsync(sp));
        var StudentCohorts = await Task.WhenAll(StudentCohortsTasks);
        return StudentCohorts.ToList();
    }

    public async Task<StudentCohortSendDTO> GetSingleStudentCohortAsync(long id)
    {
        var databaseStudentCohort = await _context.StudentCohorts
            .Include(sc => sc.AcademicYear)
            .Include(sc => sc.StudyProgram)
            .Include(sc => sc.StudyYear)
            .Include(sc => sc.CohortType)
            .Include(sc => sc.ParentStudentCohort)
            .SingleOrDefaultAsync(sp => sp.Id == id);
        return await StudentCohortToStudentCohortSendDtoAsync(databaseStudentCohort);
    }

    public async Task<List<StudentCohortSendDTO>> AddStudentCohortAsync(StudentCohortCreateDTO StudentCohort)
    {
        var newStudentCohort = await StudentCohortCreateDtoToStudentCohort(StudentCohort);
        await _context.StudentCohorts.AddAsync(newStudentCohort);
        await _context.SaveChangesAsync();
        return await GetAllStudentCohortsAsync();
    }

    public async Task<StudentCohortSendDTO> UpdateStudentCohortAsync(StudentCohortUpdateDTO request)
    {
        var id = request.Id;
        var databaseStudentCohort = await _context.StudentCohorts.FindAsync(id);

        databaseStudentCohort.Name = request.Name;
        databaseStudentCohort.Size = request.Size;
        databaseStudentCohort.AcademicYearId = request.AcademicYearId;
        databaseStudentCohort.StudyProgramId = request.StudyProgramId;
        databaseStudentCohort.StudyYearId = request.StudyYearId;
        databaseStudentCohort.CohortTypeId = request.CohortTypeId;
        databaseStudentCohort.ParentStudentCohortId = request.ParentStudentCohortId;

        await _context.SaveChangesAsync();

        return await GetSingleStudentCohortAsync(id);
    }

    public async Task<List<StudentCohortSendDTO>> DeleteStudentCohortAsync(long id)
    {
        var databaseStudentCohort = await _context.StudentCohorts.FindAsync(id);

        _context.StudentCohorts.Remove(databaseStudentCohort);
        await _context.SaveChangesAsync();

        return await GetAllStudentCohortsAsync();
    }
}
using Microsoft.EntityFrameworkCore;
using VoceaUniversitatii.Services.FacultyService;
using VoceaUniversitatiiDataModels;
using VoceaUniversitatiiDataModels.Models;
using VoceaUniversitatiiDataModels.Models.DTOs;
using VoceaUniversitatiiDataModels.Models.DTOs.StudyProgramDTOs;

namespace VoceaUniversitatii.Services.StudyProgramService;

public class StudyProgramService : IStudyProgramService
{
    private readonly DatabaseContext _context;
    private readonly IFacultyService _facultyService;

    public StudyProgramService(DatabaseContext context, IFacultyService facultyService)
    {
        _context = context;
        _facultyService = facultyService;
    }
    
    public async Task<StudyProgramSendDTO> StudyProgramToStudyProgramSendDtoAsync(StudyProgram studyProgram)
    {
        var faculty = await _facultyService.GetSingleFaculty(studyProgram.FacultyId);
        var language = new LanguageSendDTO()
        {
            Id = studyProgram.Language.Id,
            LanguageName = studyProgram.Language.LanguageName
        };
        return new StudyProgramSendDTO()
        {
            Id = studyProgram.Id,
            FullName = studyProgram.FullName,
            Language = language,
            Faculty = faculty
        };
    }

    private async Task<StudyProgram> StudyProgramCreateDtoToStudyProgram(StudyProgramCreateDTO studyProgramCreateDto)
    {
        return await Task.FromResult(new StudyProgram()
        {
            FullName = studyProgramCreateDto.FullName,
            LanguageId = studyProgramCreateDto.LanguageId,
            FacultyId = studyProgramCreateDto.FacultyId
        });
    }
    
    public async Task<List<StudyProgramSendDTO>> GetAllStudyProgramsAsync()
    {
        var databaseStudyPrograms = await _context.StudyPrograms
            .Include(sp => sp.Language)
            .Include(sp => sp.Disciplines)
            .ToListAsync();
        var studyProgramsTasks =  databaseStudyPrograms.Select(sp => StudyProgramToStudyProgramSendDtoAsync(sp));
        var studyPrograms = await Task.WhenAll(studyProgramsTasks);
        return studyPrograms.ToList();
    }

    public async Task<StudyProgramSendDTO> GetSingleStudyProgramAsync(long id)
    {
        var databaseStudyProgram = await _context.StudyPrograms
            .Include(sp => sp.Language)
            .Include(sp => sp.Disciplines)
            .SingleOrDefaultAsync(sp => sp.Id == id);
        return await StudyProgramToStudyProgramSendDtoAsync(databaseStudyProgram);
    }

    public async Task<List<StudyProgramSendDTO>> AddStudyProgramAsync(StudyProgramCreateDTO studyProgram)
    {
        var newStudyProgram = await StudyProgramCreateDtoToStudyProgram(studyProgram);
        await _context.StudyPrograms.AddAsync(newStudyProgram);
        await _context.SaveChangesAsync();
        return await GetAllStudyProgramsAsync();
    }

    public async Task<StudyProgramSendDTO> UpdateStudyProgramAsync(StudyProgramUpdateDTO request)
    {
        var id = request.Id;
        var databaseStudyProgram = await _context.StudyPrograms.FindAsync(id);

        databaseStudyProgram.FullName = request.FullName;
        databaseStudyProgram.FacultyId = request.FacultyId;
        databaseStudyProgram.LanguageId = request.LanguageId;

        await _context.SaveChangesAsync();

        return await GetSingleStudyProgramAsync(id);
    }

    public async Task<List<StudyProgramSendDTO>> DeleteStudyProgramAsync(long id)
    {
        var databaseStudyProgram = await _context.StudyPrograms.FindAsync(id);

        _context.StudyPrograms.Remove(databaseStudyProgram);
        await _context.SaveChangesAsync();

        return await GetAllStudyProgramsAsync();
    }
}
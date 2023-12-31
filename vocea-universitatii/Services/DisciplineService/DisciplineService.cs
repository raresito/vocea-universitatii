﻿using Microsoft.EntityFrameworkCore;
using VoceaUniversitatii.Services.StudyProgramService;
using VoceaUniversitatiiDataModels;
using VoceaUniversitatiiDataModels.Models;
using VoceaUniversitatiiDataModels.Models.DTOs.DisciplineDTOs;
using VoceaUniversitatiiDataModels.Models.DTOs.DisciplineDTOs.EvaluationMethodDTOs;

namespace VoceaUniversitatii.Services.DisciplineService;

public class DisciplineService : IDisciplineService
{
    private readonly DatabaseContext _context;
    private readonly IStudyProgramService _studyProgramService;

    public DisciplineService(DatabaseContext context, IStudyProgramService studyProgramService)
    {
        _context = context;
        _studyProgramService = studyProgramService;
    }
    
    public async Task<DisciplineSendDTO> DisciplineToDisciplineSendDtoAsync(Discipline discipline)
    {
        return new DisciplineSendDTO()
        {
            Id = discipline.Id,
            FullName = discipline.FullName,
            AbsoluteSemester = discipline.AbsoluteSemester,
            Optional = discipline.Optional,
            StudyProgram = await _studyProgramService.StudyProgramToStudyProgramSendDtoAsync(discipline.StudyProgram),
            EvaluationMethod = new EvaluationMethodSendDTO()
            {
                Id = discipline.EvaluationMethod.Id,
                Name = discipline.EvaluationMethod.Name
            }
        };
    }

    private async Task<Discipline> DisciplineCreateDtoToDiscipline(DisciplineCreateDTO disciplineCreateDto)
    {
        return await Task.FromResult( new Discipline()
        {
            FullName = disciplineCreateDto.FullName,
            AbsoluteSemester = disciplineCreateDto.AbsoluteSemester,
            Optional = disciplineCreateDto.Optional,
            StudyProgramId = disciplineCreateDto.StudyProgramId,
            EvaluationMethodId = disciplineCreateDto.EvaluationMethodId
        });
    }
    
    public async Task<List<DisciplineSendDTO>> GetAllDisciplinesAsync()
    {
        var databaseDisciplines = await _context.Disciplines
            .Include(d => d.StudyProgram)
            .ThenInclude(sp => sp.Language)
            .Include(d => d.EvaluationMethod)
            .ToListAsync();
        var disciplinesTasks =  databaseDisciplines.Select(sp => DisciplineToDisciplineSendDtoAsync(sp));
        var disciplines = await Task.WhenAll(disciplinesTasks);
        return disciplines.ToList();
    }

    public async Task<DisciplineSendDTO> GetSingleDisciplineAsync(long id)
    {
        var databaseDiscipline = await _context.Disciplines
            .Include(d => d.StudyProgram)
            .ThenInclude(sp => sp.Language)
            .Include(d => d.EvaluationMethod)
            .SingleOrDefaultAsync(sp => sp.Id == id);
        return await DisciplineToDisciplineSendDtoAsync(databaseDiscipline);
    }

    public async Task<List<DisciplineSendDTO>> AddDisciplineAsync(DisciplineCreateDTO discipline)
    {
        var newDiscipline = await DisciplineCreateDtoToDiscipline(discipline);
        await _context.Disciplines.AddAsync(newDiscipline);
        await _context.SaveChangesAsync();
        return await GetAllDisciplinesAsync();
    }

    public async Task<DisciplineSendDTO> UpdateDisciplineAsync(DisciplineUpdateDTO request)
    {
        var id = request.Id;
        var databaseDiscipline = await _context.Disciplines.FindAsync(id);

        databaseDiscipline.FullName = request.FullName;
        databaseDiscipline.AbsoluteSemester = request.AbsoluteSemester;
        databaseDiscipline.Optional = request.Optional;
        databaseDiscipline.StudyProgramId = request.StudyProgramId;
        databaseDiscipline.EvaluationMethodId = request.EvaluationMethodId;

        await _context.SaveChangesAsync();

        return await GetSingleDisciplineAsync(id);
    }

    public async Task<List<DisciplineSendDTO>> DeleteDisciplineAsync(long id)
    {
        var databaseDiscipline = await _context.Disciplines.FindAsync(id);

        _context.Disciplines.Remove(databaseDiscipline);
        await _context.SaveChangesAsync();

        return await GetAllDisciplinesAsync();
    }
}
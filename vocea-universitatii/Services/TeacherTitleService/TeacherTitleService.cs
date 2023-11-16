using Microsoft.EntityFrameworkCore;
using vocea_universitatii.Helpers;
using vocea_universitatii.Models;
using vocea_universitatii.Models.DTOs;

namespace vocea_universitatii.Services.TeacherTitlesService;

public class TeacherTitleService : ITeacherTitleService
{

    private readonly DatabaseContext _context;
    
    public TeacherTitleService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<List<TeacherTitleSendDTO>> GetAllTeacherTitles()
    {
        var databaseTeacherTitles =  await _context.TeacherTitles.ToListAsync();
        var returnTeacherTitles = databaseTeacherTitles.Select(t =>
        {
            return new TeacherTitleSendDTO()
            {
                Id = t.Id,
                Title = t.Title
            };
        }).ToList();
        return returnTeacherTitles;
    }
    
    public async Task<TeacherTitleSendDTO> GetSingleTeacherTitle(long id)
    {
        var databaseTeacherTitle = await _context.TeacherTitles.FirstOrDefaultAsync(i => i.Id == id);
        if (databaseTeacherTitle == null) return null;
        return new TeacherTitleSendDTO()
        {
            Id = databaseTeacherTitle.Id,
            Title = databaseTeacherTitle.Title
        };
    }

    // Should create exception if the TeacherTitle string already exists. 
    public async Task<TeacherTitleSendDTO> AddTeacherTitle(TeacherTitleCreateDTO teacherTitle)
    {
        var newTeacherTitle = new TeacherTitle()
        {
            Title = teacherTitle.Title,
        };
        await _context.TeacherTitles.AddAsync(newTeacherTitle);
        await _context.SaveChangesAsync();
        return await GetSingleTeacherTitle(newTeacherTitle.Id);
    }

    public async Task<TeacherTitleSendDTO> UpdateTeacherTitle(TeacherTitleUpdateDTO request)
    {
        var id = request.Id;
        var databaseTeacherTitle = await _context.TeacherTitles.FindAsync(id);
        if (databaseTeacherTitle == null) return null;

        databaseTeacherTitle.Title = request.Title;

        await _context.SaveChangesAsync();

        return await GetSingleTeacherTitle(request.Id);
    }

    public async Task<List<TeacherTitleSendDTO>> DeleteTeacherTitle(long id)
    {
        var databaseTeacher = await _context.TeacherTitles.FindAsync(id);
        if (databaseTeacher == null) return null;

        _context.TeacherTitles.Remove(databaseTeacher);
        await _context.SaveChangesAsync();

        return await GetAllTeacherTitles();
    }
}
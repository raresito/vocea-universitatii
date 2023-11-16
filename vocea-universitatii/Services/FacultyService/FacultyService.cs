using Microsoft.EntityFrameworkCore;
using VoceaUniversitatii.Helpers;
using VoceaUniversitatii.Models.DTOs.FacultyDTOs;

namespace VoceaUniversitatii.Services.FacultyService;

public class FacultyService : IFacultyService
{

    private readonly DatabaseContext _context;

    public FacultyService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<List<FacultySendDTO>> GetAllFaculties()
    {
        var databaseFaculties = await _context.Faculties.ToListAsync();
        var faculties =
            databaseFaculties.Select(FacultySendDTO.FacultyToFacultySendDTO);
        return faculties.ToList();
    }

    public async Task<FacultySendDTO> GetSingleFaculty(long id)
    {
        var databaseFaculty = await _context.Faculties.FindAsync(id);
        if (databaseFaculty == null) return null;
        var faculty = FacultySendDTO.FacultyToFacultySendDTO(databaseFaculty);
        return faculty;
    }

    public async Task<List<FacultySendDTO>> AddFaculty(FacultyCreateDTO faculty)
    {
        
        await _context.Faculties.AddAsync(FacultyCreateDTO.FacultyCreateDTOToFaculty(faculty));
        await _context.SaveChangesAsync();
        return await GetAllFaculties();
    }

    public async Task<List<FacultySendDTO>> UpdateFaculty(FacultyUpdateDTO request)
    {
        var id = request.Id;
        var databaseFaculty = await _context.Faculties.FindAsync(id);
        if (databaseFaculty == null) return null;
        // Update the values of the object
        
        databaseFaculty.FullName = request.FullName;
        databaseFaculty.ShortName = request.ShortName;

        await _context.SaveChangesAsync();

        return await GetAllFaculties();
    }

    public async Task<List<FacultySendDTO>> DeleteFaculty(long id)
    {
        var databaseFaculty = await _context.Faculties.FindAsync(id);
        if (databaseFaculty == null) return null;

        _context.Faculties.Remove(databaseFaculty);
        await _context.SaveChangesAsync();
        
        return await GetAllFaculties();
    }
}
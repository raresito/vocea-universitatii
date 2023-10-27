using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using vocea_universitatii.Helpers;

namespace vocea_universitatii.Services.FacultyService;

public class FacultyService : IFacultyService
{
    
    // private static List<Faculty> faculties = new List<Faculty>
    // {
    //     new Faculty
    //     {
    //         Id = 1,
    //         Name = "Facultatea de Matematica si Informatica",
    //         ShortName = "FMI"
    //     }
    // };

    private readonly FacultyContext _context;

    public FacultyService(FacultyContext context)
    {
        _context = context;
    }
    
    public async Task<List<Faculty>> GetAllFaculties()
    {
        var faculties = await _context.Faculties.ToListAsync();
        return faculties;
    }

    public async Task<Faculty> GetSingleFaculty(int id)
    {
        var faculty = await _context.Faculties.FindAsync(id);
        if (faculty is null)
        {
            return null;
        }
        return faculty;
    }

    public async Task<List<Faculty>> AddFaculty(Faculty faculty)
    {
        
        await _context.Faculties.AddAsync(faculty);
        await _context.SaveChangesAsync();
        return await GetAllFaculties();
    }

    public async Task<List<Faculty>> UpdateFaculty(int id, Faculty request)
    {
        var faculty = await _context.Faculties.FindAsync(id);
        if (faculty is null)
        {
            return null;
        }

        // Update the values of the object
        
        faculty.Id = request.Id;
        faculty.Name = request.Name;
        faculty.ShortName = request.ShortName;

        await _context.SaveChangesAsync();

        return await GetAllFaculties();
    }

    public async Task<List<Faculty>> DeleteFaculty(int id)
    {
        var faculty = await _context.Faculties.FindAsync(id);
        if (faculty is null)
        {
            return null;
        }

        _context.Faculties.Remove(faculty);
        await _context.SaveChangesAsync();
        
        return await GetAllFaculties();
    }
}
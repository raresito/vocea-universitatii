using Microsoft.EntityFrameworkCore;
using vocea_universitatii.Helpers;
using vocea_universitatii.Models;

namespace vocea_universitatii.Services.DepartmentService;

public class DepartmentService : IDepartmentService
{
    private readonly DatabaseContext _context;

    public DepartmentService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<List<Department>> GetAllDepartments()
    {
        var departments = await _context.Departments.ToListAsync();
        return departments;
    }

    public async Task<Department> GetSingleDepartment(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department is null)
        {
            return null;
        }
        return department;
    }

    public async Task<List<Department>> AddDepartment(Department department)
    {
        
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
        return await GetAllDepartments();
    }

    public async Task<List<Department>> UpdateDepartment(int id, Department request)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department is null)
        {
            return null;
        }

        // Update the values of the object
        
        department.Id = request.Id;
        department.FullName = request.FullName;

        await _context.SaveChangesAsync();

        return await GetAllDepartments();
    }

    public async Task<List<Department>> DeleteDepartment(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department is null)
        {
            return null;
        }

        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
        
        return await GetAllDepartments();
    }
}
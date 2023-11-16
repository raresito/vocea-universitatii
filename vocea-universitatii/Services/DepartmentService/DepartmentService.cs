using Microsoft.EntityFrameworkCore;
using VoceaUniversitatii.Helpers;
using VoceaUniversitatii.Models;
using VoceaUniversitatii.Models.DTOs.DepartmentDTOs;
using VoceaUniversitatii.Services.FacultyService;

namespace VoceaUniversitatii.Services.DepartmentService;

public class DepartmentService : IDepartmentService
{
    private readonly DatabaseContext _context;
    private readonly IFacultyService _facultyService;

    public DepartmentService(DatabaseContext context, IFacultyService facultyService)
    {
        _context = context;
        _facultyService = facultyService;
    }
    
    public DepartmentSendDTO DepartmentToDepartmentSendDto(Department department)
    {
        return new DepartmentSendDTO()
        {
            Id = department.Id,
            FullName = department.FullName,
            Faculty = _facultyService.GetSingleFaculty(department.FacultyId).Result
        };
    }

    public Department DepartmentCreateDtoToDepartment(DepartmentCreateDTO departmentCreateDto)
    {
        return new Department()
        {
            FullName = departmentCreateDto.FullName,
            FacultyId = departmentCreateDto.FacultyId,
        };
    }
    
    public async Task<List<DepartmentSendDTO>> GetAllDepartments()
    {
        var databaseDepartments = await _context.Departments.ToListAsync();
        return databaseDepartments.Select(DepartmentToDepartmentSendDto).ToList();
    }

    public async Task<DepartmentSendDTO> GetSingleDepartment(long id)
    {
        var databaseDepartment = await _context.Departments.FindAsync(id);
        if (databaseDepartment == null) return null;
        return DepartmentToDepartmentSendDto(databaseDepartment);
    }

    public async Task<List<DepartmentSendDTO>> AddDepartment(DepartmentCreateDTO department)
    {
        
        await _context.Departments.AddAsync(DepartmentCreateDtoToDepartment(department));
        await _context.SaveChangesAsync();
        return await GetAllDepartments();
    }

    public async Task<List<DepartmentSendDTO>> UpdateDepartment(DepartmentUpdateDTO request)
    {
        var id = request.Id;
        var databaseDepartment = await _context.Departments.FindAsync(id);
        if (databaseDepartment == null) return null;

        // Update the values of the object
        
        databaseDepartment.FullName = request.FullName;
        databaseDepartment.FacultyId = request.FacultyId;

        await _context.SaveChangesAsync();

        return await GetAllDepartments();
    }

    public async Task<List<DepartmentSendDTO>> DeleteDepartment(long id)
    {
        var databaseDepartment = await _context.Departments.FindAsync(id);
        if (databaseDepartment == null) return null;

        _context.Departments.Remove(databaseDepartment);
        await _context.SaveChangesAsync();
        
        return await GetAllDepartments();
    }
}
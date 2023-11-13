using Microsoft.EntityFrameworkCore;
using vocea_universitatii.Helpers;
using vocea_universitatii.Models;
using vocea_universitatii.Models.DTOs;
using vocea_universitatii.Services.DepartmentService;

namespace vocea_universitatii.Services.TeacherService;

public class TeacherService : ITeacherService
{
    private readonly DatabaseContext _context;
    private readonly IDepartmentService _departmentService;

    public TeacherService(DatabaseContext context, IDepartmentService departmentService)
    {
        _context = context;
        _departmentService = departmentService;
    }
    
    public TeacherSendDTO TeacherToTeacherSendDto(Teacher teacher)
    {
        var teacherDepartments = teacher.Departments.Select(_departmentService.DepartmentToDepartmentSendDto).ToList();
        var teacherDepartmentsMemberships = _context.Departments
            .Include(d => d.TeacherDepartmentMemberships)
            .SelectMany(d => d.TeacherDepartmentMemberships)
            .Where(tdm => tdm.TeacherId == teacher.Id)
            .ToList();
        
        var enhancedTeacherDepartments = teacherDepartments.Select(department =>
        {
            var membership = teacherDepartmentsMemberships.First(tdm => tdm.DepartmentId == department.Id);
            return new DepartmentOfTeacherSendDTO
            {
                Id = membership.DepartmentId,
                FullName = department.FullName,
                Faculty = department.Faculty,
                BaseDepartment = membership.BaseDepartment
            };
        }).ToList();
        
        return new TeacherSendDTO()
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Email = teacher.Email,
            Departments = enhancedTeacherDepartments,
            TeacherTitle = new TeacherTitleSendDTO()
            {
                Id = teacher.Title.Id,
                Title = teacher.Title?.Title
            }
        };
    }
    
    public Teacher TeacherCreateDtoToTeacher(TeacherCreateDTO teacherCreateDto)
    {
        var newTeacher = new Teacher()
        {
            FirstName = teacherCreateDto.FirstName,
            LastName = teacherCreateDto.LastName,
            Email = teacherCreateDto.Email,
            Departments = new List<Department>()
        };
        var teachersDepartment = _context.Departments.FirstOrDefault(s => s.Id == teacherCreateDto.BaseDepartmentId);
        newTeacher.Departments.Add(teachersDepartment);
        return newTeacher;
    }

    public async Task<TeacherSendDTO> AddTeacherDepartmentMembership(long teacherId, long departmentId)
    {
        // Find the teacher by their ID
        var teacher = await _context.Teachers
            .Include(t => t.TeacherDepartmentMemberships)
            .FirstOrDefaultAsync(t => t.Id == teacherId);

        // Find the department by their ID
        var department = await _context.Departments.FindAsync(departmentId);

        if (teacher != null && department != null)
        {
            // Create a new TeacherDepartmentMembership entity
            var membership = new TeacherDepartmentMembership
            {
                Teacher = teacher,
                DepartmentId = department.Id,
                BaseDepartment = false
            };

            // Add the new membership to the teacher's memberships
            teacher.TeacherDepartmentMemberships.Add(membership);

            // Save changes
            await _context.SaveChangesAsync();
        }

        return TeacherToTeacherSendDto(teacher);
    }

    public void ChangeTeacherBaseDepartment(long teacherId, long newDepartmentId)
    {
        var memberships = _context.Teachers
            .Include(t => t.TeacherDepartmentMemberships)
            .SelectMany(t => t.TeacherDepartmentMemberships)
            .Where(tdm => tdm.TeacherId == teacherId)
            .ToList();
        var currentBaseDepartmentMembership = memberships.FirstOrDefault(m => m.BaseDepartment);
        if (currentBaseDepartmentMembership != null)
        {
            currentBaseDepartmentMembership.BaseDepartment = false;
        }

        var newBaseDepartmentMembership = memberships.FirstOrDefault(m => m.DepartmentId == newDepartmentId);
        if (newBaseDepartmentMembership != null)
        {
            newBaseDepartmentMembership.BaseDepartment = true;
        }
    }
    
    public async Task<List<TeacherSendDTO>> GetAllTeachers()
    {
        var databaseTeachers = _context.Teachers
            .Include(t => t.Title)
            .Include(i => i.Departments).ToList();
        var teachers = databaseTeachers.Select(TeacherToTeacherSendDto).ToList();
        return teachers;
    }
    
    public async Task<TeacherSendDTO> GetSingleTeacher(long id)
    {
        // var databaseTeacher = await _context.Teachers.Include(i => i.Departments).FirstOrDefaultAsync(i => i.Id == id);
        var databaseTeacher = await _context.Teachers
            .Include(t => t.Title)
            .Include(i => i.TeacherDepartmentMemberships).FirstOrDefaultAsync(i => i.Id == id);
        if (databaseTeacher == null) return null;
        var teacher = TeacherToTeacherSendDto(databaseTeacher);
        return teacher;
    }
    
    public async Task<TeacherSendDTO> AddTeacher(TeacherCreateDTO teacher)
    {
        var newTeacher = TeacherCreateDtoToTeacher(teacher);
        await _context.Teachers.AddAsync(newTeacher);
        await _context.SaveChangesAsync();
        return await GetSingleTeacher(newTeacher.Id);
    }
    
    public async Task<List<TeacherSendDTO>> UpdateTeacher(TeacherUpdateDTO request)
    {
        var id = request.Id;
        var databaseTeacher = await _context.Teachers.FindAsync(id);
        if (databaseTeacher == null) return null;
    
        // Update the values of the object

        databaseTeacher.FirstName = request.FirstName;
        databaseTeacher.LastName = request.LastName;
        databaseTeacher.Email = request.Email;
        databaseTeacher.TeacherTitleId = request.TeacherTitleId;
        ChangeTeacherBaseDepartment(request.Id, request.BaseDepartmentId);
    
        await _context.SaveChangesAsync();
    
        return await GetAllTeachers();
    }
    
    public async Task<List<TeacherSendDTO>> DeleteTeacher(long id)
    {
        var databaseTeacher = await _context.Teachers.FindAsync(id);
        if (databaseTeacher == null) return null;
    
        _context.Teachers.Remove(databaseTeacher);
        await _context.SaveChangesAsync();

        return new List<TeacherSendDTO>();
    }
}
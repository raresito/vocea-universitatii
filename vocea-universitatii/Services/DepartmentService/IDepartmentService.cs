using vocea_universitatii.Models;
using vocea_universitatii.Models.DTOs;

namespace vocea_universitatii.Services.DepartmentService;

public interface IDepartmentService
{
    Task<List<DepartmentSendDTO>> GetAllDepartments();
    
    Task<DepartmentSendDTO> GetSingleDepartment(long id);
    
    Task<List<DepartmentSendDTO>> AddDepartment(DepartmentCreateDTO department);
    
    Task<List<DepartmentSendDTO>> UpdateDepartment(DepartmentUpdateDTO request);
    
    Task<List<DepartmentSendDTO>> DeleteDepartment(long id);
}
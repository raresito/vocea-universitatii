using VoceaUniversitatii.Models;
using VoceaUniversitatii.Models.DTOs.DepartmentDTOs;

namespace VoceaUniversitatii.Services.DepartmentService;

public interface IDepartmentService
{
    Task<List<DepartmentSendDTO>> GetAllDepartments();
    
    Task<DepartmentSendDTO> GetSingleDepartment(long id);
    
    Task<List<DepartmentSendDTO>> AddDepartment(DepartmentCreateDTO department);
    
    Task<List<DepartmentSendDTO>> UpdateDepartment(DepartmentUpdateDTO request);
    
    Task<List<DepartmentSendDTO>> DeleteDepartment(long id);

    DepartmentSendDTO DepartmentToDepartmentSendDto(Department department);
}
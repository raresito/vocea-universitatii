using VoceaUniversitatiiDataModels.Models;
using VoceaUniversitatiiDataModels.Models.DTOs.DepartmentDTOs;

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
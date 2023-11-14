using vocea_universitatii.Models;
using vocea_universitatii.Models.DTOs.DisciplineDTOs;

namespace vocea_universitatii.Services.DisciplineService;

public interface IDisciplineService
{
    Task<List<DisciplineSendDTO>> GetAllDisciplinesAsync();
    
    Task<DisciplineSendDTO> GetSingleDisciplineAsync(long id);
    
    Task<List<DisciplineSendDTO>> AddDisciplineAsync(DisciplineCreateDTO discipline);
    
    Task<DisciplineSendDTO> UpdateDisciplineAsync(DisciplineUpdateDTO request);
    
    Task<List<DisciplineSendDTO>> DeleteDisciplineAsync(long id);

    Task<DisciplineSendDTO> DisciplineToDisciplineSendDtoAsync(Discipline discipline);
}
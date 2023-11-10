using vocea_universitatii.Models;
using vocea_universitatii.Models.DTOs;
using vocea_universitatii.Services.FacultyService;

namespace vocea_universitatii_unit_testing.MockServices;

public class FacultyServiceMock : IFacultyService
{
    private readonly List<FacultySendDTO> _faculties;

    public FacultyServiceMock()
    {
        _faculties = new List<FacultySendDTO>(){
            new FacultySendDTO()
            {
                Id = 1, FullName = "Facultatea de Drept", ShortName = "FDrept"
            }
        };
    }
    public Task<List<FacultySendDTO>> GetAllFaculties()
    {
        return Task.FromResult(_faculties);
    }

    public Task<FacultySendDTO> GetSingleFaculty(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<FacultySendDTO>> AddFaculty(FacultyCreateDTO faculty)
    {
        throw new NotImplementedException();
    }

    public Task<List<FacultySendDTO>> UpdateFaculty(FacultyUpdateDTO request)
    {
        throw new NotImplementedException();
    }

    public Task<List<FacultySendDTO>> DeleteFaculty(long id)
    {
        throw new NotImplementedException();
    }
}
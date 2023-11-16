using Microsoft.AspNetCore.Mvc;
using Moq;
using vocea_universitatii_unit_testing.MockServices;
using VoceaUniversitatii.Controllers;
using VoceaUniversitatii.Models.DTOs.FacultyDTOs;
using VoceaUniversitatii.Services.FacultyService;

namespace vocea_universitatii_unit_testing;

public class Tests
{
    private FacultiesController _contoller;
    private FacultyServiceMock _service;
    private Mock<IFacultyService> singleFaculty_FacultyServiceStub;
    private List<FacultySendDTO> _singleFaculty;
    
    // These tests were written in two ways:
    // 1. By creating a Mock Service that implements the real interface, but mocks the functionality and Entity.
    // 2. Using Moq library to only mock the function from the service that was needed for the test. 
    [SetUp]
    public void Setup()
    {
        _service = new FacultyServiceMock();
        _contoller = new FacultiesController(_service);
        
        _singleFaculty = new List<FacultySendDTO>(){
            new FacultySendDTO()
            {
                Id = 1, FullName = "Facultatea de Drept", ShortName = "FDrept"
            }
        };

        singleFaculty_FacultyServiceStub = new Mock<IFacultyService>();
        singleFaculty_FacultyServiceStub
            .Setup(x => x.GetSingleFaculty(_singleFaculty.FirstOrDefault().Id))
            .Returns(Task.FromResult(_singleFaculty.FirstOrDefault())!);
    }

    [Test]
    public async Task GetAllFaculties_ReturnsOkResult_WhenFacultiesExist()
    {
        var okResult = await _contoller.GetAllFaculties();
        
        Assert.IsInstanceOf<OkObjectResult>(okResult.Result);
    }

    [Test]
    public async Task GetSingleFaculty_ReturnsOkResult_WhenFacultyFound()
    {
        var localController = new FacultiesController(singleFaculty_FacultyServiceStub.Object);
        var result = await localController.GetSingleFaculty(_singleFaculty.FirstOrDefault().Id);
        
        Assert.IsInstanceOf<OkObjectResult>(result.Result);
    }
}
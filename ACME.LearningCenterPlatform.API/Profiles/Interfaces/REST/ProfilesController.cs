using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ACME.LearningCenterPlatform.API.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Profiles")]
public class ProfilesController(
    IProfileCommandService profileCommandService,
    IProfileQueryService profileQueryService)
: ControllerBase
{
    
}
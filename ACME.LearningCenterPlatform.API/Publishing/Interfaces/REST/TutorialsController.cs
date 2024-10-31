using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST;

/// <summary>
///  The tutorial controller
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Tutorial Endpoints.")]
public class TutorialsController(
    ITutorialCommandService tutorialCommandService,
    ITutorialQueryService tutorialQueryService
    ) : ControllerBase
{
    /// <summary>
    /// Get tutorial by id 
    /// </summary>
    /// <param name="tutorialId">
    /// The id of the tutorial to get
    /// </param>
    /// <returns>
    /// The <see cref="TutorialResource"/> resource with the given id
    /// </returns>
    [HttpGet("{tutorialId:int}")]
    [SwaggerOperation(
        Summary = "Get tutorial by id",
        Description = "Get tutorial by id",
        OperationId = "GetTutorialById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The tutorial with the given id", typeof(TutorialResource))]
    public async Task<IActionResult> GetTutorialById([FromRoute] int tutorialId)
    {
        var tutorial = await tutorialQueryService.Handle(new GetTutorialByIdQuery(tutorialId));
        if (tutorial is null) return NotFound();
        var tutorialResource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return Ok(tutorialResource);
    }

    /// <summary>
    /// Create a new tutorial 
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateTutorialResource"/> resource to create
    /// </param>
    /// <returns>
    /// The <see cref="TutorialResource"/> resource created
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new tutorial",
        Description = "Create a new tutorial",
        OperationId = "CreateTutorial"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The created tutorial", typeof(TutorialResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is invalid")]
    public async Task<IActionResult> CreateTutorial([FromBody] CreateTutorialResource resource)
    {
        var createTutorialCommand = CreateTutorialCommandFromResourceAssembler.ToCommandFromResource(resource);
        var tutorial = await tutorialCommandService.Handle(createTutorialCommand);
        if (tutorial is null) return BadRequest();
        var tutorialResource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return CreatedAtAction(nameof(GetTutorialById), new { tutorialId = tutorial.Id }, tutorialResource);
    }
    
    /// <summary>
    /// Get all tutorials 
    /// </summary>
    /// <returns>
    /// The <see cref="TutorialResource"/> resources
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all tutorials",
        Description = "Get all tutorials",
        OperationId = "GetAllTutorials"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The tutorials", typeof(IEnumerable<TutorialResource>))]
    public async Task<IActionResult> GetAllTutorials()
    {
        var getAllTutorialsQuery = new GetAllTutorialsQuery();
        var tutorials = await tutorialQueryService.Handle(getAllTutorialsQuery);
        var tutorialResources = tutorials.Select(TutorialResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(tutorialResources);
    }

    /// <summary>
    /// Add a video to a tutorial 
    /// </summary>
    /// <param name="resource">
    /// The <see cref="AddVideoAssetToTutorialResource"/> resource to add
    /// </param>
    /// <param name="tutorialId">
    /// The id of the tutorial to add the video to
    /// </param>
    /// <returns>
    /// The <see cref="TutorialResource"/> resource with the added video
    /// </returns>
    [HttpPost("{tutorialId:int}/videos")]
    [SwaggerOperation(
        Summary = "Add a video to a tutorial",
        Description = "Add a video to a tutorial",
        OperationId = "AddVideoToTutorial"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The tutorial with the added video", typeof(TutorialResource))]
    public async Task<IActionResult> AddVideoToTutorial(
        [FromBody] AddVideoAssetToTutorialResource resource,
        [FromRoute] int tutorialId)
    {
        var addVideoAssetToTutorialCommand =
            AddVideoAssetToTutorialCommandFromResourceAssembler.ToCommandFromResource(resource, tutorialId);
        var tutorial = await tutorialCommandService.Handle(addVideoAssetToTutorialCommand);
        if (tutorial is null) return BadRequest();
        var tutorialResource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return CreatedAtAction(nameof(GetTutorialById), new { tutorialId = tutorial.Id }, tutorialResource);
    }
    
    
}
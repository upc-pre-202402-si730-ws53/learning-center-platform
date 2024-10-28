using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST;

/// <summary>
/// Controller for managing tutorials by category 
/// </summary>
/// <param name="tutorialQueryService">
/// The tutorial query service
/// </param>
[ApiController]
[Route("api/v1/categories/{categoryId:int}/tutorials")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Categories")]
public class CategoryTutorialsController(ITutorialQueryService tutorialQueryService) : ControllerBase
{
    /// <summary>
    /// Get tutorials by category id 
    /// </summary>
    /// <param name="categoryId">
    /// The category id to get tutorials for
    /// </param>
    /// <returns>
    /// The <see cref="TutorialResource"/> resources for the given category id
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get tutorials by category id",
        Description = "Get tutorials by category id",
        OperationId = "GetTutorialsByCategoryId")]
    [SwaggerResponse(StatusCodes.Status200OK, "The tutorials with the given category id", typeof(IEnumerable<TutorialResource>))]
    public async Task<IActionResult> GetTutorialsByCategoryId([FromRoute] int categoryId)
    {
        var getAllTutorialsByCategoryIdQuery = new GetAllTutorialsByCategoryIdQuery(categoryId);
        var tutorials = await tutorialQueryService.Handle(getAllTutorialsByCategoryIdQuery);
        var tutorialResources = tutorials.Select(TutorialResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(tutorialResources);
        
    }
    
}
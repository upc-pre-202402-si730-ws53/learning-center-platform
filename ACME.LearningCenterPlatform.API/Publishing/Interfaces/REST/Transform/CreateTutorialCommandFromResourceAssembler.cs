using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;

/// <summary>
/// Assembler to create a CreateTutorialCommand from a CreateTutorialResource 
/// </summary>
public static class CreateTutorialCommandFromResourceAssembler
{
    /// <summary>
    /// Assembles a CreateTutorialCommand from a CreateTutorialResource
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateTutorialResource"/> resource to assemble the command from
    /// </param>
    /// <returns>
    /// The <see cref="CreateTutorialCommand"/> command assembled from the resource
    /// </returns>
    public static CreateTutorialCommand ToCommandFromResource(CreateTutorialResource resource)
    {
        return new CreateTutorialCommand(resource.Title, resource.Summary, resource.CategoryId);
    }
}
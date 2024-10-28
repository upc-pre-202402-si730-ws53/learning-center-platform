using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;
using Microsoft.OpenApi.Extensions;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;

/// <summary>
/// Assembler to create a TutorialResource from a Tutorial entity 
/// </summary>
public static class TutorialResourceFromEntityAssembler
{
    /// <summary>
    /// Assembles a TutorialResource from a Tutorial entity 
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Tutorial"/> entity to assemble the resource from
    /// </param>
    /// <returns>
    /// The <see cref="TutorialResource"/> resource assembled from the entity
    /// </returns>
    public static TutorialResource ToResourceFromEntity(Tutorial entity)
    {
        return new TutorialResource(
            entity.Id,
            entity.Title,
            entity.Summary,
            CategoryResourceFromEntityAssembler.ToResourceFromEntity(entity.Category),
            entity.Status.GetDisplayName()
        );
    } 
}
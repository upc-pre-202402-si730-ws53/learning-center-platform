using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to convert a Category entity to a CategoryResource 
/// </summary>
public static class CategoryResourceFromEntityAssembler
{
    /// <summary>
    /// Convert a Category entity to a CategoryResource 
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Category"/> entity to convert 
    /// </param>
    /// <returns>
    /// The converted <see cref="CategoryResource"/> resource
    /// </returns>
    public static CategoryResource ToResourceFromEntity(Category entity)
    {
        return new CategoryResource(entity.Id, entity.Name);
    }
}
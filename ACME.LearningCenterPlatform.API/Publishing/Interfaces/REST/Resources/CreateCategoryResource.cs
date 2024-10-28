namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

/// <summary>
/// Resource for creating a category 
/// </summary>
/// <param name="Name">
/// The name of the category to create
/// </param>
public record CreateCategoryResource(string Name);
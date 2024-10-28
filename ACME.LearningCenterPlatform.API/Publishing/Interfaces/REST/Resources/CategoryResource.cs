namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

/// <summary>
/// Resource for a category 
/// </summary>
/// <param name="Id">
/// The unique identifier of the category
/// </param>
/// <param name="Name">
/// The name of the category
/// </param>
public record CategoryResource(int Id, string Name);

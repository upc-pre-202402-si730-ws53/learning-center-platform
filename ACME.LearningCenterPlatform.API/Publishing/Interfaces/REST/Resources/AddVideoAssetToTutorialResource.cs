namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

/// <summary>
/// Resource for adding a video asset to a tutorial 
/// </summary>
/// <param name="VideoUrl">
/// The URL of the video asset to add to the tutorial
/// </param>
public record AddVideoAssetToTutorialResource(string VideoUrl);
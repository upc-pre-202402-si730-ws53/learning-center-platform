using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to transform AddVideoAssetToTutorialResource to AddVideoAssetToTutorialCommand 
/// </summary>
public static class AddVideoAssetToTutorialCommandFromResourceAssembler
{
    /// <summary>
    /// Transform AddVideoAssetToTutorialResource to AddVideoAssetToTutorialCommand 
    /// </summary>
    /// <param name="resource">
    /// The <see cref="AddVideoAssetToTutorialResource"/> to transform
    /// </param>
    /// <param name="tutorialId">
    /// The tutorial id to add the video asset to
    /// </param>
    /// <returns>
    /// The <see cref="AddVideoAssetToTutorialCommand"/> command
    /// </returns>
    public static AddVideoAssetToTutorialCommand ToCommandFromResource(AddVideoAssetToTutorialResource resource, int tutorialId)
    {
        return new AddVideoAssetToTutorialCommand(resource.VideoUrl, tutorialId);
    }
}
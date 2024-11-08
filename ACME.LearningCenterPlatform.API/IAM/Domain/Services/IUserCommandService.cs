using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.IAM.Domain.Services;

/// <summary>
/// User command service
/// </summary>
/// <remarks>
/// This service is responsible for handling user commands.
/// </remarks>  
public interface IUserCommandService
{
    /// <summary>
    /// Handle sign-up command 
    /// </summary>
    /// <param name="command">
    /// The sign-up command
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation
    /// </returns>
    Task Handle(SignUpCommand command);
    
    /// <summary>
    /// Handle sign-in command 
    /// </summary>
    /// <param name="command">
    /// The sign-in command
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation, containing the <see cref="User"/> user and generated token
    /// </returns>
    Task<(User user, string token)> Handle(SignInCommand command);
}
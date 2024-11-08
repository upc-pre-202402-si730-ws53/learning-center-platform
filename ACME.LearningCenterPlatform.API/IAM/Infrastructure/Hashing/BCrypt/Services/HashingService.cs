using ACME.LearningCenterPlatform.API.IAM.Application.Internal.OutboundServices;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ACME.LearningCenterPlatform.API.IAM.Infrastructure.Hashing.BCrypt.Services;

/// <summary>
/// Hashing service using BCrypt algorithm. 
/// </summary>
public class HashingService : IHashingService
{
    // inheritedDoc
    public string HashPassword(string password)
    {
        return BCryptNet.HashPassword(password);
    }

    // inheritedDoc
    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCryptNet.Verify(password, passwordHash);
    }
}
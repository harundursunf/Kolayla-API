using Core.Utilities.Security.JWT;

using Entities.Entities;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(User user);
    }
}

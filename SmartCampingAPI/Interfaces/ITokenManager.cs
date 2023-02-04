namespace SmartCamping.Models
{
    public interface ITokenManager
    {
        Token GenerateToken();
        bool VerifyToken(string token);
    }
}

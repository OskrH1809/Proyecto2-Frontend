using System.Threading.Tasks;

public interface IAuthService
{
    Task<string?> LoginAsync(LoginRequest request);
}

using Tiketoo.Contracts.User;
namespace Tiketoo.Services.Users;

public interface IUserService
{
    Models.User CreateUser(Contracts.User.CreateUserRequest request);
    Models.User GetUser(Guid id);
}
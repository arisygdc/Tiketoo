using Tiketoo.Repository.SqlServer;
using BC = BCrypt.Net.BCrypt;
namespace Tiketoo.Services.Users;

public class UserService : IUserService
{
    private readonly TiketooRepository _tiketooRepository;

    public UserService(TiketooRepository tiketooRepository)
    {
        _tiketooRepository = tiketooRepository;
    }

    public Models.User CreateUser(Contracts.User.CreateUserRequest request)
    {
        var user = new Models.User(
            Guid.NewGuid(),
            request.Name,
            request.Email,
            request.Password
        );
        
        _tiketooRepository.Add(new Repository.Entities.User {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            Password = BC.HashPassword(user.Password)
        });
        
        if (_tiketooRepository.SaveChanges() == 0)
            throw new Exception("Could not save user to database");

        return user;
    }

    public Models.User GetUser(Guid id)
    {
        var user = _tiketooRepository.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            throw new Exception("User not found");

        return new Models.User(
            user.Id,
            user.Name,
            user.Email,
            user.Password
        );
    }
}
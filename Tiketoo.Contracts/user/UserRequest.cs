namespace Tiketoo.Contracts.User;

public record CreateUserRequest(
    string Name,
    string Email,
    string Password
);

public record UpsertUserRequest(
    string Name,
    string Email,
    string Password
);
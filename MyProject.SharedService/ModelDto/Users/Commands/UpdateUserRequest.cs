namespace MyProject.SharedService.ModelDto.Users.Commands;

public record UpdateUserRequest(int Id, string FirstName, string LastName, int RoleId);

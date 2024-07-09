using Microsoft.AspNetCore.Http;

namespace MyProject.SharedService.ModelDto.Users.Commands;

//For MVC
//public record CreateUserRequest(string FirstName, string LastName, int RoleId, IFormFile imageUpload);

public record CreateUserRequest(string FirstName, string LastName, int RoleId);
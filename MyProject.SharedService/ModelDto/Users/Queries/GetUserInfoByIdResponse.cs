namespace MyProject.SharedService.ModelDto.Users.Queries;

public record GetUserInfoByIdResponse(int Id, string FirstName, string LastName, string RoleTitle, DateTime InsertDate, bool IsDeleted);

namespace MyProject.SharedService.ModelDto.Users.Queries;

public record GetUserBySearchRequest(string name, string family, string roleTitle);

namespace MyProject.SharedService.ModelDto.Users.Queries;

public record GetAllUsersRequest(int pageNumber, int pageSize, string query);
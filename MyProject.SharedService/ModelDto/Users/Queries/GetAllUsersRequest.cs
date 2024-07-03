namespace MyProject.SharedService.ModelDto.Users.Queries;

public record GetAllUsersRequest(int pageNumber = 1, int pageSize = 5, string query = "");
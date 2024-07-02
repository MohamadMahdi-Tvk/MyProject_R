namespace MyProject.SharedService.ModelDto.Roles.Queries;

public record GetAllRolesRequest(int PageNumber, int PageSize, string Query);
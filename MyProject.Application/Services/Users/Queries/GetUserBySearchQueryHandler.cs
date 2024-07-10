using Dapper;
using MediatR;
using MyProject.DataAccess.UnitOfWork;
using MyProject.SharedService.ModelDto.Users.Queries;
using System.Data;

namespace MyProject.Application.Services.Users.Queries;

public class GetUserBySearchQueryHandler : IRequestHandler<GetUserBySearchQuery, List<GetUserBySearchResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserBySearchQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetUserBySearchResponse>> Handle(GetUserBySearchQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("name", request.Query.name);
            parameters.Add("family", request.Query.family);
            parameters.Add("roleTitle", request.Query.roleTitle);

            var model = await _unitOfWork.ApplicationReadDbConnection.QueryAsync<GetUserBySearchResponse>("GetUserBySearch", parameters, null, CommandType.StoredProcedure, cancellationToken);

            return model;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

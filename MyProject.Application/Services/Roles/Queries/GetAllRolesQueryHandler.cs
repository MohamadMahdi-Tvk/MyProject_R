using Dapper;
using MediatR;
using MyProject.DataAccess.UnitOfWork;
using MyProject.SharedService.ModelDto.Roles.Queries;
using MyProject.SharedService.Utilities;
using System.Data;

namespace MyProject.Application.Services.Roles.Queries;

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, Paginated<GetAllRolesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRolesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Paginated<GetAllRolesResponse>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("PageNumber", request.Query.PageNumber);
            parameters.Add("PageSize", request.Query.PageSize);
            parameters.Add("Query", request.Query.Query);
            parameters.Add("totalRow", 0, null, ParameterDirection.Output);

            var model = await _unitOfWork.ApplicationReadDbConnection.QueryAsync<GetAllRolesResponse>("GetAllRoles", parameters, null, CommandType.StoredProcedure, cancellationToken);

            var totalRow = parameters.Get<int>("totalRow");

            return new Paginated<GetAllRolesResponse>
            {
                data = model,
                pageIndex = request.Query.PageNumber,
                totalItems = totalRow,
                totalPages = (int)Math.Ceiling(totalRow / (double)request.Query.PageSize)
            };
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

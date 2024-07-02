using Dapper;
using MediatR;
using MyProject.DataAccess.UnitOfWork;
using MyProject.SharedService.ModelDto.Users.Queries;
using MyProject.SharedService.Utilities;
using System.Data;

namespace MyProject.Application.Services.Users.Queries;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Paginated<GetAllUsersResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllUsersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Paginated<GetAllUsersResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", request.Query.pageNumber);
            parameters.Add("PageSize", request.Query.pageSize);
            parameters.Add("Query", request.Query.query);
            parameters.Add("totalRow", 0, null, ParameterDirection.Output);


            var model = await _unitOfWork.ApplicationReadDbConnection.QueryAsync<GetAllUsersResponse>("GetAllUsers", parameters, null, CommandType.StoredProcedure, cancellationToken);

            var totalRow = parameters.Get<int>("totalRow");

            return new Paginated<GetAllUsersResponse>()
            {
                data = model,
                pageIndex = request.Query.pageNumber,
                totalItems = totalRow,
                totalPages = (int)Math.Ceiling(totalRow / (double)request.Query.pageSize)
            };


        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

using Dapper;
using MediatR;
using MyProject.DataAccess.UnitOfWork;
using MyProject.SharedService.ModelDto.Users.Queries;
using System.Data;

namespace MyProject.Application.Services.Users.Queries;

public class GetUserInfoByIdQueryHandler : IRequestHandler<GetUserInfoByIdQuery, GetUserInfoByIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserInfoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetUserInfoByIdResponse> Handle(GetUserInfoByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("Id", request.Query.Id);

            var model = await _unitOfWork.ApplicationReadDbConnection.QueryFirstAsync<GetUserInfoByIdResponse>("GetUserInfoById", parameters, null, CommandType.StoredProcedure, cancellationToken);

            return model;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

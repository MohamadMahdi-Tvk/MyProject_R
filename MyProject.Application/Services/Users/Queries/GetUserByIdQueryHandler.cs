using AutoMapper;
using Dapper;
using MediatR;
using MyProject.DataAccess.Models;
using MyProject.DataAccess.UnitOfWork;
using MyProject.SharedService.ModelDto.Users.Queries;
using System.Data;

namespace MyProject.Application.Services.Users.Queries;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            //var model = await _unitOfWork.UserRepository.Get(request.Query.Id);

            //var modelMapped = _mapper.Map<User, GetUserByIdResponse>(model);

            var parameters = new DynamicParameters();

            parameters.Add("Id", request.Query.Id);

            var model = await _unitOfWork.ApplicationReadDbConnection.QueryFirstAsync<GetUserByIdResponse>("GetUserById", parameters, null, CommandType.StoredProcedure, cancellationToken);

            return model;

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

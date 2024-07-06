using AutoMapper;
using MediatR;
using MyProject.DataAccess.UnitOfWork;
using MyProject.SharedService.ModelDto.Users.Queries;

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

            // ---------------------------- Dapper START ----------------------------
            //var parameters = new DynamicParameters();

            //parameters.Add("Id", request.Query.Id);

            //var model = await _unitOfWork.ApplicationReadDbConnection.QueryFirstAsync<GetUserByIdResponse>("GetUserById", parameters, null, CommandType.StoredProcedure, cancellationToken);

            //return model;

            // ---------------------------- Dapper END ----------------------------


            var user = await _unitOfWork.UserRepository.GetUserWithRoles(request.Query.Id);

            return new GetUserByIdResponse(user.FirstName, user.LastName, user.Role.Title);


        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

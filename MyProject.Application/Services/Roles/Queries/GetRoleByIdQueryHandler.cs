using AutoMapper;
using MediatR;
using MyProject.DataAccess.Models;
using MyProject.DataAccess.UnitOfWork;
using MyProject.SharedService.ModelDto.Roles.Queries;

namespace MyProject.Application.Services.Roles.Queries;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, GetRoleByIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRoleByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetRoleByIdResponse> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _unitOfWork.RoleRepository.Get(request.Query.Id);

            var modelMapped = _mapper.Map<Role, GetRoleByIdResponse>(model);

            return modelMapped;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

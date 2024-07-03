using AutoMapper;
using MediatR;
using MyProject.DataAccess.Models;
using MyProject.DataAccess.UnitOfWork;
using MyProject.SharedService.ModelDto.Roles.Queries;

namespace MyProject.Application.Services.Roles.Commands;

public class GetRolesForUserCreateQueryHandler : IRequestHandler<GetRolesForUserCreateQuery, IEnumerable<GetRolesForUserCreateResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRolesForUserCreateQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetRolesForUserCreateResponse>> Handle(GetRolesForUserCreateQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _unitOfWork.RoleRepository.GetAll();

            var modelMapped = _mapper.Map<IEnumerable<Role>, IEnumerable<GetRolesForUserCreateResponse>>(model);

            return modelMapped;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

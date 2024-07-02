using AutoMapper;
using MediatR;
using MyProject.DataAccess.Models;
using MyProject.DataAccess.UnitOfWork;
using MyProject.SharedService.ModelDto.Roles.Commands;

namespace MyProject.Application.Services.Roles.Commands;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CreateRoleResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateRoleResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var model = _mapper.Map<CreateRoleRequest, Role>(request.Query);

            await _unitOfWork.RoleRepository.AddAsync(model);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateRoleResponse(Success: true);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

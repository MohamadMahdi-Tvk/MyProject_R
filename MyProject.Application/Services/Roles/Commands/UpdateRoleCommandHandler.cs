using AutoMapper;
using MediatR;
using MyProject.DataAccess.UnitOfWork;
using MyProject.SharedService.ModelDto.Roles.Commands;

namespace MyProject.Application.Services.Roles.Commands;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, UpdateRoleResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateRoleResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var oldEntity = await _unitOfWork.RoleRepository.Get(request.Command.Id);

            var newEntity = _mapper.Map(request.Command, oldEntity);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UpdateRoleResponse(Success: true);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

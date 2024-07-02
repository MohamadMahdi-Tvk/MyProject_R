using MediatR;
using MyProject.DataAccess.UnitOfWork;
using MyProject.SharedService.ModelDto.Roles.Commands;

namespace MyProject.Application.Services.Roles.Commands;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, DeleteRoleResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRoleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteRoleResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _unitOfWork.RoleRepository.Get(request.Command.Id);

            await _unitOfWork.RoleRepository.Delete(model);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new DeleteRoleResponse(Success: true);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

using AutoMapper;
using MediatR;
using MyProject.DataAccess.Models;
using MyProject.DataAccess.UnitOfWork;
using MyProject.SharedService.ModelDto.Users.Commands;

namespace MyProject.Application.Services.Users.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _unitOfWork.UserRepository.Get(request.Command.Id);

            await _unitOfWork.UserRepository.Delete(model);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new DeleteUserResponse(Success: true);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

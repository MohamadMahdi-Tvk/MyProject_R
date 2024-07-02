using AutoMapper;
using MediatR;
using MyProject.DataAccess.UnitOfWork;
using MyProject.SharedService.ModelDto.Users.Commands;

namespace MyProject.Application.Services.Users.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var oldEntity = await _unitOfWork.UserRepository.Get(request.Command.Id);

            var newEntity = _mapper.Map(request.Command, oldEntity);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UpdateUserResponse(Success: true);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

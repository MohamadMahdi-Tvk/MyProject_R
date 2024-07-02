using AutoMapper;
using MediatR;
using MyProject.DataAccess.Models;
using MyProject.DataAccess.UnitOfWork;
using MyProject.SharedService.ModelDto.Users.Commands;

namespace MyProject.Application.Services.Users.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var modelMapped = _mapper.Map<CreateUserRequest, User>(request.Command);

            await _unitOfWork.UserRepository.AddAsync(modelMapped);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateUserResponse(Success: true);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using MyProject.DataAccess.Models;
using MyProject.DataAccess.UnitOfWork;
using MyProject.SharedService.ModelDto.Users.Commands;
using System;

namespace MyProject.Application.Services.Users.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHostingEnvironment _environment;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHostingEnvironment environment)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _environment = environment;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var modelMapped = _mapper.Map<CreateUserRequest, User>(request.Command);

            //var uploads = Path.Combine(_environment.WebRootPath, "Images/Users/Profiles/");

            //string imageUrl = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(request.Command.imageUpload.FileName);

            //using (var fileStream = new FileStream(Path.Combine(uploads, imageUrl), FileMode.Create))
            //{
            //    await request.Command.imageUpload.CopyToAsync(fileStream);
            //}

            //modelMapped.ImageUrl = imageUrl;

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

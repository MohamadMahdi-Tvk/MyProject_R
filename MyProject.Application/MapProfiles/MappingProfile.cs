using AutoMapper;
using MyProject.DataAccess.Models;
using MyProject.SharedService.ModelDto.Roles.Commands;
using MyProject.SharedService.ModelDto.Roles.Queries;
using MyProject.SharedService.ModelDto.Users.Commands;
using MyProject.SharedService.ModelDto.Users.Queries;

namespace MyProject.Application.MapProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region User

        CreateMap<User, GetUserByIdResponse>().ReverseMap();

        CreateMap<User, CreateUserRequest>().ReverseMap();

        CreateMap<User, UpdateUserRequest>().ReverseMap();

        CreateMap<User, DeleteUserRequest>().ReverseMap();

        #endregion

        #region Role

        CreateMap<Role, GetRoleByIdResponse>().ReverseMap();

        CreateMap<Role, CreateRoleRequest>().ReverseMap();

        CreateMap<Role, UpdateRoleRequest>().ReverseMap();

        CreateMap<Role, GetRolesForUserCreateResponse>().ReverseMap();

        #endregion
    }
}

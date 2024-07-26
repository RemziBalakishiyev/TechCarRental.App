using CarRental.Application.Dtos;
using CarRental.Application.Mappers;
using CarRental.Domain.Entities.Accounts;
using MediatR;

namespace CarRental.Application.Features.Command
{
    public class CreatUserCommand : IMapTo<User>, IMapTo<UserDetail> , IRequest<AuthenticatedUserDto>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}

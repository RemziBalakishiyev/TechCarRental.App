using AutoMapper;
using CarRental.Application.Dtos;
using CarRental.Application.Helper;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities.Accounts;
using MediatR;

namespace CarRental.Application.Features.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreatUserCommand, AuthenticatedUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public CreateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<AuthenticatedUserDto> Handle(CreatUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            user.UserDetail = _mapper.Map<UserDetail>(request);

            byte[] passwordHash, passwordSalt;

            HashHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            user.PasswordHash = Convert.ToBase64String(passwordHash);
            user.PasswordSalt = Convert.ToBase64String(passwordSalt);

            await _unitOfWork.UserRepository.AddUser(user);
            await _unitOfWork.Commit();

            return await _mediator.Send(new GenerateTokenCommand
            {
                Email = request.Email,
                Password = request.Password
            });
        }
    }
}

using Application.Common.Exceptions;
using Domain.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public record AddUserCommand(
        string Id,
        string Email,
        string FirstName,
        string LastName
    ) : IRequest<Resources.User.User>;

    public class AddUser : IRequestHandler<AddUserCommand, Resources.User.User>
    {
        private readonly IUserRepository _userRepository;

        public AddUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Resources.User.User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            await CheckExistingUser(request.Id);
            var newUser = new Domain.User.User(request.Id, request.Email, request.FirstName, request.LastName);
            await _userRepository.Add(newUser);
            return new Resources.User.User(newUser.Id, newUser.Email, newUser.FirstName, newUser.LastName);
        }

        private async Task CheckExistingUser(string id)
        {
            if ((await _userRepository.GetById(id)) != null) 
            {
                throw new DuplicateEntityException("User with that Id already exists");
            }
        }
    }
}

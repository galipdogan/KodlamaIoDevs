﻿using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdatedUserDto>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocailMedia { get; set; }



        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdatedUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {

                await _userBusinessRules.EmailCanNotBeDuplicatedWhenInsterted(request.Email);

                User? mappedUser = _mapper.Map<User>(request);
                User updatedUser = await _userRepository.UpdateAsync(mappedUser);
                UpdatedUserDto updatedUserDto = _mapper.Map<UpdatedUserDto>(updatedUser);

                return updatedUserDto;

            }
        }

    }
}
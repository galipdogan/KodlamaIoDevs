﻿using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string[] Roles => new[] { "admin" };
        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }


            public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyBusinessRules.TechnologyNameCanNotBeDuplicatedWhenUpdated(request.Name);

                Technology? mappedTechnology = _mapper.Map<Technology>(request);
                Technology updatedTechnology = await _technologyRepository.UpdateAsync(mappedTechnology);
                UpdatedTechnologyDto updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updatedTechnology);

                return updatedTechnologyDto;
            }

        }
    }
}


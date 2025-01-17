﻿using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguageCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Application.Features.ProgrammingLanguages.Commands.Delete
{
    public class DeleteProgrammingLanguageValidator : AbstractValidator<DeleteOperationClaimCommand>
    {
        public DeleteProgrammingLanguageValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
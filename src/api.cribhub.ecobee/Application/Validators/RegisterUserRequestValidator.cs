using api.cribhub.ecobee.domain.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ecobee.Application.Validators
{
    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.AuthCode).NotEmpty();
            RuleFor(x => x.State).NotEmpty();
        }
    }
}

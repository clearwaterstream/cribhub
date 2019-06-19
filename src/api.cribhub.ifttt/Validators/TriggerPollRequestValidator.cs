using api.cribhub.ifttt.Filters;
using api.cribhub.ifttt.Model;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Validators
{
    public class TriggerPollRequestValidator : AbstractValidator<TriggerPollRequest>
    {
        public TriggerPollRequestValidator()
        {
            RuleFor(x => x.triggerFields).NotNull();
            RuleFor(x => x).Custom(MustHaveTriggerFileds);
        }

        static void MustHaveTriggerFileds(TriggerPollRequest req, CustomContext validationContext)
        {
            if (req == null || req.triggerFields == null)
                return;

            var reqdFields = RequiredTriggerFields.Get(req.triggerName);

            if (reqdFields == null || !reqdFields.Any())
                return;

            foreach(var f in reqdFields)
            {
                if(!req.triggerFields.Keys.Contains(f, StringComparer.OrdinalIgnoreCase))
                {
                    validationContext.AddFailure(new ValidationFailure($"{nameof(req.triggerFields)}.{f}", $"field {f} was not supplied"));

                    break; // break!!
                }
            }
        }
    }
}

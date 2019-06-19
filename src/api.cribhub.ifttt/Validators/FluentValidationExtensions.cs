using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Validators
{
    public static class FluentValidationExtensions
    {
        public static bool HasErrors(this ValidationResult validationResult)
        {
            var result = HasValidationFailuresBySeverity(validationResult, Severity.Error);

            return result;
        }

        public static bool HasWarnings(this ValidationResult validationResult)
        {
            var result = HasValidationFailuresBySeverity(validationResult, Severity.Warning);

            return result;
        }

        static bool HasValidationFailuresBySeverity(ValidationResult validationResult, Severity severity)
        {
            if (validationResult == null || validationResult.Errors == null)
                return false;

            var hasAny = validationResult.Errors.Any(x => x != null && x.Severity == severity);

            return hasAny;
        }

        public static IEnumerable<ValidationFailure> GetErrors(this ValidationResult validationResult)
        {
            return validationResult.Errors.Where(x => x.Severity == Severity.Error);
        }
    }
}

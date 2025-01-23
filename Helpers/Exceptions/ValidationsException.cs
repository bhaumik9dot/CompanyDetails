using System.ComponentModel.DataAnnotations;

namespace LeverateFXCRM.Helpers
{
    public class ValidationsException : ApplicationException
    {
        public List<string> ValdationErrors { get; set; }

        public ValidationsException(ValidationResult validationResult)
        {
            ValdationErrors = new List<string>();

            foreach (var validationError in validationResult.MemberNames)
            {
                ValdationErrors.Add(validationError);
            }
        }

    }
}

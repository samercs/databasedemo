using System.ComponentModel.DataAnnotations;

namespace DatabaseDemo.Core
{
    public class WorkCountAttribute: ValidationAttribute
    {
        private readonly int _maxWord;

        public WorkCountAttribute(int maxWord) : base("{0} has too many words")
        {
            _maxWord = maxWord;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value.ToString().Split(' ').Length > _maxWord)
            {
                var errorMsg = FormatErrorMessage(context.DisplayName);
                return new ValidationResult(errorMsg);
            }
            return ValidationResult.Success;
        }
    }
}
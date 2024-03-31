namespace CleanArchitecture.Contract.Abstractions.Shared
{
    public sealed class ValidationResult : Result, IValidationResult
    {
        public ValidationResult(Error[] errors) : base(false, IValidationResult.ValidationError)
        {
            Errors = errors;
        }

        public Error[] Errors { get; }
        public static ValidationResult WithErrors(Error[] errors) => new(errors);
    }
    public sealed class ValidationResult<TRespone> : Result<TRespone>, IValidationResult
    {
        public ValidationResult(Error[] errors) : base(default, false, IValidationResult.ValidationError)
        {
            Errors = errors;
        }

        public Error[] Errors { get; }
        public static ValidationResult<TRespone> WithErrors(Error[] errors) => new(errors);
    }
}

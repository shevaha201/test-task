namespace TestTask.WebApi.Core.Dto
{
    public class AddUserAttemptResult
    {
        public Type ResultType { get; }


        public AddUserAttemptResult(Type resultType)
        {
            ResultType = resultType;
        }

        public enum Type
        {
            Success,
            AttemptsCountExceeded,
            LessThanRangeMinValue,
            MoreThanRangeMaxValue,
            IncorrectValue
        }
    }
}

namespace TestTask.WebApi.Core.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IntValue { get; set; }
    }

    public static class SettingName
    {
        public const string SecretRangeMinValue = "SecretRangeMinValue";
        public const string SecretRangeMaxValue = "SecretRangeMaxValue";
        public const string EnterSecretNumberAttemptsCount = "EnterSecretNumberAttemptsCount";
        public const string SecretValue = "SecretValue";
    }
}

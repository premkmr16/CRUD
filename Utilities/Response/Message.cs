namespace Utilities.Response
{
    public static class Message
    {
        public const string SuccessCode = "CRUD100";
        public const string FailureCode = "CRUD101";
        public const string ApplicationErrorCode = "CRUD102";
        public const string InvalidDataCode = "CRUD103";

        public const string SuccessMessage = "Success";
        public const string FailureMessage = "Failure";
        public const string ApplicationErrorMessage = "ApplicationError";
        public const string InvalidDataMessage = "Invalid Data";

        public static string GetMessages(string code)
        {
            switch (code)
            {
                case SuccessCode:
                    return SuccessMessage;

                case FailureCode:
                    return FailureMessage;

                case ApplicationErrorCode:
                    return ApplicationErrorMessage;

                case InvalidDataCode:
                    return InvalidDataCode;

                default:
                    return "";
            }
        }
    }
}

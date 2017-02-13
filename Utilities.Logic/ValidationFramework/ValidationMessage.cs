namespace TIUtilities.Logic.ValidationFramework
{
    public sealed class ValidationMessage
    {
        public string Message { get; set; }
        public bool Warning { get; set; }

        //Only allow creation internally or by ValidationResult class.
        public ValidationMessage()
        {
        }
    }
}
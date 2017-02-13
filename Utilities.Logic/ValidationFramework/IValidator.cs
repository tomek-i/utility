namespace TIUtilities.Logic.ValidationFramework
{
    public interface IValidator<in T>
    {
        ValidationResult Validate(T obj);
        ValidationResult Validate(T obj, bool supressWarnings);
    }
}
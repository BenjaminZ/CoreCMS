namespace CoreCMS.Persistence.Encryption
{
    public interface IValidate
    {
        bool Validate(string origin, string encrypted);
    }
}
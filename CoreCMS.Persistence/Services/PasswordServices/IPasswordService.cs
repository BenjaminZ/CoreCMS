using CoreCMS.Persistence.Encryption;

namespace CoreCMS.Persistence.Services.PasswordServices
{
    public interface IPasswordService: IEncryptService, IValidate
    {
    }
}
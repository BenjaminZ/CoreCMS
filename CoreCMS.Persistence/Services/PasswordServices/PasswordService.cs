using CoreCMS.Persistence.Encryption;

namespace CoreCMS.Persistence.Services.PasswordServices
{
    public class PasswordService : IPasswordService
    {
        private readonly IEncryptService _encryptService;

        public PasswordService(IEncryptService encryptService)
        {
            _encryptService = encryptService;
        }

        public string Encrypt(string origin)
        {
            return _encryptService.Encrypt(origin);
        }

        public bool Validate(string origin, string encrypted)
        {
            if (origin == null && encrypted == null) return true;

            if (origin == null || encrypted == null) return false;

            return encrypted.Equals(_encryptService.Encrypt(origin));
        }
    }
}
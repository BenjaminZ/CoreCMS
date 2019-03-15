using System.Linq;

namespace CoreCMS.Persistence.Encryption
{
    public class DefaultEncryptService : IEncryptService
    {
        public string Encrypt(string origin)
        {
            return string.IsNullOrEmpty(origin) ? origin : string.Join("", origin.Reverse());
        }
    }
}
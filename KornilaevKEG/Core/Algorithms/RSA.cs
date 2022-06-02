using System.Security.Cryptography;
using System.Text;

namespace KornilaevKEG.Core.Algorithms
{
    class RSA : IAsymmetricAlgorithm
    {
        public RSA()
        {
            int g;
            ///RSAProvider.ImportRSAPublicKey(RSAProvider.FromXmlString("MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCbeppZ4rljjH7fKm5zPkgWAgTxK0eWTgUeKg/wAt8qTedp3bhoQj7D2s3tKBdwKJ9HesnKPpal/f1Xf7GcSla4v3JgCLNyEpYpoIKekeW4FNsZxrakCOhg5XSysca/tylOnNvvP5kgROJ04iiJukklV+AaY4PU1LvDApFIqrmeOwIDAQAB"), out g);
        }
        public string Name => "RSA";

        private static RSACryptoServiceProvider RSAProvider = new RSACryptoServiceProvider();

        public byte[] Decrypt(byte[] message, byte[] key) => RSAProvider.Decrypt(message, false);

        public byte[] Encrypt(byte[] message, byte[] key) => RSAProvider.Encrypt(message, false);
    }
}

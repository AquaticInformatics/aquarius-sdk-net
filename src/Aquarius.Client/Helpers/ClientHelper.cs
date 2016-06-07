using System;
using System.Security.Cryptography;
using System.Text;
using Aquarius.Client.ServiceModels.Publish;
using ServiceStack;
using GetPublicKey = Aquarius.Client.ServiceModels.Publish.GetPublicKey;

namespace Aquarius.Client.Helpers
{
    public class ClientHelper
    {
        public static void SetAuthenticationToken(ServiceClientBase client, string authenticationToken)
        {
            client.Headers.Remove(AuthenticationHeaders.AuthenticationHeaderNameKey);
            client.Headers.Add(AuthenticationHeaders.AuthenticationHeaderNameKey, authenticationToken);
        }

        public static string Login(ServiceClientBase client, string username, string password)
        {
            var publicKey = client.Get(new GetPublicKey());
            var encryptedPassword = EncryptPassword(publicKey.Xml, password);
            return client.Post(new PostSession {EncryptedPassword = encryptedPassword, Username = username});
        }

        public static void Logout(ServiceClientBase client)
        {
            client.Delete(new DeleteSession());
        }

        private static string EncryptPassword(string publicKeyXml, string plaintextPassword)
        {
            using (var rsaCrypto = new RSACryptoServiceProvider())
            {
                rsaCrypto.FromXmlString(publicKeyXml);

                var plaintextBytes = Encoding.UTF8.GetBytes(plaintextPassword);
                var encryptedBytes = rsaCrypto.Encrypt(plaintextBytes, true);
                var encryptedBase64 = Convert.ToBase64String(encryptedBytes);

                return encryptedBase64;
            }
        }
    }
}

using NiaBukkit.API;
using NiaBukkit.API.Cryptography;

namespace NiaBukkit.Network
{
    public class CryptoNetworkBuf : NetworkBuf
    {
        private AesCipher _cipher;

        public CryptoNetworkBuf(AesCipher cipher)
        {
            _cipher = cipher;
        }
        
        public override void Read(byte[] input, int size)
        {
            input = _cipher.DecryptBlock(input, 0, size);
            base.Read(input, size);
        }
    }
}
namespace KornilaevKEG.Core.Algorithms
{
    class Visener : ISymmetricAlgorithm
    {
        public string Name => "Шифр Винджера";

        public byte[] Decrypt(byte[] message, byte[] key)
        {
            byte[] res = new byte[message.Length];
            int i = 0;
            foreach (var ch in message)
            {
                res[i] = (byte)(char)(ch + key[i % key.Length]);
                i++;
            }
            return res;
        }

        public byte[] Encrypt(byte[] message, byte[] key)
        {
            byte[] res = new byte[message.Length];
            int i = 0;
            foreach (var ch in message)
            {
                res[i] = (byte)(char)(ch - key[i % key.Length]);
                i++;
            }
            return res;
        }
    }
}

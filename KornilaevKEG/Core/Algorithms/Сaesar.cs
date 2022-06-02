namespace KornilaevKEG.Core.Algorithms
{
    class Сaesar : ISymmetricAlgorithm
    {
        public string Name => "Шифр Цезаря";

        public byte[] Decrypt(byte[] message, byte[] key)
        {
            byte[] res = new byte[message.Length];
            int i = 0;
            foreach (var ch in message)
            {
                res[i] = (byte)(char)(ch + key[0]);
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
                res[i] = (byte)(char)(ch - key[0]);
                i++;
            }
            return res;
        }
    }
}

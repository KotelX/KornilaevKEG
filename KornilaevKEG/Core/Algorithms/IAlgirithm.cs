namespace KornilaevKEG.Core.Algorithms
{
    interface IAlgirithm
    {
        string Name { get; }
        byte[] Encrypt(byte[] message, byte[] key);
        byte[] Decrypt(byte[] message, byte[] key);
    }
}



namespace CF9Project.Security
{
    public interface IEncryptionUtil
    {
        string Encrypt(string plainText);
        bool IsValidPassword(string plainText, string cipherText);
    }
}

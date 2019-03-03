namespace OnlyOtp
{
    internal interface IRandomProvider
    {
        string GetRandom(int length, char[] charset);
    }
}
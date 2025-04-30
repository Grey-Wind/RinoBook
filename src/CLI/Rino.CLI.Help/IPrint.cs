namespace Rino.CLI.Help
{
    internal interface IPrint
    {
        static abstract void WriteLine(string text);
        static abstract void Write(string text);
    }
}

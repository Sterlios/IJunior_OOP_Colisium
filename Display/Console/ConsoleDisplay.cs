namespace Colisium.Display.Console
{
    class ConsoleDisplay : IDisplay
    {
        public void Display(IString String)
        {
            System.Console.WriteLine(String);
        }
    }
}

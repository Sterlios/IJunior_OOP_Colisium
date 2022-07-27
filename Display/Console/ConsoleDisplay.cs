namespace Colisium.Display.Console
{
    class ConsoleDisplay : IDisplay
    {
        public void Display(IString objectForString)
        {
            System.Console.WriteLine(objectForString);
        }
    }
}

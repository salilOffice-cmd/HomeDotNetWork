namespace WebEFAPI_2.MyLogging
{
    public class LogToFile : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Logs stored in a file");
        }
    }
}

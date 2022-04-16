namespace WpfMultithreadingPractice.P074Semaphore
{
    using System.Diagnostics;
    using System.Threading;

    public static class LogV074
    {
        public static void PrintLine(string s)
        {
            Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {s}");
        }
    }
}

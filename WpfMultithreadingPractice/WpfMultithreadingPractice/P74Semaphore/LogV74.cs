namespace WpfMultithreadingPractice.P74Semaphore
{
    using System.Diagnostics;
    using System.Threading;

    public static class LogV74
    {
        public static void PrintLine(string s)
        {
            Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {s}");
        }
    }
}

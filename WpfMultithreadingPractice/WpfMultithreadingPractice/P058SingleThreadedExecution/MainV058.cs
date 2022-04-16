namespace WpfMultithreadingPractice.P058SingleThreadedExecution
{
    using System.Diagnostics;
    using WpfMultithreadingPractice.P050SingleThreadedExecution;

    public static class MainV058
    {
        public static void Enter()
        {
            Trace.WriteLine($"Testing Gate, hit CTRL+C to exit.");
            GateV058 gate = new GateV058();
            new UserThreadV050(gate, "Alice", "Alaska").Start();
            new UserThreadV050(gate, "Bobby", "Brazil").Start();
            new UserThreadV050(gate, "Chris", "Canada").Start();
        }
    }
}

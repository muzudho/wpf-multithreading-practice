namespace WpfMultithreadingPractice.P050SingleThreadedExecution
{
    using System.Diagnostics;

    public static class MainV050
    {
        public static void Enter()
        {
            Trace.WriteLine($"Testing Gate, hit CTRL+C to exit.");
            GateV050 gate = new GateV050();
            new UserThreadV050(gate, "Alice", "Alaska").Start();
            new UserThreadV050(gate, "Bobby", "Brazil").Start();
            new UserThreadV050(gate, "Chris", "Canada").Start();
        }
    }
}

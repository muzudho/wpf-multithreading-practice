namespace WpfMultithreadingPractice.P50SingleThreadedExecution
{
    using System.Diagnostics;

    public static class MainV50
    {
        public static void Enter()
        {
            Trace.WriteLine($"Testing Gate, hit CTRL+C to exit.");
            GateV50 gate = new GateV50();
            new UserThreadV50(gate, "Alice", "Alaska").Start();
            new UserThreadV50(gate, "Bobby", "Brazil").Start();
            new UserThreadV50(gate, "Chris", "Canada").Start();
        }
    }
}

namespace WpfMultithreadingPractice.P58SingleThreadedExecution
{
    using System.Diagnostics;
    using WpfMultithreadingPractice.P50SingleThreadedExecution;

    public static class MainV58
    {
        public static void Enter()
        {
            Trace.WriteLine($"Testing Gate, hit CTRL+C to exit.");
            GateV58 gate = new GateV58();
            new UserThreadV50(gate, "Alice", "Alaska").Start();
            new UserThreadV50(gate, "Bobby", "Brazil").Start();
            new UserThreadV50(gate, "Chris", "Canada").Start();
        }
    }
}

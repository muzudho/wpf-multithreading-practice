namespace WpfMultithreadingPractice.P078Practice
{
    using System.Diagnostics;

    public static class MainV078
    {
        public static void Enter()
        {
            Trace.WriteLine($"Testing Gate, hit CTRL+C to exit.");
            GateV078 gate = new GateV078();
            new UserThreadV078(gate, "Alice", "Alaska").Start();
            new UserThreadV078(gate, "Bobby", "Brazil").Start();
            new UserThreadV078(gate, "Chris", "Canada").Start();
        }
    }
}

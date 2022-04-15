namespace WpfMultithreadingPractice.P78Practice
{
    using System.Diagnostics;

    public static class MainV78
    {
        public static void Enter()
        {
            Trace.WriteLine($"Testing Gate, hit CTRL+C to exit.");
            GateV78 gate = new GateV78();
            new UserThreadV78(gate, "Alice", "Alaska").Start();
            new UserThreadV78(gate, "Bobby", "Brazil").Start();
            new UserThreadV78(gate, "Chris", "Canada").Start();
        }
    }
}

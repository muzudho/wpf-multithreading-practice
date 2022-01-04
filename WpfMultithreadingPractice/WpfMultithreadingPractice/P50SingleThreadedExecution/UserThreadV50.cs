namespace WpfMultithreadingPractice.P50SingleThreadedExecution
{
    using System.Diagnostics;
    using System.Threading;

    public class UserThreadV50
    {
        private readonly GateV50 gate;
        private readonly string myName;
        private readonly string myAddress;

        public UserThreadV50(GateV50 gate, string myName, string myAddress)
        {
            this.gate = gate;
            this.myName = myName;
            this.myAddress = myAddress;
        }

        public void Run()
        {
            Trace.WriteLine($"{myName} Begin");
            while (true)
            {
                gate.Pass(myName, myAddress);
            }
        }

        public void Start()
        {
            // 別のスレッドにやらせる仕事
            Thread backgroundThread = new Thread(new ThreadStart(this.Run));
            backgroundThread.Start();
            // ここは通り抜けます
        }
    }
}

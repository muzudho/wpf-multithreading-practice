namespace WpfMultithreadingPractice.P78Practice
{
    using System.Diagnostics;
    using System.Threading;

    public class UserThreadV78
    {
        private readonly GateV78 gate;
        private readonly string myName;
        private readonly string myAddress;

        public UserThreadV78(GateV78 gate, string myName, string myAddress)
        {
            this.gate = gate;
            this.myName = myName;
            this.myAddress = myAddress;
        }

        private void Run()
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

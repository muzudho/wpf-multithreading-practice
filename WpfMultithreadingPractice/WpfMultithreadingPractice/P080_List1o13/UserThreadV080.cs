namespace WpfMultithreadingPractice.P080_List1o13
{
    using System.Threading;

    public class UserThreadV080
    {
        private readonly PoorSecurityGateV080 gate;

        public Thread? BackgroundThread { get; private set; } = null;

        public UserThreadV080(PoorSecurityGateV080 gate)
        {
            this.gate = gate;
        }

        private void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                this.gate.Enter();
                this.gate.Exit();
            }
        }

        public void Start()
        {
            // 別のスレッドにやらせる仕事
            BackgroundThread = new Thread(new ThreadStart(this.Run));
            BackgroundThread.Start();
            // ここは通り抜けます
        }

        public void Join()
        {
            BackgroundThread?.Join();
        }
    }
}

namespace WpfMultithreadingPractice.P74Semaphore
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    public class UserThreadV74
    {
        private readonly static Random random = new Random(26535);
        private readonly BoundedResourceV74 resource;

        public UserThreadV74(BoundedResourceV74 resource)
        {
            this.resource = resource;
        }

        private void Run()
        {
            try
            {
                while (true)
                {
                    this.resource.Use();
                    Thread.Sleep(random.Next(3000));
                }
            }
            catch(Exception e)
            {
                Trace.WriteLine($"Exception {e}");
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

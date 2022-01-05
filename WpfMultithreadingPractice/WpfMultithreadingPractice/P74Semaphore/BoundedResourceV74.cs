namespace WpfMultithreadingPractice.P74Semaphore
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    public class BoundedResourceV74
    {
        private readonly SemaphoreSlim semaphore;
        private readonly int permits;
        private readonly static Random random = new Random(314159);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="permits">リソースの個数</param>
        public BoundedResourceV74(int permits)
        {
            this.semaphore = new SemaphoreSlim(0, permits);
            this.permits = permits;
        }

        /// <summary>
        /// リソースを使用します
        /// </summary>
        public void Use()
        {
            this.semaphore.WaitAsync();

            try
            {
                DoUse();
            }
            finally
            {
                this.semaphore.Release();
            }
        }

        /// <summary>
        /// リソースを実際に使用する（ここではスリープしてるだけ）
        /// </summary>
        private void DoUse()
        {
            LogV74.PrintLine($"BEGIN: used = {this.permits - this.semaphore.CurrentCount}");
            Thread.Sleep(random.Next(500)+500);
            LogV74.PrintLine($"END:   used = {this.permits - this.semaphore.CurrentCount}");
        }
    }
}

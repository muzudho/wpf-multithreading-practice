namespace WpfMultithreadingPractice.P074Semaphore
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    public class BoundedResourceV074
    {
        private readonly SemaphoreSlim semaphore;
        private readonly int permits;
        private readonly static Random random = new Random(314159);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="permits">リソースの個数</param>
        public BoundedResourceV074(int permits)
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
            LogV074.PrintLine($"BEGIN: used = {this.permits - this.semaphore.CurrentCount}");
            Thread.Sleep(random.Next(500)+500);
            LogV074.PrintLine($"END:   used = {this.permits - this.semaphore.CurrentCount}");
        }
    }
}

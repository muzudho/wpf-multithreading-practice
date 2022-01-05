namespace WpfMultithreadingPractice.P74Semaphore
{
    public static class MainV74
    {
        public static void Enter()
        {
            // 3個のリソースを用意します
            BoundedResourceV74 resource = new BoundedResourceV74(3);

            // 10個のスレッドが利用します
            for (int i=0; i<10; i++)
            {
                new UserThreadV74(resource).Start();
            }
        }
    }
}

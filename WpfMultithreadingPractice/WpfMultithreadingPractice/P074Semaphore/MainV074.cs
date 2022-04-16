namespace WpfMultithreadingPractice.P074Semaphore
{
    public static class MainV074
    {
        public static void Enter()
        {
            // 3個のリソースを用意します
            BoundedResourceV074 resource = new BoundedResourceV074(3);

            // 10個のスレッドが利用します
            for (int i=0; i<10; i++)
            {
                new UserThreadV074(resource).Start();
            }
        }
    }
}

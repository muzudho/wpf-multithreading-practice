namespace WpfMultithreadingPractice.P080_List1o13
{
    using System;
    using System.Diagnostics;

    public static class MainV080
    {
        public static void Enter()
        {
            Trace.WriteLine($"Testing PoorSecurityGate ...");

            for (int trial = 0; true; trial++)
            {
                PoorSecurityGateV080 gate = new PoorSecurityGateV080();
                UserThreadV080[] t = new UserThreadV080[5];

                // スレッド起動
                for (int i = 0; i < t.Length; i++)
                {
                    t[i] = new UserThreadV080(gate);
                    t[i].Start();
                }

                // スレッド終了待ち
                for (int i = 0; i < t.Length; i++)
                {
                    try
                    {
                        t[i].Join();
                    }
                    catch(Exception)
                    {

                    }
                }

                // 確認
                if (gate.GetCounter()==0)
                {
                    // 矛盾していない
                    Trace.WriteLine(".");
                }
                else
                {
                    // 矛盾を発見した
                    Trace.WriteLine("PoorSecurityGate is NOT safe!");
                    Trace.WriteLine($"GetCounter() == {gate.GetCounter()}");
                    Trace.WriteLine($"trial = {trial}");
                    break;
                }
            }

        }
    }
}

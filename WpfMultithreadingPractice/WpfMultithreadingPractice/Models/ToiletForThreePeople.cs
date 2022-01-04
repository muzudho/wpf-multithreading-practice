namespace WpfMultithreadingPractice.Models
{
    using System.Diagnostics;
    using System.Threading;

    /// <summary>
    /// P26 notify notifyAll wait
    /// =========================
    /// 
    /// 3人用のトイレ
    /// </summary>
    public class ToiletForThreePeople
    {
        /// <summary>
        /// 3つの個室
        /// falseなら空いています
        /// </summary>
        public bool[] Rooms { get; private set; } = new bool[] { false, false, false };

        /// <summary>
        /// 入ります
        /// </summary>
        /// <returns>
        /// 用が足せた部屋番号。用が足せてなければ -1
        /// </returns>
        public int Enter()
        {
            // 同期しているスコープに Monitor.Wait(this); を書いてください
            lock (this)
            {
                Trace.WriteLine($"Enter");

                for (var i = 0; i < Rooms.Length; i++)
                {
                    if (!Rooms[i])
                    {
                        // 使用中にします
                        Rooms[i] = true;

                        // 2秒待機
                        Thread.Sleep(2000);

                        // このメソッドから抜けます
                        return i;
                    }
                }

                // 全ての個室が埋まっていました
                // 誰かが通知してくれるまで待機します
                Monitor.Wait(this);

                Trace.WriteLine($"ここは通りません2");
            }
            return -1;
        }

        /// <summary>
        /// 手を洗って出ると考えてください
        /// </summary>
        /// <returns></returns>
        public void Exit(int roomNumber)
        {
            // 同期しているスコープに Monitor.Pulse(this); を書いてください
            lock (this)
            {
                Trace.WriteLine($"Exit");

                // 未使用にします
                Rooms[roomNumber] = false;

                // とりあえず誰か１人に通知
                Monitor.Pulse(this);
            }
        }
    }
}

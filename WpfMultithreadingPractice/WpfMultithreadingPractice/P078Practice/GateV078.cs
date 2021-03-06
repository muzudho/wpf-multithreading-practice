namespace WpfMultithreadingPractice.P078Practice
{
    using System.Diagnostics;
    using System.Threading;

    /// <summary>
    /// P53 スレッドセーフではないGateクラス
    /// </summary>
    public class GateV078
    {
        protected int Counter { get; set; } = 0;
        protected string Name { get; set; } = "Nobody";
        protected string Address { get; set; } = "Nowhere";

        public virtual void Pass(string name, string address)
        {
            this.Counter++;
            this.Name = name;

            // エラーを起こしやすくする練習
            try
            {
                Thread.Sleep(1000);
            }
            catch
            {

            }

            this.Address = address;
            Check();
        }

        public override string ToString()
        {
            return $"No.{Counter}: {Name}, {Address}";
        }

        protected void Check()
        {
            if (Name.ToCharArray()[0] != Address.ToCharArray()[0])
            {
                Trace.WriteLine("***** BROKEN ***** " + ToString());
            }
        }
    }
}

namespace WpfMultithreadingPractice.P50SingleThreadedExecution
{
    using System.Diagnostics;

    /// <summary>
    /// P53 スレッドセーフではないGateクラス
    /// </summary>
    public class GateV50
    {
        private int Counter { get; set; } = 0;
        private string Name { get; set; } = "Nobody";
        private string Address { get; set; } = "Nowhere";

        public void Pass(string name, string address)
        {
            this.Counter++;
            this.Name = name;
            this.Address = address;
            Check();
        }

        public override string ToString()
        {
            return $"No.{Counter}: {Name}, {Address}";
        }

        private void Check()
        {
            if (Name.ToCharArray()[0] != Address.ToCharArray()[0])
            {
                Trace.WriteLine("***** BROKEN ***** " + ToString());
            }
        }
    }
}

namespace WpfMultithreadingPractice.P58SingleThreadedExecution
{
    using WpfMultithreadingPractice.P50SingleThreadedExecution;

    /// <summary>
    /// P53 スレッドセーフなGateクラス
    /// 
    /// 📖 [lock statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/lock)
    /// </summary>
    public class GateV58 : GateV50
    {
        private readonly object lockObj = new object();

        public override void Pass(string name, string address)
        {
            lock (lockObj)
            {
                this.Counter++;
                this.Name = name;
                this.Address = address;
                Check();
            }
        }

        public override string ToString()
        {
            lock (lockObj)
            {
                return $"No.{Counter}: {Name}, {Address}";
            }
        }
    }
}

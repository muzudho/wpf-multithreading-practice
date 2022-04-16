namespace WpfMultithreadingPractice.P058SingleThreadedExecution
{
    using WpfMultithreadingPractice.P050SingleThreadedExecution;

    /// <summary>
    /// P53 スレッドセーフなGateクラス
    /// 
    /// 📖 [lock statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/lock)
    /// </summary>
    public class GateV058 : GateV050
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

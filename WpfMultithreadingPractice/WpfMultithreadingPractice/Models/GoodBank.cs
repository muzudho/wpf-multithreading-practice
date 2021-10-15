namespace WpfMultithreadingPractice.Models
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// List I1-10
    /// ==========
    /// 
    /// 良い銀行
    /// </summary>
    public class GoodBank
    {
        private int Money { get; set; }
        private string Name { get; set; }

        public GoodBank(string name, int money)
        {
            this.Name = name;
            this.Money = money;
        }

        /// <summary>
        /// 預金します
        /// </summary>
        /// <param name="m"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Deposit(int m)
        {
            Money += m;
        }

        /// <summary>
        /// 引き出します
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool Withdraw(int m)
        {
            // 引き出せた
            if (m <= Money)
            {
                Money -= m;
                return true;
            }
            // 残高不足
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 残高
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public int GetMoney()
        {
            return Money;
        }

        public string GetName()
        {
            return Name;
        }
    }
}

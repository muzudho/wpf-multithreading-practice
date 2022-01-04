namespace WpfMultithreadingPractice.Models
{
    using System.Diagnostics;

    public class FoodPrinter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="foodName">食べ物の名前</param>
        public FoodPrinter(string foodName)
        {
            this.FoodName = foodName;
        }

        /// <summary>
        /// 食べ物の名前
        /// </summary>
        public string FoodName { get; private set; }

        /// <summary>
        /// 食べ物の名前を Trace へ1万回出力します
        /// </summary>
        public void PrintName10000times()
        {
            // 重たい処理
            for (var i = 0; i < 10000; i++)
            {
                Trace.Write(this.FoodName);
            }
        }
    }
}

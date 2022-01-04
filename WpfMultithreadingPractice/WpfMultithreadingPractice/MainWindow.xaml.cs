namespace WpfMultithreadingPractice
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows;
    using WpfMultithreadingPractice.Models;
    using WpfMultithreadingPractice.P50SingleThreadedExecution;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// List I1-1
        /// =========
        /// 
        /// [P3 single threaded]ボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P3SingleThreadedButton_Click(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i < 10000; i++)
            {
                Trace.Write("Good!");
            }
        }

        /// <summary>
        /// List I1-3
        /// =========
        /// 
        /// [P6 my thread]ボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P6MyThreadButton_Click(object sender, RoutedEventArgs e)
        {
            // 別のスレッドにやらせる仕事
            Thread backgroundThread = new Thread(new ThreadStart(
                () =>
                {
                    // 重たい処理
                    for (var i = 0; i < 10000; i++)
                    {
                        Trace.Write("Nice!");
                    }
                }
            ));
            backgroundThread.Start();
            // ここは通り抜けます

            // このスレッドでやる仕事
            for (var i = 0; i < 10000; i++)
            {
                Trace.Write("Good!");
            }
        }

        /// <summary>
        /// [P13 two threads]ボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P13TwoThreadsButton_Click(object sender, RoutedEventArgs e)
        {
            // 別のスレッドにやらせる仕事 その1（ラムダ式を渡すなら）
            new Thread(new ThreadStart(
                () =>
                {
                    // 重たい処理
                    for (var i = 0; i < 10000; i++)
                    {
                        Trace.Write("Good!");
                    }
                }
            )).Start();
            // ここは通り抜けます

            // 別のスレッドにやらせる仕事 その2（メソッドを渡すなら）
            new Thread(new ThreadStart(DoNiceWork)).Start();
            // ここは通り抜けます

            // この UIスレッド は先に終わりますが、上の２つのスレッドは継続します
        }

        private void DoGoodWork()
        {
            // 重たい処理
            for (var i = 0; i < 10000; i++)
            {
                Trace.Write("Good!");
            }
        }

        private void DoNiceWork()
        {
            // 重たい処理
            for (var i = 0; i < 10000; i++)
            {
                Trace.Write("Nice!");
            }
        }

        /// <summary>
        /// List I1-7
        /// =========
        /// 
        /// [P15 runnable]ボタン押下時
        /// C# に Runnableインターフェースは無いので、ThreadStartの説明に変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P15RunnableButton_Click(object sender, RoutedEventArgs e)
        {
            var goodThreadStart = new ThreadStart(DoGoodWork);
            // 動的に生成したクラスのメソッドも渡すことができます
            var foodThreadStart = new ThreadStart(new FoodPrinter("Pineapple").PrintName10000times);

            new Thread(goodThreadStart).Start();
            new Thread(foodThreadStart).Start();
        }

        /// <summary>
        /// List I1-9
        /// =========
        /// 
        /// [P17 sleep]ボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P17SleepButton_Click(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i < 10; i++)
            {
                Trace.Write("Good!");
                try
                {
                    Thread.Sleep(1000);
                }
                catch (ThreadInterruptedException)
                {
                    // Ignored
                }
            }
        }

        /// <summary>
        /// List I1-10
        /// ==========
        /// 
        /// [P20 synchronized method]ボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P20SynchronizedMethodButton_Click(object sender, RoutedEventArgs e)
        {
            // 良い銀行
            var aBank = new GoodBank("AppleBank", 3000);
            var bBank = new GoodBank("BananaBank", 5000);
            var cBank = new GoodBank("CherryBank", 1000);

            // 悪い銀行
            var dBank = new BadBank("DangerBank", 3000);
            var eBank = new BadBank("EccentricBank", 5000);
            var fBank = new BadBank("FatalBank", 1000);

            // ロックを使う銀行
            var gBank = new LockBank("GrandBank", 3000);
            var hBank = new LockBank("HollyBank", 5000);
            var iBank = new LockBank("IceBank", 1000);

            // Alice さん
            new Thread(new ThreadStart(
                () =>
                {
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();

                    // 重たい処理
                    for (var i = 0; i < 100000; i++)
                    {
                        // a --> b --> c --> a と 1000 円を移動
                        aBank.Withdraw(1000);
                        bBank.Deposit(1000);

                        bBank.Withdraw(1000);
                        cBank.Deposit(1000);

                        cBank.Withdraw(1000);
                        aBank.Deposit(1000);
                    }

                    stopwatch.Stop();
                    // 各銀行の残高を調べます
                    Trace.WriteLine($"Alice [{stopwatch.Elapsed}] {aBank.GetName()}={aBank.GetMoney(),6} {bBank.GetName()}={bBank.GetMoney(),6} {cBank.GetName()}={cBank.GetMoney(),6}");

                    stopwatch.Restart();

                    for (var i = 0; i < 100000; i++)
                    {
                        // d --> e --> f --> d と 1000 円を移動
                        dBank.Withdraw(1000);
                        eBank.Deposit(1000);

                        eBank.Withdraw(1000);
                        fBank.Deposit(1000);

                        fBank.Withdraw(1000);
                        dBank.Deposit(1000);
                    }

                    stopwatch.Stop();
                    // 各銀行の残高を調べます
                    Trace.WriteLine($"Alice [{stopwatch.Elapsed}] {dBank.GetName()}={dBank.GetMoney(),6} {eBank.GetName()}={eBank.GetMoney(),6} {fBank.GetName()}={fBank.GetMoney(),6}");

                    stopwatch.Restart();

                    for (var i = 0; i < 100000; i++)
                    {
                        // g --> h --> i --> g と 1000 円を移動
                        gBank.Withdraw(1000);
                        hBank.Deposit(1000);

                        hBank.Withdraw(1000);
                        iBank.Deposit(1000);

                        iBank.Withdraw(1000);
                        gBank.Deposit(1000);
                    }

                    stopwatch.Stop();
                    // 各銀行の残高を調べます
                    Trace.WriteLine($"Alice [{stopwatch.Elapsed}] {gBank.GetName()}={gBank.GetMoney(),6} {hBank.GetName()}={hBank.GetMoney(),6} {iBank.GetName()}={iBank.GetMoney(),6}");
                }
            )).Start();

            // Bob さん
            new Thread(new ThreadStart(
                () =>
                {
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();

                    // 重たい処理
                    for (var i = 0; i < 100000; i++)
                    {
                        // a --> c --> b --> a と 1000 円を移動
                        aBank.Withdraw(1000);
                        cBank.Deposit(1000);

                        cBank.Withdraw(1000);
                        bBank.Deposit(1000);

                        bBank.Withdraw(1000);
                        aBank.Deposit(1000);
                    }

                    stopwatch.Stop();
                    // 各銀行の残高を調べます
                    Trace.WriteLine($"Bob   [{stopwatch.Elapsed}] {aBank.GetName()}={aBank.GetMoney(),6} {bBank.GetName()}={bBank.GetMoney(),6} {cBank.GetName()}={cBank.GetMoney(),6}");

                    stopwatch.Restart();

                    for (var i = 0; i < 100000; i++)
                    {
                        // d --> f --> e --> d と 1000 円を移動
                        dBank.Withdraw(1000);
                        fBank.Deposit(1000);

                        fBank.Withdraw(1000);
                        eBank.Deposit(1000);

                        eBank.Withdraw(1000);
                        dBank.Deposit(1000);
                    }

                    stopwatch.Stop();
                    // 各銀行の残高を調べます
                    Trace.WriteLine($"Bob   [{stopwatch.Elapsed}] {dBank.GetName()}={dBank.GetMoney(),6} {eBank.GetName()}={eBank.GetMoney(),6} {fBank.GetName()}={fBank.GetMoney(),6}");

                    stopwatch.Restart();

                    for (var i = 0; i < 100000; i++)
                    {
                        // g --> h --> i --> g と 1000 円を移動
                        gBank.Withdraw(1000);
                        hBank.Deposit(1000);

                        hBank.Withdraw(1000);
                        iBank.Deposit(1000);

                        iBank.Withdraw(1000);
                        gBank.Deposit(1000);
                    }

                    stopwatch.Stop();
                    // 各銀行の残高を調べます
                    Trace.WriteLine($"Bob   [{stopwatch.Elapsed}] {gBank.GetName()}={gBank.GetMoney(),6} {hBank.GetName()}={hBank.GetMoney(),6} {iBank.GetName()}={iBank.GetMoney(),6}");
                }
            )).Start();
        }

        /// <summary>
        /// P26
        /// ===
        /// 
        /// [P26 notify notifyAll wait]ボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P26NotifyNotifyAllWaitButton_Click(object sender, RoutedEventArgs e)
        {
            // 3人用のトイレがあります
            var toiletFor3people = new ToiletForThreePeople();

            var completed = 0;

            // 40人が用を足そうとします
            var max = 40;
            for (var i = 0; i < max; i++)
            {
                new Thread(new ThreadStart(
                    // このコードブロックの中では、外側の i を取ると、飛び番になったり、抜け番になったりします
                    () =>
                    {
                        // 用が足せてない間 ブロックします
                        var roomNumber = toiletFor3people.Enter();

                        if (roomNumber == -1)
                        {
                            throw new InvalidOperationException("ここは通りません");
                        }

                        toiletFor3people.Exit(roomNumber);

                        Interlocked.Increment(ref completed);

                        Trace.WriteLine($"{completed} / {max} people ok");
                    }
                )).Start();
            }
        }

        /// <summary>
        /// P50
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P50SingleThreadedExecutionButton_Click(object sender, RoutedEventArgs e)
        {
            MainV50.Enter();
        }
    }
}

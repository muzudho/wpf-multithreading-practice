﻿namespace WpfMultithreadingPractice
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows;

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
            for(var i=0; i<10000; i++)
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
            // 別のスレッドにやらせる仕事 その1
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

            // 別のスレッドにやらせる仕事 その2
            new Thread(new ThreadStart(
                () =>
                {
                    // 重たい処理
                    for (var i = 0; i < 10000; i++)
                    {
                        Trace.Write("Nice!");
                    }
                }
            )).Start();
            // ここは通り抜けます

            // この UIスレッド は先に終わりますが、上の２つのスレッドは継続します
        }
    }
}

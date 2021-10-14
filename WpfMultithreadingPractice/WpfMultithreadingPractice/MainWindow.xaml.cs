namespace WpfMultithreadingPractice
{
    using System;
    using System.Diagnostics;
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
    }
}

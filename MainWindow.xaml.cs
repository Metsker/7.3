using System;
using System.Collections.Generic;
using System.Windows;

namespace _7._3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly List<Worker> workers = new List<Worker>();
        string gender = "";
        int oldmans;

        public MainWindow()
        {
            InitializeComponent();
        }

        public struct Worker
        {
            public string WorkerName { get; set; }
            public string WorkerSurname { get; set; }
            public string WorkerPosition { get; set; }
            public int WorkerAge { get; set; }
            public bool? WorkerGenderM { get; set; }
            public bool? WorkerGenderF { get; set; }
            public int IsOld(int oldmancount)
            {
                if (WorkerGenderM == true && WorkerAge >= 65)
                {
                    oldmancount++;
                }
                else if (WorkerGenderF == true && WorkerAge >= 60)
                {
                    oldmancount++;
                }
                return oldmancount;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            oldmans = 0;

            foreach (Worker olds in workers)
            {
                oldmans = olds.IsOld(oldmans);
            }
            result.Text = oldmans.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Male.IsChecked == true)
                {
                    gender = "М";
                }
                else if (Female.IsChecked == true)
                {
                    gender = "Ж";
                }
                else
                {
                    MessageBox.Show("Установите пол");
                }

                if (Male.IsChecked == true | Female.IsChecked == true)
                {
                    workers.Add(new Worker()
                    {
                        WorkerName = Name.Text,
                        WorkerSurname = Surname.Text,
                        WorkerPosition = Position.Text,
                        WorkerAge = int.Parse(Age.Text),
                        WorkerGenderM = Male.IsChecked,
                        WorkerGenderF = Female.IsChecked,
                    });

                    Workers.Text += Surname.Text + " " + Age.Text + "y " + gender + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }   
}
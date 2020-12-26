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

            int oldmancount;

            public int IsOld()
            {
                if (WorkerAge >= 65 && WorkerGenderM == true)
                {
                    oldmancount++;
                }

                else if (WorkerAge >= 60 && WorkerGenderF == true)
                {
                    oldmancount++;
                }
                return oldmancount;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int oldmans = 0;

            foreach (Worker olds in workers)
            {
                oldmans += olds.IsOld();
            }
            result.Text = oldmans.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
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
                string gender = "";
                if (Male.IsChecked == true)
                {
                    gender = "М";
                }
                else if (Female.IsChecked == true)
                {
                    gender = "Ж";
                }
                if (Male.IsChecked == false && Female.IsChecked == false)
                {
                    MessageBox.Show("Установите пол");
                }
                else
                {
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
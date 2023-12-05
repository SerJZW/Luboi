using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VocabVibe.View
{
    /// <summary>
    /// Логика взаимодействия для Progress.xaml
    /// </summary>
    public partial class Progress : Page
    {
        public Progress()
        {
            InitializeComponent();
            var WordsArray = File.ReadAllLines("Vocab.txt");
            Count.Text = WordsArray.Length.ToString();
        }

        private void ProgressButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LearnWindow());
        }
    }
}

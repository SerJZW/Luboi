using System;
using System.Collections.Generic;
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
using VocabVibe.Model;

namespace VocabVibe.View
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public static Difficults.DifficultFlag Flag;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void EasyButton_Click(object sender, RoutedEventArgs e)
        {
            Flag = Difficults.DifficultFlag.Easy;
            NavigationService.Navigate(new LearnWindow());
        }

        private void MediumButton_Click(object sender, RoutedEventArgs e)
        {
            Flag = Difficults.DifficultFlag.Medium;
            NavigationService.Navigate(new LearnWindow());
        }

        private void HardButton_Click(object sender, RoutedEventArgs e)
        {
            Flag = Difficults.DifficultFlag.Hard;
            NavigationService.Navigate(new LearnWindow());
        }
    }
}

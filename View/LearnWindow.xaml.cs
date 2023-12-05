using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VocabVibe.Model;
using VocabVibe.View;

namespace VocabVibe.View
{
    /// <summary>
    /// Логика взаимодействия для LearnWindow.xaml
    /// </summary>
    public partial class LearnWindow : Page
    {
        public static string ThemeFlag;
        public LearnWindow()
        {
            InitializeComponent();
            if (MainMenu.Flag == Difficults.DifficultFlag.Easy)
            {
                CharacterBut.Visibility = Visibility.Collapsed;
                MoodBut.Visibility = Visibility.Collapsed;
                SchoolBut.Visibility = Visibility.Collapsed;
                SportBut.Visibility = Visibility.Collapsed;
                CityBut.Visibility = Visibility.Collapsed;
                ProfBut.Visibility = Visibility.Collapsed;
            }
            else if (MainMenu.Flag == Difficults.DifficultFlag.Medium)
            {
                WeatherBut.Visibility = Visibility.Collapsed;
                FamilyBut.Visibility = Visibility.Collapsed;
                LookBut.Visibility = Visibility.Collapsed;
                SportBut.Visibility = Visibility.Collapsed;
                CityBut.Visibility = Visibility.Collapsed;
                ProfBut.Visibility = Visibility.Collapsed;
            }
            else if (MainMenu.Flag == Difficults.DifficultFlag.Hard)
            {
                WeatherBut.Visibility = Visibility.Collapsed;
                FamilyBut.Visibility = Visibility.Collapsed;
                LookBut.Visibility = Visibility.Collapsed;
                CharacterBut.Visibility = Visibility.Collapsed;
                MoodBut.Visibility = Visibility.Collapsed;
                SchoolBut.Visibility = Visibility.Collapsed;
            }
        }
        private void SchoolBut_Click(object sender, RoutedEventArgs e)
        {
            ThemeFlag = "School";
            NavigationService.Navigate(new WordLearn());
        }

        private void WeatherBut_Click(object sender, RoutedEventArgs e)
        {
            ThemeFlag = "Weather";
            NavigationService.Navigate(new WordLearn());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        private void LookBut_Click(object sender, RoutedEventArgs e)
        {
            ThemeFlag = "Appeariance";
            NavigationService.Navigate(new WordLearn());
        }

        private void FamilyBut_Click(object sender, RoutedEventArgs e)
        {
            ThemeFlag = "FamilyCard";
            NavigationService.Navigate(new WordLearn());
        }

        private void CharacterBut_Click(object sender, RoutedEventArgs e)
        {
            ThemeFlag = "Character";
            NavigationService.Navigate(new WordLearn());
        }

        private void MoodBut_Click(object sender, RoutedEventArgs e)
        {
            ThemeFlag = "Mood";
            NavigationService.Navigate(new WordLearn());
        }

        private void SportBut_Click(object sender, RoutedEventArgs e)
        {
            ThemeFlag = "Sport";
            NavigationService.Navigate(new WordLearn());
        }

        private void CityBut_Click(object sender, RoutedEventArgs e)
        {
            ThemeFlag = "City";
            NavigationService.Navigate(new WordLearn());
        }

        private void ProfBut_Click(object sender, RoutedEventArgs e)
        {
            ThemeFlag = "Jobs";
            NavigationService.Navigate(new WordLearn());
        }

        private void VocabButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Vocabulary());
        }

        private void ProgressButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Progress());
        }
    }
}



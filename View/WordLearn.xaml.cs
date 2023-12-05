using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using VocabVibe.Event;
using VocabVibe.Model;

namespace VocabVibe.View
{
    /// <summary>
    /// Логика взаимодействия для WordLearn.xaml
    /// </summary>
    public partial class WordLearn : Page
    {
        private int ClickedTimes = 0;
        private string FileName;
        private string[] WordsArray = new string[8];
        private string[] TempArr;
        private string[] NewWordsList = new string[7];
        public WordLearn()
        {
            InitializeComponent();
            if (LearnWindow.ThemeFlag == "Appeariance")
            {
                FileName = "Appeariance.txt";
                ThemeName.Text = "Внешность";
            }
            else if (LearnWindow.ThemeFlag == "FamilyCard")
            {
                FileName = "FamilyCard.txt";
                ThemeName.Text = "Семья и друзья";
            }
            else if (LearnWindow.ThemeFlag == "Weather")
            {
                FileName = "WeatherCard.txt";
                ThemeName.Text = "Погода";
            }
            else if (LearnWindow.ThemeFlag == "Character")
            {
                FileName = "Character.txt";
                ThemeName.Text = "Характер";
            }
            else if (LearnWindow.ThemeFlag == "Mood")
            {
                FileName = "Mood.txt";
                ThemeName.Text = "Настроение";
            }
            else if (LearnWindow.ThemeFlag == "School")
            {
                FileName = "School.txt";
                ThemeName.Text = "Школа";
            }
            else if (LearnWindow.ThemeFlag == "Sport")
            {
                FileName = "Sport.txt";
                ThemeName.Text = "Спорт";
            }
            else if (LearnWindow.ThemeFlag == "City")
            {
                FileName = "City.txt";
                ThemeName.Text = "Город";
            }
            else if (LearnWindow.ThemeFlag == "Jobs")
            {
                FileName = "Jobs.txt";
                ThemeName.Text = "Профессия";
            }
            WordsArray = File.ReadAllLines(FileName);
            TempArr = WordsArray[0].Split(':');
            EnglishWord.Text = TempArr[0];
        }
        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClickedTimes < 6)
            {
                ClickedTimes++;
                TempArr = WordsArray[ClickedTimes].Split(':');
                EnglishWord.Text = TempArr[0];
                ProgressCount.Text = (ClickedTimes + 1).ToString();
                using (StreamWriter sw = File.AppendText("Vocab.txt"))
                {
                    sw.WriteLine(WordsArray[ClickedTimes]);
                }
            }
            if (ClickedTimes == 6)
            {
                MessageBox.Show("Урок пройден.", "Результат", MessageBoxButton.OK);
                NavigationService.Navigate(new LearnWindow());
            }
            TranslatedWord.Text = "🤔";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TranslatedWord.Text = TempArr[1];
        }

        private void myButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (ClickedTimes < 6)
            {
                ClickedTimes++;
                TempArr = WordsArray[ClickedTimes].Split(':');
                EnglishWord.Text = TempArr[0];
                ProgressCount.Text = (ClickedTimes + 1).ToString();
            }
            if (ClickedTimes == 6)
            {
                MessageBox.Show("Урок пройден.", "Результат", MessageBoxButton.OK);
                NavigationService.Navigate(new LearnWindow());
            }
            TranslatedWord.Text = "🤔";
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



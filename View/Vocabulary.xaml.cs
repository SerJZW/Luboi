using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для Vocabulary.xaml
    /// </summary>
    public partial class Vocabulary : Page
    {
        public Vocabulary()
        {
            InitializeComponent();
            double x = 20;
            double y = 10;
            var WordsArray = File.ReadAllLines("Vocab.txt");
            if (WordsArray.Length >= 2)
            {
                for (int i = 0; i < WordsArray.Length; i++)
                {
                    Grid grid = new Grid();
                    grid.Width = 990;
                    grid.Height = 50;
                    grid.Background = Brushes.Transparent;

                    Border border = new Border();
                    border.Background = Brushes.Transparent;
                    border.CornerRadius = new CornerRadius(20);
                    border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8150C6"));
                    border.BorderThickness = new Thickness(5);

                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Orientation = Orientation.Horizontal;

                    Canvas.SetLeft(grid, x);
                    Canvas.SetTop(grid, y);

                    var tempArr = WordsArray[i].Split(':');

                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = $"{tempArr[0]}";
                    textBlock.Foreground = Brushes.White;
                    textBlock.FontSize = 30;
                    textBlock.Margin = new Thickness(50, 0, 0, 0);
                    textBlock.VerticalAlignment = VerticalAlignment.Center;
                    textBlock.HorizontalAlignment = HorizontalAlignment.Left;

                    TextBlock textBlock1 = new TextBlock();
                    textBlock1.Text = $"{tempArr[1]}";
                    textBlock1.Foreground = Brushes.White;
                    textBlock1.FontSize = 30;
                    textBlock1.Margin = new Thickness(500, 0, 50, 0);
                    textBlock1.VerticalAlignment = VerticalAlignment.Center;
                    textBlock.HorizontalAlignment = HorizontalAlignment.Left;

                    stackPanel.Children.Add(textBlock);
                    stackPanel.Children.Add(textBlock1);

                    border.Child = stackPanel;
                    grid.Children.Add(border);

                    canvas.Children.Add(grid);

                    x = 20;
                    y += 80;
                    canvas.Height += 51;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        private void ProgressButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Progress());
        }

        private void LearnButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LearnWindow());
        }
    }
}


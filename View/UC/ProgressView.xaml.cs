using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace VocabVibe.View
{
    public partial class ProgressView : UserControl
    {
        public ProgressView()
        {
            InitializeComponent();
            var WordsArray = File.ReadAllLines("C:\\Users\\zemzh\\source\\repos\\VocabVibe\\Files\\Vocab.txt");
            Count.Text = WordsArray.Length.ToString();
        }
    }
}

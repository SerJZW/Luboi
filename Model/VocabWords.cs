using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabVibe.Model
{
    public class VocabWords : Notify
    {
        private string? word;
        public string? Word
        {
            get { return word; }
            set { word = value; OnPropertyChanged("Word"); }
        }
        private string? definition;
        public string? Definition
        {
            get { return definition; }
            set { definition = value; OnPropertyChanged("Definition"); }
        }
    }
}

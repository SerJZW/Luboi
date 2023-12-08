using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabVibe.Model;

namespace VocabVibe.ViewModel
{
    public class ApplicationViewModel : Notify
    {
        public ContentSwitch ContentSwitch { get; set; }
        public SomethingViewModel SomethingViewModel { get; set; }
        public VocabularyViewModel VocabularyViewModel { get; set; }
        public WordLearnViewModel WordLearnViewModel { get; set; }

        public ApplicationViewModel() 
        {
            WordLearnViewModel = new WordLearnViewModel();
            ContentSwitch = new ContentSwitch();
            SomethingViewModel = new SomethingViewModel();
            VocabularyViewModel = new VocabularyViewModel();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabVibe.Model;
using VocabVibe.Model.Event;

namespace VocabVibe
{
    public class SomethingViewModel
    {
        public RelayCommand ExitCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    System.Windows.Application.Current.Shutdown();
                });
            }
        }
    }   
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VocabVibe.Model;
using VocabVibe.Model.Event;
using VocabVibe.View;
using VocabVibe.View.UC;
using static VocabVibe.Model.Difficults;

namespace VocabVibe.ViewModel
{
    public class ContentSwitch : Notify
    {
        private int ClickedTimes = 0;
        private string? FileName;
        private string[]? WordsArray;
        private string[]? TempArr;
        private string[]? NewWordsList = new string[8];

        private DifficultFlag _selectedDifficult;

        public DifficultFlag SelectedDifficult
        {
            get { return _selectedDifficult; }
            set
            {
                if (_selectedDifficult != value)
                {
                    _selectedDifficult = value;
                    OnPropertyChanged(nameof(SelectedDifficult));
                }
            }
        }
        public RelayCommand SelectDifficultCommand
        {
            get
            {
                return new RelayCommand(param =>
                {
                    DifficultFlag selectedDifficulty = (DifficultFlag)Enum.Parse(typeof(DifficultFlag), param.ToString()!);
                    SelectedDifficult = selectedDifficulty;
                    UserControl viewToShow = null!;

                    switch (selectedDifficulty)
                    {
                        case DifficultFlag.Easy:
                            viewToShow = new EasyView();
                            break;

                        case DifficultFlag.Medium:
                            viewToShow = new MediumView();
                            break;

                        case DifficultFlag.Hard:
                            viewToShow = new HardView();
                            break;
                    }
                    MyContentControl.Content = viewToShow;
                });
            }
        }

        private ContentControl? myContentControl;
        public ContentControl MyContentControl
        {
            get
            {
                if (myContentControl == null) { myContentControl = new MainMenuView(); }
                return myContentControl;
            }
            set
            {
                myContentControl = value;
                OnPropertyChanged("MyContentControl");
            }
        }
        public RelayCommand? setObject;

        public RelayCommand SetObject
        {
            get
            {
                return setObject ?? (setObject = new RelayCommand(obj =>
                {
                    if ((obj as string) == "ProgressView") MyContentControl = new ProgressView();
                    if ((obj as string) == "VocabularyView") MyContentControl = new VocabularyView();
                    if ((obj as string) == "WordLernView") MyContentControl = new WordLearnView();
                    if (SelectedDifficult == DifficultFlag.Easy)
                    {
                        if ((obj as string) == "LearnView") MyContentControl = new EasyView();
                    }
                    else if (SelectedDifficult == DifficultFlag.Medium)
                    {
                        if ((obj as string) == "LearnView") MyContentControl = new MediumView();
                    }
                    else
                    {
                        if ((obj as string) == "LearnView") MyContentControl = new HardView();
                    }
                }));
            }
        }
        private RelayCommand? selectedCategory;
        public RelayCommand SelectedCategory
        {
            get
            {
                return selectedCategory ?? (selectedCategory = new RelayCommand(async obj =>
                {
                    try
                    {
                        if (obj is string category)
                        {
                            MyContentControl = new WordLearnView();

                            string filePath = string.Empty;
                            switch (category)
                            {
                                case "Sport":
                                    filePath = "C:\\Users\\zemzh\\source\\repos\\VocabVibe\\Files\\Sport.txt";
                                    break;
                                case "City":
                                    filePath = "C:\\Users\\zemzh\\source\\repos\\VocabVibe\\Files\\City.txt";
                                    break;
                                case "Jobs":
                                    filePath = "C:\\Users\\zemzh\\source\\repos\\VocabVibe\\Files\\Jobs.txt";
                                    break;
                                case "Weather":
                                    filePath = "C:\\Users\\zemzh\\source\\repos\\VocabVibe\\Files\\WeatherCard.txt";
                                    break;
                                case "Character":
                                    filePath = "C:\\Users\\zemzh\\source\\repos\\VocabVibe\\Files\\Character.txt";
                                    break;
                                case "Apperiance":
                                    filePath = "C:\\Users\\zemzh\\source\\repos\\VocabVibe\\Files\\Appeariance.txt";
                                    break;
                                case "Family":
                                    filePath = "C:\\Users\\zemzh\\source\\repos\\VocabVibe\\Files\\FamilyCard.txt";
                                    break;
                                case "School":
                                    filePath = "C:\\Users\\zemzh\\source\\repos\\VocabVibe\\Files\\School.txt";
                                    break;
                                case "Mood":
                                    filePath = "C:\\Users\\zemzh\\source\\repos\\VocabVibe\\Files\\Mood.txt";
                                    break;
                            }
                            WordsArray = LoadWordsFromFile(filePath);
                            ClickedTimes = -1;
                            string fileName = Path.GetFileNameWithoutExtension(filePath);
                            string themeName = fileName;
                            string translatedword = TranslatedWord;
                            ThemeName = themeName;
                            if (!string.IsNullOrEmpty(filePath))
                            {
                                string fileContent = await Task.Run(() => File.ReadAllText(filePath));
                                string[] lines = fileContent.Split('\n');
                                if (lines.Length >= 1)
                                {
                                    string[] parts = lines[0].Split(':');

                                    if (parts.Length >= 2)
                                    {
                                        EnglishWord = parts[0].Trim();
                                        TranslatedWord = parts[1].Trim();
                                        SelectedTranslation = TranslatedWord;
                                        TranslatedWord = "🤔";

                                    }
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }));
            }
        }

        private string? _selectedTranslation;

        public string? SelectedTranslation
        {
            get { return _selectedTranslation; }
            set
            {
                if (_selectedTranslation != value)
                {
                    _selectedTranslation = value;
                    OnPropertyChanged(nameof(SelectedTranslation));
                }
            }
        }

        private string? _themeName;
        public string? ThemeName
        {
            get { return _themeName; }
            set
            {
                if (_themeName != value)
                {
                    _themeName = value;
                    OnPropertyChanged(nameof(ThemeName));
                }
            }
        }

        private string? _englishWord;
        public string? EnglishWord
        {
            get { return _englishWord; }
            set
            {
                if (_englishWord != value)
                {
                    _englishWord = value;
                    OnPropertyChanged(nameof(EnglishWord));
                }
            }
        }

        private string _translatedWord = "🤔";
        public string TranslatedWord
        {
            get { return _translatedWord; }
            set
            {
                if (_translatedWord != value)
                {
                    _translatedWord = value;
                    OnPropertyChanged(nameof(TranslatedWord));
                }
            }
        }

        private string? _progressCount;
        public string? ProgressCount
        {
            get { return _progressCount; }
            set
            {
                if (_progressCount != value)
                {
                    _progressCount = value;
                    OnPropertyChanged(nameof(ProgressCount));
                }
            }
        }



        public RelayCommand DontNowCommand
        {
            get
            {
                return new RelayCommand(param =>
                {
                    if (ClickedTimes < WordsArray.Length - 1)
                    {
                        ClickedTimes++;
                        TempArr = WordsArray[ClickedTimes].Split(':');
                        EnglishWord = TempArr[0];
                        TranslatedWord = TempArr[1];
                        ProgressCount = (ClickedTimes + 1).ToString();
                        WordsArray[ClickedTimes] = $"{EnglishWord}:{TranslatedWord}";
                        SelectedTranslation = TranslatedWord;
                    }

                    if (ClickedTimes == WordsArray.Length - 1)
                    {
                        MessageBox.Show("Урок пройден.", "Результат", MessageBoxButton.OK);
                        ClickedTimes = 0;
                    }
                    TranslatedWord = "🤔";
                });
            }
        }

        public RelayCommand IKnowCommand
        {
            get
            {
                return new RelayCommand(param =>
                {
                    if (ClickedTimes < WordsArray.Length - 1)
                    {
                        ClickedTimes++;
                        TempArr = WordsArray[ClickedTimes].Split(':');
                        EnglishWord = TempArr[0];
                        TranslatedWord = TempArr[1];
                        ProgressCount = (ClickedTimes + 1).ToString();
                        WordsArray[ClickedTimes] = $"{EnglishWord}:{TranslatedWord}";
                        SelectedTranslation = TranslatedWord;
                        var cleanedArray = WordsArray.Select(line => line.Trim());
                        using (StreamWriter sw = new StreamWriter("C:\\Users\\zemzh\\source\\repos\\VocabVibe\\Files\\Progress.txt", true))
                        {
                            sw.WriteLine(cleanedArray);
                        }
                    }

                    if (ClickedTimes == WordsArray.Length - 1)
                    {
                        MessageBox.Show("Урок пройден.", "Результат", MessageBoxButton.OK);
                        ClickedTimes = 0;
                    }
                    TranslatedWord = "🤔";
                });
            }
        }
        private string[] LoadWordsFromFile(string filePath)
        {
            try
            {
                string fileContent = File.ReadAllText(filePath);
                return fileContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading words from file: {ex.Message}");
                return Array.Empty<string>();
            }
        }
        public RelayCommand TranslateCommand
        {
            get
            {
                return new RelayCommand(param =>
                {
                    if (TranslatedWord == "🤔")
                    {
                        TranslatedWord = SelectedTranslation;
                    }
                    else
                    {
                        TranslatedWord = "🤔";
                    }
                });
            }
        }
    }
}






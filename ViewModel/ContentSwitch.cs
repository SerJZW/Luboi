using System;
using System.IO;
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

                            // Установка пути к файлу в зависимости от категории
                            switch (category)
                            {
                                case "Sport":
                                    filePath = "C:\\Users\\zemzh\\source\\repos\\VocabVibe\\Files\\Sport.txt";
                                    break;
                                case "City":
                                    filePath = "C:\\Users\\zemzh\\source\\repos\\VocabVibe\\Files\\City.txt";
                                    break;
                                    // Добавьте остальные категории
                            }

                            // Извлекаем название темы из названия файла
                            string fileName = Path.GetFileNameWithoutExtension(filePath);
                            string themeName = fileName;

                            // Устанавливаем название темы
                            ThemeName = themeName;

                            // Чтение файла и обработка данных
                            if (!string.IsNullOrEmpty(filePath))
                            {
                                string fileContent = await Task.Run(() => File.ReadAllText(filePath));

                                // Разбиваем строки файла
                                string[] lines = fileContent.Split('\n');

                                // Предположим, что первая строка - это английское слово, а вторая - перевод
                                if (lines.Length >= 2)
                                {
                                    EnglishWord = lines[0].Trim();
                                    TranslatedWord = lines[1].Trim();
                                }

                                // Обработка данных из файла
                                // ...

                                // Пример обновления свойств в вашем ViewModel
                                // ProgressCount = ...;
                                // MyContentControl = ...;
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

        private string _translatedWord;
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
        private int ClickedTimes = 0;
        private string? FileName;
        private string[]? WordsArray = new string[8];
        private string[]? TempArr;
        private string[]? NewWordsList = new string[7];

        public RelayCommand DontNowCommand
        {
            get
            {
                return new RelayCommand(param =>
                {
                    if (ClickedTimes < 6 && WordsArray != null && WordsArray.Length > ClickedTimes && WordsArray[ClickedTimes] != null)
                    {
                        ClickedTimes++;
                        TempArr = WordsArray[ClickedTimes].Split(':');
                        EnglishWord = TempArr[0];
                        ProgressCount = (ClickedTimes + 1).ToString();
                        using (StreamWriter sw = File.AppendText("Vocab.txt"))
                        {
                            sw.WriteLine(WordsArray[ClickedTimes]);
                        }
                    }

                    if (ClickedTimes == 6)
                    {
                        MessageBox.Show("Урок пройден.", "Результат", MessageBoxButton.OK);
                    }

                    TranslatedWord = "🤔";
                });
            }
        }

        public RelayCommand? IKnowCommand
        {
            get
            {
                return new RelayCommand(param =>
                {
                    if (ClickedTimes < 6)
                    {
                        ClickedTimes++;
                        TempArr = WordsArray[ClickedTimes].Split(':');
                        EnglishWord = TempArr[0];
                        ProgressCount = (ClickedTimes + 1).ToString();
                    }
                    if (ClickedTimes == 6)
                    {
                        MessageBox.Show("Урок пройден.", "Результат", MessageBoxButton.OK);
                    }
                    TranslatedWord = "🤔";
                });
            }
        }

    }
}


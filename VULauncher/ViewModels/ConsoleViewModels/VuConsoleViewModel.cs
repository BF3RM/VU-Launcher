using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using System.Windows.Media;
using VULauncher.Util;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Enums;

namespace VULauncher.ViewModels.ConsoleViewModels
{
    public class VuConsoleViewModel : DockableDocumentViewModel
    {
        public StartupType StartupType { get; set; }
        public ProcessUtils GameProcess { get; set; }

        private static readonly Dictionary<string, Color> styleSheets = new Dictionary<string, Color>
        {
            { PathRegex, Color.FromRgb(246, 185, 59) },
            { GuidRegex, Color.FromRgb(255, 103, 51) },
            { TimeStampRegex, Color.FromRgb(96, 96, 96) },
            { InfoRegex, Color.FromRgb(255, 255, 255) },
            { ErrorRegex, Color.FromRgb(200, 25, 25) },
            { SuccessRegex, Color.FromRgb(25, 200, 25) },
            { CompilingRegex, Color.FromRgb(25, 200, 25) },
        };

        private static readonly Dictionary<string, Color> ModColors = new Dictionary<string, Color>();

        public ObservableCollection<Inline> _customInlines = new ObservableCollection<Inline>();

        public IEnumerable<Inline> CustomInlines => _customInlines;

        private const string TimeStampRegex = @"^\[\d+:\d+:\d+\]";
        private const string InfoRegex = @"^\[info\]";
        private const string ErrorRegex = @"^\[error\].+";
        private const string SuccessRegex = @".+[Ss]uccess\w+.+";
        private const string CompilingRegex = @"Compiling .+\.\.\.";

        private const string GuidRegex = @"[0-9A-F]{8}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{12}";
        private const string PathRegex = @"(\w+/)+\w+";

        public VuConsoleViewModel(string consoleName, StartupType startupType)
        {
            Title = consoleName;
            StartupType = startupType;
            GameProcess = new ProcessUtils();
        }

        public string _textBoxContent = "";
        public string TextBoxContent
        {
            get => _textBoxContent;
            set => SetField(ref _textBoxContent, value);
        }

        private static readonly Random rand = new Random();

        // TODO: REMOVE
        private Color GetRandomColour()
        {
            return Color.FromArgb((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256));
        }

        private void FindRegExPatternColor(string text)
        {
            foreach (var styleSheet in styleSheets)
            {
                foreach (Match match in new Regex(styleSheet.Key).Matches(text))
                {
                    _customInlines.Add(
                        new Run
                        {
                            Text = match.Value,
                            Foreground = new SolidColorBrush(styleSheet.Value)
                        }
                    );
                }
            }
        }

        private static Color FindModColor(string modName)
        {
            if (ModColors.ContainsKey(modName))
            {
                return ModColors[modName];
            }
            else
            {
                MD5 md5 = MD5.Create();
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(modName));
                Color color = Color.FromRgb(hash[0], hash[1], hash[2]);
                ModColors.Add(modName, color);
                return color;
            }
        }


        /*
         * TODO: MAKE BETTER
         * NOT FINISHED
         */
        private void FormatAndClean(string input)
        {
            Match messageInfo = Regex.Match(input, @"^\[(\d+-\d+-\d+ (\d+:\d+:\d+).\d+:\d+)\] \[(\w+)\] ");

            if (messageInfo.Groups.Count < 3)
            {
                _customInlines.Add(
                    new Run
                    {
                        Text = input,
                        Foreground = Brushes.White
                    }
                );
                _customInlines.Add(new LineBreak());
                return;
            }

            string time = messageInfo.Groups[2].ToString();
            string type = messageInfo.Groups[3].ToString();

            string messageRaw = input.Replace(messageInfo.Groups[0].ToString(), string.Empty);

            FindRegExPatternColor("[" + time + "]");

            if (!messageRaw.Contains("[VeniceEXT]"))
            {
                if (type == "error")
                {
                    _customInlines.Add(
                        new Run
                        {
                            Text = "[" + type + "] " + messageRaw,
                            Foreground = new SolidColorBrush(Color.FromRgb(200, 25, 25))
                        }
                    );
                }
                else
                {
                    _customInlines.Add(
                        new Run
                        {
                            Text = "[" + type + "] " + messageRaw,
                            Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255))
                        }
                    );
                }
            }
            else
            {
                string message = messageRaw.Replace("[VeniceEXT] ", string.Empty);
                string modName = Regex.Match(message, @"^\[(\w+)\] ").Groups[1].ToString();

                if (modName == string.Empty)
                {
                    FindRegExPatternColor("[" + type + "] " + message);
                }
                else
                {
                    FindRegExPatternColor("[" + type + "]");
                    _customInlines.Add(
                        new Run
                        {
                            Text = "[",
                            Foreground = Brushes.AliceBlue
                        }
                    );
                    _customInlines.Add(
                        new Run
                        {
                            Text = modName,
                            Foreground = new SolidColorBrush(FindModColor(modName))
                        }
                    );
                    _customInlines.Add(
                        new Run
                        {
                            Text = "] ",
                            Foreground = Brushes.AliceBlue
                        }
                    );

                    message = message.Replace("[" + modName + "] ", "");
                    string moduleName = Regex.Match(message, @"^\[(\w+)\] ").Groups[1].ToString();

                    if (moduleName == string.Empty)
                    {
                        if (message.Contains("Compiling"))
                        {
                            _customInlines.Add(
                                new Run
                                {
                                    Text = message,
                                    Foreground = new SolidColorBrush(Color.FromRgb(50, 50, 50))
                                }
                            );
                        }
                        else if (message.Contains("Error: "))
                        {
                            _customInlines.Add(
                                new Run
                                {
                                    Text = message,
                                    Foreground = Brushes.Red
                                }
                            );
                        }
                        else
                        {
                            _customInlines.Add(
                                new Run
                                {
                                    Text = message,
                                    Foreground = Brushes.White
                                }
                            );
                        }
                    }
                    else
                    {
                        message = message.Replace("[" + moduleName + "] ", "");
                        _customInlines.Add(
                            new Run
                            {
                                Text = "[",
                                Foreground = Brushes.AliceBlue
                            }
                        );
                        _customInlines.Add(
                            new Run
                            {
                                Text = moduleName,
                                Foreground = new SolidColorBrush(FindModColor(moduleName))
                            }
                        );
                        _customInlines.Add(
                            new Run
                            {
                                Text = "] ",
                                Foreground = Brushes.AliceBlue
                            }
                        );
                        _customInlines.Add(
                            new Run
                            {
                                Text = message,
                                Foreground = Brushes.White
                            }
                        );
                    }
                }
            }

            _customInlines.Add(new LineBreak());
        }

        public void WriteLog(string text)
        {
            if (text.Length > 0)
            {
                FormatAndClean(text);
            }
        }
    }
}

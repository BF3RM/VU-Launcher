using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace VULauncher.Views.Controls.Consoles
{
    public class BindableAvalonTextEditor : ICSharpCode.AvalonEdit.TextEditor, INotifyPropertyChanged
    {
        private const string TimeStampRegex = @"^\[\d+:\d+:\d+\]";
        private const string InfoRegex = @"^\[info\]";
        private const string ErrorRegex = @"^\[error\].+";
        private const string SuccessRegex = @".+[Ss]uccess\w+.+";
        private const string CompilingRegex = @"Compiling .+\.\.\.";

        private const string GuidRegex = @"[0-9A-F]{8}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{12}";
        private const string PathRegex = @"(\w+/)+\w+";

        //Match messageInfo = Regex.Match(input, @"^\[(\d+-\d+-\d+ (\d+:\d+:\d+).\d+:\d+)\] \[(\w+)\] ");
        //string time = messageInfo.Groups[2].ToString();
        //string type = messageInfo.Groups[3].ToString();

        private static readonly Dictionary<string, Color> ModColors = new Dictionary<string, Color>();
        
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

        /// <summary>
        /// A bindable Text property
        /// </summary>
        public new string Text
        {
            get => (string)GetValue(TextProperty);
            set
            {
                SetValue(TextProperty, value);
                RaisePropertyChanged("Text");
            }
        }

        /// <summary>
        /// The bindable text property dependency property
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(BindableAvalonTextEditor),
                new FrameworkPropertyMetadata
                {
                    DefaultValue = default(string),
                    BindsTwoWayByDefault = true,
                    PropertyChangedCallback = OnDependencyPropertyChanged
                }
            );

        protected static void OnDependencyPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var target = (BindableAvalonTextEditor)obj;

            if (target.Document != null)
            {
                var caretOffset = target.CaretOffset;
                var newValue = args.NewValue;

                if (newValue == null)
                {
                    newValue = "";
                }

                target.Document.Text = (string)newValue;
                target.CaretOffset = Math.Min(caretOffset, newValue.ToString().Length);
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (this.Document != null)
            {
                Text = this.Document.Text;
            }

            base.OnTextChanged(e);
        }

        /// <summary>
        /// Raises a property changed event
        /// </summary>
        /// <param name="property">The name of the property that updates</param>
        public void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

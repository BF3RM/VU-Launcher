using System;
using System.Threading.Tasks;
using System.Windows;
using VULauncher.ViewModels.Items.Common;
using VULauncher.Views.Dialogs;

namespace VULauncher.ViewModels.Common
{
    public abstract class PageViewModel : ItemsParentViewModel, IErrorHandler
    {
        private bool _accessDeniedMessageShown;
        private string _pageTitle;
        private bool _isLoading;
        private bool _isSaving;

        protected virtual string PageTitlePrefix { get; }

        public string PageTitle
        {
            get => PageTitlePrefix == null ? _pageTitle : $"{PageTitlePrefix}: {_pageTitle}";
            set => SetField(ref _pageTitle, value);
        }

        public bool IsBusy => IsLoading || IsSaving;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (SetField(ref _isLoading, value))
                {
                    NotifyPropertyChanged(nameof(IsBusy));
                }
            }
        }

        public bool IsSaving
        {
            get => _isSaving;
            set
            {
                if (SetField(ref _isSaving, value))
                {
                    NotifyPropertyChanged(nameof(IsBusy));
                }
            }
        }

        protected virtual bool CanEdit()
        {
            return !IsBusy;
        }

        protected virtual bool CanDiscardChanges()
        {
            return CanEdit() && IsDirty;
        }

        protected virtual bool CanSaveChanges()
        {
            return CanEdit() && IsDirty;
        }

        protected virtual bool HasChanges()
        {
            return IsDirty;
        }

        public abstract void Clear();
        public abstract Task LoadDataAsync();
        public abstract Task SaveDataAsync();

        public MessageBoxResult ShowInfo(string messageBoxText, string caption = "Info")
        {
            return MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public MessageBoxResult ShowQuestion(string messageBoxText, string caption = "Question")
        {
            return MessageBox.Show(messageBoxText, caption, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        }

        public MessageBoxResult ShowError(string messageBoxText, string caption = "Error")
        {
            return MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool? ShowException(Exception ex, string caption = "Ein schwerwiegender Fehler ist aufgetreten")
        {
            //var message = ex.Message;

            //if (ex is ServerException serverException)
            //{
            //    caption = "Ein schwerwiegender Fehler ist auf dem Server aufgetreten";

            //    message = serverException.FormattedExceptionMessage;
            //}

            ExceptionViewer ev = new ExceptionViewer(caption, ex);
            return ev.ShowDialog();
            //return MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void AccessDenied()
        {
            if (!_accessDeniedMessageShown)
            {
                _accessDeniedMessageShown = true;
                MessageBox.Show("Access Denied" +
                                Environment.NewLine +
                                "The MDO Roles in Opus are required to access.",
                                "Error");
            }
        }

        public void HandleException(Exception ex)
        {
            PageTitle = "Error";
            ShowException(ex);
        }

        public void MarkItemAsDeleted(IUserCreatableItem item, Action<IUserCreatableItem> collectionRemovalAction)
        {
            if (item == null || !item.CanDelete())
            {
                return;
            }

            if (item.IsNew)
            {
                collectionRemovalAction(item);
            }
            else
            {
                item.IsDeleted = true;
            }
        }
    }
}

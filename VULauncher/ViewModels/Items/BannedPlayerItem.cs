using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items
{
    public class BannedPlayerItem : ViewModel, IUserCreatableItem
    {
        private int _index;
        private string _playerName;
        private string _playerIp;
        private string _banReason;
        private DateTime? _banDate;
        private DateTime? _unbanDate;

        public int Index
        {
            get => _index;
            set => SetField(ref _index, value, setDirty: true);
        }

        public string PlayerName
        {
            get => _playerName;
            set => SetField(ref _playerName, value, setDirty: true);
        }

        public string PlayerIp
        {
            get => _playerIp;
            set => SetField(ref _playerIp, value, setDirty: true);
        }

        public DateTime? BanDate
        {
            get => _banDate;
            set
            {
                if (SetField(ref _banDate, value, setDirty: true))
                {
                    NotifyPropertyChanged(nameof(RemainingTime));
                }
            }
        }

        public DateTime? UnbanDate
        {
            get => _unbanDate;
            set
            {
                if (SetField(ref _unbanDate, value, setDirty: true))
                {
                    NotifyPropertyChanged(nameof(RemainingTime));
                }
            }
        }

        public TimeSpan? RemainingTime => UnbanDate - BanDate;

        public string BanReason
        {
            get => _banReason;
            set => SetField(ref _banReason, value, setDirty: true);
        }

        public int Id { get; set; }
        public bool IsNew => Id == 0;

        public bool IsEmptyItem
        {
            get
            {
                return PlayerName == null ||
                       PlayerIp == null ||
                       BanDate == null ||
                       UnbanDate == null;
            }
        }

        public bool IsDeleted { get; set; }
        public bool CanDelete()
        {
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items
{
    public class MapSelectionItem : SelectableItem, IUserCreatableItem
    {
        private int _index;
        private MapType? _mapType;
        private GameModeType? _gameModeType;
        private int _repeats;

        public MapSelectionItem()
        {

        }

        public int Index
        {
            get => _index;
            set => SetField(ref _index, value, setDirty: true);
        }

        public MapType? MapType
        {
            get => _mapType;
            set => SetField(ref _mapType, value, setDirty: true);
        }

        public GameModeType? GameModeType
        {
            get => _gameModeType;
            set => SetField(ref _gameModeType, value, setDirty: true);
        }

        public int Repeats
        {
            get => _repeats;
            set => SetField(ref _repeats, value, setDirty: true);
        }

        public int Id { get; set; }
        public bool IsNew => Id == 0;

        public bool IsEmptyItem
        {
            get
            {
                return MapType == null ||
                       GameModeType == null ||
                       Repeats == 0;
            }
        }

        public bool IsDeleted { get; set; }
        public bool CanDelete()
        {
            return true;
        }
    }
}

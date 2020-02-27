namespace VULauncher.ViewModels.Items.Common
{
    public interface IUserCreatableItem : IUserEditableItem
    {
        bool IsNew { get; }
        bool IsEmptyItem { get; }
        bool IsDeleted { get; set; }
        bool CanDelete();
    }
}

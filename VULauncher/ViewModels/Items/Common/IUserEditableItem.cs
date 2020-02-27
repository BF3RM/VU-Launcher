namespace VULauncher.ViewModels.Items.Common
{
    public interface IUserEditableItem
    {
        int Id { get; set; }
        bool IsDirty { get; set; }
    }
}

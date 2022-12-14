namespace visualizer
{
    public interface IFolderPicker
    {
        Task<string> PickFolder();
    }
}

namespace visualizer;

public partial class MainPage : ContentPage
{
	private readonly IFolderPicker _folderPicker;

	public MainPage(IFolderPicker folderPicker)
	{
		InitializeComponent();
		_folderPicker = folderPicker;
    }

	private async void OnPickFolderClicked(object sender, EventArgs e)
	{
		var pickedFolder = await _folderPicker.PickFolder();
		FolderLabel.Text = pickedFolder + "\\p.out";
		SemanticScreenReader.Announce(FolderLabel.Text);
	}

    private async void OnFindOut(object sender, EventArgs e)
    {
		var graphicsView = this.DrawableView;
		((GraphicsDrawable)graphicsView.Drawable).UpdateBoard(new Board(FolderLabel.Text));
        graphicsView.Invalidate();
    }
}


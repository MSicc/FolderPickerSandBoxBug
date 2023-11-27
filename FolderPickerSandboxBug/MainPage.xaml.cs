using CommunityToolkit.Maui.Storage;
namespace FolderPickerSandboxBug;

public partial class MainPage : ContentPage
{
    int count = 0;
    private CancellationTokenSource _folderPickerCancellationTokenSource;
    private IFolderPicker _folderPicker;

    public MainPage(IFolderPicker folderPicker)
    {
        _folderPicker = folderPicker;
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private async void OnPickFolderClicked(object sender, EventArgs e)
    {
        if (_folderPickerCancellationTokenSource == null)
            _folderPickerCancellationTokenSource = new CancellationTokenSource();
            
        var pickerResult = await _folderPicker.PickAsync(_folderPickerCancellationTokenSource.Token);
    }
}

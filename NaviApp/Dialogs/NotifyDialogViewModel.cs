using CommunityToolkit.Mvvm.ComponentModel;

namespace NaviApp.Dialogs;

public class NotifyDialogViewModel : ObservableObject
{
    public NotifyDialogViewModel(string content)
    {
        Body = content;
    }

    private string _body;

    public string Body
    {
        get => _body;
        set => SetProperty(ref _body, value);
    }
}
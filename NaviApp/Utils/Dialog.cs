using MaterialDesignThemes.Wpf;
using NaviApp.Dialogs;
using Serilog;

namespace NaviApp.Utils;

public abstract class Dialog
{
    public static async void Show(object dialogIdentifier, string message)
    {
        //let's set up a little MVVM, cos that's what the cool kids are doing:
        var view = new NotifyDialog
        {
            DataContext = new NotifyDialogViewModel(message)
        };

        //show the dialog
        var result = await DialogHost.Show(view, dialogIdentifier);

        //check the result...
        Log.Verbose("Dialog was closed: {Result}", result ?? "NULL");
    }
}
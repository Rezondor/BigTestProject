using System.Runtime.CompilerServices;
using System.Windows;

namespace BigTestProject;

class MainWindowViewModel: INotifyPropertyChanged
{

    #region Window Action

    private CommandTemplate closeWindow;
    private CommandTemplate maxWindow;
    private CommandTemplate minWindow;

    public CommandTemplate CloseWindow
    {
        get
        {
            return closeWindow ??= new CommandTemplate(obj =>
            {
                Window window = (Window)obj;
                window.Close();
            });
        }
    }
    public CommandTemplate MaxWindow
    {
        get
        {
            return maxWindow ??= new CommandTemplate(obj =>
            {
                Window window = (Window)obj;
                if (window.WindowState == WindowState.Maximized)
                    window.WindowState = WindowState.Normal;
                else
                    window.WindowState = WindowState.Maximized;
            });
        }
    }
    public CommandTemplate MinWindow
    {
        get
        {
            return minWindow ??= new CommandTemplate(obj =>
            {
                Window window = (Window)obj;
                window.WindowState = WindowState.Minimized;
            });
        }
    }


    #endregion



    #region MVVM 
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
    #endregion
}

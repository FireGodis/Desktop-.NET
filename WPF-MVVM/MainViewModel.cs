using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DesktopMvvm;

public sealed class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<string> Tasks { get; } = new();
    public ICommand AddTaskCommand { get; }
    private string _newTask = "";
    public string NewTask
    {
        get => _newTask;
        set { _newTask = value; OnPropertyChanged(); }
    }

    public MainViewModel() => AddTaskCommand = new RelayCommand(AddTask);

    private void AddTask()
    {
        if (!string.IsNullOrWhiteSpace(NewTask))
        {
            Tasks.Add(NewTask.Trim());
            NewTask = "";
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

using PruefungProj_LifeOrganaiser.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace PruefungProj_LifeOrganaiser.ViewModel
{
    internal class TodoViewModel : INotifyPropertyChanged
{
    public ObservableCollection<TaskItem> TaskItems { get; set; } = new ObservableCollection<TaskItem>();

        private string _newTaskTitle;
        public string NewTaskTitle
        {
            get => _newTaskTitle;
            set {
                _newTaskTitle = value;
                OnPropertyChanged(); }
        }

        public ICommand AddTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }

        public TodoViewModel()
        {
            AddTaskCommand = new Commands.ToDo.AddTaskCommand(this);
            DeleteTaskCommand = new Commands.ToDo.DeleteTaskCommand(this);
        }

        public void AddTodo()
        {
            if (string.IsNullOrWhiteSpace(NewTaskTitle)) return;
            TaskItems.Add(new TaskItem { Title = NewTaskTitle, IsDone = false });
            NewTaskTitle = string.Empty;
        }

        public void DeleteTodo(TaskItem item)
        {
            if (item != null)
                TaskItems.Remove(item);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

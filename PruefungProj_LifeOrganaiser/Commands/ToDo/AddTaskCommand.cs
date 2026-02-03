using PruefungProj_LifeOrganaiser.View;
using PruefungProj_LifeOrganaiser.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PruefungProj_LifeOrganaiser.Commands.ToDo
{
    internal class AddTaskCommand : ICommand
    {
        private readonly TodoViewModel _viewModel;

        public AddTaskCommand(TodoViewModel vm) => _viewModel = vm;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _viewModel.AddTodo(); 
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}

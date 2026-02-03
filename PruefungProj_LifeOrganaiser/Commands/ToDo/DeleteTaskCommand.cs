using PruefungProj_LifeOrganaiser.Model;
using PruefungProj_LifeOrganaiser.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PruefungProj_LifeOrganaiser.Commands.ToDo
{
    internal class DeleteTaskCommand : ICommand
    {
        private readonly TodoViewModel _viewModel;

        public DeleteTaskCommand(TodoViewModel vm) => _viewModel = vm;

        public bool CanExecute(object parameter) => parameter is TaskItem;

        public void Execute(object parameter)
        {
            if (parameter is TaskItem item)
            {
                _viewModel.DeleteTodo(item); 
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
    }

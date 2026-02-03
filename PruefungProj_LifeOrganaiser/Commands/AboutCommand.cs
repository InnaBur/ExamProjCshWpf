using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PruefungProj_LifeOrganaiser.Commands
{
    internal class AboutCommand : ICommand
    {
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            MessageBox.Show(
                "LifeOrganiser\n\n" +
                "LifeOrganiser is a simple desktop application designed to help you organize your daily tasks and plan zour trips\n\n" +
                "Create, manage, and track your trips or to-do items easily and keep your life organized :)",
                "About LifeOrganiser",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}

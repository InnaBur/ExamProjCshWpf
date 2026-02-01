using PruefungProj_LifeOrganaiser.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PruefungProj_LifeOrganaiser.View
{
    /// <summary>
    /// Interaction logic for TripWindow.xaml
    /// </summary>
    public partial class TripWindow : Window
    {
        public TripWindow()
        {
            InitializeComponent();
            this.DataContext = new TripViewModel();
        }
    }
}

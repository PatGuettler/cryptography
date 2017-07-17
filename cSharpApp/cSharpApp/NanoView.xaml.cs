using cSharpApp.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cSharpApp
{
    /// <summary>
    /// Interaction logic for NanoView.xaml
    /// </summary>
    public partial class NanoView : Window
    {
        NanoViewVm _vm;

        public NanoView()
        {
            _vm = new NanoViewVm();
            DataContext = _vm;
            InitializeComponent();
        }
    }
}

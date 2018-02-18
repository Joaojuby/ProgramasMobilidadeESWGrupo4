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

namespace WpfApp2
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PaisesButton_Click(object sender, RoutedEventArgs e)
        {
            Paises paisesWindow = new Paises();
            paisesWindow.Show();
            this.Close();
        }

        private void ProgramMobilButton_Click(object sender, RoutedEventArgs e)
        {
            TipoProgramMobili programMobilidadeWindow = new TipoProgramMobili();
            programMobilidadeWindow.Show();
            this.Close();
        }
    }
}

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

namespace VectorCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Pair Vect1 { get; set; }
        public Pair Vect2 { get; set; }
        public ResultVector Vect3 {get; set;}

        public MainWindow()
        {
            InitializeComponent();
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadData();
                DisplayResult();
            }
            catch (FormatException)
            {
                MessageBox.Show("You have to type in values in every single TextBox." +
                                "\nRequired format is e.g. XX or XX,XX (X - digit)." +
                                "\nPlease use \",\" insted of \".\"");
            }
    
        }

        public void LoadData ()
        {
            if(true)   
            Vect1 = new Pair(double.Parse(textBox.Text), double.Parse(textBox1.Text), Pair.Option.Angle);
            Vect2 = new Pair(double.Parse(textBox2.Text), double.Parse(textBox3.Text), Pair.Option.Angle);
        }

        public void DisplayResult()
        {
            Vect3 = new ResultVector(Vect1, Vect2);
            result.Content = Vect3;
        }

        

      
    }
}

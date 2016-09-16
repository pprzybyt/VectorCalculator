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


        public List<StackPanel> Panel { get; set; }
        public List<TextBox> Forces { get; set; }
        public List<TextBox> Angles { get; set; }
        public List<Pair> Vectors { get; set; }
        public int Count { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            DefaultSettings();
        }

        public void DefaultSettings()
        {
            Panel = new List<StackPanel>();
            Forces = new List<TextBox>();
            Angles = new List<TextBox>();
            Vectors = new List<Pair>();

            Panel.Add(stack3);
            Panel.Add(stack4);
            Panel.Add(stack5);

            Forces.Add(textBox);
            Forces.Add(textBox2);
            Forces.Add(textBox4);
            Forces.Add(textBox6);
            Forces.Add(textBox8);

            Angles.Add(textBox1);
            Angles.Add(textBox3);
            Angles.Add(textBox5);
            Angles.Add(textBox7);
            Angles.Add(textBox9);

            Vectors.Add(new Pair());
            Vectors.Add(new Pair());
            Vectors.Add(new Pair());
            Vectors.Add(new Pair());
            Vectors.Add(new Pair());

            this.Count = 2;
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

        private void LoadData ()
        {
            for (int i = 0; i < this.Count; i++)
                Vectors[i] = new Pair(Double.Parse(Forces[i].Text), Double.Parse(Angles[i].Text), Pair.Option.Angle);

        }

        private Pair GetVector()
        {
            Pair vector = Vectors[0];

            for(int i = 1; i<Count; i++)
            {
                vector = new Pair(vector, Vectors[i]);
            }

            return vector;
        }

        private void DisplayResult()
        {
            result.Content = GetVector();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            foreach (StackPanel s in Panel)
                s.Visibility = Visibility.Hidden;

            this.Count = int.Parse(comboBox.SelectionBoxItem.ToString());


            for (int i = 0; i < Count - 2; i++)
            {
                Panel[i].Visibility = Visibility.Visible;
            }

            for (int i = 5; i> Count; i--)
            {
                Forces[i-1].Text = "";
                Angles[i-1].Text = "";
            }

        }

        private void comboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBox tb in Forces)
                tb.Text = "";
            foreach (TextBox tb in Angles)
                tb.Text = "";

            result.Content = "";
        }
    }
}

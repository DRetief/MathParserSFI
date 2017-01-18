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

namespace SFIMathParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main = this;
        }

        internal static MainWindow Main;
        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Calculate();
            }
        }

        private void Calculate()
        {
            try
            {
                // Calculate Result
                var result = SimpleExpressionClass.CalculateExpression(textBoxInput.Text);
                labelAnswer.Content = result;
                textBlockMessage.Text = "";
            }
            catch (Exception e)
            {
                textBlockMessage.Text = "Error: " + e.Message;
                labelAnswer.Content = "";
            }
            // Display Question & Answer
            labelQuestion.Content = textBoxInput.Text;

            // Clear Input
            textBoxInput.Text = null;
        }
    }
}

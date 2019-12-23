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

namespace PassGen
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string passString;
        private bool ifSymbols = false;
        private bool ifNumbers = false;
        private bool ifUpperCase = false;
        private bool ifSame = false;
        private int length = 0;
        private int lengthTmp = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            passResult.Text = "";
            passString = "abcdefghjkmnopqrstuvwxyz";
            
            if (ifSymbols)
            {
                passString += "!@#$%^&*";
            }
            
            if (ifNumbers)
            {
                passString += "23456789";
            }
            
            if (ifUpperCase)
            {
                passString += "ABCDEFGHJKLMNPQRSTUVWXYZ";
            }
            
            if (ifSame)
            {
                passString += "ilI0O1";
            }

            length = Convert.ToInt32(passLength.Text);
            lengthTmp = length;
            
            StringBuilder strB = new StringBuilder();
            Random rnd = new Random();

            for(int i = 0; i < 20; i++)
            {
                while(0 < lengthTmp--)
                {
                    strB.Append(passString[rnd.Next(passString.Length)]);
                }

                passResult.Text += strB.ToString() + "\n";
                
                strB.Clear();
                lengthTmp = length;
            }
            
        }

        private void upperCaseCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ifUpperCase = true;
        }

        private void sameCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ifSame = true;
        }

        private void symbolCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ifSymbols = true;
        }

        private void numberCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ifNumbers = true;
        }

        private void upperCaseCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ifUpperCase = false;
        }

        private void symbolCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ifSymbols = false;
        }


        private void numberCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ifNumbers = false;
        }

        private void sameCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ifSame = false;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

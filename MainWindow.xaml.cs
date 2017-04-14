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
using System.Diagnostics;
using MahApps.Metro;
using MahApps.Metro.Controls;

namespace Weekend_proj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.textBox1.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            this.textBox2.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            this.textBox3.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            this.textBox4.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            contest = contestC;
        }

        void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        public int tntcost;
        public int get;
        public int balance;
        public int tntnum;
        bool changed;
        bool step1b = false;

        string buff1;
        string buff2;

        public string context;
        public string contextA = " инвентарь.";
        public string contextB = " инвентаря.";
        public string contextC = " инветарей.";
        double var2a;

        string contest;
        string contestA = " стак";
        string contestB = " стака";
        string contestC = " стаков";

        void step1()
        {
            if (!string.IsNullOrEmpty(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text))
            {
                textBox3.IsEnabled = true;
                textBox4.IsEnabled = true;
                check1.IsEnabled = true;
                check2.IsEnabled = true;
                text1.IsEnabled = true;
                text2.IsEnabled = true;
                text3.IsEnabled = true;
            }
            else
            {
                textBox3.IsEnabled = false;
                textBox4.IsEnabled = false;
                check1.IsEnabled = false;
                check2.IsEnabled = false;
                text1.IsEnabled = false;
                text2.IsEnabled = false;
                text3.IsEnabled = false;
            }
        }

        void step2()
        {
                /*if (!string.IsNullOrEmpty(tntcost.ToString()) || !string.IsNullOrEmpty(balance.ToString()))
                {
                    if (check1.IsEnabled == true)
                    {
                        check2.IsEnabled = true;
                    }
                    action2.IsEnabled = true;
                }*/
        }

        private void check1_Checked(object sender, RoutedEventArgs e)
        {
            buff1 = textBox4.Text;
            textBox4.Clear();
            textBox4.IsReadOnly = true;
            textBox3.IsReadOnly = false;
            //textBox4.IsReadOnlyCaretVisible = false;

            check2.IsChecked = false;
            step2();

            textBox3.Focus();
        }

        private void check2_Checked(object sender, RoutedEventArgs e)
        {
            buff2 = textBox3.Text;
            textBox3.Clear();
            textBox3.IsReadOnly = true;
            textBox4.IsReadOnly = false;
            //textBox3.IsReadOnlyCaretVisible = false;

            check1.IsChecked = false;
            step2();

            textBox4.Focus();
        }

        private void action1_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) &&
                !String.IsNullOrEmpty(textBox2.Text))
            {
                step1();

                get = Convert.ToInt32(textBox1.Text);
                tntcost = Convert.ToInt32(textBox2.Text);

                if (Convert.ToInt32(textBox1.Text) == get &&
                    Convert.ToInt32(textBox2.Text) == tntcost)
                {
                    action1.IsEnabled = false;
                    changed = true;
                }
            }

            if (step1b == false)
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    textBox1.Focus();
                    step1b = true;
                    
                }
            }
            else if (step1b == true)
            {
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    textBox2.Focus();
                    step1b = false;
                }
            }
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (changed == true)
            {
                if (textBox1.Text.Length > 0)
                {
                    if (Convert.ToInt32(textBox1.Text) != get ||
                        Convert.ToInt32(textBox2.Text) != tntcost)
                    {
                        action1.IsEnabled = true;
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (changed == true)
            {
                if (textBox2.Text.Length > 0)
                {
                    if (Convert.ToInt32(textBox1.Text) != get ||
                        Convert.ToInt32(textBox2.Text) != tntcost)
                    {
                        action1.IsEnabled = true;
                    }
                }
            }
        }

        private void action2_Click(object sender, RoutedEventArgs e)
        {
            if (check1.IsChecked == true)
            {
                    if (!String.IsNullOrEmpty(textBox3.Text))
                    {
                        tntnum = Convert.ToInt32(textBox3.Text);

                        int cost = tntnum * tntcost / get + 1;
                        int var1 = tntnum * tntcost;

                        var2a = cost / 36;
                        var2a = var2a + 1;

                        if (var2a <= 1)
                        {
                            context = contextA;
                        }
                        if (var2a >= 2)
                        {
                            context = contextB;
                        }
                        if (var2a >= 5)
                        {
                            context = contextC;
                        }

                        if (cost + 1 == 1 || cost + 1 == 21 || cost + 1 == 31 || cost + 1 == 41 || cost + 1 == 51 ||
                            cost + 1 == 61 || cost + 1 == 71 || cost + 1 == 81 || cost + 1 == 91 || cost + 1 == 101 ||
                            cost + 1 == 121 || cost + 1 == 131 || cost + 1 == 141 || cost + 1 == 151 || cost + 1 == 161 ||
                            cost + 1 == 171 || cost + 1 == 181 || cost + 1 == 191 || cost + 1 == 201 || cost + 1 == 221 ||
                            cost + 1 == 231 || cost + 1 == 141 || cost + 1 == 151 || cost + 1 == 261 || cost + 1 == 271 ||
                            cost + 1 == 281 || cost + 1 == 291 || cost + 1 == 301 || cost + 1 == 321 ||
                            cost + 1 == 331 || cost + 1 == 341 || cost + 1 == 351 || cost + 1 == 361 || cost + 1 == 371 ||
                            cost + 1 == 381 || cost + 1 == 391 || cost + 1 == 401 || cost + 1 == 421 ||
                            cost + 1 == 431 || cost + 1 == 441 || cost + 1 == 451 || cost + 1 == 461 || cost + 1 == 471 ||
                            cost + 1 == 481 || cost + 1 == 491 || cost + 1 == 501 || cost + 1 == 521 ||
                            cost + 1 == 531 || cost + 1 == 541 || cost + 1 == 551 || cost + 1 == 561 || cost + 1 == 571)
                        {
                            contest = contestA;
                        }

                        logBox.Text = "Для того, чтобы купить " + tntnum.ToString() + " ТНТ, Вам понадобится " +
                        var1 + "$, а это - " + cost.ToString() + " стаков сырья (" + var2a + ")" + context;
                    }
            }
            if (check2.IsChecked == true)
            {
                    if (!String.IsNullOrEmpty(textBox4.Text))
                    {
                        balance = Convert.ToInt32(textBox4.Text);
                        int tnt_num = balance / tntcost;
                        int tnt_stack = tnt_num / 64;
                        int left1 = tnt_num * tntcost;
                        int left2 = balance - left1;

                        if (left2 != 0)
                        {
                            if (tnt_stack > 4 - 1)
                            {
                                logBox.Text = "На " + balance.ToString() + "$, можно купить " + tnt_num.ToString() + " ТНТ, " + tnt_stack.ToString() + " стаков(а) (останется денег: " + left2.ToString() + "$).";
                            }
                            else
                            {
                                logBox.Text = "На " + balance.ToString() + "$, можно купить " + tnt_num.ToString() + " ТНТ (останется: " + left2.ToString() + "$).";
                            }
                            //logBox.Text = "На " + balance.ToString() + "$, можно купить " + tnt_num.ToString() + " ТНТ (останется: " + left2.ToString() + "$).";
                        }
                        else
                        {
                            if (tnt_stack > 4 - 1)
                            {
                                logBox.Text = "На " + balance.ToString() + "$, можно купить " + tnt_num.ToString() + " ТНТ, " + tnt_stack.ToString() + " стаков(а)";
                            }
                            else
                            {
                                logBox.Text = "На " + balance.ToString() + "$, можно купить " + tnt_num.ToString() + " ТНТ.";
                            }
                            //logBox.Text = "На " + balance.ToString() + "$, можно купить " + tnt_num.ToString() + " ТНТ.";
                        }
                    }
            }
        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((check1.IsChecked == true && String.IsNullOrEmpty(textBox3.Text)) || 
                (check2.IsEnabled == true && String.IsNullOrEmpty(textBox4.Text)))
            {
                action2.IsEnabled = true;
            }

            if (textBox3.Text.Length < 1)
            {
                logBox.Clear();
                action2.IsEnabled = false;
            }

            if (check1.IsChecked == false || check2.IsChecked == false)
            {
                check1.IsChecked = true;
            }
        }

        private void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (check1.IsChecked == true || check2.IsEnabled == true)
            {
                action2.IsEnabled = true;
            }

            if (textBox4.Text.Length < 1)
            {
                logBox.Clear();
                action2.IsEnabled = false;
            }

            if (check1.IsChecked == false || check2.IsChecked == false)
            {
                check2.IsChecked = true;
            }
        }

        private void clearBtn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            logBox.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://vk.com/the_equal1zer");
        }
    }
}

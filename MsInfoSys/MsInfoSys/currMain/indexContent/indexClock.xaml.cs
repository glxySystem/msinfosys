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
using System.IO;
using System.Text.RegularExpressions;

namespace MsInfoSys.currMain.indexContent
{
    /// <summary>
    /// indexClock.xaml 的交互逻辑
    /// </summary>
    public partial class indexClock : UserControl
    {
        string clockText = File.ReadAllText("Text/clock.txt");
        public indexClock()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string[] clockArr = clockText.Split('/');
            for (int index = 1; index <= clockArr.Length - 1; index++)
            {
                TextBox currClock = new TextBox();
                Style currClockStyle = (Style)FindResource("currClock");
                currClock.Style = currClockStyle;
                currClock.Text = clockArr[index];
                clockList.Children.Add(currClock);
            }
        }
        private void OpeClock_MouseDown(object sender, RoutedEventArgs e)
        {
            string time = "";
            foreach (Control control in clockList.Children)
            {
                if (control is TextBox)
                {
                    TextBox currCon = (TextBox)control;
                    string currCon_time = currCon.Text.ToString();
                    Regex reg = new Regex(@"^((20|21|22|23|[0-1]?\d):[0-5]\d:[0-5]\d)$");
                    Match m = reg.Match(currCon_time);
                    if (currCon_time != "")
                    {
                        if (m.Success)
                        {
                            currCon_time = "/" + currCon_time;
                            time += currCon_time;
                        }
                        else
                        {
                            MessageBox.Show(currCon_time + "格式不正确，已删除");
                        }
                    }
                    else
                    {
                        time += "";
                    }
                    clockText = time;
                    StreamWriter sw = new StreamWriter("Text/clock.txt", false);
                    sw.Write(clockText);
                    sw.Close();//写入
                }

            }
            string[] clockArr = clockText.Split('/');
            clockList.Children.Clear();
            for (int index = 1; index <= clockArr.Length - 1; index++)
            {
                TextBox currClock = new TextBox();
                Style currClockStyle = (Style)FindResource("currClock");
                currClock.Style = currClockStyle;
                currClock.Text = clockArr[index];
                clockList.Children.Add(currClock);
            }

        }

        private void addClock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string time = "";
            foreach (Control control in clockAdd.Children)
            {
                if (control is TextBox)
                {
                    TextBox currCon = (TextBox)control;
                    string currCon_time = currCon.Text.ToString();
                    Regex reg = new Regex(@"^((20|21|22|23|[0-1]?\d):[0-5]\d:[0-5]\d)$");
                    Match m = reg.Match(currCon_time);
                    if (currCon_time != "")
                    {
                        if (m.Success)
                        {
                            currCon_time = "/" + currCon_time;
                            time += currCon_time;
                            clockText += time;
                            StreamWriter sw = new StreamWriter("Text/clock.txt", false);
                            sw.Write(clockText);
                            sw.Close();//写入
                            currCon.Text = "";
                        }
                        else
                        {
                            MessageBox.Show(currCon_time + "格式不正确，请重新添加");
                        }
                    }
                }
            }
            string[] clockArr = clockText.Split('/');
            clockList.Children.Clear();
            for (int index = 1; index <= clockArr.Length - 1; index++)
            {
                TextBox currClock = new TextBox();
                Style currClockStyle = (Style)FindResource("currClock");
                currClock.Style = currClockStyle;
                currClock.Text = clockArr[index];
                clockList.Children.Add(currClock);
            }
        }
    }
}

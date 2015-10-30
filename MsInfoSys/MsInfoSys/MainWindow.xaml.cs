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
using Forms = System.Windows.Forms;
using System.Timers;
using System.Media;
using System.IO;
using System.Text.RegularExpressions;

namespace MsInfoSys
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        WindowState wsl;
        Forms.NotifyIcon notifyIcon;

        //定义一个全局rect记录还原状态下窗口的位置和大小。
        Rect rcnormal;             
             
        public MainWindow()
        {
            InitializeComponent();
            ShowIcon();

            //保证窗体显示在上方。 
            wsl = WindowState;

            //设置定时器
            Timer timeClock = new Timer();
            timeClock.Enabled = true;
            timeClock.Interval = 1000;
            timeClock.Elapsed += new ElapsedEventHandler(clock);
        }


        //闹钟功能
        protected void clock(object source, ElapsedEventArgs e)
        {
            //获取闹钟时间
            string clockText = File.ReadAllText("Text/clock.txt");
            string currTime = DateTime.Now.ToLongTimeString().ToString();
            Regex reg = new Regex(currTime);
            Match m = reg.Match(clockText);
            if (m.Success)
            {
                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = @"Sound/clock.wav";
                sp.Play();
            }
        }

        //显示托盘图标
        private void ShowIcon()
        {
            this.notifyIcon = new Forms.NotifyIcon();
            this.notifyIcon.BalloonTipText = "我在这里";                        //设置程序启动时显示的文本 
            this.notifyIcon.Text = "管理学院信息服务系统";                      //最小化到托盘时，鼠标点击时显示的文本 
            this.notifyIcon.Icon = new System.Drawing.Icon("Downloads.ico");    //程序图标 
            this.notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += OnNotifyIconDoubleClick;
            this.notifyIcon.ShowBalloonTip(1000);
        }
        private void OnNotifyIconDoubleClick(object sender, EventArgs e)
        {
            this.Show();
            WindowState = wsl;
        }


        //最大化+最小化切换
        private void togglemax_Click(object sender, RoutedEventArgs e)
        {
            Rect rc = SystemParameters.WorkArea;//获取工作区大小
            if (this.Width == rc.Width) {
                this.Left = rcnormal.Left;
                this.Top = rcnormal.Top;
                this.Width = rcnormal.Width;
                this.Height = rcnormal.Height;
                BitmapImage toggleChangeimage = new BitmapImage(new Uri("\\icon\\togglemax.png", UriKind.Relative));
                togglemaxImg.Source = toggleChangeimage;
            }
            else{
                rcnormal = new Rect(this.Left, this.Top, this.Width, this.Height);//保存下当前位置与大小
                this.Left = 0;//设置位置
                this.Top = 0;
                this.Width = rc.Width;
                this.Height = rc.Height;
                BitmapImage togglemaximage = new BitmapImage(new Uri("\\icon\\togglemaxChange.png", UriKind.Relative));
                togglemaxImg.Source = togglemaximage;
            }
        }
        private void togglemax_MouseEnter(object sender, MouseEventArgs e)
        {
            togglemaxBg.Background = new SolidColorBrush(Color.FromRgb(69, 76, 86));
        }

        private void togglemax_MouseLeave(object sender, MouseEventArgs e)
        {
            togglemaxBg.Background = new SolidColorBrush(Color.FromRgb(44, 151, 223));
        }



        //调整窗口尺寸
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.ActualHeight > SystemParameters.WorkArea.Height || this.ActualWidth > SystemParameters.WorkArea.Width)
            {
                this.WindowState = System.Windows.WindowState.Normal;
                togglemax_Click(null, null);
            }
        }



        //隐藏窗体
        private void hide_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        private void hide_MouseEnter(object sender, MouseEventArgs e)
        {
            hideBg.Background = new SolidColorBrush(Color.FromRgb(69, 76, 86));
        }

        private void hide_MouseLeave(object sender, MouseEventArgs e)
        {
            hideBg.Background = new SolidColorBrush(Color.FromRgb(44, 151, 223));
        }



        //关闭窗体
        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void close_MouseEnter(object sender, MouseEventArgs e)
        {
            closeBg.Background = new SolidColorBrush(Color.FromRgb(224, 67, 67));
        }

        private void close_MouseLeave(object sender, MouseEventArgs e)
        {
            closeBg.Background = new SolidColorBrush(Color.FromRgb(44, 151, 223));
        }



        //加载默认子栏目模块及内容模块
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            index.DataContext = "2";
            indexStack.Background = new SolidColorBrush(Color.FromRgb(69, 76, 86));
            BitmapImage image = new BitmapImage(new Uri("\\icon\\indexChange.png", UriKind.Relative));
            indexImg.Source = image;
            currTab.Content = new currTab.index();
        }
 
        
        private void Topshow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void index_Click(object sender, RoutedEventArgs e)
        {
            undergraduate.DataContext = "1";
            undergraduateStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image1 = new BitmapImage(new Uri("\\icon\\undergraduate.png", UriKind.Relative));
            undergraduateImg.Source = image1;

            graduate.DataContext = "1";
            graduateStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image2 = new BitmapImage(new Uri("\\icon\\graduate.png", UriKind.Relative));
            graduateImg.Source = image2;

            apartment.DataContext = "1";
            apartmentStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image3 = new BitmapImage(new Uri("\\icon\\apartment.png", UriKind.Relative));
            apartmentImg.Source = image3;

            document.DataContext = "1";
            documentStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image4 = new BitmapImage(new Uri("\\icon\\document.png", UriKind.Relative));
            documentImg.Source = image4;

            index.DataContext = "2";
            currTab.Content = new currTab.index();
        }
        private void index_MouseEnter(object sender, MouseEventArgs e)
        {
            //      改变图片
            //      BitmapImage image = new BitmapImage(new Uri("\\icon\\11.png", UriKind.Relative));
            //      userImg.Source = image;
            //改变opacity
            if ((string)index.DataContext == "1")
            {
                /*   
                   indexStack.Background = new SolidColorBrush(Color.FromRgb(69, 76, 86));
                   indexImg.Opacity = 1;
                   indexTitle.Foreground = new SolidColorBrush(Colors.White);  //用固态画刷填充前景色 
               */
                indexStack.Background = new SolidColorBrush(Color.FromRgb(69, 76, 86));
                BitmapImage image = new BitmapImage(new Uri("\\icon\\indexChange.png", UriKind.Relative));
                indexImg.Source = image;
            }
        }

        private void index_MouseLeave(object sender, MouseEventArgs e)
        {
            //     BitmapImage image = new BitmapImage(new Uri("\\icon\\logo.png", UriKind.Relative));
            //     userImg.Source = image;
            if((string)index.DataContext == "1")
            {
                /*
                indexStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
                indexImg.Opacity = 0.8;
                indexTitle.Foreground = new SolidColorBrush(Color.FromRgb(204, 204, 204));  //用固态画刷填充前景色
                */
                indexStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
                BitmapImage image = new BitmapImage(new Uri("\\icon\\index.png", UriKind.Relative));
                indexImg.Source = image;
            }
        }
        private void undergraduate_Click(object sender, RoutedEventArgs e)
        {
            index.DataContext = "1";
            indexStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image1 = new BitmapImage(new Uri("\\icon\\index.png", UriKind.Relative));
            indexImg.Source = image1;

            graduate.DataContext = "1";
            graduateStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image2 = new BitmapImage(new Uri("\\icon\\graduate.png", UriKind.Relative));
            graduateImg.Source = image2;

            apartment.DataContext = "1";
            apartmentStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image3 = new BitmapImage(new Uri("\\icon\\apartment.png", UriKind.Relative));
            apartmentImg.Source = image3;

            document.DataContext = "1";
            documentStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image4 = new BitmapImage(new Uri("\\icon\\document.png", UriKind.Relative));
            documentImg.Source = image4;

            undergraduate.DataContext = "2";
            currTab.Content = new currTab.undergraduate();
        }

        private void undergraduate_MouseEnter(object sender, MouseEventArgs e)
        {
            if ((string)undergraduate.DataContext == "1")
            {
                undergraduateStack.Background = new SolidColorBrush(Color.FromRgb(69, 76, 86));
                BitmapImage image = new BitmapImage(new Uri("\\icon\\undergraduateChange.png", UriKind.Relative));
                undergraduateImg.Source = image;
            }
        }

        private void undergraduate_MouseLeave(object sender, MouseEventArgs e)
        {
            if ((string)undergraduate.DataContext == "1")
            {
                undergraduateStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
                BitmapImage image = new BitmapImage(new Uri("\\icon\\undergraduate.png", UriKind.Relative));
                undergraduateImg.Source = image;
            }
        }
        private void graduate_Click(object sender, RoutedEventArgs e)
        {
            index.DataContext = "1";
            indexStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image1 = new BitmapImage(new Uri("\\icon\\index.png", UriKind.Relative));
            indexImg.Source = image1;

            undergraduate.DataContext = "1";
            undergraduateStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image2 = new BitmapImage(new Uri("\\icon\\undergraduate.png", UriKind.Relative));
            undergraduateImg.Source = image2;

            apartment.DataContext = "1";
            apartmentStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image3 = new BitmapImage(new Uri("\\icon\\apartment.png", UriKind.Relative));
            apartmentImg.Source = image3;

            document.DataContext = "1";
            documentStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image4 = new BitmapImage(new Uri("\\icon\\document.png", UriKind.Relative));
            documentImg.Source = image4;

            graduate.DataContext = "2";
            currTab.Content = new currTab.graduate();
        }

        private void graduate_MouseEnter(object sender, MouseEventArgs e)
        {
            if ((string)graduate.DataContext == "1")
            {
                graduateStack.Background = new SolidColorBrush(Color.FromRgb(69, 76, 86));
                BitmapImage image = new BitmapImage(new Uri("\\icon\\graduateChange.png", UriKind.Relative));
                graduateImg.Source = image;
            }
        }

        private void graduate_MouseLeave(object sender, MouseEventArgs e)
        {
            if ((string)graduate.DataContext == "1")
            {
                graduateStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
                BitmapImage image = new BitmapImage(new Uri("\\icon\\graduate.png", UriKind.Relative));
                graduateImg.Source = image;
            }
        }

        private void apartment_Click(object sender, RoutedEventArgs e)
        {
            index.DataContext = "1";
            indexStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image1 = new BitmapImage(new Uri("\\icon\\index.png", UriKind.Relative));
            indexImg.Source = image1;

            undergraduate.DataContext = "1";
            undergraduateStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image2 = new BitmapImage(new Uri("\\icon\\undergraduate.png", UriKind.Relative));
            undergraduateImg.Source = image2;

            graduate.DataContext = "1";
            graduateStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image3 = new BitmapImage(new Uri("\\icon\\graduate.png", UriKind.Relative));
            graduateImg.Source = image3;

            document.DataContext = "1";
            documentStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image4 = new BitmapImage(new Uri("\\icon\\document.png", UriKind.Relative));
            documentImg.Source = image4;

            apartment.DataContext = "2";
            currTab.Content = new currTab.apartment();
        }

        private void apartment_MouseEnter(object sender, MouseEventArgs e)
        {
            if ((string)apartment.DataContext == "1")
            {
                apartmentStack.Background = new SolidColorBrush(Color.FromRgb(69, 76, 86));
                BitmapImage image = new BitmapImage(new Uri("\\icon\\apartmentChange.png", UriKind.Relative));
                apartmentImg.Source = image;
            }
        }

        private void apartment_MouseLeave(object sender, MouseEventArgs e)
        {
            if ((string)apartment.DataContext == "1")
            {
                apartmentStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
                BitmapImage image = new BitmapImage(new Uri("\\icon\\apartment.png", UriKind.Relative));
                apartmentImg.Source = image;
            }
        }

        private void document_Click(object sender, RoutedEventArgs e)
        {
            index.DataContext = "1";
            indexStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image1 = new BitmapImage(new Uri("\\icon\\index.png", UriKind.Relative));
            indexImg.Source = image1;

            undergraduate.DataContext = "1";
            undergraduateStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image2 = new BitmapImage(new Uri("\\icon\\undergraduate.png", UriKind.Relative));
            undergraduateImg.Source = image2;

            graduate.DataContext = "1";
            graduateStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image3 = new BitmapImage(new Uri("\\icon\\graduate.png", UriKind.Relative));
            graduateImg.Source = image3;

            apartment.DataContext = "1";
            apartmentStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
            BitmapImage image4 = new BitmapImage(new Uri("\\icon\\apartment.png", UriKind.Relative));
            apartmentImg.Source = image4;

            document.DataContext = "2";
        }

        private void document_MouseEnter(object sender, MouseEventArgs e)
        {
            if ((string)document.DataContext == "1")
            {
                documentStack.Background = new SolidColorBrush(Color.FromRgb(69, 76, 86));
                BitmapImage image = new BitmapImage(new Uri("\\icon\\documentChange.png", UriKind.Relative));
                documentImg.Source = image;
            }
        }
        private void document_MouseLeave(object sender, MouseEventArgs e)
        {
            if ((string)document.DataContext == "1")
            {
                documentStack.Background = new SolidColorBrush(Color.FromRgb(53, 60, 70));
                BitmapImage image = new BitmapImage(new Uri("\\icon\\document.png", UriKind.Relative));
                documentImg.Source = image;
            }
        }


    }
}

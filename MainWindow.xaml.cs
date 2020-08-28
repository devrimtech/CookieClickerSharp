using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CookieClicker
{
    /// <summary>
    /*TODO:
     * Get button click event
     * Store amount of clicks in a variable.
     * Update the cookie count by 1
     */

    /// </summary>
    public partial class MainWindow : Window
    {
        int currentCookies;
        int clickPower = 1;
        int currentAutos = 0;
        int autoClickerPrice = 50;
        int betterClickPrice = 80;

        DispatcherTimer autoTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void InitTimer()
        {
            autoTimer.Interval = new TimeSpan(0, 0, 2);
            autoTimer.Tick += new EventHandler(timer1_Tick);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moreCookie(currentAutos);
        }

        private void moreCookie(int clickCounts)
        {
            currentCookies += clickCounts;
            cookieText.Content = "Cookies: " + currentCookies.ToString();
        }

        private void cookieClick(object sender, RoutedEventArgs e)
        {
            moreCookie(clickPower);
        }
        private void buyAuto(object sender, RoutedEventArgs e)
        {
            if (currentCookies >= autoClickerPrice)
            {
                currentCookies = currentCookies - autoClickerPrice;
                currentAutos++;
                autoClickerPrice += 10;
                cookieText.Content = "Cookies: " + currentCookies.ToString();

                if (autoTimer.IsEnabled == false)
                {
                    InitTimer();
                    autoTimer.Start();
                }
            }
        }

        private void buyBetterClicks(object sender, RoutedEventArgs e)
        {
            if (currentCookies >= betterClickPrice)
            {
                currentCookies = currentCookies - betterClickPrice;
                clickPower++;
                betterClickPrice += 20;
                cookieText.Content = "Cookies: " + currentCookies.ToString();
            }
        }
    }
}

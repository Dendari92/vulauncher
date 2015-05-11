﻿using Microsoft.Win32;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Launch Venice with the selected freq.
        private void launchVenice(String frequency, String vu_path)
        {
            System.Diagnostics.Process.Start(vu_path, "-high" + frequency);
            if (closeAfterLaunch.IsChecked == true)
                Application.Current.Shutdown();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Getting VU/BF3 install path 
            String reg_path = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\EA Games\Battlefield 3", "Install Dir", null);

            // In case VU/BF3 is installed on 32bit system
            if (reg_path == null)
            {
                reg_path = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\EA Games\Battlefield 3", "Install Dir", null);
            }

            // VU/BF3 install path
            String vu_path = (reg_path + "\\vu.exe");

            // Which option has been selected, launch VU in 30Hz, 60Hz or 120Hz
            // In case of 30Hz...
            if (radioButton.IsChecked == true)
            {
                launchVenice("30", vu_path);
            }
            // In case of 60Hz...
            else if (radioButton1.IsChecked == true)
            {
                launchVenice("60", vu_path);
            }
            // In case of 120Hz...
            else if (radioButton2.IsChecked == true)
            {
                launchVenice("120", vu_path);
            }
        }
    }
}

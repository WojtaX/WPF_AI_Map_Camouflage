using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Windows.Interop;
using System.Windows.Media.Animation;


namespace Zord_4_MC_v1_WL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Map mapa;
        ControllerMC MC;
        public MainWindow()
        {
            

           InitializeComponent();
           MC = new ControllerMC(this);
           
     
            
        }

       

       
    }
}

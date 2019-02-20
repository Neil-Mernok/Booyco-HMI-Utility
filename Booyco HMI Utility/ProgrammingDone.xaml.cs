﻿using System;
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

namespace Booyco_HMI_Utility
{
    /// <summary>
    /// Interaction logic for ProgrammingDone.xaml
    /// </summary>
    public partial class ProgrammingDone : UserControl
    {
        public ProgrammingDone()
        {
            InitializeComponent();
        }

        private void BtnProgramDone_Click(object sender, RoutedEventArgs e)
        {
            Bootloader.BootDone = false;
            this.Visibility = Visibility.Collapsed;
        }
    }
}

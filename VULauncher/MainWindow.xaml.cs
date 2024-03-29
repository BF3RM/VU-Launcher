﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace VULauncher
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

        private void MainWindow_OnClosed(object? sender, EventArgs e)
        {
            CloseAllConsoles();
        }

        private void CloseAllConsoles()
        {
            var viewModel = (MainViewModel)DataContext;
            viewModel.CloseAllConsolesCommand.Execute(null);
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;
            if (!viewModel.ConsolesViewModel.IsAnyRunning)
            {
                return;
            }

            MessageBoxResult result = MessageBox.Show($"Are you sure you want to close the VU Launcher? This will close all open game processes.", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                CloseAllConsoles();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}

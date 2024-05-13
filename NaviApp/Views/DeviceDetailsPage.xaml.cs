﻿using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Messaging;
using NaviApp.Enums;
using NaviApp.Models;
using NaviApp.ViewModels;

namespace NaviApp.Views;

public partial class DeviceDetailsPage : Page
{
    public DeviceDetailsPage()
    {
        InitializeComponent();
        Loaded += ViewLoaded;
    }

    private void Room_Click(object sender, RoutedEventArgs e)
    {
        if (((FrameworkElement)sender).DataContext is not DeviceDetailViewModel vm) return;
        if (null == vm.Owner) return;
        WeakReferenceMessenger.Default.Send(new Message { Id = MessageId.Jump2R, Extra = vm.Owner.Id });
    }

    private void ViewLoaded(object sender, RoutedEventArgs e)
    {
        //获得viewModel
        var vm = DataContext as DeviceDetailViewModel;
        vm?.LoadDataAsync();
    }
}
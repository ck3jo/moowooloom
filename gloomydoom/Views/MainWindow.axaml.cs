using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace gloomydoom.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void ButtonClicked(object source, RoutedEventArgs args)
    {
        if (Double.TryParse(celsius.Text, out double c))
        {
            var f = c * (9d / 5d) + 32;
            fahreheit.Text = f.ToString("0.00");
        }
        else
        {
            celsius.Text = "0";
            fahreheit.Text = "0";
        }
    }
}
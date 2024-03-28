using System;
using System.IO;
using System.Reflection;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using HtmlRenderer.Models;
using RtfToHtml;

namespace HtmlRenderer.Views;

public partial class MainWindow : Window
{
    private static readonly Encoding DefaultEncoding = Encoding.UTF8;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void RenderHtmlButtonOnClick(object? sender, RoutedEventArgs e)
    {
        HtmlPanel.Text = HtmlCodeBox.Text;
    }

    private void RenderRtfButtonOnClick(object? sender, RoutedEventArgs e)
    {
        if (HtmlCodeBox.Text != null)
        {
            HtmlPanel.Text = RtfToHtmlConverter.Convert(HtmlCodeBox.Text, DefaultEncoding);
        }
    }

    private void RenderSampleFileOnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var sampleFilePath = ((sender as Button)?.DataContext as Sample)?.FilePath
                                 ?? throw new InvalidOperationException();
            using var reader = new StreamReader(
                Assembly
                    .GetExecutingAssembly()
                    .GetManifestResourceStream("HtmlRenderer." + sampleFilePath)
                ?? throw new FileNotFoundException()
            );
            HtmlCodeBox.Text = reader.ReadToEnd();
        }
        catch (Exception exception)
        {
            HtmlCodeBox.Text = "Cannot load the file: " + exception.Message;
        }
    }
}
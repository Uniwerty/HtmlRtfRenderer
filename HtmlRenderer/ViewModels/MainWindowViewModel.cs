using System.Collections.ObjectModel;
using System.IO;
using HtmlRenderer.Models;

namespace HtmlRenderer.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private const string SamplesDirectory = "../../../Samples/";
    private const string HtmlSamplesPrefix = "Samples.Html.";
    private const string RtfSamplesPrefix = "Samples.Rtf.";

    public ObservableCollection<Sample> SamplesList { get; set; }

    public MainWindowViewModel()
    {
        var list = new ObservableCollection<Sample>();
        foreach (var path in Directory.EnumerateFiles(SamplesDirectory + "Html"))
        {
            var sampleFileName = Path.GetFileName(path);
            list.Add(new Sample(sampleFileName, HtmlSamplesPrefix + sampleFileName));
        }

        foreach (var path in Directory.EnumerateFiles(SamplesDirectory + "Rtf"))
        {
            var sampleFileName = Path.GetFileName(path);
            list.Add(new Sample(sampleFileName, RtfSamplesPrefix + sampleFileName));
        }

        SamplesList = list;
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HtmlRenderer.Models;

namespace HtmlRenderer.ViewModels;

public class SamplesListViewModel : ViewModelBase
{
    public ObservableCollection<Sample> SamplesList { get; set; } =
    [
        new Sample("Ivan", "ivan.txt"),
        new Sample("dmitry", "dmitry.html"),
        new Sample("petr", "petr.rtf")
    ];
}
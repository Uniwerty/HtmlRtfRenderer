namespace HtmlRenderer.Models;

public class Sample(string name, string filePath)
{
    public string Name { get; set; } = name;
    public string FilePath { get; } = filePath;
}
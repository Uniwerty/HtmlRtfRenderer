using System.Text;

namespace RtfToHtml;

using Spire.Doc;

public static class RtfToHtmlConverter
{
    public static string Convert(string rtfText, Encoding encoding)
    {
        var document = new Document();
        document.LoadFromStream(new MemoryStream(encoding.GetBytes(rtfText)), FileFormat.Rtf);
        MemoryStream outputStream = new MemoryStream();
        document.SaveToStream(outputStream, FileFormat.Html);
        outputStream.Position = 0;
        return new StreamReader(outputStream).ReadToEnd();
    }
}
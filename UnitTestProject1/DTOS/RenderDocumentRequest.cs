namespace SamplesCollection.DTOS;
{
    public class RenderDocumentRequest
{
    public long correlationID { get; set; }
    public string systemOfOrigin { get; set; }
    public string Account { get; set; }
    public InputXml inputXml { get; set; }
}

public partial class InputXml
{
    public string content { get; set; }
    public string mimetype { get; set; }
    public string name { get; set; }
}

}
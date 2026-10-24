using System.Text.Json;
using System.Xml.Linq;

public class DataParseAdapter : IEmployeeParser
{
    private readonly string xmlData;
    public DataParseAdapter(string xmlData)
    {
        this.xmlData = xmlData;
    }

    public List<EmployeeData> ParseData()
    {
        string jsonData = ConvertXmlToJson(xmlData);
        JsonParser jsonParser = new JsonParser(jsonData);
        return jsonParser.ParseData();
    }
    public string ConvertXmlToJson(string xmlData)
    {
        // Logic to convert XML data to JSON format
        if (!xmlData.TrimStart().StartsWith("<employees>"))
            xmlData = $"<employees>{xmlData}</employees>";

        XDocument doc = XDocument.Parse(xmlData);

        // Build list of objects
        var list = doc.Root.Elements("employee")
            .Select(e => new
            {
                Id = int.Parse(e.Element("Id").Value),
                Name = e.Element("Name").Value,
                Designation = e.Element("Designation").Value
            })
            .ToList();

        return JsonSerializer.Serialize(list);
    }
}
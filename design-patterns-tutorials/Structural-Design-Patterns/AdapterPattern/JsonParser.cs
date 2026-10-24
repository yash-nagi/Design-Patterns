using System.Text.Json;

public class JsonParser : IEmployeeParser
{
    private string data;
    public JsonParser(string data)
    {
        this.data = data;
    }
    public List<EmployeeData> ParseData()
    {
        List<EmployeeData> employees = new List<EmployeeData>();
        // Logic to parse JSON data and populate EmployeeData objects
        using JsonDocument document = JsonDocument.Parse(data);
        foreach (JsonElement element in document.RootElement.EnumerateArray())
        {
            EmployeeData employee = new EmployeeData();
            employee.Id = element.GetProperty("Id").GetInt32();
            employee.Name = element.GetProperty("Name").GetString();
            employee.Designation = element.GetProperty("Designation").GetString();
            employees.Add(employee);
        }
        return employees;
    }
}
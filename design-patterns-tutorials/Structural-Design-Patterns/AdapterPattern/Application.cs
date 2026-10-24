public class Application
{
    public static void DisplayEmployeeDetails()
    {
        //string jsonEmployee = "[{ \"Id\": 1, \"Name\": \"John Doe\", \"Designation\": \"Software Engineer\"}, { \"Id\": 2, \"Name\": \"Jane Smith\", \"Designation\": \"Project Manager\" }]";
        string xml = @"<employees><employee><Id>1001</Id><Name>Rahul</Name><Designation>Engineer</Designation></employee><employee><Id>1002</Id><Name>Yash</Name><Designation>Developer</Designation></employee></employees>";
        //JsonParser jsonParser = new JsonParser(jsonEmployee);
        var xmlToJson = new DataParseAdapter(xml);
        List<EmployeeData> employees = xmlToJson.ParseData();
        foreach (var employee in employees)
        {
            Console.WriteLine($"Employee ID: {employee.Id}, Name: {employee.Name}, Designation: {employee.Designation}");
        }
    }
}
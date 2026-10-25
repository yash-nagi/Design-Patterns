public class AdmissionService : IAdmissionService
{
    public bool VerifyDocuments()
    {
        return true;
    }
    public void CreateStudent()
    {
        Console.WriteLine($"Student has been created successfully.");
        //return student;
    }
}
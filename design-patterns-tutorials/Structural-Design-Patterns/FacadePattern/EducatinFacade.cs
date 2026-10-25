public class EducationFacade
{
    private readonly AdmissionService admission = new AdmissionService();
    private readonly FeeService fees = new FeeService();
    private readonly CourseService courses = new CourseService();
    private readonly LibraryService library = new LibraryService();
    private readonly NotificationService notifier = new NotificationService();

    public bool EnrollStudent()
    {
        if (!admission.VerifyDocuments()) return false;
        admission.CreateStudent();
        if (!fees.CollectFees()) return false;
        courses.GetCourse();
        library.IssusLibraryCard();
        notifier.SendEmailNotification();
        return true;
    }
}
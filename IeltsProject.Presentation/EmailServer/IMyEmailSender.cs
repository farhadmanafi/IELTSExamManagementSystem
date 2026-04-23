namespace IeltsProject.Presentation.EmailServer
{
    public interface IMyEmailSender
    {
        void SendEmail(string email, string subject, string HtmlMessage);
    }
}

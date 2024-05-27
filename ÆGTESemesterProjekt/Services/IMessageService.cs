using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public interface IMessageService
    {
        
        List<Message> GetMessages();
        Task AddMessageAsync(Message message);
        void AddMessage(Message message);
        void UpdateMessage(Message message);
        Message DeleteMessage(int? messageId);
        Message GetMessage(int messageId);
        
    }
}

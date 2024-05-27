using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.MockData;
using Microsoft.EntityFrameworkCore;
using ÆGTESemesterProjekt.EFDbContext;

namespace ÆGTESemesterProjekt.Services
{
    public class MessageService : IMessageService
    {

        private JsonFileService<Message> _jsonFileService;
        private DbGenericService<Message> _genericDbService;
        private List<Message> _message;
        private readonly ProductDbContext _productDbContext;

        public MessageService(JsonFileService<Message> jsonFileService, DbGenericService<Message> genericDbService, ProductDbContext productDbContext)
        {
            //_jsonFileService = jsonFileService;
            _genericDbService = genericDbService;
            _productDbContext = productDbContext;                      
        }

        public MessageService()
        {

        }

        //CRUD starter her
        //-------------------------------------------------
        public async Task AddMessageAsync(Message message)
        {
            _message.Add(message);
            await _genericDbService.AddObjectAsync(message);
        }

        public List<Message> GetMessage() { return _message; }

        public void AddMessage(Message message)
        {
            if (string.IsNullOrEmpty(message.MessageAuthor))
            {
                throw new ArgumentException("MessageAuthor cannot be null or empty");
            }
            _productDbContext.Add(message);
            _genericDbService.SaveObjects(_message);
        }



        public List<Message> GetMessages()
        {
            return _message;
        }
        public void UpdateMessage(Message message)
        {
            if (message != null)
            {
                foreach (Message p in _message)
                {
                    if (p.MessageId == message.MessageId)
                    {
                        p.MessageResponse = message.MessageResponse;
                        p.MessageAnswered = message.MessageAnswered;
                        
                    }
                }
                _genericDbService.SaveObjects(_message);
            }
        }
        
        public Message GetMessage(int messageId)
        {
            foreach (Message message in _message)
            {
                if (messageId == message.MessageId)
                {
                    return message;
                }
            }
            return null;
        }

        public Message DeleteMessage(int? messageId)
        {
            foreach (Message message in _message)
            {
                if (message.MessageId == messageId)
                {
                    _message.Remove(message);
                    _genericDbService.DeleteObjectAsync(message);
                    return message;
                }
            }
            return null;
        }

        //Ny version
        //-----------------------------------------------
        //Gammel version

        //public IEnumerable<Message> GetAllMessages()
        //{
        //    return _productDbContext.Messages.ToList();
        //}

        //public void AddMessage(Message message)
        //{
        //    if (message == null)
        //    {
        //        throw new ArgumentNullException(nameof(message));
        //    }
        //    _productDbContext.Messages.Add(message);
        //    _productDbContext.SaveChanges();
        //}

        //public List<Message> GetMessages() { return _messages; }






        //public void UpdateMessage(Message message)
        //{
        //    if (message != null)
        //    {
        //        foreach (Message i in _messages)
        //        {
        //            if (i.MessageId == message.MessageId)
        //            {
        //                i.MessageTitle = message.MessageTitle;
        //            }
        //        }
        //    }
        //}


    }
}

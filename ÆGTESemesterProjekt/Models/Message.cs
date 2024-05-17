namespace ÆGTESemesterProjekt.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public int RecipientId { get; set; }
        public User Recipient { get; set; }
        public int? ParrentMessageId { get; set; }
        public Message ParrentMessage { get; set; }
        public ICollection<Message> Responses { get; set; }

        public Message(int messageId, string content, DateTime timeStamp, int senderId, User sender, int recipientId, User recipient, int? parrentMessageId, Message parrentMessage, ICollection<Message> responses)
        {
            MessageId = messageId;
            Content = content;
            TimeStamp = timeStamp;
            SenderId = senderId;
            Sender = sender;
            RecipientId = recipientId;
            Recipient = recipient;
            ParrentMessageId = parrentMessageId;
            ParrentMessage = parrentMessage;
            Responses = responses;
        }

        public Message()
        {
        }
    }
}

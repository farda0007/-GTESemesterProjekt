using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ÆGTESemesterProjekt.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        public string MessageTitle { get; set; }        
        public string MessageContent { get; set; }
        public string MessageResponse { get; set; }
        public string MessageAuthor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime MessageDate { get; set; }

        public User Sender { get; set; }
        public int SenderId { get; set; }

        public User Receiver { get; set; }
        public int ReceiverId { get; set; }
        



        public Message()
        {

        }

        public Message(int messageId, string messageTitle, string messageContent, string messageAuthor, DateTime messageDate, int senderId, User sender, int receiverId, User receiver)
        {
            MessageId = messageId;
            MessageTitle = messageTitle;
            MessageContent = messageContent;
            MessageAuthor = messageAuthor;
            MessageDate = messageDate;
            SenderId = senderId;
            Sender = sender;
            ReceiverId = receiverId;
            Receiver = receiver;
        }



        //public Message(int messageId, string title, string messageContent, string messageAuthor, User SenderId, User ReceiverId)
        //{
        //    MessageId = messageId;
        //    MessageTitle = title;
        //    MessageContent = messageContent;
        //    MessageAuthor = messageAuthor;
        //    MessageDate = DateTime.Now;
        //    User = SenderId;
        //    User = ReceiverId;
        //}


    }
}

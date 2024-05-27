using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;
using ÆGTESemesterProjekt.EFDbContext;

namespace ÆGTESemesterProjekt.Models
{
    public class Message
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        [Required(ErrorMessage = "MessageTitle is required")]
        public string MessageTitle { get; set; }
        public string MessageContent { get; set; }

        public int? ParentMessageId { get; set; }
        public bool MessageAnswered { get; set; }
        public string MessageResponse { get; set; }
        [Required(ErrorMessage = "Message author is required.")]
        public string MessageAuthor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime MessageDate { get; set; }

        public User Sender { get; set; }
        public int SenderId { get; set; }
        public User Receiver { get; set; }
        public int ReceiverId { get; set; }

        public Message(int messageId, string messageTitle, string messageContent, int? parentMessageId, bool messageAnswered, string messageResponse, string messageAuthor, DateTime messageDate)//, User sender, User receiver)
        {
            MessageId = messageId;
            MessageTitle = messageTitle;
            MessageContent = messageContent;
            ParentMessageId = parentMessageId;
            MessageAnswered = messageAnswered;
            MessageResponse = messageResponse;
            MessageAuthor = messageAuthor;
            MessageDate = messageDate;
            //Sender = sender;
            //Receiver = receiver;

        }

        public Message()
        {
        }


        
    }
}

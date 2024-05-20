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

        [Display(Name = "Titel")]
        [Required(ErrorMessage = "Opslag skal have en titel")]
        [StringLength(100)]
        public string MessageTitle { get; set; }

        [Display(Name = "Besked")]
        [Required(ErrorMessage = "Besked kan ikke være tom")]
        [StringLength(100)]
        public string MessageContent { get; set; }

        public string MessageAuthor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime MessageDate { get; set; }



        public Message(int messageId, string title, string messageContent, string messageAuthor)
        {
            MessageId = messageId;
            MessageTitle = title;
            MessageContent = messageContent;
            MessageAuthor = messageAuthor;
            MessageDate = DateTime.Now;
        }

        public Message()
        {
        }
    }
}

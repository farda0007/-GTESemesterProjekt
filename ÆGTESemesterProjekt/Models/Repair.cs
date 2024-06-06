using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ÆGTESemesterProjekt.Models
{
    public class Repair
    {
        [Display(Name = "Repair ID")]
        [Required(ErrorMessage = "Der skal angives et ID til produktet")]
        [Range(typeof(int), minimum: "0", maximum: "10000", ErrorMessage = "Id skal være mellem {1} og {2}")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseId { get; set; }

        [Display(Name = "Oprettelses Dato")]
        public DateTime SubDate { get; set; }

        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        //[Display(Name = "Produkt til reperation")]
        public string RepProduct { get; set; }

        [Display(Name = "Reperations Billede")]
        public string Image { get; set; }
        public Status RepairStatus { get; set; } 
        public double RepPrice { get; set; }
        public DateTime EstDate { get; set; }

        public enum Status
        {
            Venter,
            Færdig,
            Igangværende
        }

        public Repair()
        {
        }

        public Repair(int caseId, DateTime subDate, string description, string repProduct, string image, Status repStatus, double repPrice, DateTime estDate)
        {
            RepairStatus = repStatus;
            CaseId = caseId;
            SubDate = subDate;
            Description = description;
            RepProduct = repProduct;
            Image = image;
            RepPrice = repPrice;
            EstDate = estDate;
        }
    }

}

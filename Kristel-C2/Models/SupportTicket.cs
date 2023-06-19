using System.ComponentModel.DataAnnotations;

namespace Kristel_C2.Models
{
    public class SupportTicket
    {
        [Required (ErrorMessage ="Debe ingresar un numero de Ticket")]
        public int TicketNumber { get; set; }
        [Required(ErrorMessage = "Error, debe ingresar un numero")]
        [MaxLength(25)]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Debe agregar una descripcion")]
        [MaxLength(125)]
        public string Description { get; set; }
        public bool IsOpen { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ResolvedDate { get; set; }
        public SupportTicket()
        {
            TicketNumber=new Random().Next(1,600);
            IsOpen=true;
            CreatedDate = DateTime.Now;
            ResolvedDate = DateTime.MinValue;

        }
        public SupportTicket(int ticketNumber, string subject, string description)
        {
            TicketNumber = ticketNumber;
            Subject = subject;
            Description = description;
            IsOpen = true;
            CreatedDate = DateTime.Now;
            ResolvedDate = DateTime.MinValue;
        }
        public void MarkAsResolved()
        {
            IsOpen = false;
            ResolvedDate = DateTime.Now;
        }
    }
}

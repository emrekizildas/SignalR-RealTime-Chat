using System;
using System.ComponentModel.DataAnnotations;

namespace SignalRExample.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(144)]
        public string MessageText { get; set; }
        public DateTime MesssageDate { get; set; }
    }
}

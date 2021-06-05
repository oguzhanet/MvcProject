using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcProject.Entities.Concrete
{
    public class Message : IEntity
    {
        [Key]
        public int MessageId { get; set; }
        [StringLength(50)]
        public string SenderMail { get; set; }
        [StringLength(50)]
        public string ReceiverMail { get; set; }
        [StringLength(100)]
        public string Subject { get; set; }
        [AllowHtml]
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public bool IsDraft { get; set; }
    }
}

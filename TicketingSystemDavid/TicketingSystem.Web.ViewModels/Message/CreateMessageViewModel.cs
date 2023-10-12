using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Common;
using TicketingSystem.Web.ViewModels.Message.Enums;

namespace TicketingSystem.Web.ViewModels.Message
{
    public class CreateMessageViewModel
    {
        public int Id { get; set; }

        [Required]
        public MessageState State { get; set; }

        public string Creator { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.MessageContentMaxLen, MinimumLength = DataConstants.MessageContentMinLen)]
        public string Content { get; set; } = null!;

        public int TicketId { get; set; }
    }
}

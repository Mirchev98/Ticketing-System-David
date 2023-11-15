using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Services.Models.Message
{
    public class DownloadFilesModelServices
    {
        public int Id { get; set; }

        public IFormFile File { get; set; }

        public string? FileName { get; set; }

        public byte[]? FileContent { get; set; }

        public string? ContentType { get; set; }
    }
}

﻿using Microsoft.AspNetCore.Http;

namespace TicketingSystem.Services.Models.Message
{
    public class DownloadFilesModelService
    {
        public int Id { get; set; }

        public string? FileName { get; set; }

        public byte[]? FileContent { get; set; }

        public string? ContentType { get; set; }
    }
}

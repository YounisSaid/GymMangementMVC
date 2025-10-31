﻿using Microsoft.AspNetCore.Http;
namespace GymMangementPLL.Services.AttachmentService
{
    public interface IAttachmentService
    {
        string? Upload(string folderName, IFormFile file);
        bool Delete(string fileName, string folderName);
    }
}

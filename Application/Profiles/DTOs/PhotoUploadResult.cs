using System;

namespace Application.Profiles.DTOs;

public class PhotoUploadResult
{
    public required string PublicId { get; set; } = string.Empty;
    public required string Url { get; set; } = string.Empty;
}

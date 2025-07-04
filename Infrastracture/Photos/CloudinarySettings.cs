using System;

namespace Infrastracture.Photos;

public class CloudinarySettings
{
    public required string CloudName { get; set; } = string.Empty;
    public required string ApiKey { get; set; } = string.Empty;
    public required string ApiSecret { get; set; } = string.Empty;
}

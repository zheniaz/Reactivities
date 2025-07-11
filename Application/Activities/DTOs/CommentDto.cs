using System;

namespace Application.Activities.DTOs;

public class CommentDto
{
    public required string Id { get; set; }
    public required string Body { get; set; }
    public DateTime CreatedAt { get; set; }
    public required string UserId { get; set; } = string.Empty;
    public required string DisplayName { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
}

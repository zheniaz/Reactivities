using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Activities.DTOs;

public class EditActivityDto : BaseActivityDto
{
    public string Id { get; set; } = string.Empty;
}
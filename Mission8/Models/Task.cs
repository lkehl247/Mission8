using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission8.Models;

public class Task
{
    [Key]
    public int TaskId { get; set; }

    [Required]
    public string TaskName { get; set; }

    public DateTime? DueDate { get; set; }

    [Required]
    public int Quadrant { get; set; } // 1, 2, 3, or 4

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

    public bool Completed { get; set; }
}
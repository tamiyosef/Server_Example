using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server_Example.Models;

public partial class Teacher
{
    [Key]
    public int TeacherId { get; set; }

    [StringLength(100)]
    public string? TeacherName { get; set; }

    [InverseProperty("Teacher")]
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}

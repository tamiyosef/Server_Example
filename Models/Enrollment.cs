using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server_Example.Models;

public partial class Enrollment
{
    [Key]
    public int EnrollmentId { get; set; }

    public int? StudentId { get; set; }

    public int? SubjectId { get; set; }

    public DateOnly? EnrollmentDate { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Grade { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("Enrollments")]
    public virtual Student? Student { get; set; }

    [ForeignKey("SubjectId")]
    [InverseProperty("Enrollments")]
    public virtual Subject? Subject { get; set; }
}

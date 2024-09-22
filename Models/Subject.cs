using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server_Example.Models;

public partial class Subject
{
    [Key]
    public int SubjectId { get; set; }

    [StringLength(100)]
    public string? SubjectName { get; set; }

    public int? TeacherId { get; set; }

    [InverseProperty("Subject")]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    [InverseProperty("Subject")]
    public virtual ICollection<SubjectClassroomAssignment> SubjectClassroomAssignments { get; set; } = new List<SubjectClassroomAssignment>();

    [ForeignKey("TeacherId")]
    [InverseProperty("Subjects")]
    public virtual Teacher? Teacher { get; set; }
}

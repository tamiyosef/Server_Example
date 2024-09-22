using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server_Example.Models;

public partial class Classroom
{
    [Key]
    public int ClassroomId { get; set; }

    [StringLength(100)]
    public string? ClassroomName { get; set; }

    public int? Capacity { get; set; }

    [InverseProperty("Classroom")]
    public virtual ICollection<SubjectClassroomAssignment> SubjectClassroomAssignments { get; set; } = new List<SubjectClassroomAssignment>();
}

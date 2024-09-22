using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server_Example.Models;

public partial class SubjectClassroomAssignment
{
    [Key]
    public int AssignmentId { get; set; }

    public int? SubjectId { get; set; }

    public int? ClassroomId { get; set; }

    [StringLength(100)]
    public string? Schedule { get; set; }

    [ForeignKey("ClassroomId")]
    [InverseProperty("SubjectClassroomAssignments")]
    public virtual Classroom? Classroom { get; set; }

    [ForeignKey("SubjectId")]
    [InverseProperty("SubjectClassroomAssignments")]
    public virtual Subject? Subject { get; set; }
}

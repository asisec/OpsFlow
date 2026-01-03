using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpsFlow.Core.Models;

[Table("departments")]
public class Department
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("department_name")]
    [MaxLength(100)]
    public string DepartmentName { get; set; } = string.Empty;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}


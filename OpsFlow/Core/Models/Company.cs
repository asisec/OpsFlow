using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpsFlow.Core.Models;

[Table("companies")]
public class Company
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("company_name")]
    [MaxLength(255)]
    public string CompanyName { get; set; } = string.Empty;

    [Column("tax_number")]
    [MaxLength(50)]
    public string? TaxNumber { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("phone")]
    [MaxLength(20)]
    public string? Phone { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
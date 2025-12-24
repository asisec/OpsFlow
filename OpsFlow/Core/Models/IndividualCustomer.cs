using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpsFlow.Core.Models;

[Table("individual_customers")]
public class IndividualCustomer
{
    [Key]
    [ForeignKey(nameof(User))]
    [Column("id")]
    public int Id { get; set; }

    [Column("city")]
    [MaxLength(100)]
    public string? City { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    public virtual User User { get; set; } = null!;
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KodalibApi.Data.Models.ActorsTables;

[Table("role")]
public class Role
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    public List<RolePerson> Persons { get; set; }
}
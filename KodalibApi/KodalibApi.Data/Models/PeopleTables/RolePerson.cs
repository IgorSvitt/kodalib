using System.ComponentModel.DataAnnotations.Schema;

namespace KodalibApi.Data.Models.PeopleTables;

[Table("role_person")]
public class RolePerson
{
    [Column("person_id")]
    public int PersonId { get; set; }

    [Column("role_id")]
    public int RoleId { get; set; }

    public Person Person { get; set; }

    public Role Role { get; set; }
}
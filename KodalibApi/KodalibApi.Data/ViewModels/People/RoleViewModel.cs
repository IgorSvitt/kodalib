using KodalibApi.Data.ViewModels.Actor;

namespace KodalibApi.Data.ViewModels.People;

public class RoleViewModel
{
    public int? Id { get; set; }
    
    public string? Name { get; set; }
    
    public List<PersonIdAndNameViewModel>? PersonInfo { get; set; }
}
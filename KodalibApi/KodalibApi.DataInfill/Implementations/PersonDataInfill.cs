using IMDbApiLib;
using Kodalib.Service.Interfaces;
using KodalibApi.Data.ViewModels.Actor;
using KodalibApi.DataInfill.Interfaces;
using KodalibApi.Interfaces.PeopleInterface;
using TMDbLib.Client;
using TMDbLib.Objects.Find;

namespace KodalibApi.DataInfill.Implementations;

public class PersonDataInfill: IPersonDataInfill
{

    private readonly IPersonService _person;

    public PersonDataInfill(IPersonService person)
    {
        _person = person;
    }
    
    public void Create(int id)
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        var apiLib = new ApiLib("k_q0ldd7ir");


        for (int id = 444; id < 544; id++)
        {
            var personId = _person.GetPerson(id).Data;
            if (personId != null)
            {
                var data = apiLib.NameAsync(personId.ImdbId);
                var person = new PersonViewModel()
                {
                    Name = data.Result.Name,
                    ImdbId = data.Result.Id,
                    Height = data.Result.Height,
                    Image = data.Result.Image,
                    Role = data.Result.Role.Split(", ").ToList(),
                    BirthDate = data.Result.BirthDate,
                    DeathDate = data.Result.DeathDate,
                    Summary = data.Result.Summary,
                };

                _person.UpdatePerson(personId.Id, person);
            }
            
        }
    }
}
using Inheritance.Entities;

namespace Inheritance.Dtos;

public class PersonDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public PersonTypeEnum TypeEnum { get; set; }
    public DateTime Birthdate { get; set; }
    public string Description { get; set; } = string.Empty;

    public PersonDto(Person person)
    {
        Id = person.Id;
        Name = person.Name;
        TypeEnum = person.TypeEnum;

        if (person.GetType() == typeof(NaturalPerson))
        {
            Birthdate = (person as NaturalPerson)!.Birthdate;
        }
        else if (person.GetType() == typeof(JuridicalPerson))
        {
            Description = (person as JuridicalPerson)!.Description;
        }
    }

}

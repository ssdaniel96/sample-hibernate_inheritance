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

        if (person is NaturalPerson @naturalPerson)
        {
            Birthdate = naturalPerson.Birthdate;
        }
        else if (person is JuridicalPerson @juridicalPerson)
        {
            Description = juridicalPerson.Description;
        }
    }

}

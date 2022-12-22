namespace Inheritance.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public PersonTypeEnum TypeEnum { get; set; }

        // navigations
        //public DateOnly? BirthDate { get; set; }
        //public string? Description { get; set; }
        //public NaturalPerson? NaturalPerson { get; set; }
        //public JuridicalPerson? JuridicalPerson { get; set; }
    }
}

namespace BlazorDemoPOC.Models.Repositories
{
    public interface IPersonRepository: IRepository<Person>
    {
        public Task<List<Person>> GetAllPeople();
        public Task<Person?> GetPerson();
        public  Task<bool> CreatePerson(Person person);
    }
}

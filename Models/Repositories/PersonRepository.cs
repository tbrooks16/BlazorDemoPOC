using BlazorDemoPOC.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemoPOC.Models.Repositories
{
    public class PersonRepository: Repository<Person>, IPersonRepository
    {
        private readonly ApplicationDbContext _db;

        public PersonRepository(ApplicationDbContext db): base(db){
            _db = db;
        }

        public async Task<List<Person>> GetAllPeople()
        {
            return await _db.Person.ToListAsync();
        }

        public async Task<Person?> GetPerson()
        {
            return await _db.Person.FirstOrDefaultAsync();
        }

        public async Task<bool> CreatePerson(Person person){
            try{
                await _db.Person.AddAsync(person);
                await _db.SaveChangesAsync();
                return true;
            }catch(Exception ex){
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}

using DirectoryApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DirectoryApp.Models
{
    public class SQLiteRepository : IDataRepository<Person>
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private ObservableCollection<Person> people;

        public SQLiteRepository()
        {
            Initialize();
        }

        public async void Initialize()
        {
            #region IfWeWantAddDataInsideDb
            //if (!_db.People.Any())
            //{
            //    _db.Database.Migrate();
            //    _db.People.Add(new Person { FirstName="Oğulcan",LastName="TURAN",Email = "ismetogulcanturan@gmail.com",Job="-",PhoneNumber="+90000000000",AddedDate= DateTime.Now });
            //    await _db.SaveChangesAsync();
            //}
            //else
            //{
            ////await LoadAsync();
            //}
            #endregion
            await LoadAsync();
        }

        public async Task<ObservableCollection<Person>> LoadAsync()
        {   //With this method we can get interact with view also. Instant data will be transfer

            IList<Person> personFromDb = await _db.People.ToListAsync();
            people = new ObservableCollection<Person>(personFromDb);
            return people;
        }

        public async Task AddAsync(Person person)
        {
            await _db.People.AddAsync(person);
            await _db.SaveChangesAsync();
            people.Add(person);
        }

        public async Task RemoveAsync(Person person)
        {
            _db.People.Remove(person);
            await _db.SaveChangesAsync();
            people.Remove(person);
        }
        public async Task UpdateAsync(Person person)
        {
            var personFromDb = await _db.FindAsync<Person>(new object[] { person.Id }); // Currently EF is tracking changes.

            personFromDb.FirstName = person.FirstName;
            personFromDb.LastName = person.LastName;
            personFromDb.Description = person.Description;
            personFromDb.Email = person.Email;
            personFromDb.PhoneNumber = person.PhoneNumber;

            _db.Entry(person).State = EntityState.Modified;
            _db.People.Update(personFromDb);
            await _db.SaveChangesAsync();
        }
        public async Task RemoveAllAsync()
        {
            await _db.People.ForEachAsync(x => _db.People.Remove(x));
            await _db.SaveChangesAsync();
            people.Clear();
        }
    }
}
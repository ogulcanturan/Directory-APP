using DirectoryAPP.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryAPP.Models
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
            //await Load();
            //}
            #endregion
            await Load();
            //if we dont just await Load(); is enough;
        }

        public async Task<ObservableCollection<Person>> Load()
        {   //With this method we can get interact with view also. Instant data will be transfer

            IList<Person> personFromDb = await _db.People.ToListAsync();
            people = new ObservableCollection<Person>(personFromDb);
            return people;

        }

        public Task Add(Person person)
        {
            _db.People.Add(person);
            people.Add(person);
            return _db.SaveChangesAsync();
        }

        public Task Remove(Person person)
        {
            _db.People.Remove(person);
            people.Remove(person);
            return _db.SaveChangesAsync();
        }
        public Task Update(Person person)
        {
            _db.People.Update(person);
            return _db.SaveChangesAsync();
        }
        public Task RemoveAll()
        {
            foreach (var people in _db.People)
                _db.People.Remove(people);
            people.Clear();
            return _db.SaveChangesAsync();
        }
    }
}

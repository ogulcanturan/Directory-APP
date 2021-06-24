using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Text;

namespace DirectoryApp.Models
{
    public class PersonVM : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IDataRepository<Person> _data;

        public PersonVM(IDataRepository<Person> data)
        {
            _data = data;
        }

        private void RaisePropertyChanged([CallerMemberName]string fieldName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(fieldName));
        }

        public bool TotalPeople
        {
            get
            {
                return People.Count > 0;
            }
            set
            {
                if(value!= TotalPeople)
                {
                    TotalPeople = value;
                    RaisePropertyChanged();
                }
            }
        }

        private Person selectedPerson;

        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                if (value != selectedPerson)
                {
                    selectedPerson = value;
                    RaisePropertyChanged();
                }
            }
        }

        public async void Initialize()
        {
            People = await _data.LoadAsync();
        }

        private ObservableCollection<Person> people;
        public ObservableCollection<Person> People
        {
            get { return people; }
            set
            {
                people = value;
                RaisePropertyChanged();
            }
        }

        internal async Task AddPersonAsync(Person person)
        {
            await _data.AddAsync(person);
        }
        internal async Task RemovePersonAsync(Person person)
        {
            await _data.RemoveAsync(person);
        }
        internal async Task UpdateAsync(Person person)
        {
            await _data.UpdateAsync(person);
        }
        internal async Task RemoveAllPersonAsync()
        {
            await _data.RemoveAllAsync();
        }

    }
}
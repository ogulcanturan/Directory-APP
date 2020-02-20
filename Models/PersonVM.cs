using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DirectoryAPP.Models
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
            People = await _data.Load();
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

        internal void AddPerson(Person person)
        {
            _data.Add(person);
        }
        internal void RemovePerson(Person person)
        {
            _data.Remove(person);
        }
        internal void Update(Person person)
        {
            _data.Update(person);
        }
        internal void RemoveAllPerson()
        {
            _data.RemoveAll();
        }

    }
}

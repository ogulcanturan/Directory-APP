using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryAPP.Models
{
    public interface IDataRepository<T> 
    {
        Task Add(T person);
        Task Remove(T person);
        Task Update(T person);
        Task RemoveAll();
        Task<ObservableCollection<T>> Load();
    }
}

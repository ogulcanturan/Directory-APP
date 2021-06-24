using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Models
{
    public interface IDataRepository<T> 
    {
        Task AddAsync(T person);
        Task RemoveAsync(T person);
        Task UpdateAsync(T person);
        Task RemoveAllAsync();
        Task<ObservableCollection<T>> LoadAsync();
    }
}

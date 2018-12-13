using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rescheduler.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

        //interface lives in shared project. In Xamarin it lives in different projects
        //void etc(); (it will give you error)
    }
}

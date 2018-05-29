using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemplateMvvmLight.Constants;

namespace TemplateMvvmLight.IServices
{
    public interface IStorageServices
    {
        T GetObject<T>(StorageKey key);
        Task<bool> SetObject(StorageKey key, dynamic obj);
    }
}

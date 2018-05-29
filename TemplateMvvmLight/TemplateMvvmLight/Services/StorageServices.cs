using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemplateMvvmLight.Constants;
using TemplateMvvmLight.IServices;
using Xamarin.Forms;

namespace TemplateMvvmLight.Services
{
    class StorageServices : IStorageServices
    {
        public T GetObject<T>(StorageKey key)
        {
            try
            {
                if (Application.Current.Properties.ContainsKey(key.ToString()))
                {
                    T obj = JsonConvert.DeserializeObject<T>(Application.Current.Properties[key.ToString()].ToString());
                    return obj;
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default(T);
            }
        }

        public async Task<bool> SetObject(StorageKey key, Object obj)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj);
                Application.Current.Properties[key.ToString()] = json;
                await Application.Current.SavePropertiesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}

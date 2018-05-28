using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateMvvmLight.IServices;

namespace TemplateMvvmLight.Services
{
    class ConnectivityServices : IConnectivityServices
    {
        public bool HasWebConnection()
        {
            if (!CrossConnectivity.IsSupported)
            {
                return true;
            }

            return CrossConnectivity.Current.IsConnected;
        }
    }
}

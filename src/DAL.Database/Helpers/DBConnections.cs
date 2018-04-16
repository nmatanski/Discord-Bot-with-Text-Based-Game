using CommonHelpers.Helpers;
using System;

namespace DAL.Database
{
    internal class DBConnections
    {
        internal static string GetAppHarborConnection()
        {
            return SensitiveData.GetConnectionString(); ///TODO: AppHarbor Connection String
        }

        internal static string GetAzureConnection()
        {
            return ""; ///TODO: Azure Connection String
        }
    }
}
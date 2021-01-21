using API_Tickets.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tickets.Builders
{
    public class B_DBManager : I_DBManager
    {
        public IConfiguration Config { get; }
        public B_DBManager(IConfiguration config)
        {
            Config = config;
        }
        public string BuildConnectionString()
        {
            return String.Format("Server = {0}; Database = {1}; User Id = {2}; Password = {3}; MultipleActiveResultSets = true", Config.GetSection("EntornoDev:Source").Value.ToString(), Config.GetSection("EntornoDev:DataBase").Value.ToString(), Config.GetSection("EntornoDev:User").Value.ToString(), Config.GetSection("EntornoDev:Password").Value.ToString());
        }
    }
}

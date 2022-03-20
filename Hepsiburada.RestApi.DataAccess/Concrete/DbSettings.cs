using Hepsiburada.RestApi.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.RestApi.DataAccess.Concrete
{
    public class DbSettings : IDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ProductCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
    }
}

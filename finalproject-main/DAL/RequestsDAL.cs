using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RequestsDAL
    {
        HelpForElderlyEntities1 db=new HelpForElderlyEntities1();
        public List<Requests> GetRequests()
        {
           return db.Requests.ToList();
        }
        public List<ArrangedRequests> GetArrangedRequests()
        {
            return db.ArrangedRequests.ToList();    
        }
    }
}

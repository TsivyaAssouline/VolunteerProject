using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AskingForHelpDAL
    {
        HelpForElderlyEntities1 db=new HelpForElderlyEntities1();
        public List<AskingForHelp> GetAskingForHelp()
        {
            return db.AskingForHelp.ToList();
        }
    }
}

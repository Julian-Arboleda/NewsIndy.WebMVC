using NewsIndy.Models;
using NewsIndy.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsIndy.Services
{
   public class OrgService
    {
        public IEnumerable<OrgListItem> GetOrganizationList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Organization.Select
            }
        }
    }
}

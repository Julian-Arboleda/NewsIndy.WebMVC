using NewsIndy.Data;
using NewsIndy.Models;
using NewsIndy.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsIndy.Services
{
    public class OrganizationService
    {
        public IEnumerable<OrganizationListItem> GetOrganizationList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Organizations.Select(o => new OrganizationListItem
                {
                    OrgId = o.OrgId,
                    Name = o.Name,
                    Description = o.Description,
                    BoroughId = o.BoroughId
                });

                return query.ToArray();
            }
        }

        public IEnumerable<OrganizationListItem> GetOrganizations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx
                   .Organizations
                   .Select(
                       e =>
                           new OrganizationListItem
                           {
                               BoroughId = e.BoroughId,
                               Name = e.Name,
                               Description = e.Description,

                               OrgId = e.OrgId
                           }

                       ).ToList();

                return query;


            }
        }


        public OrganizationDetail GetOrganizationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Organizations
                        .Single(e => e.OrgId == id);
                return
                    new OrganizationDetail
                    {
                        OrgId = entity.OrgId,
                        Name = entity.Name,
                        Description = entity.Description,
                        BoroughId = entity.BoroughId
                    };
            }
        }

        public bool CreateOrganization(OrganizationCreate model)
        {
            var entity =
                new Organization()
                {
                    Name = model.Name,
                    Description = model.Description,
                    BoroughId = model.BoroughId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Organizations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateOrganization(OrganizationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                             .Organizations
                             .Single(e => e.OrgId == model.OrgId);

                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.BoroughId = model.BoroughId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteOrganization(int OrgId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Organizations
                        .Single(e => e.OrgId == OrgId);

                ctx.Organizations.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }
}

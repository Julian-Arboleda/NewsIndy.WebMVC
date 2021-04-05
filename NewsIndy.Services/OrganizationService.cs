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
                    IsFoodBank = o.IsFoodBank,
                    IsShelter = o.IsShelter,
                    BoroughId = o.BoroughId
                });

                return query.ToArray();
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
                        IsFoodBank = entity.IsFoodBank,
                        IsShelter = entity.IsShelter,
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
                    IsFoodBank = model.IsFoodBank,
                    IsShelter = model.IsShelter,
                    BoroughId = model.BoroughId,
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
                entity.IsFoodBank = model.IsFoodBank;
                entity.IsShelter = model.IsShelter;
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

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
    public class VolunteerService
    {
        public IEnumerable<VolunteerListItem> GetVolunteerList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Volunteers.Select(o => new VolunteerListItem
                {
                    OrgId = o.OrgId,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                });

                return query.ToArray();
            }
        }

        public VolunteerDetail GetVolunteerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Volunteers
                        .Single(e => e.VolunteerId == id);
                return
                    new VolunteerDetail
                    {
                        OrgId = entity.OrgId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName
                    };
            }
        }

        public bool CreateVolunteer(VolunteerCreate model)
        {
            var entity =
                new Volunteer()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    OrgId = model.OrgId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Volunteers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateVolunteer(VolunteerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                             .Volunteers
                             .Single(e => e.VolunteerId == model.VolunteerId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.OrgId = model.OrgId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteVolunteer(int VolunteerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Volunteers
                        .Single(e => e.VolunteerId == VolunteerId);

                ctx.Volunteers.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }
}
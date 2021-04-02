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
    public class BoroughService
    {
        private readonly Guid _userId; 

        public BoroughService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBorough(BoroughCreate model)
        {
            var entity =
                new Borough()
                {
                    CreatorId = _userId,
                    Name = model.Name,
                    Direction = model.Direction
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Boroughs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BoroughListItem> GetBoroughs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Boroughs
                    .Where(e => e.CreatorId == _userId)
                    .Select(
                        e =>
                            new BoroughListItem
                            {
                                BoroughId = e.BoroughId,
                                Name = e.Name,
                                Direction = e.Direction
                            }

                        );

                return query.ToArray();
            }
        }

        public BoroughDetail GetBoroughById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Boroughs
                        .Single(e => e.BoroughId == id && e.CreatorId == _userId);
                return
                    new BoroughDetail
                    {
                        BoroughId = entity.BoroughId,
                        Name = entity.Name,
                        Direction = entity.Direction
                    };
            }
        }

        public bool UpdateBorough(BoroughEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                             .Boroughs
                             .Single(e => e.BoroughId == model.BoroughId && e.CreatorId == _userId);

                entity.Name = model.Name;
                entity.Direction = model.Direction;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

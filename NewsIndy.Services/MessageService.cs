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
    public class MessageService
    {
        private readonly Guid _userId;

        public MessageService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateMessage(MessageCreate model)
        {
            var entity =
                new Message()
                {
                    CreatorId = _userId,
                    Subject = model.Subject,
                    Content = model.Content,
                    DateCreated = DateTime.Now, 
                   // ModifiedDateCreated = model.ModifiedDateCreated
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Messages.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MessageListItem> GetMessageList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Messages
                    .Where(e => e.CreatorId == _userId)
                    .Select(
                        e =>
                            new MessageListItem
                            {
                                MessageId = e.MessageId,
                                Subject = e.Subject,
                                Content = e.Content,
                                DateCreated = e.DateCreated,
                                // ModifiedDateCreated = e.ModifiedDateCreated
                            }

                        );

                return query.ToArray();
            }
        }

        public IEnumerable<MessageListItem> GetMessages()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx
                   .Messages
                   .Select(
                       e =>
                           new MessageListItem
                           {
                               MessageId = e.MessageId,
                               Subject = e.Subject,
                               Content = e.Content,
                               DateCreated = e.DateCreated,
                              // ModifiedDateCreated = e.ModifiedDateCreated
                           }

                       ).ToList();

                return query;


            }
        }

        public MessageDetail GetMessageById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Messages
                        .Single(e => e.MessageId == id);
                return
                    new MessageDetail
                    {
                        MessageId = entity.MessageId,
                        Content = entity.Content,
                        Subject = entity.Subject,
                    };
            }
        }

        public bool UpdateMessage(MessageEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                             .Messages
                             .Single(e => e.MessageId == model.MessageId && e.CreatorId == _userId);

                entity.Content = model.Content;
                entity.Subject = model.Subject;
                entity.DateCreated = model.DateCreated;
               // entity.ModifiedDateCreated = model.ModifiedDateCreated;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMessage(int MessageId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Messages
                        .Single(e => e.MessageId == MessageId && e.CreatorId == _userId);

                ctx.Messages.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }


    }
}
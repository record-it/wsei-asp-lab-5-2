using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Models
{
    public interface ICRUDBlogItemRepository
    {
        BlogItem Save(BlogItem item);

        void Delete(int id);

        BlogItem Update(BlogItem item);

        BlogItem FindById(int id);

        IList<BlogItem> FindAll();

        IList<BlogItem> FindPage(int page, int size);

        void addTagToBlogItem(int blogItemId, int tagId);
    }

    public class EFBlogItemRepository : ICRUDBlogItemRepository
    {
        private ApplicationDbContext context;

        public EFBlogItemRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            context.BlogItems.Remove(context.BlogItems.Find(id));
            context.SaveChanges();
        }

        public IList<BlogItem> FindAll()
        {
            return context.BlogItems.ToList();
        }

        public BlogItem FindById(int id)
        {
            context.Find(typeof(BlogItem), id);
            return context.BlogItems.Find(id);
        }

        public BlogItem Update(BlogItem item)
        {
            try
            {
                var entryEntity = context.BlogItems.Update(item);
                context.SaveChanges();
                return entryEntity.Entity;
            } catch(Exception e)
            {
                return null;
            }
        }
        public IList<BlogItem> FindPage(int page, int size)
        {
            return (from item in context.BlogItems orderby item.CreationTimestamp select item)
                .Skip(page * size)
                .Take(size)
              
                .ToList();
        }
        public void addTagToBlogItem(int blogItemId, int tagId)
        {
            var item = context.BlogItems.Find(blogItemId);
            var tag = context.Tags.Find(tagId);
            item.Tags.Add(tag);
            Update(item);
        }

        public BlogItem Save(BlogItem item)
        {
            var entryEntity = context.BlogItems.Add(item);
            context.SaveChanges();
            return entryEntity.Entity;
        }

   
    }
}

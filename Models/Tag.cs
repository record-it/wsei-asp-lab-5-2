using System.Collections;
using System.Collections.Generic;

namespace Lab_5_2.Models
{
    public class Tag
    {
        public Tag()
        {
            BlogItems = new HashSet<BlogItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BlogItem> BlogItems { get; set; }
    }
}
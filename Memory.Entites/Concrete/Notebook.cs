using Memory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Entites.Concrete
{
    public class Notebook : IEntity
    {
        public Notebook() 
        {
        UpdateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int UserId { get; set; }

        public int CityId { get; set; }
        private DateTime UpdateDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }

        public virtual City City { get; set; }

        public virtual AppIdentityUser User { get; set;}
    }
}

using Memory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Entites.Concrete.Dtos
{
    public class CityDto : IDto
    {
         public int Id { get; set; }
         public int CityId { get; set; }
         public string Title { get; set; }
         public string Content { get; set; }
       
    }
}

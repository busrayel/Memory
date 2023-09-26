using Memory.Core.DataAccess.EntityFramework;
using Memory.DataAccess.Abstract;
using Memory.DataAccess.Concrete.EntityFramework.Context;
using Memory.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.DataAccess.Concrete.EntityFramework
{
    public class CityDal :RepositoryBase<City> ,ICityDal
    {
        public CityDal(MemoryContext context) : base(context)
        {
            
        }
    }
}

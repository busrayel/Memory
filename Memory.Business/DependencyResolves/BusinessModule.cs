using Autofac;
using Memory.Business.Abstract;
using Memory.Business.Concrete;
using Memory.DataAccess.Abstract;
using Memory.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Business.DependencyResolves
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CityManager>().As<ICityService>();
            builder.RegisterType<NoteBookManager>().As<INoteBookService>();

            builder.RegisterType<NotebookDal>().As<INotebookDal>();
            builder.RegisterType<CityDal>().As<ICityDal>();
            base.Load(builder);
        }
    }
}

using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using SnappetChallenge.Repository.Implementations;
using SnappetChallenge.Repository.Interfaces;

namespace SnappetChallenge
{
    public static class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            /*
            var executingAssembly = Assembly.GetExecutingAssembly();
            var assemblyTypes = executingAssembly.DefinedTypes.ToList();

            var interfaces = assemblyTypes.Where(type => type.IsAbstract && !type.IsClass).ToList();

            var dependencies = (
                    from @interface in interfaces
                    let @implementation =
                    assemblyTypes.FirstOrDefault(
                        domainType => @interface.IsAssignableFrom(domainType) && !(domainType == @interface))
                    where @implementation != null && !@implementation.IsAbstract
                    select new {Interface = @interface.AsType(), Implementation = @implementation.AsType()})
                .ToList();

             dependencies.ForEach(d => builder.RegisterType(d.Interface).As(d.Implementation));
             */

            //builder.RegisterType<DataRepository>().As<IDataRepository>();
            builder.RegisterType(typeof(DataRepository)).As(typeof(IDataRepository));

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}


 

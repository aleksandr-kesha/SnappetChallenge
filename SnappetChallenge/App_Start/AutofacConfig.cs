using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace SnappetChallenge
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //builder.RegisterType<BookRepository>().As<IRepository>();

            var assemblies = Assembly.GetExecutingAssembly().DefinedTypes.ToList();

            var implementations = assemblies.Where(ia => ia.IsClass).ToList();
            var interfaces = assemblies.Where(ia => ia.IsInterface).ToList();

            var dependencies =(
                from @interface in interfaces
                let @implementation = implementations.FirstOrDefault(domainType => @interface.IsAssignableFrom(domainType) && !(domainType == @interface))

                /*
                
                 */
                //.FirstOrDefault(imp => imp.ImplementedInterfaces.Select(ii => ii.Name).ToList().Contains(@interface.Name))
                where @implementation != null && !@implementation.IsAbstract
                select new { Interface = @interface.AsType(), Implementation = @implementation.AsType() }).ToList();

            dependencies.ForEach(d => builder.RegisterType(d.Interface).As(d.Implementation));

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}


 

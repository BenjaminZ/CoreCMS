using CoreCMS.WebApi.Types;
using GraphQL;
using GraphQL.Types;

namespace CoreCMS.WebApi
{
    public class CMSSchema : Schema
    {
        public CMSSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<CMSQuery>();
        }
    }
}
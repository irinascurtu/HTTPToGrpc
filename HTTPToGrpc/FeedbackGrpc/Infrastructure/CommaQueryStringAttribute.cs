using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FeedbackApi.Infrastructure
{

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class CommaQueryStringAttribute : Attribute, IResourceFilter
    {
        private readonly SeparatedQueryStringValueProviderFactory factory;

        public CommaQueryStringAttribute()
            : this(",")
        {
        }

        public CommaQueryStringAttribute(string separator)
        {
            factory = new SeparatedQueryStringValueProviderFactory(separator);
        }

        public CommaQueryStringAttribute(string key, string separator)
        {
            factory = new SeparatedQueryStringValueProviderFactory(key, separator);
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // will be implemented
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.ValueProviderFactories.Insert(0, factory);
        }
    }
}

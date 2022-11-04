using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FeedbackApi.Infrastructure
{
    public class SeparatedQueryStringValueProviderFactory : IValueProviderFactory
    {
        private readonly string separator;
        private readonly string key;

        public SeparatedQueryStringValueProviderFactory(string separator)
            : this(null, separator)
        {
        }

        public SeparatedQueryStringValueProviderFactory(string key, string separator)
        {
            this.key = key;
            this.separator = separator;
        }

        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            context.ValueProviders.Insert(0, new SeparatedQueryStringValueProvider(key, context.ActionContext.HttpContext.Request.Query, separator));
            return Task.CompletedTask;
        }
    }
}

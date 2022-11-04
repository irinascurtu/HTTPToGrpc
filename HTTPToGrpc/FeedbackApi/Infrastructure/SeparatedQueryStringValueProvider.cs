using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;

namespace FeedbackApi.Infrastructure
{
    public class SeparatedQueryStringValueProvider : QueryStringValueProvider
    {
        private readonly string key;
        private readonly string separator;
        private readonly IQueryCollection values;

        public SeparatedQueryStringValueProvider(IQueryCollection values, string separator)
            : this(null, values, separator)
        {
        }

        public SeparatedQueryStringValueProvider(string key, IQueryCollection values, string separator)
            : base(BindingSource.Query, values, CultureInfo.InvariantCulture)
        {
            this.key = key;
            this.values = values;
            this.separator = separator;
        }

        public override ValueProviderResult GetValue(string key)
        {
            var result = base.GetValue(key);

            if (this.key != null && this.key != key)
            {
                return result;
            }

            if (result != ValueProviderResult.None && result.Values.Any(x => x.IndexOf(separator, StringComparison.OrdinalIgnoreCase) > -1))
            {
                var splitValues = new StringValues(result.Values.SelectMany(x => x.TrimEnd().TrimStart().Split(new[] { separator }, StringSplitOptions.None)).ToArray());
                return new ValueProviderResult(splitValues, result.Culture);
            }

            return result;
        }
    }
}

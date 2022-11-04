using Microsoft.AspNetCore.Mvc.Abstractions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;


namespace FeedbackApi.Infrastructure
{

    public class QueryStringConstraint : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            IList<ParameterDescriptor> methodParameters = action.Parameters;

            ICollection<string> queryStringKeys = routeContext.HttpContext.Request.Query.Keys.Select(q => q.ToLower()).ToList();
            IList<string> methodParamNames = methodParameters.Select(mp => mp.Name.ToLower()).ToList();

            foreach (var methodParameter in methodParameters)
            {
                if (methodParameter.ParameterType.Name.Contains("talk"))
                {
                    //check if the query string has a parameter that is not in the method params
                    foreach (var q in queryStringKeys)
                    {
                        //if (!methodParamNames.Any(mp => mp == q))
                        if (methodParamNames.All(mp => mp != q))
                        {
                            return false;
                        }
                    }


                    if (queryStringKeys.All(q => q != methodParameter.Name.ToLower()))
                    {
                        continue;
                    }
                }
                else if (queryStringKeys.All(q => q != methodParameter.Name.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}


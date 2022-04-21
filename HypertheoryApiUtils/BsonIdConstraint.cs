
using MongoDB.Bson;

namespace HypertheoryApiUtils;

public class BsonIdConstraint : IRouteConstraint
{
    
    // used in your program.cs to add a constraint for bson ids.
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (values.TryGetValue(routeKey, out var routeValue))
        {
            var parameterValue = Convert.ToString(routeValue);
            if (ObjectId.TryParse(parameterValue, out var _))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}

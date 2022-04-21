
using MongoDB.Bson;

namespace HypertheoryApiUtils;

public class BsonIdConstraint : IRouteConstraint
{

    /// <summary>
    /// Creates a route constraint that verifies if a route value is a BsonId or not. Add it to your route constraints .
    /// </summary>
    /// <example>
    /// This is how you add it to your constraints.
    /// <code>
    /// builder.Services.AddRouting(options =>
    ///{
    ///    options.ConstraintMap.Add("bsonid", typeof(BsonIdConstraint));
    ///});
    /// </code>
    /// </example>
    /// <param name="httpContext"></param>
    /// <param name="route"></param>
    /// <param name="routeKey"></param>
    /// <param name="values"></param>
    /// <param name="routeDirection"></param>
    /// <returns></returns>
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

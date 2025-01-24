using System.Linq.Expressions;

namespace CallTrack.Share.Sort;
public static class QueryableExtensions
{
    public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, string orderByProperty, bool descending)
    {
        if (string.IsNullOrWhiteSpace(orderByProperty))
            return query; // Retorna a consulta sem ordenação se não houver campo definido

        var entityType = typeof(T);
        var property = entityType.GetProperty(orderByProperty);
        if (property == null)
            throw new ArgumentException($"A propriedade '{orderByProperty}' não existe na entidade {entityType.Name}.");

        var parameter = Expression.Parameter(entityType, "x");
        var propertyAccess = Expression.Property(parameter, property);
        var orderByExpression = Expression.Lambda(propertyAccess, parameter);

        string methodName = descending ? "OrderByDescending" : "OrderBy";

        var resultExpression = Expression.Call(
            typeof(Queryable),
            methodName,
            new Type[] { entityType, property.PropertyType },
            query.Expression,
            Expression.Quote(orderByExpression)
        );

        return query.Provider.CreateQuery<T>(resultExpression);
    }
}

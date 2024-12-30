namespace Application.Services.CQS.Queries
{
    public static class ListExtensions
    {
        public static List<T> ApplySorting<T>(this List<T> source, string? orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
                return source;

            var parts = orderBy.Split(' ');
            var propertyName = parts[0].Replace(".", "");
            var ascending = !orderBy.EndsWith(" desc", StringComparison.OrdinalIgnoreCase);

            return ascending
                ? [.. source.OrderBy(x => GetPropertyValue(x!, propertyName))]
                : [.. source.OrderByDescending(x => GetPropertyValue(x!, propertyName))]; 
        }

        public static List<T> ApplyPaging<T>(this List<T> source, int skip, int take)
        {
            return [.. source.Skip(skip).Take(take)];
        }

        private static object GetPropertyValue(object obj, string propertyName)
        {
            var propertyInfo = obj.GetType().GetProperty(propertyName);
            return propertyInfo == null
                ? throw new ArgumentException($"Property {propertyName} not found on {obj.GetType().Name}")
                : propertyInfo.GetValue(obj)!;
        }
    }
}

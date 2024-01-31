namespace Shared.ORM.Repositories
{
    public static class SortDefinition
    {
        public static IQueryable<TModel> ApplySort<TModel>(this IQueryable<TModel> models,
                                                      Func<IQueryable<TModel>, IOrderedQueryable<TModel>> sortExpression)
        {
            if (!models.Any())
            {
                return models;
            }
            models = sortExpression(models);
            return models;
        }
    }
}

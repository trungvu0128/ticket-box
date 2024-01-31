using Microsoft.EntityFrameworkCore;
using Project.Core.Constants;

namespace Project.Core.Extensions
{
    public static class EntityExtension
    {
        public static void SetEntityCreated<T>(this T entity, string createdByName)
        {
            var dateTimeProperty = entity?.GetType().GetProperty(FieldConstant.CREATEDDATEFIELD);
            dateTimeProperty?.SetValue(entity, DateTime.Now);
            var createdByProperty = entity?.GetType().GetProperty(FieldConstant.CREATEDBYFIELD);
            createdByProperty?.SetValue(entity, createdByName);
        }

        public static void SetEntityUpdated<T>(this T entity, string updatedByName)
        {
            var dateTimeProperty = entity?.GetType().GetProperty(FieldConstant.UPDATEDATEFIELD);
            dateTimeProperty?.SetValue(entity, DateTime.Now);
            var updatedByProperty = entity?.GetType().GetProperty(FieldConstant.CREATEDBYFIELD);
            updatedByProperty?.SetValue(entity, updatedByName);
        }

        public static void SetEntityDeleted<T>(this T entity, string deletedByName)
        {
            var deleteProperty = entity?.GetType().GetProperty(FieldConstant.DELETEFIELD);
            deleteProperty?.SetValue(entity, true);
            SetEntityUpdated(entity, deletedByName);
        }

        public static IQueryable<T> IncludeDeleted<T>(this IQueryable<T> entities, bool isDeleted = false) where T : notnull
        {
            var deleteProperty = typeof(T).GetProperty(FieldConstant.DELETEFIELD);
            if (deleteProperty != null && !isDeleted)
            {
                return entities.Where(x => EF.Property<bool>(x, FieldConstant.DELETEFIELD) == isDeleted);
            }
            return entities;
        }
    }
}

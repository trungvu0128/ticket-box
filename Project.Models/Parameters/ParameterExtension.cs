using Mapster;

namespace Project.Models.Parameters
{
    public static class ParameterExtension
    {
        public static T MapParameter<T>(this object source) where T : IParameter
        {
            return source.Adapt<T>();
        }
    }
}

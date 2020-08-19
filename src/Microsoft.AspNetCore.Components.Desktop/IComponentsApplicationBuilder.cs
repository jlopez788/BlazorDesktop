using System;

namespace Microsoft.AspNetCore.Components.Desktop
{
    public interface IComponentsApplicationBuilder
    {
        IServiceProvider Services { get; }

        void AddComponent(Type componentType, string domElementSelector);
    }

    public static class ComponentsApplicationBUilderExtensions
    {
        public static void AddComponent<TComponent>(this IComponentsApplicationBuilder builder, string node)
        {
            builder.AddComponent(typeof(TComponent), node);
        }
    }
}
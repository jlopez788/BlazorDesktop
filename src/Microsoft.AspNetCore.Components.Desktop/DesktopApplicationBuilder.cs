using System;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Components.Desktop
{
    internal struct ComponentNodeSelector
    {
        public Type ComponentType { get; }
        public string NodeSelector { get; }

        public ComponentNodeSelector(Type componentType, string nodeSelector)
        {
            ComponentType = componentType;
            NodeSelector = nodeSelector;
        }

        public override int GetHashCode() => ComponentType?.GetHashCode() ?? 0;

        public override bool Equals(object obj) => obj is ComponentNodeSelector selector && selector.ComponentType == ComponentType;
    }

    internal class DesktopApplicationBuilder : IComponentsApplicationBuilder
    {
        public DesktopApplicationBuilder(IServiceProvider services)
        {
            Services = services;
            Entries = new HashSet<ComponentNodeSelector>();
        }

        public HashSet<ComponentNodeSelector> Entries { get; }

        public IServiceProvider Services { get; }

        public void AddComponent(Type componentType, string domElementSelector)
        {
            if (componentType == null)
            {
                throw new ArgumentNullException(nameof(componentType));
            }

            if (domElementSelector == null)
            {
                throw new ArgumentNullException(nameof(domElementSelector));
            }

            Entries.Add(new ComponentNodeSelector(componentType, domElementSelector));
        }
    }
}
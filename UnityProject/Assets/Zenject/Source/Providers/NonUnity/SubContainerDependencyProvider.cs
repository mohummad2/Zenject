using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using Zenject.Internal;

namespace Zenject
{
    public class SubContainerDependencyProvider : IProvider
    {
        readonly ISubContainerCreator _subContainerCreator;
        readonly Type _dependencyType;
        readonly string _identifier;

        // if concreteType is null we use the contract type from inject context
        public SubContainerDependencyProvider(
            Type dependencyType,
            string identifier,
            ISubContainerCreator subContainerCreator)
        {
            _subContainerCreator = subContainerCreator;
            _dependencyType = dependencyType;
            _identifier = identifier;
        }

        public Type GetInstanceType(InjectContext context)
        {
            return _dependencyType;
        }

        InjectContext CreateSubContext(
            InjectContext parent, DiContainer subContainer)
        {
            var subContext = parent.CreateSubContext(_dependencyType, _identifier);

            subContext.Container = subContainer;

            // This iis important to avoid infinite loops
            subContext.SourceType = InjectSources.Local;

            return subContext;
        }

        public IEnumerator<List<object>> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args)
        {
            Assert.IsNotNull(context);

            var subContainer = _subContainerCreator.CreateSubContainer(args);

            var subContext = CreateSubContext(context, subContainer);

            yield return subContainer.ResolveAll(subContext).Cast<object>().ToList();
        }

        public IEnumerable<ZenjectException> Validate(InjectContext context, List<Type> argTypes)
        {
            var subContainer = _subContainerCreator.CreateSubContainer(
                ZenUtilInternal.CreateDummyArgList(argTypes));

            var subContext = CreateSubContext(context, subContainer);

            foreach (var error in subContainer.ValidateResolveAll(subContext))
            {
                yield return error;
            }

            foreach (var error in subContainer.ValidateValidatables())
            {
                yield return error;
            }
        }
    }
}

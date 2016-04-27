using System;
using ModestTree;
using System.Linq;

namespace Zenject
{
    public class FactorySubContainerBinder<TParam1, TParam2, TContract>
        : FactorySubContainerBinderWithParams<TContract>
    {
        public FactorySubContainerBinder(
            BindInfo bindInfo, Type factoryType,
            BindFinalizerWrapper finalizerWrapper, string subIdentifier)
            : base(bindInfo, factoryType, finalizerWrapper, subIdentifier)
        {
        }

        public ConditionBinder ByMethod(Action<DiContainer, TParam1, TParam2> installerMethod)
        {
            SubFinalizer = CreateFinalizer(
                (container) => new SubContainerDependencyProvider(
                    ContractType, SubIdentifier,
                    new SubContainerCreatorByMethod<TParam1, TParam2>(
                        container, installerMethod)));

            return new ConditionBinder(BindInfo);
        }
    }
}


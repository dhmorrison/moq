﻿using Moq.Proxy;

namespace Moq.Sdk
{
    /// <summary>
    /// Throws for all invocations performed, since it means the 
    /// <see cref="MockBehavior"/> did not find a matching <see cref="IMockBehavior"/> 
    /// to invoke.
    /// </summary>
    public class StrictMockBehavior : IProxyBehavior
    {
        /// <summary>
        /// Throws <see cref="StrictMockException"/>.
        /// </summary>
        public IMethodReturn Invoke(IMethodInvocation invocation, GetNextBehavior getNext) => throw new StrictMockException();
    }
}

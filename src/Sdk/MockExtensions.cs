﻿using System;
using Moq.Proxy;

namespace Moq.Sdk
{
    /// <summary>
    /// Usability functions for working with mocks.
    /// </summary>
    public static class MockExtensions
    {
        /// <summary>
        /// Adds a behavior to a mock.
        /// </summary>
		public static IMocked AddBehavior(this IMocked mock, Func<IMethodInvocation, bool> appliesTo, InvokeBehavior behavior, string name = null)
        {
            mock.Mock.Behaviors.Add(MockBehavior.Create(appliesTo, behavior, name));
            return mock;
        }

        /// <summary>
        /// Inserts a behavior into the mock behavior pipeline at the specified 
        /// index.
        /// </summary>
		public static IMocked InsertBehavior(this IMocked mock, int index, Func<IMethodInvocation, bool> appliesTo, InvokeBehavior behavior, string name = null)
        {
            mock.Mock.Behaviors.Insert(index, MockBehavior.Create(appliesTo, behavior, name));
            return mock;
        }

        /// <summary>
        /// Adds a behavior to a mock.
        /// </summary>
		public static IMock AddBehavior(this IMock mock, Func<IMethodInvocation, bool> appliesTo, InvokeBehavior behavior, string name = null)
        {
            mock.Behaviors.Add(MockBehavior.Create(appliesTo, behavior, name));
            return mock;
        }

        /// <summary>
        /// Inserts a behavior into the mock behasvior pipeline at the specified 
        /// index.
        /// </summary>
        public static IMock InsertBehavior(this IMock mock, int index, Func<IMethodInvocation, bool> appliesTo, InvokeBehavior behavior, string name = null)
        {
            mock.Behaviors.Insert(index, MockBehavior.Create(appliesTo, behavior, name));
            return mock;
        }

        /// <summary>
        /// Adds a behavior to a mock.
        /// </summary>
		public static TMock AddBehavior<TMock>(this TMock mock, Func<IMethodInvocation, bool> appliesTo, InvokeBehavior behavior, string name = null)
        {
            // We can't just add a constraint to the method signature, because this is 
            // implemented internally for Moq.Sdk to consume.
            if (mock is IMocked mocked)
                mocked.Mock.Behaviors.Add(MockBehavior.Create(appliesTo, behavior, name));
            else
                throw new ArgumentException(nameof(mock));

            return mock;
        }

        /// <summary>
        /// Inserts a behavior into the mock behasvior pipeline at the specified 
        /// index.
        /// </summary>
        public static TMock InsertBehavior<TMock>(this TMock mock, int index, Func<IMethodInvocation, bool> appliesTo, InvokeBehavior behavior, string name = null)
        {
            if (mock is IMocked mocked)
                mocked.Mock.Behaviors.Insert(index, MockBehavior.Create(appliesTo, behavior, name));
            else
                throw new ArgumentException(nameof(mock));

            return mock;
        }

        /// <summary>
        /// Adds a behavior to a mock.
        /// </summary>
        public static TMock AddBehavior<TMock>(this TMock mock, IMockBehavior behavior)
        {
            if (mock is IMocked mocked)
                mocked.Mock.Behaviors.Add(behavior);
            else
                throw new ArgumentException(nameof(mock));

            return mock;
        }

        /// <summary>
        /// Inserts a behavior into the mock behasvior pipeline at the specified 
        /// index.
        /// </summary>
        public static TMock InsertBehavior<TMock>(this TMock mock, int index, IMockBehavior behavior)
        {
            if (mock is IMocked mocked)
                mocked.Mock.Behaviors.Insert(index, behavior);
            else
                throw new ArgumentException(nameof(mock));

            return mock;
        }
    }
}

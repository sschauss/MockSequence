using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Moq.Language.Flow;

namespace MockSequence
{
    public class Sequence
    {
        private readonly List<MethodInfo> _methodInfoSequence;

        public Sequence()
        {
            _methodInfoSequence = new List<MethodInfo>();
        }

        public void Add<T>(ISetup<T> setup) where T : class
        {
            var methodInfo = (MethodInfo) setup
                .GetType()
                .GetRuntimeProperty("Method")
                .GetValue(setup);
            _methodInfoSequence.Add(methodInfo);
            setup.Callback(() =>
            {
                var currentMethod = _methodInfoSequence.ElementAt(0);
                if (currentMethod != methodInfo)
                {
                    throw new Exception($"Expected {methodInfo} to be called but {currentMethod} has been called.");
                }
                _methodInfoSequence.RemoveAt(0);
            });
        }
    }
}
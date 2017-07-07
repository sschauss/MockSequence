using Moq.Language.Flow;

namespace MockSequence
{
    public static class SequenceExtension
    {
        public static ISetup<T> InSequence<T>(this ISetup<T> setup, Sequence sequence) where T : class
        {
            sequence.Add(setup);
            return setup;
        }
    }
}
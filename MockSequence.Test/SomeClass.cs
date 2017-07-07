using System.Threading.Tasks;

namespace MockSequence.Test
{
    public class SomeClass
    {
        private readonly IFoo _foo;
        private readonly IBar _bar;

        public SomeClass(IFoo foo, IBar bar)
        {
            _bar = bar;
            _foo = foo;
        }

        public async Task<string> DoMyStuffAsync()
        {
            return await Task.Run(() => DoMyStuff());
        }

        private string DoMyStuff()
        {
            _foo.Fooxiate();
            _bar.Baronize();
            _bar.Baronize();
            _bar.Baronize(2);
            return "someString";
        }
    }
}
using Moq;
using Xunit;

namespace MockSequence.Test
{
    public class SomeClassTests
    {
        private readonly Mock<IFoo> _fooMock;
        private readonly Mock<IBar> _barMock;
        
        private readonly SomeClass _cut;
        
        public SomeClassTests()
        {
            _fooMock = new Mock<IFoo>();
            _barMock = new Mock<IBar>();
            _cut = new SomeClass(_fooMock.Object, _barMock.Object);
        }
        
        [Fact]
        public async void DoMyStuffAsyncTest()
        {
            var sequence = new Sequence();
            _fooMock.Setup(m => m.Fooxiate()).InSequence(sequence);
            _barMock.Setup(m => m.Baronize()).InSequence(sequence);
            _barMock.Setup(m => m.Baronize()).InSequence(sequence);
            _barMock.Setup(m => m.Baronize(It.IsAny<int>())).InSequence(sequence);
            var result = await _cut.DoMyStuffAsync();
            Assert.Equal("someString", result);
        }

    }
}
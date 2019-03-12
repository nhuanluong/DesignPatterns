using NUnit.Framework;

namespace Singleton.Tests
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void Singleton_IsPolicy_ReturnEqual()
        {
            Assert.AreSame(Policy.Instance, Policy.Instance);
        }   
    }
}
using FluentAssertions;
using UnitTestingWorkshop.Core.Exercise01WordCombinationsFinder;
using Xunit;

namespace UnitTestingWorkshop.Tests.Exercise01WordCombinationsFinder
{
    public class TestsForWordCombinationsFinder
    {
        private readonly WordCombinationsFinder _finder;

        public TestsForWordCombinationsFinder()
        {
            _finder = new WordCombinationsFinder();
        }

        public class TestsForFindCombinations : TestsForWordCombinationsFinder
        {
            
        }
    }
}

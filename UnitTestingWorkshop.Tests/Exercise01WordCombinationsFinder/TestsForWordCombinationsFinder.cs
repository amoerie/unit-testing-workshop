using System;
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
            [Fact]
            public void ShouldReturnEmptyWhenThereAreNoWords()
            {
                // Arrange
                var words = Array.Empty<string>();
                var requestedLength = 6;

                // Act
                var combinations = _finder.FindCombinations(words, requestedLength);

                // Assert
                combinations.Should().BeEmpty();
            }

            [Fact]
            public void ShouldReturnEmptyWhenThereAreNoCombinations()
            {
                // Arrange
                var words = new string[] { "pizza", "hamburgers", "fries" };
                var requestedLength = 6;

                // Act
                var combinations = _finder.FindCombinations(words, requestedLength);

                // Assert
                combinations.Should().BeEmpty();
            }

            [Fact]
            public void ShouldReturnTwoCombinationsWhenThereAreTwoCombinations()
            {
                // Arrange
                var words = new string[] { 
                    "al", "bums", "albums",
                    "tail", "or", "tailor"
                };
                var requestedLength = 6;

                // Act
                var combinations = _finder.FindCombinations(words, requestedLength);

                // Assert
                var expectedCombinations = new[]
                {
                    new WordCombination { Word1 = "al", Word2 = "bums", Combination = "albums" },
                    new WordCombination { Word1 = "tail", Word2 = "or", Combination = "tailor" },
                };
                combinations.Should().BeEquivalentTo(expectedCombinations);
            }
        }
    }
}

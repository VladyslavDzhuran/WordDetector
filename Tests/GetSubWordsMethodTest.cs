using System;
using System.Linq;
using WordDetector;
using Xunit;

namespace Tests
{
    public class GetSubWordsMethodTest
    {
        private readonly WordDetector.WordBreaker _instance;

        public GetSubWordsMethodTest() 
        {
            var fileReader = new FileReader(path: @"..\..\..\de-dictionary.tsv");
            _instance = new WordDetector.WordBreaker(words: fileReader.GetWords());
        } 

        [Fact]
        public void GetSubWords_ShouldReturnCurrentWord()
        {
            // Arrange
            var word = "klinik";

            // Act
            var subWord = _instance.GetSubWords(word);

            // Assert
            Assert.Contains("klinik", subWord);
            Assert.True(subWord.Count() == 1);
        }

        [Fact]
        public void GetSubWords_ShoultBeThreeSubwords()
        {
            // Arrange
            var word = "berufskraftfahrer";

            // Act
            var subWord = _instance.GetSubWords(word);

            // Assert
            Assert.Contains("berufs", subWord);
            Assert.Contains("kraft", subWord);
            Assert.Contains("fahrer", subWord);
            Assert.True(subWord.Count() == 3);
        }

        [Fact]
        public void GetSubWords_ShouldReturnEmptyString()
        {
            // Arrange
            var word = "";

            // Act
            var subWord = _instance.GetSubWords(word);

            // Assert
            Assert.True(subWord.Count() == 0);
        }

        [Fact]
        public void GetSubWords_ShouldReturnCurentWordWithGermanChar()
        {
            // Arrange
            var word = "büro";

            // Act
            var subWord = _instance.GetSubWords(word);

            // Assert
            Assert.Contains("büro", subWord);
            Assert.True(subWord.Count() == 1);
        }

        [Fact]
        public void GetSubWords_ShouldThrowNullReferenceException()
        {
            // Arrange
            string word = null;

            // Assert
            Assert.Throws<NullReferenceException>(()=>_instance.GetSubWords(word));
        }
    }
}

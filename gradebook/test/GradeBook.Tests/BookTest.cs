using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTest
    {
        [Fact]
        public void BookCalculationsTest()
        {
            //arrange 
            Book book = new Book("book");
            book.addGrade(45);
            book.addGrade(72);
            book.addGrade(60);
            //act 
            var actual = book.getStatistics();
            //Assert 
            Assert.Equal(59,actual.average,1); // third parameter is the presicion 
            Assert.Equal(45,actual.low,1);
            Assert.Equal(72,actual.high,1);
        }
    }
}

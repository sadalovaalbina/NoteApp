using NUnit.Framework;
using NoteApp;

namespace NoteAppUnitTests
{
    [TestFixture]
    public class NoteTest
    {
        private Note Note { set; get; }

        [Test(Description = "")]
        public void Get_Name()
        {
            //setup
            Note = new Note();
            var expected = "test";
            Note.Name = expected;

            //act
            var actual = Note.Name;

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}

using NUnit.Framework;
using System;
using NoteApp;

namespace NoteAppUnitTests
{
    /// <summary>
    /// Определение классов юнит-тестирования
    /// </summary>
    [TestFixture]
    public class NoteTest
    {
        /// <summary>
        /// Переменная, хранящая время создания заметки
        /// </summary>
        private readonly DateTime _createdTime = new DateTime(2021, 04, 18, 17, 00, 00);

        /// <summary>
        /// Переменная, хранящая время изменения заметки
        /// </summary>
        private readonly DateTime _changedTime = new DateTime(2021, 04, 18, 17, 05, 00);

        /// <summary>
        /// Метод, выполняющийся каждый раз перед запуском теста
        /// Создает экземпляр заметки
        /// </summary>
        public Note GetSourceNote()
        {
            var sourceNote = new Note
            {
                Name = "Здесь должен быть текст",
                NoteCategory = NoteCategory.Home,
                NoteText = "Название заметки",
                CreateTime = _createdTime,
                LastChange = _changedTime
            };

            return sourceNote;
        }

        [Test(Description = "Позитивный тест геттера Name")]
        public void Name_GetCorrectValue()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = "Здесь должен быть текст";

            //Act
            var actual = sourceNote.Name;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Позитивный тест сеттера Name")]
        public void Name_SetCorrectValue()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = sourceNote.Name;

            //Act
            sourceNote.Name = expected;
            var actual = sourceNote.Name;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера Name с пустым значением")]
        public void Name_SetEmptyValue()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = "";

            //Act
            sourceNote.Name = "";
            var actual = sourceNote.Name;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера Name с длиной значения" +
                            "поля, превышающего 50 символов")]
        public void Name_SetTooLongValue()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var source = "Слишком длинное название поля," +
                         "превышающее 50 символов и выбрасывающее" +
                         "исключение";

            //Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    // Act
                    sourceNote.Name = source;
                });
        }

        [Test(Description = "Тест геттера NoteCategory")]
        public void NoteCategory_GetCorrectNoteCategory()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = NoteCategory.Home;

            //Act
            var actual = sourceNote.NoteCategory;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера NoteCategory")]
        public void NoteCategory_SetCorrectValue()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = sourceNote.NoteCategory;

            //Act
            sourceNote.NoteCategory = expected;
            var actual = sourceNote.NoteCategory;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест геттера NoteText")]
        public void NoteText_GetCorrectNoteText()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = "Название заметки";

            //Act
            var actual = sourceNote.NoteText;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера NoteText")]
        public void NoteText_SetCorrectValue()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = sourceNote.NoteText;

            //Act
            sourceNote.NoteText = expected;
            var actual = sourceNote.NoteText;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест геттера CreateTime")]
        public void CreateTime_GetCorrectCreatedTime()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = _createdTime;

            //Act
            var actual = sourceNote.CreateTime;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера CreateTime")]
        public void CreateTime_SetCorrectCreatedTime()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = sourceNote.CreateTime;

            //Act
            sourceNote.CreateTime = expected;
            var actual = sourceNote.CreateTime;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест геттера LastChange")]
        public void LastChange_GetCorrectChangedTime()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = _changedTime;

            //Act
            var actual = sourceNote.LastChange;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера LastChange")]
        public void LastChange_SetCorrectChangedTime()
        {
            //Setup
            var sourceNote = GetSourceNote();
            var expected = sourceNote.LastChange;

            //Act
            sourceNote.LastChange = expected;
            var actual = sourceNote.LastChange;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест клонирования ICloneable")]
        public void TestClone_ReturnsSameClone()
        {
            //Act
            var sourceNote = GetSourceNote();
            var expected = (Note)sourceNote.Clone();

            //Assert
            Assert.AreEqual(expected, sourceNote);
        }
    }
}

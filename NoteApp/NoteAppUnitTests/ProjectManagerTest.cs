using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using NoteApp;

namespace NoteAppUnitTests
{
    [TestFixture]
    public class ProjectManagerTest
    {
        /// <summary>
        /// Путь к правильному файлу
        /// </summary>
        private readonly string _correctProjectFileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\TestData\correctProject.json";

        /// <summary>
        /// Путь к поврежденному файлу
        /// </summary>
        private readonly string _incorrectProjectFileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\TestData\incorrectProject.json";

        /// <summary>
        /// Путь для сохранения файла
        /// </summary>
        private readonly string _outputProjectFileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Output\savedFile.json";


        /// <summary>
        /// Создается объект проекта с двумя заметками в нем
        /// </summary>
        /// <returns></returns>
        private Project GetCorrectProject()
        {
            var correctProject = new Project();

            //Переменные хранящие время из эталонного файла
            var firstTime = DateTime.Parse("2022-03-18T12:13:16.470348+07:00");
            var secondTime = DateTime.Parse("2022-03-18T12:13:16.4713462+07:00");

            correctProject.Notes.Add(new Note()
            {
                Name = "New",
                NoteText = "Text",
                NoteCategory = NoteCategory.Other,
                CreateTime = firstTime,
                LastChange = firstTime
            });
            correctProject.Notes.Add(new Note()
            {
                Name = "Older",
                NoteText = "Another text",
                NoteCategory = NoteCategory.Finance,
                CreateTime = secondTime,
                LastChange = secondTime
            });

            return correctProject;
        }

        [Test(Description = "Позитивный тест сериализации проекта")]
        public void SaveToFile_SaveCorrectProject_ProjectSavedCorrectly()
        {
            var savingProject = GetCorrectProject();
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Output";

            if (File.Exists(path))
            {
                Directory.Delete(path, true);
            }

            ProjectManager.SaveToFile(savingProject, _outputProjectFileName);

            var actual = File.ReadAllText(_outputProjectFileName);
            var expected = File.ReadAllText(_correctProjectFileName);

            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Позитивный тест десериализации проекта")]
        public void LoadFromFile_LoadCorrectProject_ProjectLoadedCorrectly()
        {
            var expectedProject = GetCorrectProject();

            var actualProject = ProjectManager.LoadFromFile(_correctProjectFileName);

            Assert.AreEqual(expectedProject.Notes.Count, actualProject.Notes.Count);

            Assert.Multiple(() =>
            {
                for (var i = 0; i < expectedProject.Notes.Count; i++)
                {
                    var expected = expectedProject.Notes[i];
                    var actual = actualProject.Notes[i];

                    Assert.AreEqual(expected, actual);
                }
            });

        }

        [Test(Description = "Тест десериализации поврежденного файла")]
        public void LoadFromFile_LoadNotCorrectProject_ProjectLoadedNotCorrectly()
        {
            var actualProject = ProjectManager.LoadFromFile(_incorrectProjectFileName);

            Assert.AreEqual(actualProject.Notes.Count, 0);
            Assert.NotNull(actualProject);
        }

        [Test(Description = "Тест десериализации несуществующего файла")]
        public void LoadFromFile_LoadNonExistentProject_ProjectLoadedNotCorrectly()
        {
            var actualProject = ProjectManager.LoadFromFile(@"\TestData\Project.json");

            Assert.AreEqual(actualProject.Notes.Count, 0);
            Assert.NotNull(actualProject);
        }

    }
}

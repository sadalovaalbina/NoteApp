using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Хранит название, категорию и текст заметки,
    /// время ее создания, время последнего изменения
    /// </summary>
    public class Note : ICloneable
    {
        /// <summary>
        /// Название заметки
        /// </summary>
        private string _name = "Без названия";

        /// <summary>
        /// Категория заметки
        /// </summary>
        private NoteCategory _noteCategory;

        /// <summary>
        /// Текст заметки
        /// </summary>
        private string _noteText;

        /// <summary>
        /// Время создания заметки
        /// </summary>
        private DateTime _createTime = DateTime.Now;

        /// <summary>
        /// Время последнего изменения заметки
        /// </summary>
        private DateTime _lastChange;

        /// <summary>
        /// Возвращает или устанавливает значение "Название заметки"
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Длина названия не должна превышать 50 символов");
                }
                _name = value;
                LastChange = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает или устанавливает значение "Категория заметки"
        /// </summary>
        public NoteCategory NoteCategory
        {
            get
            {
                return _noteCategory;
            }
            set
            {
                _noteCategory = value;
                LastChange = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает или устанавливает значение "Текст заметки"
        /// </summary>
        public string NoteText
        {
            get
            {
                return _noteText;
            }
            set
            {
                _noteText = value;
                LastChange = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает или устанавливает значение "Время создания заметки"
        /// </summary>
        public DateTime CreateTime
        {
            get
            {
                return _createTime;
            }
        }

        /// <summary>
        /// Возвращает или устанавливает значение "Время изменения"
        /// </summary>
        public DateTime LastChange
        {
            get
            {
                return _lastChange;
            }
            private set
            {
                _lastChange = value;
            }
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Note()
        {

        }

        /// <summary>
        /// Конструктор класса Note для сериализации
        /// </summary>
        /// <param name="name"> </param> //написать значеняи параметров
        /// <param name="noteCategory"> </param>
        /// <param name="noteText"> </param>
        /// <param name="createTime"> </param>
        /// <param name="lastChange"> </param>
        private Note(string name, NoteCategory noteCategory, string noteText, DateTime createTime, DateTime lastChange)
        {
            _name = name;
            _noteCategory = noteCategory;
            _noteText = noteText;
            _createTime = createTime;
            _lastChange = lastChange;
        }

        /// <summary>
        /// Возвращает клон объекта
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Note(_name, _noteCategory, _noteText, _createTime, _lastChange);
        }
    }
}

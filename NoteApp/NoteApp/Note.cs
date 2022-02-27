using System;

namespace NoteApp
{
    /// <summary>
    /// Хранит название, категорию и текст заметки,
    /// время ее создания, время последнего изменения
    /// </summary>
    public class Note : ICloneable, IEquatable<Note>
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
            set
            {
                _createTime = value;
            }
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
            set
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
        public Note(string name, NoteCategory noteCategory, string noteText, DateTime createTime, DateTime lastChange)
        {
            Name = name;
            NoteCategory = noteCategory;
            NoteText = noteText;
            CreateTime = createTime;
            LastChange = lastChange;
        }

        /// <summary>
        /// Возвращает клон объекта
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Note(_name, _noteCategory, _noteText, _createTime, _lastChange);
        }

        /// <summary>
        /// Возвращает результат сравнения двух заметок
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Note other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            return _name == other._name
                   && _noteCategory == other._noteCategory
                   && _noteText == other._noteText
                   && _createTime.Equals(other._createTime)
                   && _lastChange.Equals(other._lastChange);
        }

        /// <summary>
        /// Возвращает результат сравнения двух заметок
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            return Equals((Note)obj);
        }

        /// <summary>
        /// Возвращает некоторое числовое значение,
        /// которое будет соответствовать данному объекту или его хэш-код
        /// С помощью него можно сравнивать объекты
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)_noteCategory;
                hashCode = (hashCode * 397) ^ (_noteText!= null ? _noteText.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _createTime.GetHashCode();
                hashCode = (hashCode * 397) ^ _lastChange.GetHashCode();
                return hashCode;
            }
        }

        public string ToFormattedTime(DateTime time)
        {
            return time.ToShortDateString() + @" " + time.ToShortTimeString();
        }
    }
}

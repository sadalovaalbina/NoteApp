using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    public class Note : ICloneable
    {
        private string _name = "Без названия";
        private NoteCategory _noteCategory;
        private string _noteText;
        private DateTime _createTime = DateTime.Now;
        private DateTime _lastChange;
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
        public DateTime CreateTime
        {
            get
            {
                return _createTime;
            }
        }
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
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="noteCategory"></param>
        /// <param name="noteText"></param>
        /// <param name="createTime"></param>
        /// <param name="lastChange"></param>
        private Note(string name, NoteCategory noteCategory, string noteText, DateTime createTime, DateTime lastChange)
        {
            _name = name;
            _noteCategory = noteCategory;
            _noteText = noteText;
            _createTime = createTime;
            _lastChange = lastChange;
        }
        public object Clone()
        {
            return new Note(_name, _noteCategory, _noteText, _createTime, _lastChange);
        }
    }
}

using System;

namespace homework_10.Task7
{
    public class Book : IComparable<Book>
    {
        private string _title;
        private string _author;

        public Book(string name, string author)
        {
            _title = name;
            _author = author;
        }

        public int CompareTo(Book other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var titileComparison = string.Compare(_title, other._title, StringComparison.CurrentCulture);
            if (titileComparison != 0) return titileComparison;
            return string.Compare(_author, other._author, StringComparison.CurrentCulture);
        }
    }
}
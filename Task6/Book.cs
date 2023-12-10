using System.Text.Json.Serialization;
using Task6.DAL.Repositories.XML.XMLEntities;

namespace Task6
{
    public class Book
    {
        string _title;
        string _publicationDate;
        List<Author> _authors;

        public string Title
        {
            get { return _title; }
        }
        public string PublicationDate
        {
            get { return _publicationDate; }
        }
        public List<Author> Authors
        {
            get { return _authors; }
        }

        [JsonConstructor]
        public Book(string title, string publicationDate, List<Author> authors)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("title is null");
            }

            _title = title;
            _publicationDate = publicationDate;
            _authors = authors;
        }

        public Book(XMLBook xmlBook)
        {
            this._title = xmlBook.Title;
            this._publicationDate = xmlBook.PublicationDate;
            this._authors = xmlBook.Authors.ConvertAll(x => new Author(x));
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Book otherBook)
                return false;

            return _title == otherBook._title &&
               _publicationDate == otherBook._publicationDate &&
               AuthorsEqual(_authors, otherBook._authors);
        }

        private bool AuthorsEqual(List<Author> authors1, List<Author> authors2)
        {
            if (authors1.Count != authors2.Count)
                return false;

            for (int i = 0; i < authors1.Count; i++)
            {
                if (!authors1[i].Equals(authors2[i]))
                    return false;
            }

            return true;
        }
    }
}

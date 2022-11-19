using HiTechManagement.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTechManagement.BLL
{
    internal class Book
    {

        // Private variables
        private int isbn;
        private string title;
        private decimal unitPrice;
        private int yearPublished;
        private int qoh;
        private int categoryId;
        private int publisherId;


        // Properties
        public int ISBN { get => isbn; set => isbn = value; }
        public string Title { get => title; set => title = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int YearPublished { get => yearPublished; set => yearPublished = value; }
        public int QOH { get => qoh; set => qoh = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public int PublisherId { get => publisherId; set => publisherId = value; }

        //custom methods

        public void SaveBook(Book bk)
        {
            BookDB.SaveRecord(bk);

        }
        public Book SearchBook(int ebk)
        {
            return BookDB.SearchRecord(ebk);

        }

        public bool IdExists(int id)
        {
            return BookDB.IsDuplicateId(id);
        }


        public void UpdateBook(Book bk)
        {
            BookDB.UpdateRecord(bk);
        }

        public void DeleteBook(int eId)
        {
            BookDB.DeleteRecord(eId);

        }

        public List<Book> GetBookList()
        {
            return BookDB.GetAllRecords();
        }


    }
}

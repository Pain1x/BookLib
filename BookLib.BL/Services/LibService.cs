using AutoMapper;
using BookLib.BL.DTO;
using BookLib.BL.Infrastructure;
using BookLib.BL.Interfaces;
using BookLib.DAL.Entities;
using BookLib.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BookLib.BL.Services
{
    public class LibService : ILibService
    {
        IUnitOfWork Database { get; set; }
        public LibService(IUnitOfWork unit)
        {
            Database = unit;
        }
        public void AddAnAuthorAndBook(string authorname, string bookname)
        {
            try
            {
                Database.ADO.AddAnAuthorAndBook(authorname, bookname);
            }
            catch
            {
                throw new ValidationException("Something went wrong", "");
            }
        }
        public void DeleteABook(string bookname)
        {
            try
            {
                Database.ADO.DeleteABook(bookname);
            }
            catch
            {
                throw new ValidationException("Something went wrong", "");
            }
        }
        public void DeleteAnAuthor(string authorname)
        {
            try
            {
                Database.ADO.DeleteAnAuthor(authorname);
            }
            catch
            {
                throw new ValidationException("Something went wrong", "");
            }
        }
        public IEnumerable<BookInfoDTO> GetBooks()
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<BookInfo, BookInfoDTO>());
                var mapper = new Mapper(config);
                return mapper.Map<IEnumerable<BookInfoDTO>>(Database.ADO.GetBooks());
            }
            catch
            {
                throw new ValidationException("Something went wrong", "");
            }
        }
        public void UpdateBookName(string bookname, string newbookname)
        {
            try
            {
                Database.ADO.UpdateBookName(bookname, newbookname);
            }
            catch
            {
                throw new ValidationException("Something went wrong", "");
            }
        }
        public void UpdateProgress(string finishpage, string bookname)
        {
            try
            {
                Database.ADO.UpdateProgress(finishpage, bookname);
            }
            catch
            {
                throw new ValidationException("Something went wrong", "");
            }
        }
    }
}

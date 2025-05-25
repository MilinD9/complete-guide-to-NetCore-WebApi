using my_books_store.Data.Models;
using my_books_store.Data.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_store.Data.Services
{
    public class PublishersService
    {
        private appDbContext _context;

        public PublishersService(appDbContext context)
        {
            _context = context;
        }

        public List<Publisher> GetAllPublishers(string sortBy,string searchString, int? pagenumber)
        { 
         var allPublishers= _context.Publishers.OrderBy(n=>n.Name
             ).ToList();

            //soting concepts
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy){
                    case "name_desc":
                        allPublishers = allPublishers.OrderByDescending(n => n.Name).ToList();
                        break;
                    default:
                        break;
                }
            }

            //searching 
            if (!string.IsNullOrEmpty(searchString))
            {
                allPublishers = allPublishers.OrderByDescending(n => n.Name.Contains(searchString)).ToList();
            }

            //paging 
            int pageSize = 5;
                allPublishers = PaginatedList<Publisher>.Create(allPublishers.AsQueryable(),pagenumber ?? 1,pageSize).ToList();
            return allPublishers;

        }
        
       
        public void AddPublisher(PublisherVM pub)
        {
            var _publisher = new Publisher()
            {
                Name = pub.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorsVM()
                    {
                        BookName = n.Title,
                        BookAuthors = n.Book_Authors.Select(n => n.Author.fullName).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return _publisherData;
        }

        public void deletepublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if(_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}

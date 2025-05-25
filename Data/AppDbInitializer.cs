using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_store.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var servicesScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicesScope.ServiceProvider.GetService<appDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book
                        {
                            Title = "Life of Pi",
                            Description = "A thrilling adventure of a young wizard learning magic at a prestigious school.",
                            IsRead = true,
                            DateRead = new DateTime(2023, 9, 15),
                            Rate = 5,
                            Genre = "Fantasy",
                            //Author = "Yann Martel",
                            CoverUrl = "https://example.com/life-of-pi-cover.jpg",
                            DateAdded = DateTime.Now
                        },

                        new Book
                        {
                            Title = "The Great Gatsby",
                            Description = "A story about the mysterious millionaire Jay Gatsby and his obsession with Daisy Buchanan.",
                            IsRead = true,
                            DateRead = new DateTime(2022, 5, 10),
                            Rate = 4,
                            Genre = "Classic",
                            //Author = "F. Scott Fitzgerald",
                            CoverUrl = "https://example.com/great-gatsby-cover.jpg",
                            DateAdded = DateTime.Now
                        },

                        new Book
                        {
                            Title = "1984",
                            Description = "A dystopian novel set in a totalitarian society under constant surveillance.",
                            IsRead = false,
                            DateRead = null,
                            Rate = 0,
                            Genre = "Dystopian",
                            //Author = "George Orwell",
                            CoverUrl = "https://example.com/1984-cover.jpg",
                            DateAdded = DateTime.Now
                        },

                        new Book
                        {
                            Title = "To Kill a Mockingbird",
                            Description = "A young girl’s coming-of-age story in the racially charged American South.",
                            IsRead = true,
                            DateRead = new DateTime(2021, 3, 22),
                            Rate = 5,
                            Genre = "Historical Fiction",
                            //Author = "Harper Lee",
                            CoverUrl = "https://example.com/to-kill-a-mockingbird-cover.jpg",
                            DateAdded = DateTime.Now
                        },

                        new Book
                        {
                            Title = "The Hobbit",
                            Description = "Bilbo Baggins embarks on an unexpected journey filled with dragons, treasure, and adventure.",
                            IsRead = true,
                            DateRead = new DateTime(2020, 8, 5),
                            Rate = 5,
                            Genre = "Fantasy",
                            //Author = "J.R.R. Tolkien",
                            CoverUrl = "https://example.com/the-hobbit-cover.jpg",
                            DateAdded = DateTime.Now
                        },

                        new Book
                        {
                            Title = "The Catcher in the Rye",
                            Description = "A story about teenage angst and rebellion narrated by the iconic Holden Caulfield.",
                            IsRead = false,
                            DateRead = null,
                            Rate = 0,
                            Genre = "Young Adult",
                            //Author = "J.D. Salinger",
                            CoverUrl = "https://example.com/catcher-in-the-rye-cover.jpg",
                            DateAdded = DateTime.Now
                        },

                        new Book
                        {
                            Title = "Pride and Prejudice",
                            Description = "A romantic novel that explores the themes of love, class, and reputation in 19th-century England.",
                            IsRead = true,
                            DateRead = new DateTime(2019, 12, 1),
                            Rate = 4,
                            Genre = "Romance",
                            //Author = "Jane Austen",
                            CoverUrl = "https://example.com/pride-and-prejudice-cover.jpg",
                            DateAdded = DateTime.Now
                        },

                        new Book
                        {
                            Title = "The Alchemist",
                            Description = "A philosophical book about a shepherd's journey to discover his personal legend.",
                            IsRead = true,
                            DateRead = new DateTime(2022, 11, 30),
                            Rate = 5,
                            Genre = "Adventure",
                            //Author = "Paulo Coelho",
                            CoverUrl = "https://example.com/the-alchemist-cover.jpg",
                            DateAdded = DateTime.Now
                        }
                    );

                    context.SaveChanges();
                }

            }

        }
    }
}

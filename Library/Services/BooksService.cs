using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BooksService : IBooksService
    {
        private readonly LibraryDbContext context;

        public BooksService(LibraryDbContext context)
        {
            this.context = context;
        }


        public async Task AddBookAsync(AddBookViewModel model)
        {
            var entity = new Book()
            {
              
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl=model.ImageUrl,
                Rating=model.Rating,
                CategoryId=model.CategoryId,
            };

            await context.Books.AddAsync(entity);
            await context.SaveChangesAsync();   
        }

        public async Task AddBookToCollectionAsync(int bookId, string userId)
        {
            var appUser = await context.Users
                 .Where(u => u.Id == userId)
                 .Include(u => u.ApplicationUsersBooks)
                 .FirstOrDefaultAsync();

            if (appUser == null)
            {
                throw new ArgumentException("Invalid User ID");
            }

            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == bookId);


            if (book == null)
            {
                throw new ArgumentException("Invalid book ID");
            }

            if (!appUser.ApplicationUsersBooks.Any(x => x.BookId == bookId))
            {
                appUser.ApplicationUsersBooks.Add(new ApplicationUserBook()
                {
                    ApplicationUserId = appUser.Id,
                    BookId = book.Id,
                    ApplicationUser = appUser,
                    Book = book
                });
            }

            await context.SaveChangesAsync();
        }


        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            var books = await context.Books
                            .Include(b => b.Category)
                            .ToListAsync();

            return books.Select(b => new BookViewModel()
            {
                Id=b.Id,
                ImageUrl=b.ImageUrl,
                Title = b.Title,
                Author= b.Author,
                Rating=b.Rating,
                Category=b.Category.Name
            });
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<MineBookViewModel>> GetMineBooksAsync(string userId)
        {
            var user = await context.Users
                     .Where(u => u.Id == userId)
                     .Include(u => u.ApplicationUsersBooks)
                     .ThenInclude(ub => ub.Book)
                     .ThenInclude(b => b.Category)
                     .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user id !");
            }

            return user.ApplicationUsersBooks.Select(b => new MineBookViewModel()
            {
                Id=b.Book.Id,
                ImageUrl=b.Book.ImageUrl,
                Title=b.Book.Author,
                Author=b.Book.Author,
                Description=b.Book.Description,
                Category=b.Book.Category.Name
            });
        }

        public async Task RemoveBookFromCollectionAsync(int bookId, string userId)
        {
            var user = await context.Users.
                     Where(u => u.Id == userId)
                     .Include(u => u.ApplicationUsersBooks)
                     .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user id !");
            }
            var book = user.ApplicationUsersBooks.FirstOrDefault(b => b.BookId == bookId);

            if (book != null)
            {
                user.ApplicationUsersBooks.Remove(book);
                await context.SaveChangesAsync();
            }

            

        }
    }
}

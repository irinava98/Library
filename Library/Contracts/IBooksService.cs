using Library.Data.Models;
using Library.Models;

namespace Library.Contracts
{
    public interface IBooksService
    {
        Task<IEnumerable<BookViewModel>> GetAllAsync();

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task AddBookAsync(AddBookViewModel model);

        Task<IEnumerable<MineBookViewModel>> GetMineBooksAsync(string userId);

        Task AddBookToCollectionAsync(int bookId, string userId);

        Task RemoveBookFromCollectionAsync(int bookId, string userId);
    }
}

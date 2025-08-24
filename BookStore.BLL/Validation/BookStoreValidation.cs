using BookStore.Common.Exceptions;

namespace BookStore.BLL.Validation
{
    public class BookStoreValidation : IBookStoreValidation
    {
        public void ValidateEntityExistense<T>(T? entity)
        {
            if (entity == null)
            {
                throw new NotFoundException("Entity not found");
            }
        }

        public void ValidateModel<T>(T? model)
        {
            if (model == null)
            {
                throw new NotFoundException("Model is null");
            }
        }
    }
}

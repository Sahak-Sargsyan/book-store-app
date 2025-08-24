namespace BookStore.BLL.Validation
{
    public interface IBookStoreValidation
    {
        void ValidateEntityExistense<T> (T? entity);

        void ValidateModel<T> (T? model);
    }
}

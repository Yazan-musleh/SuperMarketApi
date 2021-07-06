namespace Supermarket.API.Domain.Model.Services.Communication
{
    public class SaveCategoryResponse : BaseResponse
    {
        public Category Category { get; private set; }
        public SaveCategoryResponse(bool success, string message, Category category) : base(success, message)
        {
            Category = category;
        }

        ///<summary>
        ///Creates a Success response
        ///</summary>
        ///<param name="Category">Saved category </param>
        ///<returns> response </returns>

        public SaveCategoryResponse(string message) : this(false, message, null)
        {
        }
    }
}
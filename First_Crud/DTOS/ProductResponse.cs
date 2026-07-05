using First_Crud.Modals;

namespace First_Crud.DTOS
{
    public class ProductResponse
    {
        public bool isSuccess { get; set; }
        public bool isFailure { get; set; }
        public string? errors { get; set; }
        public Product? value { get; set; }
    }
}

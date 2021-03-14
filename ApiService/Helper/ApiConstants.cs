namespace ApiService.Helper
{
    public class ApiConstants
    {
        #region API Response Status
        public const string Error = "Error";
        public const string Success = "Success";
        public const string Warning = "Warning";
        #endregion

        #region Stored Procedures
        public const string P_GetOrderDetails = "P_GetOrderDetails";
        public const string P_InsertOrderDetails = "P_InsertOrderDetails";
        #endregion

        #region Common Constants
        public const string SortByAscending = "asc";
        public const string SortByDescending = "desc";
        #endregion

        #region Validation Message
        public const string DataFetchedSuccessfully = "Data fetched successfully.";
        public const string NoOrdersFound = "No orders found for the given input.";
        public const string InvalidPageInput = "Invalid Page size or Page index.";
        public const string OrderCreatedSuccessfully = "Order created successfully.";
        public const string InvalidOrderDetails = "Order details are invalid.";
        public const string InvalidInputs = "Provided inputs are invalid.";
        public const string DuplicateEmail = "Duplicate Email Id.";
        public const string NoCustomeFound = "Customer record not found.";
        public const string CustomerCreatedSuccessfully = "Customer added Successfully.";
        public const string CommonError = "Error occurred while getting/posting data.";
        public const string InvalidProductDetails = "Product details are not invalid.";
        public const string CommonErrorCode = "250";

        #endregion

    }
}

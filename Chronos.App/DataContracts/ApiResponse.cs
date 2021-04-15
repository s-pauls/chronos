using System.Collections.Generic;

namespace Chronos.App.DataContracts
{
    public class ApiResponse
    {
        public List<string> ErrorMessages { get; set; }
    }

    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public ApiResponse(T data, string successMessage)
        {
            Data = data;
            SuccessMessage = successMessage;
        }

        public T Data { get; set; }
        
        public string SuccessMessage { get; set; }
    }

    public class ApiListResponse<T> : ApiResponse<IEnumerable<T>>
    {
        public ApiListResponse(IEnumerable<T> data) : base(data)
        {
        }
    }
}

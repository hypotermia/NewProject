namespace MiniProjects.Repository
{
    public class WebApiHelper
    {
        public class ApiResponseObj
        {
            public object? data { get; set; }
            public string? message { get; set; }
            public bool status { get; set; }
        }
    }
}

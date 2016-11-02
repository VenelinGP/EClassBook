namespace EClassBook.Model
{
    using System;
    using Common.Models;

    public class Error : BaseModel
    {
        public string Message { get; set; }

        public string StackTrace { get; set; }

    }
}

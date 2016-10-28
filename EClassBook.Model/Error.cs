namespace EClassBook.Model.Entities
{
    using Common.Models;
    using System;

    public class Error : BaseModel
    {
        public string Message { get; set; }

        public string StackTrace { get; set; }

    }
}

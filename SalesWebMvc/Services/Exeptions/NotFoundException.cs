using System;

namespace SalesWebMvc.Services.Exeptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
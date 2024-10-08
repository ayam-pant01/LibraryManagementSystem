﻿namespace LMS.WebAPI.Models
{
    public class CheckoutDetailDto
    {
        public int BookId { get; set; }
        public int CheckoutDetailId { get; set; }
        public string BookTitle { get; set; }
        public bool IsReturned { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}

﻿namespace BookStore1.API.DTOs.Book
{
    public class BookResultDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string CategoryId { get; set; }
        public double Value { get; set; }
        public DateTime PublishDate { get; set; }
    }
}

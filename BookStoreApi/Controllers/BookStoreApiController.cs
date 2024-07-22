using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreApi.Models;


namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private static List<Book> Books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Author = "Author 1", Description = "Description 1", ImageUrl = "url1", Price = 10.99M, Availability = "In Stock" },
            new Book { Id = 2, Title = "Book 2", Author = "Author 2", Description = "Description 2", ImageUrl = "url2", Price = 12.99M, Availability = "Out of Stock" },
            new Book { Id = 3, Title = "Book 3", Author = "Author 3", Description = "Description 3", ImageUrl = "url3", Price = 15.99M, Availability = "In Stock" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks([FromQuery] string title = null, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var filteredBooks = Books
                .Where(b => string.IsNullOrEmpty(title) || b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            bool hasMore = filteredBooks.Count >= pageSize;
            return Ok(new { books = filteredBooks, hasMore });
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> CreateBook([FromBody] Book book)
        {
            if (book == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid book data.");
            }

            book.Id = Books.Max(b => b.Id) + 1;
            Books.Add(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            var existingBook = Books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
                return NotFound();

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Description = book.Description;
            existingBook.ImageUrl = book.ImageUrl;
            existingBook.Price = book.Price;
            existingBook.Availability = book.Availability;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            Books.Remove(book);
            return NoContent();
        }

        [HttpGet("author/{author}")]
        public ActionResult<IEnumerable<Book>> GetBooksByAuthor(string author)
        {
            var books = Books.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(books);
        }


        // CONTACT FORM

        [HttpPost("contact-us")]
        public IActionResult ContactUs([FromBody] ContactFormModel contactForm)
        {
            if (contactForm == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid contact form data.");
            }

            // Process the contact form data (e.g., save to database, send email, etc.)
            // For demonstration, we'll just log the data to console
            Console.WriteLine($"Received Contact Form Submission:");
            Console.WriteLine($"Name: {contactForm.Name}");
            Console.WriteLine($"Email: {contactForm.Email}");
            Console.WriteLine($"Subject: {contactForm.Subject}");
            Console.WriteLine($"Message: {contactForm.Message}");

            // Assuming you have a method to save the contact form to a database or similar
            // For demonstration, we'll add it to a list of reviews (not persisted)
            AddCustomerReview(contactForm);

            // Optional: Return a success message or status code
            return Ok("Contact form submitted successfully.");
        }



        // Method to retrieve all customer reviews (for demonstration)
        [HttpGet("customer-reviews")]
        public ActionResult<IEnumerable<ContactFormModel>> GetCustomerReviews()
        {
            // Return all contact form submissions as customer reviews
            return Ok(CustomerReviews);
        }

        // In-memory storage for customer reviews (for demonstration)
        private static List<ContactFormModel> CustomerReviews = new List<ContactFormModel>();

        // Method to add a new customer review (for demonstration)
        private void AddCustomerReview(ContactFormModel contactForm)
        {
            CustomerReviews.Add(contactForm);
        }

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieBase.Web.Data.Entities;

public class Review
{
    public required string ReviewId { get; set; }// wybór typu string dla klucza głównego jest arbitralny
    public required string MovieId { get; set; }
    public required string ReviewerName { get; set; }
    public required DateTime ReviewDate { get; set; }
    public required float Rating { get; set; }
}

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(x => x.ReviewId);
        builder.Property(x => x.ReviewId).HasMaxLength(36);
        builder.HasOne<Movie>()
            .WithMany()
            .HasForeignKey(p => p.MovieId);
        builder.Property(x => x.MovieId).HasMaxLength(36);
        builder.Property(x => x.ReviewerName).HasMaxLength(32);
        builder.Property(x => x.Rating);

        builder.HasData(
            new Review
            {
                ReviewId = Guid.NewGuid().ToString(),
                MovieId = "1516a394-4d9b-4447-a3ab-790a1c65b736", // Sample MovieId
                ReviewerName = "John Doe",
                ReviewDate = DateTime.Now.AddDays(-10),
                Rating = 4.5f
            },
            new Review
            {
                ReviewId = Guid.NewGuid().ToString(),
                MovieId = "36f4836a-5e13-4c2f-96a6-f1f900754a94", // Sample MovieId
                ReviewerName = "Jane Smith",
                ReviewDate = DateTime.Now.AddDays(-5),
                Rating = 3.8f
            },
            new Review
            {
                ReviewId = Guid.NewGuid().ToString(),
                MovieId = "36f4836a-5e13-4c2f-96a6-f1f900754a94", // Sample MovieId
                ReviewerName = "Bob Williams",
                ReviewDate = DateTime.Now.AddDays(-20),
                Rating = 4.2f
            },
            new Review
            {
                ReviewId = Guid.NewGuid().ToString(),
                MovieId = "d261b91c-9dae-4ef7-a6ec-cc4d958b4357", // Sample MovieId
                ReviewerName = "Eva Davis",
                ReviewDate = DateTime.Now.AddDays(-25),
                Rating = 3.9f
            },
            new Review
            {
                ReviewId = Guid.NewGuid().ToString(),
                MovieId = "d261b91c-9dae-4ef7-a6ec-cc4d958b4357", // Sample MovieId
                ReviewerName = "David Wilson",
                ReviewDate = DateTime.Now.AddDays(-30),
                Rating = 4.5f
            },
            new Review
            {
                ReviewId = Guid.NewGuid().ToString(),
                MovieId = "5f8de33b-ec39-4a46-ae1f-72b1faf04bed", // Sample MovieId
                ReviewerName = "Sophia Martinez",
                ReviewDate = DateTime.Now.AddDays(-35),
                Rating = 4.8f
            },
            new Review
            {
                ReviewId = Guid.NewGuid().ToString(),
                MovieId = "5f8de33b-ec39-4a46-ae1f-72b1faf04bed", // Sample MovieId
                ReviewerName = "Michael Thompson",
                ReviewDate = DateTime.Now.AddDays(-40),
                Rating = 3.5f
            },
            new Review
            {
                ReviewId = Guid.NewGuid().ToString(),
                MovieId = "5f8de33b-ec39-4a46-ae1f-72b1faf04bed", // Sample MovieId
                ReviewerName = "Olivia Harris",
                ReviewDate = DateTime.Now.AddDays(-45),
                Rating = 4.2f
            },
            new Review
            {
                ReviewId = Guid.NewGuid().ToString(),
                MovieId = "5f8de33b-ec39-4a46-ae1f-72b1faf04bed", // Sample MovieId
                ReviewerName = "Daniel Clark",
                ReviewDate = DateTime.Now.AddDays(-50),
                Rating = 3.7f
            }
        );
    }
}
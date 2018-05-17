using System;
using MzlLab3Client.ServiceReference1;

namespace MzlLab3Client
{
    public class RepoService :IRepoService
    {
        private static Person person;
        private static ObjectsServiceClient client = new ObjectsServiceClient();

        public RepoService(Person p)
        {
            person = p;
        }

        public static int GetNumberFromUser()
        {
            Console.WriteLine("Choose a number");
            string input = Console.ReadLine();
            int number = -1;
            if (!Int32.TryParse(input, out number))
            {
                Console.WriteLine("Chose number is incorrect... Choose again");
                input = Console.ReadLine();
            }

            return number;
        }

        private static Movie[] ShowMovies()
        {
            Movie[] movies = client.GetAllMovies();
            Console.WriteLine("All movies:");
            foreach (var movie in movies)
            {
                Console.WriteLine(movie.Id + ". " + movie.Title);
            }

            return movies;
        }

        public void AddReview()
        {
            Movie[] movies = ShowMovies();

            int number = GetNumberFromUser();

            foreach (var movie in movies)
            {
                if (movie.Id == number)
                {
                    Console.WriteLine("Put Your opinion about: " + movie.Title);
                    String content = Console.ReadLine();
                    Console.WriteLine("Score: ");
                    int score = -1;
                    while (score < 0 || score > 100)
                    {
                        score = GetNumberFromUser();
                    }

                    Review review = new Review();
                    review.Content = content;
                    review.MovieId = number;
                    review.Score = score;
                    review.Author = person;
                    client.AddReview(review);
                }

            }

        }

        private static Review[] ShowReview()
        {
            Review[] reviews = client.GetAllReviews(person);
            Console.WriteLine("Your reviews:");
            foreach (var review in reviews)
            {
                Console.WriteLine(review.Id + ". " + review.Content);
            }

            return reviews;
        }

        public void EditReview()
        {
            Review[] reviews = ShowReview();

            int number = GetNumberFromUser();
            foreach (var review in reviews)
            {
                if (review.Id == number)
                {
                    Console.WriteLine("Put new score or enter to exit");
                    int score = GetNumberFromUser();
                    review.Score = score;
                    client.UpdateReview(review);
                }
            }
        }

        public void ShowReviewForFilm()
        {
            Movie[] movies = ShowMovies();
            int number = GetNumberFromUser();
            foreach (var movie in movies)
            {
                if (movie.Id == number)
                {
                    Review[] reviewsForMovie = client.GetAllReviewsForMovie(movie);
                    foreach (var review in reviewsForMovie)
                    {
                        Console.WriteLine("Author: " + review.Author + " score: " + review.Score);
                    }
                    Console.WriteLine("Average sscore is : " + GetAverage(reviewsForMovie));

                }
            }
        }

        private int GetAverage(Review[] reviews)
        {
            int sum = 0;
            foreach (var review in reviews)
            {
                sum += review.Score;
            }

            return sum / reviews.Length;
        }

        public void AddMovie()
        {
            Console.WriteLine("Put Title");
            String title = Console.ReadLine();
            int releaseYear = GetNumberFromUser();

            Movie movie = new Movie();
            movie.Title = title;
            movie.ReleaseYear = releaseYear;

            client.AddMovie(movie);
        }

        public void RemoveReview()
        {
            Review[] reviews = ShowReview();
            int number = GetNumberFromUser();
            foreach (var review in reviews)
            {
                if (review.Id == number)
                {
                    Console.WriteLine("Are you sure you want to remove review ? (Y/N)");
                    string input = Console.ReadLine();
                    if (input == "Y")
                    {
                        client.DeleteReview(number);
                        Console.WriteLine("Review was deleted");
                    }
                }
            }
        }
    }
}

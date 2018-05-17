using System;
using System.Linq;
using MzlLab3Client.ServiceReference1;

namespace MzlLab3Client
{
    class Program
    {

        private  static ObjectsServiceClient client = new ObjectsServiceClient();

        static void Main(string[] args)
        {
            Console.WriteLine("Press Key ... If you want to exit press q");
            var sign = Console.ReadKey().KeyChar;
            while (sign != 'q')
            {
                Console.WriteLine("");
                
                InitMenu();
                Console.WriteLine("Press q if you want to exit");
                sign = Console.ReadKey().KeyChar;
            }
        }

        private static Person ReadPersonData()
        {
            Console.WriteLine("Hello! Put name : ");
            String nameAndSurname = "";

            while (nameAndSurname == null || !nameAndSurname.Contains(' ')) { 
            
                Console.WriteLine("Name and surname: ");
                nameAndSurname = Console.ReadLine();
            }

            Console.WriteLine("Name is ok");

            Person person = new Person();
            String[] names = nameAndSurname.Split(' ');
            person.Surname = names[0];
            person.Name = names[1];

            client.AddPerson(person);
            return person;
        }

        private static void InitMenu()
        {
            RepoService reposervice = new RepoService(ReadPersonData());

            Boolean isEnd = false;

            while (!isEnd)
            {
                Console.WriteLine("Add Review Press 1");
                Console.WriteLine("Edit Review Press 2");
                Console.WriteLine("Remove Review Press 3");
                Console.WriteLine("Show Reviews Press 4");
                Console.WriteLine("Add film Press 5");

                int number = RepoService.GetNumberFromUser();

                switch (number)
                {
                    case 1:
                        reposervice.AddReview();
                        break;
                    case 2:
                        reposervice.EditReview();
                        break;
                    case 3:
                        reposervice.RemoveReview();
                        break;
                    case 4:
                        reposervice.ShowReviewForFilm();
                        break;
                    case 5:
                        reposervice.AddMovie();
                        break;
                    default:
                        isEnd = true;
                        break;
                }
            }
        }


    }
}

namespace _13laba
{
    interface IPublisher
    {
        void SetBookInfo(string title, string author);
    }

    interface IBook : IPublisher
    {
        void SetPublicationInfo(DateTime publicationDate, int pageCount);
    }

    class Book : IBook
    {
        private string title;
        private string author;
        private DateTime publicationDate;
        private int pageCount;

        public void SetBookInfo(string title, string author)
        {
            this.title = title;
            this.author = author;
        }

        public void SetPublicationInfo(DateTime publicationDate, int pageCount)
        {
            this.publicationDate = publicationDate;
            this.pageCount = pageCount;
        }

        public void DisplayBookInfo()
        {
            Console.WriteLine($"Название: {title}");
            Console.WriteLine($"Автор: {author}");
            Console.WriteLine($"Дата публикации: {publicationDate}");
            Console.WriteLine($"Количество страницt: {pageCount}");
        }
    }

    interface IUser
    {
        void SetLoginAndPassword(string login, string password);
    }

    class User : IUser
    {
        private string login;
        private string password;

        public void SetLoginAndPassword(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public void DisplayUserInfo()
        {
            Console.WriteLine($"Login: {login}");
            Console.WriteLine($"Password: {password}");
        }
    }

    class ProductUser : IUser, IPublisher
    {
        private string login;
        private string password;
        private string title;
        private string author;

        public void SetLoginAndPassword(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public void SetBookInfo(string title, string author)
        {
            this.title = title;
            this.author = author;
        }

        public void BuyBook()
        {
            Console.WriteLine($"Пользователь с ником '{login}' купил книгу '{title}' за авторством '{author}'.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book();
            Book book2 = new Book();
            User user1 = new User();
            User user2 = new User();
            ProductUser productUser = new ProductUser();

            book1.SetBookInfo("1984", "Джордж Оруэлл");
            book1.SetPublicationInfo(new DateTime(1949, 6, 8), 320);

            book2.SetBookInfo("Идиот", "Достоевский Ф. М.");
            book2.SetPublicationInfo(new DateTime(1968, 1, 1), 700);


            user1.SetLoginAndPassword("user1", "password1");
            user2.SetLoginAndPassword("user2", "password2");


            productUser.SetBookInfo("Book3", "Author3");
            productUser.SetLoginAndPassword("user3", "password3");

            Console.WriteLine("Book1 info:");
            book1.DisplayBookInfo();

            Console.WriteLine("\nBook2 info:");
            book2.DisplayBookInfo();


            Console.WriteLine("\nUser1 info:");
            user1.DisplayUserInfo();

            Console.WriteLine("\nUser2 info:");
            user2.DisplayUserInfo();


            productUser.BuyBook();

            Console.ReadLine();
        }
    }
}
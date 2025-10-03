using System;

namespace posts
{
   class Program
    {
        static void Main(string[] args)
        {
            GuestBook guestbook = new GuestBook();
            int i = 0;

            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("Gästbok\n\n");

                Console.WriteLine("1. Skapa inlägg");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("3. Avsluta\n\n");

                i = 0;
                Console.WriteLine("Inlägg");
                foreach (Post post in guestbook.getPosts())
                {
                    Console.WriteLine($"[{i}] {post.Owner} - {post.Content}");
                    i++;
                }

                int inp = (int)Console.ReadKey(true).Key;
                switch (inp)
                {
                    case '1':
                        Console.CursorVisible = true;
                        Console.Write("Ange författare: ");
                        string owner = Console.ReadLine() ?? "";
                        Console.Write("Ange inlägg: ");
                        string content = Console.ReadLine() ?? "";

                        if (!String.IsNullOrWhiteSpace(owner) && !String.IsNullOrWhiteSpace(content))
                        {
                            guestbook.AddPost(owner, content);
                        }
                        else
                        {
                            Console.WriteLine("Du måste skriva både författare och inlägg!");
                            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                            Console.ReadKey(true);
                        }
                        break;

                    case '2':
                        Console.CursorVisible = true;
                        Console.Write("Ange index att radera: ");
                        string? index = Console.ReadLine();
                        if (!String.IsNullOrEmpty(index))
                        {
                            try
                            {
                                guestbook.removePost(Convert.ToInt32(index));
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Felaktigt index. Tryck på valfri tangent för att fortsätta.");
                                Console.ReadKey(true);
                            }
                        }
                        break;

                    case '3':
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}

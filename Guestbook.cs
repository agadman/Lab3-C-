using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace posts 
{
    public class GuestBook
    {
        private string filename = @"guestbook.json";

        private List<Post> posts = new List<Post>();

        public GuestBook()
        {
            if (File.Exists(filename))
            {
                string jsonString = File.ReadAllText(filename);

                if (!string.IsNullOrWhiteSpace(jsonString)) 
                {
                    posts = JsonSerializer.Deserialize<List<Post>>(jsonString)!;
                }
                else
                {
                    posts = new List<Post>(); 
                }
            }
        }

        public Post AddPost(string owner, string content)
        {
            Post obj = new Post();
            obj.Owner = owner;
            obj.Content = content;
            posts.Add(obj);
            marshal();
            return obj;
        }

        public int removePost(int index)
        {
            posts.RemoveAt(index);
            marshal();
            return index;
        }

        public List<Post> getPosts()
        {
            return posts;
        }

        private void marshal()
        {
            string jsonString = JsonSerializer.Serialize(posts);
            File.WriteAllText(filename, jsonString);
        }
    }
}
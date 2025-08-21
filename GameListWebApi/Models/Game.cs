using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace GameListWebApi.Models
{
    public class Game
    {  
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Game(int id,string title,string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}

using RestaurantAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {

                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = 10.30M,
                        },
                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 5.30M,
                        },
                    },

                    Address = new Address()
                    {
                        City = "Bydgoszcz",
                        Street = "Fordońska",
                        PostalCode = "85-799"
                    }
                },
                new Restaurant()
                {
                    Name = "McDonald",
                    Category = "Fast Food",
                    Description = "Something about McDonald",
                    ContactEmail = "contact@mcdonald.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Cheeseburger",
                            Price = 5.20M,
                        },
                    },
                    Address = new Address()
                    {
                         City = "Bydgoszcz",
                         Street = "Jagiellońska",
                        PostalCode = "85-791"
                    }
                }
            };

            return restaurants;
        }
    }
}

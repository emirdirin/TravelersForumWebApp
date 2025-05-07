using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Homework1.Models;
using System.Security.Cryptography.X509Certificates;

namespace Homework1.Models{

    public static class Repository{
        //private static List<Place> _places = new();
        
        private static DbContextOptions<PlaceDbContext> _options = new DbContextOptionsBuilder<PlaceDbContext>()
            .UseSqlite("Data Source=placesDB.db")  
            .Options;
            public static List<Place> Places {
            get
            {
                using (var context = new PlaceDbContext(_options))
                {
                    return context.Places.ToList(); 
                }
            }
        }
        public static void createPlace(Place newPlace){
            
            
            newPlace.submissionDate = DateTime.Now;  
                
            
            using (var context = new PlaceDbContext(_options))
            {
                context.Places.Add(newPlace);
                newPlace.Id = Places.Count + 1;
                context.SaveChanges();  
            }
           // _places.Add(newPlace);    
        }
        public static Place? getById(int id)
        {
            using (var context = new PlaceDbContext(_options))  
            {
                return context.Places.FirstOrDefault(p => p.Id == id);  
            }
        }

        public static void deleteById(int id){
             using (var context = new PlaceDbContext(_options)) 
            {
                var place =context.Places.FirstOrDefault(p => p.Id == id);  
                if (place != null) {
                  context.Places.Remove(place);
                  context.SaveChanges();
                  }
                  
            }
        }
    }
}
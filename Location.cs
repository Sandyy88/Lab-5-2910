using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_2910
{
    public class Location 
    {
        public Street Street { get; set; } = new Street();
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public object Postcode { get; set; } = string.Empty; //This may sometimes be considered a int or a string
        public Coordinates Coordinates { get; set; } = new Coordinates();
        public Timezone Timezone { get; set; } 

        public Location() { }
        public Location(Street street, string city, string state, string country, object postcode, Coordinates coordinates, Timezone timezone)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            Postcode = postcode;
            Coordinates = coordinates;
            Timezone = timezone;
        }

        public override string ToString()
        {
            string s = " ";
            s += $"\n\n\tLOCATION INFO:" +
               $"\n\t\tStreet: {Street?.Number} {Street?.Name}" +
               $"\n\t\tCity: {City}" +
               $"\n\t\tState: {State}" +
               $"\n\t\tCountry: {Country}" +
               $"\n\t\tPostcode: {Postcode}" +
               $"\n\t\tCoordinates: " +
               $"\n\t\t\tLatitude: {Coordinates?.Latitude}" +
               $"\n\t\t\tLongitude: {Coordinates?.Longitude}" +
               $"\n\t\tTimezone: " +
               $"\n\t\t\tOffset: {Timezone?.Offset}" +
               $"\n\t\t\tDescription: {Timezone?.Description}";

            return s;
        }
    }
}

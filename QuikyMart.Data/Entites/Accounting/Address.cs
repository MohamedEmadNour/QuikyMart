﻿namespace QuikyMart.Data.Entites.Accounting
{
    public class Address
    {
        public int Id { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AppUserID { get; set; }
        public AppUser AppUser { get; set; }




    }
}
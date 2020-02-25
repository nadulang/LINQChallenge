﻿using System.Net;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.IO;
using Newtonsoft.Json;

namespace LinqChallenge
{
    //Nomor 1
    public class Users
    {
        public int id { get; set; }
        public string username { get; set; }
        public Profile1 profile { get; set; }
        

        [JsonProperty("articles:")] 
        public List<articles1> articles { get; set; }
    }

    public class Profile1
    {
        public string full_name { get; set; }
        public string birthday { get; set; }
        public List<string> phones { get; set; }
    }

    public class articles1
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTimeOffset published_at { get; set; }
    }


    //Nomor 2

    public class Orders
    {
        public string order_id { get; set; }
        public DateTimeOffset created_at { get; set; }
        public Customer customer { get; set; }
        public List<Items> items { get; set; }
    }

    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Items
    {
        public int id { get; set; }
        public string name { get; set; }
        public int qty { get; set; }
        public int price { get; set; }
    }
 

 //Nomor 3

public class Inventories
{
    public int inventory_id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public List<string> tags { get; set; }
    public int purchased_at { get; set; }
    public Placement placement { get; set; }
}

public class Placement
{
    public int room_id { get; set; }
    public string name { get; set; }
}


    class Program
    {
        static void Main(string[] args)
        {
           //Nomor 1

            var jsonfile = File.ReadAllText(@"/Users/gigaming/Projects/LinqChallenge/Users.json");
            var listUsers = JsonConvert.DeserializeObject<List<Users>>(jsonfile);
            
           
           //noPhoneNumbers
            // var noPhoneNumbers = listUsers.Where( n => n.profile.phones.Count() == 0).Select( n => $"No Phone numbers: {n.username}");

            // Console.WriteLine(String.Join(", ", noPhoneNumbers));

            //whohas articles
            // var whohasarticles = listUsers.Where( n => n.articles.Count() > 0).Select( n => $"who has articles: {n.username}");
            // Console.WriteLine(String.Join(", ", whohasarticles));

            //who has "annis"
            // var whohasannis = listUsers.Where( n => n.profile.full_name.ToLower().Contains("annis")).Select( n => $"who has annis : {n.username}");
            // Console.WriteLine(String.Join(", ", whohasannis));

            //who has articles posted in 2020
            // var who2020 = listUsers.Where( n => n.articles.Any( s => s.published_at.Year == 2020)).Select( n => $"who has article in: {n.username}");
            // Console.WriteLine(String.Join(", ", who2020)); 

            //who has born in 1986
            // var whoborn = listUsers.Where( n => n.profile.birthday.Contains("1986")).Select( n => $"who is born in 1986 : {n.username}");
            // Console.WriteLine(String.Join(", ", whoborn));

            //who has tips on the title
            // var whichonehastips = listUsers.SelectMany( n => n.articles.Where(s => s.title.ToLower().Contains("tips")).Select( s => $"which one:  {s.title}"));
            // Console.WriteLine(String.Join(", ", whichonehastips));

            //articles published before august 2019
            // var whobef = listUsers.SelectMany( n => n.articles.Where( s => s.published_at.Month < 08).Select( s => $"what article that posted before august: {s.title}"));
            // Console.WriteLine(String.Join(", ", whobef)); 



            
            //Nomor 2
            var jsonfileorder = File.ReadAllText(@"/Users/gigaming/Projects/LinqChallenge/Orders.json");
            var listOrders = JsonConvert.DeserializeObject<List<Orders>>(jsonfileorder);

            //purchases in february
            // var purchases = listOrders.Where( h => h.created_at.Month == 2).
            //                 Select( h => $"all purchases in february: {h.order_id}");
            // Console.Write(String.Join(", ", purchases));

            //All purchases by Ari
            // var ari = listOrders.Where( l => l.customer.name.ToLower() == "ari").Sum( b => b.items.Sum( p => p.qty * p.price));
            // Console.Write(String.Join(", ", ari));

            //Grand Total
            var GrandTotal = listOrders.GroupBy( m => m.customer.name).Select(x => new {ppl = x. } ))
           
            
        }

        
                            
            
    }
    
}

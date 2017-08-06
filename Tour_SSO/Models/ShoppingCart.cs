using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_SSO.Models
{
    public class ShoppingCart
    {
        public List<Tour> Items = new List<Tour>();

        public void Add(int Id)
        {
            try
            {
                var Item = Items.Single(p => p.TourId == Id);
                Item.Booked++;
            }
            catch
            {
                UnitOfWork dbc = new UnitOfWork(new TourEntities());               
                var Item = dbc.TourRepo.GetById(Id);
                Item.Booked = 1;
                Items.Add(Item);
            }
        }

        public void Remove(int Id)
        {
            var Item = Items.Single(p => p.TourId == Id);
            Items.Remove(Item);
        }

        public void Update(int Id, int newQuantity)
        {
            var Item = Items.Single(p => p.TourId == Id);
            Item.Booked = newQuantity;
        }

        public void Clear()
        {
            Items.Clear();
        }

        public double? Amount
        {
            get
            {
                var amount = Items.Sum(p => p.Price * p.Booked);
                return amount;
            }
        }

        public int? Count
        {
            get
            {
                var count = Items.Sum(p => p.Booked);
                return count;
            }
        }

        public double? getItemAmount(int Id)
        {
            var Item = Items.Single(p => p.TourId == Id);
            return Item.Price * Item.Booked;
        }

        //--TRUY XUẤT GIỎ HÀNG TRONG SESSION--//
        public static ShoppingCart Cart
        {
            get
            {
                var cart = HttpContext.Current.Session["ShoppingCart"] as ShoppingCart;
                if (cart == null)
                {
                    cart = new ShoppingCart();
                    HttpContext.Current.Session["ShoppingCart"] = cart;
                }
                return cart;
            }
        }
    }
}
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
           using var context = new SignalRContext();
            return context.Orders.Count(o => o.Description == "Müşteri Masada");
        }

        public decimal LastOrderPrice()
        {
            using var context = new SignalRContext();
            return context.Orders.OrderByDescending(x=>x.OrderID).Take(1).Select(y=>y.TotalAmount).FirstOrDefault();
        }

        //public decimal TodayTotalPrice()
        //{
        //    using var context = new SignalRContext();
        //    return context.Orders.Where(o => o.Date == DateTime.Parse(DateTime.Now.ToShortDateString())).Sum(o => o.TotalAmount);
        //}

        public decimal TodayTotalPrice()
        {
            using var context = new SignalRContext();
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            return context.Orders
                .Where(o => o.Date >= today && o.Date < tomorrow)
                .Sum(o => o.TotalAmount);
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();
        }
    }
}

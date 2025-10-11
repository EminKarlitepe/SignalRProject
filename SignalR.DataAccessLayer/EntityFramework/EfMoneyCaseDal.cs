using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using SignalR.EntiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        public EfMoneyCaseDal(SignalRContext context) : base(context)
        {
        }

        public decimal TotalMoneyCaseAmount()
        {
            using var context = new SignalRContext();
            return context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
        }

        public void AddTotalMoneyCaseAmount(decimal amount)
        {
            using var context = new SignalRContext();

            var moneyCase = context.MoneyCases.FirstOrDefault();

            if (moneyCase != null)
            {
                moneyCase.TotalAmount += amount;

                context.SaveChanges();
            }
        }
    }
}
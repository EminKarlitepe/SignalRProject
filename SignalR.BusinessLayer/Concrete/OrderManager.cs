using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IBasketService _basketService;
        public OrderManager(IOrderDal orderDal, IOrderDetailService orderDetailService, IBasketService basketService)
        {
            _orderDal = orderDal;
            _orderDetailService = orderDetailService;
            _basketService = basketService;
        }

        public int TActiveOrderCount()
        {
            return _orderDal.ActiveOrderCount();
        }

        public void TAdd(Order entity)
        {
            _orderDal.Add(entity);
        }

        public void TDelete(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> TGetListAll()
        {
            return _orderDal.GetListAll();
        }

        public decimal TLastOrderPrice()
        {
            return _orderDal.LastOrderPrice();
        }

        public decimal TTodayTotalPrice()
        {
            return _orderDal.TodayTotalPrice();
        }

        public int TTotalOrderCount()
        {
            return _orderDal.TotalOrderCount();
        }

        public void TUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }

        public void TCompleteOrder(int tableNumber, decimal totalPrice)
        {
            var baskets = _basketService.TGetBasketByMenuTableNumber(tableNumber);
            
            var order = new Order
            {
                TableNumber = tableNumber.ToString(),
                Description = "Müşteri Masada",
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                Status = true
            };
            _orderDal.Add(order);
            
            var createdOrder = _orderDal.GetLastOrder();
            if (createdOrder != null && baskets != null && baskets.Count > 0)
            {
                _orderDetailService.TCreateOrderDetails(createdOrder.OrderID, baskets);
            }
        }
    }
}

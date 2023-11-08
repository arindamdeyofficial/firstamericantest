using BusinessModel.Requests;
using Logging;
using Microsoft.EntityFrameworkCore;
using Repository.Entity;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SampleApiDbContext _db;
        private readonly ILoggerHelper _logger;
        public OrderRepository(SampleApiDbContext db, ILoggerHelper logger) 
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<OrderModel>> GetOrders(CreateOrderRequest ord)
        {
            List<OrderModel> res = new List<OrderModel>();
            if(ord == null)
            {
                res = await _db.Orders.Select(x => new OrderModel
                {
                    Desc = x.Desc,
                    EntryDate = x.EntryDate,
                    Id = x.Id,
                    IsDeleted = x.IsDeleted,
                    IsInvoiced = x.IsInvoiced,
                    Name = x.Name
                }).ToListAsync();
            }
            else
            {
               res = await _db.Orders.Where(a =>
                                //isrecent
                                (!a.IsDeleted && (a.EntryDate >= DateTime.Now.AddDays(-1)))
                                //&& ((a.EntryDate >= ((ord.StartDate == null) ? DateTime.MinValue : ord.StartDate))
                                //&& (a.EntryDate <= ((ord.EndDate == null) ? DateTime.MinValue : ord.EndDate))
                                //)//numberofdays
                            ).Select(x => new OrderModel
                            { 
                                Desc = x.Desc,
                                EntryDate = x.EntryDate,
                                Id = x.Id,
                                IsDeleted = x.IsDeleted,
                                IsInvoiced = x.IsInvoiced,
                                Name = x.Name
                            }).ToListAsync();
            }
            
            return res;
        }

        public async Task<bool> SubmitOrder(OrderEntity ord)
        {
            bool IsSuccess = true;
            try
            {
                _db.Orders.Add(ord);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                IsSuccess = false;
            }
            return IsSuccess;
        }
    }
}
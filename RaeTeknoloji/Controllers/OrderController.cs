using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReaTeknoloji.Data.Context;
using ReaTeknoloji.Data.Dto;
using ReaTeknoloji.Data.Models;
using ReaTeknoloji.DataAccess.UnitOfWork;
using System.Net;

namespace ReaTeknoloji.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        MasterContext _context = new MasterContext();

        [HttpPost("CreateOrder")]
        public async Task<Response<string>> CreateOrder(AddOrderRequestDto requestDto)
        {
            try
            {
                using (UnitOfWork unitOf = new UnitOfWork(_context))
                {
                    unitOf.GetRepository<Order>().Add(new Order()
                    {
                        AddressId = requestDto.AddressId,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        CustomerId = requestDto.CustomerId,
                        Price = requestDto.Price,
                        Quantity = requestDto.Quantity,
                        ProductId = requestDto.ProductId,
                        Status = requestDto.Status,
                    });
                    if (unitOf.SaveChanges() == 1)
                        return new Response<string>()
                        {
                            IsSuccess = true,
                            Message = "Created order",
                            Status = HttpStatusCode.Created
                        };
                    else
                        return new Response<string>()
                        {
                            IsSuccess = false,
                            Message = "Not created order",
                            Status = HttpStatusCode.BadRequest
                        };
                }
            }
            catch (Exception ex)
            {
                return new Response<string>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Status = HttpStatusCode.BadRequest
                };
            }
        }

        [HttpPut("UpdateOrder")]
        public async Task<Response<string>> UpdateOrder(UpdateOrderRequestDto requestDto)
        {
            var order = new Order();
            try
            {
                using (UnitOfWork unitOf = new UnitOfWork(new MasterContext()))
                {
                    order = unitOf.GetRepository<Order>().Get(requestDto.OrderId);
                }
                if (order != null)
                {
                    using (UnitOfWork unitOf = new UnitOfWork(_context))
                    {
                        unitOf.GetRepository<Order>().Update(new Order()
                        {
                            Id = requestDto.OrderId,
                            AddressId = requestDto.AddressId,
                            CustomerId = requestDto.CustomerId,
                            Price = requestDto.Price,
                            ProductId = requestDto.ProductId,
                            Quantity = requestDto.Quantity,
                            Status = requestDto.Status,
                            UpdatedAt = DateTime.Now,
                            CreatedAt = order.CreatedAt
                        });
                        if (unitOf.SaveChanges() == 1)
                            return new Response<string>()
                            {
                                IsSuccess = true,
                                Message = "Completed",
                                Status = HttpStatusCode.OK
                            };
                        else
                            return new Response<string>()
                            {
                                IsSuccess = false,
                                Message = "Fail",
                                Status = HttpStatusCode.BadRequest
                            };
                    }
                }
                else
                    return new Response<string>()
                    {
                        IsSuccess = false,
                        Message = "Order not found",
                        Status = HttpStatusCode.NotFound
                    };
            }
            catch (Exception ex)
            {
                return new Response<string>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Status = HttpStatusCode.NotFound
                };
            }
            
        }

        [HttpDelete("DeleteOrder")]
        public async Task<Response<string>> DeleteOrder(int Id)
        {
            try
            {
                using (UnitOfWork unitOf = new UnitOfWork(_context))
                {
                    unitOf.GetRepository<Order>().Delete(unitOf.GetRepository<Order>().Get(Id));
                    if (unitOf.SaveChanges() == 1)
                        return new Response<string>()
                        {
                            Status = HttpStatusCode.OK,
                            Message = "Success",
                            IsSuccess = true
                        };
                    else
                        return new Response<string>()
                        {
                            Status = HttpStatusCode.NotFound,
                            Message = "Order not found",
                            IsSuccess = false
                        };
                };
            }
            catch (Exception ex)
            {
                return new Response<string>()
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    IsSuccess = false
                }; ;

            }

        }

        [HttpGet("GetOrder")]
        public async Task<Response<GetOrderResponse>> GetOrder(int Id)
        {
            try
            {
                using (UnitOfWork unitOf = new UnitOfWork(_context))
                {
                    var order = unitOf.GetRepository<Order>().Get(Id);
                    if (order != null)
                        return new Response<GetOrderResponse>()
                        {
                            Data = new GetOrderResponse()
                            {
                                Address = unitOf.GetRepository<Address>().Get(order.AddressId),
                                AddressId = order.AddressId,
                                CreatedAt = order.CreatedAt,
                                Customer = unitOf.GetRepository<Customer>().Get(order.CustomerId),
                                CustomerId = order.CustomerId,
                                Id = order.Id,
                                Price = order.Price,
                                Product = unitOf.GetRepository<Product>().Get(order.ProductId),
                                ProductId = order.ProductId,
                                Quantity = order.Quantity,
                                Status = order.Status,
                                UpdatedAt = order.UpdatedAt
                            },
                            IsSuccess = true,
                            Message = "Completed",
                            Status = HttpStatusCode.OK
                        };
                    else
                        return new Response<GetOrderResponse>()
                        {
                            IsSuccess = false,
                            Message = "Not found",
                            Status = HttpStatusCode.NoContent
                        };
                }
            }

            catch (Exception ex)
            {
                return new Response<GetOrderResponse>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Status = HttpStatusCode.NoContent
                };
            }
        }

        [HttpGet("GetOrderAll")]
        public async Task<Response<List<Order>>> GetOrderAll()
        {
            try
            {
                using (UnitOfWork unitOf = new UnitOfWork(_context))
                {
                    List<Order> orders = new List<Order>();
                    foreach (var item in unitOf.GetRepository<Order>().GetAll().ToList())
                    {
                        orders.Add(new Order()
                        {
                            Address = unitOf.GetRepository<Address>().Get(item.AddressId),
                            AddressId = item.AddressId,
                            CreatedAt = item.CreatedAt,
                            Customer = unitOf.GetRepository<Customer>().Get(item.CustomerId),
                            CustomerId = item.CustomerId,
                            Price = item.Price,
                            Product = unitOf.GetRepository<Product>().Get(item.ProductId),
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            Status = item.Status,
                            UpdatedAt = item.UpdatedAt,
                            Id = item.Id
                        });
                    }
                    if (orders.Count() > 0)
                        return new Response<List<Order>>
                        {
                            IsSuccess = true,
                            Data = orders,
                            Message = "Success",
                            Status = HttpStatusCode.OK
                        };
                    else
                        return new Response<List<Order>>
                        {
                            IsSuccess = false,
                            Message = "No content",
                            Status = HttpStatusCode.NoContent
                        };
                }
            }
            catch (Exception ex)
            {
                return new Response<List<Order>>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Status = HttpStatusCode.BadRequest
                };
            }
            
        }

        [HttpGet("GetOrderByCustomer")]
        public async Task<Response<List<Order>>> GetOrderByCustomer(int customerId)
        {
            try
            {
                using (UnitOfWork unitOf = new UnitOfWork(_context))
                {
                    List<Order> orders = new List<Order>();
                    foreach (var item in unitOf.GetRepository<Order>().GetAll(x => x.CustomerId == customerId).ToList())
                    {
                        orders.Add(new Order()
                        {
                            Address = unitOf.GetRepository<Address>().Get(item.AddressId),
                            AddressId = item.AddressId,
                            CreatedAt = item.CreatedAt,
                            Customer = unitOf.GetRepository<Customer>().Get(item.CustomerId),
                            CustomerId = item.CustomerId,
                            Price = item.Price,
                            Product = unitOf.GetRepository<Product>().Get(item.ProductId),
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            Status = item.Status,
                            UpdatedAt = item.UpdatedAt,
                            Id = item.Id
                        });
                    }
                    if (orders.Count() > 0)
                        return new Response<List<Order>>
                        {
                            IsSuccess = true,
                            Data = orders,
                            Message = "Success",
                            Status = HttpStatusCode.OK
                        };
                    else
                        return new Response<List<Order>>
                        {
                            IsSuccess = false,
                            Message = "No content",
                            Status = HttpStatusCode.NoContent
                        };
                }

            }
            catch (Exception ex)
            {
                return new Response<List<Order>>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Status = HttpStatusCode.BadRequest
                };
            }
        }
    }
}


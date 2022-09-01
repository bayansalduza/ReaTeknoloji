using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using ReaTeknoloji.Data.Context;
using ReaTeknoloji.Data.Dto;
using ReaTeknoloji.Data.Models;
using ReaTeknoloji.DataAccess.UnitOfWork;
using ReaTeknoloji.Helpers;
using System.Net;

namespace ReaTeknoloji.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private MasterContext _context = new MasterContext();

        [HttpPost("CreateCustomer")]
        public async Task<Response<string>> CreateCustomer(AddCustomerRequestDto requestDto)
        {
            try
            {
                using (UnitOfWork unitOf = new UnitOfWork(_context))
                {
                    unitOf.GetRepository<Customer>().Add(new Customer()
                    {
                        Email = requestDto.Email,
                        Name = requestDto.Name,
                        Password = requestDto.Password,
                        AddressId = requestDto.AddressId,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    });
                    if (unitOf.SaveChanges() == 1)
                        return new Response<string>()
                        {
                            IsSuccess = true,
                            Message = "Completed",
                            Status = HttpStatusCode.Created
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

        [HttpPut("UpdateCustomer")]
        public async Task<Response<string>> UpdateCustomer(UpdateCustomerRequestDto requestDto)
        {
            try
            {
                var customer = new Customer();
                using (UnitOfWork unitOf = new UnitOfWork(new MasterContext()))
                {
                    customer = unitOf.GetRepository<Customer>().Get(requestDto.CustomerId);
                }
                using (UnitOfWork unitOf = new UnitOfWork(_context))
                {
                    unitOf.GetRepository<Customer>().Update(new Customer()
                    {
                        Id = requestDto.CustomerId,
                        Name = requestDto.Name,
                        Password = requestDto.Password,
                        Email = requestDto.Email,
                        AddressId = requestDto.AddressId,
                        UpdatedAt = DateTime.Now,
                        CreatedAt = customer.CreatedAt
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

        [HttpDelete("DeleteCustomer")]
        public async Task<Response<string>> DeleteCustomer(int Id)
        {
            try
            {
                using (UnitOfWork unitOf = new UnitOfWork(_context))
                {
                    unitOf.GetRepository<Customer>().Delete(unitOf.GetRepository<Customer>().Get(Id));
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
                            Status = HttpStatusCode.BadRequest,
                            Message = "Failed",
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

        [HttpGet("GetCustomer")]
        public async Task<Response<GetCustomerResponse>> GetCustomer(int Id)
        {
            try
            {
                using (UnitOfWork unitOf = new UnitOfWork(_context))
                {
                    var customer = unitOf.GetRepository<Customer>().Get(Id);
                    if (customer != null)
                        return new Response<GetCustomerResponse>()
                        {
                            Data = new GetCustomerResponse()
                            {
                                Address = unitOf.GetRepository<Address>().Get(customer.AddressId),
                                AddressId = customer.AddressId,
                                Id = Id,
                                Email = customer.Email,
                                Name = customer.Name,
                                CreatedAt = customer.CreatedAt,
                                UpdatedAt = customer.UpdatedAt
                            },
                            IsSuccess = true,
                            Message = "Completed",
                            Status = HttpStatusCode.OK
                        };
                    else
                        return new Response<GetCustomerResponse>()
                        {
                            IsSuccess = false,
                            Message = "Not found",
                            Status = HttpStatusCode.NoContent
                        };
                }
            }

            catch (Exception ex)
            {
                return new Response<GetCustomerResponse>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Status = HttpStatusCode.NoContent
                };
            }
        }

        [HttpGet("GetCustomerAll")]
        public async Task<Response<List<Customer>>> GetCustomerAll()
        {
            try
            {
                using (UnitOfWork unitOf = new UnitOfWork(_context))
                {
                    List<Customer> customers = new List<Customer>();
                    foreach (var item in unitOf.GetRepository<Customer>().GetAll().ToList())
                    {
                        customers.Add(new Customer()
                        {
                            Address = unitOf.GetRepository<Address>().Get(item.AddressId),
                            AddressId = item.AddressId,
                            CreatedAt = item.CreatedAt,
                            CurrentToken = item.CurrentToken,
                            Email = item.Email,
                            Id = item.Id,
                            Name = item.Name,
                            Password = item.Password,
                            UpdatedAt = item.UpdatedAt
                        });
                    }
                    if (customers.Count() > 0)
                        return new Response<List<Customer>>
                        {
                            IsSuccess = true,
                            Data = customers,
                            Message = "Success",
                            Status = HttpStatusCode.OK
                        };
                    else
                        return new Response<List<Customer>>
                        {
                            IsSuccess = false,
                            Message = "No content",
                            Status = HttpStatusCode.NoContent
                        };
                }
            }
            catch (Exception ex)
            {
                return new Response<List<Customer>>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Status = HttpStatusCode.NoContent
                };
            }
        }

        [HttpGet("Validate")]
        public async Task<Response<ValidateResponse>> Validate(string email, string password)
        {
            try
            {
                var customer = new Customer();
                using (UnitOfWork unitOf = new UnitOfWork(_context))
                {
                    customer = unitOf.GetRepository<Customer>().Get(x => x.Email == email);
                }
                using (UnitOfWork unitOf = new UnitOfWork(new MasterContext()))
                {
                    if (customer != null)
                    {
                        var token = new JwtManager(_context).Get(email, password);
                        if (!string.IsNullOrEmpty(token))
                        {
                            unitOf.GetRepository<Customer>().Update(new Customer()
                            {
                                Id = customer.Id,
                                Name = customer.Name,
                                Email = customer.Email,
                                AddressId = customer.AddressId,
                                UpdatedAt = DateTime.Now,
                                CreatedAt = customer.CreatedAt,
                                CurrentToken = token,
                            });
                            unitOf.SaveChanges();
                            return new Response<ValidateResponse>
                            {
                                Data = new ValidateResponse() { Token = token },
                                IsSuccess = true,
                                Message = "Success",
                                Status = HttpStatusCode.OK
                            };
                        }
                        return new Response<ValidateResponse>
                        {
                            IsSuccess = false,
                            Message = "Failed",
                            Status = HttpStatusCode.Unauthorized
                        };
                    }
                    else
                        return new Response<ValidateResponse>
                        {
                            IsSuccess = false,
                            Message = "Failed",
                            Status = HttpStatusCode.Unauthorized
                        };
                }
            }
            catch (Exception ex)
            {
                return new Response<ValidateResponse>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Status = HttpStatusCode.Unauthorized
                };
            }

        }
    }
}

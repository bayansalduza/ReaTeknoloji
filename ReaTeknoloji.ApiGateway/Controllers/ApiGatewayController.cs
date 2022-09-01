using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReaTeknoloji.ApiGateway.Models;
using ReaTeknoloji.ApiGateway.Properties;
using System.Text.Json;
using System.Text;
using System.Net;
using System;
using Newtonsoft.Json;
using ReaTeknoloji.ApiGateway.Helpers;

namespace ReaTeknoloji.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiGatewayController : ControllerBase
    {
        public CreateClient _client = new CreateClient();

        [HttpPost("CreateCustomer")]
        public async Task<ActionResult> CreateCustomer(AddCustomerRequestDto requestDto)
        {
            try
            {
                var response = await _client.CreateCustomerAsync(requestDto);
                if (response.IsSuccess == true)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Validate")]
        public async Task<ActionResult> Validate(string email, string password)
        {
            try
            {
                var response = await _client.ValidateAsync(email, password);
                if (response.IsSuccess == true)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCustomer")]
        public async Task<ActionResult> UpdateCustomer(UpdateCustomerRequestDto requestDto)
        {
            try
            {
                var response = await _client.UpdateCustomerAsync(requestDto);
                if (response.IsSuccess == true)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteCustomer")]
        public async Task<ActionResult> DeleteCustomer(int Id)
        {
            try
            {
                var response = await _client.DeleteCustomerAsync(Id);
                if (response.IsSuccess == true)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCustomer")]
        public async Task<ActionResult> GetCustomer(int Id)
        {
            try
            {
                var response = await _client.GetCustomerAsync(Id);
                if (response.IsSuccess == true)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCustomerAll")]
        public async Task<ActionResult> GetCustomerAll()
        {
            try
            {
                var response = await _client.GetCustomerAllAsync();
                if (response.IsSuccess == true)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateOrder")]
        public async Task<ActionResult> CreateOrder(AddOrderRequestDto requestDto)
        {
            try
            {
                var response = await _client.CreateOrderAsync(requestDto);
                if (response.IsSuccess == true)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateOrder")]
        public async Task<ActionResult> UpdateOrder(UpdateOrderRequestDto requestDto)
        {
            try
            {
                var response = await _client.UpdateOrderAsync(requestDto);
                if (response.IsSuccess == true)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteOrder")]
        public async Task<ActionResult> DeleteOrder(int Id)
        {
            try
            {
                var response = await _client.DeleteOrderAsync(Id);
                if (response.IsSuccess == true)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetOrderAll")]
        public async Task<ActionResult> GetOrderAll()
        {
            try
            {
                var response = await _client.GetOrderAllAsync();
                if (response.IsSuccess == true)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetOrderByCustomer")]
        public async Task<ActionResult> GetOrderByCustomer(int Id)
        {
            try
            {
                var response = await _client.GetOrderByCustomer(Id);
                if (response.IsSuccess == true)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

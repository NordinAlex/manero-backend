using Manero_backend.DTOs.Order;
using Manero_backend.DTOs.ProductItem;
using Manero_backend.Interfaces.Order;
using Manero_backend.Interfaces.OrderLine;
using Manero_backend.Models.OrderEntities;
using Manero_backend.Models.UserEntities;
using Manero_backend.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manero_backend_tests.UnitTests
{
    public class OrderService_Tests
    {
        private Mock<IOrderRepository> _orderRepo;
        private IOrderService _orderService;
        private Mock<IOrderLineRepository> _lineRepo;
        private IOrderLineService _orderLineService;

        public OrderService_Tests()
        {
            _orderRepo = new Mock<IOrderRepository>();
            _orderService = new OrderService(_orderRepo.Object, _orderLineService!);
            _lineRepo = new Mock<IOrderLineRepository>();
            _orderLineService = new OrderLineService(_lineRepo.Object);
        }

        //[Fact]

        //public async Task Create_Should_Create_New_Order_And_OrderLine_And_Return_OrderResponse()
        //{
        //    //arrange
        //    OrderRequest req = new OrderRequest()
        //    {
        //        Address = "Address 1",
        //        City = "City 1",
        //        PostalCode = "12345",
        //        OrderDate = DateTime.Now,
        //        ProductItems = new List<ProductItemOrderModel>
        //        {
        //            new ProductItemOrderModel { Id = 1, Name = "Product 1", Price = 20, Quantity = 1 }
        //        }
        //    };
        //    UserEntity user = new UserEntity()
        //    {
        //        FirstName = "Test",
        //        LastName = "Test",
        //        Id = "Something test"
        //    };

        //    OrderEntity order = new OrderEntity()
        //    {
        //        Id = 1,
        //        UserId = "Something test",
        //        CustomerName = "Test Test",
        //        Address = "Address 1",
        //        City = "City 1",
        //        PostalCode = "12345",
        //        OrderDate = DateTime.Now,
        //        TotalPrice = 100,
        //        OrderLines = new List<OrderLineEntity>
        //        {
        //           new OrderLineEntity{ OrderId = 1, ProductItemId = 1, Price = 20, Quantity= 1, ProductName = "Product 1", UnitPrice = 20 }

        //        }
        //    };

        //    OrderLineEntity orderline = new OrderLineEntity() { OrderId = 1, ProductItemId = 1, Price = 20, Quantity = 1, ProductName = "Product 1", UnitPrice = 20 };

        //    _orderRepo.Setup(x => x.CreateOrderAsync(It.IsAny<OrderEntity>())).ReturnsAsync(order);

        //    //act

        //    var result = await _orderService.CreateOrderAsync(req, user);

        //    //assert

        //    Assert.NotNull(result);
        //    Assert.IsType<OrderResponse>(result);
        //}
        [Fact]
        public async Task GetOrdersForUser_Should_Get_Orders_With_Users_Id()
        {
            //Arrange
            var orders = new List<OrderEntity>()
            {

                new OrderEntity()
                    {
                        Id = 1,
                        UserId = "Something test",
                        CustomerName = "Test Test",
                        Address = "Address 1",
                        City = "City 1",
                        PostalCode = "12345",
                        OrderDate = DateTime.Now,
                        TotalPrice = 100,
                        OrderLines = new List<OrderLineEntity>
                        {
                           new OrderLineEntity{ OrderId = 1, ProductItemId = 1, Price = 20, Quantity= 1, ProductName = "Product 1", UnitPrice = 20 }

                        }
                    },
                new OrderEntity()
                    {
                        Id = 2,
                        UserId = "Something test",
                        CustomerName = "Test Test",
                        Address = "Address 1",
                        City = "City 1",
                        PostalCode = "12345",
                        OrderDate = DateTime.Now,
                        TotalPrice = 100,
                        OrderLines = new List<OrderLineEntity>
                        {
                           new OrderLineEntity{ OrderId = 2, ProductItemId = 1, Price = 20, Quantity= 1, ProductName = "Product 1", UnitPrice = 20 }

                        }
                    },
                  new OrderEntity()
                    {
                        Id = 3,
                        UserId = "Something test",
                        CustomerName = "Test Test",
                        Address = "Address 1",
                        City = "City 1",
                        PostalCode = "12345",
                        OrderDate = DateTime.Now,
                        TotalPrice = 100,
                        OrderLines = new List<OrderLineEntity>
                        {
                           new OrderLineEntity{ OrderId = 3, ProductItemId = 1, Price = 20, Quantity= 1, ProductName = "Product 1", UnitPrice = 20 }

                        }
                    }
            };
            UserEntity user = new UserEntity()
            {
                Id = "Something test",
                FirstName = "Test",
                LastName = "Test"
            };
            _orderRepo.Setup(x => x.GetAllOrdersAsync()).ReturnsAsync(orders);

            //Act

            var result = await _orderService.GetOrdersForUser(user.Id);

            //Assert

            Assert.NotNull(result);
            Assert.IsType<List<OrderResponse>>(result);
            Assert.Equal(orders.Count, result.Count());



        }
    }
}

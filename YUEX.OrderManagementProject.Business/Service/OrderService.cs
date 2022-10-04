using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Entities.DTOs.ResponseModel;
using YUEX.OrderManagementProject.Entities.Entities;
using YUEX.OrderManagementProject.Repository.Abstract;
using YUEX.OrderManagementProject.Business.IService;
using YUEX.OrderManagementProject.Business.Rules;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Order;
using System.Collections;
using System.Linq;

namespace YUEX.OrderManagementProject.Business.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderDAL;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderDAL, IMapper mapper)
        {
            _orderDAL = orderDAL;
            _mapper = mapper;
        }

        public async Task<OrderResponseModel> Add(OrderInsertRequestModel request)
        {
            Order orderEntity = _mapper.Map<Order>(request);
            orderEntity.IsActive = true;
            orderEntity = await _orderDAL.AddAsync(orderEntity);

            OrderResponseModel customerResponce = _mapper.Map<OrderResponseModel>(orderEntity);

            return customerResponce;
        }

        public async Task Delete(OrderDeleteModel request)
        {
            var result = await GetByIdInternal(request.Id);
            result.IsActive = false;
            _orderDAL.Delete(result);
        }

        public async Task<IList<OrderResponseModel>> GetAll()
        {
            return _mapper.Map<IList<OrderResponseModel>>(await _orderDAL.GetListAsync());
        }

        public async Task<OrderResponseModel> GetById(int id)
        {
            return _mapper.Map<OrderResponseModel>(await _orderDAL.GetAsync(x => x.Id == id));
        }

        public async Task<OrderResponseModel> Update(OrderUpdateRequestModel request)
        {
            var result = await GetByIdInternal(request.Id);

            ///

            Order orderEntity = await _orderDAL.UpdateAsync(result);
            OrderResponseModel orderResponce = _mapper.Map<OrderResponseModel>(orderEntity);

            return orderResponce;
        }

        public async Task<Order> GetByIdInternal(int id)
        {
            return await _orderDAL.GetAsync(x => x.Id == id);
        }
    }
}

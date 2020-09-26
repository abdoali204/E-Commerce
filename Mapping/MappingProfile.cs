using AutoMapper;
using E_Commerce.Controllers.Resources;
using E_Commerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace E_Commerce.Mapping
{
    public class MappingProfile : Profile
    {
       
        //Domain to Api Resource
        public MappingProfile()
        {
            //from Domain to API RESOURCE
            CreateMap<Basket,BasketResource>();
            CreateMap(typeof(QueryResult<>),typeof(QueryResultResource<>));
            CreateMap<Invoice,InvoiceResource>();
            CreateMap<Address,AddressResource>();
            CreateMap<Shipping,ShippingResource>();
            CreateMap<OrderDetails,OrderDetailsResource>()
                    .ForMember(odr => odr.ProductName, opt => opt.MapFrom(od => od.Product.Name))
                    .ForMember(odr => odr.ProductId , opt=> opt.MapFrom( od => od.ProductId))
                    .ForMember(odr => odr.Price , opt => opt.MapFrom(od => od.Product.Price))
                    .ForMember(odr => odr.FileName , Opt => Opt.MapFrom(od => od.Product.Photos.Select(photo => photo.FileName).SingleOrDefault()));
            CreateMap<Payment,PaymentResource>();
            CreateMap<Photo, PhotoResource>();
            CreateMap<Photo, KeyValuePairResource>();
            CreateMap<Material , KeyValuePairResource>();
            CreateMap<ProductCategory, KeyValuePairResource>();
            
            CreateMap<Product,ProductResource>()
                   .ForMember(pr => pr.ProductCategory , opt => opt.MapFrom(p => new KeyValuePairResource{Id = p.Category.Id, Name = p.Category.Name}))
                   .ForMember(pr => pr.Photos , opt => opt.MapFrom( p => p.Photos.Select(ph => new KeyValuePairResource{Id = ph.Id,
                                                                                        Name = ph.FileName})))
                    .ForMember(pr => pr.ProductMaterial, opt => opt.MapFrom(p => new KeyValuePairResource{Id = p.Material.Id, Name = p.Material.Name}));
            //from API Resource To Domain
            CreateMap<SavePaymentResource,Payment>();
            CreateMap<SaveAddressResource, Address>()
                    .ForMember(s => s.Id, opt => opt.Ignore());
            CreateMap<SaveOrderDetailsResource,OrderDetails>()
                    .ForMember(od => od.Id , opt => opt.Ignore());
            CreateMap<BasketResource,Basket>();
            CreateMap<ProductQueryResource,ProductQuery>();
            CreateMap<SaveShippingResource, Shipping>()
                    .ForMember(s => s.Id, opt => opt.Ignore());
            CreateMap<KeyValuePairResource,Material>();
            CreateMap<SaveProductResource, Product>()
                    .ForMember(p => p.Id, opt => opt.Ignore())
                    .ForMember(p => p.Photos, opt => opt.Ignore());

            CreateMap<SaveOrderResource, Order>()
                    .ForMember(o => o.Id, opt => opt.Ignore())
                    .ForMember(o => o.Date, opt=> opt.Ignore())
                    .ForMember(o => o.State, opt => opt.Ignore());

            CreateMap<SaveBasketResource, Basket>()
                    .ForMember(b => b.BasketId, opt => opt.Ignore())
                    .ForMember(b=> b.BasketItems , opt => opt.Ignore())
                   .AfterMap( (br , b) => {
                           IEnumerable<OrderDetails> removedItems = b.BasketItems.Where( item => !br.BasketItems.Select(bi => bi.ProductId).Contains(item.ProductId));
                           //removing deleted Items
                           foreach(var item in removedItems.ToList()){
                           b.BasketItems.Remove(item);
                           }
                           //Adding new Items
                           var addedItems = br.BasketItems.Where( item => !b.BasketItems.Any(i => i.ProductId == item.ProductId)).Select(item => new OrderDetails(){
                                   ProductId = item.ProductId,
                                   Quantity = item.Quantity
                           });
                           foreach(var item in addedItems.ToList()){
                                   b.BasketItems.Add(item);
                           }
                           //Existing Items
                           var exstingItems = br.BasketItems.Where( i => b.BasketItems.Any(bi => bi.ProductId == i.ProductId));
                           foreach(var item in exstingItems){
                                   b.BasketItems.SingleOrDefault( i => i.ProductId == item.ProductId).Quantity=item.Quantity;
                           }
                   });
                    
                    

                    
        }
        
    }
}
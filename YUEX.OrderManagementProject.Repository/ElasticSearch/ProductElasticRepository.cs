using Microsoft.Extensions.Configuration;
using Nest;
using System;
using YUEX.OrderManagementProject.Entities.ElasticDto;
using YUEX.OrderManagementProject.Entities.Entities;
using YUEX.OrderManagementProject.Repository.Abstract;

namespace YUEX.OrderManagementProject.Repository.ElasticSearch
{
    public class ProductElasticRepository : IProductElasticRepository
    {

        private readonly ElasticClient _elasticClient;
        private readonly IConfiguration _configuration;

        public ProductElasticRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            string elasticUri = configuration.GetSection("ElasticConfig:ConnectionUri").Value ?? "http://localhost:9200/";
            _elasticClient = new ElasticClient(new ConnectionSettings(new Uri(elasticUri))
                        .DefaultIndex("product_index"));
        }

        public void AddDocument(Product doc)
        {
            _elasticClient.Index(doc, idx => idx.Index("product_index"));
        }

        public bool DeleteDocument(int id)
        {
            var result = _elasticClient.Delete<Product>(id.ToString(), idx => idx.Index("product_index"));
            if (!result.IsValid)
            {
                throw new Exception(result.OriginalException.Message);
            }
            return result.ApiCall.Success;
        }

        public ISearchResponse<ProductElasticDto> Search(string text)
        {
            var searchResult = _elasticClient.Search<ProductElasticDto>(s => s
                .Size(50)
                .Index("product_index")
                .Query(q => q
                    .MultiMatch(m => m
                        .Fields(fs => fs
                            .Field(f => f.BarcodeNumber)
                            .Field(f => f.Price)
                            .Field(f => f.Description)
                        )
                        .Query(text)
                        .Lenient(true)
                    )
                )
            );

            return searchResult;
        }

        public void UpdateDocument(Product entity)
        {
            var result = _elasticClient.Update(
                    new DocumentPath<Product>(entity), u =>
                        u.Doc(entity).Index("product_index"));
            if (!result.IsValid)
            {
                throw new Exception(result.OriginalException.Message);
            }
        }
    }
}

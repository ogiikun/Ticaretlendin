using AutoMapper;
using CatalogApi.Dtos;
using CatalogApi.Models;
using CatalogApi.Settings;
using MongoDB.Driver;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Services
{
    public class ProductService: IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<ProductDto>>> GetAllAsync()
        {
            var courses = await _productCollection.Find(course => true).ToListAsync();

            if (courses.Any())
            {
                foreach(var course in courses)
                {
                    course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Product>();
            }
            return Response<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(courses), 200);
        }



        public async Task<Response<ProductDto>> GetByIdAsync(string id)
        {
            var course = await _productCollection.Find<Product>(x=>x.Id==id).FirstOrDefaultAsync();
           
            if (course == null)
            {
                return Response<ProductDto>.Fail("Product not found", 404);
            }
            course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync();

            return Response<ProductDto>.Success(_mapper.Map<ProductDto>(course), 200);
        }

        public async Task<Response<List<ProductDto>>> GetAllByUserIdAsync(string userId)
        {
            var courses = await _productCollection.Find<Product>(x => x.UserId == userId).ToListAsync();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Product>();
            }
            return Response<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(courses), 200);


        }

        public async Task<Response<ProductDto>> CreateAsync(ProductCreateDto productCreateDto)
        {
            var newCourse = _mapper.Map<Product>(productCreateDto);

            newCourse.CreatedTime = DateTime.Now;
            await _productCollection.InsertOneAsync(newCourse);

            return Response<ProductDto>.Success(_mapper.Map<ProductDto>(newCourse), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var updateCourse=_mapper.Map<Product>(productUpdateDto);

            var result = await _productCollection.FindOneAndReplaceAsync(x => x.Id == productUpdateDto.Id, updateCourse);

            if (result == null)
            {
                return Response<NoContent>.Fail("Product Not Found", 404);
            }
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _productCollection.DeleteOneAsync(x=> x.Id==id);

            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("Product Could Not Be Deleted",404);
        }

    }
}

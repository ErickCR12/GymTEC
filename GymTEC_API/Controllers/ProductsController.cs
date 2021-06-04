using Microsoft.AspNetCore.Mvc;
using GymTEC_API.Data;
using AutoMapper;
using GymTEC_API.DTOs;
using System.Collections.Generic;
using GymTEC_API.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the Product Treatment entity type. This Controller allows all the CRUD functions.
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISQLRepo _repository;
        private readonly IMapper _mapper;

        public ProductsController (ISQLRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/products
        //This request returns a list of Product entities in a JSON format representing the Product Treatment database.
        [HttpGet]
        public ActionResult <IEnumerable<ProductDto>> GetAllProducts()
        {
            var productsItem = _repository.GetAllProducts();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(productsItem));
        }

        //GET api/products/{barCode}
        //This request returns a single Product Treatment entity in a JSON format. This entity has the same barCode
        //as the received in the request header.
        [HttpGet("{barCode}", Name = "GetProductByBarCode")]
        public ActionResult <ProductDto> GetProductByBarCode(int barCode)
        {
            var productModel = _repository.GetProductByBarCode(barCode);
            if(productModel != null){
                return Ok(_mapper.Map<ProductDto>(productModel));
            }
            return NotFound();
        }

        //POST api/products
        //This request receives all the needed info to create a new Product Treatment in the Product Treatment database.
        [HttpPost]
        public ActionResult <ProductDto> CreateProduct(ProductDto productDto)
        {
            var productModel = _mapper.Map<Product>(productDto);
            _repository.CreateUpdateDeleteProduct(productModel, "INSERT");
            var newProductDto = _mapper.Map<ProductDto>(productModel);

            return CreatedAtRoute(nameof(GetProductByBarCode), new {barCode = newProductDto.barCode}, 
                                newProductDto);
        }


        //PUT api/products/{barCode}
        //This request receives all the needed info to modify an existing Product Treatment in the database.
        [HttpPut("{barCode}")]
        public ActionResult UpdateProduct(int barCode, ProductDto productDto)
        {
            var productFromRepo = _repository.GetProductByBarCode(barCode);
            productDto.barCode = productFromRepo.barCode;
            if(productFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(productDto, productFromRepo);
            _repository.CreateUpdateDeleteProduct(productFromRepo, "UPDATE");

            return NoContent();
        }

        //DELETE api/products/{barCode}
        //This request deletes the Product Treatment entity with the barCode received in the request header.
        [HttpDelete("{barCode}")]
        public ActionResult DeleteProduct(int barCode)
        {
            var productFromRepo = _repository.GetProductByBarCode(barCode);
            if(productFromRepo == null)
            {
                return NotFound();
            }
            _repository.CreateUpdateDeleteProduct(productFromRepo, "DELETE");
            return NoContent();
        }

    }
}
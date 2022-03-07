using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backend.DTO;
using backend.Entities;
using backend.Implementations;
using backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController: ControllerBase {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriesController(IMapper mapper, IUnitOfWork unitOfWork) 
         {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll(){
            try{
                return Ok(await _unitOfWork.CategoryRepository.GetAllAsync());
               
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id){
            try{
                return Ok(await _unitOfWork.CategoryRepository.GetByIdAsync(id));
               
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody]CategoryDTO CategoryDTO){
            var db_category = _mapper.Map<Category>(CategoryDTO);
            try{
                await _unitOfWork.CategoryRepository.AddAsync(db_category);
                await _unitOfWork.CommitAsync();
                return Ok();
               
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CategoryDTO categoryDTO){
             var db_category = _mapper.Map<Category>(categoryDTO);
            try{
                var db_category_update = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
                if(db_category_update == null) {
                    return NotFound();
                }
                else {
                    db_category_update.NameCategory = db_category.NameCategory;
                    _unitOfWork.CategoryRepository.Update(db_category_update);
                    await _unitOfWork.CommitAsync();
                    return Ok();
                }
                
               
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id){
            try{
                var db_category_remove = await _unitOfWork.CategoryRepository.GetByIdAsync(id);

                if(db_category_remove == null ) {
                    return NotFound();
                }
                else{
                    _unitOfWork.CategoryRepository.Remove(db_category_remove);
                    await _unitOfWork.CommitAsync();
                    return Ok();
                }
                
               
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        
    }
}
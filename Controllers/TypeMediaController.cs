using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backend.DTO;
using backend.Entities;
using backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class TypeMediaController: ControllerBase {
         private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public TypeMediaController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeMediaDTO>>> GetAll(){
            try{
                return Ok(await _unitOfWork.TypeMediaRepository.GetAllAsync());
               
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TypeMediaDTO>> GetById(int id){
            try{
                return Ok(await _unitOfWork.TypeMediaRepository.GetByIdAsync(id));
               
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody]TypeMediaDTO typeMediaDTO){
            var db_typeMedia = _mapper.Map<TypeMedia>(typeMediaDTO);
            try{
                var responde = await _unitOfWork.TypeMediaRepository.AddAsync(db_typeMedia);
                await _unitOfWork.CommitAsync();
                return Ok(responde);
               
               
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(TypeMediaDTO typeMediaDTO, int id){
            var db_TypeMediaDTO = _mapper.Map<TypeMedia>(typeMediaDTO);
            try{
                var db_typeMedia_update = await _unitOfWork.TypeMediaRepository.GetByIdAsync(id);
                if (db_typeMedia_update == null) {
                    return NotFound();
                }
                else {
                    db_typeMedia_update.Name = db_TypeMediaDTO.Name;
                   _unitOfWork.TypeMediaRepository.Update(db_typeMedia_update);
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
                var db_typeMedia_remove = await _unitOfWork.TypeMediaRepository.GetByIdAsync(id);
                if(db_typeMedia_remove == null) {
                    return NotFound();
                }
                else {
                    _unitOfWork.TypeMediaRepository.Remove(db_typeMedia_remove);
                     await _unitOfWork.CommitAsync();
                    return Ok();
                }
               
               
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        
    }
}
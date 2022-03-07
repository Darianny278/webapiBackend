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
    public class MediasController: ControllerBase {
         private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public MediasController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaDTO>>> GetAll(){
            try{
                return Ok(await _unitOfWork.MediaRepository.GetMediaWithCategoryAndType());
               
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MediaDTO>> GetById(int id){
            try{
                return Ok(await _unitOfWork.MediaRepository.GetByIdAsync(id));
               
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody]MediaDTO mediaDTO){
            var db_media = _mapper.Map<Media>(mediaDTO);
            try{
                var response = await _unitOfWork.MediaRepository.AddAsync(db_media);
                await _unitOfWork.CommitAsync();
                return Ok(response);
               
               
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(MediaDTO mediaDTO, int id){
            var db_media = _mapper.Map<Media>(mediaDTO);
            try{
                var db_media_update = await _unitOfWork.MediaRepository.GetByIdAsync(id);
                if(db_media_update == null) {
                    return NotFound();
                }
                else {
                    db_media_update.NameMedia = db_media.NameMedia;
                    db_media_update.DescriptionMedia = db_media.DescriptionMedia;
                    db_media_update.CategoryId = db_media.CategoryId;
                    db_media_update.TypeMediaId = db_media.TypeMediaId;
                    _unitOfWork.MediaRepository.Update(db_media_update);
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
                var db_media_remove = await _unitOfWork.MediaRepository.GetByIdAsync(id);
                if(db_media_remove == null) {
                    return NotFound();
                }
                else {
                    _unitOfWork.MediaRepository.Remove(db_media_remove);
                    await _unitOfWork.CommitAsync();
                    return Ok();
                }
              
               
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        
    }
}
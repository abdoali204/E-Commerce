using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.Controllers.Resources;
using E_Commerce.Core;
using E_Commerce.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("/api/materials")]
    public class MaterialsController :Controller
    {
        private readonly IMaterialRepository materialRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MaterialsController(IMaterialRepository materialRepository,IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.materialRepository = materialRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetMaterials()
        {
            return Ok(materialRepository.GetMaterials());
        }
        [HttpPost]
        public async  Task<IActionResult> PostMaterial([FromBody]KeyValuePairResource materialResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var material =  mapper.Map<KeyValuePairResource,Material>(materialResource);
            if(material == null)
                return BadRequest("Bad Material");
            materialRepository.AddMaterial(material);
            await unitOfWork.CompleteAsync();
            return Ok(mapper.Map<Material,KeyValuePairResource>(material));
        }

    }
}
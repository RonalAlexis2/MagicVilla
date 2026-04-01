using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVillaService _villaService;
        public VillaController(IMapper mapper, IVillaService villaService)
        {
            _mapper = mapper;
            _villaService = villaService;
        }
        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDto> VillaList = new();

            var response = await _villaService.ObtenerTodos<APIResponse>();

            if (response != null && response.IsExitoso)
            {
                VillaList = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Resultado));
            }


            return View(VillaList);
        }

        //GET: Crear Villa
        public async Task<IActionResult> CrearVilla()
        {
            return View();
        }

        //POST: Crear Villa

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearVilla(VillaCreateDto modelo)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.Crear<APIResponse>(modelo);
                if (response != null && response.IsExitoso)
                {
                    TempData["exitoso"] = "Villa creada exitosamente";
                    return RedirectToAction(nameof(IndexVilla));
                }
            }

            TempData["error"] = "Ocurrió un error al crear la villa";
            return View(modelo);
        }



        public async Task<IActionResult> ActualizarVilla(int villaId)
        {
            var response = await _villaService.Obtener<APIResponse>(villaId);

            if (response != null && response.IsExitoso)
            {
                VillaDto model = JsonConvert.DeserializeObject<VillaDto>(Convert.ToString(response.Resultado));
                return View(_mapper.Map<VillaUpdateDto>(model));
            }

            TempData["error"] = "Ocurrió un error al obtener la villa";
            return NotFound();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarVilla(VillaUpdateDto modelo)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.Actualizar<APIResponse>(modelo);
                if (response != null && response.IsExitoso)
                {
                    TempData["exitoso"] = "Villa actualizada exitosamente";
                    return RedirectToAction(nameof(IndexVilla));
                }
            }

            TempData["error"] = "Ocurrió un error al actualizar la villa";
            return View(modelo);

        }

        public async Task<IActionResult> RemoverVilla(int villaId)
        {
            var response = await _villaService.Obtener<APIResponse>(villaId);

            if (response != null && response.IsExitoso)
            {
                VillaDto model = JsonConvert.DeserializeObject<VillaDto>(Convert.ToString(response.Resultado));
                return View(model);
            }
            return NotFound();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoverVilla(VillaDto modelo)
        {
           
           var response = await _villaService.Remover<APIResponse>(modelo.Id);
          
            if (response != null && response.IsExitoso)
            {
                TempData["exitoso"] = "Villa eliminada exitosamente";
                return RedirectToAction(nameof(IndexVilla));
            }
            TempData["error"] = "Ocurrió un error al eliminar la villa";
            return View(modelo);

        }
    }
}

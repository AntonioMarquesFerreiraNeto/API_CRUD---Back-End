using API_CRUD_FROTA.Models;
using API_CRUD_FROTA.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD_FROTA.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OnibusController : ControllerBase {

        private readonly IOnibusRepository _onibusRepository;

        public OnibusController(IOnibusRepository onibusRepository) {
            _onibusRepository = onibusRepository;
        }

        [HttpGet]
        public IActionResult ReturnListOnibus() {
            List<Onibus> ListOnibus = _onibusRepository.ReturnListOnibus();
            if (!ListOnibus.Any()) {
                return NotFound("Nenhum item registrado!");
            }
            return Ok(ListOnibus);
        }

        [HttpPost]
        public IActionResult NewOnibus([FromBody] Onibus onibus) {
            try {
                if (ModelState.IsValid) {
                    _onibusRepository.AddOnibus(onibus);
                    return Ok(onibus);
                }
                return NotFound("Ops, observe os campos para saber o problema!");
            }
            catch (Exception error) {
                return NotFound(error.Message);
            }
            
        }

        [HttpGet("{id}")]   
        public IActionResult ReturnOnibusPorId(int? id) {
            Onibus onibus = _onibusRepository.ReturnOnibusPorId(id);
            if (onibus == null) {
                return NotFound("Desculpe, nenhum ônibus encontrado!");
            }
            return Ok(onibus);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOnibus([FromBody] Onibus onibus, int id) {
            try {
                if (ModelState.IsValid) {
                    onibus.Id = id;
                    _onibusRepository.UpdateOnibus(onibus);
                    return Ok(onibus);
                }
                return NotFound("Ops, observe os campos para saber o problema!");
            }
            catch (Exception error) {
                return NotFound(error.Message);
            }
        }

        [HttpDelete ("{id}")]
        public IActionResult DeleteOnibus(int id) {
            try {
                _onibusRepository.Delete(id);
                return Ok($"Ônibus nº {id}, deletado com sucesso!");
            }
            catch (Exception error) {
                return NotFound(error.Message);
            }
        }
    }
}

using API_CRUD_FROTA.Models;
using API_CRUD_FROTA.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD_FROTA.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MotoristaController : ControllerBase {

        private readonly IMotoristaRepository _motoristaRepository;

        public MotoristaController(IMotoristaRepository motoristaRepository) {
            _motoristaRepository = motoristaRepository;
        }

        [HttpGet]
        public IActionResult ListAllMotorista() {
            try {
                List<Motorista> motoristas = _motoristaRepository.ListMotoristaAll();
                return Ok(motoristas);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateMotorista(Motorista motorista) {
            try {
                if (ModelState.IsValid) {
                    _motoristaRepository.CreateMotorista(motorista);
                    return Ok(motorista);
                }
                return BadRequest(motorista);
            }
            catch (Exception error) {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMotoristaById(int id) {
            try {
                Motorista motorista = _motoristaRepository.ListMotoristaById(id);
                if (motorista == null) {
                    return NotFound("Desculpe, nenhum motorista encontrado!");
                }
                return Ok(motorista);
            }
            catch (Exception error) {
                return NotFound(error.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMotorista([FromBody] Motorista motorista, int id) {
            try {
                if (ModelState.IsValid) {
                    motorista.Id = id;
                    _motoristaRepository.UpdateMotorista(motorista);
                    return Ok(motorista);
                }
                return NotFound(motorista);
            }
            catch (Exception error) {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMotorista(int id) {
            try {
                Motorista motoristaDelete = new Motorista();
                motoristaDelete.Id = id;
                motoristaDelete = _motoristaRepository.DeleteMotorista(motoristaDelete);
                return Ok(motoristaDelete);
            }
            catch (Exception error) {
                return NotFound(error.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.Models.Enuns;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagensExemploController : ControllerBase
    {
        private static List<Personagem> personagens
            = new List<Personagem>()
            {
                new Personagem(){ Id=1, Nome="Kurt Ahrens Jr.", PontosVida=100, Classe = Models.Enuns.ClasseEnum.Cavaleiro},
                new Personagem() { Id = 2, Nome = "Jack Aitken", PontosVida=100,  Classe=ClasseEnum.Cavaleiro},
                new Personagem() { Id = 3, Nome = "Christijan Albers", PontosVida=100,  Classe=ClasseEnum.Clerigo },
                new Personagem() { Id = 4, Nome = "Alexander Albon", PontosVida=100,  Classe=ClasseEnum.Mago },
                new Personagem() { Id = 5, Nome = "AirtonSena", PontosVida=100,  Classe=ClasseEnum.Cavaleiro },
                new Personagem() { Id = 6, Nome = "Gabriel", PontosVida=100,  Classe=ClasseEnum.Clerigo },
                new Personagem() { Id = 7, Nome = "Gabriella", PontosVida=100,  Classe=ClasseEnum.Mago }
            };

        public static List<Personagem> Personagens { get => personagens; set => personagens = value; }

        [HttpGet("Get")]
        public IActionResult GetFirst()
        {
            Personagem p = Personagens[0];
            return Ok(p);
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(Personagens);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(Personagens.FirstOrDefault(pe => pe.Id ==id));
        }

        [HttpPost]
        public IActionResult AddPersonagem(Personagem novoPersonagem)
        {
            Personagens.Add(novoPersonagem);
            return Ok(Personagens);
        }

        [HttpPut]
        public IActionResult UpdatePersonagem(Personagem p)
        {
            Personagem personagemAlterado = Personagens.Find(pers => pers.Id == p.Id);
            personagemAlterado.Nome = p.Nome;
            personagemAlterado.PontosVida = p.PontosVida;
            personagemAlterado.Classe = p.Classe;

            return Ok(Personagens);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Personagens.RemoveAll(pers => pers.Id == id);
            return Ok(Personagens);
        }

        [HttpGet("GetByEnum/{enumId}")]
        public IActionResult GetByEnum(int enumId)
        {
            ClasseEnum enumDigitado = (ClasseEnum)enumId;
            List<Personagem> listaBusca = Personagens.FindAll(p => p.Classe == enumDigitado);
            return Ok(listaBusca);
        }







    }
}
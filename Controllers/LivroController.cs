using ExercicioGestaoLivraria.Entities;
using ExercicioGestaoLivraria.Repository;
using ExercicioGestaoLivraria.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioGestaoLivraria.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivroController : ControllerBase
{

	[HttpPost]
	[ProducesResponseType(typeof(Livro), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
	public IActionResult CriarLivro([FromBody]LivroRequest livro)
	{
		if (livro is null)
			return BadRequest("Não foi enviado um livro na requisição!");

		var novoLivro = new Livro
		{
			Id = BibliotecaRepository.RetornarNovoId(),
			Titulo = livro.Titulo,
			Autor = livro.Autor,
			Genero = livro.Genero,
			Quantidade = livro.Quantidade,
			Preco = livro.Preco
		};

		BibliotecaRepository.AdicionarRegistro(novoLivro);

		return Created(string.Empty, novoLivro);
	}

	[HttpGet]
	[ProducesResponseType(typeof(IEnumerable<Livro>), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public IActionResult ObterTodosLivros()
	{
		var livros = BibliotecaRepository.ObterTodosLivros();

		if (livros is null)
			return NoContent();

		return Ok(livros);
	}

	[HttpPut]
	[Route("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
	public IActionResult AlterarLivro([FromRoute]int id, [FromBody] LivroRequest livroRequest)
	{
		var livro = BibliotecaRepository.ObterLivro(id);

		if (livro is null)
			return BadRequest("O livro informado não esta cadastrado!");

		BibliotecaRepository.AtualizarRegistro(id, livroRequest);

		return NoContent();
	}

	[HttpDelete]
	[Route("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
	public IActionResult DeletarLivro([FromRoute] int id)
	{
		var livro = BibliotecaRepository.ObterLivro(id);

		if (livro is null)
			return BadRequest("O livro informado não esta cadastrado!");

		BibliotecaRepository.DeletarRegistro(livro);

		return NoContent();
	}
}

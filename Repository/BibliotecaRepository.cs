using ExercicioGestaoLivraria.Entities;
using ExercicioGestaoLivraria.Requests;

namespace ExercicioGestaoLivraria.Repository;

public static class BibliotecaRepository
{
	public static List<Livro> _livros = new List<Livro>();
	private static int _id = 0;

	public static int RetornarNovoId() 
	{
		_id ++;
		return _id;
	} 
	public static void AdicionarRegistro(Livro livro) => _livros.Add(livro);
	public static Livro? ObterLivro(int id) => _livros.FirstOrDefault(livro => livro.Id.Equals(id));
	public static IEnumerable<Livro> ObterTodosLivros() => _livros;

	public static void AtualizarRegistro(int id, LivroRequest livroRequest)
	{
		var livro = _livros.FirstOrDefault(livro => livro.Id.Equals(id));

		livro.Titulo = livroRequest.Titulo;
		livro.Quantidade = livroRequest.Quantidade;
		livro.Autor = livroRequest.Autor;
		livro.Genero = livroRequest.Genero;
		livro.Quantidade = livroRequest.Quantidade;
	}

	public static void DeletarRegistro(Livro livro) => _livros.Remove(livro);
}

﻿namespace ExercicioGestaoLivraria.Requests
{
	public class LivroRequest
	{
		public string Titulo { get; set; } = string.Empty;
		public string Autor { get; set; } = string.Empty;
		public string Genero { get; set; } = string.Empty;
		public decimal Preco { get; set; }
		public int Quantidade { get; set; }
	}
}

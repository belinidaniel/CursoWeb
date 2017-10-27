namespace matrizCurricular.api.Exceptions.CursoException
{
	using System;
	using System.Collections.Generic;

	public class CursoException: ApplicationException
	{
		public string Motivo { get; }

		public CursoException(string Motivo)
		{
			this.Motivo = Motivo;
		}

	}
}
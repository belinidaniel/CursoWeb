namespace matrizCurricular.api
{
	using System;
	using System.Collections.Generic;
	using System.Xml.Serialization;

	public class Curso
	{
		public int GeralAp
		{
			get
			{
				var Somatoria = 0;
				foreach (var p in this.Periodos) Somatoria = +Somatoria + p.TotalAp;
				return Somatoria;
			}
		}

		public int GeralAt
		{
			get
			{
				var Somatoria = 0;
				foreach (var p in this.Periodos) Somatoria = +Somatoria + p.TotalAt;
				return Somatoria;
			}
		}

		public int Geralcred
		{
			get
			{
				var Somatoria = 0;
				foreach (var p in this.Periodos) Somatoria = +Somatoria + p.TotalCred;
				return Somatoria;
			}
		}

		public int GeralHa
		{
			get
			{
				var Somatoria = 0;
				foreach (var p in this.Periodos) Somatoria = +Somatoria + p.TotalHa;
				return Somatoria;
			}
		}

		public int GeralHr
		{
			get
			{
				var Somatoria = 0;
				foreach (var p in this.Periodos) Somatoria = +Somatoria + p.TotalHr;
				return Somatoria;
			}
		}


		[XmlElement("nome")]
		public string Nome { get; set; }

		public Periodo P { get; internal set; }

		[XmlArrayItem("Periodo")]
		public List<Periodo> Periodos { get; set; }

	}
}
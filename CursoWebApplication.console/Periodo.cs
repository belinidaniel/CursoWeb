namespace matrizCurricular.api
{
	using System;
	using System.Collections.Generic;
	using System.Xml.Serialization;

	public class Periodo : IImprimir
	{
		[XmlArray("disciplina"), XmlArrayItem("disciplina")]
		public List<Disciplina> Disciplinas;

		[XmlElement("numero")]
		public string NumeroPeriodo { get; set; }

		[XmlElement("AP")]
		public int TotalAp
		{
			get
			{
				var Somatoria = 0;
				foreach (var d in this.Disciplinas) Somatoria = +Somatoria + d.Ap;
				return Somatoria;
			}
		}

		[XmlElement("AT")]
		public int TotalAt
		{
			get
			{
				var Somatoria = 0;
				foreach (var d in this.Disciplinas) Somatoria = +Somatoria + d.At;
				return Somatoria;
			}
		}

		[XmlElement("Créd.")]
		public int TotalCred
		{
			get
			{
				var Somatoria = 0;
				foreach (var d in this.Disciplinas) Somatoria = +Somatoria + d.Cred;
				return Somatoria;
			}
		}

		[XmlElement("HA")]
		public int TotalHa
		{
			get
			{
				var Somatoria = 0;
				foreach (var d in this.Disciplinas) Somatoria = +Somatoria + d.Ha;
				return Somatoria;
			}
		}

		[XmlElement("HR")]
		public int TotalHr
		{
			get
			{
				var Somatoria = 0;
				foreach (var d in this.Disciplinas) Somatoria = +Somatoria + d.Hr;
				return Somatoria;
			}
		}

		public void Imprimir()
		{
			Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
			Console.WriteLine(this.NumeroPeriodo + "° periodo");
			Console.WriteLine("Disciplinas               AT | AP | CRED | HA  | HR   | MT  | MP ");
			foreach (var d in this.Disciplinas) d.Imprimir();
			Console.WriteLine(
				"Total:                  |" + this.TotalAt + "  |  " + this.TotalAp + " |  " + this.TotalCred + "  | "
				+ this.TotalHa + " | " + this.TotalHr);
			Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
			Console.WriteLine("---------------------------------------------------------------------------");
		}
	}
}
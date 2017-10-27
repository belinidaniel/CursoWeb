using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrizCurricular.api
{
	using System.Xml.Serialization;

	public class Disciplina : IImprimir
    {
	    [XmlElement("Disciplinas")]
        public string Nome { get; set; }

	    [XmlElement("Ordem")]
		public int Ordem { get; set; }

		[XmlElement("AT")]
		public int At { get; set; }

	    [XmlElement("AP")]
		public int Ap { get; set; }

	    [XmlElement("Créd.")]
		public int Cred { get; set; }

	    [XmlElement("HA")]
		public int Ha { get; set; }

	    [XmlElement("HR")]
		public int Hr { get; set; }

        public void Imprimir()
        {
            Console.WriteLine("" + Nome + "       |  " + At + " |  " + Ap + " |  " + Cred + "   |  " + Ha + " |  "
                              + Hr );
        }
    }
}

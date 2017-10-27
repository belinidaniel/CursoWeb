namespace matrizCurricular.api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class MainClass
    {
	    static void delegadoHr(Disciplina disciplina, int Hr)
	    {
		    var aux = disciplina.Hr;
		    disciplina.Hr = Hr;
			Console.WriteLine("disciplina " + disciplina.Nome+ " teve sua carga horaria atualizada de " +aux+" Para "+Hr);
	    }
		public static void Main()
        {
            var diretorio = @"C:\Users\doliveira\Desktop\Estudos\Faculdade\Tecnologia de Prog II\";
            var parametro1 = "MatrizCurricularBSI.txt";
            var parametro2 = "MatrizCurricularBSI.xml";
            var parametro3 = "BSI";

            ExportarXml.metodo(diretorio + parametro1, diretorio + parametro2, parametro3);

            var listarCurso = new List<Curso>();
            var listarPeriodos = new List<Periodo>();
            var listarDisciplina = new List<Disciplina>();

			
			string xml = diretorio + parametro2;
	        LerSalvarXML.LerSalvarXml(xml, listarDisciplina, listarPeriodos, listarCurso);

			foreach (var cursos in listarCurso)
	        {
		        cursos.Imprimir();
	        }

	        delegadoHr(listarPeriodos[0].Disciplinas[0], 2000);

	        foreach (var cursos in listarCurso)
	        {
		        cursos.Imprimir();
	        }

			Console.Read();

		}
	}
}
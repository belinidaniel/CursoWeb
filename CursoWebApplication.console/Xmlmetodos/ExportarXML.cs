namespace matrizCurricular.api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Xml;


   
    class ExportarXml
    {
        public static bool metodo(string txt, string xml, string bsi)
        {
           
            if (!File.Exists(txt))
            {
               
                Console.WriteLine("Erro: " + "especifique aqui o erro");
                return false;
            }
           
            StreamReader leitor = new StreamReader(txt, Encoding.Default);

           
            XmlDocument documento = new XmlDocument();
            XmlElement raiz = documento.CreateElement("Curso");
            raiz.SetAttribute("nome", bsi);
            documento.AppendChild(raiz);

           
            string linha = null;
            string[] atributos = null;
            XmlElement elementoPeriodo = null;

           
            while ((linha = leitor.ReadLine()) != null)
            {
                string valor = linha.Trim();
                if (valor.EndsWith("Período"))
                {
                    elementoPeriodo = documento.CreateElement("periodo");
                    valor = valor.Replace("Período", "");
                    valor = valor.Trim();
                    elementoPeriodo.SetAttribute("numero", valor);
                    raiz.AppendChild(elementoPeriodo);
                }
                else if (valor.StartsWith("Ordem"))
                {
                   
                    atributos = linha.Split('\t');
                }
                else if (valor.StartsWith("Total"))
                {
                   
                    string[] colunas = valor.Split('\t');
                   
                    int indiceInicial = 3;
                    foreach (string coluna in colunas)
                    {
                        try
                        {
                           
                            int numero = Convert.ToInt32(coluna.Trim());
                           
                            elementoPeriodo.SetAttribute(atributos[indiceInicial].Trim(), numero.ToString());
                            indiceInicial++;
                        }
                        catch
                        {
                           
                        }
                    }
                }
                else if (valor.Length > 0)
                {
                   
                    string[] valores = valor.Split('\t');
                    XmlElement elementoDisciplina = documento.CreateElement("disciplina");
                    for (int i = 0; i < valores.Length && i < atributos.Length; i++)
                    {
                       
                        elementoDisciplina.SetAttribute(atributos[i].Trim(), valores[i].Trim());
                    }
            	   
                    elementoPeriodo.AppendChild(elementoDisciplina);
                }
            }
           
            documento.Save(xml);
            Console.WriteLine("Operação realizada com sucesso!");
            return true;
        }
    }
}

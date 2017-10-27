namespace matrizCurricular.api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Xml.Linq;

    using matrizCurricular.api.Exceptions.CursoException;

    public class LerSalvarXML
    {
        public static List<Curso> items { get; private set; }

        public static List<Curso> LerSalvarXml(string diretorio, List<Disciplina> listarDisciplina, List<Periodo> listarPeriodos, List<Curso> listarCurso)
        {
            if (diretorio == null)
            {
                throw new CursoException("Não foi encontrado o diretorio");
            }

            var xdoc = XDocument.Load(diretorio);
            try
            {
                items = (from i in xdoc.Elements("Curso")
                    select new Curso
                    {
                        Nome = (string)i.Attribute("nome"),
                        Periodos = (from p in i.Elements("periodo")
                        select new Periodo
                        {
                            NumeroPeriodo = (string)p.Attribute("numero"),
                            Disciplinas = (from d in p.Elements("disciplina")
                            select new Disciplina
                            {
                                Nome = (string)d.Attribute("Disciplinas"),
                                At = (int)d.Attribute("AT"),
                                Ap = (int)d.Attribute("AP"),
                                Cred = (int)d.Attribute("Créd."),
                                Ha = (int)d.Attribute("HA"),
                                Hr = (int)d.Attribute("HR"),
                                Ordem = (int)d.Attribute("Ordem")
                            }).ToList()
                        }).ToList()
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            foreach (var Curso in items)
            {

                foreach (var periodo in Curso.Periodos)
                {
                    foreach (var disciplina in periodo.Disciplinas)
                    {
                        foreach (var d in listarDisciplina)
                        {
                            if (d.Nome.Equals(disciplina.Nome))
                            {
                                throw new CursoException("Disciplina ja esta cadastrada para esse curso");
                            }
                        }

                        listarDisciplina.Add(disciplina);
                        
                    }
                    foreach (var c in listarPeriodos)
                    {
                    if (c.NumeroPeriodo.Equals(periodo.NumeroPeriodo))
                        {
                            throw new CursoException("essa periodo ja foi cadastrado");
                        }
                    }

                    listarPeriodos.Add(periodo);
                }
                listarCurso.Add(Curso);
            }
            return listarCurso;
        }
    }
}
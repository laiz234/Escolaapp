using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EscolaApp
{
    class NProfessor
    {
        private static List<Professor> profs = new List<Professor>();
        public static void Inserir(Professor p)
        {
            Abrir();
            // Procurar o maior Id
            int id = 0;
            foreach (Professor obj in profs)
                if (obj.Id > id) id = obj.Id;
            p.Id = id + 1;
            profs.Add(p);
            Salvar();
        }
        public static List<Professor> Listar()
        {
            Abrir();
            return profs;
        }
        public static void Excluir(Professor p)
        {
            Abrir();
            // Percorrer a lista de turma procurando o id informado (t.Id)
            Professor x = null;
            foreach (Professor obj in profs)
                if (obj.Id == p.Id) x = obj;
            if (x != null) profs.Remove(x);
            Salvar();
        }
        public static void Atualizar(Professor p)
        {
            Abrir();
            // Percorrer a lista de turma procurando o id informado (t.Id)
            foreach (Professor obj in profs)
                if (obj.Id == p.Id)
                {
                    obj.Nome = p.Nome;
                    obj.Matricula = p.Matricula;
                    obj.Area = p.Area;
                }
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                // Objeto que serializa (transforma) uma lista de turmas em um texto em XML
                XmlSerializer xml = new XmlSerializer(typeof(List<Professor>));
                // Objeto que abre um texto em um arquivo
                f = new StreamReader("./profs.xml");
                // Chama a operação de desserialização informando a origem do texto XML
                profs = (List<Professor>)xml.Deserialize(f);
            }
            catch
            {
                profs = new List<Professor>();
            }
            // Fecha o arquivo
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            // Objeto que serializa (transforma) uma lista de turmas em um texto em XML
            XmlSerializer xml = new XmlSerializer(typeof(List<Professor>));
            // Objeto que grava um texto em um arquivo
            StreamWriter f = new StreamWriter("./profs.xml", false);
            // Chama a operação de serialização informando o destino do texto XML
            xml.Serialize(f, profs);
            // Fecha o arquivo
            f.Close();
        }
    }
}

using Library.DAO;
using System;
using System.IO;

namespace Library
{
    public class InitDB
    {
        private void ExecutaScriptDB(string file)
        {
            string script = File.ReadAllText(file);
            string[] comandos = script.Split(new string[] { "GO" }, StringSplitOptions.None);

            foreach (string comando in comandos)
            {
                MetodosBD.ExecutaSQL(comando.Replace("\r", "").Replace("\n", "").Replace("\t", " "));
            }
        }

        public void CriarDB(string servidor, string usuario, string senha)
        {
            ExecutaScriptDB("create-database.sql");
            WriteServerData(servidor, usuario, senha);
            ExecutaScriptDB("air-system-control.sql");
        }

        private void WriteServerData(string servidor, string usuario, string senha)
        {
            File.WriteAllText("credenciais-db.txt",
                servidor + Environment.NewLine +
                usuario + Environment.NewLine +
                senha + Environment.NewLine
                );
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace SimplesINIs
{
    class SimplesINI
    {
        public List<string> ConteudoDoArquivo = new List<string>();

        public SimplesINI(string ArquivoASerLido)
        {
            try
            {
                TextReader LerArquivo = new StreamReader(ArquivoASerLido);
                char[] novaLinha = new char[2];
                string linha = Environment.NewLine;
                List<char> listadechar = new List<char>();
                foreach (var item in linha)
                {
                    listadechar.Add(item);
                }
                novaLinha[0] = listadechar[0];
                novaLinha[1] = listadechar[1];
                var TodoOConteudoDoArquivo = LerArquivo.ReadToEnd().Split(novaLinha);
                LerArquivo.Close();
                var ConteudoSelecionado = from c in TodoOConteudoDoArquivo
                                          where c != "" || !c.StartsWith("//")
                                          select c;
                ConteudoDoArquivo = ConteudoSelecionado.ToList();                
            }
            catch (FileNotFoundException)
            {
                ConteudoDoArquivo.Add(null);
                throw new FileNotFoundException();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro:");
            }
        }

        public string ReadStringInKey(string KEY)
        {
            try
            {
                string Conteudo = null;
                int? OndeTavaAkey = null;

                for (int i = 0; i < ConteudoDoArquivo.Count; i++)
                {
                    if (ConteudoDoArquivo[i].StartsWith(KEY + " ") || ConteudoDoArquivo[i].StartsWith(KEY + "="))
                    {
                        OndeTavaAkey = i;
                        var Partes = ConteudoDoArquivo[i].Split(Convert.ToChar("="));
                        List<string> ListaDepartes = Partes.ToList();

                        ListaDepartes.RemoveAt(0);

                        if (ListaDepartes.Count > 1)
                        {
                            Conteudo = ListaDepartes[0].TrimStart();

                            for (int i2 = 1; i2 < ListaDepartes.Count; i2++)
                            {
                                Conteudo += "=" + ListaDepartes[i2];
                            }

                            Conteudo = Conteudo.Trim();
                        }
                        else
                        {
                            Conteudo = ListaDepartes[0].Trim();
                        }

                    }
                 
                }

                if (OndeTavaAkey != null)
                {
                    ConteudoDoArquivo.RemoveAt(Convert.ToInt32(OndeTavaAkey));
                }
                
                return Conteudo;
            }
            catch (Exception)
            {
                return null;
            }
        }



        public Color? ReadColorInKey(string KEY)
        {
           
            try
            {
                Color? Conteudo = null;
                string ConteudoEmtexto = null;
                int? OndeTavaAkey = null;

                for (int i = 0; i < ConteudoDoArquivo.Count; i++)
                {
                    if (ConteudoDoArquivo[i].StartsWith(KEY + " ") || ConteudoDoArquivo[i].StartsWith(KEY + "="))
                    {
                        OndeTavaAkey = i;
                        var Partes = ConteudoDoArquivo[i].Split(Convert.ToChar("="));

                        if (Partes.Length >= 2)
                        {
                            ConteudoEmtexto = Partes[1].Trim();

                            if (ConteudoEmtexto != null)
                            {
                                var partesdacor = ConteudoEmtexto.Split(Convert.ToChar(","));

                                if (partesdacor.Length >= 3)
                                {
                                    int p1 = Convert.ToInt32(partesdacor[0]);
                                    int p2 = Convert.ToInt32(partesdacor[1]);
                                    int p3 = Convert.ToInt32(partesdacor[2]);

                                    Conteudo = Color.FromArgb(p1, p2, p3);
                                }
                            }
                        }

                    }

                }

                if (OndeTavaAkey != null)
                {
                    ConteudoDoArquivo.RemoveAt(Convert.ToInt32(OndeTavaAkey));
                }

                return Conteudo;
            }
            catch (Exception)
            {
                return null;             
            }


        }



    }
}

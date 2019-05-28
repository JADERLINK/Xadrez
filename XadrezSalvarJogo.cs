using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    public partial class XadrezClass
    {


        // salvar jogo

        public void SalvarJogo()
        {
            //List<string> Salvar = new List<string>();

            Salvar.Clear();

            //CasaEstaOcupada
            Salvar.Add("&1&");
            for (int id = 0; id < 65; id++)
            {
                if (CasaEstaOcupada[id] == true)
                {
                    Salvar.Add(Convert.ToString(Convert.ToChar(01)));
                }
                else
                {
                    Salvar.Add(Convert.ToString(Convert.ToChar(00)));
                } 
            }

            //CorDaPessa
            Salvar.Add("&2&");
            for (int id = 0; id < 65; id++)
            {
                Salvar.Add(Convert.ToString(Convert.ToChar(CorDaPessa[id])));
            }

            //Pessa
            Salvar.Add("&3&");
            for (int id = 0; id < 65; id++)
            {
                Salvar.Add(Convert.ToString(Convert.ToChar(Pessa[id])));
            }

            //DirecaoDoPeao
            Salvar.Add("&4&");
            for (int id = 0; id < 65; id++)
            {
                Salvar.Add(Convert.ToString(Convert.ToChar(DirecaoDoPeao[id])));
            }

            //APessaJaFoiMovida
            Salvar.Add("&5&");
            for (int id = 0; id < 65; id++)
            {
                if (APessaJaFoiMovida[id] == true)
                {
                    Salvar.Add(Convert.ToString(Convert.ToChar(01)));
                }
                else
                {
                    Salvar.Add(Convert.ToString(Convert.ToChar(00)));
                }
            }

            //PeaoAndouDuasCasas
            Salvar.Add("&6&");
            for (int id = 0; id < 65; id++)
            {
                if (PeaoAndouDuasCasas[id] == true)
                {
                    Salvar.Add(Convert.ToString(Convert.ToChar(01)));
                }
                else
                {
                    Salvar.Add(Convert.ToString(Convert.ToChar(00)));
                }
            }

            //EmqualRodadaAPessaFoiMexida
            Salvar.Add("&7&");
            for (int id = 0; id < 65; id++)
            {
                //EmqualRodadaAPessaFoiMexida[id] = 4294967295;

                var Numero = Convert.ToString(EmqualRodadaAPessaFoiMexida[id]);
                ConvertuintparaByte(Numero);

            }

            // fim das vas das casas

            //Player
            Salvar.Add("&8&");
            Salvar.Add(Convert.ToString(Convert.ToString(Convert.ToChar(Player))));
            //EmqualRodadaOplayerEstaJogando
            Salvar.Add("&9&");
            ConvertuintparaByte(Convert.ToString(EmqualRodadaOplayerEstaJogando));



            //nada, versão do save
            Salvar.Add("&A&");
            Salvar.Add(Convert.ToString(Convert.ToChar(00)));


           // nota, removido tambem

            //ReiEmXeque
            //ChecarSeOReiFoiColocadoEmXeque();
            Salvar.Add("&B&");
            /*
            if (ReiEmXeque == true)
            {
                Salvar.Add(Convert.ToString(Convert.ToChar(01)));
            }
            else
            {
                Salvar.Add(Convert.ToString(Convert.ToChar(00)));
            }
            */
            Salvar.Add(Convert.ToString(Convert.ToChar(00)));


            Salvar.Add("&END&");
            // fim do arquivo
            //Salvar.Add("Fim do arquivo, Xadrez By JADERLINK, Ver: 1.0");
        }


        public void ConvertuintparaByte(string Numero)
        {
            List<string> Unidade = new List<string>();
            Unidade.Clear();

            String[] valor = new string[5];

            foreach (var item in Numero)
            {
                Unidade.Add(Convert.ToString(item));
                //Console.WriteLine("saber " + Convert.ToString(item));
                //Console.WriteLine("saber " + item);
            }

            var Quantidade = Unidade.Count;

            switch (Quantidade)
            {

                case 0:
                    valor[0] = "00";
                    valor[1] = "00";
                    valor[2] = "00";
                    valor[3] = "00";
                    valor[4] = "00";
                    break;
                case 1:
                    valor[0] = "00";
                    valor[1] = "00";
                    valor[2] = "00";
                    valor[3] = "00";
                    valor[4] = "0" + Unidade[0];
                    break;
                case 2:
                    valor[0] = "00";
                    valor[1] = "00";
                    valor[2] = "00";
                    valor[3] = "00";
                    valor[4] = Unidade[0] + Unidade[1];
                    break;
                case 3:
                    valor[0] = "00";
                    valor[1] = "00";
                    valor[2] = "00";
                    valor[3] = "0" + Unidade[1];
                    valor[4] = Unidade[1] + Unidade[2];
                    break;
                case 4:
                    valor[0] = "00";
                    valor[1] = "00";
                    valor[2] = "00";
                    valor[3] = Unidade[0] + Unidade[1];
                    valor[4] = Unidade[2] + Unidade[3];
                    break;
                case 5:
                    valor[0] = "00";
                    valor[1] = "00";
                    valor[2] = "0" + Unidade[0];
                    valor[3] = Unidade[1] + Unidade[2];
                    valor[4] = Unidade[3] + Unidade[4];
                    break;
                case 6:
                    valor[0] = "00";
                    valor[1] = "00";
                    valor[2] = Unidade[0] + Unidade[1];
                    valor[3] = Unidade[2] + Unidade[3];
                    valor[4] = Unidade[4] + Unidade[5];
                    break;
                case 7:
                    valor[0] = "00";
                    valor[1] = "0" + Unidade[0];
                    valor[2] = Unidade[1] + Unidade[2];
                    valor[3] = Unidade[3] + Unidade[4];
                    valor[4] = Unidade[5] + Unidade[6];
                    break;
                case 8:
                    valor[0] = "00";
                    valor[1] = Unidade[0] + Unidade[1];
                    valor[2] = Unidade[2] + Unidade[3];
                    valor[3] = Unidade[4] + Unidade[5];
                    valor[4] = Unidade[6] + Unidade[7];
                    break;
                case 9:
                    valor[0] = "0" + Unidade[0];
                    valor[1] = Unidade[1] + Unidade[2];
                    valor[2] = Unidade[3] + Unidade[4];
                    valor[3] = Unidade[5] + Unidade[6];
                    valor[4] = Unidade[7] + Unidade[8];
                    break;
                case 10:
                    valor[0] = Unidade[0] + Unidade[1];
                    valor[1] = Unidade[2] + Unidade[3];
                    valor[2] = Unidade[4] + Unidade[5];
                    valor[3] = Unidade[6] + Unidade[7];
                    valor[4] = Unidade[8] + Unidade[9];
                    break;
                default:
                    valor[0] = "00";
                    valor[1] = "00";
                    valor[2] = "00";
                    valor[3] = "00";
                    valor[4] = "00";
                    break;
            }

            byte[] ValorPraByte = new byte[5];

            for (int i = 0; i < 5; i++)
            {
                ValorPraByte[i] = Convert.ToByte(valor[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                Salvar.Add(Convert.ToString(Convert.ToChar(ValorPraByte[i])));
            }
        }



    }
}

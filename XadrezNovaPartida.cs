using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    public partial class XadrezClass
    {

        // metodo para preencher as casas, usando em "IniciandoNovaPartida"
        public void Preencher()
        {
            CasaEstaOcupada[tabuleiroID] = CasaEstaOcupadaValor;
            CorDaPessa[tabuleiroID] = CorDaPessaValor;
            Pessa[tabuleiroID] = PessaValor;
            //NomesNosBotoesDotabuleiro[tabuleiroID] = NomesNosBotoesDotabuleiroValor;
            DirecaoDoPeao[tabuleiroID] = DirecaoDoPeaoValor;
            APessaJaFoiMovida[tabuleiroID] = APessaJaFoiMovidaValor;
            //EmqualRodadaAPessaFoiMexida[tabuleiroID] = EmqualRodadaAPessaFoiMexidaValor;
            //Console.WriteLine("Log: Efetuada ação em XadrezClass.Preencher() id: " + tabuleiroID);
        }

        // metodo q define uma nova partida comum
        public void IniciandoNovaPartida()
        {

            ModoEditor = false;

            // começa o com o player 1
            Player = 1;
            RivalDoPlayer = 2;

            EmqualRodadaOplayerEstaJogando = 1;

            //desabilitando tudo
            XequeMate = false;
            HouveEmpate = false;
            //ReiEmXeque = false;
            ColoqueiAPessaEmUmaCasa = false;
            ColoqueiAPessaEmUmaCasa_TabuleiroID = 64;
            TemCasaSelecionada = false;
            Selecionado_TabuleiroID = 64;
            Selecionado_PessaValor = 0;
            Selecionado_CorDaPessaValor = 0;
            Selecionado_DirecaoDoPeaoValor = 0;
            EstouFazendoUmRoque = false;
            CasaDoRoque[0] = 64;
            CasaDoRoque[1] = 64;
            CasaDoRoque[2] = 64;
            CasaDoRoque[3] = 64;
            CasaDoRoqueOndeATorreVai[0] = 64;
            CasaDoRoqueOndeATorreVai[1] = 64;
            CasaDoRoqueOndeATorreVai[2] = 64;
            CasaDoRoqueOndeATorreVai[3] = 64;
            CasaDoRoqueOndeATorreTava[0] = 64;
            CasaDoRoqueOndeATorreTava[1] = 64;
            CasaDoRoqueOndeATorreTava[2] = 64;
            CasaDoRoqueOndeATorreTava[3] = 64;
            //CasaDoPeaoAserRemovidoNoEnPassant = 64;
            CasaDoPeaoAserRemovidoNoEnPassantADireitaOuACima = 64;
            CasaDoPeaoAserRemovidoNoEnPassantAEsquerdaOuABaixo = 64;
            //EstoufazendoUmEnPassant = false;
            EstoufazendoUmEnPassantADireitaOuACima = false;
            EstoufazendoUmEnPassantAEsquerdaOuABaixo = false;
            //CasaQueClicareiParaEnPassant = 64;
            CasaQueClicareiParaEnPassantADireitaOuACima = 64;
            CasaQueClicareiParaEnPassantAEsquerdaOuABaixo = 64;

            ChecandoSeOReiEstaEmXequeMate = false;
            //ReiRivalFoiColocadoEmXeque = false;

            labelInfoRei = "";

            //colocando as peças no tabuleiro

            for (int id = 0; id < 65; id++)
            {

                // libera pra poder clicar em todos os botões
                NaoPodeClicarNesseBotao[id] = false;

                EmqualRodadaAPessaFoiMexida[id] = 0;

                PeaoAndouDuasCasas[id] = false;

                tabuleiroID = id;
                CasaEstaOcupadaValor = false;
                CorDaPessaValor = 0;
                PessaValor = 0;
                //NomesNosBotoesDotabuleiroValor = "";
                DirecaoDoPeaoValor = 0;
                APessaJaFoiMovidaValor = false;
                // define cor e define a ocupação  
                //informa q peça que esta em cada casa do tabuleiro

                switch (id)
                {

                    case 0:
                    case 7:
                        PessaValor = 21;//torre verde
                        CasaEstaOcupadaValor = true;
                        CorDaPessaValor = 2;
                        //NomesNosBotoesDotabuleiroValor = NomeTV;
                        break;
                    case 1:
                    case 6:
                        PessaValor = 22;//cavalo verde
                        CasaEstaOcupadaValor = true;
                        CorDaPessaValor = 2;
                        //NomesNosBotoesDotabuleiroValor = NomeCV;
                        break;
                    case 2:
                    case 5:
                        PessaValor = 23;//bispo verde
                        CasaEstaOcupadaValor = true;
                        CorDaPessaValor = 2;
                        //NomesNosBotoesDotabuleiroValor = NomeBV;
                        break;
                    case 3:
                        PessaValor = 24;//rei verde
                        CasaEstaOcupadaValor = true;
                        CorDaPessaValor = 2;
                        //NomesNosBotoesDotabuleiroValor = NomeREV;
                        break;
                    case 4:
                        PessaValor = 25;//rainha verde
                        CasaEstaOcupadaValor = true;
                        CorDaPessaValor = 2;
                        //NomesNosBotoesDotabuleiroValor = NomeRAV;
                        break;
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                        PessaValor = 26;//peão verde
                        CasaEstaOcupadaValor = true;
                        CorDaPessaValor = 2;
                        //NomesNosBotoesDotabuleiroValor = NomePV;
                        DirecaoDoPeaoValor = 2;
                        break;
                    case 56:
                    case 63:
                        PessaValor = 11;//torre azul
                        CasaEstaOcupadaValor = true;
                        CorDaPessaValor = 1;
                        //NomesNosBotoesDotabuleiroValor = NomeTA;
                        break;
                    case 57:
                    case 62:
                        PessaValor = 12;//cavalo azul
                        CasaEstaOcupadaValor = true;
                        CorDaPessaValor = 1;
                        //NomesNosBotoesDotabuleiroValor = NomeCA;
                        break;
                    case 58:
                    case 61:
                        PessaValor = 13;//bispo azul
                        CasaEstaOcupadaValor = true;
                        CorDaPessaValor = 1;
                        //NomesNosBotoesDotabuleiroValor = NomeBA;
                        break;
                    case 60:
                        PessaValor = 14;//rei azul
                        CasaEstaOcupadaValor = true;
                        CorDaPessaValor = 1;
                        //NomesNosBotoesDotabuleiroValor = NomeREA;
                        break;
                    case 59:
                        PessaValor = 15;//rainha azul
                        CasaEstaOcupadaValor = true;
                        CorDaPessaValor = 1;
                        //NomesNosBotoesDotabuleiroValor = NomeRAA;
                        break;
                    case 48:
                    case 49:
                    case 50:
                    case 51:
                    case 52:
                    case 53:
                    case 54:
                    case 55:
                        PessaValor = 16;//peão azul
                        CasaEstaOcupadaValor = true;
                        CorDaPessaValor = 1;
                        //NomesNosBotoesDotabuleiroValor = NomePA;
                        DirecaoDoPeaoValor = 1;
                        break;
                    case 64: /// casa inexistente
                        PessaValor = 0;//nenhuma peça
                        CasaEstaOcupadaValor = true;
                        CorDaPessaValor = 1;
                        //NomesNosBotoesDotabuleiroValor = "???";
                        APessaJaFoiMovidaValor = true;
                        break;
                    default:
                        PessaValor = 0;//nenhuma peça
                        CasaEstaOcupadaValor = false;
                        CorDaPessaValor = 0;
                       // NomesNosBotoesDotabuleiroValor = "";
                        DirecaoDoPeaoValor = 0;
                        APessaJaFoiMovidaValor = false;
                        break;

                }
                // metodo q contem os cauculos das matrizez.
                Preencher();
            }
            NomeDosBotoesPeloValorDaPessa();
            //Console.WriteLine("log: caregado XadrezClass.IniciandoNovaPartida()");

        }

        // Editar novo jogo
        public void EditarNovoJogo()
        {
            ModoEditor = true;

            // começa o com o player 1
            Player = 1;
            RivalDoPlayer = 2;
            comboBoxPlayerAtualSelectedIndex = 0;

            EmqualRodadaOplayerEstaJogando = 1;
            numericUpDownEmqualRodadaOplayerEstaJogandoValue = 1;

            //desabilitando tudo
            XequeMate = false;
            HouveEmpate = false;
            //ReiEmXeque = false;
            ColoqueiAPessaEmUmaCasa = false;
            ColoqueiAPessaEmUmaCasa_TabuleiroID = 64;
            TemCasaSelecionada = false;
            Selecionado_TabuleiroID = 64;
            Selecionado_PessaValor = 0;
            Selecionado_CorDaPessaValor = 0;
            Selecionado_DirecaoDoPeaoValor = 0;
            EstouFazendoUmRoque = false;
            CasaDoRoque[0] = 64;
            CasaDoRoque[1] = 64;
            CasaDoRoque[2] = 64;
            CasaDoRoque[3] = 64;
            CasaDoRoqueOndeATorreVai[0] = 64;
            CasaDoRoqueOndeATorreVai[1] = 64;
            CasaDoRoqueOndeATorreVai[2] = 64;
            CasaDoRoqueOndeATorreVai[3] = 64;
            CasaDoRoqueOndeATorreTava[0] = 64;
            CasaDoRoqueOndeATorreTava[1] = 64;
            CasaDoRoqueOndeATorreTava[2] = 64;
            CasaDoRoqueOndeATorreTava[3] = 64;
            CasaDoPeaoAserRemovidoNoEnPassantADireitaOuACima = 64;
            CasaDoPeaoAserRemovidoNoEnPassantAEsquerdaOuABaixo = 64;
            EstoufazendoUmEnPassantADireitaOuACima = false;
            EstoufazendoUmEnPassantAEsquerdaOuABaixo = false;
            CasaQueClicareiParaEnPassantADireitaOuACima = 64;
            CasaQueClicareiParaEnPassantAEsquerdaOuABaixo = 64;

            ChecandoSeOReiEstaEmXequeMate = false;
            //ReiRivalFoiColocadoEmXeque = false;

            labelInfoRei = "";

            for (int id = 0; id < 65; id++)
            {
                NaoPodeClicarNesseBotao[id] = false;
                EmqualRodadaAPessaFoiMexida[id] = 0;
                PeaoAndouDuasCasas[id] = false;
                Pessa[id] = 0;
                CasaEstaOcupada[id] = false;
                CorDaPessa[id] = 0;
                DirecaoDoPeao[id] = 0;
                APessaJaFoiMovida[id] = false;
            }

            NomeDosBotoesPeloValorDaPessa();

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    public partial class XadrezClass
    {
        // so tem 2 reis no jogo
        public void EmpateSoTemDoisReisNoTabuleiro()
        {
            List<int> IdDasCasasDasPassaPresentesNoJogo = new List<int>();

            IdDasCasasDasPassaPresentesNoJogo.Clear();

            for (int i = 0; i < 64; i++)
            {
                if (CorDaPessa[i] == 1
                    || CorDaPessa[i] == 2)
                {
                    IdDasCasasDasPassaPresentesNoJogo.Add(i);
                }
            }

            HouveEmpate = false;

            if (IdDasCasasDasPassaPresentesNoJogo.Count == 2
                //&& PassaPresentesNoJogo.Contains(14)
                //&& PassaPresentesNoJogo.Contains(24)
                )
            {
                //entao so tem 2 reis no jogo
                HouveEmpate = true;

                labelInfoRei = T_O_Jogo_Empatou; //"O Jogo Empatou";
                labelInfoReiColor = CORES_PRETO;
            }

        }


        // se tiver rival tiver so um rei, e n poder fazer mais jogadas é cheque mate.
        public void SoUmReiSemjogadasEhXequeMate()
        {
            List<int> PessasDoRival = new List<int>();

            for (int i = 0; i < 64; i++)
            {
                if (CorDaPessa[i] == RivalDoPlayer)
                {
                    PessasDoRival.Add(i);
                }

            }

            if (PessasDoRival.Count == 1)
            {
                ChecandoSeOReiEstaEmXequeMate = true;

                IdentificandoOndeEstaoOsReis();

                // setando vars

                for (int i = 0; i < 7; i++)
                {
                    ReiRivalLinhaEsquerda[i] = 64;
                    ReiRivalLinhaDireita[i] = 64;
                    ReiRivalColunaCima[i] = 64;
                    ReiRivalColunaBaixo[i] = 64;
                    ReiRivalDiagonalDireitaCima[i] = 64;
                    ReiRivalDiagonalEsquerdaCima[i] = 64;
                    ReiRivalDiagonalDireitaBaixo[i] = 64;
                    ReiRivalDiagonalEsquerdaBaixo[i] = 64;
                    ReiRivalCavaloJogadas[i] = 64;
                }
                ReiRivalCavaloJogadas[7] = 64;


                DefineAsColunasLinhasDiagonais(CasaOndeEstaOReiDoRival);

                for (int i = 0; i < 7; i++)
                {
                    ReiRivalLinhaEsquerda[i] = LinhaAesquerdaDaPessa[i];
                    ReiRivalLinhaDireita[i] = LinhaAdireitaDaPessa[i];
                    ReiRivalColunaCima[i] = ColunaAcimaDaPessa[i];
                    ReiRivalColunaBaixo[i] = ColunaAbaixoDaPessa[i];
                    ReiRivalDiagonalDireitaCima[i] = DiagonalDireitaCimaDaPessa[i];
                    ReiRivalDiagonalEsquerdaCima[i] = DiagonalEsquerdaCimaDaPessa[i];
                    ReiRivalDiagonalDireitaBaixo[i] = DiagonalDireitaBaixoDaPessa[i];
                    ReiRivalDiagonalEsquerdaBaixo[i] = DiagonalEsquerdaBaixoDaPessa[i];
                    ReiRivalCavaloJogadas[i] = CavaloJogadas[i];
                }
                ReiRivalCavaloJogadas[7] = CavaloJogadas[7];



                // checagens

                IDCDMQORDRPF_ReiRival.Clear();

                if (ReiRivalLinhaDireita[0] != 64
                    && CorDaPessa[ReiRivalLinhaDireita[0]] != RivalDoPlayer)
                {
                    IDCDMQORDRPF_ReiRival.Add(Convert.ToString(ReiRivalLinhaDireita[0]), ReiRivalLinhaDireita[0]);
                }
                if (ReiRivalLinhaEsquerda[0] != 64
                    && CorDaPessa[ReiRivalLinhaEsquerda[0]] != RivalDoPlayer)
                {
                    IDCDMQORDRPF_ReiRival.Add(Convert.ToString(ReiRivalLinhaEsquerda[0]), ReiRivalLinhaEsquerda[0]);
                }
                if (ReiRivalColunaBaixo[0] != 64
                    && CorDaPessa[ReiRivalColunaBaixo[0]] != RivalDoPlayer)
                {
                    IDCDMQORDRPF_ReiRival.Add(Convert.ToString(ReiRivalColunaBaixo[0]), ReiRivalColunaBaixo[0]);
                }
                if (ReiRivalColunaCima[0] != 64
                    && CorDaPessa[ReiRivalColunaCima[0]] != RivalDoPlayer)
                {
                    IDCDMQORDRPF_ReiRival.Add(Convert.ToString(ReiRivalColunaCima[0]), ReiRivalColunaCima[0]);
                }
                if (ReiRivalDiagonalDireitaBaixo[0] != 64
                    && CorDaPessa[ReiRivalDiagonalDireitaBaixo[0]] != RivalDoPlayer)
                {
                    IDCDMQORDRPF_ReiRival.Add(Convert.ToString(ReiRivalDiagonalDireitaBaixo[0]), ReiRivalDiagonalDireitaBaixo[0]);
                }
                if (ReiRivalDiagonalDireitaCima[0] != 64
                    && CorDaPessa[ReiRivalDiagonalDireitaCima[0]] != RivalDoPlayer)
                {
                    IDCDMQORDRPF_ReiRival.Add(Convert.ToString(ReiRivalDiagonalDireitaCima[0]), ReiRivalDiagonalDireitaCima[0]);
                }
                if (ReiRivalDiagonalEsquerdaBaixo[0] != 64
                    && CorDaPessa[ReiRivalDiagonalEsquerdaBaixo[0]] != RivalDoPlayer)
                {
                    IDCDMQORDRPF_ReiRival.Add(Convert.ToString(ReiRivalDiagonalEsquerdaBaixo[0]), ReiRivalDiagonalEsquerdaBaixo[0]);
                }
                if (ReiRivalDiagonalEsquerdaCima[0] != 64
                    && CorDaPessa[ReiRivalDiagonalEsquerdaCima[0]] != RivalDoPlayer)
                {
                    IDCDMQORDRPF_ReiRival.Add(Convert.ToString(ReiRivalDiagonalEsquerdaCima[0]), ReiRivalDiagonalEsquerdaCima[0]);
                }


                TirandoReiRivalDoXeque(ReiRivalLinhaDireita[0]);
                TirandoReiRivalDoXeque(ReiRivalLinhaEsquerda[0]);
                TirandoReiRivalDoXeque(ReiRivalColunaBaixo[0]);
                TirandoReiRivalDoXeque(ReiRivalColunaCima[0]);
                TirandoReiRivalDoXeque(ReiRivalDiagonalDireitaBaixo[0]);
                TirandoReiRivalDoXeque(ReiRivalDiagonalDireitaCima[0]);
                TirandoReiRivalDoXeque(ReiRivalDiagonalEsquerdaBaixo[0]);
                TirandoReiRivalDoXeque(ReiRivalDiagonalEsquerdaCima[0]);

                if (IDCDMQORDRPF_ReiRival.Count() == 0)
                {
                    ReiRivalFoiColocadoEmXequeMate = true;


                    if (Player == 1)
                    {
                        labelInfoRei = T_Jogador_Azul_Venceu_O_Jogo; //"Jogador Azul Venceu O Jogo";
                        labelInfoReiColor = CORES_AZUL;
                    }
                    else
                    {
                        labelInfoRei = T_Jogador_Verde_Venceu_O_Jogo; //"Jogador Verde Venceu O Jogo";
                        labelInfoReiColor = CORES_VERDE;
                    }

                }

                ChecandoSeOReiEstaEmXequeMate = false;
            }

        }


    }
}

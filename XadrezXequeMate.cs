using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    public partial class XadrezClass
    {

        // METODO Q checa o Xeque mate
        public void ChecandoSeAhXequeMate()
        {
            // estou checando se coloquei o rei rival em Xequemate

            ChecandoSeOReiEstaEmXequeMate = true;

            //ReiEmXeque = false;
            //IDCDLOAPDOR_PodeDefender.Clear();

            IDCDMQDPPF_Player.Clear();

            IdentificandoOndeEstaoOsReis();


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

            //checando se rei rival esta em Xeque

            for (int id = 0; id < 64; id++)
            {
                DefineAsColunasLinhasDiagonais(id);
                Selecionado_TabuleiroID = id;
                Selecionado_PessaValor = Pessa[id];
                Selecionado_CorDaPessaValor = CorDaPessa[id];
                Selecionado_DirecaoDoPeaoValor = DirecaoDoPeao[id];   

                ChecandoSeOReiEstaEmXequeMateChecandoPlayer = true;
                if (Player == 2)
                {
                    switch (Selecionado_PessaValor)
                    {
                        case 21: //torre
                            MovimentosTorre();
                            break;
                        case 22: //cavalo
                            MovimentosCavalo();
                            break;
                        case 23: //bispo
                            MovimentosBispo();
                            break;
                        case 24: //rei
                            MovimentosRei();
                            break;
                        case 25: //rainha
                            MovimentosRainha();
                            break;
                        case 26: //peão
                            MovimentosPeao();
                            break;
                    }
                }
                if (Player == 1)
                {
                    switch (Selecionado_PessaValor)
                    {
                        case 11: //torre
                            MovimentosTorre();
                            break;
                        case 12: //cavalo
                            MovimentosCavalo();
                            break;
                        case 13: //bispo
                            MovimentosBispo();
                            break;
                        case 14: //rei 
                            MovimentosRei();
                            break;
                        case 15: //rainha
                            MovimentosRainha();
                            break;
                        case 16: //peão
                            MovimentosPeao();
                            break;
                    }
                }
                ChecandoSeOReiEstaEmXequeMateChecandoPlayer = false;
            }

           
            // se contem tem xeque
            //ReiRivalFoiColocadoEmXeque = IDCDMQDPPF_Player.ContainsValue(CasaOndeEstaOReiDoRival);


            // casa o rei rival estiver em Xeque ele vai checar se é Xeque mate
            //if (ReiRivalFoiColocadoEmXeque == true)
            if (IDCDMQDPPF_Player.ContainsValue(CasaOndeEstaOReiDoRival) == true)
            {
                //Console.WriteLine("dentro do if: ReiRivalFoiColocadoEmXeque == true");

                if (RivalDoPlayer == 1)
                {
                    labelInfoRei = "Jogador Azul Esta Em Xeque";
                    labelInfoReiColor = CORES_AZUL;
                }
                else
                {
                    labelInfoRei = "Jogador Verde Esta Em Xeque";
                    labelInfoReiColor = CORES_VERDE;
                }
                

                //ReiEmXeque = true;

                ReiRivalNaoPodeSerSalvo = true;
                // o codigo abaixo vai definir se vai manter true, ou false
                // se true vai para próxima checagem, se false n tem Xeque mate

                IdDaCasaDaPessaQueAtacaOReiRival = 64;
                AtacanteEmDirecaoDoReiRival = 0;
                IdDaPessaDoAtacante = 0;
                CasasEntreOAtacanteEORei = 0;

                if (Player == 1)
                {
                    ChecandoXequeMateOqFicaDentroDosPlayers(11, 12, 13, 14, 15, 16, 21, 22, 23, 24, 25, 26);
                }

                if (Player == 2)
                {
                    ChecandoXequeMateOqFicaDentroDosPlayers(21, 22, 23, 24, 25, 26, 11, 12, 13, 14, 15, 16);
                }
            }

            ChecandoSeOReiEstaEmXequeMate = false;
        }


        public void ChecandoXequeMateOqFicaDentroDosPlayers
            (
            byte PlayerTorre,
            byte PlayerCavalo,
            byte PlayerBispo,
            byte PlayerRei,
            byte PlayerRainha,
            byte PlayerPeao,
            byte RivalTorre,
            byte RivalCavalo,
            byte RivalBispo,
            byte RivalRei,
            byte RivalRainha,
            byte RivalPeao
            )
        {
            //Console.WriteLine("Dentro de ChecandoXequeMateOqFicaDentroDosPlayers");


            // checando colunas, linhas e diagonais do rei q esta sobe ataque
            // torre, bispo, rainha.

            for (int i = 0; i < 7; i++)
            {
                ChecandoOndeEstaAPessaAtacante(i, 0, PlayerTorre, PlayerRainha);
                ChecandoOndeEstaAPessaAtacante(i, 1, PlayerTorre, PlayerRainha);
                ChecandoOndeEstaAPessaAtacante(i, 2, PlayerTorre, PlayerRainha);
                ChecandoOndeEstaAPessaAtacante(i, 3, PlayerTorre, PlayerRainha);
                ChecandoOndeEstaAPessaAtacante(i, 4, PlayerBispo, PlayerRainha);
                ChecandoOndeEstaAPessaAtacante(i, 5, PlayerBispo, PlayerRainha);
                ChecandoOndeEstaAPessaAtacante(i, 6, PlayerBispo, PlayerRainha);
                ChecandoOndeEstaAPessaAtacante(i, 7, PlayerBispo, PlayerRainha);

            }

            // checando se é um cavalo atacando o rei
            for (int i = 0; i < 8; i++)
            {
                if (Pessa[ReiRivalCavaloJogadas[i]] == PlayerCavalo)
                {
                    IdDaCasaDaPessaQueAtacaOReiRival = ReiRivalCavaloJogadas[i];
                    AtacanteEmDirecaoDoReiRival = 9;
                    IdDaPessaDoAtacante = PlayerCavalo;
                    CasasEntreOAtacanteEORei = 0;
                    //LiberandoCasaPracolocarPessaNocasoDeXeque(ReiRivalCavaloJogadas[i]);
                }
            }

            // checando peões

            if (Pessa[ReiRivalDiagonalDireitaCima[0]] == PlayerPeao)
            {
                if (DirecaoDoPeao[ReiRivalDiagonalDireitaCima[0]] == 2
                    || DirecaoDoPeao[ReiRivalDiagonalDireitaCima[0]] == 4)
                {
                    IdDaCasaDaPessaQueAtacaOReiRival = ReiRivalDiagonalDireitaCima[0];
                    AtacanteEmDirecaoDoReiRival = 8;
                    IdDaPessaDoAtacante = PlayerPeao;
                    CasasEntreOAtacanteEORei = 0;
                    //LiberandoCasaPracolocarPessaNocasoDeXeque(ReiRivalDiagonalDireitaCima[0]);
                }
            }

            if (Pessa[ReiRivalDiagonalEsquerdaCima[0]] == PlayerPeao)
            {
                if (DirecaoDoPeao[ReiRivalDiagonalEsquerdaCima[0]] == 2
                    || DirecaoDoPeao[ReiRivalDiagonalEsquerdaCima[0]] == 3)
                {
                    IdDaCasaDaPessaQueAtacaOReiRival = ReiRivalDiagonalEsquerdaCima[0];
                    AtacanteEmDirecaoDoReiRival = 6;
                    IdDaPessaDoAtacante = PlayerPeao;
                    CasasEntreOAtacanteEORei = 0;
                    //LiberandoCasaPracolocarPessaNocasoDeXeque(ReiRivalDiagonalEsquerdaCima[0]);
                }
            }


            if (Pessa[ReiRivalDiagonalDireitaBaixo[0]] == PlayerPeao)
            {
                if (DirecaoDoPeao[ReiRivalDiagonalDireitaBaixo[0]] == 1
                    || DirecaoDoPeao[ReiRivalDiagonalDireitaBaixo[0]] == 4)
                {
                    IdDaCasaDaPessaQueAtacaOReiRival = ReiRivalDiagonalDireitaBaixo[0];
                    AtacanteEmDirecaoDoReiRival = 7;
                    IdDaPessaDoAtacante = PlayerPeao;
                    CasasEntreOAtacanteEORei = 0;
                    //LiberandoCasaPracolocarPessaNocasoDeXeque(ReiRivalDiagonalDireitaBaixo[0]);
                }
            }

            if (Pessa[ReiRivalDiagonalEsquerdaBaixo[0]] == PlayerPeao)
            {
                if (DirecaoDoPeao[ReiRivalDiagonalEsquerdaBaixo[0]] == 1
                    || DirecaoDoPeao[ReiRivalDiagonalEsquerdaBaixo[0]] == 3)
                {
                    IdDaCasaDaPessaQueAtacaOReiRival = ReiRivalDiagonalEsquerdaBaixo[0];
                    AtacanteEmDirecaoDoReiRival = 5;
                    IdDaPessaDoAtacante = PlayerPeao;
                    CasasEntreOAtacanteEORei = 0;
                    //LiberandoCasaPracolocarPessaNocasoDeXeque(ReiRivalDiagonalEsquerdaBaixo[0]);
                }
            }

            // fim das checagem da onde o rei esta sendo atacado


            //------------
            // aki define se tem uma peça q pode matar a peça q esta dando Xeque.
            // ou pode bloquea-la

            // agora vou checar se tem uma peça q pode matar a peça atacante

            for (int ib = 0; ib < 7; ib++)
            {
                // aki tem coluna linha e diagonais
                ChecandoSeRivalAtacaAtacante(ib, 0, RivalTorre, RivalRainha, IdDaCasaDaPessaQueAtacaOReiRival);
                ChecandoSeRivalAtacaAtacante(ib, 1, RivalTorre, RivalRainha, IdDaCasaDaPessaQueAtacaOReiRival);
                ChecandoSeRivalAtacaAtacante(ib, 2, RivalTorre, RivalRainha, IdDaCasaDaPessaQueAtacaOReiRival);
                ChecandoSeRivalAtacaAtacante(ib, 3, RivalTorre, RivalRainha, IdDaCasaDaPessaQueAtacaOReiRival);
                ChecandoSeRivalAtacaAtacante(ib, 4, RivalBispo, RivalRainha, IdDaCasaDaPessaQueAtacaOReiRival);
                ChecandoSeRivalAtacaAtacante(ib, 5, RivalBispo, RivalRainha, IdDaCasaDaPessaQueAtacaOReiRival);
                ChecandoSeRivalAtacaAtacante(ib, 6, RivalBispo, RivalRainha, IdDaCasaDaPessaQueAtacaOReiRival);
                ChecandoSeRivalAtacaAtacante(ib, 7, RivalBispo, RivalRainha, IdDaCasaDaPessaQueAtacaOReiRival);

            }

            // checando cavalos

            DefineAsColunasLinhasDiagonais(IdDaCasaDaPessaQueAtacaOReiRival);

            for (int ib2 = 0; ib2 < 8; ib2++)
            {
                if (Pessa[CavaloJogadas[ib2]] == RivalCavalo)
                {
                    //IdDaCasaDoDefensor = CavaloJogadas[ib2];
                    //ReiRivalNaoPodeSerSalvo = false;
                    ReiRivalNaoPodeSerSalvofalseMetodo(IdDaCasaDaPessaQueAtacaOReiRival, CavaloJogadas[ib2]);
                }
            }

            // checando peões

            DefineAsColunasLinhasDiagonais(IdDaCasaDaPessaQueAtacaOReiRival);

            if (Pessa[DiagonalDireitaCimaDaPessa[0]] == RivalPeao)
            {
                if (DirecaoDoPeao[DiagonalDireitaCimaDaPessa[0]] == 2
                    || DirecaoDoPeao[DiagonalDireitaCimaDaPessa[0]] == 4)
                {
                    //IdDaCasaDoDefensor = DiagonalDireitaCimaDaPessa[0];
                    //ReiRivalNaoPodeSerSalvo = false;
                    ReiRivalNaoPodeSerSalvofalseMetodo(IdDaCasaDaPessaQueAtacaOReiRival, DiagonalDireitaCimaDaPessa[0]);
                }
            }

            DefineAsColunasLinhasDiagonais(IdDaCasaDaPessaQueAtacaOReiRival);

            if (Pessa[DiagonalEsquerdaCimaDaPessa[0]] == RivalPeao)
            {
                if (DirecaoDoPeao[DiagonalEsquerdaCimaDaPessa[0]] == 2
                    || DirecaoDoPeao[DiagonalEsquerdaCimaDaPessa[0]] == 3)
                {
                    //IdDaCasaDoDefensor = DiagonalEsquerdaCimaDaPessa[0];
                    //ReiRivalNaoPodeSerSalvo = false;
                    ReiRivalNaoPodeSerSalvofalseMetodo(IdDaCasaDaPessaQueAtacaOReiRival, DiagonalEsquerdaCimaDaPessa[0]);
                }
            }

            DefineAsColunasLinhasDiagonais(IdDaCasaDaPessaQueAtacaOReiRival);

            if (Pessa[DiagonalDireitaBaixoDaPessa[0]] == RivalPeao)
            {
                if (DirecaoDoPeao[DiagonalDireitaBaixoDaPessa[0]] == 1
                    || DirecaoDoPeao[DiagonalDireitaBaixoDaPessa[0]] == 4)
                {
                    //IdDaCasaDoDefensor = DiagonalDireitaBaixoDaPessa[0];
                    //ReiRivalNaoPodeSerSalvo = false;
                    ReiRivalNaoPodeSerSalvofalseMetodo(IdDaCasaDaPessaQueAtacaOReiRival, DiagonalDireitaBaixoDaPessa[0]);
                }
            }

            DefineAsColunasLinhasDiagonais(IdDaCasaDaPessaQueAtacaOReiRival);

            if (Pessa[DiagonalEsquerdaBaixoDaPessa[0]] == RivalPeao)
            {
                if (DirecaoDoPeao[DiagonalEsquerdaBaixoDaPessa[0]] == 1
                    || DirecaoDoPeao[DiagonalEsquerdaBaixoDaPessa[0]] == 3)
                {
                    //IdDaCasaDoDefensor = DiagonalEsquerdaBaixoDaPessa[0];
                    //ReiRivalNaoPodeSerSalvo = false;
                    ReiRivalNaoPodeSerSalvofalseMetodo(IdDaCasaDaPessaQueAtacaOReiRival, DiagonalEsquerdaBaixoDaPessa[0]);
                }
            }

            // chacar q quem ataca é um peao e se pra fazer um en passant pra matar o peao e defender o rei

            //

            //Console.WriteLine("IdDaCasaDaPessaQueAtacaOReiRival: " + IdDaCasaDaPessaQueAtacaOReiRival);

            if (IdDaPessaDoAtacante == PlayerPeao)
            {

                // vai pra cima

                if (IdDaCasaDaPessaQueAtacaOReiRival == 24
                    || IdDaCasaDaPessaQueAtacaOReiRival == 25
                    || IdDaCasaDaPessaQueAtacaOReiRival == 26
                    || IdDaCasaDaPessaQueAtacaOReiRival == 27
                    || IdDaCasaDaPessaQueAtacaOReiRival == 28
                    || IdDaCasaDaPessaQueAtacaOReiRival == 29
                    || IdDaCasaDaPessaQueAtacaOReiRival == 30
                    || IdDaCasaDaPessaQueAtacaOReiRival == 31)
                {
                    DefineAsColunasLinhasDiagonais(IdDaCasaDaPessaQueAtacaOReiRival);
                    MovimentosPeaoEnPassantNoXequeMate(IdDaCasaDaPessaQueAtacaOReiRival, LinhaAdireitaDaPessa[0], ColunaAcimaDaPessa[0], RivalPeao, 1);
                    DefineAsColunasLinhasDiagonais(IdDaCasaDaPessaQueAtacaOReiRival);
                    MovimentosPeaoEnPassantNoXequeMate(IdDaCasaDaPessaQueAtacaOReiRival, LinhaAesquerdaDaPessa[0], ColunaAcimaDaPessa[0], RivalPeao, 1);
                }

                // vai pra baixo

                if (IdDaCasaDaPessaQueAtacaOReiRival == 32
                    || IdDaCasaDaPessaQueAtacaOReiRival == 33
                    || IdDaCasaDaPessaQueAtacaOReiRival == 34
                    || IdDaCasaDaPessaQueAtacaOReiRival == 35
                    || IdDaCasaDaPessaQueAtacaOReiRival == 36
                    || IdDaCasaDaPessaQueAtacaOReiRival == 37
                    || IdDaCasaDaPessaQueAtacaOReiRival == 38
                    || IdDaCasaDaPessaQueAtacaOReiRival == 39)
                {
                    DefineAsColunasLinhasDiagonais(IdDaCasaDaPessaQueAtacaOReiRival);
                    MovimentosPeaoEnPassantNoXequeMate(IdDaCasaDaPessaQueAtacaOReiRival, LinhaAdireitaDaPessa[0], ColunaAbaixoDaPessa[0], RivalPeao, 2);
                    DefineAsColunasLinhasDiagonais(IdDaCasaDaPessaQueAtacaOReiRival);
                    MovimentosPeaoEnPassantNoXequeMate(IdDaCasaDaPessaQueAtacaOReiRival, LinhaAesquerdaDaPessa[0], ColunaAbaixoDaPessa[0], RivalPeao, 2);
                }

                // vai pra direita

                if (IdDaCasaDaPessaQueAtacaOReiRival == 4
                   || IdDaCasaDaPessaQueAtacaOReiRival == 12
                   || IdDaCasaDaPessaQueAtacaOReiRival == 20
                   || IdDaCasaDaPessaQueAtacaOReiRival == 28
                   || IdDaCasaDaPessaQueAtacaOReiRival == 36
                   || IdDaCasaDaPessaQueAtacaOReiRival == 44
                   || IdDaCasaDaPessaQueAtacaOReiRival == 52
                   || IdDaCasaDaPessaQueAtacaOReiRival == 60)
                {
                    DefineAsColunasLinhasDiagonais(IdDaCasaDaPessaQueAtacaOReiRival);
                    MovimentosPeaoEnPassantNoXequeMate(IdDaCasaDaPessaQueAtacaOReiRival, ColunaAbaixoDaPessa[0], LinhaAdireitaDaPessa[0], RivalPeao, 3);
                    DefineAsColunasLinhasDiagonais(IdDaCasaDaPessaQueAtacaOReiRival);
                    MovimentosPeaoEnPassantNoXequeMate(IdDaCasaDaPessaQueAtacaOReiRival, ColunaAcimaDaPessa[0], LinhaAdireitaDaPessa[0], RivalPeao, 3);
                }

                //if (DirecaoDoPeao[IdDaCasaDaPessaQueAtacaOReiRival] == 3) 
                // vai pra esquerda

                if (IdDaCasaDaPessaQueAtacaOReiRival == 3
                   || IdDaCasaDaPessaQueAtacaOReiRival == 11
                   || IdDaCasaDaPessaQueAtacaOReiRival == 19
                   || IdDaCasaDaPessaQueAtacaOReiRival == 27
                   || IdDaCasaDaPessaQueAtacaOReiRival == 35
                   || IdDaCasaDaPessaQueAtacaOReiRival == 43
                   || IdDaCasaDaPessaQueAtacaOReiRival == 51
                   || IdDaCasaDaPessaQueAtacaOReiRival == 59)
                {
                    DefineAsColunasLinhasDiagonais(IdDaCasaDaPessaQueAtacaOReiRival);
                    MovimentosPeaoEnPassantNoXequeMate(IdDaCasaDaPessaQueAtacaOReiRival, ColunaAbaixoDaPessa[0], LinhaAesquerdaDaPessa[0], RivalPeao, 4);
                    DefineAsColunasLinhasDiagonais(IdDaCasaDaPessaQueAtacaOReiRival);
                    MovimentosPeaoEnPassantNoXequeMate(IdDaCasaDaPessaQueAtacaOReiRival, ColunaAcimaDaPessa[0], LinhaAesquerdaDaPessa[0], RivalPeao, 4);
                }

            }



            ////////////////////////////////////////

            // fim das checagem de matar o atacante do rei

            // agora é tentar defender o rei

            // se atacante for cavalo ou peão n da pra defender
            // so se atacante for torre, bispo e rainha

            DefineAsColunasLinhasDiagonais(IdDaCasaDaPessaQueAtacaOReiRival);

            if (AtacanteEmDirecaoDoReiRival == 0
                || AtacanteEmDirecaoDoReiRival == 9)
            {
                AtacanteEmDirecaoDoRei[0] = 64;
                AtacanteEmDirecaoDoRei[1] = 64;
                AtacanteEmDirecaoDoRei[2] = 64;
                AtacanteEmDirecaoDoRei[3] = 64;
                AtacanteEmDirecaoDoRei[4] = 64;
                AtacanteEmDirecaoDoRei[5] = 64;
                AtacanteEmDirecaoDoRei[6] = 64;
            }

            for (int i = 0; i < 7; i++)
            {
                if (AtacanteEmDirecaoDoReiRival == 1)
                {
                    AtacanteEmDirecaoDoRei[i] = ColunaAcimaDaPessa[i];
                }
                if (AtacanteEmDirecaoDoReiRival == 2)
                {
                    AtacanteEmDirecaoDoRei[i] = ColunaAbaixoDaPessa[i];
                }
                if (AtacanteEmDirecaoDoReiRival == 3)
                {
                    AtacanteEmDirecaoDoRei[i] = LinhaAdireitaDaPessa[i];
                }
                if (AtacanteEmDirecaoDoReiRival == 4)
                {
                    AtacanteEmDirecaoDoRei[i] = LinhaAesquerdaDaPessa[i];
                }
                if (AtacanteEmDirecaoDoReiRival == 5)
                {
                    AtacanteEmDirecaoDoRei[i] = DiagonalDireitaCimaDaPessa[i];
                }
                if (AtacanteEmDirecaoDoReiRival == 6)
                {
                    AtacanteEmDirecaoDoRei[i] = DiagonalDireitaBaixoDaPessa[i];
                }
                if (AtacanteEmDirecaoDoReiRival == 7)
                {
                    AtacanteEmDirecaoDoRei[i] = DiagonalEsquerdaCimaDaPessa[i];
                }
                if (AtacanteEmDirecaoDoReiRival == 8)
                {
                    AtacanteEmDirecaoDoRei[i] = DiagonalEsquerdaBaixoDaPessa[i];
                }
            }
            // aki faz as checagem com as casas na frente da pessa q ataca o rei
            if (CasasEntreOAtacanteEORei != 0)
            {
                //CasasEntreOAtacanteEORei -= 1; //n precisa diminuir

                // dentro do for checa todas as casa entre o rei e a peça atacante
                for (int i = 0; i < CasasEntreOAtacanteEORei; i++)
                {
                    //AtacanteEmDirecaoDoRei[i]

                    //LiberandoCasaPracolocarPessaNocasoDeXeque(AtacanteEmDirecaoDoRei[i]);

                    for (int ib = 0; ib < 7; ib++)
                    {
                        // aki tem coluna linha e diagonais
                        ChecandoSeRivalAtacaAtacante(ib, 0, RivalTorre, RivalRainha, AtacanteEmDirecaoDoRei[i]);
                        ChecandoSeRivalAtacaAtacante(ib, 1, RivalTorre, RivalRainha, AtacanteEmDirecaoDoRei[i]);
                        ChecandoSeRivalAtacaAtacante(ib, 2, RivalTorre, RivalRainha, AtacanteEmDirecaoDoRei[i]);
                        ChecandoSeRivalAtacaAtacante(ib, 3, RivalTorre, RivalRainha, AtacanteEmDirecaoDoRei[i]);
                        ChecandoSeRivalAtacaAtacante(ib, 4, RivalBispo, RivalRainha, AtacanteEmDirecaoDoRei[i]);
                        ChecandoSeRivalAtacaAtacante(ib, 5, RivalBispo, RivalRainha, AtacanteEmDirecaoDoRei[i]);
                        ChecandoSeRivalAtacaAtacante(ib, 6, RivalBispo, RivalRainha, AtacanteEmDirecaoDoRei[i]);
                        ChecandoSeRivalAtacaAtacante(ib, 7, RivalBispo, RivalRainha, AtacanteEmDirecaoDoRei[i]);
                    }

                    // checando cavalos

                    DefineAsColunasLinhasDiagonais(AtacanteEmDirecaoDoRei[i]);

                    for (int ib2 = 0; ib2 < 8; ib2++)
                    {
                        if (Pessa[CavaloJogadas[ib2]] == RivalCavalo)
                        {
                            //IdDaCasaDoDefensor = CavaloJogadas[ib2];
                            //ReiRivalNaoPodeSerSalvo = false;
                            ReiRivalNaoPodeSerSalvofalseMetodo(AtacanteEmDirecaoDoRei[i], CavaloJogadas[ib2]);
                        }
                    }


                    // peões

                    DefineAsColunasLinhasDiagonais(AtacanteEmDirecaoDoRei[i]);

                    if (Pessa[ColunaAbaixoDaPessa[0]] == RivalPeao)
                    {
                        if (DirecaoDoPeao[ColunaAbaixoDaPessa[0]] == 1)
                        {
                            //IdDaCasaDoDefensor = ColunaAbaixoDaPessa[0];
                            //ReiRivalNaoPodeSerSalvo = false;
                            ReiRivalNaoPodeSerSalvofalseMetodo(AtacanteEmDirecaoDoRei[i], ColunaAbaixoDaPessa[0]);
                        }
                    }

                    DefineAsColunasLinhasDiagonais(AtacanteEmDirecaoDoRei[i]);

                    if (Pessa[ColunaAcimaDaPessa[0]] == RivalPeao)
                    {
                        if (DirecaoDoPeao[ColunaAcimaDaPessa[0]] == 2)
                        {
                            //IdDaCasaDoDefensor = ColunaAcimaDaPessa[0];
                            //ReiRivalNaoPodeSerSalvo = false;
                            ReiRivalNaoPodeSerSalvofalseMetodo(AtacanteEmDirecaoDoRei[i], ColunaAcimaDaPessa[0]);
                        }
                    }

                    DefineAsColunasLinhasDiagonais(AtacanteEmDirecaoDoRei[i]);

                    if (Pessa[LinhaAdireitaDaPessa[0]] == RivalPeao)
                    {
                        if (DirecaoDoPeao[LinhaAdireitaDaPessa[0]] == 4)
                        {
                            //IdDaCasaDoDefensor = LinhaAdireitaDaPessa[0];
                            //ReiRivalNaoPodeSerSalvo = false;
                            ReiRivalNaoPodeSerSalvofalseMetodo(AtacanteEmDirecaoDoRei[i], LinhaAdireitaDaPessa[0]);
                        }
                    }

                    DefineAsColunasLinhasDiagonais(AtacanteEmDirecaoDoRei[i]);

                    if (Pessa[LinhaAesquerdaDaPessa[0]] == RivalPeao)
                    {
                        if (DirecaoDoPeao[LinhaAesquerdaDaPessa[0]] == 3)
                        {
                            //IdDaCasaDoDefensor = LinhaAesquerdaDaPessa[0];
                            //ReiRivalNaoPodeSerSalvo = false;
                            ReiRivalNaoPodeSerSalvofalseMetodo(AtacanteEmDirecaoDoRei[i], LinhaAesquerdaDaPessa[0]);
                        }
                    }


                    // tem q checar peoes q pulam 2 casas.

                    DefineAsColunasLinhasDiagonais(AtacanteEmDirecaoDoRei[i]);

                    if (Pessa[ColunaAbaixoDaPessa[1]] == RivalPeao
                        && DirecaoDoPeao[ColunaAbaixoDaPessa[1]] == 1
                        && CasaEstaOcupada[ColunaAcimaDaPessa[0]] == false)
                    {
                        if (ColunaAbaixoDaPessa[1] == 48
                            || ColunaAbaixoDaPessa[1] == 49
                            || ColunaAbaixoDaPessa[1] == 50
                            || ColunaAbaixoDaPessa[1] == 51
                            || ColunaAbaixoDaPessa[1] == 52
                            || ColunaAbaixoDaPessa[1] == 53
                            || ColunaAbaixoDaPessa[1] == 54
                            || ColunaAbaixoDaPessa[1] == 55)
                        {
                            //IdDaCasaDoDefensor = ColunaAbaixoDaPessa[1];
                            //ReiRivalNaoPodeSerSalvo = false;
                            ReiRivalNaoPodeSerSalvofalseMetodo(AtacanteEmDirecaoDoRei[i], ColunaAbaixoDaPessa[1]);
                        }

                    }


                    DefineAsColunasLinhasDiagonais(AtacanteEmDirecaoDoRei[i]);

                    if (Pessa[ColunaAcimaDaPessa[1]] == RivalPeao
                        && DirecaoDoPeao[ColunaAcimaDaPessa[1]] == 2
                        && CasaEstaOcupada[ColunaAcimaDaPessa[0]] == false)
                    {
                        if (ColunaAcimaDaPessa[1] == 8
                            || ColunaAcimaDaPessa[1] == 9
                            || ColunaAcimaDaPessa[1] == 10
                            || ColunaAcimaDaPessa[1] == 11
                            || ColunaAcimaDaPessa[1] == 12
                            || ColunaAcimaDaPessa[1] == 13
                            || ColunaAcimaDaPessa[1] == 14
                            || ColunaAcimaDaPessa[1] == 15)
                        {
                            //IdDaCasaDoDefensor = ColunaAcimaDaPessa[1];
                            //ReiRivalNaoPodeSerSalvo = false;
                            ReiRivalNaoPodeSerSalvofalseMetodo(AtacanteEmDirecaoDoRei[i], ColunaAcimaDaPessa[1]);
                        }

                    }


                    DefineAsColunasLinhasDiagonais(AtacanteEmDirecaoDoRei[i]);

                    if (Pessa[LinhaAdireitaDaPessa[1]] == RivalPeao
                        && DirecaoDoPeao[LinhaAdireitaDaPessa[1]] == 4
                        && CasaEstaOcupada[LinhaAdireitaDaPessa[0]] == false)
                    {
                        if (LinhaAdireitaDaPessa[1] == 6
                            || LinhaAdireitaDaPessa[1] == 14
                            || LinhaAdireitaDaPessa[1] == 22
                            || LinhaAdireitaDaPessa[1] == 30
                            || LinhaAdireitaDaPessa[1] == 38
                            || LinhaAdireitaDaPessa[1] == 46
                            || LinhaAdireitaDaPessa[1] == 54
                            || LinhaAdireitaDaPessa[1] == 62)
                        {
                            //IdDaCasaDoDefensor = LinhaAdireitaDaPessa[1];
                            //ReiRivalNaoPodeSerSalvo = false;
                            ReiRivalNaoPodeSerSalvofalseMetodo(AtacanteEmDirecaoDoRei[i], LinhaAdireitaDaPessa[1]);
                        }
                    }


                    DefineAsColunasLinhasDiagonais(AtacanteEmDirecaoDoRei[i]);

                    if (Pessa[LinhaAesquerdaDaPessa[1]] == RivalPeao
                        && DirecaoDoPeao[LinhaAesquerdaDaPessa[1]] == 3
                        && CasaEstaOcupada[LinhaAesquerdaDaPessa[0]] == false)
                    {
                        if (LinhaAesquerdaDaPessa[1] == 1
                            || LinhaAesquerdaDaPessa[1] == 9
                            || LinhaAesquerdaDaPessa[1] == 17
                            || LinhaAesquerdaDaPessa[1] == 25
                            || LinhaAesquerdaDaPessa[1] == 33
                            || LinhaAesquerdaDaPessa[1] == 41
                            || LinhaAesquerdaDaPessa[1] == 49
                            || LinhaAesquerdaDaPessa[1] == 57)
                        {
                            //IdDaCasaDoDefensor = LinhaAesquerdaDaPessa[1];
                            //ReiRivalNaoPodeSerSalvo = false;
                            ReiRivalNaoPodeSerSalvofalseMetodo(AtacanteEmDirecaoDoRei[i], LinhaAesquerdaDaPessa[1]);
                        }
                    }

                    // fim do for
                }

                // fim o do a parte onde a peça tenta defender o rei
            }


            // depois de tentar defenter o rei e n der
            // verifica se dar pra colocar o rei em outra casa.

            if (ReiRivalNaoPodeSerSalvo == true)
            {
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

                TirandoReiRivalDoXequeRoque(0, RivalTorre);
                TirandoReiRivalDoXequeRoque(1, RivalTorre);
                TirandoReiRivalDoXequeRoque(2, RivalTorre);
                TirandoReiRivalDoXequeRoque(3, RivalTorre);

                if (IDCDMQORDRPF_ReiRival.Count() == 0)
                {
                    ReiRivalFoiColocadoEmXequeMate = true;


                    if (Player == 1)
                    {
                        labelInfoRei = "Jogador Azul Venceu O Jogo";
                        labelInfoReiColor = CORES_AZUL;
                    }
                    else
                    {
                        labelInfoRei = "Jogador Verde Venceu O Jogo";
                        labelInfoReiColor = CORES_VERDE;
                    }

                }



            }

        }


        public void ChecandoOndeEstaAPessaAtacante(int i, byte DirecaoDeAnalise, byte IdPessaTorreBispoDoPlayer, byte IdPessaRainhaDoPlayer)
        {
            int[] Direcao = new int[7];
            int[] ContraDirecao = new int[7];


            switch (DirecaoDeAnalise)
            {
                case 0:
                    Direcao = ReiRivalLinhaDireita;
                    break;
                case 1:
                    Direcao = ReiRivalLinhaEsquerda;
                    break;
                case 2:
                    Direcao = ReiRivalColunaBaixo;
                    break;
                case 3:
                    Direcao = ReiRivalColunaCima;
                    break;
                case 4:
                    Direcao = ReiRivalDiagonalDireitaBaixo;
                    break;
                case 5:
                    Direcao = ReiRivalDiagonalDireitaCima;
                    break;
                case 6:
                    Direcao = ReiRivalDiagonalEsquerdaBaixo;
                    break;
                case 7:
                    Direcao = ReiRivalDiagonalEsquerdaCima;
                    break;
            }

           

            if (CasaEstaOcupada[Direcao[i]] == true)
            {

                if (Pessa[Direcao[i]] == IdPessaTorreBispoDoPlayer
                    || Pessa[Direcao[i]] == IdPessaRainhaDoPlayer)
                {

                    DefineAsColunasLinhasDiagonais(Direcao[i]);


                    switch (DirecaoDeAnalise)
                    {
                        case 1:
                            ContraDirecao = LinhaAdireitaDaPessa;
                            break;
                        case 0:
                            ContraDirecao = LinhaAesquerdaDaPessa;
                            break;
                        case 3:
                            ContraDirecao = ColunaAbaixoDaPessa;
                            break;
                        case 2:
                            ContraDirecao = ColunaAcimaDaPessa;
                            break;
                        case 7:
                            ContraDirecao = DiagonalDireitaBaixoDaPessa;
                            break;
                        case 6:
                            ContraDirecao = DiagonalDireitaCimaDaPessa;
                            break;
                        case 5:
                            ContraDirecao = DiagonalEsquerdaBaixoDaPessa;
                            break;
                        case 4:
                            ContraDirecao = DiagonalEsquerdaCimaDaPessa;
                            break;
                    }
                    

                    if (ContraDirecao[0] == CasaOndeEstaOReiDoRival)
                    {
                        IdDaCasaDaPessaQueAtacaOReiRival = Direcao[i];
                        CasasEntreOAtacanteEORei = 0;
                        DefinindoDirecaoDoAtaqueTorreBispoRainha(DirecaoDeAnalise, IdPessaRainhaDoPlayer);
                       // LiberandoCasaPracolocarPessaNocasoDeXeque(Direcao[i]);
                    }

                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && ContraDirecao[1] == CasaOndeEstaOReiDoRival)
                    {
                        IdDaCasaDaPessaQueAtacaOReiRival = Direcao[i];
                        CasasEntreOAtacanteEORei = 1;
                        DefinindoDirecaoDoAtaqueTorreBispoRainha(DirecaoDeAnalise, IdPessaRainhaDoPlayer);
                        //LiberandoCasaPracolocarPessaNocasoDeXeque(Direcao[i]);

                    }
                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraDirecao[1]] == false
                        && ContraDirecao[2] == CasaOndeEstaOReiDoRival)
                    {
                        IdDaCasaDaPessaQueAtacaOReiRival = Direcao[i];
                        CasasEntreOAtacanteEORei = 2;
                        DefinindoDirecaoDoAtaqueTorreBispoRainha(DirecaoDeAnalise, IdPessaRainhaDoPlayer);
                       // LiberandoCasaPracolocarPessaNocasoDeXeque(Direcao[i]);
                    }
                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraDirecao[1]] == false
                        && CasaEstaOcupada[ContraDirecao[2]] == false
                        && ContraDirecao[3] == CasaOndeEstaOReiDoRival)
                    {
                        IdDaCasaDaPessaQueAtacaOReiRival = Direcao[i];
                        CasasEntreOAtacanteEORei = 3;
                        DefinindoDirecaoDoAtaqueTorreBispoRainha(DirecaoDeAnalise, IdPessaRainhaDoPlayer);
                       // LiberandoCasaPracolocarPessaNocasoDeXeque(Direcao[i]);
                    }
                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraDirecao[1]] == false
                        && CasaEstaOcupada[ContraDirecao[2]] == false
                        && CasaEstaOcupada[ContraDirecao[3]] == false
                        && ContraDirecao[4] == CasaOndeEstaOReiDoRival)
                    {
                        IdDaCasaDaPessaQueAtacaOReiRival = Direcao[i];
                        CasasEntreOAtacanteEORei = 4;
                        DefinindoDirecaoDoAtaqueTorreBispoRainha(DirecaoDeAnalise, IdPessaRainhaDoPlayer);
                       // LiberandoCasaPracolocarPessaNocasoDeXeque(Direcao[i]);
                    }
                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraDirecao[1]] == false
                        && CasaEstaOcupada[ContraDirecao[2]] == false
                        && CasaEstaOcupada[ContraDirecao[3]] == false
                        && CasaEstaOcupada[ContraDirecao[4]] == false
                        && ContraDirecao[5] == CasaOndeEstaOReiDoRival)
                    {
                        IdDaCasaDaPessaQueAtacaOReiRival = Direcao[i];
                        CasasEntreOAtacanteEORei = 5;
                        DefinindoDirecaoDoAtaqueTorreBispoRainha(DirecaoDeAnalise, IdPessaRainhaDoPlayer);
                       // LiberandoCasaPracolocarPessaNocasoDeXeque(Direcao[i]);
                    }
                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraDirecao[1]] == false
                        && CasaEstaOcupada[ContraDirecao[2]] == false
                        && CasaEstaOcupada[ContraDirecao[3]] == false
                        && CasaEstaOcupada[ContraDirecao[4]] == false
                        && CasaEstaOcupada[ContraDirecao[5]] == false
                        && ContraDirecao[6] == CasaOndeEstaOReiDoRival)
                    {
                        IdDaCasaDaPessaQueAtacaOReiRival = Direcao[i];
                        CasasEntreOAtacanteEORei = 6;
                        DefinindoDirecaoDoAtaqueTorreBispoRainha(DirecaoDeAnalise, IdPessaRainhaDoPlayer);
                       // LiberandoCasaPracolocarPessaNocasoDeXeque(Direcao[i]);
                    }
                }
            }
        }


        public void DefinindoDirecaoDoAtaqueTorreBispoRainha(byte DirecaoDeAnalise, byte pessa)
        {
            switch (DirecaoDeAnalise)
            {
                case 0:
                    AtacanteEmDirecaoDoReiRival = 4;
                    IdDaPessaDoAtacante = pessa;
                    break;
                case 1:
                    AtacanteEmDirecaoDoReiRival = 3;
                    IdDaPessaDoAtacante = pessa;
                    break;
                case 2:
                    AtacanteEmDirecaoDoReiRival = 1;
                    IdDaPessaDoAtacante = pessa;
                    break;
                case 3:
                    AtacanteEmDirecaoDoReiRival = 2;
                    IdDaPessaDoAtacante = pessa;
                    break;
                case 4:
                    AtacanteEmDirecaoDoReiRival = 7;
                    IdDaPessaDoAtacante = pessa;
                    break;
                case 5:
                    AtacanteEmDirecaoDoReiRival = 8;
                    IdDaPessaDoAtacante = pessa;
                    break;
                case 6:
                    AtacanteEmDirecaoDoReiRival = 5;
                    IdDaPessaDoAtacante = pessa;
                    break;
                case 7:
                    AtacanteEmDirecaoDoReiRival = 6;
                    IdDaPessaDoAtacante = pessa;
                    break;
            }
        }


        public void ChecandoSeRivalAtacaAtacante(int ib, byte DirecaoDeAnalise, byte IdPessaTorreBispoDoRival, byte IdPessaRainhaDoRival, int IdDaCasaParaComparacao)
        {
            int[] Direcao = new int[7];
            int[] ContraDirecao = new int[7];

            DefineAsColunasLinhasDiagonais(IdDaCasaParaComparacao);

            switch (DirecaoDeAnalise)
            {
                case 0:
                    Direcao = LinhaAdireitaDaPessa;
                    break;
                case 1:
                    Direcao = LinhaAesquerdaDaPessa;
                    break;
                case 2:
                    Direcao = ColunaAbaixoDaPessa;
                    break;
                case 3:
                    Direcao = ColunaAcimaDaPessa;
                    break;
                case 4:
                    Direcao = DiagonalDireitaBaixoDaPessa;
                    break;
                case 5:
                    Direcao = DiagonalDireitaCimaDaPessa;
                    break;
                case 6:
                    Direcao = DiagonalEsquerdaBaixoDaPessa;
                    break;
                case 7:
                    Direcao = DiagonalEsquerdaCimaDaPessa;
                    break;
            }

            if (CasaEstaOcupada[Direcao[ib]] == true)
            {
                if (Pessa[Direcao[ib]] == IdPessaTorreBispoDoRival
                    || Pessa[Direcao[ib]] == IdPessaRainhaDoRival)
                {

                    DefineAsColunasLinhasDiagonais(Direcao[ib]);

                    switch (DirecaoDeAnalise)
                    {
                        case 1:
                            ContraDirecao = LinhaAdireitaDaPessa;
                            break;
                        case 0:
                            ContraDirecao = LinhaAesquerdaDaPessa;
                            break;
                        case 3:
                            ContraDirecao = ColunaAbaixoDaPessa;
                            break;
                        case 2:
                            ContraDirecao = ColunaAcimaDaPessa;
                            break;
                        case 7:
                            ContraDirecao = DiagonalDireitaBaixoDaPessa;
                            break;
                        case 6:
                            ContraDirecao = DiagonalDireitaCimaDaPessa;
                            break;
                        case 5:
                            ContraDirecao = DiagonalEsquerdaBaixoDaPessa;
                            break;
                        case 4:
                            ContraDirecao = DiagonalEsquerdaCimaDaPessa;
                            break;
                    }

                    if (ContraDirecao[0] == IdDaCasaParaComparacao)
                    {
                        //IdDaCasaDoDefensor = Direcao[ib];
                        //ReiRivalNaoPodeSerSalvo = false;
                        ReiRivalNaoPodeSerSalvofalseMetodo(IdDaCasaParaComparacao, Direcao[ib]);
                    }


                    if (CasaEstaOcupada[ContraDirecao[0]] == false)
                    {
                        if (ContraDirecao[1] == IdDaCasaParaComparacao)
                        {
                            //IdDaCasaDoDefensor = Direcao[ib];
                            //ReiRivalNaoPodeSerSalvo = false;
                            ReiRivalNaoPodeSerSalvofalseMetodo(IdDaCasaParaComparacao, Direcao[ib]);
                        }
                    }
                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraDirecao[1]] == false)
                    {
                        if (ContraDirecao[2] == IdDaCasaParaComparacao)
                        {
                            //IdDaCasaDoDefensor = Direcao[ib];
                            //ReiRivalNaoPodeSerSalvo = false;
                            ReiRivalNaoPodeSerSalvofalseMetodo(IdDaCasaParaComparacao, Direcao[ib]);
                        }
                    }
                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                       && CasaEstaOcupada[ContraDirecao[1]] == false
                       && CasaEstaOcupada[ContraDirecao[2]] == false)
                    {
                        if (ContraDirecao[3] == IdDaCasaParaComparacao)
                        {
                            //IdDaCasaDoDefensor = Direcao[ib];
                            //ReiRivalNaoPodeSerSalvo = false;
                            ReiRivalNaoPodeSerSalvofalseMetodo(IdDaCasaParaComparacao, Direcao[ib]);
                        }
                    }
                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                       && CasaEstaOcupada[ContraDirecao[1]] == false
                       && CasaEstaOcupada[ContraDirecao[2]] == false
                       && CasaEstaOcupada[ContraDirecao[3]] == false)
                    {
                        if (ContraDirecao[4] == IdDaCasaParaComparacao)
                        {
                            //IdDaCasaDoDefensor = Direcao[ib];
                            //ReiRivalNaoPodeSerSalvo = false;
                            ReiRivalNaoPodeSerSalvofalseMetodo(IdDaCasaParaComparacao, Direcao[ib]);
                        }
                    }
                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                       && CasaEstaOcupada[ContraDirecao[1]] == false
                       && CasaEstaOcupada[ContraDirecao[2]] == false
                       && CasaEstaOcupada[ContraDirecao[3]] == false
                       && CasaEstaOcupada[ContraDirecao[4]] == false)
                    {
                        if (ContraDirecao[5] == IdDaCasaParaComparacao)
                        {
                            //IdDaCasaDoDefensor = Direcao[ib];
                            //ReiRivalNaoPodeSerSalvo = false;
                            ReiRivalNaoPodeSerSalvofalseMetodo(IdDaCasaParaComparacao, Direcao[ib]);
                        }
                    }
                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                       && CasaEstaOcupada[ContraDirecao[1]] == false
                       && CasaEstaOcupada[ContraDirecao[2]] == false
                       && CasaEstaOcupada[ContraDirecao[3]] == false
                       && CasaEstaOcupada[ContraDirecao[4]] == false
                       && CasaEstaOcupada[ContraDirecao[5]] == false)
                    {
                        if (ContraDirecao[6] == IdDaCasaParaComparacao)
                        {
                            //IdDaCasaDoDefensor = Direcao[ib];
                            //ReiRivalNaoPodeSerSalvo = false;
                            ReiRivalNaoPodeSerSalvofalseMetodo(IdDaCasaParaComparacao, Direcao[ib]);
                        }
                    }
                }
            }
        }


        public void ReiRivalNaoPodeSerSalvofalseMetodo(int ID_DA_CASA_ONDE_VAI_A_PESSA_DO_DEFENSOR, int ID_DA_CASA_DO_DEFENSOR)
        {
            // aki to checando se meu movimento esta deixando ou n o rei rival em Xeque. 
            // IdDaCasaDoDefensor  //ID_DA_CASA_DO_DEFENSOR
            // IdDaCasaDaPessaQueAtacaOReiRival //ID_DA_CASA_ONDE_VAI_A_PESSA_DO_DEFENSOR

            // aki coloca a pessa nessa casa
            Pessa[ID_DA_CASA_ONDE_VAI_A_PESSA_DO_DEFENSOR] = Pessa[ID_DA_CASA_DO_DEFENSOR];
            CorDaPessa[ID_DA_CASA_ONDE_VAI_A_PESSA_DO_DEFENSOR] = CorDaPessa[ID_DA_CASA_DO_DEFENSOR];
            CasaEstaOcupada[ID_DA_CASA_ONDE_VAI_A_PESSA_DO_DEFENSOR] = true;
            DirecaoDoPeao[ID_DA_CASA_ONDE_VAI_A_PESSA_DO_DEFENSOR] = DirecaoDoPeao[ID_DA_CASA_DO_DEFENSOR];
            APessaJaFoiMovida[ID_DA_CASA_ONDE_VAI_A_PESSA_DO_DEFENSOR] = true;
            EmqualRodadaAPessaFoiMexida[ID_DA_CASA_ONDE_VAI_A_PESSA_DO_DEFENSOR] = EmqualRodadaOplayerEstaJogando;
            PeaoAndouDuasCasas[ID_DA_CASA_ONDE_VAI_A_PESSA_DO_DEFENSOR] = false;

            // aki limpa a casa onde tava a peça
            Pessa[ID_DA_CASA_DO_DEFENSOR] = 0;
            CorDaPessa[ID_DA_CASA_DO_DEFENSOR] = 0;
            CasaEstaOcupada[ID_DA_CASA_DO_DEFENSOR] = false;
            DirecaoDoPeao[ID_DA_CASA_DO_DEFENSOR] = 0;
            APessaJaFoiMovida[ID_DA_CASA_DO_DEFENSOR] = true;
            EmqualRodadaAPessaFoiMexida[ID_DA_CASA_DO_DEFENSOR] = 0;
            PeaoAndouDuasCasas[ID_DA_CASA_DO_DEFENSOR] = false;

            IDCDMQDPPF_Player.Clear();

            //ReiRivalNaoPodeSerSalvo = false;


            //checando se rei rival esta em Xeque

            for (int id = 0; id < 64; id++)
            {
                DefineAsColunasLinhasDiagonais(id);
                Selecionado_TabuleiroID = id;
                Selecionado_PessaValor = Pessa[id];
                Selecionado_CorDaPessaValor = CorDaPessa[id];
                Selecionado_DirecaoDoPeaoValor = DirecaoDoPeao[id];
                

                ChecandoSeOReiEstaEmXequeMateChecandoPlayer = true;
                if (Player == 2)
                {
                    switch (Selecionado_PessaValor)
                    {
                        case 21: //torre
                            MovimentosTorre();
                            break;
                        case 22: //cavalo
                            MovimentosCavalo();
                            break;
                        case 23: //bispo
                            MovimentosBispo();
                            break;
                        case 24: //rei
                            MovimentosRei();
                            break;
                        case 25: //rainha
                            MovimentosRainha();
                            break;
                        case 26: //peão
                            MovimentosPeao();
                            break;
                    }
                }
                if (Player == 1)
                {
                    switch (Selecionado_PessaValor)
                    {
                        case 11: //torre
                            MovimentosTorre();
                            break;
                        case 12: //cavalo
                            MovimentosCavalo();
                            break;
                        case 13: //bispo
                            MovimentosBispo();
                            break;
                        case 14: //rei 
                            MovimentosRei();
                            break;
                        case 15: //rainha
                            MovimentosRainha();
                            break;
                        case 16: //peão
                            MovimentosPeao();
                            break;
                    }
                }
                ChecandoSeOReiEstaEmXequeMateChecandoPlayer = false;
            }

            /*
            if (IDCDMQDPPF_Player.Count() != 0)
            {
                foreach (var item in IDCDMQDPPF_Player)
                {
                    if (CasaOndeEstaOReiDoRival == item.Value)
                    {
                        ReiRivalNaoPodeSerSalvo = true;
                    }
                }
            }
            */

            if (IDCDMQDPPF_Player.ContainsValue(CasaOndeEstaOReiDoRival) == false)
            {
                ReiRivalNaoPodeSerSalvo = false; 
            }



            // depois de checagem restaura jogada. 

            //restaura o "segundo" backup.
            for (int id = 0; id < 65; id++)
            {
                CasaEstaOcupada[id] = Backup_CasaEstaOcupada[id];
                CorDaPessa[id] = Backup_CorDaPessa[id];
                Pessa[id] = Backup_Pessa[id];
                DirecaoDoPeao[id] = Backup_DirecaoDoPeao[id];
                APessaJaFoiMovida[id] = Backup_APessaJaFoiMovida[id];
                EmqualRodadaAPessaFoiMexida[id] = Backup_EmqualRodadaAPessaFoiMexida[id];
                PeaoAndouDuasCasas[id] = Backup_PeaoAndouDuasCasas[id];
            }

            IDCDMQDPPF_Player.Clear();
        }


        public void TirandoReiRivalDoXeque(int ID_DA_CASA)
        {

            if (CorDaPessa[ID_DA_CASA] != RivalDoPlayer
                && ID_DA_CASA != 64)
            {
                // aki coloca a pessa nessa casa
                Pessa[ID_DA_CASA] = Pessa[CasaOndeEstaOReiDoRival];
                CorDaPessa[ID_DA_CASA] = CorDaPessa[CasaOndeEstaOReiDoRival];
                CasaEstaOcupada[ID_DA_CASA] = true;
                DirecaoDoPeao[ID_DA_CASA] = DirecaoDoPeao[CasaOndeEstaOReiDoRival];
                APessaJaFoiMovida[ID_DA_CASA] = true;
                EmqualRodadaAPessaFoiMexida[ID_DA_CASA] = EmqualRodadaOplayerEstaJogando;
                PeaoAndouDuasCasas[ID_DA_CASA] = false;

                CasaOndeEstaOReiDoRival2 = ID_DA_CASA;

                // aki limpa a casa onde tava a peça
                Pessa[CasaOndeEstaOReiDoRival] = 0;
                CorDaPessa[CasaOndeEstaOReiDoRival] = 0;
                CasaEstaOcupada[CasaOndeEstaOReiDoRival] = false;
                DirecaoDoPeao[CasaOndeEstaOReiDoRival] = 0;
                APessaJaFoiMovida[CasaOndeEstaOReiDoRival] = true;
                EmqualRodadaAPessaFoiMexida[CasaOndeEstaOReiDoRival] = 0;
                PeaoAndouDuasCasas[CasaOndeEstaOReiDoRival] = false;

                IDCDMQDPPF_Player.Clear();

                //checando se rei rival esta em Xeque

                for (int id = 0; id < 64; id++)
                {
                    DefineAsColunasLinhasDiagonais(id);
                    Selecionado_TabuleiroID = id;
                    Selecionado_PessaValor = Pessa[id];
                    Selecionado_CorDaPessaValor = CorDaPessa[id];
                    Selecionado_DirecaoDoPeaoValor = DirecaoDoPeao[id];

                    ChecandoSeOReiEstaEmXequeMateChecandoPlayer = true;
                    if (Player == 2)
                    {
                        switch (Selecionado_PessaValor)
                        {
                            case 21: //torre
                                MovimentosTorre();
                                break;
                            case 22: //cavalo
                                MovimentosCavalo();
                                break;
                            case 23: //bispo
                                MovimentosBispo();
                                break;
                            case 24: //rei
                                MovimentosRei();
                                break;
                            case 25: //rainha
                                MovimentosRainha();
                                break;
                            case 26: //peão
                                MovimentosPeao();
                                break;
                        }
                    }
                    if (Player == 1)
                    {
                        switch (Selecionado_PessaValor)
                        {
                            case 11: //torre
                                MovimentosTorre();
                                break;
                            case 12: //cavalo
                                MovimentosCavalo();
                                break;
                            case 13: //bispo
                                MovimentosBispo();
                                break;
                            case 14: //rei 
                                MovimentosRei();
                                break;
                            case 15: //rainha
                                MovimentosRainha();
                                break;
                            case 16: //peão
                                MovimentosPeao();
                                break;
                        }
                    }
                    ChecandoSeOReiEstaEmXequeMateChecandoPlayer = false;
                }


                if (IDCDMQDPPF_Player.ContainsValue(CasaOndeEstaOReiDoRival2))
                {
                    if (IDCDMQORDRPF_ReiRival.ContainsValue(CasaOndeEstaOReiDoRival2))
                    {
                        IDCDMQORDRPF_ReiRival.Remove(Convert.ToString(CasaOndeEstaOReiDoRival2));
                    }
                }



                // depois de checagem restaura jogada. 

                //restaura o "segundo" backup.
                for (int id = 0; id < 65; id++)
                {
                    CasaEstaOcupada[id] = Backup_CasaEstaOcupada[id];
                    CorDaPessa[id] = Backup_CorDaPessa[id];
                    Pessa[id] = Backup_Pessa[id];
                    DirecaoDoPeao[id] = Backup_DirecaoDoPeao[id];
                    APessaJaFoiMovida[id] = Backup_APessaJaFoiMovida[id];
                    EmqualRodadaAPessaFoiMexida[id] = Backup_EmqualRodadaAPessaFoiMexida[id];
                    PeaoAndouDuasCasas[id] = Backup_PeaoAndouDuasCasas[id];
                }

                IDCDMQDPPF_Player.Clear();

            }


        }

        // o mesmo q o de cima so q para um roque
        public void TirandoReiRivalDoXequeRoque(int Direcao, byte IdDaTorreRival)
        {
            DefineAsColunasLinhasDiagonais(CasaOndeEstaOReiDoRival);

            switch (Direcao)
            {
                case 0:
                    ParaTodasAsDirecoesDaPessa = ColunaAcimaDaPessa;
                    break;
                case 1:
                    ParaTodasAsDirecoesDaPessa = ColunaAbaixoDaPessa;
                    break;
                case 2:
                    ParaTodasAsDirecoesDaPessa = LinhaAdireitaDaPessa;
                    break;
                case 3:
                    ParaTodasAsDirecoesDaPessa = LinhaAesquerdaDaPessa;
                    break;
            }

            // dando "clear" antes de setar algo
            CasaDoRoqueOndeATorreVai[Direcao] = 64;
            CasaDoRoqueOndeATorreTava[Direcao] = 64;
            CasaDoRoque[Direcao] = 64;
            RoqueDirecao[Direcao] = false;



            //ParaTodasAsDirecoesDaPessa
            // configuração de permição para poder fazer um roque:
            // verifica se o rei ja foi movido
            if (APessaJaFoiMovida[CasaOndeEstaOReiDoRival] == false)
            {
                // lado todos
                // aki realiza roque curto
                //checando torre ----direita
                if (APessaJaFoiMovida[ParaTodasAsDirecoesDaPessa[2]] == false)
                {
                    // checando se é uma torre
                    if (Pessa[ParaTodasAsDirecoesDaPessa[2]] == IdDaTorreRival)
                    {
                        // verifica se as casas LD0 e LD1 estão vazias
                        if (CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[0]] == false
                        && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[1]] == false)
                        {
                            // se tudo foi comprido permitido fazer o roque, liberar casa LD1
                            // rei vai na casa LD1 e torre vai na casa LD0
                            CasaDoRoqueOndeATorreVai[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[0]);
                            CasaDoRoqueOndeATorreTava[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[2]);
                            CasaDoRoque[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[1]);
                            RoqueDirecao[Direcao] = true;

                            if (!IDCDMQORDRPF_ReiRival.ContainsValue(CasaDoRoque[Direcao]))
                            {
                                IDCDMQORDRPF_ReiRival.Add(Convert.ToString(CasaDoRoque[Direcao]), CasaDoRoque[Direcao]);
                            }
                        }
                    }
                }
                // aki realiza um roque longo
                //checando torre -----direita
                if (APessaJaFoiMovida[ParaTodasAsDirecoesDaPessa[3]] == false)
                {
                    // checando se é uma torre
                    if (Pessa[ParaTodasAsDirecoesDaPessa[3]] == IdDaTorreRival)
                    {
                        // verifica se as casas LD0 e LD1 e LD2 estão vazias
                        if (CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[0]] == false
                            && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[1]] == false
                            && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[2]] == false)
                        {
                            // se tudo foi comprido permitido fazer o roque, liberar casa LD1
                            // rei vai na casa LD1 e torre vai na casa LD0

                            CasaDoRoqueOndeATorreVai[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[0]);
                            CasaDoRoqueOndeATorreTava[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[3]);
                            CasaDoRoque[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[1]);
                            RoqueDirecao[Direcao] = true;

                            if (!IDCDMQORDRPF_ReiRival.ContainsValue(CasaDoRoque[Direcao]))
                            {
                                IDCDMQORDRPF_ReiRival.Add(Convert.ToString(CasaDoRoque[Direcao]), CasaDoRoque[Direcao]);
                            }
                        }
                    }
                }
            }


            // segunda etapa do codigo


            if (RoqueDirecao[Direcao] == true)
            {

                //torre
                // caloca a torre no lado do rei
                Pessa[CasaDoRoqueOndeATorreVai[Direcao]] = Pessa[CasaDoRoqueOndeATorreTava[Direcao]];
                CorDaPessa[CasaDoRoqueOndeATorreVai[Direcao]] = CorDaPessa[CasaDoRoqueOndeATorreTava[Direcao]];
                CasaEstaOcupada[CasaDoRoqueOndeATorreVai[Direcao]] = true;
                DirecaoDoPeao[CasaDoRoqueOndeATorreVai[Direcao]] = DirecaoDoPeao[CasaDoRoqueOndeATorreTava[Direcao]];
                APessaJaFoiMovida[CasaDoRoqueOndeATorreVai[Direcao]] = true;
                EmqualRodadaAPessaFoiMexida[CasaDoRoqueOndeATorreVai[Direcao]] = EmqualRodadaOplayerEstaJogando;

                // removedo a torre de onde ela tava
                Pessa[CasaDoRoqueOndeATorreTava[Direcao]] = 0;
                CorDaPessa[CasaDoRoqueOndeATorreTava[Direcao]] = 0;
                CasaEstaOcupada[CasaDoRoqueOndeATorreTava[Direcao]] = false;
                DirecaoDoPeao[CasaDoRoqueOndeATorreTava[Direcao]] = 0;
                APessaJaFoiMovida[CasaDoRoqueOndeATorreTava[Direcao]] = true;
                EmqualRodadaAPessaFoiMexida[CasaDoRoqueOndeATorreTava[Direcao]] = 0;


                TirandoReiRivalDoXeque(CasaDoRoque[Direcao]);

            }


            //dando clear depois de verificar
            CasaDoRoqueOndeATorreVai[Direcao] = 64;
            CasaDoRoqueOndeATorreTava[Direcao] = 64;
            CasaDoRoque[Direcao] = 64;
            RoqueDirecao[Direcao] = false;

        }


        // libera a casa pra eu colocar a peça no caso de um Xeque
        /*
        public void LiberandoCasaPracolocarPessaNocasoDeXeque(int ID_DA_CASA)
        {
            if (!IDCDLOAPDOR_PodeDefender.ContainsValue(ID_DA_CASA))
            {
                IDCDLOAPDOR_PodeDefender.Add(Convert.ToString(ID_DA_CASA), ID_DA_CASA);
            }

        }
        */

        // movimento en passant checado no xequemate 

       public void MovimentosPeaoEnPassantNoXequeMate(int ID_DA_QUE_ATACA, int ID_DA_QUE_DEFENDE ,int ID_ACIMA, byte RivalPeao, byte DirecaoDoPeaoValor2)
        {
            if (Pessa[ID_DA_QUE_DEFENDE] == RivalPeao
                    && DirecaoDoPeao[ID_DA_QUE_DEFENDE] == DirecaoDoPeaoValor2
                    && EmqualRodadaAPessaFoiMexida[ID_DA_QUE_ATACA] > EmqualRodadaAPessaFoiMexida[ID_DA_QUE_DEFENDE]
                    && PeaoAndouDuasCasas[ID_DA_QUE_ATACA] == true
                    && CasaEstaOcupada[ID_ACIMA] == false)
            {
                // se tudo foi comprido, o enpassant pode ser realizado
                // se pode ja faz a checagem

                //CasaDoPeaoAserRemovidoNoEnPassantADireitaOuACima = ID_DA_QUE_ATACA;
                //CasaQueClicareiParaEnPassantADireitaOuACima = ID_ACIMA;
                //IdDaCasaDoDefensor = ID_DA_QUE_DEFENDE;

                // aki coloca a pessa nessa casa
                Pessa[ID_ACIMA] = Pessa[ID_DA_QUE_DEFENDE];
                CorDaPessa[ID_ACIMA] = CorDaPessa[ID_DA_QUE_DEFENDE];
                CasaEstaOcupada[ID_ACIMA] = true;
                DirecaoDoPeao[ID_ACIMA] = DirecaoDoPeao[ID_DA_QUE_DEFENDE];
                APessaJaFoiMovida[ID_ACIMA] = true;
                EmqualRodadaAPessaFoiMexida[ID_ACIMA] = EmqualRodadaOplayerEstaJogando;
                PeaoAndouDuasCasas[ID_ACIMA] = false;

                // aki limpa a casa onde tava a peça
                Pessa[ID_DA_QUE_DEFENDE] = 0;
                CorDaPessa[ID_DA_QUE_DEFENDE] = 0;
                CasaEstaOcupada[ID_DA_QUE_DEFENDE] = false;
                DirecaoDoPeao[ID_DA_QUE_DEFENDE] = 0;
                APessaJaFoiMovida[ID_DA_QUE_DEFENDE] = true;
                EmqualRodadaAPessaFoiMexida[ID_DA_QUE_DEFENDE] = 0;
                PeaoAndouDuasCasas[ID_DA_QUE_DEFENDE] = false;

                // aqui tira o peao q ataca

                Pessa[ID_DA_QUE_ATACA] = 0;
                CorDaPessa[ID_DA_QUE_ATACA] = 0;
                CasaEstaOcupada[ID_DA_QUE_ATACA] = false;
                DirecaoDoPeao[ID_DA_QUE_ATACA] = 0;
                APessaJaFoiMovida[ID_DA_QUE_ATACA] = true;
                EmqualRodadaAPessaFoiMexida[ID_DA_QUE_ATACA] = 0;
                PeaoAndouDuasCasas[ID_DA_QUE_ATACA] = false;

                IDCDMQDPPF_Player.Clear();

                //ReiRivalNaoPodeSerSalvo = false;

                //if (!IDCDLOAPDOR_PodeDefender.ContainsValue(ID_ACIMA)){
                //    IDCDLOAPDOR_PodeDefender.Add(Convert.ToString(ID_ACIMA), ID_ACIMA);}


                //checando se rei rival esta em Xeque

                for (int id = 0; id < 64; id++)
                {
                    DefineAsColunasLinhasDiagonais(id);
                    Selecionado_TabuleiroID = id;
                    Selecionado_PessaValor = Pessa[id];
                    Selecionado_CorDaPessaValor = CorDaPessa[id];
                    Selecionado_DirecaoDoPeaoValor = DirecaoDoPeao[id];

                    ChecandoSeOReiEstaEmXequeMateChecandoPlayer = true;
                    if (Player == 2)
                    {
                        switch (Selecionado_PessaValor)
                        {
                            case 21: //torre
                                MovimentosTorre();
                                break;
                            case 22: //cavalo
                                MovimentosCavalo();
                                break;
                            case 23: //bispo
                                MovimentosBispo();
                                break;
                            case 24: //rei
                                MovimentosRei();
                                break;
                            case 25: //rainha
                                MovimentosRainha();
                                break;
                            case 26: //peão
                                MovimentosPeao();
                                break;
                        }
                    }
                    if (Player == 1)
                    {
                        switch (Selecionado_PessaValor)
                        {
                            case 11: //torre
                                MovimentosTorre();
                                break;
                            case 12: //cavalo
                                MovimentosCavalo();
                                break;
                            case 13: //bispo
                                MovimentosBispo();
                                break;
                            case 14: //rei 
                                MovimentosRei();
                                break;
                            case 15: //rainha
                                MovimentosRainha();
                                break;
                            case 16: //peão
                                MovimentosPeao();
                                break;
                        }
                    }
                    ChecandoSeOReiEstaEmXequeMateChecandoPlayer = false;
                }

                if (IDCDMQDPPF_Player.ContainsValue(CasaOndeEstaOReiDoRival) == false)
                {
                    ReiRivalNaoPodeSerSalvo = false;
                    //if (IDCDLOAPDOR_PodeDefender.ContainsValue(ID_ACIMA)) {
                    //    IDCDLOAPDOR_PodeDefender.Remove(Convert.ToString(ID_ACIMA)); }
                }
                


                // depois de checagem restaura jogada. 

                //restaura o "segundo" backup.
                for (int id = 0; id < 65; id++)
                {
                    CasaEstaOcupada[id] = Backup_CasaEstaOcupada[id];
                    CorDaPessa[id] = Backup_CorDaPessa[id];
                    Pessa[id] = Backup_Pessa[id];
                    DirecaoDoPeao[id] = Backup_DirecaoDoPeao[id];
                    APessaJaFoiMovida[id] = Backup_APessaJaFoiMovida[id];
                    EmqualRodadaAPessaFoiMexida[id] = Backup_EmqualRodadaAPessaFoiMexida[id];
                    PeaoAndouDuasCasas[id] = Backup_PeaoAndouDuasCasas[id];
                }

                IDCDMQDPPF_Player.Clear();

            }
        }








     // fim dos metodos
    }
}

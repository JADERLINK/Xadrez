using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    public partial class XadrezClass
    {

        public void MovimentosReiRoque(int Direcao, byte IdDaTorre)
        {

            //ParaTodasAsDirecoesDaPessa

            // configuração de permição para poder fazer um roque:

            // verifica se o rei ja foi movido
            if (APessaJaFoiMovida[Selecionado_TabuleiroID] == false)
            {

                // lado todos

                // aki realiza roque curto
                //checando torre ----direita
                if (APessaJaFoiMovida[ParaTodasAsDirecoesDaPessa[2]] == false)
                {
                    // checando se é uma torre
                    if (Pessa[ParaTodasAsDirecoesDaPessa[2]] == IdDaTorre)
                    {
                        // verifica se as casas LD0 e LD1 estão vazias
                        if (CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[0]] == false
                        && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[1]] == false)
                        {
                            // se tudo foi comprido permitido fazer o roque, liberar casa LD1
                            // rei vai na casa LD1 e torre vai na casa LD0

                            //IDCDMQORDRPF_ReiRival
                            //IDCDLOORNPSC_ReiNaoPode
                            if (IDCDLOORNPSC_ReiNaoPode.ContainsValue(ParaTodasAsDirecoesDaPessa[1]))
                            {
                                // n pode fazer o roque pois da cheque
                                NaoPodeClicarNesseBotao[ParaTodasAsDirecoesDaPessa[1]] = true;
                                NomesNosBotoesDotabuleiro[ParaTodasAsDirecoesDaPessa[1]] = NomeNAOPODECOLOCAR + NomeEmBranco + NomePODEROQUE;
                                DescricaoDosBotoesInfoMov[ParaTodasAsDirecoesDaPessa[1]] = NomeDESCRICAO_NAOPODECOLOCAR + NomeEmBranco + NomeDESCRICAO_PODEROQUE;
                                CORESNASCASAS[ParaTodasAsDirecoesDaPessa[1]] = CORES_NAOPODECOLOCAR;
                                ImagemNasCasasL2[ParaTodasAsDirecoesDaPessa[1]] = IMAGEM_NAOPODEROQUE;
                                CasaDoRoqueOndeATorreVai[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[0]);
                                CasaDoRoqueOndeATorreTava[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[2]);
                                CasaDoRoque[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[1]);
                            }
                            else
                            {
                                // pode fazer o roque normalmente
                                NaoPodeClicarNesseBotao[ParaTodasAsDirecoesDaPessa[1]] = false;
                                NomesNosBotoesDotabuleiro[ParaTodasAsDirecoesDaPessa[1]] = NomePODECOLOCAR + NomeEmBranco + NomePODEROQUE;
                                DescricaoDosBotoesInfoMov[ParaTodasAsDirecoesDaPessa[1]] = NomeDESCRICAO_PODEROQUE;
                                CORESNASCASAS[ParaTodasAsDirecoesDaPessa[1]] = CORES_PODEROQUE;
                                ImagemNasCasasL2[ParaTodasAsDirecoesDaPessa[1]] = IMAGEM_PODEROQUE;
                                CasaDoRoqueOndeATorreVai[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[0]);
                                CasaDoRoqueOndeATorreTava[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[2]);
                                CasaDoRoque[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[1]);
                            }
                        }
                    }
                }
                // aki realiza um roque longo
                //checando torre -----direita
                if (APessaJaFoiMovida[ParaTodasAsDirecoesDaPessa[3]] == false)
                {
                    // checando se é uma torre
                    if (Pessa[ParaTodasAsDirecoesDaPessa[3]] == IdDaTorre)
                    {
                        // verifica se as casas LD0 e LD1 e LD2 estão vazias
                        if (CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[0]] == false
                            && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[1]] == false
                            && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[2]] == false)
                        {
                            // se tudo foi comprido permitido fazer o roque, liberar casa LD1
                            // rei vai na casa LD1 e torre vai na casa LD0

                            if (IDCDLOORNPSC_ReiNaoPode.ContainsValue(ParaTodasAsDirecoesDaPessa[1]))
                            {
                                // n pode fazer o roque pois da cheque
                                NaoPodeClicarNesseBotao[ParaTodasAsDirecoesDaPessa[1]] = true;
                                NomesNosBotoesDotabuleiro[ParaTodasAsDirecoesDaPessa[1]] = NomeNAOPODECOLOCAR + NomeEmBranco + NomePODEROQUE;
                                DescricaoDosBotoesInfoMov[ParaTodasAsDirecoesDaPessa[1]] = NomeDESCRICAO_NAOPODECOLOCAR + NomeEmBranco + NomeDESCRICAO_PODEROQUE;
                                CORESNASCASAS[ParaTodasAsDirecoesDaPessa[1]] = CORES_NAOPODECOLOCAR;
                                ImagemNasCasasL2[ParaTodasAsDirecoesDaPessa[1]] = IMAGEM_NAOPODEROQUE;
                                CasaDoRoqueOndeATorreVai[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[0]);
                                CasaDoRoqueOndeATorreTava[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[3]);
                                CasaDoRoque[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[1]);
                            }
                            else
                            {
                                // pode fazer o roque normalmente
                                NaoPodeClicarNesseBotao[ParaTodasAsDirecoesDaPessa[1]] = false;
                                NomesNosBotoesDotabuleiro[ParaTodasAsDirecoesDaPessa[1]] = NomePODECOLOCAR + NomeEmBranco + NomePODEROQUE;
                                DescricaoDosBotoesInfoMov[ParaTodasAsDirecoesDaPessa[1]] = NomeDESCRICAO_PODEROQUE;
                                CORESNASCASAS[ParaTodasAsDirecoesDaPessa[1]] = CORES_PODEROQUE;
                                ImagemNasCasasL2[ParaTodasAsDirecoesDaPessa[1]] = IMAGEM_PODEROQUE;
                                CasaDoRoqueOndeATorreVai[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[0]);
                                CasaDoRoqueOndeATorreTava[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[3]);
                                CasaDoRoque[Direcao] = Convert.ToByte(ParaTodasAsDirecoesDaPessa[1]);
                            }
                        }
                    }
                }
            }
        }


        public void LocaisOndeNaoPossoColocarORei()
        {
            // IDCDLOORNPSC_ReiNaoPode
            // Selecionado_TabuleiroID

            IDCDLOORNPSC_ReiNaoPode.Clear();

            for (int i = 0; i < 7; i++)
            {
                ReiPlayerLinhaEsquerda[i] = 64;
                ReiPlayerLinhaDireita[i] = 64;
                ReiPlayerColunaCima[i] = 64;
                ReiPlayerColunaBaixo[i] = 64;
                ReiPlayerDiagonalDireitaCima[i] = 64;
                ReiPlayerDiagonalEsquerdaCima[i] = 64;
                ReiPlayerDiagonalDireitaBaixo[i] = 64;
                ReiPlayerDiagonalEsquerdaBaixo[i] = 64;
            }

            DefineAsColunasLinhasDiagonais(Selecionado_TabuleiroID);

            for (int i = 0; i < 7; i++)
            {
                ReiPlayerLinhaEsquerda[i] = LinhaAesquerdaDaPessa[i];
                ReiPlayerLinhaDireita[i] = LinhaAdireitaDaPessa[i];
                ReiPlayerColunaCima[i] = ColunaAcimaDaPessa[i];
                ReiPlayerColunaBaixo[i] = ColunaAbaixoDaPessa[i];
                ReiPlayerDiagonalDireitaCima[i] = DiagonalDireitaCimaDaPessa[i];
                ReiPlayerDiagonalEsquerdaCima[i] = DiagonalEsquerdaCimaDaPessa[i];
                ReiPlayerDiagonalDireitaBaixo[i] = DiagonalDireitaBaixoDaPessa[i];
                ReiPlayerDiagonalEsquerdaBaixo[i] = DiagonalEsquerdaBaixoDaPessa[i];
            }

            //casas normais
            LocaisOndeNaoPossoColocarOReiCasas(ReiPlayerColunaBaixo[0], false, 0);
            LocaisOndeNaoPossoColocarOReiCasas(ReiPlayerColunaCima[0], false, 1);
            LocaisOndeNaoPossoColocarOReiCasas(ReiPlayerLinhaEsquerda[0], false, 2);
            LocaisOndeNaoPossoColocarOReiCasas(ReiPlayerLinhaDireita[0], false, 3);
            LocaisOndeNaoPossoColocarOReiCasas(ReiPlayerDiagonalDireitaCima[0], false, 4);
            LocaisOndeNaoPossoColocarOReiCasas(ReiPlayerDiagonalEsquerdaCima[0], false, 5);
            LocaisOndeNaoPossoColocarOReiCasas(ReiPlayerDiagonalDireitaBaixo[0], false, 6);
            LocaisOndeNaoPossoColocarOReiCasas(ReiPlayerDiagonalEsquerdaBaixo[0], false, 7);

            // casas dos roques
            // o oposto de
            // direçao 0 cima 1 baixo 2 direira 3 esquerda
            // entao
            // 0 baixo 1 cima 2 esquerda 3 direita.

            LocaisOndeNaoPossoColocarOReiCasas(ReiPlayerColunaBaixo[1], true, 0);
            LocaisOndeNaoPossoColocarOReiCasas(ReiPlayerColunaCima[1], true, 1);
            LocaisOndeNaoPossoColocarOReiCasas(ReiPlayerLinhaEsquerda[1], true, 2);
            LocaisOndeNaoPossoColocarOReiCasas(ReiPlayerLinhaDireita[1], true, 3);

        }

        public void LocaisOndeNaoPossoColocarOReiCasas(int ID_DA_CASA_ONDE_VAI_O_REI, bool Roque, byte Direcao)
        {
            
            for (int i = 0; i < 7; i++)
            {
                CPOPCOR_LinhaEsquerda[i] = 64;
                CPOPCOR_LinhaDireita[i] = 64;
                CPOPCOR_ColunaCima[i] = 64;
                CPOPCOR_ColunaBaixo[i] = 64;
                CPOPCOR_DiagonalDireitaCima[i] = 64;
                CPOPCOR_DiagonalEsquerdaCima[i] = 64;
                CPOPCOR_DiagonalDireitaBaixo[i] = 64;
                CPOPCOR_DiagonalEsquerdaBaixo[i] = 64;
                CPOPCOR_CavaloJogadas[i] = 64;
            }
            CPOPCOR_CavaloJogadas[7] = 64;

            DefineAsColunasLinhasDiagonais(ID_DA_CASA_ONDE_VAI_O_REI);

            for (int i = 0; i < 7; i++)
            {
                CPOPCOR_LinhaEsquerda[i] = LinhaAesquerdaDaPessa[i];
                CPOPCOR_LinhaDireita[i] = LinhaAdireitaDaPessa[i];
                CPOPCOR_ColunaCima[i] = ColunaAcimaDaPessa[i];
                CPOPCOR_ColunaBaixo[i] = ColunaAbaixoDaPessa[i];
                CPOPCOR_DiagonalDireitaCima[i] = DiagonalDireitaCimaDaPessa[i];
                CPOPCOR_DiagonalEsquerdaCima[i] = DiagonalEsquerdaCimaDaPessa[i];
                CPOPCOR_DiagonalDireitaBaixo[i] = DiagonalDireitaBaixoDaPessa[i];
                CPOPCOR_DiagonalEsquerdaBaixo[i] = DiagonalEsquerdaBaixoDaPessa[i];
                CPOPCOR_CavaloJogadas[i] = CavaloJogadas[i];
            }
            CPOPCOR_CavaloJogadas[7] = CavaloJogadas[7];

            if (ID_DA_CASA_ONDE_VAI_O_REI != 64)
            {

                if (Roque == true)
                {
                    if (Player == 1)
                    {
                        LocaisOndeNaoPossoColocarOReiCasasRoqueSeparandoPlayers(11, 12, 13, 14, 15, 16, 21, 22, 23, 24, 25, 26, ID_DA_CASA_ONDE_VAI_O_REI, Direcao);
                    }
                    if (Player == 2)
                    {
                        LocaisOndeNaoPossoColocarOReiCasasRoqueSeparandoPlayers(21, 22, 23, 24, 25, 26, 11, 12, 13, 14, 15, 16, ID_DA_CASA_ONDE_VAI_O_REI, Direcao);
                    }
                }
                else
                {
                    if (Player == 1)
                    {
                        LocaisOndeNaoPossoColocarOReiCasasSeparendoPlayers(11, 12, 13, 14, 15, 16, 21, 22, 23, 24, 25, 26, ID_DA_CASA_ONDE_VAI_O_REI, Direcao);
                    }
                    if (Player == 2)
                    {
                        LocaisOndeNaoPossoColocarOReiCasasSeparendoPlayers(21, 22, 23, 24, 25, 26, 11, 12, 13, 14, 15, 16, ID_DA_CASA_ONDE_VAI_O_REI, Direcao);
                    }
                }

            }
        }

        public void LocaisOndeNaoPossoColocarOReiCasasRoqueSeparandoPlayers
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
            byte RivalPeao,
            int ID_DA_CASA_ONDE_VAI_O_REI,
            byte Direcao
            )
        {
            int[] ContraDirecao = new int[7];
            int[] ContraContraDirecao = new int[7];
            // direçao 0 cima 1 baixo 2 direira 3 esquerda

            switch (Direcao)
            {
                case 0:
                    ContraDirecao = CPOPCOR_ColunaCima;
                    ParaTodasAsDirecoesDaPessa = CPOPCOR_ColunaBaixo;
                    break;
                case 1:
                    ContraDirecao = CPOPCOR_ColunaBaixo;
                    ParaTodasAsDirecoesDaPessa = CPOPCOR_ColunaCima;
                    break;
                case 2:
                    ContraDirecao = CPOPCOR_LinhaDireita;
                    ParaTodasAsDirecoesDaPessa = CPOPCOR_LinhaEsquerda;
                    break;
                case 3:
                    ContraDirecao = CPOPCOR_LinhaEsquerda;
                    ParaTodasAsDirecoesDaPessa = CPOPCOR_LinhaDireita;
                    break;
                default:
                    for (int i = 0; i < 7; i++)
                    {
                        ContraDirecao[i] = 64;
                        ParaTodasAsDirecoesDaPessa[i] = 64;
                    }
                    break;

            }

            for (int i = 0; i < 7; i++)
            {
                if (Pessa[ContraDirecao[i]] == RivalTorre
                    || Pessa[ContraDirecao[i]] == RivalRainha)
                {

                    DefineAsColunasLinhasDiagonais(ContraDirecao[i]);

                    switch (Direcao)
                    {
                        case 0:
                            //ContraDirecao = CPOPCOR_ColunaCima;
                            ContraContraDirecao = ColunaAbaixoDaPessa;
                            break;
                        case 1:
                            //ContraDirecao = CPOPCOR_ColunaBaixo;
                            ContraContraDirecao = ColunaAcimaDaPessa;
                            break;
                        case 2:
                            //ContraDirecao = CPOPCOR_LinhaDireita;
                            ContraContraDirecao = LinhaAesquerdaDaPessa;
                            break;
                        case 3:
                            //ContraDirecao = CPOPCOR_LinhaEsquerda;
                            ContraContraDirecao = LinhaAdireitaDaPessa;
                            break;
                    }

                    /*
                    if (ContraContraDirecao[0] == ID_DA_CASA_ONDE_VAI_O_REI) // impossivel
                    {
                        DefineCasaOndeORreiPodeColocarComoNaoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                    }


                    if (CasaEstaOcupada[ContraContraDirecao[0]] == false // imposivel
                        && ContraContraDirecao[1] == ID_DA_CASA_ONDE_VAI_O_REI)
                    {
                        DefineCasaOndeORreiPodeColocarComoNaoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                    }
                    */

                    if (CasaEstaOcupada[ContraContraDirecao[0]] == true // aki ta o rei
                        && Pessa[ContraContraDirecao[0]] == PlayerRei
                        && CasaEstaOcupada[ContraContraDirecao[1]] == false
                        && ContraContraDirecao[2] == ID_DA_CASA_ONDE_VAI_O_REI)
                    {
                        DefineCasaOndeORreiPodeColocarComoNaoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                    }

                    if (CasaEstaOcupada[ContraContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraContraDirecao[1]] == true // aki ta o rei
                        && Pessa[ContraContraDirecao[1]] == PlayerRei
                        && CasaEstaOcupada[ContraContraDirecao[2]] == false
                        && ContraContraDirecao[3] == ID_DA_CASA_ONDE_VAI_O_REI)
                    {
                        DefineCasaOndeORreiPodeColocarComoNaoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                    }

                    if (CasaEstaOcupada[ContraContraDirecao[0]] == false
                      && CasaEstaOcupada[ContraContraDirecao[1]] == false
                      && CasaEstaOcupada[ContraContraDirecao[2]] == true // aki ta o rei
                      && Pessa[ContraContraDirecao[2]] == PlayerRei
                      && CasaEstaOcupada[ContraContraDirecao[3]] == false
                      && ContraContraDirecao[4] == ID_DA_CASA_ONDE_VAI_O_REI)
                    {
                        DefineCasaOndeORreiPodeColocarComoNaoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                    }

                    if (CasaEstaOcupada[ContraContraDirecao[0]] == false
                      && CasaEstaOcupada[ContraContraDirecao[1]] == false
                      && CasaEstaOcupada[ContraContraDirecao[2]] == false
                      && CasaEstaOcupada[ContraContraDirecao[3]] == true // aki ta o rei
                      && Pessa[ContraContraDirecao[3]] == PlayerRei
                      && CasaEstaOcupada[ContraContraDirecao[4]] == false
                      && ContraContraDirecao[5] == ID_DA_CASA_ONDE_VAI_O_REI)
                    {
                        DefineCasaOndeORreiPodeColocarComoNaoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                    }

                    if (CasaEstaOcupada[ContraContraDirecao[0]] == false
                      && CasaEstaOcupada[ContraContraDirecao[1]] == false
                      && CasaEstaOcupada[ContraContraDirecao[2]] == false
                      && CasaEstaOcupada[ContraContraDirecao[3]] == false
                      && CasaEstaOcupada[ContraContraDirecao[4]] == true // aki ta o rei
                      && Pessa[ContraContraDirecao[4]] == PlayerRei
                      && CasaEstaOcupada[ContraContraDirecao[5]] == false
                      && ContraContraDirecao[6] == ID_DA_CASA_ONDE_VAI_O_REI)
                    {
                        DefineCasaOndeORreiPodeColocarComoNaoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                    }

                }
            }

            ///
            // definindo direção do roque como se tiver uma torre/rainha rival é cheque

            // checando roque
            for (int i = 0; i < 7; i++)
            {
                if (Pessa[ParaTodasAsDirecoesDaPessa[i]] == RivalTorre
                    || Pessa[ParaTodasAsDirecoesDaPessa[i]] == RivalRainha)
                {

                    DefineAsColunasLinhasDiagonais(ParaTodasAsDirecoesDaPessa[i]);

                    switch (Direcao)
                    {
                        case 0:
                            ContraDirecao = ColunaAcimaDaPessa;
                            break;
                        case 1:
                            ContraDirecao = ColunaAbaixoDaPessa;
                            break;
                        case 2:
                            ContraDirecao = LinhaAdireitaDaPessa;
                            break;
                        case 3:
                            ContraDirecao = LinhaAesquerdaDaPessa;
                            break;
                    }


                    // checando roque longo
                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraDirecao[1]] == false
                        && CasaEstaOcupada[ContraDirecao[2]] == true // torre
                        && Pessa[ContraDirecao[2]] == PlayerTorre
                        && CasaEstaOcupada[ContraDirecao[3]] == false
                        && ContraDirecao[4] == ID_DA_CASA_ONDE_VAI_O_REI)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                    }

                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraDirecao[1]] == true // torre
                        && Pessa[ContraDirecao[1]] == PlayerTorre
                        && CasaEstaOcupada[ContraDirecao[2]] == false
                        && ContraDirecao[3] == ID_DA_CASA_ONDE_VAI_O_REI)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                    }

                    if (CasaEstaOcupada[ContraDirecao[0]] == true // torre
                        && Pessa[ContraDirecao[0]] == PlayerTorre
                        && CasaEstaOcupada[ContraDirecao[1]] == false
                        && ContraDirecao[2] == ID_DA_CASA_ONDE_VAI_O_REI)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                    }

                    // checando roque curto

                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraDirecao[1]] == false
                        && CasaEstaOcupada[ContraDirecao[2]] == false
                        && CasaEstaOcupada[ContraDirecao[3]] == true // torre
                        && Pessa[ContraDirecao[3]] == PlayerTorre
                        && ContraDirecao[5] == ID_DA_CASA_ONDE_VAI_O_REI)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                    }

                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraDirecao[1]] == false
                        && CasaEstaOcupada[ContraDirecao[2]] == true // torre
                        && Pessa[ContraDirecao[2]] == PlayerTorre
                        && ContraDirecao[4] == ID_DA_CASA_ONDE_VAI_O_REI)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                    }

                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraDirecao[1]] == true // torre
                        && Pessa[ContraDirecao[1]] == PlayerTorre
                        && ContraDirecao[2] == ID_DA_CASA_ONDE_VAI_O_REI)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                    }

                    if (CasaEstaOcupada[ContraDirecao[0]] == true // torre
                        && Pessa[ContraDirecao[0]] == PlayerTorre
                        && ContraDirecao[1] == ID_DA_CASA_ONDE_VAI_O_REI)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                    }

                }

            }


            /*
                ChecandoPessaQuePodeAtacarReiDoPlayer(i, 0, RivalTorre, RivalRainha, ID_DA_CASA); //direita
                ChecandoPessaQuePodeAtacarReiDoPlayer(i, 1, RivalTorre, RivalRainha, ID_DA_CASA); //esquerda
                ChecandoPessaQuePodeAtacarReiDoPlayer(i, 2, RivalTorre, RivalRainha, ID_DA_CASA); // baixo
                ChecandoPessaQuePodeAtacarReiDoPlayer(i, 3, RivalTorre, RivalRainha, ID_DA_CASA); // cima
                ChecandoPessaQuePodeAtacarReiDoPlayer(i, 4, RivalBispo, RivalRainha, ID_DA_CASA); // 
                ChecandoPessaQuePodeAtacarReiDoPlayer(i, 5, RivalBispo, RivalRainha, ID_DA_CASA); //
                ChecandoPessaQuePodeAtacarReiDoPlayer(i, 6, RivalBispo, RivalRainha, ID_DA_CASA); //
                ChecandoPessaQuePodeAtacarReiDoPlayer(i, 7, RivalBispo, RivalRainha, ID_DA_CASA); //
             */

            // resto do codigo normal

            for (int i = 0; i < 7; i++)
            {
                switch (Direcao)
                {
                    case 0:
                    case 1:
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 0, RivalTorre, RivalRainha, ID_DA_CASA_ONDE_VAI_O_REI, true); //direita
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 1, RivalTorre, RivalRainha, ID_DA_CASA_ONDE_VAI_O_REI, true); //esquerda
                        break;
                    case 2:
                    case 3:
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 2, RivalTorre, RivalRainha, ID_DA_CASA_ONDE_VAI_O_REI, true); // baixo
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 3, RivalTorre, RivalRainha, ID_DA_CASA_ONDE_VAI_O_REI, true); // cima
                        break;
                }

                // diagonais
                ChecandoPessaQuePodeAtacarReiDoPlayer(i, 4, RivalBispo, RivalRainha, ID_DA_CASA_ONDE_VAI_O_REI, true); // 
                ChecandoPessaQuePodeAtacarReiDoPlayer(i, 5, RivalBispo, RivalRainha, ID_DA_CASA_ONDE_VAI_O_REI, true); //
                ChecandoPessaQuePodeAtacarReiDoPlayer(i, 6, RivalBispo, RivalRainha, ID_DA_CASA_ONDE_VAI_O_REI, true); //
                ChecandoPessaQuePodeAtacarReiDoPlayer(i, 7, RivalBispo, RivalRainha, ID_DA_CASA_ONDE_VAI_O_REI, true); //

            }


            // checando se é um cavalo atacando a casa onde o rei pode se colocardo
            for (int i = 0; i < 8; i++)
            {
                if (Pessa[CPOPCOR_CavaloJogadas[i]] == RivalCavalo)
                {
                    DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                }
            }

            // checando peões

            if (Pessa[CPOPCOR_DiagonalDireitaCima[0]] == RivalPeao)
            {
                if (DirecaoDoPeao[CPOPCOR_DiagonalDireitaCima[0]] == 2
                    || DirecaoDoPeao[CPOPCOR_DiagonalDireitaCima[0]] == 4)
                {
                    DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                }
            }

            if (Pessa[CPOPCOR_DiagonalEsquerdaCima[0]] == RivalPeao)
            {
                if (DirecaoDoPeao[CPOPCOR_DiagonalEsquerdaCima[0]] == 2
                    || DirecaoDoPeao[CPOPCOR_DiagonalEsquerdaCima[0]] == 3)
                {
                    DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                }
            }


            if (Pessa[CPOPCOR_DiagonalDireitaBaixo[0]] == RivalPeao)
            {
                if (DirecaoDoPeao[CPOPCOR_DiagonalDireitaBaixo[0]] == 1
                    || DirecaoDoPeao[CPOPCOR_DiagonalDireitaBaixo[0]] == 4)
                {
                    DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                }
            }

            if (Pessa[CPOPCOR_DiagonalEsquerdaBaixo[0]] == RivalPeao)
            {
                if (DirecaoDoPeao[CPOPCOR_DiagonalEsquerdaBaixo[0]] == 1
                    || DirecaoDoPeao[CPOPCOR_DiagonalEsquerdaBaixo[0]] == 3)
                {
                    DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA_ONDE_VAI_O_REI);
                }
            }

            // checando rei rival

            ChecandoSeReiRivalAtacaRei(CPOPCOR_ColunaBaixo[0], ID_DA_CASA_ONDE_VAI_O_REI, RivalRei);
            ChecandoSeReiRivalAtacaRei(CPOPCOR_ColunaCima[0], ID_DA_CASA_ONDE_VAI_O_REI, RivalRei);
            ChecandoSeReiRivalAtacaRei(CPOPCOR_DiagonalDireitaBaixo[0], ID_DA_CASA_ONDE_VAI_O_REI, RivalRei);
            ChecandoSeReiRivalAtacaRei(CPOPCOR_DiagonalDireitaCima[0], ID_DA_CASA_ONDE_VAI_O_REI, RivalRei);
            ChecandoSeReiRivalAtacaRei(CPOPCOR_DiagonalEsquerdaBaixo[0], ID_DA_CASA_ONDE_VAI_O_REI, RivalRei);
            ChecandoSeReiRivalAtacaRei(CPOPCOR_DiagonalEsquerdaCima[0], ID_DA_CASA_ONDE_VAI_O_REI, RivalRei);
            ChecandoSeReiRivalAtacaRei(CPOPCOR_LinhaDireita[0], ID_DA_CASA_ONDE_VAI_O_REI, RivalRei);
            ChecandoSeReiRivalAtacaRei(CPOPCOR_LinhaEsquerda[0], ID_DA_CASA_ONDE_VAI_O_REI, RivalRei);


        }



        public void LocaisOndeNaoPossoColocarOReiCasasSeparendoPlayers
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
            byte RivalPeao,
            int ID_DA_CASA,
            byte Direcao
            )
        {

            // checando colunas, linhas e diagonais da casa onde o rei pode colocar q esta sobe ataque
            // torre, bispo, rainha.

            switch (Direcao)
            {
                case 0: // baixo
                    if (Pessa[ID_DA_CASA] == RivalTorre
                        || Pessa[ID_DA_CASA] == RivalRainha)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_ColunaCima[1]);
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_LinhaDireita[0]);
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_LinhaEsquerda[0]);
                    }
                    if (Pessa[ID_DA_CASA] == RivalRainha)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_DiagonalDireitaCima[0]);
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_DiagonalEsquerdaCima[0]);
                    }
                    break;
                case 1: // cima
                    if (Pessa[ID_DA_CASA] == RivalTorre
                       || Pessa[ID_DA_CASA] == RivalRainha)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_ColunaBaixo[1]);
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_LinhaDireita[0]);
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_LinhaEsquerda[0]);
                    }
                    if (Pessa[ID_DA_CASA] == RivalRainha)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_DiagonalDireitaBaixo[0]);
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_DiagonalEsquerdaBaixo[0]);
                    }
                    break;
                case 2: // esquerda
                    if (Pessa[ID_DA_CASA] == RivalTorre
                       || Pessa[ID_DA_CASA] == RivalRainha)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_LinhaDireita[1]);
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_ColunaCima[0]);
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_ColunaBaixo[0]);
                    }
                    if (Pessa[ID_DA_CASA] == RivalRainha)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_DiagonalDireitaBaixo[0]);
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_DiagonalDireitaCima[0]);
                    }
                    break;
                case 3: // direita
                    if (Pessa[ID_DA_CASA] == RivalTorre
                       || Pessa[ID_DA_CASA] == RivalRainha)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_LinhaEsquerda[1]);
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_ColunaCima[0]);
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_ColunaBaixo[0]);
                    }
                    if (Pessa[ID_DA_CASA] == RivalRainha)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_DiagonalEsquerdaBaixo[0]);
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_DiagonalEsquerdaCima[0]);
                    }
                    break;
                case 4: // DC
                    if (Pessa[ID_DA_CASA] == RivalBispo
                       || Pessa[ID_DA_CASA] == RivalRainha)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_DiagonalEsquerdaBaixo[1]);
                    }
                    if (Pessa[ID_DA_CASA] == RivalRainha)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_ColunaBaixo[0]);
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_LinhaEsquerda[0]);
                    }
                    break;
                case 5: // EC
                    if (Pessa[ID_DA_CASA] == RivalBispo
                       || Pessa[ID_DA_CASA] == RivalRainha)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_DiagonalDireitaBaixo[1]);
                    }
                    if (Pessa[ID_DA_CASA] == RivalRainha)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_ColunaBaixo[0]);
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_LinhaDireita[0]);
                    }
                    break;
                case 6: // DB
                    if (Pessa[ID_DA_CASA] == RivalBispo
                       || Pessa[ID_DA_CASA] == RivalRainha)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_DiagonalEsquerdaCima[1]);
                    }
                    if (Pessa[ID_DA_CASA] == RivalRainha)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_ColunaCima[0]);
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_LinhaEsquerda[0]);
                    }
                    break;
                case 7: // EB
                    if (Pessa[ID_DA_CASA] == RivalBispo
                       || Pessa[ID_DA_CASA] == RivalRainha)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_DiagonalDireitaCima[1]);
                    }
                    if (Pessa[ID_DA_CASA] == RivalRainha)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_ColunaCima[0]);
                        DefineCasaOndeORreiPodeColocarComoAtacada(CPOPCOR_LinhaDireita[0]);
                    }
                    break;
            }

            for (int i = 0; i < 7; i++)
            {
                
                switch (Direcao)
                {
                    case 0: // baixo
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 0, RivalTorre, RivalRainha, ID_DA_CASA, false); // direita
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 1, RivalTorre, RivalRainha, ID_DA_CASA, false); // esquerda
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 2, RivalTorre, RivalRainha, ID_DA_CASA, true); // baixo
                        //ChecandoPessaQuePodeAtacarReiDoPlayer(i, 3, RivalTorre, RivalRainha, ID_DA_CASA, true); // cima
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 4, RivalBispo, RivalRainha, ID_DA_CASA, false); // DB
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 5, RivalBispo, RivalRainha, ID_DA_CASA, false); // DC
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 6, RivalBispo, RivalRainha, ID_DA_CASA, false); // EB
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 7, RivalBispo, RivalRainha, ID_DA_CASA, false); // EC
                        break;
                    case 1: // cima
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 0, RivalTorre, RivalRainha, ID_DA_CASA, false); // direita
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 1, RivalTorre, RivalRainha, ID_DA_CASA, false); // esquerda
                        //ChecandoPessaQuePodeAtacarReiDoPlayer(i, 2, RivalTorre, RivalRainha, ID_DA_CASA, true); // baixo
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 3, RivalTorre, RivalRainha, ID_DA_CASA, true); // cima
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 4, RivalBispo, RivalRainha, ID_DA_CASA, false); // DB
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 5, RivalBispo, RivalRainha, ID_DA_CASA, false); // DC
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 6, RivalBispo, RivalRainha, ID_DA_CASA, false); // EB
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 7, RivalBispo, RivalRainha, ID_DA_CASA, false); // EC
                        break;
                    case 2: // esquerda
                        //ChecandoPessaQuePodeAtacarReiDoPlayer(i, 0, RivalTorre, RivalRainha, ID_DA_CASA, true); // direita
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 1, RivalTorre, RivalRainha, ID_DA_CASA, true); // esquerda
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 2, RivalTorre, RivalRainha, ID_DA_CASA, false); // baixo
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 3, RivalTorre, RivalRainha, ID_DA_CASA, false); // cima
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 4, RivalBispo, RivalRainha, ID_DA_CASA, false); // DB
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 5, RivalBispo, RivalRainha, ID_DA_CASA, false); // DC
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 6, RivalBispo, RivalRainha, ID_DA_CASA, false); // EB
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 7, RivalBispo, RivalRainha, ID_DA_CASA, false); // EC
                        break;
                    case 3: // direita
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 0, RivalTorre, RivalRainha, ID_DA_CASA, true); // direita
                        //ChecandoPessaQuePodeAtacarReiDoPlayer(i, 1, RivalTorre, RivalRainha, ID_DA_CASA, true); // esquerda
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 2, RivalTorre, RivalRainha, ID_DA_CASA, false); // baixo
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 3, RivalTorre, RivalRainha, ID_DA_CASA, false); // cima
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 4, RivalBispo, RivalRainha, ID_DA_CASA, false); // DB
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 5, RivalBispo, RivalRainha, ID_DA_CASA, false); // DC
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 6, RivalBispo, RivalRainha, ID_DA_CASA, false); // EB
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 7, RivalBispo, RivalRainha, ID_DA_CASA, false); // EC
                        break;
                    case 4: // DC
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 0, RivalTorre, RivalRainha, ID_DA_CASA, false); // direita
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 1, RivalTorre, RivalRainha, ID_DA_CASA, false); // esquerda
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 2, RivalTorre, RivalRainha, ID_DA_CASA, false); // baixo
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 3, RivalTorre, RivalRainha, ID_DA_CASA, false); // cima
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 4, RivalBispo, RivalRainha, ID_DA_CASA, true); // DB
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 5, RivalBispo, RivalRainha, ID_DA_CASA, true); // DC
                        //ChecandoPessaQuePodeAtacarReiDoPlayer(i, 6, RivalBispo, RivalRainha, ID_DA_CASA, true); // EB
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 7, RivalBispo, RivalRainha, ID_DA_CASA, true); // EC
                        break;
                    case 5: // EC
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 0, RivalTorre, RivalRainha, ID_DA_CASA, false); // direita
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 1, RivalTorre, RivalRainha, ID_DA_CASA, false); // esquerda
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 2, RivalTorre, RivalRainha, ID_DA_CASA, false); // baixo
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 3, RivalTorre, RivalRainha, ID_DA_CASA, false); // cima
                        //ChecandoPessaQuePodeAtacarReiDoPlayer(i, 4, RivalBispo, RivalRainha, ID_DA_CASA, true); // DB
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 5, RivalBispo, RivalRainha, ID_DA_CASA, true); // DC
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 6, RivalBispo, RivalRainha, ID_DA_CASA, true); // EB
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 7, RivalBispo, RivalRainha, ID_DA_CASA, true); // EC
                        break;
                    case 6: // DB
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 0, RivalTorre, RivalRainha, ID_DA_CASA, false); // direita
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 1, RivalTorre, RivalRainha, ID_DA_CASA, false); // esquerda
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 2, RivalTorre, RivalRainha, ID_DA_CASA, false); // baixo
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 3, RivalTorre, RivalRainha, ID_DA_CASA, false); // cima
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 4, RivalBispo, RivalRainha, ID_DA_CASA, true); // DB
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 5, RivalBispo, RivalRainha, ID_DA_CASA, true); // DC
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 6, RivalBispo, RivalRainha, ID_DA_CASA, true); // EB
                        //ChecandoPessaQuePodeAtacarReiDoPlayer(i, 7, RivalBispo, RivalRainha, ID_DA_CASA, true); // EC
                        break;
                    case 7: // EB
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 0, RivalTorre, RivalRainha, ID_DA_CASA, false); // direita
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 1, RivalTorre, RivalRainha, ID_DA_CASA, false); // esquerda
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 2, RivalTorre, RivalRainha, ID_DA_CASA, false); // baixo
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 3, RivalTorre, RivalRainha, ID_DA_CASA, false); // cima
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 4, RivalBispo, RivalRainha, ID_DA_CASA, true); // DB
                        //ChecandoPessaQuePodeAtacarReiDoPlayer(i, 5, RivalBispo, RivalRainha, ID_DA_CASA, true); // DC
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 6, RivalBispo, RivalRainha, ID_DA_CASA, true); // EB
                        ChecandoPessaQuePodeAtacarReiDoPlayer(i, 7, RivalBispo, RivalRainha, ID_DA_CASA, true); // EC
                        break;
                }
                
                
                //ChecandoPessaQuePodeAtacarReiDoPlayer(i, 0, RivalTorre, RivalRainha, ID_DA_CASA, true); // direita
                //ChecandoPessaQuePodeAtacarReiDoPlayer(i, 1, RivalTorre, RivalRainha, ID_DA_CASA, true); // esquerda
                //ChecandoPessaQuePodeAtacarReiDoPlayer(i, 2, RivalTorre, RivalRainha, ID_DA_CASA, true); // baixo
                //ChecandoPessaQuePodeAtacarReiDoPlayer(i, 3, RivalTorre, RivalRainha, ID_DA_CASA, true); // cima
                //ChecandoPessaQuePodeAtacarReiDoPlayer(i, 4, RivalBispo, RivalRainha, ID_DA_CASA, true); // DB
                //ChecandoPessaQuePodeAtacarReiDoPlayer(i, 5, RivalBispo, RivalRainha, ID_DA_CASA, true); // DC
                //ChecandoPessaQuePodeAtacarReiDoPlayer(i, 6, RivalBispo, RivalRainha, ID_DA_CASA, true); // EB
                //ChecandoPessaQuePodeAtacarReiDoPlayer(i, 7, RivalBispo, RivalRainha, ID_DA_CASA, true); // EC
                
            }



            // checando se é um cavalo atacando a casa onde o rei pode se colocardo
            for (int i = 0; i < 8; i++)
            {
                if (Pessa[CPOPCOR_CavaloJogadas[i]] == RivalCavalo)
                {
                    DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                }
            }

            // checando peões

            if (Pessa[CPOPCOR_DiagonalDireitaCima[0]] == RivalPeao)
            {
                if (DirecaoDoPeao[CPOPCOR_DiagonalDireitaCima[0]] == 2
                    || DirecaoDoPeao[CPOPCOR_DiagonalDireitaCima[0]] == 4)
                {
                    DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                }
            }

            if (Pessa[CPOPCOR_DiagonalEsquerdaCima[0]] == RivalPeao)
            {
                if (DirecaoDoPeao[CPOPCOR_DiagonalEsquerdaCima[0]] == 2
                    || DirecaoDoPeao[CPOPCOR_DiagonalEsquerdaCima[0]] == 3)
                {
                    DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                }
            }


            if (Pessa[CPOPCOR_DiagonalDireitaBaixo[0]] == RivalPeao)
            {
                if (DirecaoDoPeao[CPOPCOR_DiagonalDireitaBaixo[0]] == 1
                    || DirecaoDoPeao[CPOPCOR_DiagonalDireitaBaixo[0]] == 4)
                {
                    DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                }
            }

            if (Pessa[CPOPCOR_DiagonalEsquerdaBaixo[0]] == RivalPeao)
            {
                if (DirecaoDoPeao[CPOPCOR_DiagonalEsquerdaBaixo[0]] == 1
                    || DirecaoDoPeao[CPOPCOR_DiagonalEsquerdaBaixo[0]] == 3)
                {
                    DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                }
            }


            // checando rei rival

            ChecandoSeReiRivalAtacaRei(CPOPCOR_ColunaBaixo[0], ID_DA_CASA, RivalRei);
            ChecandoSeReiRivalAtacaRei(CPOPCOR_ColunaCima[0], ID_DA_CASA, RivalRei);
            ChecandoSeReiRivalAtacaRei(CPOPCOR_DiagonalDireitaBaixo[0], ID_DA_CASA, RivalRei);
            ChecandoSeReiRivalAtacaRei(CPOPCOR_DiagonalDireitaCima[0], ID_DA_CASA, RivalRei);
            ChecandoSeReiRivalAtacaRei(CPOPCOR_DiagonalEsquerdaBaixo[0], ID_DA_CASA, RivalRei);
            ChecandoSeReiRivalAtacaRei(CPOPCOR_DiagonalEsquerdaCima[0], ID_DA_CASA, RivalRei);
            ChecandoSeReiRivalAtacaRei(CPOPCOR_LinhaDireita[0], ID_DA_CASA, RivalRei);
            ChecandoSeReiRivalAtacaRei(CPOPCOR_LinhaEsquerda[0], ID_DA_CASA, RivalRei);


        }



        public void ChecandoSeReiRivalAtacaRei(int Direcao ,int ID_DA_CASA, byte RivalRei)
        {
            if (Pessa[Direcao] == RivalRei
                && Direcao != 64)
            {
                DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
            }
        }

        public void ChecandoPessaQuePodeAtacarReiDoPlayer(int i, byte DirecaoDeAnalise, byte IdPessaTorreBispoDoPlayerRival, byte IdPessaRainhaDoPlayerRival, int ID_DA_CASA, bool MultiCasas)
        {
            int[] Direcao = new int[7];
            int[] ContraDirecao = new int[7];

            switch (DirecaoDeAnalise)
            {
                case 0:
                    Direcao = CPOPCOR_LinhaDireita;
                    break;
                case 1:
                    Direcao = CPOPCOR_LinhaEsquerda;
                    break;
                case 2:
                    Direcao = CPOPCOR_ColunaBaixo;
                    break;
                case 3:
                    Direcao = CPOPCOR_ColunaCima;
                    break;
                case 4:
                    Direcao = CPOPCOR_DiagonalDireitaBaixo;
                    break;
                case 5:
                    Direcao = CPOPCOR_DiagonalDireitaCima;
                    break;
                case 6:
                    Direcao = CPOPCOR_DiagonalEsquerdaBaixo;
                    break;
                case 7:
                    Direcao = CPOPCOR_DiagonalEsquerdaCima;
                    break;
            }

            if (CasaEstaOcupada[Direcao[i]] == true)
            {

                if (Pessa[Direcao[i]] == IdPessaTorreBispoDoPlayerRival
                    || Pessa[Direcao[i]] == IdPessaRainhaDoPlayerRival)
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


                    if (ContraDirecao[0] == ID_DA_CASA)
                    {
                        if (CorDaPessa[ID_DA_CASA] == RivalDoPlayer
                            || CorDaPessa[ID_DA_CASA] == Player)
                        {
                            DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                        }
                        else
                        {
                            DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                            if (MultiCasas == true)
                            {
                                DefineCasaOndeORreiPodeColocarComoAtacada(ContraDirecao[1]);
                                DefineCasaOndeORreiPodeColocarComoAtacada(ContraDirecao[2]);
                                DefineCasaOndeORreiPodeColocarComoAtacada(ContraDirecao[3]);
                            }
                           
                        }
                    }

                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && ContraDirecao[1] == ID_DA_CASA)
                    {
                        if (CorDaPessa[ID_DA_CASA] == RivalDoPlayer
                            || CorDaPessa[ID_DA_CASA] == Player)
                        {
                            DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                        }
                        else
                        {

                            DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                            if (MultiCasas == true)
                            {
                                DefineCasaOndeORreiPodeColocarComoAtacada(ContraDirecao[2]);               
                                DefineCasaOndeORreiPodeColocarComoAtacada(ContraDirecao[3]); 
                                DefineCasaOndeORreiPodeColocarComoAtacada(ContraDirecao[4]);
                            }
                        }
                    }
                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraDirecao[1]] == false
                        && ContraDirecao[2] == ID_DA_CASA)
                    {
                        if (CorDaPessa[ID_DA_CASA] == RivalDoPlayer
                            || CorDaPessa[ID_DA_CASA] == Player)
                        {
                            DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                        }
                        else
                        {
                            DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                            if (MultiCasas == true)
                            {
                                DefineCasaOndeORreiPodeColocarComoAtacada(ContraDirecao[3]);            
                                DefineCasaOndeORreiPodeColocarComoAtacada(ContraDirecao[4]);
                                DefineCasaOndeORreiPodeColocarComoAtacada(ContraDirecao[5]);
                            }
                        }
                    }
                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraDirecao[1]] == false
                        && CasaEstaOcupada[ContraDirecao[2]] == false
                        && ContraDirecao[3] == ID_DA_CASA)
                    {
                        if (CorDaPessa[ID_DA_CASA] == RivalDoPlayer
                            || CorDaPessa[ID_DA_CASA] == Player)
                        {
                            DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                        }
                        else
                        {

                            DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                            if (MultiCasas == true)
                            {
                                DefineCasaOndeORreiPodeColocarComoAtacada(ContraDirecao[4]);
                                DefineCasaOndeORreiPodeColocarComoAtacada(ContraDirecao[5]);
                                DefineCasaOndeORreiPodeColocarComoAtacada(ContraDirecao[6]);
                            }
                        }
                    }
                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraDirecao[1]] == false
                        && CasaEstaOcupada[ContraDirecao[2]] == false
                        && CasaEstaOcupada[ContraDirecao[3]] == false
                        && ContraDirecao[4] == ID_DA_CASA)
                    {
                        if (CorDaPessa[ID_DA_CASA] == RivalDoPlayer
                            || CorDaPessa[ID_DA_CASA] == Player)
                        {
                            DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                        }
                        else
                        {
                            DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                            if (MultiCasas == true)
                            {
                                DefineCasaOndeORreiPodeColocarComoAtacada(ContraDirecao[5]);
                                DefineCasaOndeORreiPodeColocarComoAtacada(ContraDirecao[6]);
                            }

                        }
                    }
                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraDirecao[1]] == false
                        && CasaEstaOcupada[ContraDirecao[2]] == false
                        && CasaEstaOcupada[ContraDirecao[3]] == false
                        && CasaEstaOcupada[ContraDirecao[4]] == false
                        && ContraDirecao[5] == ID_DA_CASA)
                    {
                        if(CorDaPessa[ID_DA_CASA] == RivalDoPlayer
                            || CorDaPessa[ID_DA_CASA] == Player)
                        {
                            DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                        }
                        else
                        {
                            DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);

                            if (MultiCasas == true)
                            {
                                DefineCasaOndeORreiPodeColocarComoAtacada(ContraDirecao[6]);
                            }
                        }
                    }
                    if (CasaEstaOcupada[ContraDirecao[0]] == false
                        && CasaEstaOcupada[ContraDirecao[1]] == false
                        && CasaEstaOcupada[ContraDirecao[2]] == false
                        && CasaEstaOcupada[ContraDirecao[3]] == false
                        && CasaEstaOcupada[ContraDirecao[4]] == false
                        && CasaEstaOcupada[ContraDirecao[5]] == false
                        && ContraDirecao[6] == ID_DA_CASA)
                    {
                        DefineCasaOndeORreiPodeColocarComoAtacada(ID_DA_CASA);
                    }
                }
            }
        }

        public void DefineCasaOndeORreiPodeColocarComoAtacada(int ID_DA_CASA)
        {
            if (!IDCDLOORNPSC_ReiNaoPode.ContainsValue(ID_DA_CASA))
            {
                IDCDLOORNPSC_ReiNaoPode.Add(Convert.ToString(ID_DA_CASA), ID_DA_CASA);
            }
        }

        public void DefineCasaOndeORreiPodeColocarComoNaoAtacada(int ID_DA_CASA)
        {
            if (IDCDLOORNPSC_ReiNaoPode.ContainsValue(ID_DA_CASA))
            {
                IDCDLOORNPSC_ReiNaoPode.Remove(Convert.ToString(ID_DA_CASA));
            }
        }


        public void MovimentosRei()
        {
            EhUmRei = true;

            LocaisOndeNaoPossoColocarORei();

            DefineAsColunasLinhasDiagonais(Selecionado_TabuleiroID);

            // configuração de permição para poder fazer um roque:
            if (DefineAcasaComoClicavelBool == true)
            {

                if (CorDaPessa[Selecionado_TabuleiroID] == 1)
                {
                    //pra cima
                    ParaTodasAsDirecoesDaPessa = ColunaAcimaDaPessa;
                    MovimentosReiRoque(0, 11);

                    //pra baixo
                    ParaTodasAsDirecoesDaPessa = ColunaAbaixoDaPessa;
                    MovimentosReiRoque(1, 11);

                    //pra direita
                    ParaTodasAsDirecoesDaPessa = LinhaAdireitaDaPessa;
                    MovimentosReiRoque(2, 11);

                    //pra esquerda
                    ParaTodasAsDirecoesDaPessa = LinhaAesquerdaDaPessa;
                    MovimentosReiRoque(3, 11);
                }

                if (CorDaPessa[Selecionado_TabuleiroID] == 2)
                {
                    //pra cima
                    ParaTodasAsDirecoesDaPessa = ColunaAcimaDaPessa;
                    MovimentosReiRoque(0, 21);

                    //pra baixo
                    ParaTodasAsDirecoesDaPessa = ColunaAbaixoDaPessa;
                    MovimentosReiRoque(1, 21);

                    //pra direita
                    ParaTodasAsDirecoesDaPessa = LinhaAdireitaDaPessa;
                    MovimentosReiRoque(2, 21);

                    //pra esquerda
                    ParaTodasAsDirecoesDaPessa = LinhaAesquerdaDaPessa;
                    MovimentosReiRoque(3, 21);
                }

            }

            // os 8 movimentos q o rei pode fazer de andar 1 casa para cada direção
            if (CorDaPessa[ColunaAcimaDaPessa[0]] != Player)
            {
                DefineAcasaComoClicavel(ColunaAcimaDaPessa[0]);
            }

            if (CorDaPessa[ColunaAbaixoDaPessa[0]] != Player)
            {
                DefineAcasaComoClicavel(ColunaAbaixoDaPessa[0]);
            }

            if (CorDaPessa[LinhaAdireitaDaPessa[0]] != Player)
            {
                DefineAcasaComoClicavel(LinhaAdireitaDaPessa[0]);
            }

            if (CorDaPessa[LinhaAesquerdaDaPessa[0]] != Player)
            {
                DefineAcasaComoClicavel(LinhaAesquerdaDaPessa[0]);
            }

            if (CorDaPessa[DiagonalDireitaCimaDaPessa[0]] != Player)
            {
                DefineAcasaComoClicavel(DiagonalDireitaCimaDaPessa[0]);
            }

            if (CorDaPessa[DiagonalEsquerdaCimaDaPessa[0]] != Player)
            {
                DefineAcasaComoClicavel(DiagonalEsquerdaCimaDaPessa[0]);
            }

            if (CorDaPessa[DiagonalDireitaBaixoDaPessa[0]] != Player)
            {
                DefineAcasaComoClicavel(DiagonalDireitaBaixoDaPessa[0]);
            }

            if (CorDaPessa[DiagonalEsquerdaBaixoDaPessa[0]] != Player)
            {
                DefineAcasaComoClicavel(DiagonalEsquerdaBaixoDaPessa[0]);
            }
            // fim dos 8 movimentos

            EhUmRei = false;
        }

    }
}

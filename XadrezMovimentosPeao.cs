using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    public partial class XadrezClass
    {

        public void MovimentosPeao()
        {

            if (Selecionado_DirecaoDoPeaoValor == 1)
            {
                MovimentoPeaoVaiPraCima();
            }
            else if (Selecionado_DirecaoDoPeaoValor == 2)
            {
                MovimentoPeaoVaiPraBaixo();
            }
            else if (Selecionado_DirecaoDoPeaoValor == 3)
            {
                MovimentoPeaoVaiPraDireita();
            }
            else if (Selecionado_DirecaoDoPeaoValor == 4)
            {
                MovimentoPeaoVaiPraEsquerda();
            }
            else { }
        }

        public void MovimentosPeaoEnPassant(int ID_AO_LADO, int ID_NA_DIAGONAL, bool Lado)
        {
            // so funciona no jogo normal
            if (DefineAcasaComoClicavelBool == true)
            {

                // para jogador azul
                if (Pessa[Selecionado_TabuleiroID] == 16
                    && Pessa[ID_AO_LADO] == 26
                    && EmqualRodadaAPessaFoiMexida[ID_AO_LADO] > EmqualRodadaAPessaFoiMexida[Selecionado_TabuleiroID]
                    && PeaoAndouDuasCasas[ID_AO_LADO] == true
                    && CasaEstaOcupada[ID_NA_DIAGONAL] == false)
                {
                    // se tudo foi comprido, o enpassant pode ser realizado
                    if (Lado == true)
                    {
                        CasaDoPeaoAserRemovidoNoEnPassantADireitaOuACima = ID_AO_LADO;
                        CasaQueClicareiParaEnPassantADireitaOuACima = ID_NA_DIAGONAL;
                    }
                    else
                    {
                        CasaDoPeaoAserRemovidoNoEnPassantAEsquerdaOuABaixo = ID_AO_LADO;
                        CasaQueClicareiParaEnPassantAEsquerdaOuABaixo = ID_NA_DIAGONAL;
                    }


                    if (SeReiFicaEmXequeNaoPodeColocar == true)
                    {
                        if (IDCDLOSCDREX_NaoPodeColocar.ContainsValue(ID_NA_DIAGONAL))
                        {
                            // nao pode
                            NaoPodeClicarNesseBotao[ID_NA_DIAGONAL] = true;
                            NomesNosBotoesDotabuleiro[ID_NA_DIAGONAL] = NomeNAOPODECOLOCAR + NomePODEENPASSANT;
                            DescricaoDosBotoesInfoMov[ID_NA_DIAGONAL] = NomeDESCRICAO_NAOPODECOLOCAR + NomeEmBranco + NomeDESCRICAO_PODEENPASSANT;
                            CORESNASCASAS[ID_NA_DIAGONAL] = CORES_NAOPODECOLOCAR;
                            ImagemNasCasasL2[ID_NA_DIAGONAL] = IMAGEM_NAOPODERENPASSANT;
                            IDDosStatusDeSelecao[ID_NA_DIAGONAL] = 08;
                        }
                        else
                        {
                            // pode
                            NaoPodeClicarNesseBotao[ID_NA_DIAGONAL] = false;
                            NomesNosBotoesDotabuleiro[ID_NA_DIAGONAL] = NomePODEENPASSANT;
                            DescricaoDosBotoesInfoMov[ID_NA_DIAGONAL] = NomeDESCRICAO_PODEENPASSANT;
                            CORESNASCASAS[ID_NA_DIAGONAL] = CORES_PODEENPASSANT;
                            ImagemNasCasasL2[ID_NA_DIAGONAL] = IMAGEM_PODERENPASSANT;
                            IDDosStatusDeSelecao[ID_NA_DIAGONAL] = 05;
                        }
                    }
                    else
                    {
                        // nada
                        NaoPodeClicarNesseBotao[ID_NA_DIAGONAL] = false;
                        NomesNosBotoesDotabuleiro[ID_NA_DIAGONAL] = NomePODEENPASSANT;
                        DescricaoDosBotoesInfoMov[ID_NA_DIAGONAL] = NomeDESCRICAO_PODEENPASSANT;
                        CORESNASCASAS[ID_NA_DIAGONAL] = CORES_PODEENPASSANT;
                        ImagemNasCasasL2[ID_NA_DIAGONAL] = IMAGEM_PODERENPASSANT;
                        IDDosStatusDeSelecao[ID_NA_DIAGONAL] = 05;
                    }


                }

                // para jogador verde
                if (Pessa[Selecionado_TabuleiroID] == 26
                    && Pessa[ID_AO_LADO] == 16
                    && EmqualRodadaAPessaFoiMexida[ID_AO_LADO] > EmqualRodadaAPessaFoiMexida[Selecionado_TabuleiroID]
                    && PeaoAndouDuasCasas[ID_AO_LADO] == true
                    && CasaEstaOcupada[ID_NA_DIAGONAL] == false)
                {
                    // se tudo foi comprido, o enpassant pode ser realizado 
                    if (Lado == true)
                    {
                        CasaDoPeaoAserRemovidoNoEnPassantADireitaOuACima = ID_AO_LADO;
                        CasaQueClicareiParaEnPassantADireitaOuACima = ID_NA_DIAGONAL;
                    }
                    else
                    {
                        CasaDoPeaoAserRemovidoNoEnPassantAEsquerdaOuABaixo = ID_AO_LADO;
                        CasaQueClicareiParaEnPassantAEsquerdaOuABaixo = ID_NA_DIAGONAL;
                    }


                    if (SeReiFicaEmXequeNaoPodeColocar == true)
                    {
                        if (IDCDLOSCDREX_NaoPodeColocar.ContainsValue(ID_NA_DIAGONAL))
                        {
                            // nao pode
                            NaoPodeClicarNesseBotao[ID_NA_DIAGONAL] = true;
                            NomesNosBotoesDotabuleiro[ID_NA_DIAGONAL] = NomeNAOPODECOLOCAR + NomePODEENPASSANT;
                            DescricaoDosBotoesInfoMov[ID_NA_DIAGONAL] = NomeDESCRICAO_NAOPODECOLOCAR + NomeEmBranco + NomeDESCRICAO_PODEENPASSANT;
                            CORESNASCASAS[ID_NA_DIAGONAL] = CORES_NAOPODECOLOCAR;
                            ImagemNasCasasL2[ID_NA_DIAGONAL] = IMAGEM_NAOPODERENPASSANT;
                            IDDosStatusDeSelecao[ID_NA_DIAGONAL] = 08;
                        }
                        else
                        {
                            // pode
                            NaoPodeClicarNesseBotao[ID_NA_DIAGONAL] = false;
                            NomesNosBotoesDotabuleiro[ID_NA_DIAGONAL] = NomePODEENPASSANT;
                            DescricaoDosBotoesInfoMov[ID_NA_DIAGONAL] = NomeDESCRICAO_PODEENPASSANT;
                            CORESNASCASAS[ID_NA_DIAGONAL] = CORES_PODEENPASSANT;
                            ImagemNasCasasL2[ID_NA_DIAGONAL] = IMAGEM_PODERENPASSANT;
                            IDDosStatusDeSelecao[ID_NA_DIAGONAL] = 05;
                        }
                    }
                    else
                    {
                        // nada
                        NaoPodeClicarNesseBotao[ID_NA_DIAGONAL] = false;
                        NomesNosBotoesDotabuleiro[ID_NA_DIAGONAL] = NomePODEENPASSANT;
                        DescricaoDosBotoesInfoMov[ID_NA_DIAGONAL] = NomeDESCRICAO_PODEENPASSANT;
                        CORESNASCASAS[ID_NA_DIAGONAL] = CORES_PODEENPASSANT;
                        ImagemNasCasasL2[ID_NA_DIAGONAL] = IMAGEM_PODERENPASSANT;
                        IDDosStatusDeSelecao[ID_NA_DIAGONAL] = 05;
                    }

                }
            }
        }

        public void MovimentoPeaoVaiPraCima()
        {

            ParaTodasAsDirecoesDaPessa = ColunaAcimaDaPessa;


            // aki ve se pode par um passo pra frente
            if (CasaEstaOcupada[ColunaAcimaDaPessa[0]] == false)
            {
                DefineAcasaComoClicavel(ColunaAcimaDaPessa[0]);
            }

            // aki ve se tem uma peça inimiga na diaginal direita
            if (CorDaPessa[DiagonalDireitaCimaDaPessa[0]] == RivalDoPlayer)
            {
                DefineAcasaComoClicavel(DiagonalDireitaCimaDaPessa[0]);
            }

            // aki ve se tem uma peça inimiga na diaginal esquerda
            if (CorDaPessa[DiagonalEsquerdaCimaDaPessa[0]] == RivalDoPlayer)
            {
                DefineAcasaComoClicavel(DiagonalEsquerdaCimaDaPessa[0]);
            }

            // aki verifica se posso pular duas casas na posição inicial do peão.

            if (Selecionado_TabuleiroID == 48
                || Selecionado_TabuleiroID == 49
                || Selecionado_TabuleiroID == 50
                || Selecionado_TabuleiroID == 51
                || Selecionado_TabuleiroID == 52
                || Selecionado_TabuleiroID == 53
                || Selecionado_TabuleiroID == 54
                || Selecionado_TabuleiroID == 55)
            {
                if (CasaEstaOcupada[ColunaAcimaDaPessa[1]] == false
                   && CasaEstaOcupada[ColunaAcimaDaPessa[0]] == false)
                {
                    DefineAcasaComoClicavel(ColunaAcimaDaPessa[1]);
                }
            }


            // aki verifica se eu posso fazer um en passant

            if (Selecionado_TabuleiroID == 24
                || Selecionado_TabuleiroID == 25
                || Selecionado_TabuleiroID == 26
                || Selecionado_TabuleiroID == 27
                || Selecionado_TabuleiroID == 28
                || Selecionado_TabuleiroID == 29
                || Selecionado_TabuleiroID == 30
                || Selecionado_TabuleiroID == 31)
            {

                MovimentosPeaoEnPassant(LinhaAdireitaDaPessa[0], DiagonalDireitaCimaDaPessa[0], true);
                MovimentosPeaoEnPassant(LinhaAesquerdaDaPessa[0], DiagonalEsquerdaCimaDaPessa[0], false);

            }

        }

        public void MovimentoPeaoVaiPraBaixo()
        {


            ParaTodasAsDirecoesDaPessa = ColunaAbaixoDaPessa;

            // aki ve se pode par um passo pra frente
            if (CasaEstaOcupada[ColunaAbaixoDaPessa[0]] == false)
            {
                DefineAcasaComoClicavel(ColunaAbaixoDaPessa[0]);
            }

            // aki ve se tem uma peça inimiga na diaginal direita
            if (CorDaPessa[DiagonalDireitaBaixoDaPessa[0]] == RivalDoPlayer)
            {
                DefineAcasaComoClicavel(DiagonalDireitaBaixoDaPessa[0]);
            }

            // aki ve se tem uma peça inimiga na diaginal esquerda
            if (CorDaPessa[DiagonalEsquerdaBaixoDaPessa[0]] == RivalDoPlayer)
            {
                DefineAcasaComoClicavel(DiagonalEsquerdaBaixoDaPessa[0]);
            }

            // aki verifica se posso pular duas casas na posição inicial do peão.

            if (Selecionado_TabuleiroID == 8
                || Selecionado_TabuleiroID == 9
                || Selecionado_TabuleiroID == 10
                || Selecionado_TabuleiroID == 11
                || Selecionado_TabuleiroID == 12
                || Selecionado_TabuleiroID == 13
                || Selecionado_TabuleiroID == 14
                || Selecionado_TabuleiroID == 15)
            {
                if (CasaEstaOcupada[ColunaAbaixoDaPessa[1]] == false
                   && CasaEstaOcupada[ColunaAbaixoDaPessa[0]] == false)
                {
                    DefineAcasaComoClicavel(ColunaAbaixoDaPessa[1]);
                }
            }



            // aki verifica se eu posso fazer um en passant

            if (Selecionado_TabuleiroID == 32
                || Selecionado_TabuleiroID == 33
                || Selecionado_TabuleiroID == 34
                || Selecionado_TabuleiroID == 35
                || Selecionado_TabuleiroID == 36
                || Selecionado_TabuleiroID == 37
                || Selecionado_TabuleiroID == 38
                || Selecionado_TabuleiroID == 39)
            {

                MovimentosPeaoEnPassant(LinhaAdireitaDaPessa[0], DiagonalDireitaBaixoDaPessa[0], true);
                MovimentosPeaoEnPassant(LinhaAesquerdaDaPessa[0], DiagonalEsquerdaBaixoDaPessa[0], false);

            }

        }

        public void MovimentoPeaoVaiPraDireita()
        {

            ParaTodasAsDirecoesDaPessa = LinhaAdireitaDaPessa;

            // aki ve se pode par um passo pra frente
            if (CasaEstaOcupada[LinhaAdireitaDaPessa[0]] == false)
            {
                DefineAcasaComoClicavel(LinhaAdireitaDaPessa[0]);
            }

            // aki ve se tem uma peça inimiga na diaginal direita baixo
            if (CorDaPessa[DiagonalDireitaBaixoDaPessa[0]] == RivalDoPlayer)
            {
                DefineAcasaComoClicavel(DiagonalDireitaBaixoDaPessa[0]);
            }

            // aki ve se tem uma peça inimiga na diaginal direita cima
            if (CorDaPessa[DiagonalDireitaCimaDaPessa[0]] == RivalDoPlayer)
            {
                DefineAcasaComoClicavel(DiagonalDireitaCimaDaPessa[0]);
            }

            // aki verifica se posso pular duas casas na posição inicial do peão.

            if (Selecionado_TabuleiroID == 1
                || Selecionado_TabuleiroID == 9
                || Selecionado_TabuleiroID == 17
                || Selecionado_TabuleiroID == 25
                || Selecionado_TabuleiroID == 33
                || Selecionado_TabuleiroID == 41
                || Selecionado_TabuleiroID == 49
                || Selecionado_TabuleiroID == 57)
            {
                if (CasaEstaOcupada[LinhaAdireitaDaPessa[1]] == false
                   && CasaEstaOcupada[LinhaAdireitaDaPessa[0]] == false)
                {
                    DefineAcasaComoClicavel(LinhaAdireitaDaPessa[1]);
                }
            }



            // aki verifica se eu posso fazer um en passant

            if (Selecionado_TabuleiroID == 4
                || Selecionado_TabuleiroID == 12
                || Selecionado_TabuleiroID == 20
                || Selecionado_TabuleiroID == 28
                || Selecionado_TabuleiroID == 36
                || Selecionado_TabuleiroID == 44
                || Selecionado_TabuleiroID == 52
                || Selecionado_TabuleiroID == 60)
            {

                MovimentosPeaoEnPassant(ColunaAbaixoDaPessa[0], DiagonalDireitaBaixoDaPessa[0], true);
                MovimentosPeaoEnPassant(ColunaAcimaDaPessa[0], DiagonalDireitaCimaDaPessa[0], false);

            }

        }

        public void MovimentoPeaoVaiPraEsquerda()
        {

            ParaTodasAsDirecoesDaPessa = LinhaAesquerdaDaPessa;

            // aki ve se pode par um passo pra frente
            if (CasaEstaOcupada[LinhaAesquerdaDaPessa[0]] == false)
            {
                DefineAcasaComoClicavel(LinhaAesquerdaDaPessa[0]);
            }

            // aki ve se tem uma peça inimiga na diaginal esquerda baixo
            if (CorDaPessa[DiagonalEsquerdaBaixoDaPessa[0]] == RivalDoPlayer)
            {
                DefineAcasaComoClicavel(DiagonalEsquerdaBaixoDaPessa[0]);
            }

            // aki ve se tem uma peça inimiga na diaginal esquerda cima
            if (CorDaPessa[DiagonalEsquerdaCimaDaPessa[0]] == RivalDoPlayer)
            {
                DefineAcasaComoClicavel(DiagonalEsquerdaCimaDaPessa[0]);
            }

            // aki verifica se posso pular duas casas na posição inicial do peão.

            if (Selecionado_TabuleiroID == 6
                || Selecionado_TabuleiroID == 14
                || Selecionado_TabuleiroID == 22
                || Selecionado_TabuleiroID == 30
                || Selecionado_TabuleiroID == 38
                || Selecionado_TabuleiroID == 46
                || Selecionado_TabuleiroID == 54
                || Selecionado_TabuleiroID == 62)
            {
                if (CasaEstaOcupada[LinhaAesquerdaDaPessa[1]] == false
                   && CasaEstaOcupada[LinhaAesquerdaDaPessa[0]] == false)
                {
                    DefineAcasaComoClicavel(LinhaAesquerdaDaPessa[1]);
                }
            }



            // aki verifica se eu posso fazer um en passant 

            if (Selecionado_TabuleiroID == 3
                || Selecionado_TabuleiroID == 11
                || Selecionado_TabuleiroID == 19
                || Selecionado_TabuleiroID == 27
                || Selecionado_TabuleiroID == 35
                || Selecionado_TabuleiroID == 43
                || Selecionado_TabuleiroID == 51
                || Selecionado_TabuleiroID == 59)
            {

                MovimentosPeaoEnPassant(ColunaAbaixoDaPessa[0], DiagonalEsquerdaBaixoDaPessa[0], true);
                MovimentosPeaoEnPassant(ColunaAcimaDaPessa[0], DiagonalEsquerdaCimaDaPessa[0], false);

            }

        }


    }
}

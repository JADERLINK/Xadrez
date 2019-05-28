using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    public partial class XadrezClass
    {

        // // modo editor usado dentro de DarClickNaCasaDoTabuleiro;
        public void ModoEditorMetodo(int ID_DA_CASA)
        {
            // função de edição

            if (ModoEditor_Selecionar == true)
            {
                // aqui é o modo q seleciona e edita

                if (ModoEditor_TemCasaSelecionada == true)
                {
                    // aki ele desseleciona a casa selecionada
                    if (Selecionado_TabuleiroID == ID_DA_CASA)
                    {
                        Selecionado_TabuleiroID = 64;
                        ModoEditor_TemCasaSelecionada = false;

                        comboBoxAPessaJaFoiMovidaEnabled = false;
                        comboBoxDirecaoDoPeaoEnabled = false;
                        comboBoxPeaoAndouDuasCasasEnabled = false;
                        comboBoxPessaEscolhidaEnabled = false;
                        numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = false;

                        //NomeDosBotoesPeloValorDaPessa();
                    }
                    else
                    {
                        // se for uma casa diferente ele vai selecionar outra casa:
                        ModoEditor_SelecionaUmaCasa(ID_DA_CASA);
                    }

                }
                else
                {
                    // vai selecionar uma casa
                    ModoEditor_SelecionaUmaCasa(ID_DA_CASA);
                }


            }


            if (ModoEditor_Subistituir == true)
            {
                // aqui ele va pegar as info e vai subistituir
                CasaEstaOcupada[ID_DA_CASA] = CasaEstaOcupadaValor;
                CorDaPessa[ID_DA_CASA] = CorDaPessaValor;
                Pessa[ID_DA_CASA] = PessaValor;
                APessaJaFoiMovida[ID_DA_CASA] = APessaJaFoiMovidaValor;
                EmqualRodadaAPessaFoiMexida[ID_DA_CASA] = EmqualRodadaAPessaFoiMexidaValor;
                PeaoAndouDuasCasas[ID_DA_CASA] = PeaoAndouDuasCasasValor;
                DirecaoDoPeao[ID_DA_CASA] = DirecaoDoPeaoValor;

                //NomeDosBotoesPeloValorDaPessa();
            }

            NomeDosBotoesPeloValorDaPessa();
        }

        // seleciona uma casa no modo editor
        public void ModoEditor_SelecionaUmaCasa(int ID_DA_CASA)
        {
            if (ID_DA_CASA != 64)
            {
                // aki ele seleciona uma casa

                Selecionado_TabuleiroID = ID_DA_CASA;
                ModoEditor_TemCasaSelecionada = true;

                Selecionado_PessaValor = Pessa[ID_DA_CASA];

                switch (Selecionado_PessaValor)
                {
                    //casa vasia
                    case 0:
                        comboBoxAPessaJaFoiMovidaEnabled = false;
                        comboBoxDirecaoDoPeaoEnabled = false;
                        comboBoxPeaoAndouDuasCasasEnabled = false;
                        comboBoxPessaEscolhidaEnabled = true;
                        numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = false;

                        comboBoxPessaEscolhidaSelectedIndex = 0;

                        break;
                    // casa com peão
                    case 16:
                    case 26:
                        comboBoxAPessaJaFoiMovidaEnabled = true;
                        comboBoxDirecaoDoPeaoEnabled = true;
                        comboBoxPeaoAndouDuasCasasEnabled = true;
                        comboBoxPessaEscolhidaEnabled = true;
                        numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;

                        if (Selecionado_PessaValor == 16)
                        {
                            comboBoxPessaEscolhidaSelectedIndex = 1;
                        }
                        if (Selecionado_PessaValor == 26)
                        {
                            comboBoxPessaEscolhidaSelectedIndex = 7;
                        }

                        if (APessaJaFoiMovida[ID_DA_CASA] == true)
                        {
                            comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }
                        if (PeaoAndouDuasCasas[ID_DA_CASA] == true)
                        {
                            comboBoxPeaoAndouDuasCasasSelectedIndex = 1;
                        }
                        else
                        {
                            comboBoxPeaoAndouDuasCasasSelectedIndex = 0;
                        }
                        if (DirecaoDoPeao[ID_DA_CASA] == 1)
                        {
                            comboBoxDirecaoDoPeaoSelectedIndex = 0;
                        }
                        else if (DirecaoDoPeao[ID_DA_CASA] == 2)
                        {
                            comboBoxDirecaoDoPeaoSelectedIndex = 1;
                        }
                        else if (DirecaoDoPeao[ID_DA_CASA] == 3)
                        {
                            comboBoxDirecaoDoPeaoSelectedIndex = 2;
                        }
                        else if (DirecaoDoPeao[ID_DA_CASA] == 4)
                        {
                            comboBoxDirecaoDoPeaoSelectedIndex = 3;
                        }
                        else
                        {
                            comboBoxDirecaoDoPeaoSelectedIndex = 0;
                        }

                        numericUpDownEmqualRodadaAPessaFoiMexidaValue = EmqualRodadaAPessaFoiMexida[ID_DA_CASA];

                        break;
                    //outras peças
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                    case 25:
                        comboBoxAPessaJaFoiMovidaEnabled = true;
                        comboBoxDirecaoDoPeaoEnabled = false;
                        comboBoxPeaoAndouDuasCasasEnabled = false;
                        comboBoxPessaEscolhidaEnabled = true;
                        numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;

                        if (Selecionado_PessaValor == 11)
                        {
                            comboBoxPessaEscolhidaSelectedIndex = 2;
                        }
                        if (Selecionado_PessaValor == 12)
                        {
                            comboBoxPessaEscolhidaSelectedIndex = 3;
                        }
                        if (Selecionado_PessaValor == 13)
                        {
                            comboBoxPessaEscolhidaSelectedIndex = 4;
                        }
                        if (Selecionado_PessaValor == 14)
                        {
                            comboBoxPessaEscolhidaSelectedIndex = 5;
                        }
                        if (Selecionado_PessaValor == 15)
                        {
                            comboBoxPessaEscolhidaSelectedIndex = 6;
                        }
                        if (Selecionado_PessaValor == 21)
                        {
                            comboBoxPessaEscolhidaSelectedIndex = 8;
                        }
                        if (Selecionado_PessaValor == 22)
                        {
                            comboBoxPessaEscolhidaSelectedIndex = 9;
                        }
                        if (Selecionado_PessaValor == 23)
                        {
                            comboBoxPessaEscolhidaSelectedIndex = 10;
                        }
                        if (Selecionado_PessaValor == 24)
                        {
                            comboBoxPessaEscolhidaSelectedIndex = 11;
                        }
                        if (Selecionado_PessaValor == 25)
                        {
                            comboBoxPessaEscolhidaSelectedIndex = 12;
                        }

                        if (APessaJaFoiMovida[ID_DA_CASA] == true)
                        {
                            comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        numericUpDownEmqualRodadaAPessaFoiMexidaValue = EmqualRodadaAPessaFoiMexida[ID_DA_CASA];
                        break;

                }

                // aki coloca o simbolo de selecionado
                //NomeDosBotoesPeloValorDaPessa();

                //NomesNosBotoesDotabuleiro[ID_DA_CASA] += NomeEmBranco + NomeSELECIONADO;
                //CORESNASCASAS[ID_DA_CASA] = CORES_SELECIONADO;
                //ImagemNasCasasL2[ID_DA_CASA] = IMAGEM_SELECIONADO;

            }
        }

    }
}

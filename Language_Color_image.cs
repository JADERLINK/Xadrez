using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Drawing;
using SimplesINIs;


namespace Xadrez
{
    public partial class Form1
    {
       
        public void CarregaLanguage()
        {
            try
            {
                string Conteudo = null;

                SimplesINI Language = new SimplesINI("Language.txt");
            
                Conteudo = Language.ReadStringInKey("001");
                if (Conteudo != null)
                {
                    menuToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("002");
                if (Conteudo != null)
                {
                    jogoOnlineToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("003");
                if (Conteudo != null)
                {
                    configToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("004");
                if (Conteudo != null)
                {
                    creditosToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("005");
                if (Conteudo != null)
                {
                    concluirJogadaToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("006");
                if (Conteudo != null)
                {
                    novaPartidaToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("007");
                if (Conteudo != null)
                {
                    salvarComoToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("008");
                if (Conteudo != null)
                {
                    carregarParaJogarToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("009");
                if (Conteudo != null)
                {
                    carregarParaEditarToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("010");
                if (Conteudo != null)
                {
                    editarNovoJogoToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("011");
                if (Conteudo != null)
                {
                    sairToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("012");
                if (Conteudo != null)
                {
                    hostearPartidaToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("013");
                if (Conteudo != null)
                {
                    conectarNaPartidaToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("014");
                if (Conteudo != null)
                {
                    desconectarToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("015");
                if (Conteudo != null)
                {
                    requisitarNovaPartidaToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("016");
                if (Conteudo != null)
                {
                    requisitarJogoCarregadoToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("017");
                if (Conteudo != null)
                {
                    requisitarDadosDoTabuleiroToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("018");
                if (Conteudo != null)
                {
                    corNosNomesToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("019");
                if (Conteudo != null)
                {
                    nomesImagensToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("020");
                if (Conteudo != null)
                {
                    autoConcluirJogadaToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("021");
                if (Conteudo != null)
                {
                    descricaoNoTabuleiroToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("022");
                if (Conteudo != null)
                {
                    infoDeDebugToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("023");
                if (Conteudo != null)
                {
                    testarTabuleiroDebugToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("024");
                if (Conteudo != null)
                {
                    buttonConcluirJogada.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("025");
                if (Conteudo != null)
                {
                    buttonHostear.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("026");
                if (Conteudo != null)
                {
                    buttonConectar.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("027");
                if (Conteudo != null)
                {
                    radioButtonHostCarregarPartida.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("028");
                if (Conteudo != null)
                {
                    radioButtonHostNovaPartida.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("029");
                if (Conteudo != null)
                {
                    radioButton_Edit_Selecionar.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("030");
                if (Conteudo != null)
                {
                    radioButton_Edit_Subistituir.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("031");
                if (Conteudo != null)
                {
                    groupBoxModoDeEdicao.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("032");
                if (Conteudo != null)
                {
                   groupBoxEditorPessa.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("033");
                if (Conteudo != null)
                {
                    groupBoxEditorGeral.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("034");
                if (Conteudo != null)
                {
                    labelTraduz001.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("035");
                if (Conteudo != null)
                {
                    labelTraduz002.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("036");
                if (Conteudo != null)
                {
                    labelTraduz004.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("037");
                if (Conteudo != null)
                {
                    labelTraduz005.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("038");
                if (Conteudo != null)
                {
                    labelTraduz006.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("039");
                if (Conteudo != null)
                {
                    labelTraduz007.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("040");
                if (Conteudo != null)
                {
                    labelTraduz008.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("041");
                if (Conteudo != null)
                {
                    labelTraduz010.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("042");
                if (Conteudo != null)
                {
                    labelTraduz011.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("043");
                if (Conteudo != null)
                {
                    labelTraduz012.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("044");
                if (Conteudo != null)
                {
                    labelTraduz013.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("045");
                if (Conteudo != null)
                {
                    labelTraduz014.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("046");
                if (Conteudo != null)
                {
                    labelTraduz015.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("047");
                if (Conteudo != null)
                {
                    labelTraduz016.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("048");
                if (Conteudo != null)
                {
                    labelTraduz017.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("049");
                if (Conteudo != null)
                {
                    labelTraduz018.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("050");
                if (Conteudo != null)
                {
                    T_Rainha = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("051");
                if (Conteudo != null)
                {
                    T_Torre = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("052");
                if (Conteudo != null)
                {
                    T_Bispo = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("053");
                if (Conteudo != null)
                {
                    T_Cavalo = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("054");
                if (Conteudo != null)
                {
                    T_Vazio = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("055");
                if (Conteudo != null)
                {
                    T_False = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("056");
                if (Conteudo != null)
                {
                    T_True = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("057");
                if (Conteudo != null)
                {
                    T_Pra_Cima = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("058");
                if (Conteudo != null)
                {
                    T_Pra_Baixo = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("059");
                if (Conteudo != null)
                {
                    T_Pra_Direita = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("060");
                if (Conteudo != null)
                {
                    T_Pra_Esquerda = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("061");
                if (Conteudo != null)
                {
                    T_Player_Azul = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("062");
                if (Conteudo != null)
                {
                    T_Player_Verde = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("063");
                if (Conteudo != null)
                {
                    T_Colocar_Texto_Preto = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("064");
                if (Conteudo != null)
                {
                    T_Colocar_Texto_Colorido = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("065");
                if (Conteudo != null)
                {
                    T_Colocar_Nomes_Nas_Casas = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("066");
                if (Conteudo != null)
                {
                    T_Colocar_Imagem_Nas_Casas = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("067");
                if (Conteudo != null)
                {
                    T_Ativar_Funcao = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("068");
                if (Conteudo != null)
                {
                    T_Desativar_Funcao = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("069");
                if (Conteudo != null)
                {
                    T_Desativar_Popup = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("070");
                if (Conteudo != null)
                {
                    T_Ativar_Popup = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("071");
                if (Conteudo != null)
                {
                    T_Ativar_Info_De_Debug = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("072");
                if (Conteudo != null)
                {
                    T_Desativar_Info_De_Debug = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("073");
                if (Conteudo != null)
                {
                    T_Ativar_Teste_Do_Tabuleiro = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("074");
                if (Conteudo != null)
                {
                    T_Desativar_Teste_Do_Tabuleiro = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("075");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomePV = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("076");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeTV = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("077");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeCV = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("078");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeBV = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("079");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeREV = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("080");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeRAV = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("081");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomePA = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("082");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeTA = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("083");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeCA = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("084");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeBA = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("085");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeREA = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("086");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeRAA = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("087");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeSELECIONADO = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("088");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeCOLOCARAQUI = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("089");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomePODECOLOCAR = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("090");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomePODEROQUE = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("091");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomePODEENPASSANT = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("092");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeAZUL = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("093");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeVERDE = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("094");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeNAOPODECOLOCAR = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("095");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeDIRECAOCAVALO = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("096");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeDIRECAOBAIXO = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("097");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeDIRECAOCIMA = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("098");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeDIRECAODIREITA = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("099");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeDIRECAOESQUERDA = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("100");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeDIRECAODIAGONALDIREITABAIXO = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("101");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeDIRECAODIAGONALDIREITACIMA = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("102");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeDIRECAODIAGONALESQUERDABAIXO = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("103");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeDIRECAODIAGONALESQUERDACIMA = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("104");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeDESCRICAO_SELECIONADO = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("105");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeDESCRICAO_COLOCARAQUI = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("106");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeDESCRICAO_PODECOLOCAR = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("107");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeDESCRICAO_PODEROQUE = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("108");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeDESCRICAO_PODEENPASSANT = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("109");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeDESCRICAO_NAOPODECOLOCAR = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("110");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.NomeDESCRICAO_CASASELECIONADA = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("111");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.T_Jogador_Azul_Esta_Em_Xeque = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("112");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.T_Jogador_Verde_Esta_Em_Xeque = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("113");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.T_O_Jogo_Empatou = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("114");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.T_Jogador_Azul_Venceu_O_Jogo = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("115");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.T_Jogador_Verde_Venceu_O_Jogo = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("116");
                if (Conteudo != null)
                {
                    T_CHAT__Conectado_Com_O_Servidor = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("117");
                if (Conteudo != null)
                {
                    T_CHAT__Desconectado_Do_Servidor = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("118");
                if (Conteudo != null)
                {
                    T_CHAT__Voce_Perdeu_A_Conexao_Com_O_Servidor = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("119");
                if (Conteudo != null)
                {
                    T_CHAT__Servidor_Iniciado = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("120");
                if (Conteudo != null)
                {
                    T_CHAT__O_Outro_Jogador_Entrou = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("121");
                if (Conteudo != null)
                {
                    T_CHAT__Um_Novo_Jogador_Entrou = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("122");
                if (Conteudo != null)
                {
                    T_CHAT__Servidor_Parado = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("123");
                if (Conteudo != null)
                {
                    T_CHAT__Perdeu_se_A_Conexão_Com_O_Outro_Jogador = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("124");
                if (Conteudo != null)
                {
                    T_CHAT__Espere_Ele_Reconectar_se_Para_Jogar = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("125");
                if (Conteudo != null)
                {
                    T_TITULO_ERRO = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("126");
                if (Conteudo != null)
                {
                    T_TITULO_Responda_a_pergunta = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("127");
                if (Conteudo != null)
                {
                    T_TITULO_Fim_De_Jogo = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("128");
                if (Conteudo != null)
                {
                    T_TITULO_CREDITOS = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("129");
                if (Conteudo != null)
                {
                    T_mBox01 = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("130");
                if (Conteudo != null)
                {
                    T_mBox02 = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("131");
                if (Conteudo != null)
                {
                    T_mBox03 = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("132");
                if (Conteudo != null)
                {
                    T_mBox04 = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("133");
                if (Conteudo != null)
                {
                    T_mBox05 = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("134");
                if (Conteudo != null)
                {
                    T_mBox06 = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("135");
                if (Conteudo != null)
                {
                    T_mBox07 = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("136");
                if (Conteudo != null)
                {
                    T_mBox08 = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("137");
                if (Conteudo != null)
                {
                    T_mBox09 = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("138");
                if (Conteudo != null)
                {
                    T_mBox10 = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("139");
                if (Conteudo != null)
                {
                    T_mBox11 = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("140");
                if (Conteudo != null)
                {
                    T_mBox12 = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("141");
                if (Conteudo != null)
                {
                    T_mBox13 = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("142");
                if (Conteudo != null)
                {
                    T_mBox14 = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("143");
                if (Conteudo != null)
                {
                    T_mBox15 = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("144");
                if (Conteudo != null)
                {
                    T_mBox16 = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("TranslatedBy");
                if (Conteudo != null)
                {
                    T_Translated_By = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("145");
                if (Conteudo != null)
                {
                    inverterTabuleiroToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("146");
                if (Conteudo != null)
                {
                    enviaEscolhaDeJogadaToolStripMenuItem.Text = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("147");
                if (Conteudo != null)
                {
                    T_Nao_Enviar_Meus_Movimentos = Conteudo;
                }
                Conteudo = Language.ReadStringInKey("148");
                if (Conteudo != null)
                {
                    T_Enviar_Meus_Movimentos = Conteudo;
                }

                Language.ConteudoDoArquivo.Clear();
                Conteudo = null;
            }
            catch (FileNotFoundException)
            {
                // iginorar

            }
            catch (Exception)
            {

            }

        }
    
        public void CarregaCores()
        {
            try
            {
                Color? Conteudo = null;

                SimplesINI Colors = new SimplesINI("Colors.txt");

                Conteudo = Colors.ReadColorInKey("CORES_AZUL");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.CORES_AZUL = (Color)Conteudo;
                   
                }
                Conteudo = Colors.ReadColorInKey("CORES_VERDE");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.CORES_VERDE = (Color)Conteudo;
                }
                Conteudo = Colors.ReadColorInKey("CORES_SELECIONADO");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.CORES_SELECIONADO = (Color)Conteudo;
                }
                Conteudo = Colors.ReadColorInKey("CORES_COLOCARAQUI");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.CORES_COLOCARAQUI = (Color)Conteudo;
                }
                Conteudo = Colors.ReadColorInKey("CORES_PODECOLOCAR");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.CORES_PODECOLOCAR = (Color)Conteudo;
                }
                Conteudo = Colors.ReadColorInKey("CORES_PODEROQUE");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.CORES_PODEROQUE = (Color)Conteudo;
                }
                Conteudo = Colors.ReadColorInKey("CORES_PODEENPASSANT");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.CORES_PODEENPASSANT = (Color)Conteudo;
                }
                Conteudo = Colors.ReadColorInKey("CORES_NAOPODECOLOCAR");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.CORES_NAOPODECOLOCAR = (Color)Conteudo;
                }
                Conteudo = Colors.ReadColorInKey("CORES_DIRECAO");
                if (Conteudo != null)
                {
                    ImportandoXadrezClass.CORES_DIRECAO = (Color)Conteudo;
                }
                Conteudo = Colors.ReadColorInKey("CORES_TABULEIRO1");
                if (Conteudo != null)
                {
                    Color T1 = (Color)Conteudo;
 
                    button1A.BackColor = T1;
                    button1A.FlatAppearance.MouseDownBackColor = T1;
                    button1A.FlatAppearance.MouseOverBackColor = T1;

                    button1C.BackColor = T1;
                    button1C.FlatAppearance.MouseDownBackColor = T1;
                    button1C.FlatAppearance.MouseOverBackColor = T1;

                    button1E.BackColor = T1;
                    button1E.FlatAppearance.MouseDownBackColor = T1;
                    button1E.FlatAppearance.MouseOverBackColor = T1;

                    button1G.BackColor = T1;
                    button1G.FlatAppearance.MouseDownBackColor = T1;
                    button1G.FlatAppearance.MouseOverBackColor = T1;

                    button2B.BackColor = T1;
                    button2B.FlatAppearance.MouseDownBackColor = T1;
                    button2B.FlatAppearance.MouseOverBackColor = T1;

                    button2D.BackColor = T1;
                    button2D.FlatAppearance.MouseDownBackColor = T1;
                    button2D.FlatAppearance.MouseOverBackColor = T1;

                    button2F.BackColor = T1;
                    button2F.FlatAppearance.MouseDownBackColor = T1;
                    button2F.FlatAppearance.MouseOverBackColor = T1;

                    button2H.BackColor = T1;
                    button2H.FlatAppearance.MouseDownBackColor = T1;
                    button2H.FlatAppearance.MouseOverBackColor = T1;

                    // ///////

                    button3A.BackColor = T1;
                    button3A.FlatAppearance.MouseDownBackColor = T1;
                    button3A.FlatAppearance.MouseOverBackColor = T1;

                    button3C.BackColor = T1;
                    button3C.FlatAppearance.MouseDownBackColor = T1;
                    button3C.FlatAppearance.MouseOverBackColor = T1;

                    button3E.BackColor = T1;
                    button3E.FlatAppearance.MouseDownBackColor = T1;
                    button3E.FlatAppearance.MouseOverBackColor = T1;

                    button3G.BackColor = T1;
                    button3G.FlatAppearance.MouseDownBackColor = T1;
                    button3G.FlatAppearance.MouseOverBackColor = T1;

                    button4B.BackColor = T1;
                    button4B.FlatAppearance.MouseDownBackColor = T1;
                    button4B.FlatAppearance.MouseOverBackColor = T1;

                    button4D.BackColor = T1;
                    button4D.FlatAppearance.MouseDownBackColor = T1;
                    button4D.FlatAppearance.MouseOverBackColor = T1;

                    button4F.BackColor = T1;
                    button4F.FlatAppearance.MouseDownBackColor = T1;
                    button4F.FlatAppearance.MouseOverBackColor = T1;

                    button4H.BackColor = T1;
                    button4H.FlatAppearance.MouseDownBackColor = T1;
                    button4H.FlatAppearance.MouseOverBackColor = T1;

                    // ////////

                    button5A.BackColor = T1;
                    button5A.FlatAppearance.MouseDownBackColor = T1;
                    button5A.FlatAppearance.MouseOverBackColor = T1;

                    button5C.BackColor = T1;
                    button5C.FlatAppearance.MouseDownBackColor = T1;
                    button5C.FlatAppearance.MouseOverBackColor = T1;

                    button5E.BackColor = T1;
                    button5E.FlatAppearance.MouseDownBackColor = T1;
                    button5E.FlatAppearance.MouseOverBackColor = T1;

                    button5G.BackColor = T1;
                    button5G.FlatAppearance.MouseDownBackColor = T1;
                    button5G.FlatAppearance.MouseOverBackColor = T1;

                    button6B.BackColor = T1;
                    button6B.FlatAppearance.MouseDownBackColor = T1;
                    button6B.FlatAppearance.MouseOverBackColor = T1;

                    button6D.BackColor = T1;
                    button6D.FlatAppearance.MouseDownBackColor = T1;
                    button6D.FlatAppearance.MouseOverBackColor = T1;

                    button6F.BackColor = T1;
                    button6F.FlatAppearance.MouseDownBackColor = T1;
                    button6F.FlatAppearance.MouseOverBackColor = T1;

                    button6H.BackColor = T1;
                    button6H.FlatAppearance.MouseDownBackColor = T1;
                    button6H.FlatAppearance.MouseOverBackColor = T1;

                    // /////////

                    button7A.BackColor = T1;
                    button7A.FlatAppearance.MouseDownBackColor = T1;
                    button7A.FlatAppearance.MouseOverBackColor = T1;

                    button7C.BackColor = T1;
                    button7C.FlatAppearance.MouseDownBackColor = T1;
                    button7C.FlatAppearance.MouseOverBackColor = T1;

                    button7E.BackColor = T1;
                    button7E.FlatAppearance.MouseDownBackColor = T1;
                    button7E.FlatAppearance.MouseOverBackColor = T1;

                    button7G.BackColor = T1;
                    button7G.FlatAppearance.MouseDownBackColor = T1;
                    button7G.FlatAppearance.MouseOverBackColor = T1;

                    button8B.BackColor = T1;
                    button8B.FlatAppearance.MouseDownBackColor = T1;
                    button8B.FlatAppearance.MouseOverBackColor = T1;

                    button8D.BackColor = T1;
                    button8D.FlatAppearance.MouseDownBackColor = T1;
                    button8D.FlatAppearance.MouseOverBackColor = T1;

                    button8F.BackColor = T1;
                    button8F.FlatAppearance.MouseDownBackColor = T1;
                    button8F.FlatAppearance.MouseOverBackColor = T1;

                    button8H.BackColor = T1;
                    button8H.FlatAppearance.MouseDownBackColor = T1;
                    button8H.FlatAppearance.MouseOverBackColor = T1;

                }
                Conteudo = Colors.ReadColorInKey("CORES_TABULEIRO2");
                if (Conteudo != null)
                {
                    Color T2 = (Color)Conteudo;

                    button1B.BackColor = T2;
                    button1B.FlatAppearance.MouseDownBackColor = T2;
                    button1B.FlatAppearance.MouseOverBackColor = T2;

                    button1D.BackColor = T2;
                    button1D.FlatAppearance.MouseDownBackColor = T2;
                    button1D.FlatAppearance.MouseOverBackColor = T2;

                    button1F.BackColor = T2;
                    button1F.FlatAppearance.MouseDownBackColor = T2;
                    button1F.FlatAppearance.MouseOverBackColor = T2;

                    button1H.BackColor = T2;
                    button1H.FlatAppearance.MouseDownBackColor = T2;
                    button1H.FlatAppearance.MouseOverBackColor = T2;

                    button2A.BackColor = T2;
                    button2A.FlatAppearance.MouseDownBackColor = T2;
                    button2A.FlatAppearance.MouseOverBackColor = T2;

                    button2C.BackColor = T2;
                    button2C.FlatAppearance.MouseDownBackColor = T2;
                    button2C.FlatAppearance.MouseOverBackColor = T2;

                    button2E.BackColor = T2;
                    button2E.FlatAppearance.MouseDownBackColor = T2;
                    button2E.FlatAppearance.MouseOverBackColor = T2;

                    button2G.BackColor = T2;
                    button2G.FlatAppearance.MouseDownBackColor = T2;
                    button2G.FlatAppearance.MouseOverBackColor = T2;

                    // /////

                    button3B.BackColor = T2;
                    button3B.FlatAppearance.MouseDownBackColor = T2;
                    button3B.FlatAppearance.MouseOverBackColor = T2;

                    button3D.BackColor = T2;
                    button3D.FlatAppearance.MouseDownBackColor = T2;
                    button3D.FlatAppearance.MouseOverBackColor = T2;

                    button3F.BackColor = T2;
                    button3F.FlatAppearance.MouseDownBackColor = T2;
                    button3F.FlatAppearance.MouseOverBackColor = T2;

                    button3H.BackColor = T2;
                    button3H.FlatAppearance.MouseDownBackColor = T2;
                    button3H.FlatAppearance.MouseOverBackColor = T2;

                    button4A.BackColor = T2;
                    button4A.FlatAppearance.MouseDownBackColor = T2;
                    button4A.FlatAppearance.MouseOverBackColor = T2;

                    button4C.BackColor = T2;
                    button4C.FlatAppearance.MouseDownBackColor = T2;
                    button4C.FlatAppearance.MouseOverBackColor = T2;

                    button4E.BackColor = T2;
                    button4E.FlatAppearance.MouseDownBackColor = T2;
                    button4E.FlatAppearance.MouseOverBackColor = T2;

                    button4G.BackColor = T2;
                    button4G.FlatAppearance.MouseDownBackColor = T2;
                    button4G.FlatAppearance.MouseOverBackColor = T2;

                    // ////

                    button5B.BackColor = T2;
                    button5B.FlatAppearance.MouseDownBackColor = T2;
                    button5B.FlatAppearance.MouseOverBackColor = T2;

                    button5D.BackColor = T2;
                    button5D.FlatAppearance.MouseDownBackColor = T2;
                    button5D.FlatAppearance.MouseOverBackColor = T2;

                    button5F.BackColor = T2;
                    button5F.FlatAppearance.MouseDownBackColor = T2;
                    button5F.FlatAppearance.MouseOverBackColor = T2;

                    button5H.BackColor = T2;
                    button5H.FlatAppearance.MouseDownBackColor = T2;
                    button5H.FlatAppearance.MouseOverBackColor = T2;

                    button6A.BackColor = T2;
                    button6A.FlatAppearance.MouseDownBackColor = T2;
                    button6A.FlatAppearance.MouseOverBackColor = T2;

                    button6C.BackColor = T2;
                    button6C.FlatAppearance.MouseDownBackColor = T2;
                    button6C.FlatAppearance.MouseOverBackColor = T2;
                    
                    button6E.BackColor = T2;
                    button6E.FlatAppearance.MouseDownBackColor = T2;
                    button6E.FlatAppearance.MouseOverBackColor = T2;

                    button6G.BackColor = T2;
                    button6G.FlatAppearance.MouseDownBackColor = T2;
                    button6G.FlatAppearance.MouseOverBackColor = T2;

                    // ////

                    button7B.BackColor = T2;
                    button7B.FlatAppearance.MouseDownBackColor = T2;
                    button7B.FlatAppearance.MouseOverBackColor = T2;

                    button7D.BackColor = T2;
                    button7D.FlatAppearance.MouseDownBackColor = T2;
                    button7D.FlatAppearance.MouseOverBackColor = T2;

                    button7F.BackColor = T2;
                    button7F.FlatAppearance.MouseDownBackColor = T2;
                    button7F.FlatAppearance.MouseOverBackColor = T2;

                    button7H.BackColor = T2;
                    button7H.FlatAppearance.MouseDownBackColor = T2;
                    button7H.FlatAppearance.MouseOverBackColor = T2;

                    button8A.BackColor = T2;
                    button8A.FlatAppearance.MouseDownBackColor = T2;
                    button8A.FlatAppearance.MouseOverBackColor = T2;

                    button8C.BackColor = T2;
                    button8C.FlatAppearance.MouseDownBackColor = T2;
                    button8C.FlatAppearance.MouseOverBackColor = T2;

                    button8E.BackColor = T2;
                    button8E.FlatAppearance.MouseDownBackColor = T2;
                    button8E.FlatAppearance.MouseOverBackColor = T2;

                    button8G.BackColor = T2;
                    button8G.FlatAppearance.MouseDownBackColor = T2;
                    button8G.FlatAppearance.MouseOverBackColor = T2;

                }

                Colors.ConteudoDoArquivo.Clear();
                Conteudo = null;

            }
            catch (FileNotFoundException)
            {
                // iginorar

            }
            catch (Exception)
            {

            }

        }

        public void CarregaImagens()
        {
            try
            {
                ImportandoXadrezClass.IMAGEM_CA = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_CA.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_BA = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_BA.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_BV = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_BV.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_COLOCARAQUI = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_COLOCARAQUI.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_CV = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_CV.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_DIRECAOBAIXO = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_DIRECAOBAIXO.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_DIRECAOCAVALO = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_DIRECAOCAVALO.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_DIRECAOCIMA = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_DIRECAOCIMA.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_DIRECAODIAGONALDIREITABAIXO = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_DIRECAODIAGONALDIREITABAIXO.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_DIRECAODIAGONALDIREITACIMA = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_DIRECAODIAGONALDIREITACIMA.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_DIRECAODIAGONALESQUERDABAIXO = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_DIRECAODIAGONALESQUERDABAIXO.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_DIRECAODIAGONALESQUERDACIMA = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_DIRECAODIAGONALESQUERDACIMA.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_DIRECAODIREITA = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_DIRECAODIREITA.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_DIRECAOESQUERDA = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_DIRECAOESQUERDA.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_DIRECAOSELECIONADO = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_DIRECAOSELECIONADO.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_NAOPODECOLOCAR = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_NAOPODECOLOCAR.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_NAOPODERENPASSANT = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_NAOPODERENPASSANT.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_NAOPODEROQUE = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_NAOPODEROQUE.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_PA = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_PA.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_PODECOLOCAR = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_PODECOLOCAR.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_PODEENPASSANTAKI = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_PODEENPASSANTAKI.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_PODERENPASSANT = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_PODERENPASSANT.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_PODEROQUE = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_PODEROQUE.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_PODEROQUEAKI = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_PODEROQUEAKI.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_PV = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_PV.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_RAA = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_RAA.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_RAV = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_RAV.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_REA = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_REA.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_REV = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_REV.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_SELECIONADO = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_SELECIONADO.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_TA = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_TA.png");
            }
            catch (Exception)
            {
            }
            try
            {
                ImportandoXadrezClass.IMAGEM_TV = (Bitmap)Bitmap.FromFile("Texturas/IMAGEM_TV.png");
            }
            catch (Exception)
            {
            }




        }

    }
}

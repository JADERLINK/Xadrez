using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Xadrez
{
    public partial class XadrezClass
    {
        #region Todas as variaveis

        //martriz cada numero de matriz representa uma casa do tabuleiro
        // mudei de 64 para 65, pois o ultimo valor usarei como casa n existente
        // n pode em hipótese alguma clicar na casa de id 64 q fica fora do tabuleiro

        // para saber qual esta jogando, player: 1=Azul, 2=Verde, 0=nenhum player
        public byte Player;
        // rival do player, se player1 = 2, e se player2 = 1.
        public byte RivalDoPlayer;
        //cada posição da matriz é uma casa do tabuleiro
        // se a casa for ocupada por uma peça é true, se n é false.
        public bool[] CasaEstaOcupada = new bool[65];
        // é o mesmo q player porem define de qual cor é a peça, 1= Azul, 2= Verde, 0= nenhuma cor
        public byte[] CorDaPessa = new byte[65];
        // indica qual peça esta naquela casa.
        //cada peça é representada por um id numerico.
        public byte[] Pessa = new byte[65];
        //aki representa em qual direção o peão deve segir em frente.
        // 0=nenhuma direção (usado pras outras peças), 1 = Pracima, 2 = Prabaixo, 3=pradireira, 4=praesquerda
        public byte[] DirecaoDoPeao = new byte[65];
        // aki reprensenta se a pessa ja foi movida alguma vez.
        // se true essa pessa ja foi movida uma vez.
        public bool[] APessaJaFoiMovida = new bool[65];
        // informa em qual rodada a pessa foi mexida
        public uint[] EmqualRodadaAPessaFoiMexida = new uint[65];
        // checa se o peão andou 2 casa
        public bool[] PeaoAndouDuasCasas = new bool[65];
        // id da casa do tabuleiro.
        public int tabuleiroID;
        // valor a ser atribuido aka CorDaPessa
        public byte CorDaPessaValor;
        // valor a ser atribuido aka Pessa
        public byte PessaValor;
        // valor a ser atribuido aka CasaOcupada
        public bool CasaEstaOcupadaValor;
        // valor a ser atribuido aka DirecaoDoPeao
        public byte DirecaoDoPeaoValor;
        // valor a ser atribuido aka APessaJaFoiMovida
        public bool APessaJaFoiMovidaValor;
        // valor a ser atribuido aka EmqualRodadaAPessaFoiMexida
        public uint EmqualRodadaAPessaFoiMexidaValor;
        // valor a ser atribuido aka PeaoAndouDuasCasas
        public bool PeaoAndouDuasCasasValor;


        // backup dos stats das casas/peças:
        public bool[] Backup_CasaEstaOcupada = new bool[65];
        public byte[] Backup_CorDaPessa = new byte[65];
        public byte[] Backup_Pessa = new byte[65];
        public byte[] Backup_DirecaoDoPeao = new byte[65];
        public bool[] Backup_APessaJaFoiMovida = new bool[65];
        public uint[] Backup_EmqualRodadaAPessaFoiMexida = new uint[65];
        public bool[] Backup_PeaoAndouDuasCasas = new bool[65];


        // informa em qual roda o jogador esta jogando
        public uint EmqualRodadaOplayerEstaJogando;


        // verifica se o rei esta em Xeque , se true ele esta
        //public bool ReiEmXeque;
        public bool ReiFoiColocadoEmXeque;
        // verifica se aconteceu Xeque mate, se true aconteceu
        public bool XequeMate;
        public bool ReiRivalFoiColocadoEmXequeMate;
        // ??? checando as coisas.
        public bool ChecandoSeOReiEstaEmXeque;
        public bool ChecandoSeOReiEstaEmXequeMate;
        //public bool ChecandoSeOReiEstaEmXequeMateChecandoRivalSemRei;
        public bool ChecandoSeOReiEstaEmXequeMateChecandoPlayer;
        //public bool ChecandoSeOReiEstaEmXequeMateChecandoReiRival;
        //public bool ReiRivalFoiColocadoEmXeque;


        // informa q ouve empate
        public bool HouveEmpate;

        public bool DefineAcasaComoClicavelBool;

        // informa se ja a uma casa selecionada, se true então tem uma casa selecionada
        public bool TemCasaSelecionada;
        // id da casa selecionada
        public int Selecionado_TabuleiroID;
        // valor/id da peça selecionada
        public byte Selecionado_PessaValor;
        // cor da pessa selecionada
        public byte Selecionado_CorDaPessaValor;
        // valor de DireçãoDoPeao
        public byte Selecionado_DirecaoDoPeaoValor;


        // backup de Selecionado
        public int Backup_Selecionado_TabuleiroID;
        public byte Backup_Selecionado_PessaValor;
        public byte Backup_Selecionado_CorDaPessaValor;
        public byte Backup_Selecionado_DirecaoDoPeaoValor;




        // id da casa q vai ser relizado o roque.
        //public byte CasaDoRoque;
        public byte[] CasaDoRoque = new byte[4];
        // id da casa na qual o torre sera colocada no roque
        //public byte CasaDoRoqueOndeATorreVai;
        public byte[] CasaDoRoqueOndeATorreVai = new byte[4];
        // id da casa de onde a torre tava
        //public byte CasaDoRoqueOndeATorreTava;
        public byte[] CasaDoRoqueOndeATorreTava = new byte[4];
        // informa q estou fazendo um roque
        public bool EstouFazendoUmRoque;
        // 0= cima 1 = baixo 2= direira 3 esquerda
        public bool[] RoqueDirecao = new bool[4]; 


        // informa se ja escolhi uma casa para colocar uma peça ja selecionada com precedência
        public bool ColoqueiAPessaEmUmaCasa;
        // id da casa onde eu colocarei a peça
        public int ColoqueiAPessaEmUmaCasa_TabuleiroID;


        // string para enviar informações para o log 
        public string Log;

        // ativa mensagembox de Xequemate.
        public bool mesagemBoxXequeMate;
        // ativa mesagem box do empate
        public bool mesagemBoxEmpate;


        // conclui jogada ao selecionar uma lugar pra colocar a peça ja escolhida
        public bool AutoConcluirJogada;

        // colocar os nomes dos botões do tabuleiro
        public string[] NomesNosBotoesDotabuleiro = new string[65];
        //public string NomesNosBotoesDotabuleiroValor;


        // string reservada para quardar o nome das peças, sem as palavras celec,pode,aki
        //public string[] NomesNosBotoesDotabuleiroSemCelecPodeAki = new string[65];

        // string reservada para quardar o nome das peças com celec e pode.
        public string[] NomesNosBotoesDotabuleiroComCelecPode = new string[65];

        // STRING RESERVADA PARA REMOVER A PALAVRA SELECIONADO
        //public string NomeREMOVERESELECIONADO;
        //string reservada para remver a palavra colocaraqui
        // public string NomeREMOVERCOLOCARAQUI;

        // usado para desabilitar a função de clicar nesse botão:
        // se falso pode clicar no botao, se true n pode clicar no botao
        public bool[] NaoPodeClicarNesseBotao = new bool[65];


        // aki quarda qual botoes eu posso clicar para minha peça selecionada
        public bool[] NaoPodeClicarNesseBotaoComInfoDaPessaSelecionada = new bool[65];

        // aki desativa a função do botão q te q todo o codigo seja realisado
        // se true n da pra usar o botão.
        public bool BotaoBloqueado;


        // NomeParaAsPeças
        public string NomeEmBranco = " ";
        public string NomePV = "Peão Verde";
        public string NomeTV = "Torre Verde";
        public string NomeCV = "Cavalo Verde";
        public string NomeBV = "Bispo Verde";
        public string NomeREV = "Rei Verde";
        public string NomeRAV = "Rainha Verde";
        public string NomePA = "Peão Azul";
        public string NomeTA = "Torre Azul";
        public string NomeCA = "Cavalo Azul";
        public string NomeBA = "Bispo Azul";
        public string NomeREA = "Rei Azul";
        public string NomeRAA = "Rainha Azul";
        // nome dos status
        public string NomeSELECIONADO = "[Selec]";
        public string NomeCOLOCARAQUI = "[Aqui]";
        public string NomePODECOLOCAR = "[Pode]";
        public string NomePODEROQUE = "[Roque]";
        public string NomePODEENPASSANT = "[En Pasant]";
        public string NomeAZUL = "Azul";
        public string NomeVERDE = "Verde";
        public string NomeNAOPODECOLOCAR = "[Xeque]";
        // direções
        public string NomeDIRECAOCAVALO = "[CAVALO]";
        public string NomeDIRECAOBAIXO = "[BAIXO]";
        public string NomeDIRECAOCIMA = "[CIMA]";
        public string NomeDIRECAODIREITA = "[DIREITA]";
        public string NomeDIRECAOESQUERDA = "[ESQUERDA]";
        public string NomeDIRECAODIAGONALDIREITABAIXO = "[DIREITA BAIXO]";
        public string NomeDIRECAODIAGONALDIREITACIMA = "[DIREITA CIMA]";
        public string NomeDIRECAODIAGONALESQUERDABAIXO = "[ESQUERDA BAIXO]";
        public string NomeDIRECAODIAGONALESQUERDACIMA = "[ESQUERDA CIMA]";
        // descrição
        public string NomeDESCRICAO_SELECIONADO = "Peça Selecionada";
        public string NomeDESCRICAO_COLOCARAQUI = "Colocar Peça Aqui";
        public string NomeDESCRICAO_PODECOLOCAR = "Pode Ser Colocado Aqui";
        public string NomeDESCRICAO_PODEROQUE = "Pode Fazer Roque";
        public string NomeDESCRICAO_PODEENPASSANT = "Pode Fazer En Pasant";
        public string NomeDESCRICAO_NAOPODECOLOCAR = "Você Fica Em Xeque, Não";
        public string NomeDESCRICAO_CASASELECIONADA = "Casa Selecionada";

        //Xeque
        // cores para as casas dos botoes. 
        // Cor Preta
        public Color CORES_PRETO = Color.FromArgb(0, 0, 0);
        // peças azuis
        public Color CORES_AZUL = Color.FromArgb(53, 83, 255);
        // peças verdes
        public Color CORES_VERDE = Color.FromArgb(38, 167, 0);
        // SELECIONADO cor
        public Color CORES_SELECIONADO = Color.FromArgb(165, 95, 19);
        // COLOCARAQUI cor
        public Color CORES_COLOCARAQUI = Color.FromArgb(165, 95, 0);
        // PODECOLOCAR cor
        public Color CORES_PODECOLOCAR = Color.FromArgb(165, 0, 11);
        // PODEROQUE cor
        public Color CORES_PODEROQUE = Color.FromArgb(204, 149, 0);
        // PODEENPASSANT cor
        public Color CORES_PODEENPASSANT = Color.FromArgb(204, 149, 0);
        // NAOPODECOLOCAR cor
        public Color CORES_NAOPODECOLOCAR = Color.FromArgb(229, 43, 45);
        // DIRECAO cor
        public Color CORES_DIRECAO = Color.FromArgb(100, 4, 145);

        // cores nos botoes
        public Color[] CORESNASCASAS = new Color[65];

        // Color reservada para quardar a cor das peças, sem as palavras celec,pode,aki
        //public Color[] CORESNASCASAS_SemCelecPodeAki = new Color[65];

        // Color reservada para quardar a cor das peças com celec e pode.
        public Color[] CORESNASCASAS_ComCelecPode = new Color[65];


        //define as imagem
        // imagem transparente
        public Bitmap IMAGEM_TRASPARENTE = Properties.Resources.Transparente;
        // peças
        public Bitmap IMAGEM_TA = Properties.Resources.IMAGEM_TA;
        public Bitmap IMAGEM_TV = Properties.Resources.IMAGEM_TV;
        public Bitmap IMAGEM_CA = Properties.Resources.IMAGEM_CA;
        public Bitmap IMAGEM_CV = Properties.Resources.IMAGEM_CV;
        public Bitmap IMAGEM_BA = Properties.Resources.IMAGEM_BA;
        public Bitmap IMAGEM_BV = Properties.Resources.IMAGEM_BV;
        public Bitmap IMAGEM_REA = Properties.Resources.IMAGEM_REA;
        public Bitmap IMAGEM_REV = Properties.Resources.IMAGEM_REV;
        public Bitmap IMAGEM_RAA = Properties.Resources.IMAGEM_RAA;
        public Bitmap IMAGEM_RAV = Properties.Resources.IMAGEM_RAV;
        public Bitmap IMAGEM_PA = Properties.Resources.IMAGEM_PA;
        public Bitmap IMAGEM_PV = Properties.Resources.IMAGEM_PV;
        // status
        public Bitmap IMAGEM_SELECIONADO = Properties.Resources.IMAGEM_SELECIONADO;
        public Bitmap IMAGEM_PODECOLOCAR = Properties.Resources.IMAGEM_PODECOLOCAR;
        public Bitmap IMAGEM_COLOCARAQUI = Properties.Resources.IMAGEM_COLOCARAQUI;
        public Bitmap IMAGEM_PODEROQUE = Properties.Resources.IMAGEM_PODEROQUE;
        public Bitmap IMAGEM_PODEROQUEAKI = Properties.Resources.IMAGEM_PODEROQUEAKI;
        public Bitmap IMAGEM_PODERENPASSANT = Properties.Resources.IMAGEM_PODERENPASSANT;
        public Bitmap IMAGEM_PODEENPASSANTAKI = Properties.Resources.IMAGEM_PODEENPASSANTAKI;
        public Bitmap IMAGEM_NAOPODECOLOCAR = Properties.Resources.IMAGEM_NAOPODECOLOCAR;
        public Bitmap IMAGEM_NAOPODEROQUE = Properties.Resources.IMAGEM_NAOPODEROQUE;
        public Bitmap IMAGEM_NAOPODERENPASSANT = Properties.Resources.IMAGEM_NAOPODERENPASSANT;

        // direções

        public Bitmap IMAGEM_DIRECAOBAIXO = Properties.Resources.IMAGEM_DIRECAOBAIXO;
        public Bitmap IMAGEM_DIRECAOCAVALO = Properties.Resources.IMAGEM_DIRECAOCAVALO;
        public Bitmap IMAGEM_DIRECAOCIMA = Properties.Resources.IMAGEM_DIRECAOCIMA;
        public Bitmap IMAGEM_DIRECAODIAGONALDIREITABAIXO = Properties.Resources.IMAGEM_DIRECAODIAGONALDIREITABAIXO;
        public Bitmap IMAGEM_DIRECAODIAGONALDIREITACIMA = Properties.Resources.IMAGEM_DIRECAODIAGONALDIREITACIMA;
        public Bitmap IMAGEM_DIRECAODIAGONALESQUERDABAIXO = Properties.Resources.IMAGEM_DIRECAODIAGONALESQUERDABAIXO;
        public Bitmap IMAGEM_DIRECAODIAGONALESQUERDACIMA = Properties.Resources.IMAGEM_DIRECAODIAGONALESQUERDACIMA;
        public Bitmap IMAGEM_DIRECAODIREITA = Properties.Resources.IMAGEM_DIRECAODIREITA;
        public Bitmap IMAGEM_DIRECAOESQUERDA = Properties.Resources.IMAGEM_DIRECAOESQUERDA;
        public Bitmap IMAGEM_DIRECAOSELECIONADO = Properties.Resources.IMAGEM_DIRECAOSELECIONADO;

        // imagem nos botoes layer1
        public Bitmap[] ImagemNasCasasL1 = new Bitmap[65];
        // imagem nos botoes layer2
        public Bitmap[] ImagemNasCasasL2 = new Bitmap[65];

        //Bitmap reservado para quardar a imagens das peças, sem as palavras celec,pode,aki
        //public Bitmap[] ImagemNasCasasL1_SemCelecPodeAki = new Bitmap[65];
        //public Bitmap[] ImagemNasCasasL2_SemCelecPodeAki = new Bitmap[65];

        // Bitmap reservada para quardar a imagem das peças com celec e pode.
        //public Bitmap[] ImagemNasCasasL1_ComCelecPode = new Bitmap[65];
        public Bitmap[] ImagemNasCasasL2_ComCelecPode = new Bitmap[65];


        //define os IDs das casas relativo a onde ta a peça.
        public int[] ColunaAcimaDaPessa = new int[7];
        public int[] ColunaAbaixoDaPessa = new int[7];
        public int[] LinhaAdireitaDaPessa = new int[7];
        public int[] LinhaAesquerdaDaPessa = new int[7];
        public int[] DiagonalDireitaCimaDaPessa = new int[7];
        public int[] DiagonalEsquerdaCimaDaPessa = new int[7];
        public int[] DiagonalDireitaBaixoDaPessa = new int[7];
        public int[] DiagonalEsquerdaBaixoDaPessa = new int[7];
        public int[] CavaloJogadas = new int[8];

        //usado para facilitar codigo
        public int[] ParaTodasAsDirecoesDaPessa = new int[7];


        // adiciona descrição aos botoes do tabuleiro
        public string[] DescricaoDosBotoes = new string[65];

        // em descrição, informa o nome da pesça
        public string[] DescricaoDosBotoesNomeDasPessas = new string[65];

        // em descrição, informa o movimento que esta sendo feito
        public string[] DescricaoDosBotoesInfoMov = new string[65];

        // oq o nome sugere
        public string[] DescricaoDosBotoesInfoMov_ComCelecPode = new string[65];

        //IdNunericoParaNome
        public string[] IdNunericoParaNome = new string[65];

        //DescricaoDosBotoesDebug
        public string[] DescricaoDosBotoesDebug = new string[65];


        //valor da peça que eu escolhi pra subistituir o peão
        public byte IdDaPessaQueOPeaoVaiVirar;


        // usado para verificar se o peão andou duas casas
        public bool OPeaoAndouDuasCasas;


        //en passant, variaveis nessarias
        //public bool EstoufazendoUmEnPassant; //                 REMOVER DEPOIS
        public bool EstoufazendoUmEnPassantADireitaOuACima;
        public bool EstoufazendoUmEnPassantAEsquerdaOuABaixo;
        //casa do peao a ser removido no enpassant
        //public int CasaDoPeaoAserRemovidoNoEnPassant; //        REMOVER DEPOIS    
        public int CasaDoPeaoAserRemovidoNoEnPassantADireitaOuACima;
        public int CasaDoPeaoAserRemovidoNoEnPassantAEsquerdaOuABaixo;
        // informa qual casa devo clicar pra fazer o en Passant
        //public int CasaQueClicareiParaEnPassant; //             REMOVER DEPOIS  
        public int CasaQueClicareiParaEnPassantADireitaOuACima;
        public int CasaQueClicareiParaEnPassantAEsquerdaOuABaixo;


        //lista para checagem de peças atacando o rei
        //List<int> IdDasCasasDosmovimentosQueAsPessasPodemFazer = new List<int>();

        //IdDasCasasDosMovimentosQueAsPessasDoRivalPodemFazer
        Dictionary<String, int> IDCDMQAPDRPF_Rival = new Dictionary<String, int>();

        //IdDasCasasDosMovimentosQueOReiDoRivalPodeFazer
        Dictionary<String, int> IDCDMQORDRPF_ReiRival = new Dictionary<String, int>();

        //IdDasCasasDosMovimentosQueAsPessasDoPlayerPodeFazer
        Dictionary<String, int> IDCDMQDPPF_Player = new Dictionary<String, int>();

        public int CasaOndeEstaOReiDoPlayer;
        public int CasaOndeEstaOReiDoRival;
        public int CasaOndeEstaOReiDoRival2;

        //usado para salvar o jogo
        public List<string> Salvar = new List<string>();

        // ativa a testagem do tabuleiro
        public bool TestarTabuleiroDebug;

        // ativa modo editor
        public bool ModoEditor;

        // variaves do modo editor
        public bool ModoEditor_Selecionar;
        public bool ModoEditor_Subistituir;

        public bool ModoEditor_TemCasaSelecionada;


        // prenche: Pessa, CorDaPessa, CasaEstaOcupada
        //public int ModoEditor_PessaASerColocada;
        // outros status da peça
        //public int ModoEditor_APessaJaFoiMovida;
        //public int ModoEditor_EmqualRodadaAPessaFoiMexida;

        // somente para peao
        //public int ModoEditor_PeaoAndouDuasCasas;
        //public int ModoEditor_DirecaoDoPeao;

        // geral
        //public int ModoEditor_Player;
        //public int ModoEditor_EmqualRodadaOplayerEstaJogando;


        // controle das caixas:
        public bool comboBoxAPessaJaFoiMovidaEnabled;
        public bool comboBoxDirecaoDoPeaoEnabled;
        public bool comboBoxPeaoAndouDuasCasasEnabled;
        public bool comboBoxPessaEscolhidaEnabled;
        public bool numericUpDownEmqualRodadaAPessaFoiMexidaEnabled;
        // item selecionado;  SelectedIndex    
        public int comboBoxAPessaJaFoiMovidaSelectedIndex;
        public int comboBoxDirecaoDoPeaoSelectedIndex;
        public int comboBoxPeaoAndouDuasCasasSelectedIndex;
        public int comboBoxPessaEscolhidaSelectedIndex;
        public uint numericUpDownEmqualRodadaAPessaFoiMexidaValue;
        // valor de player e em EmqualRodadaOplayerEstaJogando
        public int comboBoxPlayerAtualSelectedIndex;
        public uint numericUpDownEmqualRodadaOplayerEstaJogandoValue;



        // //////////////////////
        // varivais usado no metodo de checar Xeque mate

        public bool ReiRivalNaoPodeSerSalvo;
 
        // id da casa da peça q ataca o rei
        public int IdDaCasaDaPessaQueAtacaOReiRival;

        public int IdDaCasaDoDefensor;
        public int IdDaPessaDoAtacante;

        public int CasasEntreOAtacanteEORei;


        public int[] ReiRivalLinhaEsquerda = new int[7];
        public int[] ReiRivalLinhaDireita = new int[7];
        public int[] ReiRivalColunaCima = new int[7];
        public int[] ReiRivalColunaBaixo = new int[7];
        public int[] ReiRivalDiagonalDireitaCima = new int[7];
        public int[] ReiRivalDiagonalEsquerdaCima = new int[7];
        public int[] ReiRivalDiagonalDireitaBaixo = new int[7];
        public int[] ReiRivalDiagonalEsquerdaBaixo = new int[7];
        public int[] ReiRivalCavaloJogadas = new int[8];


        public int[] AtacanteEmDirecaoDoRei = new int[7];


        // direção do ataque
        // 0=none 1=cima 2=baixo 3=direita 4=esquerda 5=diagonaldireitacima 6=diagonaldireitabaixo 7=diagonalesquerdacima 8=diagonalesquerdabaixa
        // 9=cavalo
        public int AtacanteEmDirecaoDoReiRival;


        // ///////
        // variavis pra n colocar o rei em Xeque
        public bool EhUmRei;
        //public bool EhUmIdDaJogadaDoRei;

        //IdDasCasasDosLugaresOndeOReiNaoPodeSerColocado
        Dictionary<String, int> IDCDLOORNPSC_ReiNaoPode = new Dictionary<String, int>();
        //IdDasCasasDosLugaresOndeAsPessasDefedemORei
        // usando dentro de ReiEmXeque
        //Dictionary<String, int> IDCDLOAPDOR_PodeDefender = new Dictionary<String, int>();  // remover n é mais util


        // rei do player
        public int[] ReiPlayerLinhaEsquerda = new int[7];
        public int[] ReiPlayerLinhaDireita = new int[7];
        public int[] ReiPlayerColunaCima = new int[7];
        public int[] ReiPlayerColunaBaixo = new int[7];
        public int[] ReiPlayerDiagonalDireitaCima = new int[7];
        public int[] ReiPlayerDiagonalEsquerdaCima = new int[7];
        public int[] ReiPlayerDiagonalDireitaBaixo = new int[7];
        public int[] ReiPlayerDiagonalEsquerdaBaixo = new int[7];

        // direções referentes da uma possovel casa onde posso colocar o rei
        //CasaPossivelOndePossoColocarORei
        public int[] CPOPCOR_LinhaEsquerda = new int[7];
        public int[] CPOPCOR_LinhaDireita = new int[7];
        public int[] CPOPCOR_ColunaCima = new int[7];
        public int[] CPOPCOR_ColunaBaixo = new int[7];
        public int[] CPOPCOR_DiagonalDireitaCima = new int[7];
        public int[] CPOPCOR_DiagonalEsquerdaCima = new int[7];
        public int[] CPOPCOR_DiagonalDireitaBaixo = new int[7];
        public int[] CPOPCOR_DiagonalEsquerdaBaixo = new int[7];
        public int[] CPOPCOR_CavaloJogadas = new int[8];


        // backup do player
        public byte Backup_Player;



        // é ativa antes dos movs das pessas
        public bool ChecandoSeReiNaoFicaEmXeque;


        //IdDasCasasDosLugaresOndeSeColocarDeixaReiEmXeque
        Dictionary<String, int> IDCDLOSCDREX_NaoPodeColocar = new Dictionary<String, int>();


        public bool SeReiFicaEmXequeNaoPodeColocar;

        public bool ChecandoSeReiNaoFicaEmXeque_NaoPodeColocar;

        //IdDasCasasDosLugaresOndeSeColocarDeixaReiEmXequeRivalJogadas
        Dictionary<String, int> IDCDLOSCDREXRJ_RivalJogadas = new Dictionary<String, int>();


        // string para a label labelInfoRei
        public string labelInfoRei;
        public Color labelInfoReiColor = Color.FromArgb(0, 0, 0);



        #endregion


        // testa a casa do tabuleiro
        public void TestarTabuleiroDebugMetodo(int ID_DA_CASA)
        {
            Log = "Testando o tabuleiro";

            // se tiver no modo editor
            // e no modo selecionadado ele desselecionda

            if (ModoEditor == true
                && ModoEditor_Selecionar == true)
            {
                ModoEditor_TemCasaSelecionada = false;
                comboBoxAPessaJaFoiMovidaEnabled = false;
                comboBoxDirecaoDoPeaoEnabled = false;
                comboBoxPeaoAndouDuasCasasEnabled = false;
                comboBoxPessaEscolhidaEnabled = false;
                numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = false;
            }


            NomeDosBotoesPeloValorDaPessa();

            if (CasaEstaOcupada[ID_DA_CASA] == false)
            {
                for (int i = 0; i < 64; i++)
                {
                    ImagemNasCasasL2[i] = IMAGEM_TRASPARENTE;
                }

                DefineAsColunasLinhasDiagonais(ID_DA_CASA);

                ImagemNasCasasL2[ID_DA_CASA] = IMAGEM_DIRECAOSELECIONADO;
                NomesNosBotoesDotabuleiro[ID_DA_CASA] = NomeSELECIONADO;
                DescricaoDosBotoesInfoMov[ID_DA_CASA] = NomeDESCRICAO_CASASELECIONADA;
                CORESNASCASAS[ID_DA_CASA] = CORES_DIRECAO;

                for (int i = 0; i < 7; i++)
                {
                    // direita
                    ImagemNasCasasL2[LinhaAdireitaDaPessa[i]] = IMAGEM_DIRECAODIREITA;
                    CORESNASCASAS[LinhaAdireitaDaPessa[i]] = CORES_DIRECAO;
                    DescricaoDosBotoesInfoMov[LinhaAdireitaDaPessa[i]] = NomeDIRECAODIREITA;
                    if (CasaEstaOcupada[LinhaAdireitaDaPessa[i]] == true)
                    {
                        NomesNosBotoesDotabuleiro[LinhaAdireitaDaPessa[i]] += NomeEmBranco + NomeDIRECAODIREITA;
                    }
                    else
                    {
                        NomesNosBotoesDotabuleiro[LinhaAdireitaDaPessa[i]] = NomeDIRECAODIREITA;
                    }

                    //esquerda
                    ImagemNasCasasL2[LinhaAesquerdaDaPessa[i]] = IMAGEM_DIRECAOESQUERDA;
                    CORESNASCASAS[LinhaAesquerdaDaPessa[i]] = CORES_DIRECAO;
                    DescricaoDosBotoesInfoMov[LinhaAesquerdaDaPessa[i]] = NomeDIRECAOESQUERDA;
                    if (CasaEstaOcupada[LinhaAesquerdaDaPessa[i]] == true)
                    {
                        NomesNosBotoesDotabuleiro[LinhaAesquerdaDaPessa[i]] += NomeEmBranco + NomeDIRECAOESQUERDA;
                    }
                    else
                    {
                        NomesNosBotoesDotabuleiro[LinhaAesquerdaDaPessa[i]] = NomeDIRECAOESQUERDA;
                    }

                    //cima
                    ImagemNasCasasL2[ColunaAcimaDaPessa[i]] = IMAGEM_DIRECAOCIMA;
                    CORESNASCASAS[ColunaAcimaDaPessa[i]] = CORES_DIRECAO;
                    DescricaoDosBotoesInfoMov[ColunaAcimaDaPessa[i]] = NomeDIRECAOCIMA;
                    if (CasaEstaOcupada[ColunaAcimaDaPessa[i]] == true)
                    {
                        NomesNosBotoesDotabuleiro[ColunaAcimaDaPessa[i]] += NomeEmBranco + NomeDIRECAOCIMA;
                    }
                    else
                    {
                        NomesNosBotoesDotabuleiro[ColunaAcimaDaPessa[i]] = NomeDIRECAOCIMA;
                    }

                    //baixo
                    ImagemNasCasasL2[ColunaAbaixoDaPessa[i]] = IMAGEM_DIRECAOBAIXO;
                    CORESNASCASAS[ColunaAbaixoDaPessa[i]] = CORES_DIRECAO;
                    DescricaoDosBotoesInfoMov[ColunaAbaixoDaPessa[i]] = NomeDIRECAOBAIXO;
                    if (CasaEstaOcupada[ColunaAbaixoDaPessa[i]] == true)
                    {
                        NomesNosBotoesDotabuleiro[ColunaAbaixoDaPessa[i]] += NomeEmBranco + NomeDIRECAOBAIXO;
                    }
                    else
                    {
                        NomesNosBotoesDotabuleiro[ColunaAbaixoDaPessa[i]] = NomeDIRECAOBAIXO;
                    }

                    // diganais

                    //direita baixo
                    ImagemNasCasasL2[DiagonalDireitaBaixoDaPessa[i]] = IMAGEM_DIRECAODIAGONALDIREITABAIXO;
                    CORESNASCASAS[DiagonalDireitaBaixoDaPessa[i]] = CORES_DIRECAO;
                    DescricaoDosBotoesInfoMov[DiagonalDireitaBaixoDaPessa[i]] = NomeDIRECAODIAGONALDIREITABAIXO;
                    if (CasaEstaOcupada[DiagonalDireitaBaixoDaPessa[i]] == true)
                    {
                        NomesNosBotoesDotabuleiro[DiagonalDireitaBaixoDaPessa[i]] += NomeEmBranco + NomeDIRECAODIAGONALDIREITABAIXO;
                    }
                    else
                    {
                        NomesNosBotoesDotabuleiro[DiagonalDireitaBaixoDaPessa[i]] = NomeDIRECAODIAGONALDIREITABAIXO;
                    }

                    //direita cima
                    ImagemNasCasasL2[DiagonalDireitaCimaDaPessa[i]] = IMAGEM_DIRECAODIAGONALDIREITACIMA;
                    CORESNASCASAS[DiagonalDireitaCimaDaPessa[i]] = CORES_DIRECAO;
                    DescricaoDosBotoesInfoMov[DiagonalDireitaCimaDaPessa[i]] = NomeDIRECAODIAGONALDIREITACIMA;
                    if (CasaEstaOcupada[DiagonalDireitaCimaDaPessa[i]] == true)
                    {
                        NomesNosBotoesDotabuleiro[DiagonalDireitaCimaDaPessa[i]] += NomeEmBranco + NomeDIRECAODIAGONALDIREITACIMA;
                    }
                    else
                    {
                        NomesNosBotoesDotabuleiro[DiagonalDireitaCimaDaPessa[i]] = NomeDIRECAODIAGONALDIREITACIMA;
                    }

                    //esquerda baixo
                    ImagemNasCasasL2[DiagonalEsquerdaBaixoDaPessa[i]] = IMAGEM_DIRECAODIAGONALESQUERDABAIXO;
                    CORESNASCASAS[DiagonalEsquerdaBaixoDaPessa[i]] = CORES_DIRECAO;
                    DescricaoDosBotoesInfoMov[DiagonalEsquerdaBaixoDaPessa[i]] = NomeDIRECAODIAGONALESQUERDABAIXO;
                    if (CasaEstaOcupada[DiagonalEsquerdaBaixoDaPessa[i]] == true)
                    {
                        NomesNosBotoesDotabuleiro[DiagonalEsquerdaBaixoDaPessa[i]] += NomeEmBranco + NomeDIRECAODIAGONALESQUERDABAIXO;
                    }
                    else
                    {
                        NomesNosBotoesDotabuleiro[DiagonalEsquerdaBaixoDaPessa[i]] = NomeDIRECAODIAGONALESQUERDABAIXO;
                    }

                    //esquerda cima
                    ImagemNasCasasL2[DiagonalEsquerdaCimaDaPessa[i]] = IMAGEM_DIRECAODIAGONALESQUERDACIMA;
                    CORESNASCASAS[DiagonalEsquerdaCimaDaPessa[i]] = CORES_DIRECAO;
                    DescricaoDosBotoesInfoMov[DiagonalEsquerdaCimaDaPessa[i]] = NomeDIRECAODIAGONALESQUERDACIMA;
                    if (CasaEstaOcupada[DiagonalEsquerdaCimaDaPessa[i]] == true)
                    {
                        NomesNosBotoesDotabuleiro[DiagonalEsquerdaCimaDaPessa[i]] += NomeEmBranco + NomeDIRECAODIAGONALESQUERDACIMA;
                    }
                    else
                    {
                        NomesNosBotoesDotabuleiro[DiagonalEsquerdaCimaDaPessa[i]] = NomeDIRECAODIAGONALESQUERDACIMA;
                    }

                }

                // cavalo
                for (int i = 0; i < 8; i++)
                {
                    ImagemNasCasasL2[CavaloJogadas[i]] = IMAGEM_DIRECAOCAVALO;
                    CORESNASCASAS[CavaloJogadas[i]] = CORES_DIRECAO;
                    DescricaoDosBotoesInfoMov[CavaloJogadas[i]] = NomeDIRECAOCAVALO;
                    if (CasaEstaOcupada[CavaloJogadas[i]] == true)
                    {
                        NomesNosBotoesDotabuleiro[CavaloJogadas[i]] += NomeEmBranco + NomeDIRECAOCAVALO;
                    }
                    else
                    {
                        NomesNosBotoesDotabuleiro[CavaloJogadas[i]] = NomeDIRECAOCAVALO;
                    }
                }

            }
            else
            {
                // Backup_Player

                Backup_Player = Player;
                if (CorDaPessa[ID_DA_CASA] == 1)
                {
                    Player = 1;
                    RivalDoPlayer = 2;
                }
                else
                {
                    Player = 2;
                    RivalDoPlayer = 1;
                }

                // coloca o a casa como selecionado

                NomesNosBotoesDotabuleiro[ID_DA_CASA] += NomeEmBranco + NomeSELECIONADO;
                DescricaoDosBotoesInfoMov[ID_DA_CASA] = NomeDESCRICAO_SELECIONADO;
                CORESNASCASAS[ID_DA_CASA] = CORES_SELECIONADO;
                ImagemNasCasasL2[ID_DA_CASA] = IMAGEM_SELECIONADO;

                ////
                Selecionado_TabuleiroID = ID_DA_CASA;
                Selecionado_CorDaPessaValor = CorDaPessa[ID_DA_CASA];
                Selecionado_PessaValor = Pessa[ID_DA_CASA];
                Selecionado_DirecaoDoPeaoValor = DirecaoDoPeao[ID_DA_CASA];
                DefineAsColunasLinhasDiagonais(Selecionado_TabuleiroID);
                NaoPodeDeixarReiEmCheque();
                DefineOndePossoColocarCadaPessa();

                if (Backup_Player == 1)
                {
                    Player = 1;
                    RivalDoPlayer = 2;
                }
                else
                {
                    Player = 2;
                    RivalDoPlayer = 1;
                }

            }


            for (int i = 0; i < 64; i++)
            {
                NaoPodeClicarNesseBotao[i] = false;
            }

        }

        // metodo ao clicar na casa
        public void DarClickNaCasaDoTabuleiro(int ID_DA_CASA)
        {
            //Console.WriteLine("log: Cliquei no botão: " + ID_DA_CASA);

            if (BotaoBloqueado == true)
            {

                Log = "vc n pode usar esse botão ate q todo o codigo seja realizado";
            }
            else
            {
                BotaoBloqueado = true;

                if (TestarTabuleiroDebug == true)
                {
                    TestarTabuleiroDebugMetodo(ID_DA_CASA);
                }
                else
                {

                    if (ModoEditor == true)
                    {
                        ModoEditorMetodo(ID_DA_CASA);
                    }
                    else
                    {
                        if (HouveEmpate == true)
                        {
                            Log = "Fim de jogo";
                        }
                        else
                        {
                            if (XequeMate == true)
                            {
                                // aki faz ação caso tenha cheq mate no jogo
                                Log = "Fim de jogo";
                            }
                            else
                            {
                                // if pra verificar se posso ou n clicar nesse botao
                                if (NaoPodeClicarNesseBotao[ID_DA_CASA] == true)
                                {
                                    Log = "vc n pode clicar aki";
                                }
                                else // se false eu posso clicar nessa casa
                                {
                                    //aki verifica se eu ja escolhi uma casa pra colocar a peça escolhida
                                    if (ColoqueiAPessaEmUmaCasa == true)
                                    {
                                        //aki checa se pode desselecionar essa casa 
                                        if (ID_DA_CASA == ColoqueiAPessaEmUmaCasa_TabuleiroID)
                                        {
                                            ColoqueiAPessaEmUmaCasa = false;
                                            ColoqueiAPessaEmUmaCasa_TabuleiroID = 64;
                                            EstouFazendoUmRoque = false;
                                            //CasaDoRoque = 64;
                                            //CasaDoRoqueOndeATorreVai = 64;
                                            //CasaDoRoqueOndeATorreTava = 64;

                                            OPeaoAndouDuasCasas = false;

                                            //EstoufazendoUmEnPassant = false;
                                            EstoufazendoUmEnPassantADireitaOuACima = false;
                                            EstoufazendoUmEnPassantAEsquerdaOuABaixo = false;

                                            // NomeDosBotoesPeloValorDaPessa();

                                            for (int id = 0; id < 65; id++)
                                            {
                                                NomesNosBotoesDotabuleiro[id] = NomesNosBotoesDotabuleiroComCelecPode[id];
                                                CORESNASCASAS[id] = CORESNASCASAS_ComCelecPode[id];
                                                ImagemNasCasasL2[id] = ImagemNasCasasL2_ComCelecPode[id];
                                                DescricaoDosBotoesInfoMov[id] = DescricaoDosBotoesInfoMov_ComCelecPode[id];
                                            }

                                            // ao deselecionar a peça volta para o fator de peça "selecionada"
                                            // colocar codigo aki

                                            for (int id = 0; id < 65; id++)
                                            {
                                                NaoPodeClicarNesseBotao[id] = NaoPodeClicarNesseBotaoComInfoDaPessaSelecionada[id];
                                            }
                                            Log = "deselecionado lugar onde a peça ia ser colocada";

                                        }

                                        // colocar if para caso eu clicar na peça selecionada, quando ja estiver aparecendo aki.


                                        if (ID_DA_CASA == Selecionado_TabuleiroID)
                                        {
                                            // aki ele vai desselecionar tudo
                                            ColoqueiAPessaEmUmaCasa = false;
                                            TemCasaSelecionada = false;
                                            NomeDosBotoesPeloValorDaPessa();
                                            for (int id = 0; id < 65; id++)
                                            {
                                                NaoPodeClicarNesseBotao[id] = false;
                                            }

                                            //Selecionado_TabuleiroID = 64;
                                            Selecionado_CorDaPessaValor = 0;
                                            Selecionado_PessaValor = 0;
                                            ColoqueiAPessaEmUmaCasa_TabuleiroID = 64;

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

                                            OPeaoAndouDuasCasas = false;
                                            //EstoufazendoUmEnPassant = false;
                                            EstoufazendoUmEnPassantADireitaOuACima = false;
                                            EstoufazendoUmEnPassantAEsquerdaOuABaixo = false;
                                            //CasaQueClicareiParaEnPassant = 64;
                                            CasaQueClicareiParaEnPassantADireitaOuACima = 64;
                                            CasaQueClicareiParaEnPassantAEsquerdaOuABaixo = 64;

                                            Log = "deselecionado tudo";
                                        }
                                    }
                                    else
                                    {
                                        //aki verifica se ja foi selecionado uma casa com uma peça
                                        if (TemCasaSelecionada == true)
                                        {
                                            if (CorDaPessa[ID_DA_CASA] == Player
                                                && ID_DA_CASA != Selecionado_TabuleiroID)
                                            {
                                                //aki faz a ação de selecionar uma casa 
                                                //ChecarSeOReiFoiColocadoEmXeque();
                                                NomeDosBotoesPeloValorDaPessa();
                                                SelecionarCasaDoTabuleiro(ID_DA_CASA);
                                            }
                                            else
                                            {
                                                // aki faz a ação pos ter selecionado uma casa
                                                OndeColocarPessaNaCasaDoTabuleiro(ID_DA_CASA);

                                                if (AutoConcluirJogada == true)
                                                {
                                                    BotaoBloqueado = false;
                                                    ConcluirJogada();
                                                }

                                            }
                                        }
                                        else
                                        {
                                            //aki faz a ação de selecionar uma casa 
                                            //ChecarSeOReiFoiColocadoEmXeque();
                                            SelecionarCasaDoTabuleiro(ID_DA_CASA);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                BotaoBloqueado = false;
            }
        }
        
        // metodo q seleciona uma casa no tabuleito e diz onde pode colocar
        public void SelecionarCasaDoTabuleiro(int ID_DA_CASA)
        {

            if (CorDaPessa[ID_DA_CASA] == Player)
            {

                Selecionado_TabuleiroID = ID_DA_CASA;
                Selecionado_CorDaPessaValor = CorDaPessa[ID_DA_CASA];
                Selecionado_PessaValor = Pessa[ID_DA_CASA];
                Selecionado_DirecaoDoPeaoValor = DirecaoDoPeao[ID_DA_CASA];
                TemCasaSelecionada = true;
                // AKI MUDA O TEXTO DA CASA
                // aki é o nome de todas as casas sem cel pode e aki

                /*
                for (int id = 0; id < 65; id++)
                {
                    NomesNosBotoesDotabuleiroSemCelecPodeAki[id] = NomesNosBotoesDotabuleiro[id];
                    CORESNASCASAS_SemCelecPodeAki[id] = CORESNASCASAS[id];
                    ImagemNasCasasL2_SemCelecPodeAki[id] = ImagemNasCasasL2[id];
                }
                */
                NomesNosBotoesDotabuleiro[ID_DA_CASA] += NomeEmBranco + NomeSELECIONADO;
                DescricaoDosBotoesInfoMov[ID_DA_CASA] = NomeDESCRICAO_SELECIONADO;
                CORESNASCASAS[ID_DA_CASA] = CORES_SELECIONADO;
                ImagemNasCasasL2[ID_DA_CASA] = IMAGEM_SELECIONADO;


                // aki colocar chamada de metodo q vai definir onde eu terei permição para colocar a peça 
                DefineAsColunasLinhasDiagonais(Selecionado_TabuleiroID);
                NaoPodeDeixarReiEmCheque();
                DefineOndePossoColocarCadaPessa();

                for (int id = 0; id < 65; id++)
                {
                    NomesNosBotoesDotabuleiroComCelecPode[id] = NomesNosBotoesDotabuleiro[id];
                    CORESNASCASAS_ComCelecPode[id] = CORESNASCASAS[id];
                    ImagemNasCasasL2_ComCelecPode[id] = ImagemNasCasasL2[id];
                    NaoPodeClicarNesseBotaoComInfoDaPessaSelecionada[id] = NaoPodeClicarNesseBotao[id];
                    DescricaoDosBotoesInfoMov_ComCelecPode[id] = DescricaoDosBotoesInfoMov[id];
                }

                Console.WriteLine(" peça selecionada com sucesso ID: " + ID_DA_CASA);
                Log = "peça selecionada com sucesso ID: " + ID_DA_CASA;

                // aki permite selecionar outras peças do player sem ter q deselecionar a selecionada antes

                for (int i = 0; i < 64; i++)
                {
                    if (CorDaPessa[i] == Player)
                    {
                        NaoPodeClicarNesseBotao[i] = false;
                    }


                }

            }

            else
            {
                Console.WriteLine("vc n pode selecionar essa peça ID: " + ID_DA_CASA);
                Log = "vc n pode selecionar essa peça ID: " + ID_DA_CASA;
            }
        }

        // define o "aki" no tabuleiro
        public void OndeColocarPessaNaCasaDoTabuleiro(int ID_DA_CASA)
        {
            // esse if é para desselecionar a casa selecionada 
            if (ID_DA_CASA == Selecionado_TabuleiroID)
            {

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

                ColoqueiAPessaEmUmaCasa = false;
                ColoqueiAPessaEmUmaCasa_TabuleiroID = 64;

                Selecionado_TabuleiroID = 64;
                Selecionado_CorDaPessaValor = 0;
                Selecionado_PessaValor = 0;
                TemCasaSelecionada = false;

                OPeaoAndouDuasCasas = false;
                EstoufazendoUmEnPassantADireitaOuACima = false;
                EstoufazendoUmEnPassantAEsquerdaOuABaixo = false;

                // aki é o nome de todas as casas sem cel pode e aki
                //NomesNosBotoesDotabuleiro = NomesNosBotoesDotabuleiroSemCelecPodeAki;

                // remuda o nome
                //NomesNosBotoesDotabuleiro[ID_DA_CASA] = NomeREMOVERESELECIONADO;

                NomeDosBotoesPeloValorDaPessa();


                // aki vai redifinir onde eu posso clicar no tabluleiro

                for (int id = 0; id < 65; id++)
                {
                    NaoPodeClicarNesseBotao[id] = false;
                }


                Console.WriteLine("peça desselecionada ID: " + ID_DA_CASA);
                Log = "peça desselecionada ID: " + ID_DA_CASA;


            }
            else {
                // se ele n vai desselecionar a casa ele vai fazer isso:

                //Console.WriteLine("ja foi selecionado uma casa");
                //this.Log = "ja foi selecionado uma casa ID";

                // apartir do if é um modo livre pra testar///

                // como esse codigo so vai funcionar nas casas permitidas pode deixar assim

                if (ID_DA_CASA != Selecionado_TabuleiroID)
                {

                    // aki ele permite colocar a peça em qualquer lugar menos onde ela ja esta. 
                    ColoqueiAPessaEmUmaCasa_TabuleiroID = ID_DA_CASA;
                    ColoqueiAPessaEmUmaCasa = true;

                    // AKI MUDA O TEXTO DA CASA

                    NomeDosBotoesPeloValorDaPessa();
                    /*
                    for (int id = 0; id < 65; id++)
                    {
                        //NomesNosBotoesDotabuleiro[id] = NomesNosBotoesDotabuleiroSemCelecPodeAki[id];
                        //CORESNASCASAS[id] = CORESNASCASAS_SemCelecPodeAki[id];
                        //ImagemNasCasasL2[id] = ImagemNasCasasL2_SemCelecPodeAki[id];
                        DescricaoDosBotoesInfoMov[id] = "";
                    }
                    */
                    NomesNosBotoesDotabuleiro[Selecionado_TabuleiroID] += NomeEmBranco + NomeSELECIONADO;
                    DescricaoDosBotoesInfoMov[Selecionado_TabuleiroID] = NomeDESCRICAO_SELECIONADO;
                    CORESNASCASAS[Selecionado_TabuleiroID] = CORES_SELECIONADO;
                    ImagemNasCasasL2[Selecionado_TabuleiroID] = IMAGEM_SELECIONADO;

                    if (CasaEstaOcupada[ID_DA_CASA] == true)
                    {
                        NomesNosBotoesDotabuleiro[ID_DA_CASA] += NomeEmBranco + NomeCOLOCARAQUI;
                    }
                    else
                    {
                        NomesNosBotoesDotabuleiro[ID_DA_CASA] = NomeCOLOCARAQUI;
                    }
                    DescricaoDosBotoesInfoMov[ID_DA_CASA] = NomeDESCRICAO_COLOCARAQUI;
                    CORESNASCASAS[ID_DA_CASA] = CORES_COLOCARAQUI;
                    ImagemNasCasasL2[ID_DA_CASA] = IMAGEM_COLOCARAQUI;


                    // aki colocar metodo para deixar somente essa casa clicavel;

                    for (int id = 0; id < 65; id++)
                    {
                        NaoPodeClicarNesseBotao[id] = true;
                    }
                    NaoPodeClicarNesseBotao[ID_DA_CASA] = false;
                    // aki permite tambem clicar na casa selecionada
                    NaoPodeClicarNesseBotao[Selecionado_TabuleiroID] = false;


                    // aki endentifica se é um roque e informa para o concluir jogada q estou fazendo um roque
                    // verifica se é um rei
                    if (Pessa[Selecionado_TabuleiroID] == 4
                       || Pessa[Selecionado_TabuleiroID] == 14
                       || Pessa[Selecionado_TabuleiroID] == 24)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            //verifica se o id da casa q eu clique é o mesmo id da casa do roque
                            if (ID_DA_CASA == CasaDoRoque[i] && CasaDoRoque[i] != 64)
                            {
                                EstouFazendoUmRoque = true;
                                NomesNosBotoesDotabuleiro[ID_DA_CASA] = NomeCOLOCARAQUI + NomeEmBranco + NomePODEROQUE;
                                DescricaoDosBotoesInfoMov[ID_DA_CASA] = NomeDESCRICAO_COLOCARAQUI + NomeEmBranco + NomeDESCRICAO_PODEROQUE;
                                CORESNASCASAS[ID_DA_CASA] = CORES_PODEROQUE;
                                ImagemNasCasasL2[ID_DA_CASA] = IMAGEM_PODEROQUEAKI;
                                RoqueDirecao[i] = true;
                            }
                        }
                    }



                    // ve se é um peão
                    if (Pessa[Selecionado_TabuleiroID] == 6
                      || Pessa[Selecionado_TabuleiroID] == 16
                      || Pessa[Selecionado_TabuleiroID] == 26)
                    {
                        // aki verifica q o peão andou duas casas:
                        if (ID_DA_CASA == ParaTodasAsDirecoesDaPessa[1])
                        {
                            OPeaoAndouDuasCasas = true;
                        }

                        // aki verifica se estou fazendo um en passant
                        if (ID_DA_CASA == CasaQueClicareiParaEnPassantADireitaOuACima)
                        {
                            EstoufazendoUmEnPassantADireitaOuACima = true;
                            NomesNosBotoesDotabuleiro[ID_DA_CASA] = NomeCOLOCARAQUI + NomeEmBranco + NomePODEENPASSANT;
                            DescricaoDosBotoesInfoMov[ID_DA_CASA] = NomeDESCRICAO_COLOCARAQUI + NomeEmBranco + NomeDESCRICAO_PODEENPASSANT;
                            CORESNASCASAS[ID_DA_CASA] = CORES_PODEENPASSANT;
                            ImagemNasCasasL2[ID_DA_CASA] = IMAGEM_PODEENPASSANTAKI;
                        }

                        // aki verifica se estou fazendo um en passant
                        if (ID_DA_CASA == CasaQueClicareiParaEnPassantAEsquerdaOuABaixo)
                        {
                            EstoufazendoUmEnPassantAEsquerdaOuABaixo = true;
                            NomesNosBotoesDotabuleiro[ID_DA_CASA] = NomeCOLOCARAQUI + NomeEmBranco + NomePODEENPASSANT;
                            DescricaoDosBotoesInfoMov[ID_DA_CASA] = NomeDESCRICAO_COLOCARAQUI + NomeEmBranco + NomeDESCRICAO_PODEENPASSANT;
                            CORESNASCASAS[ID_DA_CASA] = CORES_PODEENPASSANT;
                            ImagemNasCasasL2[ID_DA_CASA] = IMAGEM_PODEENPASSANTAKI;
                        }


                    }


                    Log = "selecionado para colocar a peça aki";


                }
                else { //se n, no pode fazer isso
                    Log = "vc n pode colocar a peça onde ela ja esta";
                    Console.WriteLine("vc n pode colocar a peça onde ela ja esta");
                }


            }


        }

        // metodo do botão de concluir a jogada.
        public void ConcluirJogada()
        {
            if (BotaoBloqueado == true)
            {

                Log = "vc n pode usar esse botão ate q todo o codigo seja realizado";

            }
            else
            {
                BotaoBloqueado = true;

                if (ColoqueiAPessaEmUmaCasa == true)
                {
                    //ReiEmXeque = false;

                    // faz backup dos casas/peças
                    for (int id = 0; id < 65; id++)
                    {
                        Backup_CasaEstaOcupada[id] = CasaEstaOcupada[id];
                        Backup_CorDaPessa[id] = CorDaPessa[id];
                        Backup_Pessa[id] = Pessa[id];
                        Backup_DirecaoDoPeao[id] = DirecaoDoPeao[id];
                        Backup_APessaJaFoiMovida[id] = APessaJaFoiMovida[id];
                        Backup_EmqualRodadaAPessaFoiMexida[id] = EmqualRodadaAPessaFoiMexida[id];
                        Backup_PeaoAndouDuasCasas[id] = PeaoAndouDuasCasas[id];
                    }

                    // aki limpa a casa onde tava a peça
                    Pessa[Selecionado_TabuleiroID] = 0;
                    CorDaPessa[Selecionado_TabuleiroID] = 0;
                    CasaEstaOcupada[Selecionado_TabuleiroID] = false;
                    DirecaoDoPeao[Selecionado_TabuleiroID] = 0;
                    APessaJaFoiMovida[Selecionado_TabuleiroID] = true;
                    EmqualRodadaAPessaFoiMexida[Selecionado_TabuleiroID] = 0;
                    PeaoAndouDuasCasas[Selecionado_TabuleiroID] = false;

                    // aki coloca a pessa nessa casa
                    Pessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = Selecionado_PessaValor;
                    CorDaPessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = Selecionado_CorDaPessaValor;
                    CasaEstaOcupada[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                    DirecaoDoPeao[ColoqueiAPessaEmUmaCasa_TabuleiroID] = Selecionado_DirecaoDoPeaoValor;
                    APessaJaFoiMovida[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                    EmqualRodadaAPessaFoiMexida[ColoqueiAPessaEmUmaCasa_TabuleiroID] = EmqualRodadaOplayerEstaJogando;
                    PeaoAndouDuasCasas[ColoqueiAPessaEmUmaCasa_TabuleiroID] = false;

                    // faz as coisas se a jogada for um roque
                    if (EstouFazendoUmRoque == true)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (RoqueDirecao[i] == true)
                            {
                                // caloca a torre no lado do rei
                                Pessa[CasaDoRoqueOndeATorreVai[i]] = Pessa[CasaDoRoqueOndeATorreTava[i]];
                                CorDaPessa[CasaDoRoqueOndeATorreVai[i]] = CorDaPessa[CasaDoRoqueOndeATorreTava[i]];
                                CasaEstaOcupada[CasaDoRoqueOndeATorreVai[i]] = true;
                                DirecaoDoPeao[CasaDoRoqueOndeATorreVai[i]] = DirecaoDoPeao[CasaDoRoqueOndeATorreTava[i]];
                                APessaJaFoiMovida[CasaDoRoqueOndeATorreVai[i]] = true;
                                EmqualRodadaAPessaFoiMexida[CasaDoRoqueOndeATorreVai[i]] = EmqualRodadaOplayerEstaJogando;

                                // removedo a torre de onde ela tava
                                Pessa[CasaDoRoqueOndeATorreTava[i]] = 0;
                                CorDaPessa[CasaDoRoqueOndeATorreTava[i]] = 0;
                                CasaEstaOcupada[CasaDoRoqueOndeATorreTava[i]] = false;
                                DirecaoDoPeao[CasaDoRoqueOndeATorreTava[i]] = 0;
                                APessaJaFoiMovida[CasaDoRoqueOndeATorreTava[i]] = true;
                                EmqualRodadaAPessaFoiMexida[CasaDoRoqueOndeATorreTava[i]] = 0;

                                RoqueDirecao[i] = false;
                            }
                        }

                        // conclui operação. 
                        EstouFazendoUmRoque = false;

                        // "limpa" os valores de checagem
                        //CasaDoRoqueOndeATorreVai = 64;
                        //CasaDoRoqueOndeATorreTava = 64;
                        //CasaDoRoque = 64;
                        ColoqueiAPessaEmUmaCasa_TabuleiroID = 64;
                        Selecionado_TabuleiroID = 64;
                        Selecionado_CorDaPessaValor = 0;
                        Selecionado_PessaValor = 0;

                    }

                    // informa q o peao andou 2 casa
                    if (OPeaoAndouDuasCasas == true)
                    {
                        PeaoAndouDuasCasas[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        OPeaoAndouDuasCasas = false;
                    }

                    // faz oq tem q fazer se esta fazando um en passant
                    if (EstoufazendoUmEnPassantADireitaOuACima == true)
                    {
                        Pessa[CasaDoPeaoAserRemovidoNoEnPassantADireitaOuACima] = 0;
                        CorDaPessa[CasaDoPeaoAserRemovidoNoEnPassantADireitaOuACima] = 0;
                        CasaEstaOcupada[CasaDoPeaoAserRemovidoNoEnPassantADireitaOuACima] = false;
                        DirecaoDoPeao[CasaDoPeaoAserRemovidoNoEnPassantADireitaOuACima] = 0;
                        APessaJaFoiMovida[CasaDoPeaoAserRemovidoNoEnPassantADireitaOuACima] = true;
                        EmqualRodadaAPessaFoiMexida[CasaDoPeaoAserRemovidoNoEnPassantADireitaOuACima] = 0;

                        EstoufazendoUmEnPassantADireitaOuACima = false;
                        CasaQueClicareiParaEnPassantADireitaOuACima = 64;
                    }
                    if (EstoufazendoUmEnPassantAEsquerdaOuABaixo == true)
                    {

                        Pessa[CasaDoPeaoAserRemovidoNoEnPassantAEsquerdaOuABaixo] = 0;
                        CorDaPessa[CasaDoPeaoAserRemovidoNoEnPassantAEsquerdaOuABaixo] = 0;
                        CasaEstaOcupada[CasaDoPeaoAserRemovidoNoEnPassantAEsquerdaOuABaixo] = false;
                        DirecaoDoPeao[CasaDoPeaoAserRemovidoNoEnPassantAEsquerdaOuABaixo] = 0;
                        APessaJaFoiMovida[CasaDoPeaoAserRemovidoNoEnPassantAEsquerdaOuABaixo] = true;
                        EmqualRodadaAPessaFoiMexida[CasaDoPeaoAserRemovidoNoEnPassantAEsquerdaOuABaixo] = 0;

                        EstoufazendoUmEnPassantAEsquerdaOuABaixo = false;
                        CasaQueClicareiParaEnPassantAEsquerdaOuABaixo = 64;
                    }

                    // faz as mudanças caso o peão chegue na ultima casa
                    PeaoChegouNaUltimaCasa();


                    // aki desativa as "flags"
                    ColoqueiAPessaEmUmaCasa = false;
                    TemCasaSelecionada = false;
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
                    CasaQueClicareiParaEnPassantADireitaOuACima = 64;
                    CasaQueClicareiParaEnPassantAEsquerdaOuABaixo = 64;


                    // aki checa se eu coloque o rei em Xeque
                    ChecarSeOReiFoiColocadoEmXeque();

                    // se o rei estiver em Xeque ele n deixa fazer a jogada
                    if (ReiFoiColocadoEmXeque == true)
                    {
                        //restaura o primeiro backup.
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

                        //Vc n pode fazer esse movimento ele põe o seu rei em Xeque ou 
                        Log = "vc n pode deixar seu rei em Xeque";
                    }
                    else
                    {
                        // aki ele continua a jogada normalmente
                        // faz backup para ser usado na testagem do Xeque-mate
                        // faz backup dos casas/peças
                        for (int id = 0; id < 65; id++)
                        {
                            Backup_CasaEstaOcupada[id] = CasaEstaOcupada[id];
                            Backup_CorDaPessa[id] = CorDaPessa[id];
                            Backup_Pessa[id] = Pessa[id];
                            Backup_DirecaoDoPeao[id] = DirecaoDoPeao[id];
                            Backup_APessaJaFoiMovida[id] = APessaJaFoiMovida[id];
                            Backup_EmqualRodadaAPessaFoiMexida[id] = EmqualRodadaAPessaFoiMexida[id];
                            Backup_PeaoAndouDuasCasas[id] = PeaoAndouDuasCasas[id];
                        }

                        labelInfoRei = "";

                        // ativar metodo para ativar a checagem de Xeque-mate
                        ChecandoSeAhXequeMate();

                        // outro tipo de cheque mate
                        SoUmReiSemjogadasEhXequeMate();

                        // checa se ouve empate de ter so dois reis no jogo
                        EmpateSoTemDoisReisNoTabuleiro();

                        if (HouveEmpate == true)
                        {
                            //
                            Log = "Fim De Jogo";
                            mesagemBoxEmpate = true;
                        }
                        else
                        {
                            if (ReiRivalFoiColocadoEmXequeMate == true)
                            {
                                //XequeMate = true;
                                Log = "Fim De Jogo";
                                mesagemBoxXequeMate = true;

                                // aki ele bloqueia todos os botoes
                                for (int id = 0; id < 65; id++)
                                {
                                    NaoPodeClicarNesseBotao[id] = true;
                                }

                                //ativa a variavel xeque-mate
                                XequeMate = true;

                            }
                            else
                            {

                                // aki muda o player q ta jogando
                                if (Player == 1)
                                {
                                    Player = 2;
                                    RivalDoPlayer = 1;
                                }
                                else
                                {
                                    Player = 1;
                                    RivalDoPlayer = 2;
                                }

                                // o próxima a jogar vai jogar na próxima rodada:
                                EmqualRodadaOplayerEstaJogando++;

                                Log = "operação concluida com sucesso, agora é a vez do jogador: " + Player;

                                // aki libera pra eu clicar em todos os botoes:
                                for (int id = 0; id < 65; id++)
                                {
                                    NaoPodeClicarNesseBotao[id] = false;
                                }

                            }
                        }
                    }

                    // aki muda o nome das casas:
                    NomeDosBotoesPeloValorDaPessa();

                    ReiFoiColocadoEmXeque = false;
                    
                }
                else
                {

                    Log = "vc n pode clicar aqui sem terminar a jogada";

                }
                BotaoBloqueado = false;
            }
        }

        
        // DefineOndePossoColocarCadaPessa
        public void DefineOndePossoColocarCadaPessa()
        {
            DefineAcasaComoClicavelBool = true;

            // aqui vai ser verificado qual peça foi selecionada


            // aki impede q todos os botões do tabuleiro sejam clicados.
            for (int id = 0; id < 65; id++) {
                NaoPodeClicarNesseBotao[id] = true;
            }

            // aki permite eu clicar na casa selecionada
            NaoPodeClicarNesseBotao[Selecionado_TabuleiroID] = false;

            DefineAsColunasLinhasDiagonais(Selecionado_TabuleiroID);

            switch (Selecionado_PessaValor) {

                case 0:
                    // caso imposivel de acontecer
                    Log = "ERRO, pesça id 0 selecionda";
                    break;
                case 1: //torre
                case 11: //torre azul
                case 21: //torre verde
                    MovimentosTorre();
                    break;
                case 2: //cavalo
                case 12: //cavalo azul
                case 22: //cavalo verde
                    MovimentosCavalo();
                    break;
                case 3: //bispo
                case 13: //bispo azul
                case 23: //bispo verde
                    MovimentosBispo();
                    break;
                case 4: //rei
                case 14: //rei azul
                case 24: //rei verde
                    MovimentosRei();
                    break;
                case 5: //rainha
                case 15: //rainha azul
                case 25: //rainha verde
                    MovimentosRainha();
                    break;
                case 6: //peão
                case 16: //peão azul
                case 26: //peão verde
                    MovimentosPeao();
                    break;
                default:
                    // foi selecionado um id de peça n verificado
                    Log = "ERRO, foi selecionado um id de peça n verificado";
                    break;

                 
            }

            DefineAcasaComoClicavelBool = false;
            SeReiFicaEmXequeNaoPodeColocar = false;

        }

        public void MovimentosTorre()
        {
            // parte a cima ColunaAcimaDaPessa
            //ParaTodasAsDirecoesDaPessa = ColunaAcimaDaPessa;
            DefineAsColunasLinhasDiagonais(Selecionado_TabuleiroID);
            TodasAsDirecoes(ColunaAcimaDaPessa);

            // parte a baixo ColunaAbaixoDaPessa
            //ParaTodasAsDirecoesDaPessa = ColunaAbaixoDaPessa;
            DefineAsColunasLinhasDiagonais(Selecionado_TabuleiroID);
            TodasAsDirecoes(ColunaAbaixoDaPessa);

            // linha direita LinhaAdireitaDaPessa
            //ParaTodasAsDirecoesDaPessa = LinhaAdireitaDaPessa;
            DefineAsColunasLinhasDiagonais(Selecionado_TabuleiroID);
            TodasAsDirecoes(LinhaAdireitaDaPessa);

            // linha a esquerda LinhaAesquerdaDaPessa
            //ParaTodasAsDirecoesDaPessa = LinhaAesquerdaDaPessa;
            DefineAsColunasLinhasDiagonais(Selecionado_TabuleiroID);
            TodasAsDirecoes(LinhaAesquerdaDaPessa);
        }

        public void MovimentosBispo()
        {
            // diagonal direita cima
            //ParaTodasAsDirecoesDaPessa = DiagonalDireitaCimaDaPessa;
            DefineAsColunasLinhasDiagonais(Selecionado_TabuleiroID);
            TodasAsDirecoes(DiagonalDireitaCimaDaPessa);

            // diagonal esquerda cima
            //ParaTodasAsDirecoesDaPessa = DiagonalEsquerdaCimaDaPessa;
            DefineAsColunasLinhasDiagonais(Selecionado_TabuleiroID);
            TodasAsDirecoes(DiagonalEsquerdaCimaDaPessa);

            // diagonal direita baixo
            //ParaTodasAsDirecoesDaPessa = DiagonalDireitaBaixoDaPessa;
            DefineAsColunasLinhasDiagonais(Selecionado_TabuleiroID);
            TodasAsDirecoes(DiagonalDireitaBaixoDaPessa);

            // diagonal esquerda baixo
            //ParaTodasAsDirecoesDaPessa = DiagonalEsquerdaBaixoDaPessa;
            DefineAsColunasLinhasDiagonais(Selecionado_TabuleiroID);
            TodasAsDirecoes(DiagonalEsquerdaBaixoDaPessa);
        }

        public void MovimentosRainha() {
            // a rainha faz os movimentos da torre e do bispo
            MovimentosTorre();
            MovimentosBispo();
        }

        public void MovimentosCavalo() {
            for (int id = 0; id < 8; id++)
            {
                if (CorDaPessa[CavaloJogadas[id]] != Player)
                {
                    DefineAcasaComoClicavel(CavaloJogadas[id]);
                }
            }
        }

 
        // aki define qual casa pode ser "clicavel"
        public void DefineAcasaComoClicavel(int ID_DA_CASA)
        {
            if (ID_DA_CASA != 64)
            {

                // usado no jogo normal
                if (DefineAcasaComoClicavelBool == true)
                {
                    if (EhUmRei == true)
                    {
                        if (IDCDLOORNPSC_ReiNaoPode.ContainsValue(ID_DA_CASA))
                        {
                            // n pode colocar
                            NaoPodeClicarNesseBotao[ID_DA_CASA] = true;
                            CORESNASCASAS[ID_DA_CASA] = CORES_NAOPODECOLOCAR;
                            ImagemNasCasasL2[ID_DA_CASA] = IMAGEM_NAOPODECOLOCAR;
                            DescricaoDosBotoesInfoMov[ID_DA_CASA] = NomeDESCRICAO_NAOPODECOLOCAR + NomeEmBranco + NomeDESCRICAO_PODECOLOCAR;
                            if (CasaEstaOcupada[ID_DA_CASA] == true)
                            {
                                NomesNosBotoesDotabuleiro[ID_DA_CASA] += NomeEmBranco + NomeNAOPODECOLOCAR;
                            }
                            else
                            {
                                NomesNosBotoesDotabuleiro[ID_DA_CASA] = NomeNAOPODECOLOCAR;
                            }
                        }
                        else
                        {
                            // pode colocar
                            NaoPodeClicarNesseBotao[ID_DA_CASA] = false;
                            CORESNASCASAS[ID_DA_CASA] = CORES_PODECOLOCAR;
                            ImagemNasCasasL2[ID_DA_CASA] = IMAGEM_PODECOLOCAR;
                            DescricaoDosBotoesInfoMov[ID_DA_CASA] = NomeDESCRICAO_PODECOLOCAR;
                            if (CasaEstaOcupada[ID_DA_CASA] == true)
                            {
                                NomesNosBotoesDotabuleiro[ID_DA_CASA] += NomeEmBranco + NomePODECOLOCAR;
                            }
                            else
                            {
                                NomesNosBotoesDotabuleiro[ID_DA_CASA] = NomePODECOLOCAR;
                            }
                        }

                    }
                    else
                    {

                        if (SeReiFicaEmXequeNaoPodeColocar == true)
                        {
                            if (IDCDLOSCDREX_NaoPodeColocar.ContainsValue(ID_DA_CASA))
                            {
                                // nao pode colocar
                                NaoPodeClicarNesseBotao[ID_DA_CASA] = true;
                                CORESNASCASAS[ID_DA_CASA] = CORES_NAOPODECOLOCAR;
                                ImagemNasCasasL2[ID_DA_CASA] = IMAGEM_NAOPODECOLOCAR;
                                DescricaoDosBotoesInfoMov[ID_DA_CASA] = NomeDESCRICAO_NAOPODECOLOCAR + NomeEmBranco + NomeDESCRICAO_PODECOLOCAR;
                                if (CasaEstaOcupada[ID_DA_CASA] == true)
                                {
                                    NomesNosBotoesDotabuleiro[ID_DA_CASA] += NomeEmBranco + NomeNAOPODECOLOCAR;
                                }
                                else
                                {
                                    NomesNosBotoesDotabuleiro[ID_DA_CASA] = NomeNAOPODECOLOCAR;
                                }
                            }
                            else
                            {
                                // pode colocar
                                NaoPodeClicarNesseBotao[ID_DA_CASA] = false;
                                CORESNASCASAS[ID_DA_CASA] = CORES_PODECOLOCAR;
                                ImagemNasCasasL2[ID_DA_CASA] = IMAGEM_PODECOLOCAR;
                                DescricaoDosBotoesInfoMov[ID_DA_CASA] = NomeDESCRICAO_PODECOLOCAR;
                                if (CasaEstaOcupada[ID_DA_CASA] == true)
                                {
                                    NomesNosBotoesDotabuleiro[ID_DA_CASA] += NomeEmBranco + NomePODECOLOCAR;
                                }
                                else
                                {
                                    NomesNosBotoesDotabuleiro[ID_DA_CASA] = NomePODECOLOCAR;
                                }

                            }

                        }
                        else
                        {
                            NaoPodeClicarNesseBotao[ID_DA_CASA] = false;
                            CORESNASCASAS[ID_DA_CASA] = CORES_PODECOLOCAR;
                            ImagemNasCasasL2[ID_DA_CASA] = IMAGEM_PODECOLOCAR;
                            DescricaoDosBotoesInfoMov[ID_DA_CASA] = NomeDESCRICAO_PODECOLOCAR;
                            if (CasaEstaOcupada[ID_DA_CASA] == true)
                            {
                                NomesNosBotoesDotabuleiro[ID_DA_CASA] += NomeEmBranco + NomePODECOLOCAR;
                            }
                            else
                            {
                                NomesNosBotoesDotabuleiro[ID_DA_CASA] = NomePODECOLOCAR;
                            }
                        }

                    }
                }
                // usado no codigo do Xeque
                if (ChecandoSeOReiEstaEmXeque == true)
                {
                    if (IDCDMQAPDRPF_Rival.ContainsValue(ID_DA_CASA) == false)
                    {
                        IDCDMQAPDRPF_Rival.Add(Convert.ToString(ID_DA_CASA), ID_DA_CASA);
                    }
                }
                // usado no codigo do Xequemate
                if (ChecandoSeOReiEstaEmXequeMate == true)
                {
                    if (ChecandoSeOReiEstaEmXequeMateChecandoPlayer == true)
                    {
                        if (IDCDMQDPPF_Player.ContainsValue(ID_DA_CASA) == false)
                        {
                                IDCDMQDPPF_Player.Add(Convert.ToString(ID_DA_CASA), ID_DA_CASA);
                        }
                    }
                }

                // usado no codigo q ferifica se o mevimento n deixa o rei em xeque
                if (ChecandoSeReiNaoFicaEmXeque == true)
                {
                    NaoPodeDeixarReiEmChequePart2(ID_DA_CASA);
                }

                // checa as jogadas do rival em quanto checo se esse movimento deixa o rei em xeque
                if (ChecandoSeReiNaoFicaEmXeque_NaoPodeColocar == true)
                {
                    if (IDCDLOSCDREXRJ_RivalJogadas.ContainsValue(ID_DA_CASA) == false)
                    {
                        IDCDLOSCDREXRJ_RivalJogadas.Add(Convert.ToString(ID_DA_CASA), ID_DA_CASA);
                    }

                }


            }

        }

        // aki define as linhas/coluna/digonais clicaveis
        public void TodasAsDirecoes(int[] Direcao) {

            ParaTodasAsDirecoesDaPessa = Direcao;
            if (CorDaPessa[ParaTodasAsDirecoesDaPessa[0]] != Player)
            {
                DefineAcasaComoClicavel(ParaTodasAsDirecoesDaPessa[0]);
            }

            ParaTodasAsDirecoesDaPessa = Direcao;
            if (CorDaPessa[ParaTodasAsDirecoesDaPessa[1]] != Player)
            {
                if (CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[0]] == false)
                {
                    DefineAcasaComoClicavel(ParaTodasAsDirecoesDaPessa[1]);
                }
            }

            ParaTodasAsDirecoesDaPessa = Direcao;
            if (CorDaPessa[ParaTodasAsDirecoesDaPessa[2]] != Player)
            {
                if (CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[0]] == false
                    && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[1]] == false)
                {
                    DefineAcasaComoClicavel(ParaTodasAsDirecoesDaPessa[2]);
                }
            }

            ParaTodasAsDirecoesDaPessa = Direcao;
            if (CorDaPessa[ParaTodasAsDirecoesDaPessa[3]] != Player)
            {
                if (CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[0]] == false
                    && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[1]] == false
                    && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[2]] == false)
                {
                    DefineAcasaComoClicavel(ParaTodasAsDirecoesDaPessa[3]);
                }
            }

            ParaTodasAsDirecoesDaPessa = Direcao;
            if (CorDaPessa[ParaTodasAsDirecoesDaPessa[4]] != Player)
            {
                if (CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[0]] == false
                    && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[1]] == false
                    && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[2]] == false
                    && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[3]] == false)
                {
                    DefineAcasaComoClicavel(ParaTodasAsDirecoesDaPessa[4]);
                }
            }

            ParaTodasAsDirecoesDaPessa = Direcao;
            if (CorDaPessa[ParaTodasAsDirecoesDaPessa[5]] != Player)
            {
                if (CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[0]] == false
                    && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[1]] == false
                    && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[2]] == false
                    && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[3]] == false
                    && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[4]] == false)
                {
                    DefineAcasaComoClicavel(ParaTodasAsDirecoesDaPessa[5]);
                }
            }

            ParaTodasAsDirecoesDaPessa = Direcao;
            if (CorDaPessa[ParaTodasAsDirecoesDaPessa[6]] != Player)
            {
                if (CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[0]] == false
                    && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[1]] == false
                    && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[2]] == false
                    && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[3]] == false
                    && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[4]] == false
                    && CasaEstaOcupada[ParaTodasAsDirecoesDaPessa[5]] == false)
                {
                    DefineAcasaComoClicavel(ParaTodasAsDirecoesDaPessa[6]);
                }
            }

        }


        // dar nome para as peças com o valor da peça
        public void NomeDosBotoesPeloValorDaPessa()
        {

            for (int id = 0; id < 65; id++)
            {
                ImagemNasCasasL2[id] = IMAGEM_TRASPARENTE;
                DescricaoDosBotoesInfoMov[id] = "";


                switch (Pessa[id]) {
                    case 0:
                        NomesNosBotoesDotabuleiro[id] = "";
                        DescricaoDosBotoesNomeDasPessas[id] = "";
                        CORESNASCASAS[id] = CORES_PRETO;
                        ImagemNasCasasL1[id] = IMAGEM_TRASPARENTE;
                        break;
                    case 11:
                        NomesNosBotoesDotabuleiro[id] = NomeTA;
                        DescricaoDosBotoesNomeDasPessas[id] = NomeTA;
                        CORESNASCASAS[id] = CORES_AZUL;
                        ImagemNasCasasL1[id] = IMAGEM_TA;
                        break;
                    case 12:
                        NomesNosBotoesDotabuleiro[id] = NomeCA;
                        DescricaoDosBotoesNomeDasPessas[id] = NomeCA;
                        CORESNASCASAS[id] = CORES_AZUL;
                        ImagemNasCasasL1[id] = IMAGEM_CA;
                        break;
                    case 13:
                        NomesNosBotoesDotabuleiro[id] = NomeBA;
                        DescricaoDosBotoesNomeDasPessas[id] = NomeBA;
                        CORESNASCASAS[id] = CORES_AZUL;
                        ImagemNasCasasL1[id] = IMAGEM_BA;
                        break;
                    case 14:
                        NomesNosBotoesDotabuleiro[id] = NomeREA;
                        DescricaoDosBotoesNomeDasPessas[id] = NomeREA;
                        CORESNASCASAS[id] = CORES_AZUL;
                        ImagemNasCasasL1[id] = IMAGEM_REA;
                        break;
                    case 15:
                        NomesNosBotoesDotabuleiro[id] = NomeRAA;
                        DescricaoDosBotoesNomeDasPessas[id] = NomeRAA;
                        CORESNASCASAS[id] = CORES_AZUL;
                        ImagemNasCasasL1[id] = IMAGEM_RAA;
                        break;
                    case 16:
                        NomesNosBotoesDotabuleiro[id] = NomePA;
                        DescricaoDosBotoesNomeDasPessas[id] = NomePA;
                        CORESNASCASAS[id] = CORES_AZUL;
                        ImagemNasCasasL1[id] = IMAGEM_PA;
                        break;
                    case 21:
                        NomesNosBotoesDotabuleiro[id] = NomeTV;
                        DescricaoDosBotoesNomeDasPessas[id] = NomeTV;
                        CORESNASCASAS[id] = CORES_VERDE;
                        ImagemNasCasasL1[id] = IMAGEM_TV;
                        break;
                    case 22:
                        NomesNosBotoesDotabuleiro[id] = NomeCV;
                        DescricaoDosBotoesNomeDasPessas[id] = NomeCV;
                        CORESNASCASAS[id] = CORES_VERDE;
                        ImagemNasCasasL1[id] = IMAGEM_CV;
                        break;
                    case 23:
                        NomesNosBotoesDotabuleiro[id] = NomeBV;
                        DescricaoDosBotoesNomeDasPessas[id] = NomeBV;
                        CORESNASCASAS[id] = CORES_VERDE;
                        ImagemNasCasasL1[id] = IMAGEM_BV;
                        break;
                    case 24:
                        NomesNosBotoesDotabuleiro[id] = NomeREV;
                        DescricaoDosBotoesNomeDasPessas[id] = NomeREV;
                        CORESNASCASAS[id] = CORES_VERDE;
                        ImagemNasCasasL1[id] = IMAGEM_REV;
                        break;
                    case 25:
                        NomesNosBotoesDotabuleiro[id] = NomeRAV;
                        DescricaoDosBotoesNomeDasPessas[id] = NomeRAV;
                        CORESNASCASAS[id] = CORES_VERDE;
                        ImagemNasCasasL1[id] = IMAGEM_RAV;
                        break;
                    case 26:
                        NomesNosBotoesDotabuleiro[id] = NomePV;
                        DescricaoDosBotoesNomeDasPessas[id] = NomePV;
                        CORESNASCASAS[id] = CORES_VERDE;
                        ImagemNasCasasL1[id] = IMAGEM_PV;
                        break;
                    default:
                        NomesNosBotoesDotabuleiro[id] = "???";
                        DescricaoDosBotoesNomeDasPessas[id] = "???";
                        CORESNASCASAS[id] = CORES_PRETO;
                        ImagemNasCasasL1[id] = IMAGEM_TRASPARENTE;
                        break;
                }

            }

            if (ModoEditor_TemCasaSelecionada == true)
            {
                ImagemNasCasasL2[Selecionado_TabuleiroID] = IMAGEM_SELECIONADO;
                DescricaoDosBotoesInfoMov[Selecionado_TabuleiroID] = NomeDESCRICAO_CASASELECIONADA;
                CORESNASCASAS[Selecionado_TabuleiroID] = CORES_SELECIONADO;

                if (NomesNosBotoesDotabuleiro[Selecionado_TabuleiroID] == "")
                {
                    NomesNosBotoesDotabuleiro[Selecionado_TabuleiroID] = NomeSELECIONADO;
                }
                else
                {
                    if (NomesNosBotoesDotabuleiro[Selecionado_TabuleiroID].EndsWith(NomeSELECIONADO) == false)
                    {
                        NomesNosBotoesDotabuleiro[Selecionado_TabuleiroID] += NomeEmBranco + NomeSELECIONADO;
                    }  
                }
            }

        }


        // metodo das descrições dos botoes do tabuleiro
        public void DescricaoDosBotoesMetodo() {

            for (int id = 0; id < 65; id++)
            {
                if (DescricaoDosBotoesNomeDasPessas[id] == "")
                {
                    DescricaoDosBotoes[id] =
                       IdNunericoParaNome[id] + Environment.NewLine +
                       DescricaoDosBotoesInfoMov[id];
                }
                else
                {
                    DescricaoDosBotoes[id] =
                       IdNunericoParaNome[id] + Environment.NewLine +
                       DescricaoDosBotoesNomeDasPessas[id] + Environment.NewLine +
                       DescricaoDosBotoesInfoMov[id];
                }
            }
        }


        // metodo das descrições dos botoes com info das variaveis
        public void DescricaoDosBotoesDebugMetodo()
        {
            for (int id = 0; id < 65; id++)
            {
                DescricaoDosBotoesDebug[id] =
                IdNunericoParaNome[id] + Environment.NewLine +
                "CasaEstaOcupada[" + id + "] = " + CasaEstaOcupada[id] + Environment.NewLine +
                "CorDaPessa[" + id + "] = " + CorDaPessa[id] + Environment.NewLine +
                "Pessa[" + id + "] = " + Pessa[id] + Environment.NewLine +
                "DirecaoDoPeao[" + id + "] = " + DirecaoDoPeao[id] + Environment.NewLine +
                "APessaJaFoiMovida[" + id + "] = " + APessaJaFoiMovida[id] + Environment.NewLine +
                "EmqualRodadaAPessaFoiMexida[" + id + "] = " + EmqualRodadaAPessaFoiMexida[id] + Environment.NewLine +
                "PeaoAndouDuasCasas[" + id + "] = " + PeaoAndouDuasCasas[id] + Environment.NewLine +
                "NaoPodeClicarNesseBotao[" + id + "] = " + NaoPodeClicarNesseBotao[id] + Environment.NewLine +
                "NomesNosBotoesDotabuleiro[" + id + "] = " + NomesNosBotoesDotabuleiro[id];
            }

            // para id 64
            /*
            DescricaoDosBotoesDebug[64] +=
                Environment.NewLine +
                "Variaveis Gerais:" + Environment.NewLine +
                "Player: " + Player + Environment.NewLine +
                "RivalDoPlayer: " + RivalDoPlayer + Environment.NewLine +
                "TemCasaSelecionada: " + TemCasaSelecionada + Environment.NewLine +
                "ColoqueiAPessaEmUmaCasa: " + ColoqueiAPessaEmUmaCasa
                ;
            */

        }

        // IdNunericoParaNome
        public void IdNunericoParaNomeMetodo()
        {
            IdNunericoParaNome[0] = "1A";
            IdNunericoParaNome[1] = "1B";
            IdNunericoParaNome[2] = "1C";
            IdNunericoParaNome[3] = "1D";
            IdNunericoParaNome[4] = "1E";
            IdNunericoParaNome[5] = "1F";
            IdNunericoParaNome[6] = "1G";
            IdNunericoParaNome[7] = "1H";
            IdNunericoParaNome[8] = "2A";
            IdNunericoParaNome[9] = "2B";
            IdNunericoParaNome[10] = "2C";
            IdNunericoParaNome[11] = "2D";
            IdNunericoParaNome[12] = "2E";
            IdNunericoParaNome[13] = "2F";
            IdNunericoParaNome[14] = "2G";
            IdNunericoParaNome[15] = "2H";
            IdNunericoParaNome[16] = "3A";
            IdNunericoParaNome[17] = "3B";
            IdNunericoParaNome[18] = "3C";
            IdNunericoParaNome[19] = "3D";
            IdNunericoParaNome[20] = "3E";
            IdNunericoParaNome[21] = "3F";
            IdNunericoParaNome[22] = "3G";
            IdNunericoParaNome[23] = "3H";
            IdNunericoParaNome[24] = "4A";
            IdNunericoParaNome[25] = "4B";
            IdNunericoParaNome[26] = "4C";
            IdNunericoParaNome[27] = "4D";
            IdNunericoParaNome[28] = "4E";
            IdNunericoParaNome[29] = "4F";
            IdNunericoParaNome[30] = "4G";
            IdNunericoParaNome[31] = "4H";
            IdNunericoParaNome[32] = "5A";
            IdNunericoParaNome[33] = "5B";
            IdNunericoParaNome[34] = "5C";
            IdNunericoParaNome[35] = "5D";
            IdNunericoParaNome[36] = "5E";
            IdNunericoParaNome[37] = "5F";
            IdNunericoParaNome[38] = "5G";
            IdNunericoParaNome[39] = "5H";
            IdNunericoParaNome[40] = "6A";
            IdNunericoParaNome[41] = "6B";
            IdNunericoParaNome[42] = "6C";
            IdNunericoParaNome[43] = "6D";
            IdNunericoParaNome[44] = "6E";
            IdNunericoParaNome[45] = "6F";
            IdNunericoParaNome[46] = "6G";
            IdNunericoParaNome[47] = "6H";
            IdNunericoParaNome[48] = "7A";
            IdNunericoParaNome[49] = "7B";
            IdNunericoParaNome[50] = "7C";
            IdNunericoParaNome[51] = "7D";
            IdNunericoParaNome[52] = "7E";
            IdNunericoParaNome[53] = "7F";
            IdNunericoParaNome[54] = "7G";
            IdNunericoParaNome[55] = "7H";
            IdNunericoParaNome[56] = "8A";
            IdNunericoParaNome[57] = "8B";
            IdNunericoParaNome[58] = "8C";
            IdNunericoParaNome[59] = "8D";
            IdNunericoParaNome[60] = "8E";
            IdNunericoParaNome[61] = "8F";
            IdNunericoParaNome[62] = "8G";
            IdNunericoParaNome[63] = "8H";
            IdNunericoParaNome[64] = "??";
        }

        // pra trocar de pessa quando o peão chega na ultima casa
        public void PeaoChegouNaUltimaCasa() {

            if (DirecaoDoPeao[ColoqueiAPessaEmUmaCasa_TabuleiroID] == 1) // pra cima
            {
                if (ColoqueiAPessaEmUmaCasa_TabuleiroID == 0
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 1
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 2
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 3
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 4
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 5
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 6
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 7)
                {
                    // se tudo for verdadeiro vai mudar pra pessa escolhida
                    ColocarPessaEscolhidaNoLugarDoPeao();
                }
            }
            if (DirecaoDoPeao[ColoqueiAPessaEmUmaCasa_TabuleiroID] == 2) // pra baixo
            {
                if (ColoqueiAPessaEmUmaCasa_TabuleiroID == 56
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 57
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 58
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 59
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 60
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 61
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 62
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 63)
                {
                    // se tudo for verdadeiro vai mudar pra pessa escolhida
                    ColocarPessaEscolhidaNoLugarDoPeao();
                }
            }

            if (DirecaoDoPeao[ColoqueiAPessaEmUmaCasa_TabuleiroID] == 3) // pra direita
            {
                if (ColoqueiAPessaEmUmaCasa_TabuleiroID == 7
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 15
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 23
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 31
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 39
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 47
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 55
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 63)
                {
                    // se tudo for verdadeiro vai mudar pra pessa escolhida
                    ColocarPessaEscolhidaNoLugarDoPeao();
                }
            }

            if (DirecaoDoPeao[ColoqueiAPessaEmUmaCasa_TabuleiroID] == 4) // pra esquerda
            {
                if (ColoqueiAPessaEmUmaCasa_TabuleiroID == 0
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 8
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 16
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 24
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 32
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 40
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 48
                    || ColoqueiAPessaEmUmaCasa_TabuleiroID == 56)
                {
                    // se tudo for verdadeiro vai mudar pra pessa escolhida
                    ColocarPessaEscolhidaNoLugarDoPeao();
                }
            }
        }

        // usado em PeaoChegouNaUltimaCasa()
        public void ColocarPessaEscolhidaNoLugarDoPeao() {

            //peao azul
            if (Pessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] == 16)
            {
                switch (IdDaPessaQueOPeaoVaiVirar)
                {
                    case 0: // rainha
                        Pessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 15;
                        CorDaPessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 1;
                        CasaEstaOcupada[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        DirecaoDoPeao[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 0;
                        APessaJaFoiMovida[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        break;
                    case 1: //torre
                        Pessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 11;
                        CorDaPessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 1;
                        CasaEstaOcupada[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        DirecaoDoPeao[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 0;
                        APessaJaFoiMovida[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        break;
                    case 2: // bispo
                        Pessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 13;
                        CorDaPessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 1;
                        CasaEstaOcupada[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        DirecaoDoPeao[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 0;
                        APessaJaFoiMovida[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        break;
                    case 3: // cavalo
                        Pessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 12;
                        CorDaPessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 1;
                        CasaEstaOcupada[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        DirecaoDoPeao[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 0;
                        APessaJaFoiMovida[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        break;
                    default:
                        Console.WriteLine("erro, n foi escolhido uma pessa para o peão");
                        break;
                }
            }

            //peão verde
            if (Pessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] == 26)
            {
                switch (IdDaPessaQueOPeaoVaiVirar)
                {
                    case 0: // rainha
                        Pessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 25;
                        CorDaPessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 2;
                        CasaEstaOcupada[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        DirecaoDoPeao[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 0;
                        APessaJaFoiMovida[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        break;
                    case 1: //torre
                        Pessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 21;
                        CorDaPessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 2;
                        CasaEstaOcupada[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        DirecaoDoPeao[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 0;
                        APessaJaFoiMovida[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        break;
                    case 2: // bispo
                        Pessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 23;
                        CorDaPessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 2;
                        CasaEstaOcupada[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        DirecaoDoPeao[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 0;
                        APessaJaFoiMovida[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        break;
                    case 3: // cavalo
                        Pessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 22;
                        CorDaPessa[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 2;
                        CasaEstaOcupada[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        DirecaoDoPeao[ColoqueiAPessaEmUmaCasa_TabuleiroID] = 0;
                        APessaJaFoiMovida[ColoqueiAPessaEmUmaCasa_TabuleiroID] = true;
                        break;
                    default:
                        Console.WriteLine("erro, n foi escolhido uma pessa para o peão");
                        break;
                }
            }
        }


        // /////////////////////////////////////////////// //

        public void IdentificandoOndeEstaoOsReis()
        {
            for (int id = 0; id < 64; id++)
            {
                if (Player == 1
                    && Pessa[id] == 14)
                {
                    CasaOndeEstaOReiDoPlayer = id;
                    //Console.WriteLine("CasaOndeEstaOReiDoPlayer: " + CasaOndeEstaOReiDoPlayer);
                }
                if (Player == 2
                    && Pessa[id] == 24)
                {
                    CasaOndeEstaOReiDoPlayer = id;
                    //Console.WriteLine("CasaOndeEstaOReiDoPlayer: " + CasaOndeEstaOReiDoPlayer);
                }
                if (RivalDoPlayer == 2
                    && Pessa[id] == 24)
                {
                    CasaOndeEstaOReiDoRival = id;
                    //Console.WriteLine("CasaOndeEstaOReiDoRival: " + CasaOndeEstaOReiDoRival);
                }
                if (RivalDoPlayer == 1
                    && Pessa[id] == 14)
                {
                    CasaOndeEstaOReiDoRival = id;
                    //Console.WriteLine("CasaOndeEstaOReiDoRival: " + CasaOndeEstaOReiDoRival);
                }
            }
        } 


        //metodo que checa se coloque o rei em Xeque
        public void ChecarSeOReiFoiColocadoEmXeque()
        {
            ChecandoSeOReiEstaEmXeque = true;

            IDCDMQAPDRPF_Rival.Clear();

            // identifica em q casa o rei esta
            IdentificandoOndeEstaoOsReis();

            // agora tenho q checar se alguma peça pode atacar esse rei

            for (int id = 0; id < 64; id++) {
                Selecionado_TabuleiroID = id;
                Selecionado_PessaValor = Pessa[Selecionado_TabuleiroID];
                Selecionado_CorDaPessaValor = CorDaPessa[Selecionado_TabuleiroID];
                Selecionado_DirecaoDoPeaoValor = DirecaoDoPeao[Selecionado_TabuleiroID];
                DefineAsColunasLinhasDiagonais(Selecionado_TabuleiroID);

                if (Player == 2)
                {
                    Player = 1;
                    RivalDoPlayer = 2;
                    switch (Selecionado_PessaValor)
                    {

                        case 11: //torre azul
                            MovimentosTorre();
                            break;
                        case 12: //cavalo azul
                            MovimentosCavalo();
                            break;
                        case 13: //bispo azul
                            MovimentosBispo();
                            break;
                        case 14: //rei azul
                            MovimentosRei();
                            break;
                        case 15: //rainha azul
                            MovimentosRainha();
                            break;
                        case 16: //peão azul
                            MovimentosPeao();
                            break;
                        default:
                            // aki n tem pessa inimiga
                            break;
                    }
                    Player = 2;
                    RivalDoPlayer = 1;
                }

                if (Player == 1)
                {
                    Player = 2;
                    RivalDoPlayer = 1;
                    switch (Selecionado_PessaValor)
                    {
                        case 21: //torre verde
                            MovimentosTorre();
                            break;
                        case 22: //cavalo verde
                            MovimentosCavalo();
                            break;
                        case 23: //bispo verde
                            MovimentosBispo();
                            break;
                        case 24: //rei verde
                            MovimentosRei();
                            break;
                        case 25: //rainha verde
                            MovimentosRainha();
                            break;
                        case 26: //peão verde
                            MovimentosPeao();
                            break;
                        default:
                            // aki n tem pessa inimiga
                            break;
                    }
                    Player = 1;
                    RivalDoPlayer = 2;
                }
            }

            // agora comparo se a casa do rei esta presente nessa lista. 

            ReiFoiColocadoEmXeque = IDCDMQAPDRPF_Rival.ContainsValue(CasaOndeEstaOReiDoPlayer);
            //ReiEmXeque = IDCDMQAPDRPF_Rival.ContainsValue(CasaOndeEstaOReiDoPlayer);
            //Console.WriteLine("ReiFoiColocadoEmXeque: " + ReiFoiColocadoEmXeque);
            IDCDMQAPDRPF_Rival.Clear();
            ChecandoSeOReiEstaEmXeque = false;
        }


        public void NaoPodeDeixarReiEmCheque()
        {
           
                DefineAcasaComoClicavelBool = false;
                EhUmRei = false;
                //ReiEmXeque = false;
                SeReiFicaEmXequeNaoPodeColocar = false;
                ChecandoSeOReiEstaEmXeque = false;
                ChecandoSeOReiEstaEmXequeMate = false;
                ChecandoSeOReiEstaEmXequeMateChecandoPlayer = false;
                ChecandoSeReiNaoFicaEmXeque_NaoPodeColocar = false;

                Backup_Selecionado_TabuleiroID = Selecionado_TabuleiroID;
                Backup_Selecionado_PessaValor = Selecionado_PessaValor;
                Backup_Selecionado_DirecaoDoPeaoValor = Selecionado_DirecaoDoPeaoValor;
                Backup_Selecionado_CorDaPessaValor = Selecionado_CorDaPessaValor;

                // faz backup dos casas/peças
                for (int id = 0; id < 65; id++)
                {
                    Backup_CasaEstaOcupada[id] = CasaEstaOcupada[id];
                    Backup_CorDaPessa[id] = CorDaPessa[id];
                    Backup_Pessa[id] = Pessa[id];
                    Backup_DirecaoDoPeao[id] = DirecaoDoPeao[id];
                    Backup_APessaJaFoiMovida[id] = APessaJaFoiMovida[id];
                    Backup_EmqualRodadaAPessaFoiMexida[id] = EmqualRodadaAPessaFoiMexida[id];
                    Backup_PeaoAndouDuasCasas[id] = PeaoAndouDuasCasas[id];
                }

                ChecandoSeReiNaoFicaEmXeque = true;

                IDCDLOSCDREX_NaoPodeColocar.Clear();
                IDCDLOSCDREXRJ_RivalJogadas.Clear();

                IdentificandoOndeEstaoOsReis();

                DefineAsColunasLinhasDiagonais(Backup_Selecionado_TabuleiroID);

                switch (Backup_Selecionado_PessaValor)
                {
                    case 11: //torre azul
                    case 21: //torre verde
                        MovimentosTorre();
                        break;
                    case 12: //cavalo azul
                    case 22: //cavalo verde
                        MovimentosCavalo();
                        break;
                    case 13: //bispo azul
                    case 23: //bispo verde
                        MovimentosBispo();
                        break;
                    //case 14: //rei azul
                    //case 24: //rei verde
                        //MovimentosRei();
                        //break;
                    case 15: //rainha azul
                    case 25: //rainha verde
                        MovimentosRainha();
                        break;
                    case 16: //peão azul
                        MovimentosPeao();
                        ChecarSePodeFazerEnpassant(26);
                        break;
                    case 26: //peão verde
                        MovimentosPeao();
                        ChecarSePodeFazerEnpassant(16);
                        break;
                    default:
                        // foi selecionado um id de peça n verificado
                        //Log = "ERRO, foi selecionado um id de peça n verificado";
                        break;

                }


                //restaura o backup.
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


                Selecionado_TabuleiroID = Backup_Selecionado_TabuleiroID;
                Selecionado_PessaValor = Backup_Selecionado_PessaValor;
                Selecionado_DirecaoDoPeaoValor = Backup_Selecionado_DirecaoDoPeaoValor;
                Selecionado_CorDaPessaValor = Backup_Selecionado_CorDaPessaValor;

                ChecandoSeReiNaoFicaEmXeque = false;
                SeReiFicaEmXequeNaoPodeColocar = true;

           
        }


        public void NaoPodeDeixarReiEmChequePart2(int ID_DA_CASA)
        {
            // movendo a pessa para checar

            CasaEstaOcupada[ID_DA_CASA] = CasaEstaOcupada[Backup_Selecionado_TabuleiroID];
            CorDaPessa[ID_DA_CASA] = CorDaPessa[Backup_Selecionado_TabuleiroID];
            Pessa[ID_DA_CASA] = Pessa[Backup_Selecionado_TabuleiroID];
            DirecaoDoPeao[ID_DA_CASA] = DirecaoDoPeao[Backup_Selecionado_TabuleiroID];
            APessaJaFoiMovida[ID_DA_CASA] = true;
            EmqualRodadaAPessaFoiMexida[ID_DA_CASA] = EmqualRodadaAPessaFoiMexida[Backup_Selecionado_TabuleiroID];
            PeaoAndouDuasCasas[ID_DA_CASA] = PeaoAndouDuasCasas[Backup_Selecionado_TabuleiroID];

            CasaEstaOcupada[Backup_Selecionado_TabuleiroID] = false;
            CorDaPessa[Backup_Selecionado_TabuleiroID] = 0;
            Pessa[Backup_Selecionado_TabuleiroID] = 0;
            DirecaoDoPeao[Backup_Selecionado_TabuleiroID] = 0;
            APessaJaFoiMovida[Backup_Selecionado_TabuleiroID] = false;
            EmqualRodadaAPessaFoiMexida[Backup_Selecionado_TabuleiroID] = 0;
            PeaoAndouDuasCasas[Backup_Selecionado_TabuleiroID] = false;

            // fica dentro de DefineAcasaComoClicavel
            ChecandoSeReiNaoFicaEmXeque = false;

            IDCDLOSCDREXRJ_RivalJogadas.Clear();
            ChecandoSeReiNaoFicaEmXeque_NaoPodeColocar = true;

            for (int i = 0; i < 64; i++)
            {
                Selecionado_TabuleiroID = i;
                Selecionado_PessaValor = Pessa[i];
                Selecionado_DirecaoDoPeaoValor = DirecaoDoPeao[i];
                Selecionado_CorDaPessaValor = CorDaPessa[i];

                DefineAsColunasLinhasDiagonais(i);

                if (Player == 1)
                {
                    Player = 2;
                    RivalDoPlayer = 1;
                    switch (Selecionado_PessaValor)
                    {                      
                        case 21: //torre verde
                            MovimentosTorre();
                            break;                        
                        case 22: //cavalo verde
                            MovimentosCavalo();
                            break;                       
                        case 23: //bispo verde
                            MovimentosBispo();
                            break;                       
                       // case 24: //rei verde
                            //MovimentosRei();
                           // break;                      
                        case 25: //rainha verde
                            MovimentosRainha();
                            break;                      
                        case 26: //peão verde
                            MovimentosPeao();
                            break;
                    }
                    Player = 1;
                    RivalDoPlayer = 2;
                }
                if (Player == 2)
                {
                    Player = 1;
                    RivalDoPlayer = 2;
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
                        //case 14: //rei 
                            //MovimentosRei();
                            //break;
                        case 15: //rainha 
                            MovimentosRainha();
                            break;
                        case 16: //peão
                            MovimentosPeao();
                            break;
                    }
                    Player = 2;
                    RivalDoPlayer = 1;
                }


            }
            ChecandoSeReiNaoFicaEmXeque_NaoPodeColocar = false;
            ChecandoSeReiNaoFicaEmXeque = true;

            if (IDCDLOSCDREXRJ_RivalJogadas.ContainsValue(CasaOndeEstaOReiDoPlayer))
            {
                IDCDLOSCDREX_NaoPodeColocar.Add(Convert.ToString(ID_DA_CASA), ID_DA_CASA);
            }

            //restaura o backup.
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

            Selecionado_TabuleiroID = Backup_Selecionado_TabuleiroID;
            Selecionado_PessaValor = Backup_Selecionado_PessaValor;
            Selecionado_DirecaoDoPeaoValor = Backup_Selecionado_DirecaoDoPeaoValor;
            Selecionado_CorDaPessaValor = Backup_Selecionado_CorDaPessaValor;

            DefineAsColunasLinhasDiagonais(Backup_Selecionado_TabuleiroID);

        }


        public void ChecarSePodeFazerEnpassant(byte RivalPeao)
        { 
            if (Backup_Selecionado_DirecaoDoPeaoValor == 1)
            {
                if (Backup_Selecionado_TabuleiroID == 24
               || Backup_Selecionado_TabuleiroID == 25
               || Backup_Selecionado_TabuleiroID == 26
               || Backup_Selecionado_TabuleiroID == 27
               || Backup_Selecionado_TabuleiroID == 28
               || Backup_Selecionado_TabuleiroID == 29
               || Backup_Selecionado_TabuleiroID == 30
               || Backup_Selecionado_TabuleiroID == 31)
                {
                    DefineAsColunasLinhasDiagonais(Backup_Selecionado_TabuleiroID);
                    ChecarSePodeFazerMovimentosPeaoEnPassant(LinhaAdireitaDaPessa[0], DiagonalDireitaCimaDaPessa[0], RivalPeao);
                    DefineAsColunasLinhasDiagonais(Backup_Selecionado_TabuleiroID);
                    ChecarSePodeFazerMovimentosPeaoEnPassant(LinhaAesquerdaDaPessa[0], DiagonalEsquerdaCimaDaPessa[0], RivalPeao);

                }
            }
            if (Backup_Selecionado_DirecaoDoPeaoValor == 2)
            {
                if (Backup_Selecionado_TabuleiroID == 32
               || Backup_Selecionado_TabuleiroID == 33
               || Backup_Selecionado_TabuleiroID == 34
               || Backup_Selecionado_TabuleiroID == 35
               || Backup_Selecionado_TabuleiroID == 36
               || Backup_Selecionado_TabuleiroID == 37
               || Backup_Selecionado_TabuleiroID == 38
               || Backup_Selecionado_TabuleiroID == 39)
                {
                    DefineAsColunasLinhasDiagonais(Backup_Selecionado_TabuleiroID);
                    ChecarSePodeFazerMovimentosPeaoEnPassant(LinhaAdireitaDaPessa[0], DiagonalDireitaBaixoDaPessa[0], RivalPeao);
                    DefineAsColunasLinhasDiagonais(Backup_Selecionado_TabuleiroID);
                    ChecarSePodeFazerMovimentosPeaoEnPassant(LinhaAesquerdaDaPessa[0], DiagonalEsquerdaBaixoDaPessa[0], RivalPeao);

                }
            }
            if (Backup_Selecionado_DirecaoDoPeaoValor == 3)
            {
                if (Backup_Selecionado_TabuleiroID == 4
               || Backup_Selecionado_TabuleiroID == 12
               || Backup_Selecionado_TabuleiroID == 20
               || Backup_Selecionado_TabuleiroID == 28
               || Backup_Selecionado_TabuleiroID == 36
               || Backup_Selecionado_TabuleiroID == 44
               || Backup_Selecionado_TabuleiroID == 52
               || Backup_Selecionado_TabuleiroID == 60)
                {
                    DefineAsColunasLinhasDiagonais(Backup_Selecionado_TabuleiroID);
                    ChecarSePodeFazerMovimentosPeaoEnPassant(ColunaAbaixoDaPessa[0], DiagonalDireitaBaixoDaPessa[0], RivalPeao);
                    DefineAsColunasLinhasDiagonais(Backup_Selecionado_TabuleiroID);
                    ChecarSePodeFazerMovimentosPeaoEnPassant(ColunaAcimaDaPessa[0], DiagonalDireitaCimaDaPessa[0], RivalPeao);

                }
            }
            if (Backup_Selecionado_DirecaoDoPeaoValor == 4)
            {
                if (Backup_Selecionado_TabuleiroID == 3
                || Backup_Selecionado_TabuleiroID == 11
                || Backup_Selecionado_TabuleiroID == 19
                || Backup_Selecionado_TabuleiroID == 27
                || Backup_Selecionado_TabuleiroID == 35
                || Backup_Selecionado_TabuleiroID == 43
                || Backup_Selecionado_TabuleiroID == 51
                || Backup_Selecionado_TabuleiroID == 59)
                {
                    DefineAsColunasLinhasDiagonais(Backup_Selecionado_TabuleiroID);
                    ChecarSePodeFazerMovimentosPeaoEnPassant(ColunaAbaixoDaPessa[0], DiagonalEsquerdaBaixoDaPessa[0], RivalPeao);
                    DefineAsColunasLinhasDiagonais(Backup_Selecionado_TabuleiroID);
                    ChecarSePodeFazerMovimentosPeaoEnPassant(ColunaAcimaDaPessa[0], DiagonalEsquerdaCimaDaPessa[0], RivalPeao);

                }
            }


        }


        public void ChecarSePodeFazerMovimentosPeaoEnPassant(int ID_AO_LADO, int ID_NA_DIAGONAL, byte RivalPeao)
        {
            if (Pessa[ID_AO_LADO] == RivalPeao
                    && EmqualRodadaAPessaFoiMexida[ID_AO_LADO] > EmqualRodadaAPessaFoiMexida[Backup_Selecionado_TabuleiroID]
                    && PeaoAndouDuasCasas[ID_AO_LADO] == true
                    && CasaEstaOcupada[ID_NA_DIAGONAL] == false)
            {
  
                CasaEstaOcupada[ID_AO_LADO] = false;
                CorDaPessa[ID_AO_LADO] = 0;
                Pessa[ID_AO_LADO] = 0;
                DirecaoDoPeao[ID_AO_LADO] = 0;
                APessaJaFoiMovida[ID_AO_LADO] = false;
                EmqualRodadaAPessaFoiMexida[ID_AO_LADO] = 0;
                PeaoAndouDuasCasas[ID_AO_LADO] = false;

                IdentificandoOndeEstaoOsReis();

                NaoPodeDeixarReiEmChequePart2(ID_NA_DIAGONAL);

            }

        }



        //linha dos metodos
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Xadrez
{
    public partial class Form1 : Form

    {

        XadrezClass ImportandoXadrezClass = new XadrezClass();

        public bool TextoDasCasasColorido;

        public bool ColocarImagensNasCasas;

        public bool AutoConcluirJogadaOn;

        public bool MostrarPopupDasCasas;

        public bool VerInfoDeDebug;

        // carregar pra jogar 
        public bool CarregarPraJogar;

        // carregar pra editar
        public bool CarregarPraEditar;

        public Form1()
        {           
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
            // desabilitendo caixa de log
            textBoxLog.Hide();
            labelTraduz003.Hide();

            //
            Console.WriteLine("log: carregado Form1_Load");

            // coloca scroll no log
            textBoxLog.ScrollBars = ScrollBars.Both;
            textBoxLog.WordWrap = false;

            labelInfoRei.Text = "";
            ImportandoXadrezClass.labelInfoRei = "";
            ImportandoXadrezClass.IdNunericoParaNomeMetodo();
            ImportandoXadrezClass.DescricaoDosBotoesDebugMetodo();
            toolTipDescricaoDasCasas.SetToolTip(numericUpDownInfoDebug, ImportandoXadrezClass.DescricaoDosBotoesDebug[64]);

            // QUANDO ABRIR O PROGRAMA JA VAI TER UMA NOVA PARTIDA
            ImportandoXadrezClass.IniciandoNovaPartida();
            
            // colocar imagem, e nomes coloridos
            RenomearNomeDosBotoesDoTabuleiroSemTexto();
            MudarCorDoTextoDasCasasColorido();
            ComImagensNasCasas();

            TextoDasCasasColorido = true;
            oNOFFToolStripMenuItem.Text = "Colocar Texto Preto";

            ColocarImagensNasCasas = true;
            oNOFFToolStripMenuItem1.Text = "Colocar nomes nas casas";

            AutoConcluirJogadaOn = false;
            oNOFFToolStripMenuItem2.Text = "Ativar Função";

            MostrarPopupDasCasas = true;
            oNOFFToolStripMenuItem3.Text = "Desativar Popup";

            VerInfoDeDebug = false;
            oNOFFToolStripMenuItem4.Text = "Ativar Info De Debug";

            //Testar Tabuleiro(Debug)
            ImportandoXadrezClass.TestarTabuleiroDebug = false;
            oNOFFToolStripMenuItem5.Text = "Ativar Teste Do tabuleiro";
 
            ImportandoXadrezClass.DescricaoDosBotoesMetodo();
            DescricaoDosBotoes();

            DarClickNoBotaoInfo();

            // configurando combo box do peão

            comboBoxPeao.Items.Add("Rainha");
            comboBoxPeao.Items.Add("Torre");
            comboBoxPeao.Items.Add("Bispo");
            comboBoxPeao.Items.Add("Cavalo");
            comboBoxPeao.SelectedItem = "Rainha";
            //ImportandoXadrezClass.IdDaPessaQueOPeaoVaiVirar = Convert.ToByte(comboBoxPeao.SelectedIndex);
            ImportandoXadrezClass.IdDaPessaQueOPeaoVaiVirar = 0;


            panelJogoNormal.Show();
            panelModoEditar.Hide();
            panelModoEditar.Location = panelJogoNormal.Location;


            // config do  modo  editor

            ImportandoXadrezClass.ModoEditor = false;

            radioButton_Edit_Selecionar.Checked = true;
            ImportandoXadrezClass.ModoEditor_Selecionar = true;
            ImportandoXadrezClass.ModoEditor_Subistituir = false;

            comboBoxAPessaJaFoiMovida.Enabled = false;
            comboBoxDirecaoDoPeao.Enabled = false;
            comboBoxPeaoAndouDuasCasas.Enabled = false;
            comboBoxPessaEscolhida.Enabled = false;
            numericUpDownEmqualRodadaAPessaFoiMexida.Enabled = false;

            ImportandoXadrezClass.CasaEstaOcupadaValor = false;
            ImportandoXadrezClass.CorDaPessaValor = 0;
            ImportandoXadrezClass.PessaValor = 0;
            ImportandoXadrezClass.APessaJaFoiMovidaValor = false;
            ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor = 0;
            ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;
            ImportandoXadrezClass.DirecaoDoPeaoValor = 0;


            comboBoxPessaEscolhida.Items.Add("Vazio");
            comboBoxPessaEscolhida.Items.Add(ImportandoXadrezClass.NomePA);
            comboBoxPessaEscolhida.Items.Add(ImportandoXadrezClass.NomeTA);
            comboBoxPessaEscolhida.Items.Add(ImportandoXadrezClass.NomeCA);
            comboBoxPessaEscolhida.Items.Add(ImportandoXadrezClass.NomeBA);
            comboBoxPessaEscolhida.Items.Add(ImportandoXadrezClass.NomeREA);
            comboBoxPessaEscolhida.Items.Add(ImportandoXadrezClass.NomeRAA);
            comboBoxPessaEscolhida.Items.Add(ImportandoXadrezClass.NomePV);
            comboBoxPessaEscolhida.Items.Add(ImportandoXadrezClass.NomeTV);
            comboBoxPessaEscolhida.Items.Add(ImportandoXadrezClass.NomeCV);
            comboBoxPessaEscolhida.Items.Add(ImportandoXadrezClass.NomeBV);
            comboBoxPessaEscolhida.Items.Add(ImportandoXadrezClass.NomeREV);
            comboBoxPessaEscolhida.Items.Add(ImportandoXadrezClass.NomeRAV);
            comboBoxPessaEscolhida.SelectedItem = "Vazio";
            //ImportandoXadrezClass.ModoEditor_PessaASerColocada = comboBoxPessaEscolhida.SelectedIndex;

            comboBoxAPessaJaFoiMovida.Items.Add("False");
            comboBoxAPessaJaFoiMovida.Items.Add("True");
            comboBoxAPessaJaFoiMovida.SelectedItem = "False";
            //ImportandoXadrezClass.ModoEditor_APessaJaFoiMovida = comboBoxAPessaJaFoiMovida.SelectedIndex;

            comboBoxDirecaoDoPeao.Items.Add("Pra Cima");
            comboBoxDirecaoDoPeao.Items.Add("Pra Baixo");
            comboBoxDirecaoDoPeao.Items.Add("Pra Direita");
            comboBoxDirecaoDoPeao.Items.Add("Pra Esquerda");
            comboBoxDirecaoDoPeao.SelectedItem = "Pra Cima";
            //ImportandoXadrezClass.ModoEditor_DirecaoDoPeao = comboBoxDirecaoDoPeao.SelectedIndex;

            comboBoxPeaoAndouDuasCasas.Items.Add("False");
            comboBoxPeaoAndouDuasCasas.Items.Add("True");
            comboBoxPeaoAndouDuasCasas.SelectedItem = "False";
            //ImportandoXadrezClass.ModoEditor_PeaoAndouDuasCasas = comboBoxPeaoAndouDuasCasas.SelectedIndex;

            comboBoxPlayerAtual.Items.Add("Player Azul");
            comboBoxPlayerAtual.Items.Add("Player Verde");
            comboBoxPlayerAtual.SelectedItem = "Player Azul";
            //ImportandoXadrezClass.ModoEditor_Player = comboBoxPlayerAtual.SelectedIndex;
        }

        #region Casas Do Tabuleiro Click

        private void button1A_Click(object sender, EventArgs e)
        {
            int ID = 0;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button1B_Click(object sender, EventArgs e)
        {
            int ID = 1;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button1C_Click(object sender, EventArgs e)
        {
            int ID = 2;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button1D_Click(object sender, EventArgs e)
        {
            int ID = 3;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button1E_Click(object sender, EventArgs e)
        {
            int ID = 4;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button1F_Click(object sender, EventArgs e)
        {
            int ID = 5;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button1G_Click(object sender, EventArgs e)
        {
            int ID = 6;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button1H_Click(object sender, EventArgs e)
        {
            int ID = 7;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button2A_Click(object sender, EventArgs e)
        {
            int ID = 8;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button2B_Click(object sender, EventArgs e)
        {
            int ID = 9;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button2C_Click(object sender, EventArgs e)
        {
            int ID = 10;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button2D_Click(object sender, EventArgs e)
        {
            int ID = 11;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button2E_Click(object sender, EventArgs e)
        {
            int ID = 12;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button2F_Click(object sender, EventArgs e)
        {
            int ID = 13;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button2G_Click(object sender, EventArgs e)
        {
            int ID = 14;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button2H_Click(object sender, EventArgs e)
        {
            int ID = 15;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button3A_Click(object sender, EventArgs e)
        {
            int ID = 16;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button3B_Click(object sender, EventArgs e)
        {
            int ID = 17;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button3C_Click(object sender, EventArgs e)
        {
            int ID = 18;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button3D_Click(object sender, EventArgs e)
        {
            int ID = 19;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button3E_Click(object sender, EventArgs e)
        {
            int ID = 20;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button3F_Click(object sender, EventArgs e)
        {
            int ID = 21;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button3G_Click(object sender, EventArgs e)
        {
            int ID = 22;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button3H_Click(object sender, EventArgs e)
        {
            int ID = 23;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button4A_Click(object sender, EventArgs e)
        {
            int ID = 24;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button4B_Click(object sender, EventArgs e)
        {
            int ID = 25;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button4C_Click(object sender, EventArgs e)
        {
            int ID = 26;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button4D_Click(object sender, EventArgs e)
        {
            int ID = 27;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button4E_Click(object sender, EventArgs e)
        {
            int ID = 28;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button4F_Click(object sender, EventArgs e)
        {
            int ID = 29;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button4G_Click(object sender, EventArgs e)
        {
            int ID = 30;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button4H_Click(object sender, EventArgs e)
        {
            int ID = 31;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button5A_Click(object sender, EventArgs e)
        {
            int ID = 32;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button5B_Click(object sender, EventArgs e)
        {
            int ID = 33;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button5C_Click(object sender, EventArgs e)
        {
            int ID = 34;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button5D_Click(object sender, EventArgs e)
        {
            int ID = 35;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button5E_Click(object sender, EventArgs e)
        {
            int ID = 36;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button5F_Click(object sender, EventArgs e)
        {
            int ID = 37;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button5G_Click(object sender, EventArgs e)
        {
            int ID = 38;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button5H_Click(object sender, EventArgs e)
        {
            int ID = 39;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button6A_Click(object sender, EventArgs e)
        {
            int ID = 40;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button6B_Click(object sender, EventArgs e)
        {
            int ID = 41;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button6C_Click(object sender, EventArgs e)
        {
            int ID = 42;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button6D_Click(object sender, EventArgs e)
        {
            int ID = 43;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button6E_Click(object sender, EventArgs e)
        {
            int ID = 44;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button6F_Click(object sender, EventArgs e)
        {
            int ID = 45;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button6G_Click(object sender, EventArgs e)
        {
            int ID = 46;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button6H_Click(object sender, EventArgs e)
        {
            int ID = 47;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button7A_Click(object sender, EventArgs e)
        {
            int ID = 48;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button7B_Click(object sender, EventArgs e)
        {
            int ID = 49;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button7C_Click(object sender, EventArgs e)
        {
            int ID = 50;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);

        }

        private void button7D_Click(object sender, EventArgs e)
        {
            int ID = 51;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button7E_Click(object sender, EventArgs e)
        {
            int ID = 52;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button7F_Click(object sender, EventArgs e)
        {
            int ID = 53;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button7G_Click(object sender, EventArgs e)
        {
            int ID = 54;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button7H_Click(object sender, EventArgs e)
        {
            int ID = 55;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button8A_Click(object sender, EventArgs e)
        {
            int ID = 56;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button8B_Click(object sender, EventArgs e)
        {
            int ID = 57;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button8C_Click(object sender, EventArgs e)
        {
            int ID = 58;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);

        }

        private void button8D_Click(object sender, EventArgs e)
        {
            int ID = 59;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button8E_Click(object sender, EventArgs e)
        {
            int ID = 60;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button8F_Click(object sender, EventArgs e)
        {
            int ID = 61;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button8G_Click(object sender, EventArgs e)
        {
            int ID = 62;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        private void button8H_Click(object sender, EventArgs e)
        {

            int ID = 63;
            ImportandoXadrezClass.DarClickNaCasaDoTabuleiro(ID);
            DarClickNaCasaDoTabuleiroInfo(ID);
        }

        #endregion

        private void buttonConcluirJogada_Click(object sender, EventArgs e)
        {
            ImportandoXadrezClass.ConcluirJogada();
            DarClickNoBotaoInfo();
        }

        private void concluirJogadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportandoXadrezClass.ConcluirJogada();
            DarClickNoBotaoInfo();
        }

        private void novaPartidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportandoXadrezClass.IniciandoNovaPartida();
            textBoxLog.Text = "Iniciando novo jogo";
            ImportandoXadrezClass.Log = "";
            DarClickNoBotaoInfo();
            panelJogoNormal.Show();
            panelModoEditar.Hide();

            ImportandoXadrezClass.BotaoBloqueado = false;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // informações ao clicar em uma casa no tabuleiro
        public void DarClickNaCasaDoTabuleiroInfo(int ID_DA_CASA)
        {

            DarClickNoBotaoInfo();

            //Console.WriteLine("Log: Cliquei no botão: " + ID_DA_CASA);
            //Console.WriteLine("Log: CasaEstaOcupada[{0}]: {1}", ID_DA_CASA, Convert.ToString(ImportandoXadrezClass.CasaEstaOcupada[ID_DA_CASA]));
            //Console.WriteLine("Log: CorDaPessa[{0}]: {1}", ID_DA_CASA, Convert.ToString(ImportandoXadrezClass.CorDaPessa[ID_DA_CASA]));
            //Console.WriteLine("Log: Pessa[{0}]: {1}", ID_DA_CASA, Convert.ToString(ImportandoXadrezClass.Pessa[ID_DA_CASA]));
            //Console.WriteLine("Log: DirecaoDoPeao[{0}]: {1}", ID_DA_CASA, Convert.ToString(ImportandoXadrezClass.DirecaoDoPeao[ID_DA_CASA]));
            //Console.WriteLine("Log: APessaJaFoiMovida[{0}]: {1}", ID_DA_CASA, Convert.ToString(ImportandoXadrezClass.APessaJaFoiMovida[ID_DA_CASA]));
            //Console.WriteLine("Log: EmqualRodadaAPessaFoiMexida[{0}]: {1}", ID_DA_CASA, Convert.ToString(ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ID_DA_CASA]));
            //Console.WriteLine("Log: PeaoAndouDuasCasas[{0}]: {1}", ID_DA_CASA, Convert.ToString(ImportandoXadrezClass.PeaoAndouDuasCasas[ID_DA_CASA]));

            // info Environment.NewLine coloca nova linha

        }

        public void DarClickNoBotaoInfo()
        {

            if (ImportandoXadrezClass.ModoEditor == true)
            {
                comboBoxAPessaJaFoiMovida.Enabled = ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled;
                comboBoxDirecaoDoPeao.Enabled = ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled;
                comboBoxPeaoAndouDuasCasas.Enabled = ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled;
                comboBoxPessaEscolhida.Enabled = ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled;
                numericUpDownEmqualRodadaAPessaFoiMexida.Enabled = ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled;

                comboBoxAPessaJaFoiMovida.SelectedIndex = ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex;
                comboBoxDirecaoDoPeao.SelectedIndex = ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex;
                comboBoxPeaoAndouDuasCasas.SelectedIndex = ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasSelectedIndex;
                comboBoxPessaEscolhida.SelectedIndex = ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex;
                numericUpDownEmqualRodadaAPessaFoiMexida.Value = ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue;

                // PlayerAtual e Em
                comboBoxPlayerAtual.SelectedIndex = ImportandoXadrezClass.comboBoxPlayerAtualSelectedIndex;
                numericUpDownEmqualRodadaOplayerEstaJogando.Value = ImportandoXadrezClass.numericUpDownEmqualRodadaOplayerEstaJogandoValue;
            }


            if (ImportandoXadrezClass.Player == 1)
            {
                labelPlayerColor.Text = ImportandoXadrezClass.NomeAZUL;
                labelPlayerColor.ForeColor = ImportandoXadrezClass.CORES_AZUL;
            }
            if (ImportandoXadrezClass.Player == 2)
            {
                labelPlayerColor.Text = ImportandoXadrezClass.NomeVERDE;
                labelPlayerColor.ForeColor = ImportandoXadrezClass.CORES_VERDE;
            }

            if (TextoDasCasasColorido == true)
            {
                MudarCorDoTextoDasCasasColorido();
            }

            if (ColocarImagensNasCasas == true)
            {
                ComImagensNasCasas();
                RenomearNomeDosBotoesDoTabuleiroSemTexto();
            }
            else
            {
                RenomearNomeDosBotoesDoTabuleiro();
                SemImagensNasCasas();
            }

            textBoxLog.Text = textBoxLog.Text + Environment.NewLine + ImportandoXadrezClass.Log;
            labelInfoRei.Text = ImportandoXadrezClass.labelInfoRei;
            labelInfoRei.ForeColor = ImportandoXadrezClass.labelInfoReiColor;

            // mesagem para Xequemate
            if (ImportandoXadrezClass.mesagemBoxXequeMate == true)
            {
                string Vencedor = "";

                if (ImportandoXadrezClass.Player == 1)
                {
                    Vencedor = ImportandoXadrezClass.NomeAZUL;
                }
                if (ImportandoXadrezClass.Player == 2)
                {
                    Vencedor = ImportandoXadrezClass.NomeVERDE;
                }

                MessageBox.Show("Fim De Jogo, Jogador "+ Vencedor +  " Venceu", "Fim De Jogo");

                ImportandoXadrezClass.mesagemBoxXequeMate = false;

                //Console.WriteLine("IdDaCasaDaPessaQueAtacaOReiRival: " + ImportandoXadrezClass.IdDaCasaDaPessaQueAtacaOReiRival);
            }

            // mesagem de empate
            if (ImportandoXadrezClass.mesagemBoxEmpate == true)
            {
                MessageBox.Show("O Jogo Empatou", "Fim De Jogo");
                ImportandoXadrezClass.mesagemBoxEmpate = false;
            }



            if (VerInfoDeDebug == true)
            {
                ImportandoXadrezClass.DescricaoDosBotoesDebugMetodo();
                DescricaoDosBotoesDebug();
            }
            else
            {
                ImportandoXadrezClass.DescricaoDosBotoesMetodo();
                DescricaoDosBotoes();
            }

        }


        // casas tem nomes
        public void RenomearNomeDosBotoesDoTabuleiro()
        {
            button1A.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[0];
            button1B.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[1];
            button1C.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[2];
            button1D.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[3];
            button1E.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[4];
            button1F.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[5];
            button1G.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[6];
            button1H.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[7];
            button2A.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[8];
            button2B.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[9];
            button2C.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[10];
            button2D.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[11];
            button2E.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[12];
            button2F.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[13];
            button2G.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[14];
            button2H.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[15];
            button3A.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[16];
            button3B.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[17];
            button3C.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[18];
            button3D.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[19];
            button3E.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[20];
            button3F.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[21];
            button3G.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[22];
            button3H.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[23];
            button4A.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[24];
            button4B.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[25];
            button4C.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[26];
            button4D.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[27];
            button4E.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[28];
            button4F.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[29];
            button4G.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[30];
            button4H.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[31];
            button5A.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[32];
            button5B.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[33];
            button5C.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[34];
            button5D.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[35];
            button5E.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[36];
            button5F.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[37];
            button5G.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[38];
            button5H.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[39];
            button6A.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[40];
            button6B.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[41];
            button6C.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[42];
            button6D.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[43];
            button6E.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[44];
            button6F.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[45];
            button6G.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[46];
            button6H.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[47];
            button7A.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[48];
            button7B.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[49];
            button7C.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[50];
            button7D.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[51];
            button7E.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[52];
            button7F.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[53];
            button7G.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[54];
            button7H.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[55];
            button8A.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[56];
            button8B.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[57];
            button8C.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[58];
            button8D.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[59];
            button8E.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[60];
            button8F.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[61];
            button8G.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[62];
            button8H.Text = ImportandoXadrezClass.NomesNosBotoesDotabuleiro[63];
        }

        // casas tem nome em branco
        public void RenomearNomeDosBotoesDoTabuleiroSemTexto()
        {
            button1A.Text = ImportandoXadrezClass.NomeEmBranco;
            button1B.Text = ImportandoXadrezClass.NomeEmBranco;
            button1C.Text = ImportandoXadrezClass.NomeEmBranco;
            button1D.Text = ImportandoXadrezClass.NomeEmBranco;
            button1E.Text = ImportandoXadrezClass.NomeEmBranco;
            button1F.Text = ImportandoXadrezClass.NomeEmBranco;
            button1G.Text = ImportandoXadrezClass.NomeEmBranco;
            button1H.Text = ImportandoXadrezClass.NomeEmBranco;
            button2A.Text = ImportandoXadrezClass.NomeEmBranco;
            button2B.Text = ImportandoXadrezClass.NomeEmBranco;
            button2C.Text = ImportandoXadrezClass.NomeEmBranco;
            button2D.Text = ImportandoXadrezClass.NomeEmBranco;
            button2E.Text = ImportandoXadrezClass.NomeEmBranco;
            button2F.Text = ImportandoXadrezClass.NomeEmBranco;
            button2G.Text = ImportandoXadrezClass.NomeEmBranco;
            button2H.Text = ImportandoXadrezClass.NomeEmBranco;
            button3A.Text = ImportandoXadrezClass.NomeEmBranco;
            button3B.Text = ImportandoXadrezClass.NomeEmBranco;
            button3C.Text = ImportandoXadrezClass.NomeEmBranco;
            button3D.Text = ImportandoXadrezClass.NomeEmBranco;
            button3E.Text = ImportandoXadrezClass.NomeEmBranco;
            button3F.Text = ImportandoXadrezClass.NomeEmBranco;
            button3G.Text = ImportandoXadrezClass.NomeEmBranco;
            button3H.Text = ImportandoXadrezClass.NomeEmBranco;
            button4A.Text = ImportandoXadrezClass.NomeEmBranco;
            button4B.Text = ImportandoXadrezClass.NomeEmBranco;
            button4C.Text = ImportandoXadrezClass.NomeEmBranco;
            button4D.Text = ImportandoXadrezClass.NomeEmBranco;
            button4E.Text = ImportandoXadrezClass.NomeEmBranco;
            button4F.Text = ImportandoXadrezClass.NomeEmBranco;
            button4G.Text = ImportandoXadrezClass.NomeEmBranco;
            button4H.Text = ImportandoXadrezClass.NomeEmBranco;
            button5A.Text = ImportandoXadrezClass.NomeEmBranco;
            button5B.Text = ImportandoXadrezClass.NomeEmBranco;
            button5C.Text = ImportandoXadrezClass.NomeEmBranco;
            button5D.Text = ImportandoXadrezClass.NomeEmBranco;
            button5E.Text = ImportandoXadrezClass.NomeEmBranco;
            button5F.Text = ImportandoXadrezClass.NomeEmBranco;
            button5G.Text = ImportandoXadrezClass.NomeEmBranco;
            button5H.Text = ImportandoXadrezClass.NomeEmBranco;
            button6A.Text = ImportandoXadrezClass.NomeEmBranco;
            button6B.Text = ImportandoXadrezClass.NomeEmBranco;
            button6C.Text = ImportandoXadrezClass.NomeEmBranco;
            button6D.Text = ImportandoXadrezClass.NomeEmBranco;
            button6E.Text = ImportandoXadrezClass.NomeEmBranco;
            button6F.Text = ImportandoXadrezClass.NomeEmBranco;
            button6G.Text = ImportandoXadrezClass.NomeEmBranco;
            button6H.Text = ImportandoXadrezClass.NomeEmBranco;
            button7A.Text = ImportandoXadrezClass.NomeEmBranco;
            button7B.Text = ImportandoXadrezClass.NomeEmBranco;
            button7C.Text = ImportandoXadrezClass.NomeEmBranco;
            button7D.Text = ImportandoXadrezClass.NomeEmBranco;
            button7E.Text = ImportandoXadrezClass.NomeEmBranco;
            button7F.Text = ImportandoXadrezClass.NomeEmBranco;
            button7G.Text = ImportandoXadrezClass.NomeEmBranco;
            button7H.Text = ImportandoXadrezClass.NomeEmBranco;
            button8A.Text = ImportandoXadrezClass.NomeEmBranco;
            button8B.Text = ImportandoXadrezClass.NomeEmBranco;
            button8C.Text = ImportandoXadrezClass.NomeEmBranco;
            button8D.Text = ImportandoXadrezClass.NomeEmBranco;
            button8E.Text = ImportandoXadrezClass.NomeEmBranco;
            button8F.Text = ImportandoXadrezClass.NomeEmBranco;
            button8G.Text = ImportandoXadrezClass.NomeEmBranco;
            button8H.Text = ImportandoXadrezClass.NomeEmBranco;
        }

        // texto das casas colorido
        public void MudarCorDoTextoDasCasasColorido()
        {
            button1A.ForeColor = ImportandoXadrezClass.CORESNASCASAS[0];
            button1B.ForeColor = ImportandoXadrezClass.CORESNASCASAS[1];
            button1C.ForeColor = ImportandoXadrezClass.CORESNASCASAS[2];
            button1D.ForeColor = ImportandoXadrezClass.CORESNASCASAS[3];
            button1E.ForeColor = ImportandoXadrezClass.CORESNASCASAS[4];
            button1F.ForeColor = ImportandoXadrezClass.CORESNASCASAS[5];
            button1G.ForeColor = ImportandoXadrezClass.CORESNASCASAS[6];
            button1H.ForeColor = ImportandoXadrezClass.CORESNASCASAS[7];
            button2A.ForeColor = ImportandoXadrezClass.CORESNASCASAS[8];
            button2B.ForeColor = ImportandoXadrezClass.CORESNASCASAS[9];
            button2C.ForeColor = ImportandoXadrezClass.CORESNASCASAS[10];
            button2D.ForeColor = ImportandoXadrezClass.CORESNASCASAS[11];
            button2E.ForeColor = ImportandoXadrezClass.CORESNASCASAS[12];
            button2F.ForeColor = ImportandoXadrezClass.CORESNASCASAS[13];
            button2G.ForeColor = ImportandoXadrezClass.CORESNASCASAS[14];
            button2H.ForeColor = ImportandoXadrezClass.CORESNASCASAS[15];
            button3A.ForeColor = ImportandoXadrezClass.CORESNASCASAS[16];
            button3B.ForeColor = ImportandoXadrezClass.CORESNASCASAS[17];
            button3C.ForeColor = ImportandoXadrezClass.CORESNASCASAS[18];
            button3D.ForeColor = ImportandoXadrezClass.CORESNASCASAS[19];
            button3E.ForeColor = ImportandoXadrezClass.CORESNASCASAS[20];
            button3F.ForeColor = ImportandoXadrezClass.CORESNASCASAS[21];
            button3G.ForeColor = ImportandoXadrezClass.CORESNASCASAS[22];
            button3H.ForeColor = ImportandoXadrezClass.CORESNASCASAS[23];
            button4A.ForeColor = ImportandoXadrezClass.CORESNASCASAS[24];
            button4B.ForeColor = ImportandoXadrezClass.CORESNASCASAS[25];
            button4C.ForeColor = ImportandoXadrezClass.CORESNASCASAS[26];
            button4D.ForeColor = ImportandoXadrezClass.CORESNASCASAS[27];
            button4E.ForeColor = ImportandoXadrezClass.CORESNASCASAS[28];
            button4F.ForeColor = ImportandoXadrezClass.CORESNASCASAS[29];
            button4G.ForeColor = ImportandoXadrezClass.CORESNASCASAS[30];
            button4H.ForeColor = ImportandoXadrezClass.CORESNASCASAS[31];
            button5A.ForeColor = ImportandoXadrezClass.CORESNASCASAS[32];
            button5B.ForeColor = ImportandoXadrezClass.CORESNASCASAS[33];
            button5C.ForeColor = ImportandoXadrezClass.CORESNASCASAS[34];
            button5D.ForeColor = ImportandoXadrezClass.CORESNASCASAS[35];
            button5E.ForeColor = ImportandoXadrezClass.CORESNASCASAS[36];
            button5F.ForeColor = ImportandoXadrezClass.CORESNASCASAS[37];
            button5G.ForeColor = ImportandoXadrezClass.CORESNASCASAS[38];
            button5H.ForeColor = ImportandoXadrezClass.CORESNASCASAS[39];
            button6A.ForeColor = ImportandoXadrezClass.CORESNASCASAS[40];
            button6B.ForeColor = ImportandoXadrezClass.CORESNASCASAS[41];
            button6C.ForeColor = ImportandoXadrezClass.CORESNASCASAS[42];
            button6D.ForeColor = ImportandoXadrezClass.CORESNASCASAS[43];
            button6E.ForeColor = ImportandoXadrezClass.CORESNASCASAS[44];
            button6F.ForeColor = ImportandoXadrezClass.CORESNASCASAS[45];
            button6G.ForeColor = ImportandoXadrezClass.CORESNASCASAS[46];
            button6H.ForeColor = ImportandoXadrezClass.CORESNASCASAS[47];
            button7A.ForeColor = ImportandoXadrezClass.CORESNASCASAS[48];
            button7B.ForeColor = ImportandoXadrezClass.CORESNASCASAS[49];
            button7C.ForeColor = ImportandoXadrezClass.CORESNASCASAS[50];
            button7D.ForeColor = ImportandoXadrezClass.CORESNASCASAS[51];
            button7E.ForeColor = ImportandoXadrezClass.CORESNASCASAS[52];
            button7F.ForeColor = ImportandoXadrezClass.CORESNASCASAS[53];
            button7G.ForeColor = ImportandoXadrezClass.CORESNASCASAS[54];
            button7H.ForeColor = ImportandoXadrezClass.CORESNASCASAS[55];
            button8A.ForeColor = ImportandoXadrezClass.CORESNASCASAS[56];
            button8B.ForeColor = ImportandoXadrezClass.CORESNASCASAS[57];
            button8C.ForeColor = ImportandoXadrezClass.CORESNASCASAS[58];
            button8D.ForeColor = ImportandoXadrezClass.CORESNASCASAS[59];
            button8E.ForeColor = ImportandoXadrezClass.CORESNASCASAS[60];
            button8F.ForeColor = ImportandoXadrezClass.CORESNASCASAS[61];
            button8G.ForeColor = ImportandoXadrezClass.CORESNASCASAS[62];
            button8H.ForeColor = ImportandoXadrezClass.CORESNASCASAS[63];
        }

        // texto das casas preto
        public void MudarCorDoTextoDasCasasPreto()
        {
            button1A.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button1B.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button1C.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button1D.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button1E.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button1F.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button1G.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button1H.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button2A.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button2B.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button2C.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button2D.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button2E.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button2F.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button2G.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button2H.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button3A.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button3B.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button3C.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button3D.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button3E.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button3F.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button3G.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button3H.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button4A.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button4B.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button4C.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button4D.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button4E.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button4F.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button4G.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button4H.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button5A.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button5B.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button5C.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button5D.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button5E.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button5F.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button5G.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button5H.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button6A.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button6B.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button6C.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button6D.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button6E.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button6F.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button6G.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button6H.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button7A.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button7B.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button7C.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button7D.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button7E.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button7F.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button7G.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button7H.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button8A.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button8B.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button8C.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button8D.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button8E.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button8F.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button8G.ForeColor = ImportandoXadrezClass.CORES_PRETO;
            button8H.ForeColor = ImportandoXadrezClass.CORES_PRETO;
        }

        // coloca imagens nas casas
        public void ComImagensNasCasas()
        {
            button1A.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[0];
            button1B.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[1];
            button1C.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[2];
            button1D.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[3];
            button1E.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[4];
            button1F.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[5];
            button1G.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[6];
            button1H.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[7];
            button2A.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[8];
            button2B.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[9];
            button2C.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[10];
            button2D.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[11];
            button2E.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[12];
            button2F.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[13];
            button2G.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[14];
            button2H.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[15];
            button3A.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[16];
            button3B.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[17];
            button3C.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[18];
            button3D.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[19];
            button3E.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[20];
            button3F.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[21];
            button3G.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[22];
            button3H.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[23];
            button4A.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[24];
            button4B.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[25];
            button4C.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[26];
            button4D.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[27];
            button4E.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[28];
            button4F.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[29];
            button4G.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[30];
            button4H.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[31];
            button5A.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[32];
            button5B.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[33];
            button5C.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[34];
            button5D.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[35];
            button5E.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[36];
            button5F.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[37];
            button5G.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[38];
            button5H.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[39];
            button6A.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[40];
            button6B.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[41];
            button6C.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[42];
            button6D.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[43];
            button6E.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[44];
            button6F.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[45];
            button6G.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[46];
            button6H.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[47];
            button7A.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[48];
            button7B.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[49];
            button7C.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[50];
            button7D.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[51];
            button7E.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[52];
            button7F.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[53];
            button7G.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[54];
            button7H.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[55];
            button8A.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[56];
            button8B.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[57];
            button8C.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[58];
            button8D.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[59];
            button8E.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[60];
            button8F.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[61];
            button8G.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[62];
            button8H.BackgroundImage = ImportandoXadrezClass.ImagemNasCasasL1[63];
            button1A.Image = ImportandoXadrezClass.ImagemNasCasasL2[0];
            button1B.Image = ImportandoXadrezClass.ImagemNasCasasL2[1];
            button1C.Image = ImportandoXadrezClass.ImagemNasCasasL2[2];
            button1D.Image = ImportandoXadrezClass.ImagemNasCasasL2[3];
            button1E.Image = ImportandoXadrezClass.ImagemNasCasasL2[4];
            button1F.Image = ImportandoXadrezClass.ImagemNasCasasL2[5];
            button1G.Image = ImportandoXadrezClass.ImagemNasCasasL2[6];
            button1H.Image = ImportandoXadrezClass.ImagemNasCasasL2[7];
            button2A.Image = ImportandoXadrezClass.ImagemNasCasasL2[8];
            button2B.Image = ImportandoXadrezClass.ImagemNasCasasL2[9];
            button2C.Image = ImportandoXadrezClass.ImagemNasCasasL2[10];
            button2D.Image = ImportandoXadrezClass.ImagemNasCasasL2[11];
            button2E.Image = ImportandoXadrezClass.ImagemNasCasasL2[12];
            button2F.Image = ImportandoXadrezClass.ImagemNasCasasL2[13];
            button2G.Image = ImportandoXadrezClass.ImagemNasCasasL2[14];
            button2H.Image = ImportandoXadrezClass.ImagemNasCasasL2[15];
            button3A.Image = ImportandoXadrezClass.ImagemNasCasasL2[16];
            button3B.Image = ImportandoXadrezClass.ImagemNasCasasL2[17];
            button3C.Image = ImportandoXadrezClass.ImagemNasCasasL2[18];
            button3D.Image = ImportandoXadrezClass.ImagemNasCasasL2[19];
            button3E.Image = ImportandoXadrezClass.ImagemNasCasasL2[20];
            button3F.Image = ImportandoXadrezClass.ImagemNasCasasL2[21];
            button3G.Image = ImportandoXadrezClass.ImagemNasCasasL2[22];
            button3H.Image = ImportandoXadrezClass.ImagemNasCasasL2[23];
            button4A.Image = ImportandoXadrezClass.ImagemNasCasasL2[24];
            button4B.Image = ImportandoXadrezClass.ImagemNasCasasL2[25];
            button4C.Image = ImportandoXadrezClass.ImagemNasCasasL2[26];
            button4D.Image = ImportandoXadrezClass.ImagemNasCasasL2[27];
            button4E.Image = ImportandoXadrezClass.ImagemNasCasasL2[28];
            button4F.Image = ImportandoXadrezClass.ImagemNasCasasL2[29];
            button4G.Image = ImportandoXadrezClass.ImagemNasCasasL2[30];
            button4H.Image = ImportandoXadrezClass.ImagemNasCasasL2[31];
            button5A.Image = ImportandoXadrezClass.ImagemNasCasasL2[32];
            button5B.Image = ImportandoXadrezClass.ImagemNasCasasL2[33];
            button5C.Image = ImportandoXadrezClass.ImagemNasCasasL2[34];
            button5D.Image = ImportandoXadrezClass.ImagemNasCasasL2[35];
            button5E.Image = ImportandoXadrezClass.ImagemNasCasasL2[36];
            button5F.Image = ImportandoXadrezClass.ImagemNasCasasL2[37];
            button5G.Image = ImportandoXadrezClass.ImagemNasCasasL2[38];
            button5H.Image = ImportandoXadrezClass.ImagemNasCasasL2[39];
            button6A.Image = ImportandoXadrezClass.ImagemNasCasasL2[40];
            button6B.Image = ImportandoXadrezClass.ImagemNasCasasL2[41];
            button6C.Image = ImportandoXadrezClass.ImagemNasCasasL2[42];
            button6D.Image = ImportandoXadrezClass.ImagemNasCasasL2[43];
            button6E.Image = ImportandoXadrezClass.ImagemNasCasasL2[44];
            button6F.Image = ImportandoXadrezClass.ImagemNasCasasL2[45];
            button6G.Image = ImportandoXadrezClass.ImagemNasCasasL2[46];
            button6H.Image = ImportandoXadrezClass.ImagemNasCasasL2[47];
            button7A.Image = ImportandoXadrezClass.ImagemNasCasasL2[48];
            button7B.Image = ImportandoXadrezClass.ImagemNasCasasL2[49];
            button7C.Image = ImportandoXadrezClass.ImagemNasCasasL2[50];
            button7D.Image = ImportandoXadrezClass.ImagemNasCasasL2[51];
            button7E.Image = ImportandoXadrezClass.ImagemNasCasasL2[52];
            button7F.Image = ImportandoXadrezClass.ImagemNasCasasL2[53];
            button7G.Image = ImportandoXadrezClass.ImagemNasCasasL2[54];
            button7H.Image = ImportandoXadrezClass.ImagemNasCasasL2[55];
            button8A.Image = ImportandoXadrezClass.ImagemNasCasasL2[56];
            button8B.Image = ImportandoXadrezClass.ImagemNasCasasL2[57];
            button8C.Image = ImportandoXadrezClass.ImagemNasCasasL2[58];
            button8D.Image = ImportandoXadrezClass.ImagemNasCasasL2[59];
            button8E.Image = ImportandoXadrezClass.ImagemNasCasasL2[60];
            button8F.Image = ImportandoXadrezClass.ImagemNasCasasL2[61];
            button8G.Image = ImportandoXadrezClass.ImagemNasCasasL2[62];
            button8H.Image = ImportandoXadrezClass.ImagemNasCasasL2[63];
        }

        // sem imagem nas casas
        public void SemImagensNasCasas()
        {
            button1A.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button1B.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button1C.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button1D.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button1E.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button1F.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button1G.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button1H.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button2A.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button2B.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button2C.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button2D.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button2E.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button2F.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button2G.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button2H.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button3A.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button3B.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button3C.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button3D.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button3E.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button3F.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button3G.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button3H.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button4A.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button4B.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button4C.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button4D.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button4E.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button4F.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button4G.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button4H.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button5A.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button5B.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button5C.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button5D.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button5E.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button5F.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button5G.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button5H.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button6A.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button6B.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button6C.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button6D.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button6E.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button6F.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button6G.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button6H.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button7A.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button7B.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button7C.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button7D.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button7E.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button7F.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button7G.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button7H.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button8A.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button8B.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button8C.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button8D.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button8E.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button8F.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button8G.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button8H.BackgroundImage = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button1A.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button1B.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button1C.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button1D.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button1E.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button1F.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button1G.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button1H.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button2A.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button2B.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button2C.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button2D.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button2E.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button2F.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button2G.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button2H.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button3A.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button3B.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button3C.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button3D.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button3E.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button3F.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button3G.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button3H.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button4A.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button4B.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button4C.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button4D.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button4E.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button4F.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button4G.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button4H.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button5A.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button5B.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button5C.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button5D.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button5E.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button5F.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button5G.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button5H.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button6A.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button6B.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button6C.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button6D.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button6E.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button6F.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button6G.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button6H.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button7A.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button7B.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button7C.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button7D.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button7E.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button7F.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button7G.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button7H.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button8A.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button8B.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button8C.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button8D.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button8E.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button8F.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button8G.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
            button8H.Image = ImportandoXadrezClass.IMAGEM_TRASPARENTE;
        }


        // coloca descrição nos botoes. 
        public void DescricaoDosBotoes()
        {
            toolTipDescricaoDasCasas.SetToolTip(button1A, ImportandoXadrezClass.DescricaoDosBotoes[0]);
            toolTipDescricaoDasCasas.SetToolTip(button1B, ImportandoXadrezClass.DescricaoDosBotoes[1]);
            toolTipDescricaoDasCasas.SetToolTip(button1C, ImportandoXadrezClass.DescricaoDosBotoes[2]);
            toolTipDescricaoDasCasas.SetToolTip(button1D, ImportandoXadrezClass.DescricaoDosBotoes[3]);
            toolTipDescricaoDasCasas.SetToolTip(button1E, ImportandoXadrezClass.DescricaoDosBotoes[4]);
            toolTipDescricaoDasCasas.SetToolTip(button1F, ImportandoXadrezClass.DescricaoDosBotoes[5]);
            toolTipDescricaoDasCasas.SetToolTip(button1G, ImportandoXadrezClass.DescricaoDosBotoes[6]);
            toolTipDescricaoDasCasas.SetToolTip(button1H, ImportandoXadrezClass.DescricaoDosBotoes[7]);
            toolTipDescricaoDasCasas.SetToolTip(button2A, ImportandoXadrezClass.DescricaoDosBotoes[8]);
            toolTipDescricaoDasCasas.SetToolTip(button2B, ImportandoXadrezClass.DescricaoDosBotoes[9]);
            toolTipDescricaoDasCasas.SetToolTip(button2C, ImportandoXadrezClass.DescricaoDosBotoes[10]);
            toolTipDescricaoDasCasas.SetToolTip(button2D, ImportandoXadrezClass.DescricaoDosBotoes[11]);
            toolTipDescricaoDasCasas.SetToolTip(button2E, ImportandoXadrezClass.DescricaoDosBotoes[12]);
            toolTipDescricaoDasCasas.SetToolTip(button2F, ImportandoXadrezClass.DescricaoDosBotoes[13]);
            toolTipDescricaoDasCasas.SetToolTip(button2G, ImportandoXadrezClass.DescricaoDosBotoes[14]);
            toolTipDescricaoDasCasas.SetToolTip(button2H, ImportandoXadrezClass.DescricaoDosBotoes[15]);
            toolTipDescricaoDasCasas.SetToolTip(button3A, ImportandoXadrezClass.DescricaoDosBotoes[16]);
            toolTipDescricaoDasCasas.SetToolTip(button3B, ImportandoXadrezClass.DescricaoDosBotoes[17]);
            toolTipDescricaoDasCasas.SetToolTip(button3C, ImportandoXadrezClass.DescricaoDosBotoes[18]);
            toolTipDescricaoDasCasas.SetToolTip(button3D, ImportandoXadrezClass.DescricaoDosBotoes[19]);
            toolTipDescricaoDasCasas.SetToolTip(button3E, ImportandoXadrezClass.DescricaoDosBotoes[20]);
            toolTipDescricaoDasCasas.SetToolTip(button3F, ImportandoXadrezClass.DescricaoDosBotoes[21]);
            toolTipDescricaoDasCasas.SetToolTip(button3G, ImportandoXadrezClass.DescricaoDosBotoes[22]);
            toolTipDescricaoDasCasas.SetToolTip(button3H, ImportandoXadrezClass.DescricaoDosBotoes[23]);
            toolTipDescricaoDasCasas.SetToolTip(button4A, ImportandoXadrezClass.DescricaoDosBotoes[24]);
            toolTipDescricaoDasCasas.SetToolTip(button4B, ImportandoXadrezClass.DescricaoDosBotoes[25]);
            toolTipDescricaoDasCasas.SetToolTip(button4C, ImportandoXadrezClass.DescricaoDosBotoes[26]);
            toolTipDescricaoDasCasas.SetToolTip(button4D, ImportandoXadrezClass.DescricaoDosBotoes[27]);
            toolTipDescricaoDasCasas.SetToolTip(button4E, ImportandoXadrezClass.DescricaoDosBotoes[28]);
            toolTipDescricaoDasCasas.SetToolTip(button4F, ImportandoXadrezClass.DescricaoDosBotoes[29]);
            toolTipDescricaoDasCasas.SetToolTip(button4G, ImportandoXadrezClass.DescricaoDosBotoes[30]);
            toolTipDescricaoDasCasas.SetToolTip(button4H, ImportandoXadrezClass.DescricaoDosBotoes[31]);
            toolTipDescricaoDasCasas.SetToolTip(button5A, ImportandoXadrezClass.DescricaoDosBotoes[32]);
            toolTipDescricaoDasCasas.SetToolTip(button5B, ImportandoXadrezClass.DescricaoDosBotoes[33]);
            toolTipDescricaoDasCasas.SetToolTip(button5C, ImportandoXadrezClass.DescricaoDosBotoes[34]);
            toolTipDescricaoDasCasas.SetToolTip(button5D, ImportandoXadrezClass.DescricaoDosBotoes[35]);
            toolTipDescricaoDasCasas.SetToolTip(button5E, ImportandoXadrezClass.DescricaoDosBotoes[36]);
            toolTipDescricaoDasCasas.SetToolTip(button5F, ImportandoXadrezClass.DescricaoDosBotoes[37]);
            toolTipDescricaoDasCasas.SetToolTip(button5G, ImportandoXadrezClass.DescricaoDosBotoes[38]);
            toolTipDescricaoDasCasas.SetToolTip(button5H, ImportandoXadrezClass.DescricaoDosBotoes[39]);
            toolTipDescricaoDasCasas.SetToolTip(button6A, ImportandoXadrezClass.DescricaoDosBotoes[40]);
            toolTipDescricaoDasCasas.SetToolTip(button6B, ImportandoXadrezClass.DescricaoDosBotoes[41]);
            toolTipDescricaoDasCasas.SetToolTip(button6C, ImportandoXadrezClass.DescricaoDosBotoes[42]);
            toolTipDescricaoDasCasas.SetToolTip(button6D, ImportandoXadrezClass.DescricaoDosBotoes[43]);
            toolTipDescricaoDasCasas.SetToolTip(button6E, ImportandoXadrezClass.DescricaoDosBotoes[44]);
            toolTipDescricaoDasCasas.SetToolTip(button6F, ImportandoXadrezClass.DescricaoDosBotoes[45]);
            toolTipDescricaoDasCasas.SetToolTip(button6G, ImportandoXadrezClass.DescricaoDosBotoes[46]);
            toolTipDescricaoDasCasas.SetToolTip(button6H, ImportandoXadrezClass.DescricaoDosBotoes[47]);
            toolTipDescricaoDasCasas.SetToolTip(button7A, ImportandoXadrezClass.DescricaoDosBotoes[48]);
            toolTipDescricaoDasCasas.SetToolTip(button7B, ImportandoXadrezClass.DescricaoDosBotoes[49]);
            toolTipDescricaoDasCasas.SetToolTip(button7C, ImportandoXadrezClass.DescricaoDosBotoes[50]);
            toolTipDescricaoDasCasas.SetToolTip(button7D, ImportandoXadrezClass.DescricaoDosBotoes[51]);
            toolTipDescricaoDasCasas.SetToolTip(button7E, ImportandoXadrezClass.DescricaoDosBotoes[52]);
            toolTipDescricaoDasCasas.SetToolTip(button7F, ImportandoXadrezClass.DescricaoDosBotoes[53]);
            toolTipDescricaoDasCasas.SetToolTip(button7G, ImportandoXadrezClass.DescricaoDosBotoes[54]);
            toolTipDescricaoDasCasas.SetToolTip(button7H, ImportandoXadrezClass.DescricaoDosBotoes[55]);
            toolTipDescricaoDasCasas.SetToolTip(button8A, ImportandoXadrezClass.DescricaoDosBotoes[56]);
            toolTipDescricaoDasCasas.SetToolTip(button8B, ImportandoXadrezClass.DescricaoDosBotoes[57]);
            toolTipDescricaoDasCasas.SetToolTip(button8C, ImportandoXadrezClass.DescricaoDosBotoes[58]);
            toolTipDescricaoDasCasas.SetToolTip(button8D, ImportandoXadrezClass.DescricaoDosBotoes[59]);
            toolTipDescricaoDasCasas.SetToolTip(button8E, ImportandoXadrezClass.DescricaoDosBotoes[60]);
            toolTipDescricaoDasCasas.SetToolTip(button8F, ImportandoXadrezClass.DescricaoDosBotoes[61]);
            toolTipDescricaoDasCasas.SetToolTip(button8G, ImportandoXadrezClass.DescricaoDosBotoes[62]);
            toolTipDescricaoDasCasas.SetToolTip(button8H, ImportandoXadrezClass.DescricaoDosBotoes[63]);
        }


        // descrição dos botoes mostra debug
        public void DescricaoDosBotoesDebug()
        {
            toolTipDescricaoDasCasas.SetToolTip(button1A, ImportandoXadrezClass.DescricaoDosBotoesDebug[0]);
            toolTipDescricaoDasCasas.SetToolTip(button1B, ImportandoXadrezClass.DescricaoDosBotoesDebug[1]);
            toolTipDescricaoDasCasas.SetToolTip(button1C, ImportandoXadrezClass.DescricaoDosBotoesDebug[2]);
            toolTipDescricaoDasCasas.SetToolTip(button1D, ImportandoXadrezClass.DescricaoDosBotoesDebug[3]);
            toolTipDescricaoDasCasas.SetToolTip(button1E, ImportandoXadrezClass.DescricaoDosBotoesDebug[4]);
            toolTipDescricaoDasCasas.SetToolTip(button1F, ImportandoXadrezClass.DescricaoDosBotoesDebug[5]);
            toolTipDescricaoDasCasas.SetToolTip(button1G, ImportandoXadrezClass.DescricaoDosBotoesDebug[6]);
            toolTipDescricaoDasCasas.SetToolTip(button1H, ImportandoXadrezClass.DescricaoDosBotoesDebug[7]);
            toolTipDescricaoDasCasas.SetToolTip(button2A, ImportandoXadrezClass.DescricaoDosBotoesDebug[8]);
            toolTipDescricaoDasCasas.SetToolTip(button2B, ImportandoXadrezClass.DescricaoDosBotoesDebug[9]);
            toolTipDescricaoDasCasas.SetToolTip(button2C, ImportandoXadrezClass.DescricaoDosBotoesDebug[10]);
            toolTipDescricaoDasCasas.SetToolTip(button2D, ImportandoXadrezClass.DescricaoDosBotoesDebug[11]);
            toolTipDescricaoDasCasas.SetToolTip(button2E, ImportandoXadrezClass.DescricaoDosBotoesDebug[12]);
            toolTipDescricaoDasCasas.SetToolTip(button2F, ImportandoXadrezClass.DescricaoDosBotoesDebug[13]);
            toolTipDescricaoDasCasas.SetToolTip(button2G, ImportandoXadrezClass.DescricaoDosBotoesDebug[14]);
            toolTipDescricaoDasCasas.SetToolTip(button2H, ImportandoXadrezClass.DescricaoDosBotoesDebug[15]);
            toolTipDescricaoDasCasas.SetToolTip(button3A, ImportandoXadrezClass.DescricaoDosBotoesDebug[16]);
            toolTipDescricaoDasCasas.SetToolTip(button3B, ImportandoXadrezClass.DescricaoDosBotoesDebug[17]);
            toolTipDescricaoDasCasas.SetToolTip(button3C, ImportandoXadrezClass.DescricaoDosBotoesDebug[18]);
            toolTipDescricaoDasCasas.SetToolTip(button3D, ImportandoXadrezClass.DescricaoDosBotoesDebug[19]);
            toolTipDescricaoDasCasas.SetToolTip(button3E, ImportandoXadrezClass.DescricaoDosBotoesDebug[20]);
            toolTipDescricaoDasCasas.SetToolTip(button3F, ImportandoXadrezClass.DescricaoDosBotoesDebug[21]);
            toolTipDescricaoDasCasas.SetToolTip(button3G, ImportandoXadrezClass.DescricaoDosBotoesDebug[22]);
            toolTipDescricaoDasCasas.SetToolTip(button3H, ImportandoXadrezClass.DescricaoDosBotoesDebug[23]);
            toolTipDescricaoDasCasas.SetToolTip(button4A, ImportandoXadrezClass.DescricaoDosBotoesDebug[24]);
            toolTipDescricaoDasCasas.SetToolTip(button4B, ImportandoXadrezClass.DescricaoDosBotoesDebug[25]);
            toolTipDescricaoDasCasas.SetToolTip(button4C, ImportandoXadrezClass.DescricaoDosBotoesDebug[26]);
            toolTipDescricaoDasCasas.SetToolTip(button4D, ImportandoXadrezClass.DescricaoDosBotoesDebug[27]);
            toolTipDescricaoDasCasas.SetToolTip(button4E, ImportandoXadrezClass.DescricaoDosBotoesDebug[28]);
            toolTipDescricaoDasCasas.SetToolTip(button4F, ImportandoXadrezClass.DescricaoDosBotoesDebug[29]);
            toolTipDescricaoDasCasas.SetToolTip(button4G, ImportandoXadrezClass.DescricaoDosBotoesDebug[30]);
            toolTipDescricaoDasCasas.SetToolTip(button4H, ImportandoXadrezClass.DescricaoDosBotoesDebug[31]);
            toolTipDescricaoDasCasas.SetToolTip(button5A, ImportandoXadrezClass.DescricaoDosBotoesDebug[32]);
            toolTipDescricaoDasCasas.SetToolTip(button5B, ImportandoXadrezClass.DescricaoDosBotoesDebug[33]);
            toolTipDescricaoDasCasas.SetToolTip(button5C, ImportandoXadrezClass.DescricaoDosBotoesDebug[34]);
            toolTipDescricaoDasCasas.SetToolTip(button5D, ImportandoXadrezClass.DescricaoDosBotoesDebug[35]);
            toolTipDescricaoDasCasas.SetToolTip(button5E, ImportandoXadrezClass.DescricaoDosBotoesDebug[36]);
            toolTipDescricaoDasCasas.SetToolTip(button5F, ImportandoXadrezClass.DescricaoDosBotoesDebug[37]);
            toolTipDescricaoDasCasas.SetToolTip(button5G, ImportandoXadrezClass.DescricaoDosBotoesDebug[38]);
            toolTipDescricaoDasCasas.SetToolTip(button5H, ImportandoXadrezClass.DescricaoDosBotoesDebug[39]);
            toolTipDescricaoDasCasas.SetToolTip(button6A, ImportandoXadrezClass.DescricaoDosBotoesDebug[40]);
            toolTipDescricaoDasCasas.SetToolTip(button6B, ImportandoXadrezClass.DescricaoDosBotoesDebug[41]);
            toolTipDescricaoDasCasas.SetToolTip(button6C, ImportandoXadrezClass.DescricaoDosBotoesDebug[42]);
            toolTipDescricaoDasCasas.SetToolTip(button6D, ImportandoXadrezClass.DescricaoDosBotoesDebug[43]);
            toolTipDescricaoDasCasas.SetToolTip(button6E, ImportandoXadrezClass.DescricaoDosBotoesDebug[44]);
            toolTipDescricaoDasCasas.SetToolTip(button6F, ImportandoXadrezClass.DescricaoDosBotoesDebug[45]);
            toolTipDescricaoDasCasas.SetToolTip(button6G, ImportandoXadrezClass.DescricaoDosBotoesDebug[46]);
            toolTipDescricaoDasCasas.SetToolTip(button6H, ImportandoXadrezClass.DescricaoDosBotoesDebug[47]);
            toolTipDescricaoDasCasas.SetToolTip(button7A, ImportandoXadrezClass.DescricaoDosBotoesDebug[48]);
            toolTipDescricaoDasCasas.SetToolTip(button7B, ImportandoXadrezClass.DescricaoDosBotoesDebug[49]);
            toolTipDescricaoDasCasas.SetToolTip(button7C, ImportandoXadrezClass.DescricaoDosBotoesDebug[50]);
            toolTipDescricaoDasCasas.SetToolTip(button7D, ImportandoXadrezClass.DescricaoDosBotoesDebug[51]);
            toolTipDescricaoDasCasas.SetToolTip(button7E, ImportandoXadrezClass.DescricaoDosBotoesDebug[52]);
            toolTipDescricaoDasCasas.SetToolTip(button7F, ImportandoXadrezClass.DescricaoDosBotoesDebug[53]);
            toolTipDescricaoDasCasas.SetToolTip(button7G, ImportandoXadrezClass.DescricaoDosBotoesDebug[54]);
            toolTipDescricaoDasCasas.SetToolTip(button7H, ImportandoXadrezClass.DescricaoDosBotoesDebug[55]);
            toolTipDescricaoDasCasas.SetToolTip(button8A, ImportandoXadrezClass.DescricaoDosBotoesDebug[56]);
            toolTipDescricaoDasCasas.SetToolTip(button8B, ImportandoXadrezClass.DescricaoDosBotoesDebug[57]);
            toolTipDescricaoDasCasas.SetToolTip(button8C, ImportandoXadrezClass.DescricaoDosBotoesDebug[58]);
            toolTipDescricaoDasCasas.SetToolTip(button8D, ImportandoXadrezClass.DescricaoDosBotoesDebug[59]);
            toolTipDescricaoDasCasas.SetToolTip(button8E, ImportandoXadrezClass.DescricaoDosBotoesDebug[60]);
            toolTipDescricaoDasCasas.SetToolTip(button8F, ImportandoXadrezClass.DescricaoDosBotoesDebug[61]);
            toolTipDescricaoDasCasas.SetToolTip(button8G, ImportandoXadrezClass.DescricaoDosBotoesDebug[62]);
            toolTipDescricaoDasCasas.SetToolTip(button8H, ImportandoXadrezClass.DescricaoDosBotoesDebug[63]); 
        }


        // mudar oq o peão vai virar quando chegar no outro lado do tabuleiro
        private void comboBoxPeao_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImportandoXadrezClass.IdDaPessaQueOPeaoVaiVirar = Convert.ToByte(comboBoxPeao.SelectedIndex);
        }


        //Cor nos nomes
        private void oNOFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TextoDasCasasColorido == true)
            {
                MudarCorDoTextoDasCasasPreto();
                TextoDasCasasColorido = false;
                oNOFFToolStripMenuItem.Text = "Colocar Texto Colorido";
            }
            else
            {
                MudarCorDoTextoDasCasasColorido();
                TextoDasCasasColorido = true;
                oNOFFToolStripMenuItem.Text = "Colocar Texto Preto";
            }

        }

        //nomes-imagens
        private void oNOFFToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ColocarImagensNasCasas == true)
            {
                SemImagensNasCasas();
                RenomearNomeDosBotoesDoTabuleiro();
                ColocarImagensNasCasas = false;
                oNOFFToolStripMenuItem1.Text = "Colocar Imagem nas casas";
            }
            else
            {
                ComImagensNasCasas();
                RenomearNomeDosBotoesDoTabuleiroSemTexto();
                ColocarImagensNasCasas = true;
                oNOFFToolStripMenuItem1.Text = "Colocar nomes nas casas";

            }
        }

        //auto concluir jogada
        private void oNOFFToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (AutoConcluirJogadaOn == true)
            {
                oNOFFToolStripMenuItem2.Text = "Ativar Função";
                ImportandoXadrezClass.AutoConcluirJogada = false;
                AutoConcluirJogadaOn = false;

            }
            else
            {
                oNOFFToolStripMenuItem2.Text = "Desativar Função";
                ImportandoXadrezClass.AutoConcluirJogada = true;
                AutoConcluirJogadaOn = true;

            }
        }
        
        //ativa desativa popup das casas do tabuleiro
        private void oNOFFToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (MostrarPopupDasCasas == true)
            {
                toolTipDescricaoDasCasas.Active = false;
                oNOFFToolStripMenuItem3.Text = "Ativar Popup";
                MostrarPopupDasCasas = false;
            }
            else
            {
                toolTipDescricaoDasCasas.Active = true;
                oNOFFToolStripMenuItem3.Text = "Desativar Popup";
                MostrarPopupDasCasas = true;
            }
        }

        // info de debug
        private void oNOFFToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (VerInfoDeDebug == true)
            {
                ImportandoXadrezClass.DescricaoDosBotoesMetodo();
                DescricaoDosBotoes();
                oNOFFToolStripMenuItem4.Text = "Ativar Info De Debug";
                VerInfoDeDebug = false;
            }
            else
            {
                ImportandoXadrezClass.DescricaoDosBotoesDebugMetodo();
                DescricaoDosBotoesDebug();
                oNOFFToolStripMenuItem4.Text = "Desativar Info De Debug";
                VerInfoDeDebug = true;
            }
        }

        // botao de salvar como
        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportandoXadrezClass.CasaOndeEstaOReiDoPlayer = 64;
            ImportandoXadrezClass.CasaOndeEstaOReiDoRival = 64;
            ImportandoXadrezClass.IdentificandoOndeEstaoOsReis();

            List<int> QuantidadeDeReis = new List<int>();

            QuantidadeDeReis.Clear();

            for (int i = 0; i < 64; i++)
            {
                if (ImportandoXadrezClass.Pessa[i] == 14
                    || ImportandoXadrezClass.Pessa[i] == 24)
                {
                    QuantidadeDeReis.Add(i);
                }
            }



            if (ImportandoXadrezClass.XequeMate == true)
            {
                MessageBox.Show("Você não pode salvar um jogo com Xeque-mate.", "Erro:");
            }
            else
            {
                if (ImportandoXadrezClass.CasaOndeEstaOReiDoPlayer == 64 || ImportandoXadrezClass.CasaOndeEstaOReiDoRival == 64)
                {
                    MessageBox.Show("Você não pode salvar um jogo sem que tenha pelo menos um rei azul e um rei verde.", "Erro:");
                }
                else
                {
                    if (QuantidadeDeReis.Count != 2)
                    {
                        MessageBox.Show("Você não pode salvar um jogo que tenha mais de um rei azul ou de um rei verde.", "Erro:");
                    }
                    else
                    {
                        saveFileDialog1.ShowDialog();
                    }
                }
            }
        }

        // clicar no botao de ok da pagina de salvamento
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            ImportandoXadrezClass.SalvarJogo();

            // comando para criar arquivo
            TextWriter ArquivoSavar = new StreamWriter(saveFileDialog1.FileName);
            // tem q fazer excesão caso for subistituir um arquivo // n precisou

            ArquivoSavar.WriteLine("XADREZ_BY_JADERLINK");

            foreach (var item in ImportandoXadrezClass.Salvar)
            {
                //ArquivoSavar.WriteLine(item);
                ArquivoSavar.Write(item);
            }

            ArquivoSavar.Write(Environment.NewLine);

            //"Fim do arquivo, Xadrez By JADERLINK, Ver: 1.0"
            ArquivoSavar.Write("Fim do arquivo, Xadrez By JADERLINK, Ver: 1.0");

            ArquivoSavar.Close();

            ImportandoXadrezClass.Salvar.Clear();

        }

        // botao de carregar jogo pra jogar
        private void carregarParaJogarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarPraJogar = true;
            openFileDialog1.ShowDialog();
        }

        // apertar ok do ja janela de abrir arquivo
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //carrega arquivo
            TextReader LerArquivo = new StreamReader(openFileDialog1.FileName);

            List<byte> PartesEmBytes = new List<byte>();

            if (LerArquivo.ReadLine() == "XADREZ_BY_JADERLINK")
            {


                foreach (var item in LerArquivo.ReadToEnd())
                {
                    PartesEmBytes.Add(Convert.ToByte(item));
                }


                // apartir daqui coloco as informações do arquivo nas variaveis

                //CasaEstaOcupada
                for (int i = 0; i < 65; i++)
                {
                    int ide2 = i + 3;

                    if (PartesEmBytes[ide2] == 01)
                    {
                        ImportandoXadrezClass.CasaEstaOcupada[i] = true;
                    }
                    else
                    {
                        ImportandoXadrezClass.CasaEstaOcupada[i] = false;
                    }

                }

                // 71
                // CorDaPessa
                for (int i = 0; i < 65; i++)
                {
                    int ide2 = i + 71;
                    ImportandoXadrezClass.CorDaPessa[i] = PartesEmBytes[ide2];
                }

                //139
                //Pessa
                for (int i = 0; i < 65; i++)
                {
                    int ide2 = i + 139;
                    ImportandoXadrezClass.Pessa[i] = PartesEmBytes[ide2];
                }

                //207
                //DirecaoDoPeao
                for (int i = 0; i < 65; i++)
                {
                    int ide2 = i + 207;
                    ImportandoXadrezClass.DirecaoDoPeao[i] = PartesEmBytes[ide2];
                }

                //275
                //APessaJaFoiMovida
                for (int i = 0; i < 65; i++)
                {
                    int ide2 = i + 275;

                    if (PartesEmBytes[ide2] == 01)
                    {
                        ImportandoXadrezClass.APessaJaFoiMovida[i] = true;
                    }
                    else
                    {
                        ImportandoXadrezClass.APessaJaFoiMovida[i] = false;
                    }
                }
                //343
                //PeaoAndouDuasCasas
                for (int i = 0; i < 65; i++)
                {
                    int ide2 = i + 343;

                    if (PartesEmBytes[ide2] == 01)
                    {
                        ImportandoXadrezClass.PeaoAndouDuasCasas[i] = true;
                    }
                    else
                    {
                        ImportandoXadrezClass.PeaoAndouDuasCasas[i] = false;
                    }
                }

                int agrega = 0;

                //411
                //EmqualRodadaAPessaFoiMexida
                for (int i = 0; i < 65; i++)
                {
                    agrega += 4;

                    ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[i] =
                        Convert.ToUInt32(
                            Convert.ToString(PartesEmBytes[i + 411 + agrega - 4]) +
                            Convert.ToString(PartesEmBytes[i + 411 + agrega - 3]) +
                            Convert.ToString(PartesEmBytes[i + 411 + agrega - 2]) +
                            Convert.ToString(PartesEmBytes[i + 411 + agrega - 1]) +
                            Convert.ToString(PartesEmBytes[i + 411 + agrega]));

                }

                //739
                //Player
                ImportandoXadrezClass.Player = PartesEmBytes[739];

                if (PartesEmBytes[739] == 01)
                {
                    ImportandoXadrezClass.RivalDoPlayer = 2;
                }
                else
                {
                    ImportandoXadrezClass.RivalDoPlayer = 1;
                }

                //Console.WriteLine("carregando, Player: " + ImportandoXadrezClass.Player);
                //743
                //EmqualRodadaOplayerEstaJogando

                ImportandoXadrezClass.EmqualRodadaOplayerEstaJogando =
                    Convert.ToUInt32(
                        Convert.ToString(PartesEmBytes[743]) +
                        Convert.ToString(PartesEmBytes[744]) +
                        Convert.ToString(PartesEmBytes[745]) +
                        Convert.ToString(PartesEmBytes[746]) +
                        Convert.ToString(PartesEmBytes[747]));

                //Console.WriteLine("carregando, EmqualRodadaOplayerEstaJogando: " + ImportandoXadrezClass.EmqualRodadaOplayerEstaJogando);


                //751
                //nada
       
                //755
                //ReiEmXeque

                // removido
                /*
                if (PartesEmBytes[755] == 01)
                {
                    ImportandoXadrezClass.ReiEmXeque = true;
                }
                else
                {
                    ImportandoXadrezClass.ReiEmXeque = false;
                }
                */


                // setando oq n foi setado
                ImportandoXadrezClass.labelInfoRei = "";
                ImportandoXadrezClass.BotaoBloqueado = false;
                ImportandoXadrezClass.CasaDoPeaoAserRemovidoNoEnPassantADireitaOuACima = 64;
                ImportandoXadrezClass.CasaDoPeaoAserRemovidoNoEnPassantAEsquerdaOuABaixo = 64;
                ImportandoXadrezClass.CasaDoRoque[0] = 64;
                ImportandoXadrezClass.CasaDoRoque[1] = 64;
                ImportandoXadrezClass.CasaDoRoque[2] = 64;
                ImportandoXadrezClass.CasaDoRoque[3] = 64;
                ImportandoXadrezClass.CasaDoRoqueOndeATorreVai[0] = 64;
                ImportandoXadrezClass.CasaDoRoqueOndeATorreVai[1] = 64;
                ImportandoXadrezClass.CasaDoRoqueOndeATorreVai[2] = 64;
                ImportandoXadrezClass.CasaDoRoqueOndeATorreVai[3] = 64;
                ImportandoXadrezClass.CasaDoRoqueOndeATorreTava[0] = 64;
                ImportandoXadrezClass.CasaDoRoqueOndeATorreTava[1] = 64;
                ImportandoXadrezClass.CasaDoRoqueOndeATorreTava[2] = 64;
                ImportandoXadrezClass.CasaDoRoqueOndeATorreTava[3] = 64;
                ImportandoXadrezClass.CasaOndeEstaOReiDoPlayer = 64;
                ImportandoXadrezClass.CasaOndeEstaOReiDoRival = 64;
                ImportandoXadrezClass.CasaQueClicareiParaEnPassantADireitaOuACima = 64;
                ImportandoXadrezClass.CasaQueClicareiParaEnPassantAEsquerdaOuABaixo = 64;
                ImportandoXadrezClass.XequeMate = false;
                ImportandoXadrezClass.HouveEmpate = false;
                ImportandoXadrezClass.ColoqueiAPessaEmUmaCasa = false;
                ImportandoXadrezClass.ColoqueiAPessaEmUmaCasa_TabuleiroID = 64;
                ImportandoXadrezClass.EstoufazendoUmEnPassantADireitaOuACima = false;
                ImportandoXadrezClass.EstoufazendoUmEnPassantAEsquerdaOuABaixo = false;
                ImportandoXadrezClass.EstouFazendoUmRoque = false;
                ImportandoXadrezClass.mesagemBoxXequeMate = false;
                for (int i = 0; i < 65; i++)
                {
                    ImportandoXadrezClass.NaoPodeClicarNesseBotao[i] = false;
                }
                ImportandoXadrezClass.OPeaoAndouDuasCasas = false;
                ImportandoXadrezClass.ReiRivalFoiColocadoEmXequeMate = false;
                ImportandoXadrezClass.TemCasaSelecionada = false;


                ImportandoXadrezClass.Log = "Jogo carregado com sucesso";

                textBoxLog.Text = "Carregado Jogo";
                //ImportandoXadrezClass.Log = "";

                // //


                // faz backup para ser usado na testagem do Xeque-mate
                // faz backup dos casas/peças
                for (int id = 0; id < 65; id++)
                {
                    ImportandoXadrezClass.Backup_CasaEstaOcupada[id] = ImportandoXadrezClass.CasaEstaOcupada[id];
                    ImportandoXadrezClass.Backup_CorDaPessa[id] = ImportandoXadrezClass.CorDaPessa[id];
                    ImportandoXadrezClass.Backup_Pessa[id] = ImportandoXadrezClass.Pessa[id];
                    ImportandoXadrezClass.Backup_DirecaoDoPeao[id] = ImportandoXadrezClass.DirecaoDoPeao[id];
                    ImportandoXadrezClass.Backup_APessaJaFoiMovida[id] = ImportandoXadrezClass.APessaJaFoiMovida[id];
                    ImportandoXadrezClass.Backup_EmqualRodadaAPessaFoiMexida[id] = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[id];
                    ImportandoXadrezClass.Backup_PeaoAndouDuasCasas[id] = ImportandoXadrezClass.PeaoAndouDuasCasas[id];
                }

                //ImportandoXadrezClass.IdentificandoOndeEstaoOsReis();

               // if (ImportandoXadrezClass.ReiEmXeque == true){

     
                    if (ImportandoXadrezClass.Player == 1)
                    {
                        ImportandoXadrezClass.Player = 2;
                        ImportandoXadrezClass.RivalDoPlayer = 1;

                        ImportandoXadrezClass.ChecandoSeAhXequeMate();

                        ImportandoXadrezClass.Player = 1;
                        ImportandoXadrezClass.RivalDoPlayer = 2;

                    }
                    if (ImportandoXadrezClass.Player == 2)
                    {
                        ImportandoXadrezClass.Player = 1;
                        ImportandoXadrezClass.RivalDoPlayer = 2;

                        ImportandoXadrezClass.ChecandoSeAhXequeMate();

                        ImportandoXadrezClass.Player = 2;
                        ImportandoXadrezClass.RivalDoPlayer = 1;
                    }


                //}

                // gambiarra
                //ImportandoXadrezClass.ReiEmXeque = false;

                // //

                if (CarregarPraJogar == true)
                {
                    panelJogoNormal.Show();
                    panelModoEditar.Hide();
                    ImportandoXadrezClass.ModoEditor = false;
                    ImportandoXadrezClass.ModoEditor_TemCasaSelecionada = false;

                }

                if (CarregarPraEditar == true)
                {
                    panelJogoNormal.Hide();
                    panelModoEditar.Show();
                    ImportandoXadrezClass.ModoEditor = true;
                    ImportandoXadrezClass.ModoEditor_TemCasaSelecionada = false;


                    if (ImportandoXadrezClass.Player == 1)
                    {
                        ImportandoXadrezClass.comboBoxPlayerAtualSelectedIndex = 0;
                    }
                    else
                    {
                        ImportandoXadrezClass.comboBoxPlayerAtualSelectedIndex = 1;
                    }

                    ImportandoXadrezClass.numericUpDownEmqualRodadaOplayerEstaJogandoValue = ImportandoXadrezClass.EmqualRodadaOplayerEstaJogando;


                    // /////

                    comboBoxAPessaJaFoiMovida.Enabled = false;
                    comboBoxDirecaoDoPeao.Enabled = false;
                    comboBoxPeaoAndouDuasCasas.Enabled = false;
                    comboBoxPessaEscolhida.Enabled = false;
                    numericUpDownEmqualRodadaAPessaFoiMexida.Enabled = false;

                    radioButton_Edit_Selecionar.Checked = true;
                    ImportandoXadrezClass.ModoEditor_Selecionar = true;
                    ImportandoXadrezClass.ModoEditor_Subistituir = false;


                    ImportandoXadrezClass.CasaEstaOcupadaValor = false;
                    ImportandoXadrezClass.CorDaPessaValor = 0;
                    ImportandoXadrezClass.PessaValor = 0;
                    ImportandoXadrezClass.APessaJaFoiMovidaValor = false;
                    ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor = 0;
                    ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;
                    ImportandoXadrezClass.DirecaoDoPeaoValor = 0;

                    ImportandoXadrezClass.BotaoBloqueado = false;


                    ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = false;
                    ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;
                    ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                    ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = false;
                    ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = false;

                    ImportandoXadrezClass.labelInfoRei = "";

                }

                // atualiza oq é mostrado no tabuleiro
                ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa();
                DarClickNoBotaoInfo();

                ImportandoXadrezClass.BotaoBloqueado = false;

            }
            else
            {
                MessageBox.Show("Erro: o arquivo não é do tipo adeguando ou esta conrompido");
            }

            LerArquivo.Close();
            CarregarPraJogar = false;
            CarregarPraEditar = false;

        }

        // //  radio button opção selecionar
        private void radioButton_Edit_Selecionar_Click(object sender, EventArgs e)
        {
            ImportandoXadrezClass.ModoEditor_Selecionar = true;
            ImportandoXadrezClass.ModoEditor_Subistituir = false;

            comboBoxAPessaJaFoiMovida.Enabled = false;
            comboBoxDirecaoDoPeao.Enabled = false;
            comboBoxPeaoAndouDuasCasas.Enabled = false;
            comboBoxPessaEscolhida.Enabled = false;
            numericUpDownEmqualRodadaAPessaFoiMexida.Enabled = false;

            ImportandoXadrezClass.ModoEditor_TemCasaSelecionada = false;


            ImportandoXadrezClass.CasaEstaOcupadaValor = false;
            ImportandoXadrezClass.CorDaPessaValor = 0;
            ImportandoXadrezClass.PessaValor = 0;
            ImportandoXadrezClass.APessaJaFoiMovidaValor = false;
            ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor = 0;
            ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;
            ImportandoXadrezClass.DirecaoDoPeaoValor = 0;


            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = false;
            ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;
            ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
            ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = false;
            ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = false;

            ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa();
            DarClickNoBotaoInfo();

        }

        // //  radio button opção subistituir
        private void radioButton_Edit_Subistituir_Click(object sender, EventArgs e)
        {
            ImportandoXadrezClass.ModoEditor_Selecionar = false;
            ImportandoXadrezClass.ModoEditor_Subistituir = true;
            ImportandoXadrezClass.ModoEditor_TemCasaSelecionada = false;

            comboBoxPessaEscolhida.Enabled = true;
            comboBoxAPessaJaFoiMovida.Enabled = false;
            comboBoxDirecaoDoPeao.Enabled = false;
            comboBoxPeaoAndouDuasCasas.Enabled = false;
            numericUpDownEmqualRodadaAPessaFoiMexida.Enabled = false;

            comboBoxPessaEscolhida.SelectedItem = "Vazio";

            ImportandoXadrezClass.CasaEstaOcupadaValor = false;
            ImportandoXadrezClass.CorDaPessaValor = 0;
            ImportandoXadrezClass.PessaValor = 0;
            ImportandoXadrezClass.APessaJaFoiMovidaValor = false;
            ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor = 0;
            ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;
            ImportandoXadrezClass.DirecaoDoPeaoValor = 0;

            ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa();

            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = false;
            ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;
            ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
            ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
            ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = false;

            DarClickNoBotaoInfo();
        }

        // // troca do q tem dentro da combobox
        private void comboBoxPessaEscolhida_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indece = comboBoxPessaEscolhida.SelectedIndex;

            int ID_DA_CASA = ImportandoXadrezClass.Selecionado_TabuleiroID;

            if (ImportandoXadrezClass.ModoEditor_Selecionar == true)
            {

                switch (indece)
                {
                    case 0: // vasio
                        ImportandoXadrezClass.Pessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.CorDaPessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.CasaEstaOcupada[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = false;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = false;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 0;
                        break;
                    case 1:// peão azul
                        ImportandoXadrezClass.Pessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 16;
                        ImportandoXadrezClass.CorDaPessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 1;
                        ImportandoXadrezClass.CasaEstaOcupada[ImportandoXadrezClass.Selecionado_TabuleiroID] = true;
                        //ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = true;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = true;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 1;

                        if (ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] == 0)
                        {
                            ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 1;
                        }



                        if (ImportandoXadrezClass.APessaJaFoiMovida[ID_DA_CASA] == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }
                        if (ImportandoXadrezClass.PeaoAndouDuasCasas[ID_DA_CASA] == true)
                        {
                            ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasSelectedIndex = 0;
                        }
                        if (ImportandoXadrezClass.DirecaoDoPeao[ID_DA_CASA] == 1)
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 0;
                        }
                        else if (ImportandoXadrezClass.DirecaoDoPeao[ID_DA_CASA] == 2)
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 1;
                        }
                        else if (ImportandoXadrezClass.DirecaoDoPeao[ID_DA_CASA] == 3)
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 2;
                        }
                        else if (ImportandoXadrezClass.DirecaoDoPeao[ID_DA_CASA] == 4)
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 3;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ID_DA_CASA];



                        break;
                    case 2:// torre azul
                        ImportandoXadrezClass.Pessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 11;
                        ImportandoXadrezClass.CorDaPessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 1;
                        ImportandoXadrezClass.CasaEstaOcupada[ImportandoXadrezClass.Selecionado_TabuleiroID] = true;
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 2;

                        if (ImportandoXadrezClass.APessaJaFoiMovida[ID_DA_CASA] == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ID_DA_CASA];


                        break;
                    case 3:// cavalo azul
                        ImportandoXadrezClass.Pessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 12;
                        ImportandoXadrezClass.CorDaPessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 1;
                        ImportandoXadrezClass.CasaEstaOcupada[ImportandoXadrezClass.Selecionado_TabuleiroID] = true;
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 3;

                        if (ImportandoXadrezClass.APessaJaFoiMovida[ID_DA_CASA] == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ID_DA_CASA];
                        break;
                    case 4:// bispo azul
                        ImportandoXadrezClass.Pessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 13;
                        ImportandoXadrezClass.CorDaPessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 1;
                        ImportandoXadrezClass.CasaEstaOcupada[ImportandoXadrezClass.Selecionado_TabuleiroID] = true;
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 4;

                        if (ImportandoXadrezClass.APessaJaFoiMovida[ID_DA_CASA] == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ID_DA_CASA];
                        break;
                    case 5:// rei azul
                        ImportandoXadrezClass.Pessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 14;
                        ImportandoXadrezClass.CorDaPessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 1;
                        ImportandoXadrezClass.CasaEstaOcupada[ImportandoXadrezClass.Selecionado_TabuleiroID] = true;
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 5;

                        if (ImportandoXadrezClass.APessaJaFoiMovida[ID_DA_CASA] == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ID_DA_CASA];
                        break;
                    case 6:// rainha azul
                        ImportandoXadrezClass.Pessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 15;
                        ImportandoXadrezClass.CorDaPessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 1;
                        ImportandoXadrezClass.CasaEstaOcupada[ImportandoXadrezClass.Selecionado_TabuleiroID] = true;
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 6;

                        if (ImportandoXadrezClass.APessaJaFoiMovida[ID_DA_CASA] == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ID_DA_CASA];
                        break;
                    case 7:// peão verde
                        ImportandoXadrezClass.Pessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 26;
                        ImportandoXadrezClass.CorDaPessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 2;
                        ImportandoXadrezClass.CasaEstaOcupada[ImportandoXadrezClass.Selecionado_TabuleiroID] = true;
                        //ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = true;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = true;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 7;

                        if (ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] == 0)
                        {
                            ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 1;
                        }


                        if (ImportandoXadrezClass.APessaJaFoiMovida[ID_DA_CASA] == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }
                        if (ImportandoXadrezClass.PeaoAndouDuasCasas[ID_DA_CASA] == true)
                        {
                            ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasSelectedIndex = 0;
                        }
                        if (ImportandoXadrezClass.DirecaoDoPeao[ID_DA_CASA] == 1)
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 0;
                        }
                        else if (ImportandoXadrezClass.DirecaoDoPeao[ID_DA_CASA] == 2)
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 1;
                        }
                        else if (ImportandoXadrezClass.DirecaoDoPeao[ID_DA_CASA] == 3)
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 2;
                        }
                        else if (ImportandoXadrezClass.DirecaoDoPeao[ID_DA_CASA] == 4)
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 3;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ID_DA_CASA];


                        break;
                    case 8:// torre verde
                        ImportandoXadrezClass.Pessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 21;
                        ImportandoXadrezClass.CorDaPessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 2;
                        ImportandoXadrezClass.CasaEstaOcupada[ImportandoXadrezClass.Selecionado_TabuleiroID] = true;
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 8;

                        if (ImportandoXadrezClass.APessaJaFoiMovida[ID_DA_CASA] == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ID_DA_CASA];
                        break;
                    case 9:// cavalo verde
                        ImportandoXadrezClass.Pessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 22;
                        ImportandoXadrezClass.CorDaPessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 2;
                        ImportandoXadrezClass.CasaEstaOcupada[ImportandoXadrezClass.Selecionado_TabuleiroID] = true;
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 9;

                        if (ImportandoXadrezClass.APessaJaFoiMovida[ID_DA_CASA] == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ID_DA_CASA];
                        break;
                    case 10:// bispo verde
                        ImportandoXadrezClass.Pessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 23;
                        ImportandoXadrezClass.CorDaPessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 2;
                        ImportandoXadrezClass.CasaEstaOcupada[ImportandoXadrezClass.Selecionado_TabuleiroID] = true;
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 10;

                        if (ImportandoXadrezClass.APessaJaFoiMovida[ID_DA_CASA] == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ID_DA_CASA];
                        break;
                    case 11:// rei verde
                        ImportandoXadrezClass.Pessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 24;
                        ImportandoXadrezClass.CorDaPessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 2;
                        ImportandoXadrezClass.CasaEstaOcupada[ImportandoXadrezClass.Selecionado_TabuleiroID] = true;
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 11;

                        if (ImportandoXadrezClass.APessaJaFoiMovida[ID_DA_CASA] == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ID_DA_CASA];
                        break;
                    case 12:// rainha verde
                        ImportandoXadrezClass.Pessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 25;
                        ImportandoXadrezClass.CorDaPessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 2;
                        ImportandoXadrezClass.CasaEstaOcupada[ImportandoXadrezClass.Selecionado_TabuleiroID] = true;
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 12;

                        if (ImportandoXadrezClass.APessaJaFoiMovida[ID_DA_CASA] == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ID_DA_CASA];
                        break;
                    default:// nada
                        ImportandoXadrezClass.Pessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.CorDaPessa[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.CasaEstaOcupada[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = false;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = false;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 0;
                        break;

                }

            }


            if (ImportandoXadrezClass.ModoEditor_Subistituir == true)
            {

                switch (indece)
                {
                    case 0: // vasio
                        ImportandoXadrezClass.PessaValor = 0;
                        ImportandoXadrezClass.CorDaPessaValor = 0;
                        ImportandoXadrezClass.CasaEstaOcupadaValor = false;
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 0;
                        ImportandoXadrezClass.APessaJaFoiMovidaValor = false;
                        ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = false;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = false;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 0;
                        break;
                    case 1:// peão azul
                        ImportandoXadrezClass.PessaValor = 16;
                        ImportandoXadrezClass.CorDaPessaValor = 1;
                        ImportandoXadrezClass.CasaEstaOcupadaValor = true;
                        //ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = true;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = true;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 1;

                        if (ImportandoXadrezClass.DirecaoDoPeaoValor == 0)
                        {
                            ImportandoXadrezClass.DirecaoDoPeaoValor = 1;
                        }



                        if (ImportandoXadrezClass.APessaJaFoiMovidaValor == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }
                        if (ImportandoXadrezClass.PeaoAndouDuasCasasValor == true)
                        {
                            ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasSelectedIndex = 0;
                        }
                        if (ImportandoXadrezClass.DirecaoDoPeaoValor == 1)
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 0;
                        }
                        else if (ImportandoXadrezClass.DirecaoDoPeaoValor == 2)
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 1;
                        }
                        else if (ImportandoXadrezClass.DirecaoDoPeaoValor == 3)
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 2;
                        }
                        else if (ImportandoXadrezClass.DirecaoDoPeaoValor == 4)
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 3;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor;



                        break;
                    case 2:// torre azul
                        ImportandoXadrezClass.PessaValor = 11;
                        ImportandoXadrezClass.CorDaPessaValor = 1;
                        ImportandoXadrezClass.CasaEstaOcupadaValor = true;
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 2;

                        if (ImportandoXadrezClass.APessaJaFoiMovidaValor == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor;


                        break;
                    case 3:// cavalo azul
                        ImportandoXadrezClass.PessaValor = 12;
                        ImportandoXadrezClass.CorDaPessaValor = 1;
                        ImportandoXadrezClass.CasaEstaOcupadaValor = true;
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 3;

                        if (ImportandoXadrezClass.APessaJaFoiMovidaValor == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor;
                        break;
                    case 4:// bispo azul
                        ImportandoXadrezClass.PessaValor = 13;
                        ImportandoXadrezClass.CorDaPessaValor = 1;
                        ImportandoXadrezClass.CasaEstaOcupadaValor = true;
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 4;

                        if (ImportandoXadrezClass.APessaJaFoiMovidaValor == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor;
                        break;
                    case 5:// rei azul
                        ImportandoXadrezClass.PessaValor = 14;
                        ImportandoXadrezClass.CorDaPessaValor = 1;
                        ImportandoXadrezClass.CasaEstaOcupadaValor = true;
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 5;

                        if (ImportandoXadrezClass.APessaJaFoiMovidaValor == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor;
                        break;
                    case 6:// rainha azul
                        ImportandoXadrezClass.PessaValor = 15;
                        ImportandoXadrezClass.CorDaPessaValor = 1;
                        ImportandoXadrezClass.CasaEstaOcupadaValor = true;
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 6;

                        if (ImportandoXadrezClass.APessaJaFoiMovidaValor == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor;
                        break;
                    case 7:// peão verde
                        ImportandoXadrezClass.PessaValor = 26;
                        ImportandoXadrezClass.CorDaPessaValor = 2;
                        ImportandoXadrezClass.CasaEstaOcupadaValor = true;
                        //ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        //ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = true;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = true;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 7;

                        if (ImportandoXadrezClass.DirecaoDoPeaoValor == 0)
                        {
                            ImportandoXadrezClass.DirecaoDoPeaoValor = 1;
                        }


                        if (ImportandoXadrezClass.APessaJaFoiMovidaValor == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }
                        if (ImportandoXadrezClass.PeaoAndouDuasCasasValor == true)
                        {
                            ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasSelectedIndex = 0;
                        }
                        if (ImportandoXadrezClass.DirecaoDoPeaoValor == 1)
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 0;
                        }
                        else if (ImportandoXadrezClass.DirecaoDoPeaoValor == 2)
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 1;
                        }
                        else if (ImportandoXadrezClass.DirecaoDoPeaoValor == 3)
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 2;
                        }
                        else if (ImportandoXadrezClass.DirecaoDoPeaoValor == 4)
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 3;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor;


                        break;
                    case 8:// torre verde
                        ImportandoXadrezClass.PessaValor = 21;
                        ImportandoXadrezClass.CorDaPessaValor = 2;
                        ImportandoXadrezClass.CasaEstaOcupadaValor = true;
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 8;

                        if (ImportandoXadrezClass.APessaJaFoiMovidaValor == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor;
                        break;
                    case 9:// cavalo verde
                        ImportandoXadrezClass.PessaValor = 22;
                        ImportandoXadrezClass.CorDaPessaValor = 2;
                        ImportandoXadrezClass.CasaEstaOcupadaValor = true;
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 9;

                        if (ImportandoXadrezClass.APessaJaFoiMovidaValor == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor;
                        break;
                    case 10:// bispo verde
                        ImportandoXadrezClass.PessaValor = 23;
                        ImportandoXadrezClass.CorDaPessaValor = 2;
                        ImportandoXadrezClass.CasaEstaOcupadaValor = true;
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 10;

                        if (ImportandoXadrezClass.APessaJaFoiMovidaValor == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor;
                        break;
                    case 11:// rei verde
                        ImportandoXadrezClass.PessaValor = 24;
                        ImportandoXadrezClass.CorDaPessaValor = 2;
                        ImportandoXadrezClass.CasaEstaOcupadaValor = true;
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 11;

                        if (ImportandoXadrezClass.APessaJaFoiMovidaValor == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor;
                        break;
                    case 12:// rainha verde
                        ImportandoXadrezClass.PessaValor = 25;
                        ImportandoXadrezClass.CorDaPessaValor = 2;
                        ImportandoXadrezClass.CasaEstaOcupadaValor = true;
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 0;
                        //ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        //ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = true;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 12;

                        if (ImportandoXadrezClass.APessaJaFoiMovidaValor == true)
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        }
                        else
                        {
                            ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        }

                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor;
                        break;
                    default:// nada
                        ImportandoXadrezClass.PessaValor = 0;
                        ImportandoXadrezClass.CorDaPessaValor = 0;
                        ImportandoXadrezClass.CasaEstaOcupadaValor = false;
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 0;
                        ImportandoXadrezClass.APessaJaFoiMovidaValor = false;
                        ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor = 0;
                        ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaEnabled = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaEnabled = false;
                        ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaEnabled = false;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasEnabled = false;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoEnabled = false;

                        ImportandoXadrezClass.comboBoxPessaEscolhidaSelectedIndex = 0;
                        break;
                }

            }


            ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa();
            DarClickNoBotaoInfo();
        }

        // botao pra editar novo jogo.
        private void editarNovoJogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportandoXadrezClass.EditarNovoJogo();
            textBoxLog.Text = "";
            ImportandoXadrezClass.Log = "";
            DarClickNoBotaoInfo();
            panelJogoNormal.Hide();
            panelModoEditar.Show();

            comboBoxAPessaJaFoiMovida.Enabled = false;
            comboBoxDirecaoDoPeao.Enabled = false;
            comboBoxPeaoAndouDuasCasas.Enabled = false;
            comboBoxPessaEscolhida.Enabled = false;
            numericUpDownEmqualRodadaAPessaFoiMexida.Enabled = false;

            ImportandoXadrezClass.ModoEditor_TemCasaSelecionada = false;

            radioButton_Edit_Selecionar.Checked = true;
            ImportandoXadrezClass.ModoEditor_Selecionar = true;
            ImportandoXadrezClass.ModoEditor_Subistituir = false;


            ImportandoXadrezClass.CasaEstaOcupadaValor = false;
            ImportandoXadrezClass.CorDaPessaValor = 0;
            ImportandoXadrezClass.PessaValor = 0;
            ImportandoXadrezClass.APessaJaFoiMovidaValor = false;
            ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor = 0;
            ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;
            ImportandoXadrezClass.DirecaoDoPeaoValor = 0;

            ImportandoXadrezClass.BotaoBloqueado = false;

        }

        // //
        private void comboBoxAPessaJaFoiMovida_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indece = comboBoxAPessaJaFoiMovida.SelectedIndex;

            if (ImportandoXadrezClass.ModoEditor_Selecionar == true)
            {
                switch (indece)
                {
                    case 0:// false
                        ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        break;
                    case 1:// true
                        ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        break;
                    default: // fica como false
                        ImportandoXadrezClass.APessaJaFoiMovida[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        break;
                }

            }

            if (ImportandoXadrezClass.ModoEditor_Subistituir == true)
            {
                switch (indece)
                {
                    case 0:// false
                        ImportandoXadrezClass.APessaJaFoiMovidaValor = false;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        break;
                    case 1:// true
                        ImportandoXadrezClass.APessaJaFoiMovidaValor = true;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 1;
                        break;
                    default: // fica como false
                        ImportandoXadrezClass.APessaJaFoiMovidaValor = false;
                        ImportandoXadrezClass.comboBoxAPessaJaFoiMovidaSelectedIndex = 0;
                        break;
                }

            }



            ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa();
            DarClickNoBotaoInfo();

        }

        // //
        private void numericUpDownEmqualRodadaAPessaFoiMexida_ValueChanged(object sender, EventArgs e)
        {
            uint valordacaixa = Convert.ToUInt32(numericUpDownEmqualRodadaAPessaFoiMexida.Value);

            if (ImportandoXadrezClass.ModoEditor_Selecionar == true)
            {
                ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[ImportandoXadrezClass.Selecionado_TabuleiroID] = valordacaixa;
 
            }

            if (ImportandoXadrezClass.ModoEditor_Subistituir == true)
            {
                ImportandoXadrezClass.EmqualRodadaAPessaFoiMexidaValor = valordacaixa;
            }

            ImportandoXadrezClass.numericUpDownEmqualRodadaAPessaFoiMexidaValue = valordacaixa;

            ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa();
            DarClickNoBotaoInfo();
        }

        // //
        private void comboBoxPeaoAndouDuasCasas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indece = comboBoxPeaoAndouDuasCasas.SelectedIndex;

            if (ImportandoXadrezClass.ModoEditor_Selecionar == true)
            {
                switch (indece)
                {
                    case 0:// false
                        ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasSelectedIndex = 0;
                        break;
                    case 1:// true
                        ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasSelectedIndex = 1;
                        break;
                    default: // fica como false
                        ImportandoXadrezClass.PeaoAndouDuasCasas[ImportandoXadrezClass.Selecionado_TabuleiroID] = false;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasSelectedIndex = 0;
                        break;
                }

            }

            if (ImportandoXadrezClass.ModoEditor_Subistituir == true)
            {
                switch (indece)
                {
                    case 0:// false
                        ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasSelectedIndex = 0;
                        break;
                    case 1:// true
                        ImportandoXadrezClass.PeaoAndouDuasCasasValor = true;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasSelectedIndex = 1;
                        break;
                    default: // fica como false
                        ImportandoXadrezClass.PeaoAndouDuasCasasValor = false;
                        ImportandoXadrezClass.comboBoxPeaoAndouDuasCasasSelectedIndex = 0;
                        break;
                }

            }




            ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa();
            DarClickNoBotaoInfo();
        }

        // //
        private void comboBoxDirecaoDoPeao_SelectedIndexChanged(object sender, EventArgs e)
        {

            int indece = comboBoxDirecaoDoPeao.SelectedIndex;

            if (ImportandoXadrezClass.ModoEditor_Selecionar == true)
            {
                switch (indece)
                {
                    case 0://pra cima
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 1;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 0;
                        break;
                    case 1://pra baixo
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 2;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 1;
                        break;
                    case 2://pra direita
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 3;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 2;
                        break;
                    case 3://pra esquerda
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 4;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 3;
                        break;
                    default:// seta como 0
                        ImportandoXadrezClass.DirecaoDoPeao[ImportandoXadrezClass.Selecionado_TabuleiroID] = 0;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 0;
                        break;
                }
            }


            if (ImportandoXadrezClass.ModoEditor_Subistituir == true)
            {
                switch (indece)
                {
                    case 0://pra cima
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 1;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 0;
                        break;
                    case 1://pra baixo
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 2;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 1;
                        break;
                    case 2://pra direita
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 3;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 2;
                        break;
                    case 3://pra esquerda
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 4;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 3;
                        break;
                    default:// seta como 0
                        ImportandoXadrezClass.DirecaoDoPeaoValor = 0;
                        ImportandoXadrezClass.comboBoxDirecaoDoPeaoSelectedIndex = 0;
                        break;
                }
            }


            ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa();
            DarClickNoBotaoInfo();
        }

        // // geral player atual
        private void comboBoxPlayerAtual_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indece = comboBoxPlayerAtual.SelectedIndex;

                switch (indece)
                {
                    case 0:// player azul
                    ImportandoXadrezClass.Player = 1;
                    ImportandoXadrezClass.RivalDoPlayer = 2;
                    ImportandoXadrezClass.comboBoxPlayerAtualSelectedIndex = 0;
                        break;
                    case 1:// player verde
                    ImportandoXadrezClass.Player = 2;
                    ImportandoXadrezClass.RivalDoPlayer = 1;
                    ImportandoXadrezClass.comboBoxPlayerAtualSelectedIndex = 1;
                    break;
                    default: // fica como player azul
                    ImportandoXadrezClass.Player = 1;
                    ImportandoXadrezClass.RivalDoPlayer = 2;
                    ImportandoXadrezClass.comboBoxPlayerAtualSelectedIndex = 0;
                    break;
                }

            ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa();
            DarClickNoBotaoInfo();
        }

        // //
        private void numericUpDownEmqualRodadaOplayerEstaJogando_ValueChanged(object sender, EventArgs e)
        {
            uint valordacaixa = Convert.ToUInt32(numericUpDownEmqualRodadaOplayerEstaJogando.Value);

            ImportandoXadrezClass.EmqualRodadaOplayerEstaJogando = valordacaixa;
            ImportandoXadrezClass.numericUpDownEmqualRodadaOplayerEstaJogandoValue = valordacaixa;

            ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa();
            DarClickNoBotaoInfo();
        }

        // carrega de um arquivo e dita
        private void carregarParaEditarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarPraEditar = true;
            openFileDialog1.ShowDialog();
        }

        // "botao" superior informa os creditos
        private void creditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // info Environment.NewLine coloca nova linha

            MessageBox.Show("Xadrez By Jaderlink" + Environment.NewLine + "Site: jaderlink.blogspot.com", "Créditos:");
           
        }

        // Testar Tabuleiro (Debug)
        private void oNOFFToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //oNOFFToolStripMenuItem5.Text = "Ativar Teste Do tabuleiro";
            //ImportandoXadrezClass.TestarTabuleiroDebug = false;

            if (ImportandoXadrezClass.TestarTabuleiroDebug == true)
            {
                ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa();
                DarClickNoBotaoInfo();
                ImportandoXadrezClass.TemCasaSelecionada = false;
                ImportandoXadrezClass.ColoqueiAPessaEmUmaCasa = false;
                oNOFFToolStripMenuItem5.Text = "Ativar Teste Do tabuleiro";
                ImportandoXadrezClass.TestarTabuleiroDebug = false;
            }
            else
            {
                ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa();
                DarClickNoBotaoInfo();
                ImportandoXadrezClass.TemCasaSelecionada = false;
                ImportandoXadrezClass.ColoqueiAPessaEmUmaCasa = false;
                oNOFFToolStripMenuItem5.Text = "Desativar Teste Do tabuleiro";
                ImportandoXadrezClass.TestarTabuleiroDebug = true;
            }
        }

        private void numericUpDownInfoDebug_ValueChanged(object sender, EventArgs e)
        {
            ImportandoXadrezClass.DescricaoDosBotoesDebugMetodo();
            toolTipDescricaoDasCasas.SetToolTip(numericUpDownInfoDebug, ImportandoXadrezClass.DescricaoDosBotoesDebug[Convert.ToInt32(numericUpDownInfoDebug.Value)]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Windows.Forms;

namespace Xadrez
{
    public partial class Form1
    {
        TcpClient OndeClientEstaConectado;

        bool ClientEstaConectadoComHost;

        bool SeTemQPedirAInfoDotabuleiro;

        Thread ThreadComunica_seComHost;

        delegate void Chamavoid();
        delegate void ChamavoidComString(string NomeDaString);

        public void Conectar()
        {
            try
            {
                if (ClientEstaConectadoComHost == false)
                {
                    OndeClientEstaConectado = new TcpClient();
                    OndeClientEstaConectado.Connect(textBoxClientIP.Text,Convert.ToInt32(numericUpDownClientDoor.Value));

                    ClientEstaConectadoComHost = true;

                    SeTemQPedirAInfoDotabuleiro = true;

                    ThreadComunica_seComHost = new Thread(Comunica_seComHost);
                    ThreadComunica_seComHost.IsBackground = true;
                    ThreadComunica_seComHost.Start();

                    string OQueTavaNoChat = textBoxChat.Text;
                    textBoxChat.Text += "Conectando Com o Servidor;" + Environment.NewLine;


                    ImportandoXadrezClass.TaNoOnline = true;

                    // manipula as abas do programa

                    panelConectar.Hide();
                    panelHostearPartida.Hide();
                    panelCHAT.Show();
                    panelJogoNormal.Show();
                    panelModoEditar.Hide();
                    panelTemTabuleiro.Show();
                    salvarComoToolStripMenuItem.Enabled = true;
                    concluirJogadaToolStripMenuItem.Enabled = true;
                    desconectarToolStripMenuItem.Enabled = true;

                    novaPartidaToolStripMenuItem.Enabled = false;
                    carregarParaEditarToolStripMenuItem.Enabled = false;
                    carregarParaJogarToolStripMenuItem.Enabled = false;
                    editarNovoJogoToolStripMenuItem.Enabled = false;
                    hostearPartidaToolStripMenuItem.Enabled = false;
                    conectarNaPartidaToolStripMenuItem.Enabled = false;
                    textBoxEnviaProChat.Enabled = true;

                    requisitarJogoCarregadoToolStripMenuItem.Enabled = true;
                    requisitarNovaPartidaToolStripMenuItem.Enabled = true;
                    requisitarDadosDoTabuleiroToolStripMenuItem.Enabled = true;

                    testarTabuleiroDebugToolStripMenuItem.Enabled = false;
                    ImportandoXadrezClass.TemCasaSelecionada = false;
                    ImportandoXadrezClass.ColoqueiAPessaEmUmaCasa = false;
                    oNOFFToolStripMenuItem5.Text = "Ativar Teste Do tabuleiro";
                    ImportandoXadrezClass.TestarTabuleiroDebug = false;


                }
            }
            catch (FormatException)
            {
                MessageBox.Show("IP incorreto, digite um IP valido.", "Erro:");
            }
            catch (SocketException)
            {
                MessageBox.Show("IP incorreto, ou não pode conectar-se com o IP.", "Erro:");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro:");
            }

        }

        public void Desconectar()
        {
            if (ClientEstaConectadoComHost == true)
            {
                ClientEstaConectadoComHost = false;
                ThreadComunica_seComHost.Abort();
                OndeClientEstaConectado.Close();
                ManipulaDados.Close();

                ImportandoXadrezClass.TaNoOnline = false;

                string OQueTavaNoChat = textBoxChat.Text;
                textBoxChat.Text += "Desconectando Do Servidor;" + Environment.NewLine;
            }

        }

        void Comunica_seComHost()
        {
            try
            {
                ManipulaDados = OndeClientEstaConectado.GetStream();
              
                while (ClientEstaConectadoComHost == true)
                {

                    if (SeTemQPedirAInfoDotabuleiro == true)
                    {
                        string PedeInfoDoTabuleiro = "3 Passa os dados ai";
                        byte[] sendBytes = Encoding.UTF8.GetBytes(PedeInfoDoTabuleiro);
                        ManipulaDados.Write(sendBytes, 0, sendBytes.Length);
                        ManipulaDados.Flush();

                        SeTemQPedirAInfoDotabuleiro = false;
                    }

                    if (ManipulaDados.DataAvailable)
                    {
                        byte[] bytes = new byte[OndeClientEstaConectado.ReceiveBufferSize];
                        ManipulaDados.Read(bytes, 0, OndeClientEstaConectado.ReceiveBufferSize);
                        string Dados = Encoding.UTF8.GetString(bytes);
                        Invoke(new DelegateMostraAsMensagensRecebidas(MostraAsMensagensRecebidas), new object[] { Dados });
                    }

                    // faz n usar 25% de cpu
                    Thread.Sleep(1);
                }
            }
            catch (IOException)
            {
                if (ClientEstaConectadoComHost == true)
                {
                    ClientEstaConectadoComHost = false;
                    OndeClientEstaConectado.Close();
                    ManipulaDados.Close();
                    ThreadComunica_seComHost.Abort();
                    ImportandoXadrezClass.PlayerDoUsuario = 3;

                    //textBoxChat.Text += "Você Perdeu A Conexão Com O Servidor;" + Environment.NewLine;

                    SetControlPropertyValue(textBoxChat, "Text", textBoxChat.Text + "Você Perdeu A Conexão Com O Servidor;" + Environment.NewLine);
                }

            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception)
            {
            }
        }

    }
}

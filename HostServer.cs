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
        // armazena o ip do cliente conectado
        TcpClient TcpClientDoCliente;

        // abre a conexão para a cominicação entre host e o cliente.
        TcpListener TcpListenerHost;

        // threads
        Thread ThreadEsperaClientEntrar;
        Thread ThreadComunica_seComOClient;

        NetworkStream ManipulaDados;

        delegate void DelegateMostraAsMensagensRecebidas(string Mensagem);

        IPAddress IPAddressDoHost;
        int Door;

        bool SeServerEstaHosteado;
        bool ClientEstaConectado;

        public void IniciaHost()
        {
            // inicio o server
            try
            {
                if (SeServerEstaHosteado == false)
                {
                    IPAddressDoHost = IPAddress.Parse(textBoxHostIP.Text);
                    Door = Convert.ToInt32(numericUpDownHostDoor.Value);

                    // inicia o TcpListener
                    TcpListenerHost = new TcpListener(IPAddressDoHost, Door);
                    TcpListenerHost.Start();

                    // informa q o server ta on
                    SeServerEstaHosteado = true;

                    // inicia thread que aceita clientes
                    ThreadEsperaClientEntrar = new Thread(EsperandoClientEntrar);
                    ThreadEsperaClientEntrar.IsBackground = true;
                    ThreadEsperaClientEntrar.Start();

                    // inicia thead que se comunica com o client
                    ThreadComunica_seComOClient = new Thread(Comunica_seComOClient);
                    ThreadComunica_seComOClient.IsBackground = true;
                    ThreadComunica_seComOClient.Start();

                    textBoxChat.Text += "Servidor iniciado, Espere o outro jogador para jogar;" + Environment.NewLine;

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
                MessageBox.Show("IP incorreto, digite um IP valido.", "Erro:");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro:");
                //throw ex;
            }

        }

        void EsperandoClientEntrar()
        {
            try
            {
                while (SeServerEstaHosteado == true)
                {
                    TcpClient TcpClientLocal = TcpListenerHost.AcceptTcpClient();

                    if (ClientEstaConectado == false)
                    {
                        TcpClientDoCliente = TcpClientLocal;

                        if (TcpClientDoCliente != null)
                        {                            
                            ManipulaDados = TcpClientDoCliente.GetStream();
                            ClientEstaConectado = true;

                            string VaiProChat = textBoxChat.Text + "O Outro Jogador Entrou;" + Environment.NewLine;
                            SetControlPropertyValue(textBoxChat, "Text", VaiProChat); 
                        }
                    }
                    else
                    {
                        if (TcpClientLocal != null)
                        {
                            if (TcpClientDoCliente != null)
                            {
                                ClientEstaConectado = false;
                                TcpClientDoCliente.Close();
                                ManipulaDados.Close();
                            }

                            TcpClientDoCliente = TcpClientLocal;
                            ManipulaDados = TcpClientDoCliente.GetStream();
                            ClientEstaConectado = true;

                            string VaiProChat = textBoxChat.Text + "Um Novo Jogador Entrou;" + Environment.NewLine;
                            SetControlPropertyValue(textBoxChat, "Text", VaiProChat);
                        }
                    }
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception)
            {          
            }
        }


        public void Fechahost()
        {
            if (SeServerEstaHosteado == true)
            {
                if (TcpClientDoCliente != null)
                {
                    ClientEstaConectado = false;
                    TcpClientDoCliente.Close();
                    ManipulaDados.Close();
                }

                TcpListenerHost.Stop();
                TcpListenerHost = null;

                SeServerEstaHosteado = false;
                ThreadEsperaClientEntrar.Abort();
                ThreadComunica_seComOClient.Abort();

                string OQueTavaNoChat = textBoxChat.Text;
                textBoxChat.Text += "Servidor Parado;" + Environment.NewLine;

                ImportandoXadrezClass.TaNoOnline = false;
                ImportandoXadrezClass.PlayerDoUsuario = 3;
            }
        }


        void AoSairDoPrograma(object sender, EventArgs e)
        {
            // do host
            if (SeServerEstaHosteado == true)
            {
                if (TcpClientDoCliente != null)
                {
                    ClientEstaConectado = false;                 
                    TcpClientDoCliente.Close();
                    ManipulaDados.Close();
                }
                TcpListenerHost.Stop();
                TcpListenerHost = null;

                SeServerEstaHosteado = false;
                ThreadEsperaClientEntrar.Abort();
                ThreadComunica_seComOClient.Abort();
            }

            // do client
            if (ClientEstaConectadoComHost == true)
            {
                ClientEstaConectadoComHost = false;             
                OndeClientEstaConectado.Close();
                ManipulaDados.Close();
                ThreadComunica_seComHost.Abort();
            }
        }

        void Comunica_seComOClient()
        {
            try
            {
                while (SeServerEstaHosteado == true)
                {                
                    if (ClientEstaConectado == true)
                    {        
                        if (ManipulaDados.DataAvailable)
                        {
                            byte[] bytes = new byte[TcpClientDoCliente.ReceiveBufferSize];
                            ManipulaDados.Read(bytes, 0, TcpClientDoCliente.ReceiveBufferSize);
                            string StringQueRecebeOSDados = Encoding.UTF8.GetString(bytes);
                            Invoke(new DelegateMostraAsMensagensRecebidas(MostraAsMensagensRecebidas), new object[] { StringQueRecebeOSDados });
                        }
                    }

                    // faz n usar 25% de cpu
                    Thread.Sleep(1);
                }

            }
            catch (ThreadAbortException)
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void MostraAsMensagensRecebidas(string Mensagem)
        {
            lock (this)
            {
                if (Mensagem.StartsWith("NADA"))
                {
                    // faz nada
                }
                else if (Mensagem.StartsWith("1"))
                {
                    string Dados = Mensagem.Remove(0, 2);

                    SetControlPropertyValue(textBoxChat, "Text", textBoxChat.Text + Dados + Environment.NewLine);
                }
                else if (Mensagem.StartsWith("2"))
                {
                    string Dados = Mensagem.Remove(0, 2);
                    string Dados2 = "1 " + "Verde: " + Dados;

                    if (EnviaDados(Dados2))
                    {
                        SetControlPropertyValue(textBoxChat, "Text", textBoxChat.Text + "Verde: " + Dados + Environment.NewLine);
                    }
                }
                else if (Mensagem.StartsWith("3"))
                {
                    Invoke(new Chamavoid(ImportandoXadrezClass.SalvarJogo));

                    string TodoOtabuleiro = "4 ";
                    for (int i = 0; i < ImportandoXadrezClass.Salvar.Count; i++)
                    {
                        TodoOtabuleiro += ImportandoXadrezClass.Salvar[i];
                    }

                    EnviaDados(TodoOtabuleiro);

                }
                else if (Mensagem.StartsWith("4"))
                {
                    string DadosTratados = Mensagem.Remove(0, 2);

                    Invoke(new ChamavoidComString(RecebeinfoDotabuleiroEAtualiza_o), new object[] { DadosTratados });

                    // setando oq n foi setado
                    Invoke(new Chamavoid(SetandoOQueNaoFoiSetado));

                    ImportandoXadrezClass.PlayerDoUsuario = 2;
                    Invoke(new Chamavoid(ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa));
                    Invoke(new Chamavoid(ImportandoXadrezClass.ChecarSeOReiFoiColocadoEmXeque));
                    Invoke(new Chamavoid(DarClickNoBotaoInfo));

                    string InformaQueRecebeuOsdados = "6 Recebi os dados, ok";

                    EnviaDados(InformaQueRecebeuOsdados);

                }
                else if (Mensagem.StartsWith("5"))
                {
                    string DadosTratados = Mensagem.Remove(0, 2);

                    Invoke(new Chamavoid(ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa));
                    Invoke(new ChamavoidComString(ImportandoXadrezClass.RecebeinfoDeDisplayDotabuleiroEAtualiza_o), new object[] { DadosTratados });
                    Invoke(new Chamavoid(DarClickNoBotaoInfo));
                }
                else if (Mensagem.StartsWith("6"))
                {
                    ImportandoXadrezClass.PlayerDoUsuario = 1;
                    Invoke(new Chamavoid(ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa));
                    Invoke(new Chamavoid(ImportandoXadrezClass.ChecarSeOReiFoiColocadoEmXeque));
                    Invoke(new Chamavoid(DarClickNoBotaoInfo));


                }
                else if (Mensagem.StartsWith("7"))
                {
                    string DadosTratados = Mensagem.Remove(0, 2);

                    Invoke(new ChamavoidComString(RecebeinfoDotabuleiroEAtualiza_o), new object[] { DadosTratados });
                    Invoke(new Chamavoid(ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa));
                    Invoke(new Chamavoid(ImportandoXadrezClass.ChecarSeOReiFoiColocadoEmXeque));
                    Invoke(new Chamavoid(DarClickNoBotaoInfo));
                }
                else if (Mensagem.StartsWith("X"))
                {
                    if (ImportandoXadrezClass.Player == 1)
                    {
                        ImportandoXadrezClass.labelInfoRei = "Jogador Azul Venceu O Jogo";
                        ImportandoXadrezClass.labelInfoReiColor = ImportandoXadrezClass.CORES_AZUL;
                    }
                    else
                    {
                        ImportandoXadrezClass.labelInfoRei = "Jogador Verde Venceu O Jogo";
                        ImportandoXadrezClass.labelInfoReiColor = ImportandoXadrezClass.CORES_VERDE;
                    }
                    Invoke(new Chamavoid(DarClickNoBotaoInfo));
                    ImportandoXadrezClass.XequeMate = true;
                    XequemateMessageBox = true;
                    Invoke(new Chamavoid(ChamaAsMessageBoxXequeMateEEmpate));
                }
                else if (Mensagem.StartsWith("E"))
                {
                    ImportandoXadrezClass.labelInfoRei = "O Jogo Empatou";
                    ImportandoXadrezClass.labelInfoReiColor = ImportandoXadrezClass.CORES_PRETO;
                    Invoke(new Chamavoid(DarClickNoBotaoInfo));
                    ImportandoXadrezClass.HouveEmpate = true;
                    HouveEmpateMessageBox = true;

                    Invoke(new Chamavoid(ChamaAsMessageBoxXequeMateEEmpate));
                }
                else if (Mensagem.StartsWith("R1A")
                    || Mensagem.StartsWith("R1V"))
                {
                    if (MessageBox.Show("O Outro Jogador Requisitou Uma Nova Partida," + Environment.NewLine + "Você Aceita Jogar Uma Nova Partida?", "Pesponda a pergunta:", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (Mensagem.StartsWith("R1A"))
                        {
                            string Oqvaienviar = "S1A sim aceito";
                            EnviaDados(Oqvaienviar);
                        }
                        if (Mensagem.StartsWith("R1V"))
                        {
                            string Oqvaienviar = "S1V sim aceito";
                            EnviaDados(Oqvaienviar);
                        }

                    }

                }
                else if (Mensagem.StartsWith("R2A")
                    || Mensagem.StartsWith("R2V"))
                {
                    if (MessageBox.Show("O Outro Jogador Requisitou Uma Partida De Um Jogo Carregado," + Environment.NewLine + "Você Aceita Jogar Uma 'Nova' Partida?", "Pesponda a pergunta:", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (Mensagem.StartsWith("R2A"))
                        {
                            string Oqvaienviar = "S2A sim aceito";
                            EnviaDados(Oqvaienviar);
                        }
                        if (Mensagem.StartsWith("R2V"))
                        {
                            string Oqvaienviar = "S2V sim aceito";
                            EnviaDados(Oqvaienviar);
                        }

                    }

                }
                else if (Mensagem.StartsWith("S1A"))
                {
                    Invoke(new Chamavoid(ImportandoXadrezClass.IniciandoNovaPartida));
                    Invoke(new Chamavoid(SetandoOQueNaoFoiSetado));
                    ImportandoXadrezClass.PlayerDoUsuario = 2;
                    Invoke(new Chamavoid(ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa));
                    Invoke(new Chamavoid(ImportandoXadrezClass.ChecarSeOReiFoiColocadoEmXeque));
                    Invoke(new Chamavoid(DarClickNoBotaoInfo));

                    string Oqenviar = "D1A Faz um novo jogo ai";
                    EnviaDados(Oqenviar);
                }
                else if (Mensagem.StartsWith("S1V"))
                {
                    Invoke(new Chamavoid(ImportandoXadrezClass.IniciandoNovaPartida));
                    Invoke(new Chamavoid(SetandoOQueNaoFoiSetado));
                    ImportandoXadrezClass.PlayerDoUsuario = 1;
                    Invoke(new Chamavoid(ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa));
                    Invoke(new Chamavoid(ImportandoXadrezClass.ChecarSeOReiFoiColocadoEmXeque));
                    Invoke(new Chamavoid(DarClickNoBotaoInfo));

                    string Oqenviar = "D1V Faz um novo jogo ai";
                    EnviaDados(Oqenviar);
                }
                else if (Mensagem.StartsWith("D1A"))
                {
                    Invoke(new Chamavoid(ImportandoXadrezClass.IniciandoNovaPartida));
                    Invoke(new Chamavoid(SetandoOQueNaoFoiSetado));
                    ImportandoXadrezClass.PlayerDoUsuario = 1;
                    Invoke(new Chamavoid(ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa));
                    Invoke(new Chamavoid(ImportandoXadrezClass.ChecarSeOReiFoiColocadoEmXeque));
                    Invoke(new Chamavoid(DarClickNoBotaoInfo));
                }
                else if (Mensagem.StartsWith("D1V"))
                {
                    Invoke(new Chamavoid(ImportandoXadrezClass.IniciandoNovaPartida));
                    Invoke(new Chamavoid(SetandoOQueNaoFoiSetado));
                    ImportandoXadrezClass.PlayerDoUsuario = 2;
                    Invoke(new Chamavoid(ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa));
                    Invoke(new Chamavoid(ImportandoXadrezClass.ChecarSeOReiFoiColocadoEmXeque));
                    Invoke(new Chamavoid(DarClickNoBotaoInfo));
                }
                else if (Mensagem.StartsWith("S2A")
                    || Mensagem.StartsWith("S2V"))
                {
                    for (int id = 0; id < 65; id++)
                    {
                        ImportandoXadrezClass.CasaEstaOcupada[id] = Carregar.CasaEstaOcupada[id];
                        ImportandoXadrezClass.CorDaPessa[id] = Carregar.CorDaPessa[id];
                        ImportandoXadrezClass.Pessa[id] = Carregar.Pessa[id];
                        ImportandoXadrezClass.DirecaoDoPeao[id] = Carregar.DirecaoDoPeao[id];
                        ImportandoXadrezClass.APessaJaFoiMovida[id] = Carregar.APessaJaFoiMovida[id];
                        ImportandoXadrezClass.EmqualRodadaAPessaFoiMexida[id] = Carregar.EmqualRodadaAPessaFoiMexida[id];
                        ImportandoXadrezClass.PeaoAndouDuasCasas[id] = Carregar.PeaoAndouDuasCasas[id];
                    }

                    ImportandoXadrezClass.Player = Carregar.Player;
                    ImportandoXadrezClass.EmqualRodadaOplayerEstaJogando = Carregar.EmqualRodadaOplayerEstaJogando;

                    // setando oq n foi setado
                    Invoke(new Chamavoid(SetandoOQueNaoFoiSetado));

                    Invoke(new Chamavoid(ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa));
                    Invoke(new Chamavoid(ImportandoXadrezClass.ChecarSeOReiFoiColocadoEmXeque));
                    Invoke(new Chamavoid(DarClickNoBotaoInfo));


                    Invoke(new Chamavoid(ImportandoXadrezClass.SalvarJogo));

                    if (Mensagem.StartsWith("S2A"))
                    {
                        ImportandoXadrezClass.PlayerDoUsuario = 2;

                        string Oqenviar = "D2A ";

                        for (int i = 0; i < ImportandoXadrezClass.Salvar.Count; i++)
                        {
                            Oqenviar += ImportandoXadrezClass.Salvar[i];
                        }

                        EnviaDados(Oqenviar);
                    }

                    if (Mensagem.StartsWith("S2V"))
                    {
                        ImportandoXadrezClass.PlayerDoUsuario = 1;

                        string Oqenviar = "D2V ";

                        for (int i = 0; i < ImportandoXadrezClass.Salvar.Count; i++)
                        {
                            Oqenviar += ImportandoXadrezClass.Salvar[i];
                        }

                        EnviaDados(Oqenviar);
                    }


                }
                else if (Mensagem.StartsWith("D2A")
                    || Mensagem.StartsWith("D2V"))
                {


                    string DadosTratados = Mensagem.Remove(0, 4);

                    Invoke(new ChamavoidComString(RecebeinfoDotabuleiroEAtualiza_o), new object[] { DadosTratados });


                    // setando oq n foi setado
                    Invoke(new Chamavoid(SetandoOQueNaoFoiSetado));

                    Invoke(new Chamavoid(ImportandoXadrezClass.NomeDosBotoesPeloValorDaPessa));
                    Invoke(new Chamavoid(ImportandoXadrezClass.ChecarSeOReiFoiColocadoEmXeque));
                    Invoke(new Chamavoid(DarClickNoBotaoInfo));

                    if (Mensagem.StartsWith("D2A"))
                    {
                        ImportandoXadrezClass.PlayerDoUsuario = 1;
                    }
                    if (Mensagem.StartsWith("D2V"))
                    {
                        ImportandoXadrezClass.PlayerDoUsuario = 2;
                    }


                }
                else if (Mensagem.StartsWith("T"))
                {
                    Invoke(new Chamavoid(ImportandoXadrezClass.SalvarJogo));

                    string TodoOtabuleiro = "7 ";
                    for (int i = 0; i < ImportandoXadrezClass.Salvar.Count; i++)
                    {
                        TodoOtabuleiro += ImportandoXadrezClass.Salvar[i];
                    }

                    EnviaDados(TodoOtabuleiro);
                }
                else
                {
                    SetControlPropertyValue(textBoxChat, "Text", textBoxChat.Text + Mensagem + Environment.NewLine);
                    //textBoxChat.Text += Mensagem + Environment.NewLine;
                }

            }




        }


        public void EnviaAsMensagens()
        {
            try
            {
                // do host
                if (ClientEstaConectado == true)
                {
                    if (textBoxEnviaProChat.Lines.Length >= 1)
                    {
                        string StringASerEnviada = "1 " + "Azul: " + textBoxEnviaProChat.Text + Environment.NewLine;
                        string oqvaiaparecer = "Azul: " + textBoxEnviaProChat.Text + Environment.NewLine;
                        textBoxEnviaProChat.Lines = null;
                        textBoxEnviaProChat.Text = "";

                        //string Nada = "NADA";
                        //byte[] sendBytesNada = Encoding.UTF8.GetBytes(Nada);
                        //ManipulaDados.Write(sendBytesNada, 0, sendBytesNada.Length);

                        byte[] sendBytes = Encoding.UTF8.GetBytes(StringASerEnviada);
                        ManipulaDados.Write(sendBytes, 0, sendBytes.Length);
                        ManipulaDados.Flush();
                        textBoxChat.Text += oqvaiaparecer;
                    }
                    
                }
                // do client
               else if (ClientEstaConectadoComHost == true)
                {
                    if (textBoxEnviaProChat.Lines.Length >= 1)
                    {
                        string StringASerEnviada = "2 " + textBoxEnviaProChat.Text + Environment.NewLine;
                        textBoxEnviaProChat.Lines = null;
                        textBoxEnviaProChat.Text = "";

                        //string Nada = "NADA";
                        //byte[] sendBytesNada = Encoding.UTF8.GetBytes(Nada);
                        //ManipulaDados.Write(sendBytesNada, 0, sendBytesNada.Length);

                        byte[] sendBytes = Encoding.UTF8.GetBytes(StringASerEnviada);
                        ManipulaDados.Write(sendBytes, 0, sendBytes.Length);
                        ManipulaDados.Flush();
                    }

                }
            }
            catch (IOException)
            {
                // se recebe essa "Exception", é por q n tem como se comunicar com o outro lado
                if (SeServerEstaHosteado == true)
                {
                    ClientEstaConectado = false;
                    TcpClientDoCliente.Close();
                    ManipulaDados.Close();

                    ImportandoXadrezClass.PlayerDoUsuario = 3;
;
                    textBoxChat.Text += "Perdeu-se A Conexão Com O Outro Jogador," + Environment.NewLine +
                        "Espere Ele Reconectar-se Para Jogar;" + Environment.NewLine;
                }
                if (ClientEstaConectadoComHost == true)
                {
                    ClientEstaConectadoComHost = false;
                    OndeClientEstaConectado.Close();
                    ManipulaDados.Close();
                    ThreadComunica_seComHost.Abort();
                    ImportandoXadrezClass.PlayerDoUsuario = 3;

                    textBoxChat.Text += "Você Perdeu A Conexão Com O Servidor;" + Environment.NewLine;
                }

            }
            catch (Exception)
            {               
            }           
        }


        bool EnviaDados(string StringASerEnviada)
        {
            try
            {
                //string Nada = "NADA"; 
                //byte[] sendBytesNada = Encoding.UTF8.GetBytes(Nada);
                //ManipulaDados.Write(sendBytesNada, 0, sendBytesNada.Length);
                byte[] sendBytes = Encoding.UTF8.GetBytes(StringASerEnviada);
                ManipulaDados.Write(sendBytes, 0, sendBytes.Length);
                ManipulaDados.Flush();

                return true;
            }
            catch (IOException)
            {
                // se recebe essa "Exception", é por q n tem como se comunicar com o outro lado
                if (SeServerEstaHosteado == true)
                {                  
                    ClientEstaConectado = false;
                    TcpClientDoCliente.Close();
                    ManipulaDados.Close();

                    ImportandoXadrezClass.PlayerDoUsuario = 3;

                    //textBoxChat.Text += "Perdeu-se A Conexão Com O Outro Jogador," + Environment.NewLine + 
                    //    "Espere Ele Reconectar-se Para Jogar;" + Environment.NewLine;

                    SetControlPropertyValue(textBoxChat, "Text", textBoxChat.Text + "Perdeu-se A Conexão Com O Outro Jogador," + Environment.NewLine +
                        "Espere Ele Reconectar-se Para Jogar;" + Environment.NewLine);
                }
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

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        void SetandoOQueNaoFoiSetado()
        {
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
            ImportandoXadrezClass.mesagemBoxEmpate = false;
            for (int i = 0; i < 65; i++)
            {
                ImportandoXadrezClass.NaoPodeClicarNesseBotao[i] = false;
            }
            ImportandoXadrezClass.OPeaoAndouDuasCasas = false;
            ImportandoXadrezClass.ReiRivalFoiColocadoEmXequeMate = false;
            ImportandoXadrezClass.TemCasaSelecionada = false;
            ImportandoXadrezClass.ModoEditor_TemCasaSelecionada = false;

            if (ImportandoXadrezClass.Player == 1)
            {
                ImportandoXadrezClass.RivalDoPlayer = 2;
            }
            else
            {
                ImportandoXadrezClass.RivalDoPlayer = 1;
            }

            HouveEmpateMessageBox = false;
            XequemateMessageBox = false;

        }

    }
}

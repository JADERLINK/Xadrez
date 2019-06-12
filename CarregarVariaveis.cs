using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
    class CarregarVariaveis
    {
        // usado para carregar os arquivos:
        public bool[] CasaEstaOcupada = new bool[65];
        public byte[] CorDaPessa = new byte[65];
        public byte[] Pessa = new byte[65];
        public byte[] DirecaoDoPeao = new byte[65];
        public bool[] APessaJaFoiMovida = new bool[65];
        public uint[] EmqualRodadaAPessaFoiMexida = new uint[65];
        public bool[] PeaoAndouDuasCasas = new bool[65];
        public byte Player;
        public uint EmqualRodadaOplayerEstaJogando;
    }
}

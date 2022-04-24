using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oduncu_vs_GerginGorunusluAdam
{
    public class Savasci
    {
        int hiz, can, hasar;

        public int Hiz
        {
            get { return hiz; }
            set { hiz = value; }
        }

        public int Can
        {
            get { return can; }
            set { can = value; }
        }

        public int Hasar
        {
            get { return hasar; }
            set { hasar = value; }
        }

        public Savasci()
        {
            Random rand = new Random();
            this.hiz = rand.Next(1, 16); //1-15 arası hız
            this.can = rand.Next(100, 151); // 100-150 arası can
            this.hasar = rand.Next(1, 21); // 1-20 arası hasar
            Thread.Sleep(1000);
        }

        public void HasarYemek(int hasar)
        {
            this.Can -= hasar;
            if(this.Can<0)
            {
                this.Can = 0;
            }
        }
    }
}


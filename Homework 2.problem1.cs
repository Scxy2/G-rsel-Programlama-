using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Windows.Forms;
namespace Problem1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox=false;          
            this.Text = "Problem1";
            this.ClientSize = new Size(600, 600);

            Dizi_islem sayi = new Dizi_islem();
            Loc empty = new Loc(2, 2 ,0);
            Map uzay = new Map();
            
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    if(i==2 && j==2)
                    {
                        uzay.map[i*5+j*1]=0;
                        continue;
                    }
                    else {
                        int siu = sayi.random();
                        uzay.map[i * 5 + j * 1] = siu;
                        My_button ok= new My_button(i,j,siu,empty,uzay);
                        this.Controls.Add(ok);
                    }

                }
            }

        }
    }

    public class Dizi_islem
    {
        private List<int> list = new List<int>(); 

        public Dizi_islem()
        {
            for(int i=1; i<25; i++)
            {
                list.Add(i);
            }    
        }
        
        public int random()
        {
            Random rnd = new Random();
            int random = rnd.Next(0,list.Count);
            random = list[random];
            list.Remove(random);
            return random;           
        }     
    }

    public class My_button : Button
    {
        public Loc konum ;
        public Loc empty;
        public Map map;

        public My_button(int x, int y, int k, Loc f,Map m)
        {
            this.Text = string.Format("{0}", k);
            this.Size = new Size(120, 120);
            this.Location = new Point(x * 120, y * 120);
            this.konum= new Loc(x, y,k);
            this.empty = f;
            this.map= m;

        }
        protected override void OnClick(EventArgs e)
        {      
            if ((Math.Abs(konum.X - empty.X) == 1 && konum.Y == empty.Y) ||
                (Math.Abs(konum.Y - empty.Y) == 1 && konum.X == empty.X))
            {
                map.yer_degistirme(konum.X, konum.Y, konum.Z, empty.X, empty.Y, empty.Z);
                int tempX = konum.X;
                int tempY = konum.Y;
                konum.X = empty.X;
                konum.Y = empty.Y;
                empty.X = tempX;
                empty.Y = tempY;
                this.Location = new Point(konum.X * 120, konum.Y * 120);
            }
            if (map.exp())
            {
                MessageBox.Show("Baþardýn!!!");
            }
        }
    }

    public class  Loc {
        public int X { get; set; }
        public int Y { get; set; }
        
        public int Z { get; set; }

        public Loc(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;  
        }
    }

    public class Map {
        public int[] map;
        public List<int> solution;
        public Map() {
            map=new int[25];
            solution=new List<int>();

            for(int i=1;i<25;i++)
            {
                solution.Add(i);
            }
            solution.Add(0);
        } 
        public bool exp()
        {
            for (int i = 0; i < 25; i++)
            {
                if (solution[i] != map[i])
                {
                    return false;
                }             
            } 
            return true;
        }

        public void yer_degistirme(int x1, int y1, int z1, int x2, int y2, int z2) //ilk kutucugun deðerleri sonra empty degerleri 
        {
            map[x2 * 5 + y2 * 1] = z1;
            map[x1 * 5 + y1 * 1] = z2;

        }
        
    }
}

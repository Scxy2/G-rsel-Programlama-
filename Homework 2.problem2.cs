using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

namespace Problem2
{
    public partial class Form1 : Form
    {
        private List<My_button> buttons = new List<My_button>();
        public int[] boyutlar = new int[2];
        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new Size(600, 600);
            boyutlar[0]=ClientSize.Width;
            boyutlar[1]=ClientSize.Height;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Problem2";
            this.Resize += Form1_Resize;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dizi_islem sayi = new Dizi_islem();
            Loc empty = new Loc(2, 2, 0);
            Map uzay = new Map();

            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    if (i == 2 && j == 2)
                    {
                        uzay.map.Add(0);
                        continue;
                    }
                    else
                    {
                        int siu = sayi.random();
                        uzay.map.Add(siu);
                        My_button ok = new My_button(i, j, siu, empty, uzay,boyutlar);
                        buttons.Add(ok);
                        this.Controls.Add(ok);
                    }

                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            boyutlar[0]=ClientSize.Width;
            boyutlar[1]=ClientSize.Height;
            ResizeButtons();
        }

        private void ResizeButtons()
        {
            int buttonwidth= ClientSize.Width / 5;
            int buttonheight = ClientSize.Height / 5;
            foreach (My_button button in buttons)
            {
                button.Size = new Size(buttonwidth, buttonheight);
                button.Location = new Point(button.konum.X * buttonwidth, button.konum.Y * buttonheight);
            }
        }
    }

    public class Dizi_islem
    {
        private List<int> list = new List<int>();

        public Dizi_islem()
        {
            for (int i = 1; i < 25; i++)
            {
                list.Add(i);
            }
        }

        public int random()
        {
            Random rnd = new Random();
            int random = rnd.Next(0, list.Count);
            random = list[random];
            list.Remove(random);
            return random;
        }
    }

    public class My_button : Button
    {
        public Loc konum;
        public Loc empty;
        public Map map;
        public int[] boyut;

        public My_button(int x, int y, int k, Loc f, Map m, int[] boyut)
        {
            this.Text = string.Format("{0}", k);
            this.Size = new Size(boyut[0] / 5, boyut[1] / 5);
            this.Location = new Point(x * boyut[0] / 5, y* boyut[1] / 5);
            this.konum = new Loc(x, y, k);
            this.empty = f;
            this.map = m;
            this.boyut = boyut;
        }
        protected override void OnClick(EventArgs e)
        {
            if ((Math.Abs(konum.X - empty.X) == 1 && konum.Y == empty.Y) ||
                (Math.Abs(konum.Y - empty.Y) == 1 && konum.X == empty.X))
            {
                this.map.yer_degistirme(konum.X, konum.Y, konum.Z, empty.X, empty.Y, empty.Z);              
                int tempX = konum.X;
                int tempY = konum.Y;
                konum.X = empty.X;
                konum.Y = empty.Y;
                empty.X = tempX;
                empty.Y = tempY;
                this.Location = new Point(konum.X * boyut[0] / 5, konum.Y * boyut[1] / 5);
            }

            if (map.exp())
            {
                MessageBox.Show("Baþardýn!!!");

            }
        }
    }

    public class Loc
    {
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

    public class Map
    {
        public List<int> map;
        public List<int> solution;
        public Map()
        {
            map = new List<int>();
            solution = new List<int>();

            for (int i = 1; i < 25; i++)
            {
                solution.Add(i);
            }
            solution.Add(0);
        }
        public bool exp()
        {
            for (int i = 0; i < 25; i++)
            {
                if (solution[i] == map[i])
                {
                    continue;
                }
                else
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

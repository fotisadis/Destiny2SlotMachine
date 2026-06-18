using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Destiny2SlotMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int p1;//δηλώνω τα αντικείμενα μου(εικόνες)
        public static int p2;
        public static int p3;

        public static long credits = 100;//δηλώνω το glimmer και το chance 
        public static long total = 0;
        public static int bet = 5;

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("1.png");
            pictureBox2.Image = Image.FromFile("2.png");
            pictureBox3.Image = Image.FromFile("3.png");
        }
        public static class IntUtil//φτιαχνει τυχαίους αριθμούς
        {
            private static Random random;

            private static void Init()
            {
                if (random == null) random = new Random();
            }
            public static int Random (int min,int max)
            {
                Init();
                return random.Next(min,max);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (credits >=bet)//συνθήκη για να μπορώ να παίξω
            {
                credits = credits - bet;
                label1.Text = "Glimmer:" + credits.ToString();
                for (var i=0;i<10;i++)
                {
                    p1 = IntUtil.Random(1, 4);//δίνω τυχαίους αριθμούς 1-3 στις εικόνες
                    p2 = IntUtil.Random(1, 4);
                    p3 = IntUtil.Random(1, 4);
                }
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();//αν υπάρχει κάτι στο picturebox δίνουμε μια τυχαία εικόνα βάση του τυχαίου αριθμού που πηρε από την κλάση
                pictureBox1.Image = Image.FromFile(p1.ToString() + ".png");

                if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
                pictureBox2.Image = Image.FromFile(p2.ToString() + ".png");

                if (pictureBox3.Image != null) pictureBox3.Image.Dispose();
                pictureBox3.Image = Image.FromFile(p3.ToString() + ".png");
                total = 0;
                //δημιουργία συνθηκών για να κερδίσουμε glimmer βάση των τυχαίων αριθμών
                if (p1 == 3) total = total + 5;

                if (p1 == 2 & p2 == 2) total = total + 10;
                if (p1 == 3 & p2 == 3) total = total + 10;

                if (p1 == 1 & p2 == 1 & p3 == 1) total = total + 20;
                if (p1 == 2 & p2 == 2 & p3 == 2) total = total + 30;
                if (p1 == 3 & p2 == 3 & p3 == 3) total = total + 50;

                credits = credits + total;//γίνεται υπολογισμός των glimmer και εμφανίζουμε τις τελικές τιμές win kai glimmer
                label3.Text="Win:" + total.ToString();
                label1.Text = "Glimmer:" + credits.ToString();

            }
        }
    }


}

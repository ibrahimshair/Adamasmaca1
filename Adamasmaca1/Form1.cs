using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adamasmaca1
{
    

    public partial class Form1 : Form
    {
        string[] iller = {
            "Adana","Adiyaman","Afyonkarahisar","Agri","Aksaray","Amasya","Ankara","Artvin","Aydin","Balikesir","Bilecik","Bingol","Bitlis","Bolu","Burdur","Bursa","Canakkale","Cankiri",
            "Corum","Denizli","Diyarbakir","Edirne","Elazig","Erzincan","Erzurum","Eskisehir","Gaziantep","Giresun","Gumushane","Hakkari","Hatay","Igdir","Isparta","Istanbul","Izmir",
            "Kahramanmaras","Karabuk","Karaman","Kars","Kastamonu","Kayseri","Kirikkale","Kirklareli","Kirsehir","Kilisim","Kocaeli","Konya","Kutahya","Malatya","Manisa","Mardin",
            "Mersin","Mugla","Mus","Nevsehir","Nigde","Ordu","Osmaniye","Rize","Sakarya","Samsun","Siirt","Sinop","Sivas","Tekirdag","Tokat","Trabzon","Tunceli","Sanlıurfa",
            "Usak","Van","Yalova","Yozgat","Zonguldak"
        };

        private string secilenIl;

        public Form1()
        {
            InitializeComponent();
          
            Random r = new Random();
            int index = r.Next(iller.Length);
            secilenIl = iller[index].ToUpper(); // seçilen ili büyük harfle yaz
            label10.Text = new string('-', secilenIl.Length); // seçilen ili - halinde yaz
            
        }

        private void RastgeleIlGoster()
        {
            Random r = new Random();
            int index = r.Next(iller.Length);
            secilenIl = iller[index].ToUpper(); // yeni il seçiliyor
            label10.Text = Gizle(secilenIl); // yeni kelimeyi şifrele
            label2.Text = "6"; // kalan hak 6
            hata = 0; // hata sayısını sıfırla
            pictureBox1.Load("Resimler/0.png"); //  birinci fotoğraf
        }


        private string Gizle(string a)
        {
            return new string('-', a.Length); // seçilen ili - halinde yaz
        }

        private void button27_Click(object sender, EventArgs e)
        {
            string girilenHarf = textBox1.Text.ToUpper(); // girilen harf büyük olsun 

            if (girilenHarf.Length == 1) // sadece bir harf girilsin
            {
                string yeniGizlenmisIl = ""; //güncellenmiş gizlenmiş il
                bool harfBulundu = false; // Hhrarf kelimede var mı

                for (int i = 0; i < secilenIl.Length; i++)
                {
                    if (secilenIl[i].ToString().ToUpper() == girilenHarf)
                    {
                        yeniGizlenmisIl += secilenIl[i]; // Ddoğru harfi ekle
                        harfBulundu = true; // harf bulundu
                    }
                    else
                    {
                        yeniGizlenmisIl += label10.Text[i]; // gizli karakter kalsın
                    }
                }

                label10.Text = yeniGizlenmisIl; // güncellenmiş gizlenmiş il

                // kelime tamamlandıysa
                if (label10.Text == secilenIl)
                {
                    MessageBox.Show("Tebrikler! Doğru bildiniz!"); // kullanıcıyı tebrik et
                    if (int.TryParse(label4.Text, out int mevcutDeğer))
                    {
                        mevcutDeğer++;
                        label4.Text = mevcutDeğer.ToString(); // yeni değeri label4'e yaz
                    }
                    RastgeleIlGoster(); // yeni kelimeyi seç
                    return; // işlemi sonlandır
                }

                // harf bulunmadıysa
                if (!harfBulundu)
                {
                    if (int.TryParse(label2.Text, out int kalanHak)) // label2 deki sayıyı kontrol et
                    {
                        kalanHak--; // kalan hakkı 1 azalt
                        label2.Text = kalanHak.ToString(); // yeni kalan hakkı göster
                        hata++; // hata sayısını 1 artır
                        MessageBox.Show($"Yanlış harf! Kalan hak: {kalanHak}"); // kullanıcıya hak hakkında bilgi ver

                        // resmi güncelle
                        pictureBox1.Load($"Resimler/{hata}.png");

                        // kalan hak sıfır olduğunda kaybettin mesajı göster
                        if (kalanHak <= 0)
                        {
                            MessageBox.Show("Kaybettiniz!"); // kaybettiniz mesajı ver
                            label4.Text = "0"; // Label4 ü 0 a dönsün
                            RastgeleIlGoster(); // Yeni kelimeyi seç
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen sadece bir harf girin!"); // Hata mesajı ver
            }

            textBox1.Clear(); // TextBox ı temizle
        }


        int hata = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Load("Resimler/" + hata + ".png"); 
            
        }

        private void label10_Click(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        
    }
}

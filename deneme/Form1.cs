/********************************************************************************************************************
**                                              SAKARYA ÜNİVERSİTESİ 
**                                   BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**                                    BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ
**                                      NESENEYE DAYALI PROGRAMLAMA DERSİ
**                                           2018-2019 BAHAR DÖNEMİ
**
**
**                                                  ÖDEV NUMARASI:1
**                                               ÖĞRENCİ ADI:BERK TUNÇ
**                                                   NO:B171200016
**
**************************************************************************************************************************/
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

namespace deneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();                   //Dosya açılmasını sağlar.
            if (dosya.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            else
            {
                StreamReader okuma = new StreamReader(dosya.FileName);   //Dosyanın okunmasını sağlar.
                richTextBox1.Text = okuma.ReadToEnd();
                okuma.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string alinanTc = tcno.Text.Trim();   //string değerin başındaki ve sonundaki boşlukları siler.
            string[] satirlar;
            string veriler = richTextBox1.Text;
            satirlar = veriler.Split('\n');   //Dosya satırlara ayırma.

            double maas;




            if (tcno.Text == String.Empty)           //  TC no bölümü boş bırakılırsa mesaj kutusu açılacak.
            {
                MessageBox.Show("Lütfen TC no Giriniz...");
                tcno.Focus(); //tcno metnine odaklanır.imleç çıkar.
            }

            else if (tcno.Text.Length < 11 || tcno.Text.Length > 11) //TC no bölümüne 11 den eksik veya fazla karakter girildiğinde mesaj kutusu açılacak
            {
                MessageBox.Show("GİRDİĞİNİZ TC no 11 HANELİ DEĞİLDİR");
                tcno.Focus(); //tcno metnine odaklanır.imleç çıkar.
            }







            else
            {
                foreach (string s in satirlar)   //personel bilgileri ayrıştırma.
                {
                    string[] kelimeler = s.Split(' '); //Bir dizgeyi belirli bir ayraç ile parçalayıp, parçalardan bir dizi döndürür.

                    if (kelimeler[0] == alinanTc)    // Eğer 0. index alinantc ye eşit ise aşağıdaki işlemler uygulanır(bloğa girilir).
                    {

                        ad.Text = kelimeler[1];
                        soyad.Text = kelimeler[2];
                        yas.Text = kelimeler[3];
                        calismaSuresi.Text = kelimeler[4];
                        evlilikDurumu.Text = kelimeler[5];
                        esiCalisiyormu.Text = kelimeler[6];                        //Dizideki personel bilgilerini ilgili textboxlara  yazdırır.
                        cocukSayisi.Text = kelimeler[7];
                        tabanMaas.Text = kelimeler[8];
                        makamTazminati.Text = kelimeler[9];
                        idariGorevTazminati.Text = kelimeler[10];
                        fazlaMesai.Text = kelimeler[11];
                        fazlaMesaiUcreti.Text = kelimeler[12];
                        vergiMatrahi.Text = kelimeler[13];
                        resimyolu.Text = kelimeler[14];

                        




                        
                            pictureBox1.Image = Image.FromFile(kelimeler[14]);   //Dizinin 14. sırasındaki yolu alır picturebox'a ekler.


                            if (pictureBox1.Image.Width > pictureBox1.Width && pictureBox1.Image.Height > pictureBox1.Height)

                            {                                                                                                    //Alınan resmi picturebox'a sığdırmayı sağlar.

                                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                            }

                            

                        

                        int cocuk_Sayisi = Convert.ToInt32(cocukSayisi.Text);
                        double fazla_mesai = Convert.ToInt32(fazlaMesai.Text);
                        double vergi_matrahi = Convert.ToInt32(vergiMatrahi.Text);
                        double taban_Maas = Convert.ToInt32(tabanMaas.Text);
                        double fazlamesai_ucreti = Convert.ToInt32(fazlaMesaiUcreti.Text);                  //Dönüştürme işlemleri yapılır.
                        double idarigorev_tazminati = Convert.ToInt32(idariGorevTazminati.Text);
                        double makam_Tazminati = Convert.ToInt32(makamTazminati.Text);




                        if (evlilikDurumu.Text == "B")
                        {
                            double brutMaas = taban_Maas + makam_Tazminati + idarigorev_tazminati + (cocuk_Sayisi * 30) + (fazla_mesai * fazlamesai_ucreti); // Brüt maaş bu işlemler sonucunda elde edilir.
                            double emekliVergisi = brutMaas * 0.15;        // Brüt maaşın yüzde 15 i emekli vergisine eşittir.
                            double damgaVergisi = brutMaas * 0.10;        //Brüt maaşın yüzde 10 u damga vergisine eşittir.
                            double gelirVergisi = 0;                      //Gelir vergisine 0 değer atadık.Aşağıdaki işlemler sonucu bulunacak




                            if (vergi_matrahi < 10000)             // Vergi matrahı 10000 den küçük ise gelir vergisi
                            {
                                gelirVergisi = brutMaas * 0.15;
                            }
                            else if (vergi_matrahi >= 10000 && vergi_matrahi < 20000)  //Vergi matrahı 10000(dahil) ile 20000 arasında ise gelir vergisi.
                            {
                                gelirVergisi = brutMaas * 0.20;
                            }
                            else if (vergi_matrahi >= 20000 && vergi_matrahi < 30000) //Vergi matrahı 20000(dahil) ile 30000 arasında ise gelir vergisi.
                            {
                                gelirVergisi = brutMaas * 0.25;
                            }
                            else                                                  // Vergi matrahı 30000 e eşit ve 30000 den büyük ise gelir vergisi.
                                gelirVergisi = brutMaas * 0.30;

                            textBox2.Text = Convert.ToString(brutMaas);
                            textBox3.Text = Convert.ToString(damgaVergisi);
                            textBox5.Text = Convert.ToString(emekliVergisi);   //İlgili metin kutularına yazdırma.(dönüştürerek)
                            textBox4.Text = Convert.ToString(gelirVergisi);

                            maas = brutMaas - (emekliVergisi + gelirVergisi + damgaVergisi); //4 işlem yapıldı.Net maaş bulundu.
                            alinanMaas.Text = Convert.ToString(maas);  //Metin kutusuna dönüştürme işlemi yapılarak Neet maaş yazıldı.

                        }


                         else if (evlilikDurumu.Text == "E" && esiCalisiyormu.Text == "E") // Evli ve eşi çalışıyor ise.
                        {

                            double brutMaas = taban_Maas + makam_Tazminati + idarigorev_tazminati + (cocuk_Sayisi * 30) + (fazla_mesai * fazlamesai_ucreti); // Brüt maaş bu işlemler sonucunda elde edilir.
                            double emekliVergisi = brutMaas * 0.15;  // Brüt maaşın yüzde 15 i emekli vergisine eşittir.
                            double damgaVergisi = brutMaas * 0.10;   //Brüt maaşın yüzde 10 u damga vergisine eşittir.
                            double gelirVergisi = 0;                 //Gelir vergisine 0 değer atadık.Aşağıdaki işlemler sonucu bulunacak

                            if (vergi_matrahi < 10000)              // Vergi matrahı 10000 den küçük ise gelir vergisi.
                            {
                                gelirVergisi = brutMaas * 0.15;
                            }
                            else if (vergi_matrahi >= 10000 && vergi_matrahi < 20000)   //Vergi matrahı 10000 ile 20000 arasında ise gelir vergisi.
                            {
                                gelirVergisi = brutMaas * 0.20;
                            }
                            else if (vergi_matrahi >= 20000 && vergi_matrahi < 30000)   //Vergi matrahının 20000 ile 30000 arasında ise gelir vergisi.
                            {
                                gelirVergisi = brutMaas * 0.25;
                            }
                            else                                               // Vergi matrahı 30000 e eşit ve 30000 den büyük  ise gelir vergisi.
                                gelirVergisi = brutMaas * 0.30;

                            if (kelimeler[14] == "") // Eğer 14. index boş ise bloğa gir.
                            {
                                MessageBox.Show("FOTOGRAF BULUNMAMAKTADIR!");       //Dosyada foto yoksa mesaj kutusu açılacak.
                            }
                            else
                            {
                                pictureBox1.Image = Image.FromFile(kelimeler[14]);   //Dizinin 14. sırasındaki yolu alır picturebox'a ekler.


                                if (pictureBox1.Image.Width > pictureBox1.Width && pictureBox1.Image.Height > pictureBox1.Height)

                                {                                                                                                    //Alınan resmi picturebox'a sığdırmayı sağlar.

                                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                                }

                                else
                                {

                                    return;
                                }
                            }
                            textBox2.Text = Convert.ToString(brutMaas);
                            textBox3.Text = Convert.ToString(damgaVergisi);
                            textBox5.Text = Convert.ToString(emekliVergisi);   //İlgili metin kutularına yazdırma.(dönüştürerek)
                            textBox4.Text = Convert.ToString(gelirVergisi);

                            maas = brutMaas - (emekliVergisi + gelirVergisi + damgaVergisi);  //4 işlem yapıldı.Net maaş bulundu.
                            alinanMaas.Text = Convert.ToString(maas);  //Metin kutusuna dönüştürme işlemi yapılarak Neet maaş yazıldı.
                        }

                        if (evlilikDurumu.Text == "E" && esiCalisiyormu.Text == "H")  //Evli ve eşi çalışmıyorsa.
                        {

                            double brutMaas = taban_Maas + makam_Tazminati + idarigorev_tazminati + 200 + (cocuk_Sayisi * 30) + (fazla_mesai * fazlamesai_ucreti);  // Brüt maaş bu işlemler sonucunda elde edilir.
                            double emekliVergisi = brutMaas * 0.15;  // Brüt maaşın yüzde 15 i emekli vergisine eşittir.
                            double damgaVergisi = brutMaas * 0.10;   //Brüt maaşın yüzde 10 u damga vergisine eşittir.
                            double gelirVergisi = 0;                 //Gelir vergisine 0 değer atadık.Aşağıdaki işlemler sonucu bulunacak

                            if (vergi_matrahi < 10000)        // Vergi matrahının 10000 den küçük ise gelir vergisi.
                            {
                                gelirVergisi = brutMaas * 0.15;
                            }
                            else if (vergi_matrahi >= 10000 && vergi_matrahi < 20000)    //Vergi matrahı 10000 ile 20000 arasında ise gelir vergisi.
                            {
                                gelirVergisi = brutMaas * 0.20;
                            }
                            else if (vergi_matrahi >= 20000 && vergi_matrahi < 30000)   //Vergi matrahının 20000 ile 30000 arasında ise gelir vergisi.
                            {
                                gelirVergisi = brutMaas * 0.25;
                            }
                            else                                   // Vergi matrahı 30000 e eşit ve 30000 den büyük  ise gelir vergisi.
                                gelirVergisi = brutMaas * 0.30;

                            maas = brutMaas - (emekliVergisi + gelirVergisi + damgaVergisi);  //4 işlem yapıldı.Net maaş bulundu.
                            alinanMaas.Text = Convert.ToString(maas);  //Metin kutusuna dönüştürme işlemi yapılarak Neet maaş yazıldı.

                            textBox2.Text = Convert.ToString(brutMaas);
                            textBox3.Text = Convert.ToString(damgaVergisi);
                            textBox5.Text = Convert.ToString(emekliVergisi);    //İlgili metin kutularına yazdırma.(dönüştürerek)
                            textBox4.Text = Convert.ToString(gelirVergisi);


                        }
                    }
                }
            }
        }
    }
}

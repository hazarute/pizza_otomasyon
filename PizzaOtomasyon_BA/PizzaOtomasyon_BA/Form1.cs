using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOtomasyon_BA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<PizzaCesitleri> pizzaCesitleri = new List<PizzaCesitleri>();
        List<Ebatlar> ebatlar = new List<Ebatlar>();
        List<Malzemeler> malzemeler = new List<Malzemeler>();
        List<Siparis> siparisler = new List<Siparis>();

        private void Form1_Load(object sender, EventArgs e)
        {
            pizzaCesitleri.Add(new PizzaCesitleri("Klasik", 14));
            pizzaCesitleri.Add(new PizzaCesitleri("Karışık", 17));
            pizzaCesitleri.Add(new PizzaCesitleri("ExtraVaganza", 21));
            pizzaCesitleri.Add(new PizzaCesitleri("Italiano", 20));
            pizzaCesitleri.Add(new PizzaCesitleri("Turkish", 23));
            pizzaCesitleri.Add(new PizzaCesitleri("Tuna", 18));
            pizzaCesitleri.Add(new PizzaCesitleri("SeaFeed", 19));
            pizzaCesitleri.Add(new PizzaCesitleri("Kastamonu", 20));
            pizzaCesitleri.Add(new PizzaCesitleri("Calypso", 24));
            pizzaCesitleri.Add(new PizzaCesitleri("Akdeniz", 21));
            pizzaCesitleri.Add(new PizzaCesitleri("Karadeniz", 21));

            lbPizzalar.DataSource = pizzaCesitleri;
            lbPizzalar.DisplayMember = "_pizzaIsmi";
            lbPizzalar.ValueMember = "_pizzaFiyat";


            ebatlar.Add(new Ebatlar("Maxi", 2));
            ebatlar.Add(new Ebatlar("Büyük", 1.75));
            ebatlar.Add(new Ebatlar("Orta", 1.25));
            ebatlar.Add(new Ebatlar("Küçük", 1));

            cmbEbatlar.DataSource = ebatlar;
            cmbEbatlar.DisplayMember = "_ebatIsmi";
            cmbEbatlar.ValueMember = "_ebatFiyatCarpani";
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            HesaplaButonBas();
        }
        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            HesaplaButonBas();
            malzemeler.Clear();
            SiparisOlustur();

            double toplamTutar = 0;
            foreach (Siparis item in siparisler)
            {
                Siparis sp = (Siparis)item;
                toplamTutar = toplamTutar + sp._sTutar;
            }

            lblToplamTutar.Text = toplamTutar.ToString();
        }

        private void btnSiparisiOnayla_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Toplam" + " " + lbSiparis.Items.Count + " " + "Adet siparişiniz" + Environment.NewLine + lblToplamTutar.Text + " " + "TL Tutarındadır.");
        }

        private void SiparisOlustur()
        {
            try
            {
                Siparis siparis = new Siparis();
                siparis._sEbat = cmbEbatlar.Text.ToString();
                if (rbKalinKenar.Checked)
                    siparis._sKenarCesidi = rbKalinKenar.Text.ToString();
                else
                    siparis._sKenarCesidi = rbInceKenar.Text.ToString();

                foreach (Control item in gbMalzemeler.Controls)
                {
                    if (item is CheckBox)
                    {
                        CheckBox cb = (CheckBox)item;
                        if (cb.Checked)
                        {
                            malzemeler.Add(new Malzemeler(cb.Text.ToString()));
                        }
                    }
                }

                siparis._sMalzemeler = malzemeler;
                siparis._sPizzaIsmi = lbPizzalar.Text.ToString();
                siparis._sTutar = sTutar;

                lbSiparis.Items.Add(siparis.ToString());
                siparisler.Add(siparis);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private double sTutar;
        private void HesaplaButonBas()
        {
            try
            {
                double kenarCesidi = 0;
                if (rbKalinKenar.Checked)
                {
                    kenarCesidi = 2;
                }
                double tutar = 0, ebat, adet, pizzaFiyati;
                ebat = Convert.ToDouble(cmbEbatlar.SelectedValue);
                adet = Convert.ToDouble(txtAdet.Text);
                pizzaFiyati = Convert.ToDouble(lbPizzalar.SelectedValue);

                txtTutar.Text = ToplamHesapla(tutar, ebat, adet, pizzaFiyati, kenarCesidi).ToString();
                sTutar = Convert.ToDouble(txtTutar.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen Adet Bölümüne Geçerli bir sayı giriniz.");
            }
        }

        private object ToplamHesapla(double tutar, double ebat, double adet, double pizzaFiyati, double kenarCesidi)
        {
            return tutar = ((adet * pizzaFiyati) * ebat) + (adet * kenarCesidi);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace erogluotomasyonproje
{
    public partial class Form6 : Form
    {
        OleDbConnection connection;
        OleDbDataAdapter adapter;
        OleDbDataReader dataReader;
        OleDbCommand command;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=eroglu.accdb");
            connection.Open();
            adapter = new OleDbDataAdapter("select * from siparisler", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            int kolonsayisi = table.Rows.Count;
            dataGridView1.DataSource = table;

            adapter = new OleDbDataAdapter("select * from musteri",connection);
            DataTable table2 = new DataTable();
            adapter.Fill(table2);
            int musterisayisi = table2.Rows.Count;

            adapter = new OleDbDataAdapter("select * from aku", connection);
            DataTable table3 = new DataTable();
            adapter.Fill(table3);
            int akucesit = table3.Rows.Count;
            connection.Close();
            
            gunaAreaDataset1.DataPoints.Add("Akü Çeşit Sayısı",akucesit);
            gunaAreaDataset1.DataPoints.Add("Müşteri Sayısı", musterisayisi);
            gunaAreaDataset1.DataPoints.Add("Sipariş Sayısı", kolonsayisi);
            
          

            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#de6262");






        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            settings settings = new settings();
            settings.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        

        

        

        

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from siparisler where TC='" + textBox4.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        adapter = new OleDbDataAdapter("select * from siparisler where TC='" + textBox4.Text + "'", connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu TC ile kayıtlı müşteri bulunmamakta !!");
                        connection.Close();
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Bir hata oluştu");
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Lütfen TC kısmını doğru giriniz !!");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            connection.Open();
            adapter = new OleDbDataAdapter("select * from siparisler", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox5.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from aku where Kod='" + textBox3.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        adapter = new OleDbDataAdapter("select * from aku where Kod='" + textBox3.Text + "'", connection);
                        DataTable table2 = new DataTable();
                        adapter.Fill(table2);
                        string b = table2.Rows[0]["Adet"].ToString();
                        int stok = Convert.ToInt32(b) - Convert.ToInt32(textBox2.Text);
                        if (stok >= 0)
                        {
                            command = new OleDbCommand("select * from musteri where TC='" + textBox1.Text + "'", connection);
                            dataReader = command.ExecuteReader();
                            if (dataReader.Read())
                            {
                                adapter = new OleDbDataAdapter("select * from aku where Kod='" + textBox3.Text + "'", connection);
                                DataTable table = new DataTable();
                                adapter.Fill(table);
                                string a = table.Rows[0]["Fiyatı"].ToString();
                                string akuAdet = table.Rows[0]["Adet"].ToString();
                                int ucret = Convert.ToInt32(a) * Convert.ToInt32(textBox2.Text);
                                adapter = new OleDbDataAdapter("select * from musteri where TC='" + textBox1.Text + "'", connection);
                                DataTable table3 = new DataTable();
                                adapter.Fill(table3);
                                string odeme = table3.Rows[0]["ödeme"].ToString();
                                string il = table3.Rows[0]["il"].ToString();
                                string ilce = table3.Rows[0]["ilçe"].ToString();
                                string adres = table3.Rows[0]["Adres"].ToString();
                                command = new OleDbCommand("insert into siparisler(TC,ödeme,Adet,Kod,il,ilçe,Adres,ucret,siparisno,Tarih) values('" + textBox1.Text + "','" + odeme + "','" + textBox2.Text + "','" + textBox3.Text + "','" + il + "','" + ilce + "','" + adres + "','" + ucret.ToString() + "','" + textBox5.Text + "','" + DateTime.Now.ToString() + "')", connection);
                                command.ExecuteNonQuery();
                                int kalanStok = Convert.ToInt32(akuAdet) - Convert.ToInt32(textBox2.Text);
                                command = new OleDbCommand("update aku set Adet='" + kalanStok.ToString() + "' where Kod='" + textBox3.Text + "'", connection);
                                command.ExecuteNonQuery();

                                MessageBox.Show("Sipariş oluşturuldu");
                            }
                            else
                                MessageBox.Show("Bu TC ile kayıtlı müşteri bulunamadı");
                        }
                        else
                            MessageBox.Show("Stok Yetersiz !!");
                        connection.Close();

                    }
                    else
                    {
                        MessageBox.Show("Hatalı kod girdiniz !!");
                        connection.Close();
                    }

                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata oluştu");
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Boş alan bırakmayınız");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox5.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from siparisler where TC='" + textBox1.Text + "' and siparisno='" + textBox5.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {

                        command = new OleDbCommand("delete from siparisler where TC='" + textBox1.Text + "' and siparisno='" + textBox5.Text + "'", connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Sipariş başarıyla silindi");

                    }
                    else
                    {
                        MessageBox.Show("Bu TC ile kayıtlı sipariş bulunamadı !!");
                        connection.Close();
                    }

                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata oluştu");
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Boş alan bırakmayınız");
        }

        

        private void yenileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            InitializeComponent();
        }
    }
}

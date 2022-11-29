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
    public partial class Form5 : Form
    {
        string dosyaAdi;
        OleDbConnection connection;
        OleDbDataAdapter adapter;
        OleDbDataReader dataReader;
        OleDbCommand command;
        public Form5()
        {
            InitializeComponent();
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

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=eroglu.accdb");
            connection.Open();
            adapter = new OleDbDataAdapter("select TC,Marka,Plaka,Tipi,Volt from arac",connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#de6262");

        }

        

        

        

        

        

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                guna2CirclePictureBox1.Image = new Bitmap(open.FileName);
                dosyaAdi = open.FileName;

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox4.Text != "" && dosyaAdi != null)
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from musteri where TC='" + textBox1.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        command = new OleDbCommand("select * from arac where TC='" + textBox1.Text + "'", connection);
                        dataReader = command.ExecuteReader();
                        if (dataReader.Read())
                        {
                            MessageBox.Show("Bu TC ile kayıtlı araç bulunmakta !!");
                            connection.Close();
                        }
                        else
                        {
                            command = new OleDbCommand("insert into arac(TC,Marka,Plaka,Tipi,Volt,Resim) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox4.Text + "','" + textBox4.Text + "','" + dosyaAdi + "')", connection);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Araç bilgileri başarıyla kaydedildi");
                            connection.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu TC ile kayıtlı müşteri bulunamadı");
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
                MessageBox.Show("Lütfen boş yer bırakmayınız !!");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from arac where TC='" + textBox1.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        command = new OleDbCommand("delete from arac where TC='" + textBox1.Text + "'", connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Araç bilgileri başarıyla silindi");
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu TC ile kayıtlı araç bulunmamakta !!");
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
                MessageBox.Show("Lütfen TC bilgisini doldurunuz !!");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox4.Text != "" && dosyaAdi != null)
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from arac where TC='" + textBox1.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        command = new OleDbCommand("update arac set Marka='" + textBox2.Text + "',Plaka='" + textBox3.Text + "',Tipi='" + comboBox4.Text + "',Volt='" + textBox4.Text + "',Resim='" + dosyaAdi + "' where TC='" + textBox1.Text + "'", connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Araç bilgileri başarıyla güncellendi");
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu TC ile kayıtlı araç bulunmamakta !!");
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
                MessageBox.Show("Lütfen boş yer bırakmayınız !!");
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from arac where TC='" + textBox5.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        adapter = new OleDbDataAdapter("select * from arac where TC='" + textBox5.Text + "'", connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                        connection.Close();

                        connection.Open();

                        adapter = new OleDbDataAdapter("select Resim from arac where TC='" + textBox5.Text + "'", connection);
                        DataTable ds = new DataTable();
                        adapter.Fill(ds);
                        string a = ds.Rows[0]["Resim"].ToString();
                        if (a != null)
                        {
                            guna2CirclePictureBox1.Image = new Bitmap(a);
                        }
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu TC ile kayıtlı araç bulunmamakta !!");
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
                MessageBox.Show("Lütfen TC bilgisini doğru giriniz !!");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            connection.Open();
            adapter = new OleDbDataAdapter("select TC,Marka,Plaka,Tipi,Volt from arac", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeComponent();
        }
    }
}

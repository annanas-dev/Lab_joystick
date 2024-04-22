using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_7_TP
{
    public partial class Form1 : Form
    {

        private int xCoord = 0;
        private int zCoord = 0;
        private int angle = 0;
        private bool xMoving = false;
        private bool zMoving = false;
        private bool rotating = false;
        private bool xMode = true;

        public Form1()
        {
            InitializeComponent();
            button9.Click += button9_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            xMode = true;
            label1.Text = "Режим: XT";
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = false;
            button8.Enabled = false;
        }

        private void UpdateCoordinates()
        {
            listBox1.Items.Add($"X: {xCoord}, Z: {zCoord}, Угол: {angle}°");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!xMoving)
            {
                xMoving = true;
                Timer xTimer = new Timer();
                xTimer.Interval = 100;
                xTimer.Tick += (s, ev) =>
                {
                    xCoord++;
                    UpdateCoordinates();
                    if (!xMoving)
                        xTimer.Stop();
                };
                xTimer.Start();
            }
            else
            {
                xMoving = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!xMoving)
            {
                xMoving = true;
                Timer xTimer = new Timer();
                xTimer.Interval = 100;
                xTimer.Tick += (s, ev) =>
                {
                    xCoord--;
                    UpdateCoordinates();
                    if (!xMoving)
                        xTimer.Stop();
                };
                xTimer.Start();
            }
            else
            {
                xMoving = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!zMoving)
            {
                zMoving = true;
                Timer zTimer = new Timer();
                zTimer.Interval = 100;
                zTimer.Tick += (s, ev) =>
                {
                    zCoord++;
                    UpdateCoordinates();
                    if (!zMoving)
                        zTimer.Stop();
                };
                zTimer.Start();
            }
            else
            {
                zMoving = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!zMoving)
            {
                zMoving = true;
                Timer zTimer = new Timer();
                zTimer.Interval = 100;
                zTimer.Tick += (s, ev) =>
                {
                    zCoord--;
                    UpdateCoordinates();
                    if (!zMoving)
                        zTimer.Stop();
                };
                zTimer.Start();
            }
            else
            {
                zMoving = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!rotating)
            {
                rotating = true;
                Timer rotateTimer = new Timer();
                rotateTimer.Interval = 100;
                rotateTimer.Tick += (s, ev) =>
                {
                    angle += 10;
                    if (angle >= 360)
                        angle -= 360;
                    UpdateCoordinates();
                    if (!rotating)
                        rotateTimer.Stop();
                };
                rotateTimer.Start();
            }
            else
            {
                rotating = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!rotating)
            {
                rotating = true;
                Timer rotateTimer = new Timer();
                rotateTimer.Interval = 100;
                rotateTimer.Tick += (s, ev) =>
                {
                    angle -= 10;
                    if (angle < 0)
                        angle += 360;
                    UpdateCoordinates();
                    if (!rotating)
                        rotateTimer.Stop();
                };
                rotateTimer.Start();
            }
            else
            {
                rotating = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            xMoving = false;
            zMoving = false;
            rotating = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            xMode = !xMode;
            if (xMode)
            {
                label1.Text = "Режим: XT";
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = false;
                button8.Enabled = false;
            }
            else
            {
                label1.Text = "Режим: ZX";
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); 
            xCoord = 0; 
            zCoord = 0; 
            angle = 0; 
            xMoving = false; 
            zMoving = false; 
            rotating = false; 

            xMode = true;
            label1.Text = "Режим: XT";
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = false;
            button8.Enabled = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Сохранить данные";
            saveFileDialog.FileName = "coordinates.txt"; 

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath))
                    {
                        foreach (var item in listBox1.Items)
                        {
                            file.WriteLine(item.ToString());
                        }
                    }

                    MessageBox.Show("Данные успешно сохранены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                DialogResult result = MessageBox.Show("Хотите сохранить данные перед выходом?", "Сохранение данных", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    button10_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            Application.Exit();
        }
    }
}

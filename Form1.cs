using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5words
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string path;
        public static int index_ = 0; // предыдущий индекс англ слова
        public static int index = 0, index1 = 0, index2 = 0, index3 = 0, index4 = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            path = Environment.CurrentDirectory;

            try
            {
                using (FileStream fstream = File.OpenRead($"{path}\\database.txt"))
                {
                    // преобразуем строку в байты
                    byte[] array = new byte[fstream.Length];
                    // считываем данные
                    fstream.Read(array, 0, array.Length);
                    // декодируем байты в строку
                    string textFromFile = System.Text.Encoding.UTF8.GetString(array);

                    string[] words = textFromFile.Split(new char[] { ';' });


                    int i = 2;
                    foreach (string item in words)
                    {
                        if (i % 2 == 0)
                        {
                            if (item != "")
                                words_rus.Add(item);
                        }
                        if (i % 2 != 0)
                        {
                            if (item != "")
                                words_eng.Add(item);
                        }
                        i++;
                    }

                    indexes();
                    label1.Text = words_eng[index];
                    button1.Text = words_rus[index1]; button2.Text = words_rus[index2];
                    button3.Text = words_rus[index3]; button4.Text = words_rus[index4];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            indexes();
            label1.Text = words_eng[index];
            button1.Text = words_rus[index1]; button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            button2.Text = words_rus[index2]; button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            button3.Text = words_rus[index3]; button3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            button4.Text = words_rus[index4]; button4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        }

        public static List<string> words_rus = new List<string>();
        public static List<string> words_eng = new List<string>();
        private void button_Click(object sender, EventArgs e)
        {
            Button b = sender as Button; // b это кнопка, на которую кликаем

            ((Button)sender).BackColor = SystemColors.ActiveCaption;

            Button[] bt = new Button[4];
            bt[0] = button1; bt[1] = button2; bt[2] = button3; bt[3] = button4;

            int j = 0;
            foreach (Button btns in bt)
            {
                if (bt[j] != (Button)sender)
                {
                    bt[j].BackColor = SystemColors.GradientInactiveCaption;
                }
                j++;
            }

            if (b.Text == words_rus[index])
            {
                //this.Text = b.Text;

                ((Button)sender).BackColor = SystemColors.Highlight;

            }
            else { b.BackColor = SystemColors.ButtonShadow; }
        }

        public void indexes()
        {
            Random rnd = new Random();

            index = rnd.Next(0, words_rus.Count);
            if (index == index_)
                while (index == index_)
                    index = rnd.Next(0, words_rus.Count);

            int this_index = rnd.Next(1, 5);

            switch (this_index)
            {
                case 1:
                    { index_ = index1 = index; }; break;
                case 2:
                    { index_ = index2 = index; }; break;
                case 3:
                    { index_ = index3 = index; }; break;
                case 4:
                    { index_ = index4 = index; }; break;
            }

            switch (this_index)
            {
                case 1: // index_ = index1 = index;
                    {
                        index2 = rnd.Next(0, words_rus.Count); // 2
                        if ((index2 == index1) || (index2 == index_) || (index2 == index))
                            while ((index2 == index1) || (index2 == index_) || (index2 == index))
                                index2 = rnd.Next(0, words_rus.Count);

                        index3 = rnd.Next(0, words_rus.Count); // 3
                        if ((index3 == index1) || (index3 == index2) || (index3 == index4) || (index3 == index_) || (index3 == index))
                            while ((index3 == index1) || (index3 == index2) || (index3 == index4) || (index3 == index_) || (index3 == index))
                                index3 = rnd.Next(0, words_rus.Count);

                        index4 = rnd.Next(0, words_rus.Count); // 4
                        if ((index4 == index3) || (index4 == index2) || (index4 == index1) || (index4 == index_) || (index3 == index))
                            while ((index4 == index3) || (index4 == index2) || (index4 == index1) || (index4 == index_) || (index3 == index))
                                index4 = rnd.Next(0, words_rus.Count);
                    }; break;
                case 2: // index_ = index2 = index;
                    {
                        index1 = rnd.Next(0, words_rus.Count); // 1
                        if ((index1 == index_) || (index1 == index))
                            while ((index1 == index_) || (index1 == index))
                                index1 = rnd.Next(0, words_rus.Count);

                        index3 = rnd.Next(0, words_rus.Count); // 3
                        if ((index3 == index1) || (index3 == index4) || (index3 == index_) || (index3 == index2) || (index3 == index))
                            while ((index3 == index1) || (index3 == index4) || (index3 == index_) || (index3 == index2) || (index3 == index))
                                index3 = rnd.Next(0, words_rus.Count);

                        index4 = rnd.Next(0, words_rus.Count); // 4
                        if ((index4 == index3) || (index4 == index2) || (index4 == index1) || (index4 == index) || (index4 == index_))
                            while ((index4 == index3) || (index4 == index2) || (index4 == index1) || (index4 == index) || (index4 == index_))
                                index4 = rnd.Next(0, words_rus.Count);
                    }; break;
                case 3: // index_ = index3 = index;
                    {
                        index1 = rnd.Next(0, words_rus.Count); // 1
                        if ((index1 == index3) || (index1 == index) || (index1 == index_))
                            while ((index1 == index3) || (index1 == index) || (index1 == index_))
                                index1 = rnd.Next(0, words_rus.Count);

                        index2 = rnd.Next(0, words_rus.Count); // 2
                        if ((index2 == index1) || (index2 == index3) || (index2 == index) || (index2 == index_))
                            while ((index2 == index1) || (index2 == index3) || (index2 == index) || (index2 == index_))
                                index2 = rnd.Next(0, words_rus.Count);

                        index4 = rnd.Next(0, words_rus.Count); // 4
                        if ((index4 == index3) || (index4 == index2) || (index4 == index1) || (index4 == index) || (index4 == index_))
                            while ((index4 == index3) || (index4 == index2) || (index4 == index1) || (index4 == index) || (index4 == index_))
                                index4 = rnd.Next(0, words_rus.Count);
                    }; break;
                case 4: // index_ = index4 = index;
                    {
                        index1 = rnd.Next(0, words_rus.Count); // 1
                        if ((index1 == index_) || (index1 == index4) || (index1 == index))
                            while ((index1 == index_) || (index1 == index4) || (index1 == index))
                                index1 = rnd.Next(0, words_rus.Count);

                        index2 = rnd.Next(0, words_rus.Count); // 2
                        if ((index2 == index4) || (index2 == index) || (index2 == index_))
                            while ((index2 == index4) || (index2 == index) || (index2 == index_))
                                index2 = rnd.Next(0, words_rus.Count);

                        index3 = rnd.Next(0, words_rus.Count); // 3
                        if ((index3 == index1) || (index3 == index2) || (index3 == index4) || (index3 == index) || (index3 == index_))
                            while ((index3 == index1) || (index3 == index2) || (index3 == index4))
                                index3 = rnd.Next(0, words_rus.Count);
                    }; break;
            }
        }
    }
}

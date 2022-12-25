using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2Anikaev
{
    public partial class Form1 : Form
    {
        Univers[] univer = new Univers[5];
        public int Kol = 0;
        public class Univers// : ICloneable
        {
            public string univer_name;// { get; set; } //Назва університету
            public string address;// { get; set; } // адрес
            public int number_of_rooms;// { get; set; } // кількість кімнат
            public int number_of_staff;// { get; set; } // кількість персоналу
            public int number_of_students;// { get; set; } // кількість студентів
            public int income;// { get; set; } // дохід за мешкання студентів у гуртожитку, за місяць
            
            public Univers(string un1, string un2, int un3)//конструктор
            {
                univer_name = un1;
                address = un2;
                income = un3;
            }
            public void get_numbers()
            {
                Random r = new Random();
                number_of_rooms = r.Next(10, 100);
                number_of_staff = r.Next(2, 10);
                number_of_students = r.Next(20, 200);

            }
            public new string ToString()
            {
                string tostring;
                tostring ="Назва Університету: " + univer_name + ";" + 
                    " oooooooooooooooooooooooooooooooooo " + "Адреса: " + address + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Кількість кімнат: " + number_of_rooms + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Кількість персоналу: " + number_of_staff + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Кількість студентів: " + number_of_students + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Дохід за мешкання студентів: " + income;
                return tostring;
            }
            public void Method1(int un1) //Збільшити кількість кімнат на un1
            {
                number_of_rooms += un1;
            }
            public void Method2(int un1, int un2) //Збільшити кількість кімнат на un1
            {
                if (un1 == 1) number_of_students += un2;
                else number_of_students -= un2;
            }
            public void Method3(int un1, int un2) //Збільшити кількість кімнат на un1
            {
                
            }
            public object Clone()
            {
                return new Univers(univer_name, address, income)
                {
                    number_of_rooms = this.number_of_rooms,
                    number_of_staff = this.number_of_staff,
                    number_of_students = this.number_of_students,

                };
            }
            //public object Clone()
           // {
                //return this.MemberwiseClone();
                //return new Univers()
                //{
                //    univer_name = this.univer_name,
                //    address = this.address,
                //    number_of_rooms = this.number_of_rooms,
                //    number_of_staff = this.number_of_staff,
                //    number_of_students = this.number_of_students,
                //    income = this.income
                //};
           // }
        }
        //public static class UniversExt
        //{
        //    public static int DinRoom(this Univers univer)
        //    {
        //        return new Univers(univer_name, address, income)
        //        {
        //            number_of_rooms = this.number_of_rooms,
        //            number_of_staff = this.number_of_staff,
        //            number_of_students = this.number_of_students,

        //        };
        //    }
        //}
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                string uni1, uni2;
                int uni3;
                uni1 = textBox3.Text;
                uni2 = textBox4.Text;
                //обєкт
                uni3 = Convert.ToInt32(textBox5.Text);
                univer[Kol] = new Univers(uni1, uni2, uni3);
                univer[Kol++].get_numbers();
                //очистити бокси
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            
        }

        //Показати інформацію по Університету
        public void button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(textBox1.Text);
            if (i >= 0 && i <= Kol-1)
            {
                textBox2.Text = "";
                textBox2.Text = univer[i].ToString();//виведення інформації
            }
            else {
                textBox2.Text = "";
            }
        }

        //Збільшити кількість кімнат на i1
        private void button3_Click(object sender, EventArgs e)
        {
            int i1 = Convert.ToInt32(textBox6.Text);//на скільки
            int i2 = Convert.ToInt32(textBox7.Text);//який універ
            if (i1 >= 0 && (i2 >= 0 && i2 <= Kol-1))
            {
                univer[i2].Method1(i1);
            }
            else
            {
                MessageBox.Show("Невірно введені дані!", "Form Closing",
                                MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question);
            }
        }

        //Заселення/виселення одного студенту
        private void button4_Click(object sender, EventArgs e)
        {
            int i1 = Convert.ToInt32(textBox8.Text);//Заселення - 1, Виселення - 2
            int i2 = Convert.ToInt32(textBox9.Text);//який універ
            int i3 = Convert.ToInt32(textBox10.Text);//кількість студентів
            if ((i1 == 1 || i1 == 2) && (i2 >= 0 && i2 <= Kol-1) && i3 >= 1)
            {
                univer[i2].Method2(i1, i3);
            }
            else
            {
                MessageBox.Show("Невірно введені дані!", "Form Closing",
                                MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i1 = Convert.ToInt32(textBox11.Text);//номер університету
            var univer1 = (Univers)univer[i1].Clone(); //клонируем объект
            textBox2.Text = "";
            textBox2.Text = "Копія створена інтерфейсом ICloneable:" + " oooooooooooooooooooooooooooooooooo " +
                    "Назва Університету: " + univer1.univer_name + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Адреса: " + univer1.address + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Кількість кімнат: " + univer1.number_of_rooms + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Кількість персоналу: " + univer1.number_of_staff + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Кількість студентів: " + univer1.number_of_students + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Дохід за мешкання студентів: " + univer1.income; //виведення інформації
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i1 = Convert.ToInt32(textBox12.Text);//номер університету
            textBox13.Text = "";
            textBox13.Text = "Назва Університету: " + univer[i1].univer_name + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Дохід за місяць: " + univer[i1].income + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Дохід за півроку: " + univer[i1].income * 6 + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Дохід за рік: " + univer[i1].income * 12 + ";";//виведення інформації
        }
    }
}

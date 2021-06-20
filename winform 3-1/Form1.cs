using Newtonsoft.Json;
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

namespace winform_3_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            nameupdatetxtb.Enabled = false;

        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            this.UpdateBtn.Location = new Point(30, 300);
            this.Addbtn.Location = new Point(30, 250);
            nameupdatetxtb.Enabled = false;
            Human human = new Human();
            human.Name = textBox1.Text;
            human.Surname = textBox2.Text;
            human.Email = textBox4.Text;
            human.BirthDate = dateTimePicker1.Text;
            Humans.Items.Add(human);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            //   this.UpdateBtn.Top  = 250;
            //     this.Addbtn .up
            this.UpdateBtn.Location = new Point(30, 250);
            this.Addbtn.Location = new Point(30, 300);
            try
            {
                nameupdatetxtb.Enabled = true;

                foreach (Human item in Humans.Items)
                {

                    if (item.Name == nameupdatetxtb.Text)
                    {
                        Humans.Items.Remove(item);
                        Human human = new Human();
                        human.Name = textBox1.Text;
                        human.Surname = textBox2.Text;
                        human.Email = textBox4.Text;
                        human.BirthDate = dateTimePicker1.Text;
                        Humans.Items.Add(human);
                    }
                }
            }
            catch (Exception)
            {


            }

        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            Human human = new Human();
            human.Name = textBox1.Text;
            human.Surname = textBox2.Text;
            human.Email = textBox4.Text;
            human.BirthDate = dateTimePicker1.Text;

            List<Human> humans = new List<Human>
            {
                new Human
                {
                    Email ="ZeynebHesenova@gmail.com",
                    Name="zeyneb",
                    Surname ="hesenova",
                    PhoneNumber ="12312323535",

                },

                new Human
                {
Name ="fuad",
Surname ="ugurlu",
Email ="fuad123@gmail.com",
PhoneNumber ="+12235256"
                },
                new Human
                {
                    Name ="nezrin",
                    Surname ="rehimli",
                    Email="nezrin123@gmail.com",
                    PhoneNumber ="+9941312334"
                }



        };
            humans.Add(human);


            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter("humans.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, humans);
                }
            }
        }

        private void loadbtn_Click(object sender, EventArgs e)
        {
            Human[] humans = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader("humans.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    humans = serializer.Deserialize<Human[]>(jr);
                }
                foreach (var item in humans)
                {
                    Humans.Items.Add(item);
                }
                Human human = new Human();
                human.Name = textBox1.Text;
                human.Surname = textBox2.Text;
                human.Email = textBox4.Text;
                human.BirthDate = dateTimePicker1.Text;
                Humans.Items.Add(human);
            }
        }
    }

}
    

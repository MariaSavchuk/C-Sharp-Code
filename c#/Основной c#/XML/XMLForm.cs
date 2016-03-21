using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.IO;
namespace XMLApplication
{
    /*1.Создать XML-документ, используя приведенные выше данные (IN.TXT в OUT.TXT)
     * 2. Написать DTD для валидации
     * 3. Поместить данные из XML-документа в элемент DataGridView формы.
     */
    public partial class XMLForm : Form
    {
        public XMLForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //запись докуметна
            Encoding enc = Encoding.GetEncoding(1251);
            XmlWriterSettings settings = new XmlWriterSettings();
            StreamReader f = new StreamReader("IN.TXT", enc);
            settings.Indent = true;
            settings.Encoding = Encoding.Default;
            string input;
            using (XmlWriter writer = XmlWriter.Create("OUT.TXT", settings))
            {
                writer.WriteStartDocument();
                writer.WriteDocType("table", null, null, String.Format("<!ELEMENT table (team+)>\t<!ELEMENT team (information)>\t<!ELEMENT information (login,password)>\t<!ELEMENT login EMPTY>\t<!ELEMENT password EMPTY>\t<!ATTLIST team name CDATA #REQUIRED>\t<!ATTLIST login text CDATA #REQUIRED>\t<!ATTLIST password pas1 CDATA #REQUIRED pas2 CDATA #REQUIRED>"));
                writer.WriteStartElement("table");
                while ((input = f.ReadLine()) != null)
                {
                    string[] mas = input.Split(new char[] { ' ' });
                    string name = "";
                    for (int i = 3; i < mas.Length; i++)
                        name = String.Format(name + mas[i] + " ");
                    name = name.Substring(0, name.Length - 1);
                    writer.WriteStartElement("team");
                    writer.WriteAttributeString("name", name);
                    writer.WriteStartElement("information");
                    writer.WriteStartElement("login");
                    writer.WriteAttributeString("text", mas[0]);
                    writer.WriteEndElement();
                    writer.WriteStartElement("password");
                    writer.WriteAttributeString("pas1", mas[1]);
                    writer.WriteAttributeString("pas2", mas[2]);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //чтение
                dataGridView1.ColumnCount = 4;
                dataGridView1.Columns[0].HeaderText = "Логин";
                dataGridView1.Columns[1].HeaderText = "Пароль1";
                dataGridView1.Columns[2].HeaderText = "Пароль2";
                dataGridView1.Columns[3].HeaderText = "Команда";
                dataGridView1.RowHeadersWidth = 50;
                dataGridView1.Width = 470;
                dataGridView1.Columns[0].Width = dataGridView1.Columns[0].Width = dataGridView1.Columns[0].Width = dataGridView1.Columns[0].Width = 100;
                int i = 0;
                XmlReaderSettings set = new XmlReaderSettings();
                set.ValidationType = ValidationType.DTD;
                set.ProhibitDtd = false;
                using (XmlReader reader = XmlReader.Create("OUT.TXT", set))
                {
                   
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "team")
                            {
                                dataGridView1.RowCount = dataGridView1.RowCount + 1;
                                dataGridView1.Rows[i].HeaderCell.Value = String.Format((i + 1).ToString());
                                reader.MoveToNextAttribute();
                                dataGridView1.Rows[i].Cells[3].Value = String.Format(" {0}", reader.Value);
                            }
                            if (reader.Name == "login")
                            {
                                reader.MoveToNextAttribute();
                                dataGridView1.Rows[i].Cells[0].Value = String.Format(" {0}", reader.Value);
                            }
                            if (reader.Name == "password")
                            {
                                reader.MoveToNextAttribute();
                                dataGridView1.Rows[i].Cells[1].Value = String.Format(" {0}", reader.Value);
                                reader.MoveToNextAttribute();
                                dataGridView1.Rows[i].Cells[2].Value = String.Format(" {0}", reader.Value);
                            }
                            reader.MoveToElement();
                        }
                        if (reader.NodeType == XmlNodeType.EndElement)
                        {
                            if (reader.Name == "team")
                                i++;
                            reader.MoveToElement();
                        }
                    }
                }
                button1.Enabled = false;
            }
            catch (XmlSchemaValidationException)
            {
                MessageBox.Show("Не правильно построен XML-документ");
                Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                Close();
            }
        }
    }
}

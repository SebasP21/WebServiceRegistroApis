using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Drawing;

using WebServiceP.DetailsCountry;
using WebServiceP.ConfirmarEmail;
using WebServiceP.ConfirmarTarjeta;

using System.Data.SqlClient;
namespace WebServiceP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WebServiceP.DetailsCountry.country test = new WebServiceP.DetailsCountry.country();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebServiceP.DetailsCountry.country test = new WebServiceP.DetailsCountry.country();
            string ts = test.GetCountries();



            //comboBox2.DataSource = Enum.GetValues(typeof());
            //comboBox2.SelectedItem = ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebServiceP.DetailsCountry.country test = new WebServiceP.DetailsCountry.country();
            string ts = test.GetCountries();
            ts = ts.Replace("<NewDataSet>", "");
            ts = ts.Replace("<Table>", "");
            ts = ts.Replace("</Table>", "");
            ts = ts.Replace("</NewDataSet>", "");
            ts = ts.Replace("<Name>", "");
            ts = ts.Replace("</Name>", "~");
            ts = ts.Replace("\n", "");
            ts = ts.Replace("  ", "");

            string[] tester = ts.Split('~');

            for (int i = 0; i < tester.Length; i++)
            {
                comboBox3.Items.Add(tester[i]);
                
                

                //comboBox3.DataSource = Enum.GetValues(typeof(tes));

            }
            
            //string mon = test.GetCurrencies();
            //mon = mon.Replace("<NewDataSet>", "");
            //mon = mon.Replace("<Table>", "");
            //mon = mon.Replace("</Table>", "");
            //mon = mon.Replace("</NewDataSet>", "");
            //mon = mon.Replace("<Name>", "~");
            //mon = mon.Replace("</Name>", "");
            //mon = mon.Replace("<CountryCode>", "");
            //mon = mon.Replace("</CountryCode>", "§");
            //mon = mon.Replace("<Currency>", "");
            //mon = mon.Replace("</Currency>", "§");
            //mon = mon.Replace("<CurrencyCode>", "");
            //mon = mon.Replace("</CurrencyCode>", "§");
            //mon = mon.Replace("<CurrencyCode />", "§");
            //mon = mon.Replace("<Currency />", "§");
            //mon = mon.Replace("\n", "");
            //mon = mon.Replace(" ", "");

            //string[] moneda = mon.Split('~');

            //for (int i = 1; i < moneda.Length; i++)
            //{
            //    string[] valores = moneda[i].Split('§');

            //    comboBox4.Items.Add(valores[0]);
            //    comboBox5.Items.Add(valores[1]);
            //    comboBox6.Items.Add(valores[2]);
            //    comboBox7.Items.Add(valores[3]);
                
                

            //}
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            WebServiceP.DetailsCountry.country test = new WebServiceP.DetailsCountry.country();
            string m = test.GetCurrencyByCountry(Convert.ToString(comboBox3.SelectedItem));
            m = m.Replace("<NewDataSet>", "");
            m = m.Replace("<Table>", "§");
            m = m.Replace("</Table>", "");
            m = m.Replace("</NewDataSet>", "");
            m = m.Replace("<Name>", "");
            m = m.Replace("</Name>", "");
            m = m.Replace("<CountryCode>", "§");
            m = m.Replace("</CountryCode>", "");
            m = m.Replace("<Currency>", "§");
            m = m.Replace("</Currency>", "");
            m = m.Replace("<CurrencyCode>", "§");
            m = m.Replace("</CurrencyCode>", "");
            m = m.Replace("<CurrencyCode />", "§");
            m = m.Replace("<Currency />", "§");
            m = m.Replace("\n", "");
            m = m.Replace(" ", "");

            string[] moneda = m.Split('§');
            
            textBox1.Text = moneda[1];
            textBox2.Text = moneda[2];
            textBox3.Text = moneda[3];
            textBox4.Text = moneda[4];


        }

        private void button2_Click(object sender, EventArgs e)
        {
            WebServiceP.ConfirmarEmail.ValidateEmail email = new WebServiceP.ConfirmarEmail.ValidateEmail();
            
            //Boolean em = email.IsValidEmail(Convert.ToString(textBox5.SelectedText));
            if (email.IsValidEmail(textBox5.Text) == true)
            {
                textBox5.ForeColor = Color.Green;
            }
            else
            {
                textBox5.ForeColor = Color.Red;
            }
            WebServiceP.ConfirmarTarjeta.CCChecker tarjeta = new WebServiceP.ConfirmarTarjeta.CCChecker();

            textBox8.Text = tarjeta.ValidateCardNumber(textBox6.Text, textBox7.Text);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=SEBASTIAN ; database=RegistroWebService ; integrated security = true");
            conexion.Open();
            MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");
            //conexion.Close();
            //MessageBox.Show("Se cerró la conexión.");
       

 
   SqlCommand myCommand = new SqlCommand("set_insertarRegistro ", conexion);

   // Mark the Command as a SPROC
   myCommand.CommandType = CommandType.StoredProcedure;

   SqlParameter parameterNombre = new SqlParameter("@Nombre", SqlDbType.VarChar, 50);
   parameterNombre.Value = nombre.Text;
   myCommand.Parameters.Add(parameterNombre);
   
   SqlParameter parameterApellido= new SqlParameter("@Apellido", SqlDbType.VarChar, 50);
   parameterApellido.Value = apellido.Text;
   myCommand.Parameters.Add(parameterApellido);

            SqlParameter parameterTelefono = new SqlParameter("@Telefono", SqlDbType.VarChar, 50);
   parameterTelefono.Value = telefono.Text;
   myCommand.Parameters.Add(parameterTelefono);
            
            SqlParameter parameterPais = new SqlParameter("@Pais", SqlDbType.VarChar, 50);
   parameterPais.Value = textBox1.Text;
   myCommand.Parameters.Add(parameterPais);
            

            SqlParameter parameterCodPais = new SqlParameter("@CodPais", SqlDbType.VarChar, 50);
   parameterCodPais.Value = textBox2.Text;
   myCommand.Parameters.Add(parameterCodPais);

            SqlParameter parameterMoneda = new SqlParameter("@Moneda", SqlDbType.VarChar, 50);
   parameterMoneda.Value = textBox3.Text;
   myCommand.Parameters.Add(parameterMoneda);

            SqlParameter parameterCodMoneda = new SqlParameter("@CodMoneda", SqlDbType.VarChar, 50);
   parameterCodMoneda.Value = textBox4.Text;
   myCommand.Parameters.Add(parameterCodMoneda);

            SqlParameter parameterEmail = new SqlParameter("@Email", SqlDbType.VarChar, 50);
   parameterEmail.Value = textBox5.Text;
   myCommand.Parameters.Add(parameterEmail);

            SqlParameter parameterTipoTarjeta = new SqlParameter("@TipoTarjeta", SqlDbType.VarChar, 50);
   parameterTipoTarjeta.Value = textBox6.Text;
   myCommand.Parameters.Add(parameterTipoTarjeta);

            SqlParameter parameterNumTarjeta = new SqlParameter("@NumTarjeta", SqlDbType.VarChar, 50);
   parameterNumTarjeta.Value = textBox7.Text;
   myCommand.Parameters.Add(parameterNumTarjeta);

            SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.VarChar, 50);
   parameterPassword.Value = password.Text;
   myCommand.Parameters.Add(parameterPassword);

            

   SqlDataReader datDatos_t = myCommand.ExecuteReader();
   //if (datDatos_t.Read()) 
   //{
   // this.strCodigo_l = strCodigo_p;
   // this.strPais_l = datDatos_t.GetString(datDatos_t.GetOrdinal("CODPAI"));
   // this.strNombre_l = datDatos_t.GetString(datDatos_t.GetOrdinal("NOMCIU"));
   // this.intDepartamento_l = Int32.Parse((datDatos_t.GetValue(datDatos_t.GetOrdinal("CODDEP")).ToString()));
   // this.strEstado_l =  datDatos_t.GetString(datDatos_t.GetOrdinal("ESTADO"));
   //}
   datDatos_t.Close();
   conexion.Close();
  }
        }
        
    }





using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstLabForm
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            Send(XTextBox.Text.ToString(),YTextBox.Text.ToString());
        }
        private async Task Send(string x,string y)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsync("http://localhost:80/FirstLab/Sum?X=" + x + "&Y=" + y, null);
            ResultTextBox.Text = await response.Content.ReadAsStringAsync();
        }
    }
}

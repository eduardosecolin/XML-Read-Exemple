using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Xml;
using System.Xml.Linq;

namespace ExemploXml {
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btnImportar_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = "c:\\";
            file.Filter = "xml files (*.xml)|*.txt|All files (*.*)|*.*";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            if(file.ShowDialog() == true){
                string caminho = file.FileName;
                XmlDocument doc = new XmlDocument();
                doc.Load(caminho);
                XDocument xml = XDocument.Load(caminho);
                string version = xml.Declaration.Version;
                MessageBox.Show(version);
                XmlNodeList nodes = doc.SelectNodes("clientes");
                List<string> detalhes = new List<string>();
                foreach (XmlNode item in nodes) {
                    txtNome.Text = item["nome"].InnerText;
                    txtSexo.Text = item["sexo"].InnerText;
                    txtEndereco.Text = item["endereco"].InnerText;
                    lsClientes.Items.Add(item["bairro"].InnerText);
                    lsClientes.Items.Add(item["cidade"].InnerText);
                    lsClientes.Items.Add(item["estado"].InnerText);
                    lsClientes.Items.Add(item["pais"].InnerText);
                }

            }
        }
    }
}

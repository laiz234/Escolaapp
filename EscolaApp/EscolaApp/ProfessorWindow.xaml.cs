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
using System.Windows.Shapes;

namespace EscolaApp
{
    /// <summary>
    /// Lógica interna para ProfessorWindow.xaml
    /// </summary>
    public partial class ProfessorWindow : Window
    {
        public ProfessorWindow()
        {
            InitializeComponent();
        }

        private void InserirClick_Click(object sender, RoutedEventArgs e)
        {
            Professor p = new Professor();
            p.Id = int.Parse(txtId.Text);
            p.Nome = txtNome.Text;
            p.Matricula = txtMatricula.Text;
            p.Area = txtArea.Text;
            NProfessor.Inserir(p);
            ListarClick(sender, e);
        }

        private void ListarClick_Click(object sender, RoutedEventArgs e)
        {
            listProfessores.ItemsSource = null;
            listProfessores.ItemsSource = NProfessor.Listar();
        }

        private void AtualizarClick_Click(object sender, RoutedEventArgs e)
        {
            Professor p = new Professor();
            p.Id = int.Parse(txtId.Text);
            p.Nome = txtNome.Text;
            p.Matricula = txtMatricula.Text;
            p.Area = txtArea.Text;
            NProfessor.Atualizar(p);
            ListarClick(sender, e);
        }

        private void ExcluirClick_Click(object sender, RoutedEventArgs e)
        {
            Professor p = new Professor();
            p.Id = int.Parse(txtId.Text);
            NProfessor.Excluir(p);
            ListarClick(sender, e);
        }

        private void listProfessores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listProfessores.SelectedItem != null)
            {
                Professor obj = (Professor)listProfessores.SelectedItem;
                txtId.Text = obj.Id.ToString();
                txtNome.Text = obj.Nome;
                txtMatricula.Text = obj.Matricula;
                txtArea.Text = obj.Area.ToString();
            }
        }
    }
}

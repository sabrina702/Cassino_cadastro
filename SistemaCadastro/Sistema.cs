﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SistemaCadastro
{
    public partial class Sistema : Form
    {

        public Sistema()
        {
            InitializeComponent();
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            marcador.Height = btnCadastra.Height;
            marcador.Top = btnCadastra.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }
        

        private void btnBusca_Click(object sender, EventArgs e)
        {
            marcador.Height = btnBusca.Height;
            marcador.Top = btnBusca.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }



        void listaGenero()
        {
            ConectaBanco con = new ConectaBanco();
            DataTable tabelaDados = new DataTable();
            tabelaDados = con.listaGeneros();
            cbGenero.DataSource = tabelaDados;
            cbGenero.DisplayMember = "genero";
            cbGenero.ValueMember = "idgenero";
            lblmsgerro.Text = con.mensagem;
            cbGenero.Text = "";
        }

        void listaBanda()
        {
            ConectaBanco con = new ConectaBanco();
            dgBandas.DataSource = con.listaBandas();
        }
        void limpaCampos()
        {
            txtnome.Text = "";
            cbGenero.Text = "";
            txtintegrantes.Text = "";
            txtranking.Text = "";
            txtnome.Focus();
        }

        private void Sistema_Load(object sender, EventArgs e)
        {
            listaGenero();
            listaBanda();
        }


        private void BtnConfirmaCadastro_Click_1(object sender, EventArgs e)
        {
            Banda b = new Banda();
            b.Nome = txtnome.Text;
            b.Genero =Convert.ToInt32(cbGenero.SelectedValue.ToString());
            b.Integrantes = Convert.ToInt32(txtintegrantes.Text);
            b.Ranking = Convert.ToInt32(txtranking.Text);
            // enviar para o banco 
            ConectaBanco conecta = new ConectaBanco();
            bool retorno = conecta.insereBanda(b);
            if (retorno == true)
            {
                MessageBox.Show("Dados inseridos com sucesso!");
            }
            else
                lblmsgerro.Text = conecta.mensagem;

            listaBanda();
            limpaCampos();
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            (dgBandas.DataSource as DataTable).DefaultView.RowFilter = String.Format("nome like'{0}%'", txtBusca.Text);
        }

        private void btnRemoveBanda_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            
        }

         private void btnConfirmaAlteracao_Click(object sender, EventArgs e)
        {
            


        }

        private void bntAddGenero_Click(object sender, EventArgs e)
        {
          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

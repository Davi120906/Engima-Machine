using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Teclado : Form
{
    private List<Label> teclas = new List<Label>();

    public Teclado()
    {
        this.KeyDown += new KeyEventHandler(Teclado_KeyDown); 
        this.Text = "ENIGMA MACHINE";
        this.ClientSize = new System.Drawing.Size(1500, 800);

        this.CriarTeclado();
    }

    private async void Teclado_KeyDown(object sender, KeyEventArgs e) 
    {
        char l = Rotor.TeclaPressionada(e.KeyCode.ToString()[0]);
        foreach (var tecla in teclas)
        {
            if (tecla.Text.ToUpper() == l.ToString())
            {
                tecla.BackColor = Color.Yellow;  
                await Task.Delay(400); 
                tecla.BackColor = Color.LightGray;  
            }
        }
    }

    private void CriarTeclado()
    {
        int janelaLargura = 1500;
        int janelaAltura = 800;  
        int espaco = 120;        


        int teclaLargura = 80;
        int teclaAltura = 80;

     
        string[] linhas = new string[]
        {
            "QWERTYUIOP",  
            "ASDFGHJKL",  
            "ZXCVBNM"      
        };

        
        int larguraTeclado = Math.Max(Math.Max(linhas[0].Length, linhas[1].Length), linhas[2].Length) * espaco;

        int alturaTeclado = linhas.Length * espaco;

  
        int startX = (janelaLargura - larguraTeclado) / 2;
        int startY = (janelaAltura - alturaTeclado) / 2;

     
        for (int i = 0; i < linhas.Length; i++)
        {
            int espacoCentralizado = (larguraTeclado - linhas[i].Length * espaco) / 2;

            for (int j = 0; j < linhas[i].Length; j++)
            {
                char c = linhas[i][j];

              
                Label lbl = new Label
                {
                    Text = c.ToString(),
                    Font = new Font("Arial", 32, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(teclaLargura, teclaAltura),
                    BackColor = Color.LightGray,
                    BorderStyle = BorderStyle.FixedSingle,
                    ForeColor = Color.Black
                };

              
                int xPos = startX + espacoCentralizado + (j * espaco);
                
                int yPos = startY + (i * espaco);

                lbl.Location = new Point(xPos, yPos);

                // Adiciona o label à tela
                this.Controls.Add(lbl);
                teclas.Add(lbl);
            }
        }
    }
}
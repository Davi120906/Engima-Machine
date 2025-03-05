using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;

public class Rotor{
    public String sequencia;
    private Dictionary<char,int> letraNum;
    private int posicao = 0;
    private int  ponto;
    
    private static List<Rotor> rotores = new List<Rotor>();

    public Rotor(String s, Dictionary<char,int> letraNum, int p){
        this.sequencia = s;
        this.letraNum = letraNum;
        this.ponto = p;
        rotores.Add(this);
    }
    public char Trocar(char l){
        int i = letraNum[l] + posicao;
        if(i > 25){
            i -= 26;
        }
        return sequencia[i];
    }
    public char TrocarReverso(char l) {
        int i = sequencia.IndexOf(l) - posicao;
        if (i < 0) {
            i += 26;
        }

        foreach (var par in letraNum) {
            if (par.Value == i) {
                return par.Key;
            }
        }
        return l;
    }

    public void Rodar() {
        posicao = (posicao + 1) % 26; 
    }

    public int getPos(){
        return posicao;
    }
    public int getPonto(){
        return ponto;
    }
    public static char TeclaPressionada(char l) {
        Console.WriteLine(l);
        l = Plugboard.usePlug(l);
        for (int i = 0; i < rotores.Count; i++) {
            l = rotores[i].Trocar(l);
            Console.WriteLine(l);

        }

        // Refletor
        Dictionary<char, char> mapaDeLetras = new Dictionary<char, char>
        {
            {'A','H'},{'B','O'},{'C','L'},{'D','U'},{'E','W'},{'F','S'},{'G','R'},
            {'H','A'},{'I','Q'},{'J','T'},{'K','Y'},{'L','C'},{'M','Z'},{'N','V'},
            {'O','B'},{'P','X'},{'Q','I'},{'R','G'},{'S','F'},{'T','J'},{'U','D'},
            {'V','N'},{'W','E'},{'X','P'},{'Y','K'},{'Z','M'}
        };

        l = mapaDeLetras[l];
        Console.WriteLine(l);


        
        for (int i = rotores.Count - 1; i >= 0; i--) {
            l = rotores[i].TrocarReverso(l);
            Console.WriteLine(l);

        }

        
        if (rotores[1].getPos() == rotores[1].getPonto()) {
            rotores[1].Rodar();
            rotores[2].Rodar();
        } else if (rotores[0].getPos() == rotores[0].getPonto()) {
            rotores[1].Rodar();
        }
        
        rotores[0].Rodar(); 
        Console.WriteLine("--------------------------------------------");
        return l;
}

}
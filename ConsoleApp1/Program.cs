

class Program
{
    static void Main()
    {
        Dictionary<char, int> letraNum = new Dictionary<char, int>();
        for(int i = 0; i < 26; i++){
            letraNum.Add((char)('A'+i),i);
        }
        Plugboard.addPlug('G','S');
        Rotor rotor1 = new Rotor("KGWNTRBLQPAHYDVJIFXEZOCSMU",letraNum, 5);
        Rotor rotor2 = new Rotor("JKGOPTCIHABRNMDEYLZFXWVUQS",letraNum, 4);
        Rotor rotor3 = new Rotor("RCBUTXVZJINQPKWMLAYEDGOFSH",letraNum, 19);


        Application.EnableVisualStyles();
        Application.Run(new Teclado());

    }
}
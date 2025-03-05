public static class Plugboard{
    public static Dictionary<char, char> Plugboards = new Dictionary<char, char>();
    public static void addPlug(char a, char b){
        if(Plugboards.ContainsKey(a) || Plugboards.ContainsKey(b)){
            return;
        }
        Plugboards.Add(a,b);
        Plugboards.Add(b,a);
    }
    public static char usePlug(char l){
        if(Plugboards.ContainsKey(l)){
            return Plugboards[l];
        }
        else{
            return l;
        }
    }
}
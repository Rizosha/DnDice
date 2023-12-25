public class SpellData
{
    public string spellName;
    public int d4;
    public int d6;
    public int d8;
    public int d10;
    public int d12;
    public int d20;
    public int d100;
    public int modifier;
    public bool all;
    
    public SpellData(string spellName, int d4, int d6, int d8, int d10, int d12, int d20, int d100, int modifier, bool all)
    {
        this.spellName = spellName;
        this.d4 = d4;
        this.d6 = d6;
        this.d8 = d8;
        this.d10 = d10;
        this.d12 = d12;
        this.d20 = d20;
        this.d100 = d100;
        this.modifier = modifier;
        this.all = all;
    }
}

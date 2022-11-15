
public class Aluno
{
    public int Matricula { get; set; }
    public string? Nome { get; set; }
    public float Matematica { get; set; }
    public float Portugues { get; set; }
    public float Historia { get; set; }

    public bool Passed
    {
        get
        {
            bool passed = true;
            if (Matematica < 60) passed = false;
            if (Historia < 60) passed = false;
            if (Portugues < 60) passed = false;
            return passed;
        }
    }

    public float Average
    {
        get
        {
            return (float)Math.Round((Matematica + Historia + Portugues) / 3, 2);
        }
    }
}

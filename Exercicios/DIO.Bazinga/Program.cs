using System;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;


public class Mesa {

  public Personagem p1;
  public Personagem p2;
  
  public Mesa (Personagem p1, Personagem p2)
  {
    this.p1 = p1;
    this.p2 = p2;
  }

public void analizar () {
    Objeto j1 = p1.jogada;
    Objeto j2 = p2.jogada;
    
    // p1.venceu = false;
    // p2.venceu = false;
    
    if (j1.winsFor.Contains(j2)) 
    {
        p1.TalkAboutVictory();
        // p1.venceu = true;
        // return
    }else if (j2.winsFor.Contains(j1)) 
    {
        p1.TalkAboutDefeat();
        // p2.venceu = true;
        // return;
    }else
    {
        p1.SpeakinTheTie();
    }
 
  }
}


public abstract class Objeto 
{
    public List<Objeto> winsFor = new List<Objeto>(){}; 
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (this.GetType() == obj.GetType()) return true;
        return false;
    }
}

public class Spock : Objeto {
    public Spock (bool Add = false) 
    {
        if (Add) 
        {
            this.winsFor.Add(new Tesoura());
            this.winsFor.Add(new Pedra());
        }
    }

}

public class Papel : Objeto {
    public Papel (bool Add = false) 
    {
        if (Add) 
        {
            this.winsFor.Add(new Pedra());
            this.winsFor.Add(new Spock());
        }
    }

}

public class Lagarto : Objeto {
    public Lagarto (bool Add = false) 
    {
        if (Add) 
        {
            this.winsFor.Add(new Spock());
            this.winsFor.Add(new Papel());
        }
    }
}

public class Tesoura : Objeto {
    public Tesoura (bool Add = false) 
    {
        if (Add) 
        {
            this.winsFor.Add(new Papel());
            this.winsFor.Add(new Lagarto());
        }
    }
}


public class Pedra : Objeto
{
    public Pedra (bool Add = false) 
    {
        if (Add) {
            this.winsFor.Add(new Lagarto());
            this.winsFor.Add(new Tesoura());
        }
    }
}


public abstract class Personagem 
{
    public Objeto jogada {get; set;} 
    public bool venceu {get;set;}
    
    public virtual void GetJogada(string j) 
    {
        var param  = new object[] {true};
        Type tp = System.Type.GetType(j);
        
        var instancia = Activator.CreateInstance(tp,  args: param);
        this.jogada = (Objeto) instancia;
    }    
    
    public abstract void TalkAboutVictory();
    public abstract void TalkAboutDefeat();    
    public abstract void SpeakinTheTie();
}

public class Sheldon : Personagem 
{    	
    public override void TalkAboutVictory() 
    {
        Console.WriteLine("Bazinga!") ;
    }
    
    public override void TalkAboutDefeat() 
    {
        Console.WriteLine("Raj trapaceou!") ;
    }
    
    public override void SpeakinTheTie() 
    {
        Console.WriteLine("De novo!") ;
    }
}

public class Raj : Personagem 
{
    public override void TalkAboutVictory(){}
    public override void TalkAboutDefeat(){}    
    public override void SpeakinTheTie(){}
}

namespace DIO.Bazinga
{
    class Program
    {
        static void Main(string[] args)
        {
            TextInfo myTI = new CultureInfo("pt-BR", false).TextInfo;
            int caseNumber = int.Parse(Console.ReadLine());
            string[] cases = new string[caseNumber*2];

            for (int i = 0; i < caseNumber * 2; i+=2) 
            {
                
                string s = myTI.ToTitleCase(Console.ReadLine());
                string[] sArr = s.Split(" ");

                cases[i] = sArr[0];
                cases[i+1] = sArr[1];
            }
            
        
            Sheldon sheldon = new Sheldon();
            Raj raj = new Raj();
            Mesa m = new Mesa(sheldon, raj);
            for (int i = 0,j=1; i < cases.Length; i+=2,j++) 
            {
                sheldon.GetJogada(cases[i]);
                raj.GetJogada(cases[i+1]);

                Console.Write($"Caso #{j}: ");
                m.analizar();
            }

        }
    }
}











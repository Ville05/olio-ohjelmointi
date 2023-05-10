public interface käskyrobotille
{
    void Suorita(olio robotti);
}

public class aloita : käskyrobotille
{
    public void Suorita(olio robotti)
    {
        robotti.OnKäynnissä = true;
    }
}

public class Sammuta : käskyrobotille
{
    public void Suorita(olio robotti)
    {
        robotti.OnKäynnissä = false;
    }
}

public class ylös : käskyrobotille
{
    public void Suorita(olio robotti)
    {
        if (robotti.OnKäynnissä)
        {
            robotti.Y += 1;
        }
    }
}

public class alas : käskyrobotille
{
    public void Suorita(olio robotti)
    {
        if (robotti.OnKäynnissä)
        {
            robotti.Y -= 1;
        }
    }
}
public class oikea : käskyrobotille
{
    public void Suorita(olio robotti)
    {
        if (robotti.OnKäynnissä)
        {
            robotti.X += 1;
        }
    }
}
public class vasen : käskyrobotille
{
    public void Suorita(olio robotti)
    {
        if (robotti.OnKäynnissä)
        {
            robotti.X -= 2;
        }
    }
}



public class olio
{
    public int Y { get; set; }

    public bool OnKäynnissä { get; set; }
    public int X { get; set; }
   
    
    public käskyrobotille?[] Käskyt { get; } = new käskyrobotille?[3];

    public void Suorita()
    {
        foreach (käskyrobotille? käsky in Käskyt)
        {
            käsky?.Suorita(this);
            Console.WriteLine($"[{X} {Y} {OnKäynnissä}]");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        olio robo = new olio();

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(" käsky minkä tahdont antaa robotille (starttaa, lopeta, ylös, alas, vasen, oikea):");
            string syöte = Console.ReadLine();

            switch (syöte.ToLower())
            {
                case "oikea":
                    robo.Käskyt[i] = new oikea();
                    break;

                case "starttaa":
                    robo.Käskyt[i] = new aloita();
                    break;

                case "lopeta":
                    robo.Käskyt[i] = new Sammuta();
                    break;

                case "alas":
                    robo.Käskyt[i] = new alas();
                    break;

                case "ylös":
                    robo.Käskyt[i] = new ylös();
                    break;
                
                case "vasen":
                    robo.Käskyt[i] = new vasen();
                    break;
                
                default:
                    Console.Write("käskyä ei ole osaaks lukee g??These bitches love Sosa\r\nO end or no end\r\nFucking with them O boys, you gon' get fucked over\r\nRaris and Rovers\r\nThese hoes love Chief Sosa\r\nHit him with that cobra, now that boy slumped over\r\nThey do it all for Sosa\r\n\r\n[Verse 1]\r\nYou boys ain't making no noise\r\nY'all know I'm a grown boy\r\nYour clique full of broke boys\r\nGod y'all some broke boys\r\nGod y'all some broke boys\r\nWe GBE dope boys\r\nWe got lots of dough boy\r\nI'm sippin' on that codeine, not brandy, that's a no-no\r\nI fucked your girl, now she a thot, I fucked her friend, now she a thot\r\nThots everywhere, I'm a thot boy, that's why I rock designer clothes\r\nFucked up off this drank, I'm a thot boy, and all these bands got your girl like, \"Boy, don't he know he's handsome?\"\r\n\r\n[Hook]\r\nThese bitches love Sosa\r\nO end or no end\r\nFucking with them O boys, you gon' get fucked over\r\nRaris and Rovers\r\nThese hoes love Chief Sosa\r\nHit him with that cobra, now that boy slumped over\r\nThey do it all for Sosa\r\n\r\n[Verse 2]\r\nNow that we gettin' money, all these bitches wanna fuck me\r\nNow that I'm getting money, I don't want no bitch that's ugly\r\nSmoke one squad, bitch, I'm Kobe\r\nGlo gang bitch, we GBE\r\nGot a lot of cash, I don't know why these niggas mad at me\r\nBitch, I'm ballin' like I'm comin' off of free throws\r\nJust cause you got money, that don't mean you got class, ho\r\nI switch it up, I'm cool with niggas that's cool with Taliban\r\nI done drove every car, bitch, I'm a test driver\r\nCatch me in the Lamb' with your girl, getting head by the campfire\r\nShe ask me if I'm a genius, I say, \"Genius, don't question it\"\r\nThe money got me geeked, like I took a hit of the crack pipe\r\n[Bridge]\r\nSosa baby, you know I'm rockin', baby\r\nGlo'd up, and you know it's GBE baby\r\nBang bang, bitch, Sosa baby\r\nGBE baby, O block\r\n\r\n[Hook]\r\nThese bitches love Sosa\r\nO end or no end\r\nFucking with them O boys, you gon' get fucked over\r\nRaris and Rovers\r\nThese hoes love Chief Sosa\r\nHit him with that cobra, now that boy slumped over\r\nThey do it all for Sosa");
                    i--;


                    break;
            }
        }
        robo.Suorita();
    }
}
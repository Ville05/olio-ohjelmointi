using System;

string karkit = "a.tilaus";
string peratilaus = "b.tilaus";
int pituustilaus = 0;
string haluttupituus;

Console.WriteLine("Aloitetaan perästä minkälainen perä saisi olla? (lehti, kanansulka, kotkansulka) :");
while (peratilaus != "lehti" || peratilaus != "kanansulka" || peratilaus != "kotkansulka")
{
    peratilaus = Console.ReadLine();
    if (peratilaus == "lehti" || peratilaus == "kanansulka" || peratilaus == "kotkansulka")
    {
        break;
    }
}


Console.WriteLine("Minkälainen kärki (kivinen, kultainen, timantti) :");
while (karkit != "kivinen" || karkit != "kultainen" || karkit != "timantti")
{
    karkit = Console.ReadLine();
    if (karkit == "timantti" || karkit == "kultainen" || karkit == "kivinen")
    {
        break;
    }
}

Console.WriteLine("Nuolen koko (60-100cm) :");
while (pituustilaus < 60 || pituustilaus > 100)
{
    haluttupituus = Console.ReadLine();
    if (int.TryParse(haluttupituus, out pituustilaus) == true && pituustilaus < 100 && pituustilaus > 60)
    {
        break;
    }
}
Nuoli tilattuNuoli = new Nuoli(karkit, peratilaus, pituustilaus);
Console.WriteLine("Nuoli maksaa " + tilattuNuoli.Hinta() + " kultaa");



public class Nuoli
{
    private double _pituus;
    private string _karki;
    private string _pera;
    private double nuolenhinta;
    
    

    public Nuoli(string karki, string pera, int pituus)
    {
        _pituus = pituus;
        _pera = pera;
        _karki = karki;
        

        if (_karki == "timantti")
        {
            nuolenhinta += 50;
        }
        if (_karki == "kivinen")
        {
            nuolenhinta += 6;
        }
        if (_karki == "kultainen")
        {
            nuolenhinta += 25;
        }
        
       
        if (_pera == "kotkansulka")
        {
            nuolenhinta += 5;
        }
        if (_pera == "kanansulka")
        {
            nuolenhinta += 1;
        }
        nuolenhinta = nuolenhinta + _pituus * 0.5;
        return;
    }

    
    public string pääty()
    {
        return _karki;
    }
   

    public double Hinta()
    {
        return nuolenhinta;
    }
    public double koko()
    {
        return _pituus;
    }
    public string Pera()
    {
        return _pera;
    }
}
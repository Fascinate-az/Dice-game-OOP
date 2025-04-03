namespace ConsoleApp2;

class Setting
{
    private const int faccieDado = 6;
    private const int tentativi = 3;

    public int FaccieDado()
    {
        return faccieDado;
    }

    public int TentativiPerIndovinare()
    {
        return tentativi;
    }
}

class Intro
{
    private Setting setting;

    public Intro(Setting setting)
    {
        this.setting = setting;
    }

    public void Benvenuto()
    {
        Console.WriteLine($"Gioco dei dadi ..... hai {setting.TentativiPerIndovinare()} tentativi per indovinare il numero estratto");

    }
}

class LancioDeiDadi
{
    Random rnd = new Random();
    private Setting setting;

    public LancioDeiDadi(Setting setting)
    {
        this.setting = setting;
    }

    public int LancioDadi()
    {
        
        var numeroEstratto = rnd.Next(1, setting.FaccieDado()+1);
        
        return numeroEstratto;
    }
}

class ControlInput
{
    private LancioDeiDadi lancioDeiDadi;
    private Setting setting;
    private MessaggiConsole msg;
    

    public ControlInput(LancioDeiDadi lancioDeiDadi, Setting setting,MessaggiConsole msg)
    {
        this.lancioDeiDadi = lancioDeiDadi;
        this.setting = setting;
        this.msg = msg;
    }

    public int CheckWin()
    {
        int startCounterTentativi = 0;
        int numeroDaIndovinare = lancioDeiDadi.LancioDadi();
        int iswin = 0;
        //Console.WriteLine($"numero uscito {numeroDaIndovinare}"); per test
        while (startCounterTentativi < setting.TentativiPerIndovinare())
        {
            
            bool indovinare = int.TryParse(Console.ReadLine(), out int isGuessNumber);
            

            if (!indovinare)
            {
                msg.ValoreNonNumerico();
                iswin = 2;
                
            }
            else if (isGuessNumber != numeroDaIndovinare)
            {
                msg.NotGuessNumber();
                startCounterTentativi++;
                iswin = 2;
               

            }
            
            else 
            {
                iswin = 1;
                break;

            }
        }

        
        return iswin;
    }
}
class MessaggiConsole{

    public void ValoreNonNumerico()
    {
        Console.WriteLine("inserire un valore numerico valido");
    }

    public void NotGuessNumber()
    {
        Console.WriteLine("Hai sbagliato");
    }

    public void Vittoria()
    {
        Console.WriteLine("HAI VINTO");
    }

    public void TentativiFiniti()
    {
        Console.WriteLine("Tentativi finiti");
    }
    
}

class WinOrLose
{
    private ControlInput controlInput;
    private MessaggiConsole msg;

    public WinOrLose(ControlInput controlInput,MessaggiConsole msg)
    {
        this.controlInput = controlInput;
        this.msg = msg;
        
    }
    public enum VittoriaOSconfitta
    {
        Vittoria = 1,
        Sconfitta = 2
    }

    public void RisultatoFinale()
    {
        int controlloVittoria = controlInput.CheckWin();
        if (controlloVittoria == (int)VittoriaOSconfitta.Vittoria)
        {
            msg.Vittoria();
        }
        else
        {
            msg.TentativiFiniti();
        }
        
        
    }
}

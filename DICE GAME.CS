namespace ConsoleApp2;

class Program 
{ 
    static void Main(string[] args)
    {
        Setting setting = new Setting();
        Intro start = new Intro(setting);
        MessaggiConsole msg = new MessaggiConsole();
        LancioDeiDadi lancioDeiDadi = new LancioDeiDadi(setting);
        ControlInput controlInput = new ControlInput(lancioDeiDadi, setting,msg);
        WinOrLose winOrLose = new WinOrLose(controlInput,msg);

        start.Benvenuto();
        
        winOrLose.RisultatoFinale();



    }

        
    }

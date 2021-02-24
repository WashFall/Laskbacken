using System;
using System.Collections.Generic;

namespace Läskbacken
{
    public class Dryck //här gör jag klassen "Dryck" som används till att skapa objekten som vektorn "läskbacken" kommer innehålla
    {
        private string Namn; //variabel som representerar dryckens namn
        private double Pris; //variabel som representerar dryckens pris
        private string Sort; //denna variabel representerar dryckens sort, men den används inte genom programmet

        //konstruktor för objekten "Dryck"
        public Dryck(string namn, double pris, string sort) //denna metod tar in namn, pris och sort för varje objekt
        {
            this.Namn = namn; 
            this.Pris = pris;
            this.Sort = sort;
        }

        public string DryckNamn() //en enkel get-metod som returnerar namnet på ett objekt
        {
            return Namn;
        }

        public double DryckPris() //en get-metod som returnerar priset på ett objekt
        {
            return Pris;
        }
    }

    //här är klassen "Läskback" som skapar en vektor som rymmer alla objekt av klassen "Dryck"
    class Läskback //det är i denna klassen de flesta metoder finns, och i stort sett hela programmet körs härifrån
    {
        private Dryck[] läskbacken = new Dryck[24]; //här är en vektor som representerar "läskbacken", och har plats för 24 flaskor (Dryck)

        private static Dryck fanta = new Dryck("Fanta", 15.50, "Läsk"); //här skapar jag några objekt som användaren kan skicka in i läskbacken
        private static Dryck cola = new Dryck("Cola", 16.50, "Läsk");
        private static Dryck pripps = new Dryck("Pripps Blå", 13.95, "Folköl");
        private static Dryck mariestads = new Dryck("Mariestads", 12, "Folköl");
        private static Dryck loka = new Dryck("Loka", 7, "Vatten");
        private static Dryck ramlösa = new Dryck("Ramlösa", 7.95, "Vatten");

        //här gör jag en lista som innehåller alla "Drycker" som skapas
        private static List<Dryck> allaDrycker = new List<Dryck>() {fanta, cola, pripps, mariestads, loka, ramlösa}; 
        

        public void Run() //denna metod innehåller alla menyer i programmet. Härifrån anropas alla metoder
        {
            int exit = 0;
            while (exit != 1) //jag skapar en while-loop fom kör programmet tills variabeln "exit" blir 1
            {
                //jag skriver in titeln till huvudmenyn. För att starta resten av programmet måste användaren trycka på Enter-tangenten
                //för att avsluta programmet måste användaren trycka på Escape-tangenten. Inga andra tangenter gör något
                Console.WriteLine("Välkommen till din virtuella Läskback!\n\nTryck 'Enter' för att starta\n\nTryck 'Escape' för att avsluta");
                var start = Console.ReadKey().Key; //här lagrar jag en knapptryckning i variabeln "start"
                if (start == ConsoleKey.Escape) //om "start" är lika med Escape-tangenten så avslutas loopen, och programmet
                {
                    exit = 1; 
                }
                else if (start == ConsoleKey.Enter) //om "start" är lika med Enter-tangenten tas användaren vidare till programmets meny
                {
                    Console.Clear();
                    Console.WriteLine("---Välj ett alternativ genom att skriva in numret och trycka 'Enter'---"); //jag ger instruktioner till användaren
                    int avsluta = 0;
                    while (avsluta != 1) //jag gör en while-loop som körs till variabeln "avsluta" är lika med 1. Då stängs programmet av
                    {
                        Console.WriteLine("\n1.Lägg till dryck i backen\n\n2.Ta bort dryck från backen\n\n3.Visa backen\n\n4.Registrera ny dryck" +
                            "\n\n5.Sök efter dryck\n\n6.Byt plats på flaskor\n\n7.Sortera backen\n\n\n8.Avsluta"); //här skriver jag ut menyn med alla alternativ
                        int val = NummerVal(Console.ReadLine()); //för användarens input så anropar jag en metod innehållande ett try- och catch-block
                        Console.Clear(); //jag använder Console.Clear() genom programmet för att rensa skärmen, och göra allt lite tydligare

                        switch (val) //jag gör en switch-sats som jämför variabeln "val" med alla alternativ, och då vilka metoder som ska anropas
                        {
                            case 0: //om användaren skriver något som inte är en siffra, en för hög siffra eller 0 så skrivs denna text ut
                                Console.WriteLine("---Välj ett alternativ genom att skriva in numret och trycka 'Enter'---");
                                break;
                            case 1:
                                LäggTillDryck();
                                break;
                            case 2:
                                TaBortVal();
                                break;
                            case 3:
                                VisaBackMedPris();
                                BackPris();
                                break;
                            case 4:
                                RegistreraDryck();
                                break;
                            case 5:
                                SökaDryck();
                                break;
                            case 6:
                                BytaPlats();
                                break;
                            case 7:
                                SorteraBack();
                                break;
                            case 8: //skriver användaren 8 så avslutas programmet
                                avsluta = 1;
                                exit = 1;
                                break;

                        }
                    }
                }
                Console.Clear();
            }
        }

        private void LäggTillDryck() //denna metoden låter användaren lägga till flaskor i backen, det vill säga lägga till objekt av "Dryck" i vektorn "läskbacken[]"
        {
            Console.WriteLine("Vilken dryck vill du lägga till?");
            int nr = 1;
            foreach (Dryck dryck in allaDrycker) //jag skriver ut alla skapade objekt av "Dryck" i en lista för att användaren ska kunna läsa och välja -
            {                                    //vilken dryck som den vill lägga till i vektorn
                Console.WriteLine("\n" + nr + "." + dryck.DryckNamn()); //jag anropar get-metoden "DryckNamn" som returnerar namnet på ett objekt som en string-variabel
                nr++;
            }
            Console.WriteLine("\n\n{0}.Slumpa backen!", nr); //jag skriver ut ett alternativ för att slumpmässigt fylla backen med "Drycker"
            Console.WriteLine("\n{0}.Gå tillbaka", nr + 1); //ett alternativ för att gå tillbaka till menyn
            int val = NummerVal(Console.ReadLine()); //varje gång användaren ska skriva in en variabel så anropas metoden "NummerVal" som innehåller try och catch
                                                     //detta för att programmet ska kunna omvandla strängen till en siffra utan att krascha
            if (val == nr)
            {
                Random slumpa = new Random(); //här gör jag en variabel av Random för att slumpmässigt välja en av dryckerna i listan "allaDrycker"
                for (int i = 0; i < läskbacken.Length; i++) //jag loopar för att fylla alla platser i "läskbacken" med en slumpad "Dryck"
                {
                    int dryck = slumpa.Next(0, allaDrycker.Count);
                    läskbacken[i] = allaDrycker[dryck];
                }
                VisaBack(); //här anropar jag en metod som skriver ut hela vektorn "läskbacken[]"
                Console.WriteLine("\n---Tryck på valfri tangent för att fortsätta---");
                Console.ReadKey(); //jag ger instruktioner till användaren för att fortsätta programmet
            }
            else if (val == nr + 1) //här tas användaren tillbaka till menyn
            {
                Console.Clear();
                return; 
            }
            else if(val == 0) //ifall användaren skriver in något felaktigt skrivs detta ut och metoden anropas igen för att starta om
            {
                Console.Clear();
                Console.WriteLine("---Välj ett alternativ genom att skriva in numret och trycka 'Enter'---\n");
                LäggTillDryck();
            }
            else if(val < nr) //detta utförs om användaren valde en av "Dryckerna"
            {
                Console.Clear();
                string dryckNamn = allaDrycker[val - 1].DryckNamn(); //jag lagrar namnet på den valda drycken i en variabel
                int platser = TommaPlatser(läskbacken); //här anropar jag metoden "TommaPlatser" som kollar hur många tomma platser det finns i läskbacken
                int svar = 0;

                while (svar == 0) //jag gör en while-loop för att användaren ska kunna försöka igen om den skriver in något felaktigt
                {
                    if(platser == 0) //om det finns 0 lediga platser i backen skrivs detta ut, och användaren får ta bort en "Dryck"
                    {
                        Console.WriteLine("Backen är full, du måste ta bort en flaska!\n\nTryck valfri tangent för att välja en flaska att plocka bort");
                        Console.ReadKey();
                        TaBortFlaska(); //här anropas metoden "TaBortFlaska" som låter användaren välja en plats i läskbacken att tömma
                        platser++; //och variabeln "platser" ökar med 1 eftersom det nu finns en ledig plats
                    }
                    Console.WriteLine("Du har {0} lediga platser i backen.\nHur många {1} vill du lägga till?", platser, dryckNamn);
                    svar = NummerVal(Console.ReadLine()); //jag skriver ut mängden lediga platser och frågar hur många drycker användaren vill lägga till

                    if (svar == 0) //kollar så att användaren skriver in ett korrekt nummer
                    {
                        Console.Clear();
                        Console.WriteLine("---Skriv endast in ett nummer över 0 och tryck 'Enter'---\n");
                    }
                    else
                    {
                        for (int i = 0; i < svar; i++) //jag gör en for-loop för mängden flaskor användaren vill lägga i läskbacken 
                        {
                            for (int j = 0; j < läskbacken.Length; j++) //och en loop som går igenom hela vektorn "läskbacken" 
                            {
                                if (läskbacken[j] == null) //om det finns en tom plats i backen så läggs ett objekt av "Dryck" till 
                                {
                                    läskbacken[j] = allaDrycker[val - 1];
                                    j = 24; //jag gör variabeln "j" till 24 så att loopen kan startas om och inte fylla i alla tomma platser
                                }
                            }
                            platser--; //antalet lediga platser går ner
                        }
                    }
                }
                VisaBack(); //jag anropar "VisaBack" så användaren får en visuell representation av hur backen är fylld
                Console.WriteLine("\n---Tryck på valfri tangent för att fortsätta---");
                Console.ReadKey();
            }
            else //om användaren inte valde ett alternativ i menyn så startas metoden om med en anvisning till hur den bör göra
            {
                Console.Clear();
                Console.WriteLine("---Vänligen välj ett av alternativen på skärmen---\n");
                LäggTillDryck();
            }
            Console.Clear();
        }

        private void TaBortVal() //här är metoden "TaBortVal" som gör en meny för att användaren ska välja vilken "ta bort-metod" den vill använda
        {
            Console.Clear();
            int val;
            do //jag loopar så att användaren kan välja ett alternativ även om den skrev in något felaktigt
            {
                Console.WriteLine("Välj ett alternativ\n\n1.Ta bort en flaska\n2.Ta bort alla med samma namn\n3.Töm backen\n\n4.Gå tillbaka");
                val = NummerVal(Console.ReadLine()); //jag skriver ut en meny och testar användarens input
                if (val == 0 || val > 4)
                {
                    Console.WriteLine("---Skriv bara in en av siffrorna och tryck 'Enter'---\n"); //skrivs ut om inputen var felaktig
                }
                else if (val == 1) //om användaren bara vill ta bort en flaska så anropas följande metoder
                {
                    TaBortFlaska();
                    VisaBack();
                    Console.WriteLine("\n---Tryck på valfri tangent för att fortsätta---");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (val == 2) //om användaren vill ta bort alla av samma namn (till exempel alla "Fanta") så anropas följande metoder
                {
                    TaBortDryck();
                    VisaBack();
                    Console.WriteLine("\n---Tryck på valfri tangent för att fortsätta---");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (val == 3) //om användaren vill tömma hela backen (vektorn "läskbacken") så anropas följande metoder
                {
                    TömBack();
                    VisaBack();
                    Console.WriteLine("\n---Tryck på valfri tangent för att fortsätta---");
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.Clear();
            } while (val == 0 || val > 4);
        }

        private void TaBortFlaska() //denna metod används för att ta bort ett objekt av "Dryck" ifån vektorn "läskbacken"
        {
            int val = 0;
            while (val == 0) //jag skapar en while-loop för att låta användaren skriva in en korrekt input
            {
                VisaBack(); //jag visar hela backen med nummer framför varje flaska så användaren kan välja vilken den vill ta bort
                Console.WriteLine("\nVilken flaska vill du ta bort?: ");
                val = NummerVal(Console.ReadLine());
                if (val == 0 || val > 24) //om fel nummer (eller inget nummer alls) skrivs in så skrivs detta ut och loopen börjar om
                {
                    Console.Clear();
                    Console.WriteLine("---Du måste välja ett av numren på skärmen---\n\nTryck på valfri tangent för att pröva igen");
                    val = 0;
                    Console.ReadKey();
                }
            }
            läskbacken[val - 1] = null; //här byts objektet på vektorns index ut till null (tas bort)
            Console.Clear(); //det står "val - 1" eftersom jag listar upp alla flaskor från 1-24, men indexet går från 0-23
        }

        private void TaBortDryck() //denna metod tar bort alla objekt av "Dryck" som har samma namn
        {
            Console.Clear();
            int nr = 1;
            foreach(Dryck dryck in allaDrycker) //jag skriver ut alla drycker användaren kan välja på
            {
                Console.WriteLine("\n" + nr + "." + dryck.DryckNamn());
                nr++;
            }
            Console.WriteLine("\nVilken vill du ta bort?: ");
            int val = NummerVal(Console.ReadLine()); //användaren får välja vilken dryck den vill ta bort

            for(int i = 0; i < läskbacken.Length; i++) //jag gör en loop som går igenom hela vektorn
            {
                if (läskbacken[i] != null) //om indexet är ett objekt, det vill säga om det inte är null så görs följande
                {
                    if (läskbacken[i].DryckNamn() == allaDrycker[val - 1].DryckNamn()) //om indexets namn är samma som valets namn
                    {
                        läskbacken[i] = null; //så byts objektet ut mot null
                    }
                }
            }
        }

        private void TömBack() //denna metod ersätter alla index i vektorn "läskbacken" med null, alltså tar bort alla objekt
        {
            for(int i = 0; i < läskbacken.Length; i++)
            {
                läskbacken[i] = null;
            }
        }

        private void BytaPlats() //denna metod låter användaren byta plats på två objekt i vektorn (eller med ett objekt och null)
        {
            int första = 0;
            int andra = 0; //jag skapar två variabler som kommer inehålla användarens val av flaskor som ska bytas
            while (första == 0 || första > 24) //jag gör en loop ifall användaren skriver in ett felaktigt tal
            {
                VisaBack(); //jag visar innehållet och låter användaren välja en "Dryck"
                Console.WriteLine("Vilken vill du flytta?: ");
                första = NummerVal(Console.ReadLine());

                if(första == 0 || första > 24) //detta skrivs ut om inputen är ogiltig
                {
                    Console.Clear();
                    Console.WriteLine("---Du måste välja ett av numren på skärmen---\n\nTryck på valfri tangent för att försöka igen");
                    Console.ReadKey();
                }
            }
            while (andra == 0 || andra > 24) //därefter händer samma som ovan, fast med den andra variabeln, alltså det andra objektet som ska flyttas
            {
                VisaBack();
                Console.WriteLine("Vilken vill du byta med?: ");
                andra = NummerVal(Console.ReadLine());

                if (andra == 0 || andra > 24)
                {
                    Console.Clear();
                    Console.WriteLine("---Du måste välja ett av numren på skärmen---\n\nTryck på valfri tangent för att försöka igen");
                    Console.ReadKey();
                }
            }
            Console.Clear();

            Dryck kopia = läskbacken[första - 1]; //jag gör en kopia på den första "Drycken"
            läskbacken[första - 1] = läskbacken[andra - 1]; //jag gör den första drycken till den andra drycken
            läskbacken[andra - 1] = kopia; //och jag gör den andra drycken till kopian av den första
            VisaBack();
            Console.WriteLine("\n---Tryck på valfri tangent för att fortsätta---");
            Console.ReadKey();
            Console.Clear();
        }

        private void SökaDryck() //denna metod låter användaren skriva in ett namn på en dryck och se hur många av den som finns i backen
        {
            Console.Clear();
            Console.WriteLine("Välj vilken dryck du vill söka efter:");
            string dryckNamn = Console.ReadLine().ToLower(); //jag tar emot användarens input och omvandlar det till små bokstäver
            Console.Clear();

            int antalFlaskor = 0;
            List<int> dryckPlatser = new List<int>(); //jag gör en lista som fylls med alla platser i vektorn "läskbacken" som den sökta drycken finns på

            for (int i = 0; i < läskbacken.Length; i++) //jag gör en loop som går igenom vektorn
            {
                if (läskbacken[i] != null) //jag kollar så att indexet inte är tomt
                {   //jag jämför användarens sökning med namnet på alla Drycker i vektorn, om de är samma så läggs indexet till i listan
                    if (dryckNamn == läskbacken[i].DryckNamn() || dryckNamn == läskbacken[i].DryckNamn().ToLower()) //jag jämför även med dryckernas namn i små bokstäver
                    {
                        antalFlaskor++;
                        dryckPlatser.Add(i + 1);
                    }
                }
            }//här skriver jag ut hur många flaskor av den sökta typen som finns i vektorn, och jag tar sökningen och gör första bokstaven stor, och resten av ordet till små bokstäver
            Console.WriteLine("Det finns {0} {1}-flaskor i läskbacken", antalFlaskor, dryckNamn[0].ToString().ToUpper() + dryckNamn.Substring(1).ToLower());
            if (antalFlaskor == 1)                                      
            {
                Console.WriteLine("\nDen finns på plats {0}", dryckPlatser[0]); //detta skrivs ut om det bara finns en flaska av den typen i vektorn
            }
            else if (antalFlaskor > 1)
            {
                Console.Write("\nDe finns på platserna "); //här skrivs alla platser den sökta drycken finns på ut
                foreach(int plats in dryckPlatser)
                {
                    if (plats == dryckPlatser[0]) //den första platsen skrivs ut här, och resten med ett kommatecken före
                    {
                        Console.Write(plats);
                    }
                    else
                    {
                        Console.Write(", " + plats);
                    }
                }
            }
            Console.WriteLine("\n---Tryck på valfri tangent för att fortsätta---");
            Console.ReadKey();
            Console.Clear();
        }

        private void VisaBack() //denna metod skriver ut innehållet i vektorn "läskbacken"
        {
            Console.Clear();
            int nr = 1;
            for (int i = 0; i < läskbacken.Length; i++)
            {
                if (läskbacken[i] != null)
                {
                    Console.WriteLine(nr + "." + läskbacken[i].DryckNamn()); //jag skriver ut dryckernas namn för varje dryck i backen
                }
                else
                {
                    Console.WriteLine("{0}.Tom plats", nr); //om det inte finns en dryck på ett index skrivs istället "Tom Plats" ut
                }
                nr++;
            }
        }
        private void VisaBackMedPris() //denna metod skriver också ut backens innehåll, men nu skrivs alla objekt av "Dryck"s priser ut också
        {
            Console.Clear();
            int nr = 1;
            for (int i = 0; i < läskbacken.Length; i++)
            {
                if (läskbacken[i] != null)
                {                           //här anropar jag båda get-metoder jag skapat, alltså för objektens namn och priser
                    Console.WriteLine(nr + "." + läskbacken[i].DryckNamn() + " - - - " + läskbacken[i].DryckPris() + " kr");
                }
                else
                {
                    Console.WriteLine("{0}.Tom plats", nr);
                }
                nr++;
            }
        }
        private void BackPris() //denna metoden räknar ihop alla läskbackens objekts priser och skriver ut den totala kostnaden för alla flaskor
        {
            double helaPriset = 0;
            foreach(Dryck flaska in läskbacken) //jag gör en loop för varje index i vektorn "läskbacken"
            {
                if(flaska != null) //om indexet inte är null
                {
                    helaPriset += flaska.DryckPris(); //så plussas objektets pris på till variabeln "helaPriset"
                }
            }
            Console.WriteLine("\nDet totala priset för din back är: {0:c}", Math.Round(helaPriset, 2));
            Console.WriteLine("\n---Tryck på valfri tangent för att fortsätta---"); //jag skriver ut hela priset och omvandlar det till valuta, i detta fall kronor
            Console.ReadKey();
            Console.Clear();
        }

        private void SorteraBack() //denna metod är en meny för de två olika metoderna som sorterar vektorn "läskbacken"
        {
            int input = 0;
            while (input == 0 || input > 2) //jag gör en while-loop för att användaren ska skriva in en korrekt siffra
            {
                Console.WriteLine("1.Sortera efter bokstavsordning\n\n2.Sortera efter pris");
                input = NummerVal(Console.ReadLine());
                if (input == 1) //de får välja mellan att sortera efter objektens pris eller i bokstavsordning
                {
                    SorteraBokstav(); //jag anropar en metod som sorterar efter bokstavsordning
                }
                else if (input == 2)
                {
                    SorteraPris(); //jag anropar en metod som sorterar efter pris
                }
                else
                {
                    Console.Clear(); //detta skrivs ut om de inte valde 1 eller 2
                    Console.WriteLine("---Välj antingen 1 eller 2---\n");
                    input = 0;
                }
            }
        }
        
        private void SorteraBokstav() //denna metod sorterar alla drycker i vektorn "läskbacken" efter bokstavsordning
        {
            Console.Clear();
            for(int i = 0; i < läskbacken.Length; i++)
            {
                if (läskbacken[i] != null)
                {
                    for (int j = 0; j < läskbacken.Length - 1; j++) //jag gör två loopar för att skapa en bubble sort
                    {                                               //denna jämför varje objekt med sin granne, och byter dem om den ena är "större" än den andra
                        if (läskbacken[j] != null)
                        {
                            int index = 0; //jag gör variabeln "index" för att kunna ändra värdet på den
                            int bokstav1 = läskbacken[j].DryckNamn()[index]; //jag gör två variabler som ska representera den första bokstaven i varje drycks namn
                            int bokstav2 = 1000; //jag sätter den andra till 1000, så att om indexet i vektorn inte innehåller ett objekt -
                                                 //så sorteras de "neråt" i vektorn. Då hamnar alla tomma platser i bottnen, och alla drycker uppåt 

                            if (läskbacken[j + 1] != null) //om indexet i vektorn inte är null händer detta
                            {
                                bokstav2 = läskbacken[j + 1].DryckNamn()[index]; //jag gör "bokstav2" till första bokstaven i objektets namn
                            }

                            if(läskbacken[j] != läskbacken[j + 1]) //här kollar jag så att de två objekten inte är likadana
                                //denna if-sats är till för att jämföra två objekt som börjar på samma bokstav, men har två olika namn (till exempel "Pripps" och "Pepsi")
                            {
                                while(bokstav2 == bokstav1) //om bokstäverna är likadana...
                                {
                                    index++; //variabeln index ökar med 1 för att testa nästa bokstav i objektens namn
                                    bokstav1 = läskbacken[j].DryckNamn()[index];
                                    bokstav2 = läskbacken[j + 1].DryckNamn()[index];
                                } //detta pågår tills bokstäverna är olika
                            }

                            if (bokstav2 < bokstav1) //om bokstav2 är större än bokstav1 så byter de plats
                            {
                                Dryck kopia = läskbacken[j + 1];
                                läskbacken[j + 1] = läskbacken[j];
                                läskbacken[j] = kopia;
                            }

                        }
                        else //objekten byter plats med null
                        {
                            Dryck kopia = läskbacken[j + 1];
                            läskbacken[j + 1] = läskbacken[j];
                            läskbacken[j] = kopia;
                        }
                    }
                }
            }
            VisaBack(); //och jag visar resultatet i slutet
            Console.WriteLine("\n---Tryck på valfri tangent för att fortsätta---");
            Console.ReadKey();
            Console.Clear();
        }

        private void SorteraPris() //denna metod sorterar efter priset på alla objekten i vektorn
        {
            for (int i = 0; i < läskbacken.Length; i++)
            {
                if (läskbacken[i] != null)
                {
                    for(int j = 0; j < läskbacken.Length - 1; j++) //gör återigen en bubble sort
                    {
                        if(läskbacken[j] != null)
                        {
                            if (läskbacken[j + 1] != null) //jag kollar så att båda objekten jag jämför inte är null
                            {
                                if (läskbacken[j + 1].DryckPris() < läskbacken[j].DryckPris()) //jag jämför priserna på objekten
                                {
                                    Dryck kopia = läskbacken[j + 1]; //och byter plats på dem om det ena priset är högre än det andra
                                    läskbacken[j + 1] = läskbacken[j];
                                    läskbacken[j] = kopia;
                                }
                            }
                        }
                        else //jag byter plats på objekt och null
                        {
                            Dryck kopia = läskbacken[j + 1];
                            läskbacken[j + 1] = läskbacken[j];
                            läskbacken[j] = kopia;
                        }
                    }
                }
            }
            VisaBackMedPris(); //efteråt visar jag resultatet med synliga priser på objekten
            BackPris(); //och jag skriver ut det totala priset på backen
            Console.Clear();
        }

        private void RegistreraDryck() //denna metod används för att användaren ska kunna skapa nya objekt av "Dryck" som de kan lägga in i vektorn "läskbacken"
        {
            Console.Clear();
            Console.WriteLine("Vad heter drycken?");
            string namn = Console.ReadLine(); //jag frågar efter dryckens namn
            Console.Clear();
            Console.WriteLine("Vad kostar drycken?");
            int försök = 0;
            double pris = -1; //jag frågar efter dryckens pris
            while (försök == 0) //jag gör en loop för att användaren ska skriva in ett korrekt pris
            {
                pris = Prissättning(Console.ReadLine()); //jag anropar metoden "Prissättning" som innehåller ett try- och catch-block för att omvandla en string till double (flyttal)
                if(pris == -1)
                {
                    Console.Clear(); //detta skrivs ut om användaren skrivit in något felaktigt
                    Console.WriteLine("---Vänligen skriv endast in ett pris med siffror och ett kommatecken om priset har decimaler---");
                    Console.WriteLine("\nVad kostar drycken?");
                }
                else
                {
                    försök++; //annars kliver programmet ur loopen
                }
            }
            Console.Clear();
            Console.WriteLine("Vad är den för typ?");
            string sort = Console.ReadLine(); //jag frågar vilken typ av dryck det är

            Dryck nyDryck = new Dryck(namn, pris, sort); //och sedan skapar jag ett nytt objekt av klassen "Dryck" genom att anropa konstruktorn
            allaDrycker.Add(nyDryck); //objektet läggs till i listan med de andra dryckerna

            Console.Clear();
            Console.WriteLine("{0} är nu registrerad!", namn); //jag skriver ut att den nya drycken är registrerad och låter användaren gå tillbaka till menyn
            Console.WriteLine("\n---Tryck på valfri tangent för att fortsätta---");
            Console.ReadKey();
            Console.Clear();
        }

        private int TommaPlatser(Dryck[] läskback) //denna metod kollar hur många index i vektorn "läskbacken" som är null
        {
            int platser = 0;
            foreach(Dryck plats in läskbacken) //jag loopar igenom vektorn
            {
                if (plats == null) //om platsen är null så ökar variabeln "platser" med 1
                    platser++;
            }
            return platser; //värdet returneras
        }
        private int NummerVal(string val) //denna metod försöker omvandla en string till en int
        {
            int nummer = 0;

            try
            { //jag försöker omvandla
                nummer = int.Parse(val);
                return nummer; //och om det lyckas så returnerar jag resultatet
            }
            catch
            {
                return nummer; //om det misslyckas så returnerar jag 0
            }
        }

        private double Prissättning(string flyttal) //denna metod försöker omvandla en string till en double
        {
            double pris = -1;

            try
            { //försöker konvertera strängen till ett flyttal
                pris = Convert.ToDouble(flyttal);
                return pris; //om det lyckas returnerar jag priset
            }
            catch
            {
                return pris; //om det misslyckas returneras -1
            }
        }
    }

    class Program //här är klassen Program, som är där hela programmet startar
    {
        static void Main(string[] args) //metoden "Main" används för att starta programmet
        {

            Läskback läskbacken = new Läskback(); //jag skapar läskbacken
            läskbacken.Run(); //jag kör metoden "Run" ifrån klassen Läskbacken, som innehåller nästan hela programmet
        }

    }
}

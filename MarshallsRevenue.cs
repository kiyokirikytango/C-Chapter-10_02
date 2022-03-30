using System;
using static System.Console;
using System.Globalization;
 class MarshallsRevenue
    {
        static void Main()
        {
            //Set of variables and arrays 
            const int MAX_MURALS = 30;
            int month;
            int numInterior;
            int numExterior;
            double totalIn = 0;
            double totalEx = 0;
            InteriorMural[] interiorMurals = new InteriorMural[MAX_MURALS];
            ExteriorMural[] exteriorMurals = new ExteriorMural[MAX_MURALS];
            month = getMonth();
            for (int x = 0; x < MAX_MURALS; ++x)
            {
                interiorMurals[x] = new InteriorMural(month);
                exteriorMurals[x] = new ExteriorMural(month);
            }
            //prints the methods with the returns 
            numInterior = getNumMurals("interior");
            numExterior = getNumMurals("exterior");
            totalIn = dataEntry("interior", numInterior, month, interiorMurals);
            totalEx = dataEntry("exterior", numExterior, month, exteriorMurals);
            WriteLine("Total revenue for interior murals is " + totalIn.ToString("C", CultureInfo.GetCultureInfo("en-US")));
            WriteLine("Total revenue for exterior murals is " + totalEx.ToString("C", CultureInfo.GetCultureInfo("en-US")));
            WriteLine("Total revenue is " + (totalIn + totalEx).ToString("C", CultureInfo.GetCultureInfo("en-US")));
            getSelectedMurals(interiorMurals, exteriorMurals);
        }
        private static int getMonth()
        {

            //userinputs a month 1-12,converted to INT 
            string entryString;
            int month = 0;
            WriteLine("Enter the month>>");
            entryString = ReadLine();
            int.TryParse(entryString, out month);
            //if user doesnt input 1-12,they try again            
            while (month <= 0 || month > 12 || (!int.TryParse(entryString, out month)))
            {
                WriteLine("Wrong format,Enter the month>>");
                entryString = ReadLine();
                int.TryParse(entryString, out month);
            }
            return month;
        }
        private static int getNumMurals(string location)
        {
            //user inputs number of interior/exterior murals
            int mural = 0;
            string entryString;
            const int MIN_MURALS = 0;
            const int MAX_MURALS = 30;
            Write("Enter number of {0} murals scheduled: ", location);
            entryString = ReadLine();
            int.TryParse(entryString, out mural);
            while (mural < MIN_MURALS || mural > MAX_MURALS || (!int.TryParse(entryString, out mural)))
            //if user doesnt input between 0-30, it trys again             
            {
                Write("Wrong Format,Enter number of {0} murals scheduled: ", location);
                entryString = ReadLine();
                int.TryParse(entryString, out mural);

            }
            return mural;
        }


        private static double dataEntry(string location, int num, int month, Mural[] murals)
        {
            string entryString;
            bool isValid;
            int x;
            char code;
            double tot = 0;
            WriteLine("\n\nEntering {0} jobs:", location);
            x = 0;
            //while loop that enters number, adds name to mural ,and how many
            while (x < num)
            {
                tot += murals[x].Price;
                Write("Enter customers name: ");
                murals[x].Name = ReadLine();
                WriteLine("Mural options are: ");
                for (int y = 0; y < Mural.muralCodes.Length; ++y)
                    WriteLine("  {0}   {1}", Mural.muralCodes[y], Mural.muralTypes[y]);
                Write("Enter mural style code: ");
                entryString = ReadLine();
                isValid = false;
                char[] m = Mural.muralCodes;
                bool correct = false;
                while (!isValid)
                {
                    code = char.Parse(entryString);
                    for (int i = 0; i < m.Length; i++)
                    {
                        if (code == m[i])
                        {
                            correct = true;
                            break;
                        }
                    }
                    if (correct == false)
                    {
                        throw new System.Exception();
                    }
                    else
                    {
                        murals[x].Code = code;
                        isValid = true;
                    }
                }


                ++x;
            }
            //returns the total of either interior or exterior murals
            return tot;
        }

        private static void getSelectedMurals(Mural[] interiors, Mural[] exteriors)
        {
            //userinputs mural code to demonstrate which name is with what mural   
            char option = ' ';
            const char QUIT = 'Z';
            bool isValid = false;
            bool found;
            int pos = 0;
            int x;
            string entryString;
            Write("\nEnter a mural type or {0} to quit >> ", QUIT);
            entryString = ReadLine();
            while (!isValid)
            {
                //will run until user inputs QUIT 
                option = char.Parse(entryString);
                if (option == QUIT)
                    isValid = true;
                else
                {
                    for (int z = 0; z < Mural.muralCodes.Length; ++z)
                    {
                        if (option == Mural.muralCodes[z])
                        {
                            isValid = true;
                            pos = z;
                        }
                    }
                    //if user uputs anything besides mural code or quit it will ask again    
                    if (!isValid)
                    {
                        WriteLine("{0} is not a valid code", option);
                        Write("\nEnter a mural type or {0} to quit >> ", QUIT);
                        entryString = ReadLine();
                    }
                }

                
                if (isValid && option != QUIT)
                {
                    WriteLine("\nCustomers ordering {0} murals are:",
    Mural.muralTypes[pos]);
                    found = false;
                    for (x = 0; x < interiors.Length; ++x)
                    {
                        //displays the interior mural the customers name and the price of their specific mural
                        if (interiors[x].Code == option)
                        {
                            WriteLine(interiors[x].ToString());
                            found = true;
                        }
                    }
                    for (x = 0; x < exteriors.Length; ++x)
                    {

                        if (exteriors[x].Code == option)
                        {
                            //displays the exterior mural the customers name and the price of their specific mural
                            WriteLine(exteriors[x].ToString());
                            found = true;
                        }
                    }
                    //if no mural were added it will print this
                    if (!found)
                        WriteLine("No customers ordered {0} murals",Mural.muralTypes[pos]);
                    //will keep askin for mural type till Quit is selected
                    Write("\nEnter a mural type or {0} to quit >> ", QUIT);
                    entryString = ReadLine();
                    isValid = false;
                }
            }
        }
    }
    class Mural
    {
        //class contains fields for a mural code (code) and description (muralType) 
        public static char[] muralCodes = { 'L', 'S', 'A', 'C', 'O' };
        public static string[] muralTypes = {"Landscape",
      "Seascape", "Abstract", "Children's", "Other"};
        //get set method to get name
        public string Name { get; set; }

        private char code;

        private string muralType;
        public Mural()
        {
            Name = "";
            Code = 'I';
        }
    public char Code
        {
            get
            {
                return code;
            }
            set
            {
                //if user enter anything besides the talents or Z
                int pos = muralCodes.Length;
                for (int z = 0; z < muralCodes.Length; ++z)
                    if(value == muralCodes[z])
                        pos = z;
                if (pos == muralCodes.Length)
                {
                    code = 'I';
                    muralType = "Invalid";
                }
                else
                {
                    code = value;
                    muralType = muralTypes[pos];
                }
            }
        }
        public string MuralType
        {
            get
            {
                return muralType;
            }
        }
        //get set method to get price
        public double Price { get; set; }
  }
    //subclass of mural
  class InteriorMural : Mural
    {
        //set variable
        const int interiorPrice = 500;
        const int discountPrice = 450;
        //constructor
        public InteriorMural(int month)
        {
            //dependig on the month the price changes
            if (month == 7 || month == 8)
                Price = discountPrice;
            else
                Price = interiorPrice;
        }
        //override string to display a differnt price according to the mural and month
        public override string ToString()
        {
            return ("Interior, " + MuralType + " mural for Customer: " + Name + "  Price " + Price.ToString("C", CultureInfo.GetCultureInfo("en-US")));
        }
    }
    //subclass of mural
    class ExteriorMural : Mural
    {
        //set variable
        const int exteriorPrice = 750;
        const int discountPrice = 699;
        public ExteriorMural(int month)
        {
            //dependig on the month the price changes
            if (month == 12 || month == 1 || month == 2)
                Price = 0;
            else
               if (month == 4 || month == 5 || month == 9 || month == 10)
                Price = discountPrice;
            else
                Price = exteriorPrice;
        }
        //override string to display a differnt price according to the mural and month
        public override string ToString()
        {
            return ("Exterior, " + MuralType + " " + "mural for Customer: " + Name + "  Price " + Price.ToString("C", CultureInfo.GetCultureInfo("en-US")));
        }
    }

using System;

namespace Midterm_Final
{
    internal class Program
    {
        public static void Main(string[] args = null) //main method set to null in order for it to be called as a method
        {
            //variable declarations for loop approval
            char yn = default(char);
            char ep;

            do
            {
                Console.Clear(); // clears the console for cleaner look whenever a loop is about to be executed again
                PrimaryMethods.HomePage(); // no need instantiation for methods in static class, shows homepage
                int userSelect = PrimaryMethods.UserSelection(); //asks if user, owner, or neither

                //conditionals for the choices
                {
                    if (userSelect == 2) //if owner
                    {
                        PrimaryMethods.Login(); //Redirects to the login page
                    }

                    else if (userSelect == 1) //if user
                    {
                        User u = new User(); //instantiates new user
                        u.Greet(); //greets user 
                        PrimaryMethods.Extend(); //starts the static method for dropping coins in pc
                    }
                    else //neither user nor owner
                    {
                        Environment.Exit(0); //exits the console automatically
                    }
                }

                /*assuming all of the processes are done*/

                if (userSelect == 1) //if user
                {
                    yn = PrimaryMethods.EndPromptUser(); //shows prompt if user wants to loop the menu or log out
                    if (yn == 'e') //if loop the menu
                    {
                        do
                        {
                            Console.Clear(); 
                            PrimaryMethods.ExtendPage(); //static method that shows extend page instead of home page
                            PrimaryMethods.Extend(); //starts the static method for dropping coins in pc
                            ep = PrimaryMethods.EndPromptUser(); //shows prompt if user wants to loop the menu or log out and assigns value input to ep
                            if (ep == 'l') //if log out
                            {
                                yn = ep; //assigns the value to yn in order to go to the main do-while loop and go back to home page
                                break; //stops the loop
                            }
                        } while (ep == 'e'); //loop condition for the extend page
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (userSelect == 2) //if owner
                {
                    yn = PrimaryMethods.EndPromptOwner(); //shows prompt if owner wants to loop the menu or log out
                    if (yn == 'e') //if loop the menu
                    {
                        do
                        {
                            PrimaryMethods.OwnerMenu(); //static method to show the owner menu
                            ep = PrimaryMethods.EndPromptOwner(); //shows prompt if user wants to loop the menu or log out and assigns value input to ep
                            if (ep == 'l') //if log out
                            {
                                yn = ep; //assigns the value to yn in order to go to the main do-while loop and go back to home page
                                break; //stops the loop
                            }
                        } while (ep == 'e'); //loop condition for the owner menu page
                    }
                }
            } while (yn == 'l'); //main do-while loop for log out redirecting to homepage
            Console.ReadKey();
        }
    }
    public class Human //Parent class Human
    {
        private string name; //field

        public string Name //property
        {
            get { return name; } set { name = value; }
        }

        public virtual void Greet() //base greeting method
        {
            Console.Write("\nHello,");
        }
    }
    public class User : Human //Child class User that inherits human
    {
        //constructor
        public User() //asks for user name
        {
            Console.Write("Enter name: ");
            Name = Console.ReadLine();
        }

        //method
        public override void Greet() //greets user
        {
            base.Greet();
            Console.WriteLine($" user {Name}! Welcome to Jermz Piso Net.");
        }
    }
    public class Owner : Human //Child class Owner that inherits human
    {
        private string username, password, id; //fields

        //properties
        public string Id
        {
            get { return id; } set { id = value; }
        }
        public string Username
        {
            get { return username; } set { username = value; }
        }
        public string Password
        {
            get { return password; } set { password = value; }
        }

        //constructor with parameters
        public Owner(string name, string username, string password, string id)
        {
            Name = name;
            Id = id;
            Username = username;
            Password = password;
        }

        //method
        public override void Greet() //greets owner
        {
            base.Greet();
            Console.WriteLine($" owner {Id} {Name}!");
            Console.Write("\nI would like to:\n(1) Check my money   (2) Take money || "); //owner menu
        }

    }
    public class Coins //Parent class Coins
    {
        //fields
        private int pc1, pc2, pc3, pc4, pc5; //stores coins dropped in each PC
        private int pChoice, time; //stores PC choice value and general time value
        static private int pisoTotal, singkoTotal, dyisTotal, total; //stores total values of each coin as well as the subtotal of all coins
        private int piso, singko, dyis; //values of the coins dropped in each PC and serves as an updater for total values of coins
        public int hour, min; //time values 

        //properties
        public int Pc1
        {
            get { return pc1; } set { pc1 = value; }
        }
        public int Pc2
        {
            get { return pc2; } set { pc2 = value; }
        }
        public int Pc3
        {
            get { return pc3; } set { pc3 = value; }
        }
        public int Pc4
        {
            get { return pc4; } set { pc4 = value; }
        }
        public int Pc5
        {
            get { return pc5; } set { pc5 = value; }
        }
        public int PChoice
        {
            get { return pChoice; } set { pChoice = value; }
        }
        public int Time
        {
            get { return time; } set { time = value; }
        }
        public int Total
        {
            get { return total; } set { total = value; }
        }
        public int PisoTotal
        {
            get { return pisoTotal; } set { pisoTotal = value; }
        }
        public int SingkoTotal
        {
            get { return singkoTotal; } set { singkoTotal = value; }
        }
        public int DyisTotal
        {
            get { return dyisTotal; } set { dyisTotal = value; }
        }
        public int Piso
        {
            get { return piso; } set { piso = value; }
        }
        public int Singko
        {
            get { return singko; } set { singko = value; }
        }
        public int Dyis
        {
            get { return dyis; } set { dyis = value; }
        }

        //methods
        public virtual void Kaching() //sound effect for dropped coins
        {
            Console.WriteLine("\nKaching!");
        }
        public virtual void CalculateTime() //Calculates the time for money spent on a PC, but in the base only the greeting is executed
        {
            Console.WriteLine("Enjoy your time!");
        }
        public virtual void CalculateMoney() //base method for calculating money
        {}
        public void TimePass() //method to display that time has passed and time is up
        {
            for (int i = 0; i < 100; i++)
                System.Threading.Thread.Sleep(1);
            Console.WriteLine("\n\nSome time has passed... Your Time is Up!");
        }
        public void CheckMoney() //method to display total coins and total values of coins and the total income
        {
            Total = PisoTotal + SingkoTotal + DyisTotal;
            Console.WriteLine($"\nPiso:         P {PisoTotal} ({PisoTotal}) ");
            Console.WriteLine($"Singko:       P {SingkoTotal} ({SingkoTotal / 5})");
            Console.WriteLine($"Dyis:         P {DyisTotal} ({DyisTotal / 10})");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Total Income: P {Total}");
        }
        public void TakeMoney() //method to take money from the total 
        {
            Console.Write("\nHow much money would you like to take? P ");
            int moneyTake = int.Parse(Console.ReadLine());
            int quo, rem;
            if (moneyTake <= Total && moneyTake > 0) //If money can be taken from the storage
            {
                Console.WriteLine($"You have taken P {moneyTake} from the cash storage. Spend it wisely!\nCoin Totals have been updated, some coins were converted to higher denominations.");
                Total -= moneyTake; //subtracts the money taken from the total
                DyisTotal = 0;
                PisoTotal = 0;
                SingkoTotal = 0;
                //updates the coins to the highest denominations possible
                while(Total/10!= 0)
                {
                    quo = Total / 10;
                    rem = Total % 10;
                    Total = (quo * 10);
                    DyisTotal = Total;
                    Total = rem;
                }
                while(Total/5 != 0)
                {
                    quo = Total / 5;
                    rem = Total % 5;
                    Total = (quo * 5);
                    SingkoTotal = Total;
                    Total = rem;
                }
                PisoTotal = Total;
            }
            else if (moneyTake > Total) //if money is not enough
            {
                Console.WriteLine("Your money is not enough!");
            }
            else if (moneyTake <= 0) //if invalid input of money
            {
                Console.WriteLine("Is that even a quantity of money?");
            }

        }
    }
    public class Piso : Coins //Child class Piso that inherits Coins
    {
        //fields
        static int tMultiplier = 6, mMultiplier = 1; //time multiplier and money multiplier for piso

        //constructor
        public Piso(int pChoice)
        {
            Console.Write("How many piso would you like to drop? ");
            PChoice = pChoice;
            switch (PChoice)
            {
                case 1: Pc1 = int.Parse(Console.ReadLine()); break;
                case 2: Pc2 = int.Parse(Console.ReadLine()); break;
                case 3: Pc3 = int.Parse(Console.ReadLine()); break;
                case 4: Pc4 = int.Parse(Console.ReadLine()); break;
                case 5: Pc5 = int.Parse(Console.ReadLine()); break;
            }
        }

        //methods
        public override void Kaching() //sound effect for coins dropped and serves as confirmation statement
        {
            base.Kaching();
            switch (PChoice)
            {
                case 1: Console.WriteLine($"{Pc1} piso coins has been dropped in PC 1."); break;
                case 2: Console.WriteLine($"{Pc2} piso coins has been dropped in PC 2."); break;
                case 3: Console.WriteLine($"{Pc3} piso coins has been dropped in PC 3."); break;
                case 4: Console.WriteLine($"{Pc4} piso coins has been dropped in PC 4."); break;
                case 5: Console.WriteLine($"{Pc5} piso coins has been dropped in PC 5."); break;
            }
        }
        public override void CalculateTime() //calculates the time in hours and seconds depending on the coins dropped
        {
            Console.WriteLine("");
            switch (PChoice)
            {
                case 1:
                    Time = Pc1 * tMultiplier;
                    if (Time >= 60)
                    {
                        hour = Time / 60;
                        min = Time % 60;
                        Console.WriteLine($"You have {hour} hours and {min} minutes to use this PC.");
                    }
                    else
                    {
                        Console.WriteLine($"You have {Time} minutes to use this PC.");
                    }
                    break;
                case 2:
                    Time = Pc2 * tMultiplier;
                    if (Time >= 60)
                    {
                        hour = Time / 60;
                        min = Time % 60;
                        Console.WriteLine($"You have {hour} hours and {min} minutes to use this PC.");
                    }
                    else
                    {
                        Console.WriteLine($"You have {Time} minutes to use this PC.");
                    }
                    break;
                case 3:
                    Time = Pc3 * tMultiplier;
                    if (Time >= 60)
                    {
                        hour = Time / 60;
                        min = Time % 60;
                        Console.WriteLine($"You have {hour} hours and {min} minutes to use this PC.");
                    }
                    else
                    {
                        Console.WriteLine($"You have {Time} minutes to use this PC.");
                    }
                    break;
                case 4:
                    Time = Pc4 * tMultiplier;
                    if (Time >= 60)
                    {
                        hour = Time / 60;
                        min = Time % 60;
                        Console.WriteLine($"You have {hour} hours and {min} minutes to use this PC.");
                    }
                    else
                    {
                        Console.WriteLine($"You have {Time} minutes to use this PC.");
                    }
                    break;
                case 5:
                    Time = Pc5 * tMultiplier;
                    if (Time >= 60)
                    {
                        hour = Time / 60;
                        min = Time % 60;
                        Console.WriteLine($"You have {hour} hours and {min} minutes to use this PC.");
                    }
                    else
                    {
                        Console.WriteLine($"You have {Time} minutes to use this PC.");
                    }
                    break;
            }
            base.CalculateTime(); //calls the base method
        }
        public override void CalculateMoney() //calculates the total amount of piso (value)
        {
            switch (PChoice)
            {
                case 1:
                    Piso = Pc1 * mMultiplier;
                    break;
                case 2:
                    Piso = Pc2 * mMultiplier;
                    break;
                case 3:
                    Piso = Pc3 * mMultiplier;
                    break;
                case 4:
                    Piso = Pc4 * mMultiplier;
                    break;
                case 5:
                    Piso = Pc5 * mMultiplier;
                    break;
            }
            PisoTotal += Piso; //updates PisoTotal based on added piso
        }
    }
    public class Singko : Coins //Child class Singko that inherits Coins
    {
        //fields
        static int tMultiplier = 30, mMultiplier = 5; //time multiplier and money multiplier for singko

        //constructor
        public Singko(int pChoice)
        {
            Console.Write("How many singko would you like to drop? ");
            PChoice = pChoice;
            switch (PChoice)
            {
                case 1: Pc1 = int.Parse(Console.ReadLine()); break;
                case 2: Pc2 = int.Parse(Console.ReadLine()); break;
                case 3: Pc3 = int.Parse(Console.ReadLine()); break;
                case 4: Pc4 = int.Parse(Console.ReadLine()); break;
                case 5: Pc5 = int.Parse(Console.ReadLine()); break;
            }
        }

        //methods
        public override void Kaching() //sound effect for coins dropped and serves as confirmation statement
        {
            base.Kaching();
            switch (PChoice)
            {
                case 1: Console.WriteLine($"{Pc1} singko coins has been dropped in PC 1."); break;
                case 2: Console.WriteLine($"{Pc2} singko coins has been dropped in PC 2."); break;
                case 3: Console.WriteLine($"{Pc3} singko coins has been dropped in PC 3."); break;
                case 4: Console.WriteLine($"{Pc4} singko coins has been dropped in PC 4."); break;
                case 5: Console.WriteLine($"{Pc5} singko coins has been dropped in PC 5."); break;
            }
        }
        public override void CalculateTime() //calculates the time in hours and seconds depending on the coins dropped
        {
            Console.WriteLine("");
            switch (PChoice)
            {
                case 1:
                    Time = Pc1 * tMultiplier;
                    if (Time >= 60)
                    {
                        hour = Time / 60;
                        min = Time % 60;
                        Console.WriteLine($"You have {hour} hours and {min} minutes to use this PC.");
                    }
                    else
                    {
                        Console.WriteLine($"You have {Time} minutes to use this PC.");
                    }
                    break;
                case 2:
                    Time = Pc2 * tMultiplier;
                    if (Time >= 60)
                    {
                        hour = Time / 60;
                        min = Time % 60;
                        Console.WriteLine($"You have {hour} hours and {min} minutes to use this PC.");
                    }
                    else
                    {
                        Console.WriteLine($"You have {Time} minutes to use this PC.");
                    }
                    break;
                case 3:
                    Time = Pc3 * tMultiplier;
                    if (Time >= 60)
                    {
                        hour = Time / 60;
                        min = Time % 60;
                        Console.WriteLine($"You have {hour} hours and {min} minutes to use this PC.");
                    }
                    else
                    {
                        Console.WriteLine($"You have {Time} minutes to use this PC.");
                    }
                    break;
                case 4:
                    Time = Pc4 * tMultiplier;
                    if (Time >= 60)
                    {
                        hour = Time / 60;
                        min = Time % 60;
                        Console.WriteLine($"You have {hour} hours and {min} minutes to use this PC.");
                    }
                    else
                    {
                        Console.WriteLine($"You have {Time} minutes to use this PC.");
                    }
                    break;
                case 5:
                    Time = Pc5 * tMultiplier;
                    if (Time >= 60)
                    {
                        hour = Time / 60;
                        min = Time % 60;
                        Console.WriteLine($"You have {hour} hours and {min} minutes to use this PC.");
                    }
                    else
                    {
                        Console.WriteLine($"You have {Time} minutes to use this PC.");
                    }
                    break;
            }
            base.CalculateTime();  //calls the base method
        }
        public override void CalculateMoney() //calculates the total amount of singko (value)
        {
            switch (PChoice)
            {
                case 1:
                    Singko = Pc1 * mMultiplier;
                    break;
                case 2:
                    Singko = Pc2 * mMultiplier;
                    break;
                case 3:
                    Singko = Pc3 * mMultiplier;
                    break;
                case 4:
                    Singko = Pc4 * mMultiplier;
                    break;
                case 5:
                    Singko = Pc5 * mMultiplier;
                    break;
            }
            SingkoTotal += Singko; //updates SingkoTotal based on added singko
        }
    }
    public class Dyis : Coins //Child class Dyis that inherits Coins
    {
        //fields
        static int tMultiplier = 60, mMultiplier = 10; //time multiplier and money multiplier for dyis

        //constructor
        public Dyis(int pChoice)
        {
            Console.Write("How many dyis would you like to drop? ");
            PChoice = pChoice;
            switch (PChoice)
            {
                case 1: Pc1 = int.Parse(Console.ReadLine()); break;
                case 2: Pc2 = int.Parse(Console.ReadLine()); break;
                case 3: Pc3 = int.Parse(Console.ReadLine()); break;
                case 4: Pc4 = int.Parse(Console.ReadLine()); break;
                case 5: Pc5 = int.Parse(Console.ReadLine()); break;
            }
        }

        //methods
        public override void Kaching() //sound effect for coins dropped and serves as confirmation statement
        {
            base.Kaching();
            switch (PChoice)
            {
                case 1: Console.WriteLine($"{Pc1} dyis coins has been dropped in PC 1."); break;
                case 2: Console.WriteLine($"{Pc2} dyis coins has been dropped in PC 2."); break;
                case 3: Console.WriteLine($"{Pc3} dyis coins has been dropped in PC 3."); break;
                case 4: Console.WriteLine($"{Pc4} dyis coins has been dropped in PC 4."); break;
                case 5: Console.WriteLine($"{Pc5} dyis coins has been dropped in PC 5."); break;
            }
        }
        public override void CalculateTime() //calculates the time in hours and seconds depending on the coins dropped
        {
            Console.WriteLine("");
            switch (PChoice)
            {
                case 1:
                    Time = Pc1 * tMultiplier;
                    if (Time >= 60)
                    {
                        hour = Time / 60;
                        min = Time % 60;
                        Console.WriteLine($"You have {hour} hours and {min} minutes to use this PC.");
                    }
                    else
                    {
                        Console.WriteLine($"You have {Time} minutes to use this PC.");
                    }
                    break;
                case 2:
                    Time = Pc2 * tMultiplier;
                    if (Time >= 60)
                    {
                        hour = Time / 60;
                        min = Time % 60;
                        Console.WriteLine($"You have {hour} hours and {min} minutes to use this PC.");
                    }
                    else
                    {
                        Console.WriteLine($"You have {Time} minutes to use this PC.");
                    }
                    break;
                case 3:
                    Time = Pc3 * tMultiplier;
                    if (Time >= 60)
                    {
                        hour = Time / 60;
                        min = Time % 60;
                        Console.WriteLine($"You have {hour} hours and {min} minutes to use this PC.");
                    }
                    else
                    {
                        Console.WriteLine($"You have {Time} minutes to use this PC.");
                    }
                    break;
                case 4:
                    Time = Pc4 * tMultiplier;
                    if (Time >= 60)
                    {
                        hour = Time / 60;
                        min = Time % 60;
                        Console.WriteLine($"You have {hour} hours and {min} minutes to use this PC.");
                    }
                    else
                    {
                        Console.WriteLine($"You have {Time} minutes to use this PC.");
                    }
                    break;
                case 5:
                    Time = Pc5 * tMultiplier;
                    if (Time >= 60)
                    {
                        hour = Time / 60;
                        min = Time % 60;
                        Console.WriteLine($"You have {hour} hours and {min} minutes to use this PC.");
                    }
                    else
                    {
                        Console.WriteLine($"You have {Time} minutes to use this PC.");
                    }
                    break;
            }
            base.CalculateTime(); //calls the base method
        }
        public override void CalculateMoney() //calculates the total amount of dyis (value)
        {
            switch (PChoice)
            {
                case 1:
                    Dyis = Pc1 * mMultiplier;
                    break;
                case 2:
                    Dyis = Pc2 * mMultiplier;
                    break;
                case 3:
                    Dyis = Pc3 * mMultiplier;
                    break;
                case 4:
                    Dyis = Pc4 * mMultiplier;
                    break;
                case 5:
                    Dyis = Pc5 * mMultiplier;
                    break;
            }
            DyisTotal += Dyis; //updates DyisTotal based on added dyis

        }
    }
    public static class PrimaryMethods //static class that houses all of my static methods enabling my main to be clean and easily loopable
    {
        public static void HomePage() //homepage header
        {
            Console.WriteLine("                                                    Jermz Pisonet");
            Console.WriteLine("                                                  Coin Counter System");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("******************************************************Home Page********************************************************");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
        }
        public static void ExtendPage() //extend page header
        {
            Console.WriteLine("                                                    Jermz Pisonet");
            Console.WriteLine("                                                  Coin Counter System");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("*******************************************************EXTEND*********************************************************");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
        }
        public static void OwnerMenu() //menu for owners
        {

            Console.Write("\nI would like to:\n(1) Check my money   (2) Take money || ");
            int money = int.Parse(Console.ReadLine()); //takes input from the choice in the greeting which is to check money or take money
            Coins cCoin = new Coins(); //instantiates new object cCoin from class Coins

            if (money == 1) //check money
            {
                cCoin.CheckMoney(); //method to check money
            }
            else if (money == 2) //take money
            {
                cCoin.TakeMoney(); //method to take money
            }
        }
        public static void Login()
        {
            //instantiate new owners with parameters (predefined usernames and passwords)
            Owner jermz = new Owner("Jermyne Josh Kaquilala", "jermzu", "jermynejosh34", "21-3227-221");
            Owner papa = new Owner("Wynford Kaquilala", "wkaquilala", "wynford35", "4-002309-006109");

            //login interface
            {
                Console.WriteLine("\nLOGIN");
                Console.Write("\nUsername: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                if (username == "jermzu") //username is jermzu
                {
                    if (password == "jermynejosh34") //password of username jermzu is correct
                    {
                        jermz.Greet(); //greets owner
                        int money = int.Parse(Console.ReadLine()); //takes input from the choice in the greeting which is to check money or take money
                        Coins cCoin = new Coins(); //instantiates new object cCoin from class Coins

                        if (money == 1) //check money
                        {
                            cCoin.CheckMoney(); //method to check money
                        }
                        else if (money == 2) //take money
                        {
                            cCoin.TakeMoney(); //method to take money
                        }
                    }
                    else //password is incorrect
                    {
                        Console.WriteLine("Password is incorrect!\n\nRedirecting to Home Page.."); //shows error message
                        for (int i = 0; i < 150; i++)
                            System.Threading.Thread.Sleep(1); //delay timer before going back to the home page
                        Program.Main(null); //calls main method all over again
                    }
                }
                else if (username == "wkaquilala") //username is wkaquilala
                {
                    if (password == "wynford35") //password of wkaquilala is correct
                    {
                        papa.Greet(); //greets owner
                        Coins coins = new Coins(); //instantiates new object coins from class Coins
                        int money = int.Parse(Console.ReadLine());

                        if (money == 1) //check money
                        {
                            coins.CheckMoney(); //method to check money
                        }
                        else if (money == 2) //take money
                        {
                            coins.TakeMoney(); //method to take money
                        }
                    }
                    else //password is incorrect
                    {
                        Console.WriteLine("Password is incorrect!\n\nRedirecting to Home Page..."); //shows error message
                        for (int i = 0; i < 150; i++)
                            System.Threading.Thread.Sleep(1); //delay timer before going back to the home page
                        Program.Main(null); //calls main method all over again
                    }
                }
                else //username is incorrect
                {
                    Console.WriteLine("\nNo owner exists with that username!\n\nRedirecting to Home Page...");
                    for (int i = 0; i < 150; i++)
                        System.Threading.Thread.Sleep(1); //delay timer before going back to the home page
                    Program.Main(null); //calls main method all over again
                }
            }
        }
        public static void Extend() //method for the pisonet simulator
        {
            Console.Write("Select PC to use from 1-5: "); //pc selection
             int pChoice = int.Parse(Console.ReadLine());
            if (pChoice >= 1 && pChoice <= 5) //only selects pc from 1-5
            {
                Console.WriteLine($"\nWelcome to PC {pChoice}! Please insert coin to use."); //displays PC number of choice

                //prompt to see coin choices and time equivalence
                Console.WriteLine("\n    Coin   || Equivalent ||     Time    ");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("(1) Piso   ||  P 1.00    ||   6 minutes");
                Console.WriteLine("(2) Singko ||  P 5.00    ||   30 minutes");
                Console.WriteLine("(3) Dyis   ||  P 10.00   ||   60 minutes");
                int coin = int.Parse(Console.ReadLine()); //takes input of whatever type of coin is being put.
                switch (coin)
                {
                    case 1: //Piso
                        Piso piso = new Piso(pChoice); //instantiates new object piso from class Piso
                        if (piso.Pc1 > 0 || piso.Pc2 > 0 || piso.Pc3 > 0 || piso.Pc4 > 0 || piso.Pc5 > 0) //if input is a positive value
                        {
                            //order of methods to be called
                            piso.Kaching();
                            piso.CalculateTime();
                            piso.TimePass();
                            piso.CalculateMoney();
                        }
                        else //if input is a negative value
                        {
                            Console.WriteLine("Invalid input!"); 
                        }
                        break;
                    case 2: //Singko
                        Singko singko = new Singko(pChoice);
                        if (singko.Pc1 > 0 || singko.Pc2 > 0 || singko.Pc3 > 0 || singko.Pc4 > 0 || singko.Pc5 > 0) //if input is a positive value
                        {
                            //order of methods to be called
                            singko.Kaching();
                            singko.CalculateTime();
                            singko.TimePass();
                            singko.CalculateMoney();
                        }
                        else //if input is a negative value
                        {
                            Console.WriteLine("Invalid input!"); 
                        }
                        break;
                    case 3: //Dyis
                        Dyis dyis = new Dyis(pChoice);
                        if (dyis.Pc1 > 0 || dyis.Pc2 > 0 || dyis.Pc3 > 0 || dyis.Pc4 > 0 || dyis.Pc5 > 0) //if input is a positive value
                        {
                            //order of methods to be called
                            dyis.Kaching();
                            dyis.CalculateTime();
                            dyis.TimePass();
                            dyis.CalculateMoney();
                        }
                        else //if input is a negative value
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        break;
                    default: //invalid input
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
            else //rejects pc that is not numbered 1-5
            {
                Console.WriteLine($"PC {pChoice} does not exist!");
            }

        }
        public static char EndPromptUser() //Ending Prompt for the user
        {
            Console.Write("\nDo you wish to extend stay or log out? (e/l) || ");
            char el = char.Parse(Console.ReadLine());
            return el;
        }
        public static int UserSelection() //User selection
        {
            Console.WriteLine("\nWelcome! Are you"); //greeting
            Console.Write("(1) User   (2) Owner   (3) Exit || "); // choices
            int us = int.Parse(Console.ReadLine());
            return us;
        }
        public static char EndPromptOwner() //Ending Prompt for the owner
        {
            Console.Write("\nDo you have anything else to do or do you want to log out? (e/l) || ");
            char el = char.Parse(Console.ReadLine());
            return el;
        }
    }
}

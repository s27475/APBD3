using ZadanieKontenery;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Stworzenie produktow");
        Product eggs = new Product("Eggs", 19);
        Product cheese = new Product("Cheese", 7.2);
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Stworzenie kontenerow na plyny");
        LiquidContainer liquid1 = new LiquidContainer(200, 500, 500, 1000, false);
        LiquidContainer liquid2 = new LiquidContainer(150, 350, 350, 750, true);
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Stworzenie kontenerow na gaz");
        GasContainer gas1 = new GasContainer(200, 500, 500, 1000, 5);
        GasContainer gas2 = new GasContainer(150, 350, 350, 750, 2);
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Stworzenie kontenerow lodowek");
        RefrigeratedContainer ref1 = new RefrigeratedContainer(200, 500, 500, 1000, eggs, 5);
        RefrigeratedContainer ref2 = new RefrigeratedContainer(150, 350, 350, 750, cheese, 7.2);
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Ladowanie do kontenerow");
        liquid1.LoadContainer(700);
        liquid2.LoadContainer(200);
        gas1.LoadContainer(600);
        gas2.LoadContainer(750);
        ref1.LoadContainer(200);
        ref2.LoadContainer(430);
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Utworzenie statkow");
        ContainerShip ship1 = new ContainerShip(30, 6, 5000);
        ContainerShip ship2 = new ContainerShip(15, 4, 5000);
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Zaladowanie pojedynczego kontenera i listy kontenerow");
        List<Container> kontenery = new List<Container>();
        kontenery.Add(liquid1);
        kontenery.Add(ref2);
        ship1.LoadContainers(kontenery);
        ship1.LoadContainer(gas2);
        List<Container> kontenery2 = new List<Container>();
        kontenery2.Add(liquid2);
        kontenery2.Add(ref1);
        ship2.LoadContainers(kontenery2);
        ship2.LoadContainer(gas1);
        ship1.ShowListOfContainers();
        ship2.ShowListOfContainers();
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Usuniecie kontenera");
        ship1.DeleteContainer("KON-L-1");
        ship2.DeleteContainer("KON-G-3");
        ship1.ShowListOfContainers();
        ship2.ShowListOfContainers();
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Rozladowanie kontenera");
        ref1.UnloadContainer();
        Console.WriteLine(ref1.ToString());
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Zastapienie konteneru");
        ship1.ContainerExchange("KON-C-6", liquid1);
        ship1.ShowListOfContainers();
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Zamiana kontenerow");
        ship1.TransferContainer(gas2,ship2);
        ship1.ShowListOfContainers();
        ship2.ShowListOfContainers();
    }
}
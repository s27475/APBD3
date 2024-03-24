namespace ZadanieKontenery;

public class ContainerShip
{
    public List<Container> Containers { private set; get; } = new List<Container>();
    private double sumOfContainers = 0;
    private int loadedCount = 0;
    public double Speed { get; set; }
    public int MaxNumberOfContainers { get; private set; }
    public double MaxContainersWeight { get; private set; }

    public ContainerShip(double speed, int maxNumberOfContainers, double maxContainersWeight)
    {
        Speed = speed;
        MaxNumberOfContainers = maxNumberOfContainers;
        MaxContainersWeight = maxContainersWeight;
        Console.WriteLine("Container ship successfully created");
    }

    private bool CheckContainer(Container container)
    {
        sumOfContainers = sumOfContainers + container.Weight + container.LoadWeight;
        if (Containers.Count < MaxNumberOfContainers && sumOfContainers <= MaxContainersWeight)
        {
            Containers.Add(container);
            return true;
        }
        return false;
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            if (CheckContainer(container)) 
            {
                loadedCount++;
            }
            else
            {
                break;
            }
        }
        Console.WriteLine($"Successfully loaded {loadedCount} containers");
    }
    
    public void LoadContainer(Container container)
    {
        if (CheckContainer(container)) 
        {
            loadedCount++;
            Console.WriteLine("Successfully loaded container");
        }
    }

    public void ShowListOfContainers()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Loaded containers:");
        foreach (var container in Containers)
        {
            Console.WriteLine(container.ToString());
        }
    }

    public void DeleteContainer(string serialnumber)
    {
        foreach (var container in Containers)
        {
            if (serialnumber == container.SerialNumber)
            {
                Containers.Remove(container);
                sumOfContainers = sumOfContainers - (container.Weight + container.LoadWeight);
                Console.WriteLine($"Container {container.SerialNumber} successfully deleted");
                break;
            }
        }
    }

    public void ContainerExchange(string name1, Container container2)
    {
        if (CheckContainer(container2))
        {
            DeleteContainer(name1);
        }
    }

    public void TransferContainer(Container container, ContainerShip targetShip)
    {
        if (targetShip.CheckContainer(container))
        {
            DeleteContainer(container.SerialNumber);
            Console.WriteLine("Container successfully transfered");
        }
        else
        {
            Console.WriteLine("Failed to transfer container");
        }
    }
    
    public override string ToString()
    {
        return
            $"Container ship, speed: {Speed} knots, max number of containers {MaxNumberOfContainers}, max containers weight {MaxContainersWeight}";
    }
}
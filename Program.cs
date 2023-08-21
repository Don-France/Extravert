// See https://aka.ms/new-console-template for more information





List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Tulip",
        LightNeeds = 3,
        AskingPrice = 5.50M,
        City = "Columbia",
        Zip = 38401,
        Sold = false,
        AvailableUntil = new DateTime(2023, 7, 15)
    },
    new Plant()
    {
        Species = "Fern",
        LightNeeds = 3,
        AskingPrice = 15.25M,
        City = "Lawrenceburg",
        Zip = 38484,
        Sold = true,
        AvailableUntil = new DateTime(2023, 9, 15)
    },
    new Plant()
    {
        Species = "Poppies",
        LightNeeds = 4,
        AskingPrice = 2.50M,
        City = "Summertown",
        Zip = 38483,
        Sold = true,
        AvailableUntil = new DateTime(2023, 4, 15)
    },
    new Plant()
    {
        Species = "Daffodil",
        LightNeeds = 2,
        AskingPrice = 5.75M,
        City = "Hohenwald",
        Zip = 38462,
        Sold = false,
        AvailableUntil = new DateTime(2023, 10, 15)
    },
    new Plant()
    {
        Species = "Cactus",
        LightNeeds = 5,
        AskingPrice = 25.50M,
        City = "Ethridge",
        Zip = 38486,
        Sold = true,
        AvailableUntil = new DateTime(2023, 11, 15)
    }
};
Random random = new Random();
int randomInterger = random.Next(1, 6);

string greeting = @"Welcome to ExtraVert Plant Adoption Emporium
For all your plant adoption needs!";

Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    try
    {
        Console.WriteLine(@"Please choose an option:
                        0. Exit
                        1. Display All Plants
                        2. Post a plant to be adopted
                        3. Adopt a plant
                        4. Delist a plant
                        5. Plant of the Day
                        6. Search for plants
                        7. View Plant Statistics");
        choice = Console.ReadLine().Trim();

        if (choice == "0")
        {
            Console.WriteLine("Goodbye, the program will exit now!");
        }
        else if (choice == "1")
        {
            DisplayAllPlants();
        }
        else if (choice == "2")
        {
            PostAPlantForAdoption();
        }
        else if (choice == "3")
        {
            AdoptAPlant();
        }
        else if (choice == "4")
        {
            DelistAPlant();
        }
        else if (choice == "5")
        {
            PlantOfTheDay();
        }
        else if (choice == "6")
        {
            SearchForPlants();
        }
        else if (choice == "7")
        {
            ViewPlantStatistics();
        }
        else
        {
            Console.WriteLine("Invalid choice, please choose an option from the list!");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Please type only numbers!");
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine("Please choose an existing item only!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        Console.WriteLine("Try again please!");
    }
}





void DisplayAllPlants()
{

    for (int i = 0; i < plants.Count; i++)
    {
        Plant allPlants = plants[i];
        string plantDetails = PlantDetails(allPlants);
        Console.WriteLine($"{i + 1}. {plantDetails}");
    }
}
void PostAPlantForAdoption()
{
    Console.WriteLine("Enter plant details:");

    Console.WriteLine("Species: ");
    string species = Console.ReadLine();

    Console.WriteLine("Light Needs: ");
    int lightNeeds = int.Parse(Console.ReadLine());

    Console.WriteLine("Asking Price: ");
    decimal askingPrice = decimal.Parse(Console.ReadLine());

    Console.WriteLine("City: ");
    string city = Console.ReadLine();

    Console.WriteLine("Zip: ");
    int zip = int.Parse(Console.ReadLine());

    // Console.WriteLine("Available Until - Year:");
    // int year = int.Parse(Console.ReadLine());

    // Console.WriteLine("Month:");
    // int month = int.Parse(Console.ReadLine());

    // Console.WriteLine("Day:");
    // int day = int.Parse(Console.ReadLine());

    // DateTime availableUntil = new DateTime(year, month, day);

    // ...

    Console.WriteLine("Available Until - Year:");
    if (int.TryParse(Console.ReadLine(), out int year) && year >= DateTime.Now.Year)
    {
        Console.WriteLine("Month:");
        if (int.TryParse(Console.ReadLine(), out int month) && month >= 1 && month <= 12)
        {
            Console.WriteLine("Day:");
            if (int.TryParse(Console.ReadLine(), out int day) && day >= 1 && day <= DateTime.DaysInMonth(year, month))
            {
                DateTime availableUntil = new DateTime(year, month, day);

                plants.Add(new Plant()
                {
                    Species = species,
                    LightNeeds = lightNeeds,
                    AskingPrice = askingPrice,
                    City = city,
                    Zip = zip,
                    Sold = false,
                    AvailableUntil = availableUntil
                });
            }
            else
            {
                Console.WriteLine("Invalid day input or date not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid month input.");
        }
    }
    else
    {
        Console.WriteLine("Invalid year input.");
    }
    // ...


};
void AdoptAPlant()
{
    Console.WriteLine("Available Plants for Adoption:");

    for (int i = 0; i < plants.Count; i++)
    {
        Plant availablePlants = plants[i];
        if (availablePlants.Sold != true && DateTime.Now.Date <= availablePlants.AvailableUntil.Date)
        {
            string formattedDate = availablePlants.AvailableUntil.ToString("yyyy-MM-dd");
            Console.WriteLine(@$"{i + 1}.{availablePlants.Species} in {availablePlants.City} is available until {formattedDate} for ${availablePlants.AskingPrice}!");
        }

    }

    Console.WriteLine("Please choose a plant to adopt (enter number)!");
    /*int.TryParse is a method that attempts to convert the input string to an integer. 
    If successful, it returns true and assigns the converted integer value to the choiceIndex variable.
     If not successful, it returns false and sets choiceIndex to 0.The out keyword in C# is used in a method parameter
      to indicate that the corresponding argument is intended to provide output from the method rather than being used as input. 
      It's a way to return multiple values from a method.*/
    if (int.TryParse(Console.ReadLine(), out int choiceIndex) && choiceIndex > 0 && choiceIndex <= plants.Count)
    {
        Plant chosenPlant = plants[choiceIndex - 1];
        chosenPlant.Sold = true;
        Console.WriteLine($"Congratulations! You adopted a {chosenPlant.Species} from {chosenPlant.City} for ${chosenPlant.AskingPrice}!");
    }
    else
    {
        Console.WriteLine("Invalid input or plant not found.");
    }



};
//Removing a plant from the list
void DelistAPlant()
{
    DisplayAllPlants();
    Console.WriteLine("Please choose a plant to remove from the list by number!");


    if (int.TryParse(Console.ReadLine(), out int choiceIndex) && choiceIndex > 0 && choiceIndex <= plants.Count)
    {
        Plant chosenPlant = plants[choiceIndex - 1];
        plants.RemoveAt(choiceIndex - 1);
        Console.WriteLine($"The {chosenPlant.Species} has been removed!");
    }


};
// Displaying random plant that is not sold
void PlantOfTheDay()
{
    /* Start by initializing a boolean variable called availablePlantFound to false. 
    This variable will help us control the loop and determine whether we've found an available plant.*/
    bool availablePlantFound = false;
    /*We create an instance of the Random class to generate random numbers*/
    Random random = new Random();
    /*Declare a Plant variable named randomPlant and initialize it to null. This variable will store the selected plant for the "Plant of the Day."*/
    Plant randomPlant = null;

    while (!availablePlantFound)
    {
        /*Generate a random index within the range of the plants list using the Next method of the Random class.*/
        int randomIndex = random.Next(plants.Count);
        /*Retrieve a plant from the plants list based on the generated random index.*/
        randomPlant = plants[randomIndex];

        if (!randomPlant.Sold)
        {
            availablePlantFound = true;
        }
    }

    Console.WriteLine($"Plant of the Day: {PlantDetails(randomPlant)}");
}
// Searching for plants by Light Needed
void SearchForPlants()
{
    Console.WriteLine("Enter the light needs (1-5):");
    if (int.TryParse(Console.ReadLine(), out int lightInput) && lightInput >= 1 && lightInput <= 5)
    {
        List<Plant> matchingPlants = plants.FindAll(plant => plant.LightNeeds == lightInput);

        if (matchingPlants.Count == 0)
        {
            Console.WriteLine("No plants found with the specified light needs.");
        }
        else
        {
            Console.WriteLine("Plants matching the specified light needs:");
            foreach (Plant matchingPlant in matchingPlants)
            {
                Console.WriteLine($"{matchingPlant.Species} in {matchingPlant.City} is available for ${matchingPlant.AskingPrice}!");
            }
        }
    }
}



void ViewPlantStatistics()
{
    if (plants.Count == 0)
    {
        Console.WriteLine("No plants available.");
        return;
    }

    Plant lowestPricedPlant = plants[0];

    foreach (Plant plant in plants)
    {
        if (plant.AskingPrice < lowestPricedPlant.AskingPrice)
        {
            lowestPricedPlant = plant;
        }
    }

    Console.WriteLine($"Lowest Priced Plant: {lowestPricedPlant.Species} in {lowestPricedPlant.City} is available for ${lowestPricedPlant.AskingPrice}!");

    int notSoldAndAvailableCount = 0;

    foreach (Plant plant in plants)
    {
        if (!plant.Sold && DateTime.Now.Date <= plant.AvailableUntil.Date)
        {
            notSoldAndAvailableCount++;
        }
    }

    Console.WriteLine($"Number of Plants Not Sold and Still Available: {notSoldAndAvailableCount}");
    Plant highestLightNeed = plants[0];

    for (int i = 1; i < plants.Count; i++)
    {
        if (plants[i].LightNeeds > highestLightNeed.LightNeeds)
        {
            highestLightNeed = plants[i];
        }
    }

    Console.WriteLine($"Plant with the highest need for light: {highestLightNeed.Species} ");
    int totalLightNeeds = 0;
    foreach (Plant plant in plants)
    {
        totalLightNeeds += plant.LightNeeds;
    }

    // Calculate the average by dividing the total by the number of plants
    double averageLightNeeds = (double)totalLightNeeds / plants.Count;

    Console.WriteLine($"Average Light Needs for All Plants: {averageLightNeeds:F2}");

    int totalPlants = plants.Count;

    // Calculate the number of adopted (sold) plants
    int adoptedPlants = plants.Count(plant => plant.Sold);

    // Calculate the percentage of plants adopted
    double adoptionPercentage = (double)adoptedPlants / totalPlants * 100;

    Console.WriteLine($"Percentage of Plants Adopted: {adoptionPercentage:F2}%");


}
string PlantDetails(Plant plant)
{
    string plantString = $"Species: {plant.Species}, " +
                        $"Light Needs: {plant.LightNeeds}, " +
                        $"Asking Price: {plant.AskingPrice}, " +
                        $"City: {plant.City}, " +
                        $"Zip: {plant.Zip}, " +
                        $"Sold: {(plant.Sold ? "Yes" : "No")}, " +
                        $"Available Until: {plant.AvailableUntil:yyyy-MM-dd}";

    return plantString;
}

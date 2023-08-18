// Plant chosenPlant = null;
// while (chosenPlant == null)
// {
//     Console.WriteLine("Please enter a plant number:");
//     try
//     {
//         int response = int.Parse(Console.ReadLine().Trim());
//         chosenPlant = plants[response - 1];
//     }
//     catch (FormatException)
//     {
//         Console.WriteLine("Please type only numbers!");
//     }
//     catch (ArgumentOutOfRangeException)
//     {
//         Console.WriteLine("Please choose an existing item only!");
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine(ex);
//         Console.WriteLine("Try again please!");
//     }
// }
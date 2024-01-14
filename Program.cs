// This is for collection of fundamental classes and base classes
using System;

class Program {
    //This main method is the starting point of your project being executed
    static void Main() {
        //Create a new function to display a list of available bus routes
        DisplayBusRoutes();

        //The GET function 'GetSelectedRoute()' is being stored into the 'selectedRoute' variable
        //Allow users to select a bus route
        int selectedRoute = GetSelectedRoute();

        //The GET function 'GetNumberOfTickets()' is being stored into the 'numberOfTickets' variable
        //Prompt users for the number of tickets they want to purchase
        int numberOfTickets = GetNumberOfTickets();

        //Calculate the total cost by calling the 'CalculateTotalCost' function with selected route and number of tickets as parameters
        //The result stored into the variable 'totalCost'
        //Display the total cost based on the selected route and the number of tickets
        double totalCost = CalculateTotalCost(selectedRoute, numberOfTickets);
        Console.WriteLine($"Total cost: RM{totalCost}");

        DisplayConfirmation(selectedRoute, numberOfTickets, totalCost);
    }

    //This function 'DisplayBusRoutes' is simply prints the available routes to the console
    static void DisplayBusRoutes(){
        Console.WriteLine("Available Bus Routes:");
        Console.WriteLine("1. Route A");
        Console.WriteLine("2. Route B");
        Console.WriteLine("3. Route C");
    }

    //This function prompts user to select a bus route and validates the input
    //Console.ReadLine() means read user input from the console as a string
    /* 'int.TryParse(Console.ReadLine(), out selectedRoute)' means parse the user's input
    (which is a string) into an integer. If the parsing is success, then the parsed value will be
    stored into the selectedRoute variable */
    //TryParse returns true. If the user enter non-numeric value, then the TryParse returns false
    static int GetSelectedRoute(){
        int userSelectRoute; //Declare an integer variable named 'selectedRoute' inside this function
        do //Keep execute as long as the condition specified after the 'while' keyword is TRUE
        {
            Console.WriteLine("Select a bus route (1-3): "); //Prompt user to enter the number between 1 to 3

            //'!int.TryParse' means the ! operator negates the result of 'int.TryParse'.
            //So, the loop continue as long as the parsing fails(eg; the user enter non-numeric value for bus route selection)
            /* 'selectedRoute <1 || selectedRoute > 3' means this condition checks wether the parsed integer 'selectedRoute'
            is less than 1 or greater than 3 */
            //If either of these condition is true, the loop continues, prompting the user again and again
        } while (!int.TryParse(Console.ReadLine(), out userSelectRoute) || userSelectRoute <1 || userSelectRoute > 3);

        //return the value 'userSelectRoute' from function 'GetSelectedRoute'
        //and is stored into 'selectedRoute' variable (refer to line number 12)
        return userSelectRoute;
    }

    //This function prompts user to enter the number of tickets and validates the input
    static int GetNumberOfTickets(){
        int userNumberOfTickets;
        do
        {
            Console.WriteLine("Enter the number of tickets: ");
        } while (!int.TryParse(Console.ReadLine(), out userNumberOfTickets) || userNumberOfTickets < 0);

        return userNumberOfTickets;
    }

    //This function calculates the total cost based on the selected route and the number of tickets
    //Use switch case statement to assign different cost for different routes
    static double CalculateTotalCost(int selectedRoute, int numberOfTickets){
        double routeCost = selectedRoute switch {
            1 => 10.0,
            2 => 15.0,
            3 => 20.0,
            _ => 0.0 //Default case, should not happen
        };

        return routeCost * numberOfTickets;
    }

    //This function prints a booking confirmation message to the console
    static void DisplayConfirmation(int selectedRoute, int numberOfTickets, double totalCost){
        Console.WriteLine($"Booking Confirmation:");
        Console.WriteLine($"Route: Route {selectedRoute}");
        Console.WriteLine($"Number of Tickets: {numberOfTickets}");
        Console.WriteLine($"Total Cost: RM{totalCost}");
        Console.WriteLine("Thank you for booking with us!");
    }
}
using System;

public class PointCard
{
    // Properties
    public int Points { get; set; }
    public int PunchCard { get; set; }
    public string Tier { get; set; }

    // Constructors
    public PointCard()
    {
        // Default constructor
    }

    public PointCard(int points, int punchCard)
    {
        Points = points;
        PunchCard = punchCard;
        UpdateTier(); // You might want to update the tier based on the initial points
    }

    // Methods

    // Method to calculate points earned based on the total amount paid
    public void EarnPoints(double totalAmountPaid)
    {
        int earnedPoints = (int)Math.Floor(totalAmountPaid * 0.72);
        AddPoints(earnedPoints);
    }

    // Method to check if the member is eligible for the gold members' order queue
    public bool IsGoldMember()
    {
        return Tier == "Gold";
    }

    // Method to redeem points for silver and gold members
    public void RedeemPoints(int amount)
    {
        if ((Tier == "Silver" || Tier == "Gold") && Points >= amount)
        {
            Points -= amount;
            // Silver and gold members can redeem points for $0.02 each
            double offset = amount * 0.02;
            Console.WriteLine($"Points redeemed for ${offset}.");
        }
        else
        {
            // Handle insufficient points or membership level for redemption
            Console.WriteLine("Insufficient points or not eligible for redemption.");
        }

        UpdateTier(); // Update tier after redeeming points
    }

    // Method to handle punch card system
    public void Punch()
    {
        PunchCard++;
        if (PunchCard == 10)
        {
            Console.WriteLine("Congratulations! Your 11th ice cream is free!");
            PunchCard = 0; // Reset punch card after the 11th ice cream
        }

        UpdateTier(); // Update tier after punching the card
    }

    // Private method to update tier based on points, punchCard, or any other criteria you have
    private void UpdateTier()
    {
        if (Points >= 100 && PunchCard >= 5)
        {
            Tier = "Gold";
        }
        else if (Points >= 50)
        {
            Tier = "Silver";
        }
        else
        {
            Tier = "Bronze";
        }
    }

    // Custom implementation for converting the object to a string
    public override string ToString()
    {
        return $"PointCard: Points - {Points}, PunchCard - {PunchCard}, Tier - {Tier}";
    }
}


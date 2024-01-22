using System;

public class PointCard
{
    private int points;
    public int Points
    {
        get { return points; }
        set { points = value; }
    }

    private int punchCard;
    public int PunchCard
    {
        get { return punchCard; }
        set { punchCard = value; }
    }

    private string tier;
    public string Tier
    {
        get { return  tier; }
        set { tier = value; }
    }

    public PointCard() { }
    PointCard(int points,  int punchcard)
    {
        Points = points;
        PunchCard = punchcard;
    }
    private void SetTier() { }


    public override string ToString()
    {
        return $"PointCard: Points - {Points}, PunchCard - {PunchCard}, Tier - {Tier}";
    }
}


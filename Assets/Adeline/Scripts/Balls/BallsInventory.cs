using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BallsInventory 
{

    static ArrayList EnableBalls = new ArrayList();
    static ArrayList MarketPlaceBalls = new ArrayList();
    static ArrayList SelectedBalls = new ArrayList(); 

    public static void AddEnableBall(Ball ball)
    {
        EnableBalls.Add(ball);
    }

    public static void RemoveEnableBall(Ball ball)
    {
        EnableBalls.Remove(ball);
    }

    public static ArrayList GetInventoryBalls()
    {
        return EnableBalls;
    }

    public static ArrayList GetMarketPlaceBalls()
    {
        return MarketPlaceBalls;
    }

    public static void AddBallToSelected(Ball ball)
    {
        SelectedBalls.Add(ball);
    }

    public static void RemoveBallToSelected(Ball ball)
    {
        SelectedBalls.Remove(ball);
    }
    public static ArrayList GetSelectedBalls()
    {
        return SelectedBalls;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BallsInventory 
{

    static ArrayList MyBalls = new ArrayList();
    static ArrayList MarketPlaceBalls = new ArrayList();

    public static void AddBall(Ball ball)
    {
        MyBalls.Add(ball);
    }

    public static void RemoveBall(Ball ball)
    {
        MyBalls.Remove(ball);
    }

    public static ArrayList GetInventoryBalls()
    {
        return MyBalls;
    }

    public static ArrayList GetMarketPlaceBalls()
    {
        return MarketPlaceBalls;
    }

}

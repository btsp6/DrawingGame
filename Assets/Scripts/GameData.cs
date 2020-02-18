using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    private static GameState gameState; // TODO: Remove getters and setters?
    private static int[] scores = new int[3];
    public static GameObject activeShape;
    public static List<GameObject> placedShapes = new List<GameObject>();

    public static GameState getGameState()
    {
        return gameState;
    }

    public static void setGameState(GameState gameState)
    {
        GameData.gameState = gameState;
    }

    public static void increaseScore(int index)
    {
        scores[index]++;
    }

    public static void resetScore()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = 0;
        }
    }

    public static int getScore(int index)
    {
        return scores[index];
    }

    public static int[] getScores()
    {
        return scores;
    }
}

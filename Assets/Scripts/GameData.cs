using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public const int numRounds = 5;
    public const float secondsPerTurn = 25;
    public const float notifyTurnSeconds = 2.5f;
    public const float notifyTurnFadeFrac = .1f;

    private static GameState gameState; // TODO: Remove getters and setters?
    private static int[] scores = new int[3];
    public static GameObject activeShape;
    public static List<GameObject> placedShapes = new List<GameObject>();
    public static int turnCount = 0;
    public static float turnSecondsRemaining = secondsPerTurn;
    public static float notifyTurnSecondsRemaining = 2;

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

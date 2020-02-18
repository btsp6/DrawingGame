﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    private static GameState gameState; // TODO: Remove getters and setters?
    public static GameObject activeShape;
    public static GameObject[] placedShapes;

    public static GameState getGameState()
    {
        return gameState;
    }

    public static void setGameState(GameState gameState)
    {
        GameData.gameState = gameState;
    }
}

using System.Collections;
using System.Collections.Generic;

public static class GameData
{
    private static GameState gameState;

    public static GameState getGameState()
    {
        return gameState;
    }

    public static void setGameState(GameState gameState)
    {
        GameData.gameState = gameState;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject TurnText;
    public GameObject NotifyTurnPanel;

    public GameObject[] shapes;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (GameData.getGameState() == GameState.GameStart)
        {
            if (GameData.turnCount >= 2 * GameData.numRounds)
            {
                GameData.setGameState(GameState.DisplayWords);
            }

            GameData.turnSecondsRemaining -= Time.deltaTime;

            if (Input.GetButton("PlaceShape") && PlaceShape()) GotoNextTurn();
            else if (GameData.turnSecondsRemaining <= 0)
            {
                PlaceShape(); // try and place shape when time runs out
                GotoNextTurn();
            }

            TurnText.GetComponent<TMPro.TextMeshProUGUI>().SetText(getHudText());
        }
        else if (GameData.getGameState() == GameState.NotifyTurn)
        {
            GameData.notifyTurnSecondsRemaining -= Time.deltaTime;

            float time_frac = 1 - GameData.notifyTurnSecondsRemaining / GameData.notifyTurnSeconds;
            if (time_frac < GameData.notifyTurnFadeFrac)
            {
                NotifyTurnPanel.GetComponent<CanvasGroup>().alpha = time_frac / GameData.notifyTurnFadeFrac; // fade in
            }
            else if (1 - time_frac < GameData.notifyTurnFadeFrac)
            {
                NotifyTurnPanel.GetComponent<CanvasGroup>().alpha = (1 - time_frac) / GameData.notifyTurnFadeFrac; // fade out
            }
            else
            {
                NotifyTurnPanel.GetComponent<CanvasGroup>().alpha = 1;
            }

            if (GameData.notifyTurnSecondsRemaining <= 0)
            {
                NotifyTurnPanel.SetActive(false);
                GameData.setGameState(GameState.GameStart);
            }
        }
    }

    private void GotoNextTurn()
    {
        GameData.turnCount += 1;
        GameData.turnSecondsRemaining = GameData.secondsPerTurn;
        GameData.setGameState(GameState.NotifyTurn);
        NotifyTurnPanel.SetActive(true);
        NotifyTurnPanel.GetComponent<CanvasGroup>().alpha = 0;
        GameData.notifyTurnSecondsRemaining = GameData.notifyTurnSeconds;

        string activePlayer = (GameData.turnCount % 2 == 0) ? "One" : "Two";
        NotifyTurnPanel.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = $"Player {activePlayer}\nto Draw!";
    }

    public void SpawnShape(string shapeTag)
    {
        if (GameData.getGameState() != GameState.GameStart) return;
        foreach (GameObject shape in shapes)
        {
            if (shape.CompareTag(shapeTag))
            {
                if (GameData.activeShape != null) Destroy(GameData.activeShape);
                GameData.activeShape = Instantiate(shape);
                GameData.activeShape.transform.position = new Vector3(0, 0, -1);
                break;
            }
        }
    }

    // Returns whether shape was placed or not.
    public bool PlaceShape()
    {
        if (GameData.activeShape != null)
        {
            GameData.activeShape.GetComponent<Shape>().PlaceShape();
            GameData.placedShapes.Add(GameData.activeShape);
            GameData.activeShape = null;
            return true;
        }
        return false;
    }

    private string getHudText()
    {
        int curRound = GameData.turnCount / 2 + 1;
        int activePlayer = GameData.turnCount % 2 + 1;
        int secondsRemaining = (int)(GameData.turnSecondsRemaining + 0.999f);
        return $"Round {curRound}/{GameData.numRounds} - P{activePlayer} to Draw\nTime Remaining: 0:{secondsRemaining:00}";
    }
}

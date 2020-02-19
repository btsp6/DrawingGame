using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using UnityEngine.SceneManagement;


public class GamePanelController : MonoBehaviour
{
    // Panels
    public GameObject PromptPanel;
    public GameObject WordPanel;
    public GameObject TurnText;
    public GameObject ScorePanel;
    public GameObject WinnerPanel;

    // Prompt panel text
    private TextMeshProUGUI PromptText;
    private TextMeshProUGUI PromptButtonText;

    // Word panel text
    private TextMeshProUGUI WordText;

    // Score panel text
    private TextMeshProUGUI[] Words;
    private TextMeshProUGUI[] Scores;

    // Winner panel text
    private TextMeshProUGUI WinnerText;

    // Player words
    private string PlayerOneWord;
    private string PlayerTwoWord;
    private string DummyWord;

    // Random permutation generating tools
    private System.Random rand;
    private int[] scrambler;
    private int[] unscrambler;
   

    // Start is called before the first frame update
    void Start()
    {
        // Set all panels inactive
        PromptPanel.SetActive(false);
        WordPanel.SetActive(false);
        ScorePanel.SetActive(false);
        WinnerPanel.SetActive(false);

        // Get PromptText, PromptButtonText and WordText objects
        PromptText = PromptPanel.transform.Find("PromptTextPanel").gameObject.GetComponentInChildren<TextMeshProUGUI>();
        PromptButtonText = PromptPanel.transform.Find("PromptBottomPanel").gameObject.GetComponentInChildren<TextMeshProUGUI>();
        WordText = WordPanel.transform.Find("WordText").gameObject.GetComponent<TextMeshProUGUI>();

        // Set text of prompt panel and word panel
        PromptText.text = "Prompt";
        PromptButtonText.text = "OK";
        WordText.text = "word";

        // Reset scores to 0
        GameData.resetScore();

        // Get words and scores text of score panel
        Words = new TextMeshProUGUI[3];
        Scores = new TextMeshProUGUI[3];
        for (int i = 0; i < Words.Length; i++)
        {
            Words[i] = ScorePanel.transform.Find("WordsPanel").Find("WordButton" + i).gameObject.GetComponentInChildren<TextMeshProUGUI>();
            Words[i].text = "word";
            Scores[i] = ScorePanel.transform.Find("ScoresPanel").Find("Score" + i).gameObject.GetComponent<TextMeshProUGUI>();
            Scores[i].text = "0";
        }

        // Generate the two words for the player this round
        PlayerOneWord = Pictures.generateWord();
        PlayerTwoWord = Pictures.generateWord();
        DummyWord = Pictures.generateWord();

        // Generate permutation
        rand = new System.Random();
        scrambler = new int[3];
        scrambler = GetPermutation(scrambler.Length);
        unscrambler = new int[3];
        unscrambler = GetReverse(scrambler);

        // Get winner panel text
        WinnerText = WinnerPanel.transform.Find("WinnerTextPanel").gameObject.GetComponentInChildren<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (GameData.getGameState()) // TODO: Switch statements should eventually be changed into event handling code
        {
            case GameState.PlayerOneOpen:
                PromptText.text = "Everyone except for Player One, please close your eyes.";
                PromptPanel.SetActive(true);
                break;
            case GameState.PlayerOneWord:
                WordText.text = PlayerOneWord;
                WordPanel.SetActive(true);
                break;
            case GameState.PlayerTwoOpen:
                PromptText.text = "Everyone except for Player Two, please close your eyes.";
                PromptPanel.SetActive(true);
                break;
            case GameState.PlayerTwoWord:
                WordText.text = PlayerTwoWord;
                WordPanel.SetActive(true);
                break;
            case GameState.EveryoneOpen:
                PromptText.text = "Everyone, please open your eyes. Start Game?";
                PromptPanel.SetActive(true);
                PromptButtonText.text = "GO!";
                break;
            case GameState.GameStart:
                break;
            case GameState.DisplayWords:
                PromptButtonText.text = "OK";
                Words[scrambler[0]].text = PlayerOneWord;
                Words[scrambler[1]].text = PlayerTwoWord;
                Words[scrambler[2]].text = DummyWord;
                ScorePanel.SetActive(true);
                break;
            case GameState.DisplayWinner:
                int maxScore = GameData.getScores().Max();
                if (GameData.getScore(0) == maxScore) WinnerText.text = "Player One Wins!";
                else if (GameData.getScore(1) == maxScore) WinnerText.text = "Player Two Wins!";
                else WinnerText.text = "Nobody Wins!";
                WinnerPanel.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void ButtonClicked()
    {
        switch (GameData.getGameState())
        {
            case GameState.PlayerOneOpen:
                PromptPanel.SetActive(false);
                GameData.setGameState(GameState.PlayerOneWord);
                break;
            case GameState.PlayerOneWord:
                WordPanel.SetActive(false);
                GameData.setGameState(GameState.PlayerTwoOpen);
                break;
            case GameState.PlayerTwoOpen:
                PromptPanel.SetActive(false);
                GameData.setGameState(GameState.PlayerTwoWord);
                break;
            case GameState.PlayerTwoWord:
                WordPanel.SetActive(false);
                GameData.setGameState(GameState.EveryoneOpen);
                break;
            case GameState.EveryoneOpen:
                PromptPanel.SetActive(false);
                TurnText.GetComponent<TMPro.TextMeshProUGUI>().SetText($"Player One's Turn\nRound 1/{GameController.numRounds / 2}");
                GameData.setGameState(GameState.GameStart);
                break;
            case GameState.GameStart:
                GameData.setGameState(GameState.DisplayWords);
                break;
            case GameState.DisplayWords:
                //ScorePanel.SetActive(false);
                GameData.setGameState(GameState.DisplayWinner);
                break;
            case GameState.DisplayWinner:
                // Temporary setting to go back to title screen
                SceneManager.LoadScene("TitleScene");
                break;
            default:
                break;
        }
    }

    public void IncreaseScore(int index)
    {
        GameData.increaseScore(unscrambler[index]);
        Scores[index].text = GameData.getScore(unscrambler[index]).ToString();
    }

    // Generates a random permutation of the words
    private int[] GetPermutation(int len)
    {
        int[] arr = new int[len];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i;
        }
        return arr.OrderBy(x => rand.Next()).ToArray();
    }

    private int[] GetReverse(int[] arr)
    {
        int[] output = new int[arr.Length];

        for (int i = 0; i < arr.Length; i++)
        {
            output[arr[i]] = i;
        }
        return output;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePanelController : MonoBehaviour
{

    public GameObject PromptPanel;
    public GameObject WordPanel;

    private TextMeshProUGUI PromptText;
    private TextMeshProUGUI PromptButtonText;
    private TextMeshProUGUI WordText;

    private string PlayerOneWord;
    private string PlayerTwoWord;


    // Start is called before the first frame update
    void Start()
    {
        PromptPanel.SetActive(false);
        WordPanel.SetActive(false);

        // Get PromptText, PromptButtonText and WordText objects
        PromptText = PromptPanel.transform.Find("PromptTextPanel").gameObject.GetComponentInChildren<TextMeshProUGUI>();
        PromptButtonText = PromptPanel.transform.Find("PromptBottomPanel").gameObject.GetComponentInChildren<TextMeshProUGUI>();
        WordText = WordPanel.transform.Find("WordText").gameObject.GetComponent<TextMeshProUGUI>();

        PromptText.text = "Prompt";
        PromptButtonText.text = "OK";
        WordText.text = "word";

        // Generate the two words for the player this round
        PlayerOneWord = Pictures.generateWord();
        PlayerTwoWord = Pictures.generateWord();

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
                GameData.setGameState(GameState.GameStart);
                break;
            case GameState.GameStart:
                break;
            default:
                break;
        }
    }
}

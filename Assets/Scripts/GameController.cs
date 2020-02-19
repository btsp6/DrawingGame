using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject TurnText;

    public GameObject[] shapes;
    public static int numRounds = 20;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("PlaceShape")) PlaceShape();
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

    public void PlaceShape()
    {
        if (GameData.activeShape != null)
        {
            GameData.activeShape.GetComponent<Shape>().PlaceShape();
            GameData.placedShapes.Add(GameData.activeShape);
            GameData.activeShape = null;

            string playerString = GameData.placedShapes.Count % 2 == 0 ? "One" : "Two";
            //print($"Player {playerString}'s Turn\nRound {GameData.placedShapes.Count / 2}/{numRounds / 2}");
            TurnText.GetComponent<TMPro.TextMeshProUGUI>().SetText($"Player {playerString}'s Turn\nRound {1 + GameData.placedShapes.Count / 2}/{numRounds / 2}");

            if (GameData.placedShapes.Count == numRounds)
            {
                GameData.setGameState(GameState.DisplayWords);
            }
        }
    }
}

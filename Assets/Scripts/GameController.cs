using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] shapes;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("PlaceShape") && GameData.activeShape != null)
        {
            GameData.activeShape.GetComponent<Shape>().PlaceShape();
            GameData.placedShapes.Add(GameData.activeShape);
            GameData.activeShape = null;
        }
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
}

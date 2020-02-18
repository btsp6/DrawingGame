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

    }

    public void SpawnShape(string shapeTag)
    {
        foreach (GameObject shape in shapes)
        {   
            if (shape.CompareTag(shapeTag))
            {
                print("Spawning shape!");
                Destroy(GameData.activeShape);
                GameData.activeShape = Instantiate(shape);
                GameData.activeShape.transform.position = new Vector3(0, 0, -1);
                break;
            }
        }
    }
}

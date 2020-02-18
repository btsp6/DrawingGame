using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitButtonFindActiveShape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceActiveShape()
    {
        GameData.activeShape.GetComponent<Shape>().PlaceShape();
    }
}

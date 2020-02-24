using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 100f;
    public float scaleSpeed = 0.5f;
    private float minScale = 0.1f;

    public bool isPlaced = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Instantiated shape.");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaced)
        {
            // TODO: Figure out if we want GetAxis or GetAxisRaw
            Vector3 moveDir = new Vector3(Input.GetAxis("MoveX"), Input.GetAxis("MoveY"), 0);
            gameObject.transform.position += Time.deltaTime * moveSpeed * moveDir;

            gameObject.transform.Rotate(0, 0, Time.deltaTime * rotateSpeed * Input.GetAxis("Rotate"));

            Vector3 scaleDir = new Vector3(Input.GetAxis("ScaleX"), Input.GetAxis("ScaleY"), 0);
            Vector3 newScale = gameObject.transform.localScale + Time.deltaTime * moveSpeed * scaleDir;
            newScale.x = Mathf.Max(minScale, newScale.x);
            newScale.y = Mathf.Max(minScale, newScale.y);
            gameObject.transform.localScale = newScale;
        }
    }

    public void PlaceShape()
    {
        gameObject.GetComponent<AudioSource>().Play();
        isPlaced = true;
        foreach (Transform child in gameObject.transform) // Destroy colliders
        {
            Destroy(child.gameObject);
        }
    }
}

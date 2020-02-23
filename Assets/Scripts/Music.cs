using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music Instance { get; private set; } = null;

    void Awake()
    {
        print("HI!");
        if (Instance != null && Instance != this)
        {
            print("Destroying myself");
            Destroy(this.gameObject);
            return;
        }

        print("Not destroying myself");
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start() {
    }

    void Update() {
    }
}

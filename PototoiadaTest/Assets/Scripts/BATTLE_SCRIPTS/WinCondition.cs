using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour {

    public GameObject[] Players = null;
    public GameObject[] Enemies = null;
    public int win, lose;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Players = GameObject.FindGameObjectsWithTag("Player");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        win = Enemies.Length;
        lose = Players.Length;
        if (win == 0)
        {
            print("you win");
        }
        else if (lose == 0)
        {
            print("you lose");
        }
    }
}

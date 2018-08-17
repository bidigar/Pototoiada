using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dedé : PlayerScript
{

    // Use this for initialization
    private void Awake()
    {
        lv = 99;
        hp = 90;
        atk = 70;
        matk = 10;
        def = 60;
        mdef = 0;
        spd = 20;
        JobChosen(3);
    }
    protected override void Start() { positionInGame = "Char_2"; base.Start(); }
    protected override void Update() { base.Update(); }
}

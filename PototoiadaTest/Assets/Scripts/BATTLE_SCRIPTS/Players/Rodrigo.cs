using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rodrigo : PlayerScript {

    // Use this for initialization
    private void Awake()
    {
        lv = 99;
        hp = 40;
        atk = 70;
        matk = 10;
        def = 40;
        mdef = 20;
        spd = 90;
        JobChosen(6);
    }
    protected override void Start() { positionInGame = "Char_1";  base.Start(); }
    protected override void Update() { base.Update(); }
}
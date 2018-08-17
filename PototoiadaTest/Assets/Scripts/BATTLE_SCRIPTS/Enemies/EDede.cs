using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDede : EnemyScript {

    // Use this for initialization
    private void Awake()
    {
        lv = 80;
        hp = 90;
        atk = 70;
        matk = 10;
        def = 60;
        mdef = 0;
        spd = 20;
        JobChosen(3);
    }
    protected override void Start() { positionInGame = "Char_5"; base.Start(); }
    protected override void Update() { base.Update(); }
}
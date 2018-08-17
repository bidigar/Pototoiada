using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGustavo : EnemyScript {

    // Use this for initialization
    private void Awake()
    {
        lv = 80;
        hp = 60;
        atk = 60;
        matk = 10;
        def = 30;
        mdef = 30;
        spd = 70;
        JobChosen(4);
    }
    protected override void Start(){positionInGame = "Char_6";base.Start();}
    protected override void Update() { base.Update(); }
}
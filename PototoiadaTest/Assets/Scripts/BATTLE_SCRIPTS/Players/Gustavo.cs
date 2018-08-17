using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gustavo : PlayerScript {

    // Use this for initialization
    private void Awake()
    {
        lv = 99;
        hp = 60;
        atk = 60;
        matk = 10;
        def = 30;
        mdef = 30;
        spd = 70;
        JobChosen(4);
    }
    protected override void Start(){ positionInGame = "Char_3"; base.Start();}
    protected override void Update(){base.Update();}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasScript : MonoBehaviour {

    public Camera House, Bedroom, Battle, Armory, Summon;
    public Animator SummonCameraControler;
    public GameObject BedroomButton, BattleButton, ArmoryButton, SummonButton;
    // Bedroom buttons
    public Canvas BedroomCanvas;
    public GameObject EditTeam, Characters, ChaBack, Skins;
    // Battle buttons
    public Canvas BattleCanvas;
    public GameObject MainCampaing, Extras;
    // Armory buttons
    public Canvas ArmoryCanvas;
    public GameObject Weapons, MergeWeapons;
    //Summon buttons
    public Canvas SummonCanvas;
    public GameObject CharacterSummon, WeaponAndSkinSummon;

    public void Button_House()
    {
        House.enabled = true;
        Bedroom.enabled = false;
        Battle.enabled = false;
        Armory.enabled = false;
        Summon.enabled = false;

        BedroomButton.SetActive(true);
        BattleButton.SetActive(true);
        ArmoryButton.SetActive(true);
        SummonButton.SetActive(true);

        BedroomCanvas.enabled = false;
        BattleCanvas.enabled = false;
        ArmoryCanvas.enabled = false;
        SummonCanvas.enabled = false;

        SummonCameraControler.SetBool("summonButtonClicked", false);

    }

    public void Button_Bedroom()
    {
        House.enabled = false;
        Bedroom.enabled = true;
        Battle.enabled = false;
        Armory.enabled = false;
        Summon.enabled = false;

        BedroomButton.SetActive(false);
        BattleButton.SetActive(false);
        ArmoryButton.SetActive(false);
        SummonButton.SetActive(false);

        BedroomCanvas.enabled = true;
    }

    public void Button_Battle()
    {
        House.enabled = false;
        Bedroom.enabled = false;
        Battle.enabled = true;
        Armory.enabled = false;
        Summon.enabled = false;

        BedroomButton.SetActive(false);
        BattleButton.SetActive(false);
        ArmoryButton.SetActive(false);
        SummonButton.SetActive(false);

        BattleCanvas.enabled = true;
    }

    public void Button_Armory()
    {
        House.enabled = false;
        Bedroom.enabled = false;
        Battle.enabled = false;
        Armory.enabled = true;
        Summon.enabled = false;

        BedroomButton.SetActive(false);
        BattleButton.SetActive(false);
        ArmoryButton.SetActive(false);
        SummonButton.SetActive(false);

        ArmoryCanvas.enabled = true;
    }

    public void Button_Summon()
    {
        House.enabled = false;
        Bedroom.enabled = false;
        Battle.enabled = false;
        Armory.enabled = false;
        Summon.enabled = true;
        SummonCameraControler.enabled = true;

        BedroomButton.SetActive(false);
        BattleButton.SetActive(false);
        ArmoryButton.SetActive(false);
        SummonButton.SetActive(false);

        SummonCameraControler.SetBool("summonButtonClicked", true);
    }

    public void Button_Characters()
    {
        EditTeam.SetActive(false);
        Characters.SetActive(false);
        Skins.SetActive(false);
        ChaBack.SetActive(true);
    }

    public void Button_ChaBack()
    {
        EditTeam.SetActive(true);
        Characters.SetActive(true);
        Skins.SetActive(true);
        ChaBack.SetActive(false);
    }

    public void Button_EditTeam()
    {
        EditTeam.SetActive(false);
        Characters.SetActive(false);
        Skins.SetActive(false);
        ChaBack.SetActive(true);
    }

        // Use this for initialization
        void Start () {
        House.enabled = true;
        Bedroom.enabled = false;
        Battle.enabled = false;
        Armory.enabled = false;
        Summon.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

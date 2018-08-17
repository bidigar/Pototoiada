using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : PlayerBehavior {
    

    // Combat
    protected new void AttackPriority()
    {
        // Seleção do inimigo
         float distance = Mathf.Infinity;
         Vector3 position = transform.position;
         switch (job)
         {
             case "Berserker":
                foreach (GameObject en in Enemies)
                 {
                     enemyJob = en.GetComponent<PlayerBehavior>().job;                   
                     if (enemyJob == "Thief")
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                        if (enemySet == false)
                        {
                            distance = curDistance;
                            Enemy = en;
                        }
                        else if (curDistance < distance)
                        {
                            Enemy = en;
                            distance = curDistance;
                        }
                        enemySet = true;
                     }
                    else if (enemySet == false)
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                         if (curDistance < distance)
                         {
                             Enemy = en;
                             distance = curDistance;
                         }
                     }
                 }
                foreach (GameObject pl in Players)
                {
                    playerJob = pl.GetComponent<PlayerBehavior>().job;
                    if (playerJob == "Knight")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    else if (playerJob == "Wanderer")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    else if (playerJob == "Soldier")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }


                }
                break;
             case "Priest":
                foreach (GameObject en in Enemies)
                 {
                     enemyJob = en.GetComponent<PlayerBehavior>().job;
                     if (enemyJob == "Soldier")
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                        if (enemySet == false)
                        {
                            distance = curDistance;
                            Enemy = en;
                        }
                        else if (curDistance < distance)
                        {
                            Enemy = en;
                            distance = curDistance;
                        }
                        enemySet = true;
                     }
                     else if (enemySet == false)
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                         if (curDistance < distance)
                         {
                             Enemy = en;
                             distance = curDistance;
                         }
                     }
                 }
                foreach (GameObject pl in Players)
                {
                    playerJob = pl.GetComponent<PlayerBehavior>().job;
                    if (playerJob == "Thief")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    else if (playerJob == "Berserker")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    else if (playerJob == "Knight")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    else if (playerJob == "Wanderer")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    else if (playerJob == "Soldier")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }


                }
                break;
             case "Knight":
                foreach (GameObject en in Enemies)
                 {
                     enemyJob = en.GetComponent<PlayerBehavior>().job;
                     if (enemyJob == "Berserker")
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                        if (enemySet == false)
                        {
                            distance = curDistance;
                            Enemy = en;
                        }
                        else if (curDistance < distance)
                        {
                            Enemy = en;
                            distance = curDistance;
                        }
                        enemySet = true;
                     }
                     else if (enemySet == false)
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                         if (curDistance < distance)
                         {
                             Enemy = en;
                             distance = curDistance;
                         }
                     }
                 }
                break;
             case "Soldier":
                foreach (GameObject en in Enemies)
                 {
                     enemyJob = en.GetComponent<PlayerBehavior>().job;
                     if (enemyJob == "Tactician")
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                        if (enemySet == false)
                        {
                            distance = curDistance;
                            Enemy = en;
                        }
                        else if (curDistance < distance)
                        {
                            Enemy = en;
                            distance = curDistance;
                        }
                        enemySet = true;
                     }
                     else if (enemySet == false)
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                         if (curDistance < distance)
                         {
                             Enemy = en;
                             distance = curDistance;
                         }
                     }
                 }
                break;
             case "Tactician":
                foreach (GameObject en in Enemies)
                 {
                     enemyJob = en.GetComponent<PlayerBehavior>().job;
                     if (enemyJob == "Wanderer")
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                        if (enemySet == false)
                        {
                            distance = curDistance;
                            Enemy = en;
                        }
                        else if (curDistance < distance)
                        {
                            Enemy = en;
                            distance = curDistance;
                        }
                        enemySet = true;
                     }
                     else if (enemySet == false)
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                         if (curDistance < distance)
                         {
                             Enemy = en;
                             distance = curDistance;
                         }
                     }
                 }
                foreach (GameObject pl in Players)
                {
                    playerJob = pl.GetComponent<PlayerBehavior>().job;
                    if (playerJob == "Thief")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    else if (playerJob == "Berserker")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    else if (playerJob == "Knight")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    else if (playerJob == "Wanderer")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    else if (playerJob == "Soldier")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }


                }
                break;
             case "Thief":
                foreach (GameObject en in Enemies)
                 {
                     enemyJob = en.GetComponent<PlayerBehavior>().job;
                     if (enemyJob == "Priest")
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                        if (enemySet == false)
                        {
                            distance = curDistance;
                            Enemy = en;
                        }
                        else if (curDistance < distance)
                        {
                            Enemy = en;
                            distance = curDistance;
                        }
                         enemySet = true;
                     }
                     else if (enemyJob == "Wizard" && enemySet == false)
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                        if (enemySet == false)
                        {
                            distance = curDistance;
                            Enemy = en;
                        }
                        else if (curDistance < distance)
                        {
                            Enemy = en;
                            distance = curDistance;
                        }
                        enemySet = true;
                     }
                     else if (enemySet == false)
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                         if (curDistance < distance)
                         {
                             Enemy = en;
                             distance = curDistance;
                         }
                     }
                 }
                foreach (GameObject pl in Players)
                 {
                    playerJob = pl.GetComponent<PlayerBehavior>().job;
                    if (playerJob == "Knight")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    else if (playerJob == "Wanderer")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    else if (playerJob == "Soldier")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    
                    
                 }
                break;
             case "Wanderer":
                foreach (GameObject en in Enemies)
                 {
                     enemyJob = en.GetComponent<PlayerBehavior>().job;
                     if (enemyJob == "Wizard")
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                        if (enemySet == false)
                        {
                            distance = curDistance;
                            Enemy = en;
                        }
                        else if (curDistance < distance)
                        {
                            Enemy = en;
                            distance = curDistance;
                        }
                        enemySet = true;
                     }
                     else if (enemySet == false)
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                         if (curDistance < distance)
                         {
                             Enemy = en;
                             distance = curDistance;
                         }
                     }
                 }
                break;
             case "Wizard":
                foreach (GameObject en in Enemies)
                 {
                     enemyJob = en.GetComponent<PlayerBehavior>().job;
                     if (enemyJob == "Knight")
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                        if (enemySet == false)
                        {
                            distance = curDistance;
                            Enemy = en;
                        }
                        else if (curDistance < distance)
                        {
                            Enemy = en;
                            distance = curDistance;
                        }
                        enemySet = true;
                     }
                     else if (enemySet == false)
                     {
                         Vector3 diff = en.transform.position - position;
                         float curDistance = diff.sqrMagnitude;
                         if (curDistance < distance)
                         {
                             Enemy = en;
                             distance = curDistance;
                         }
                     }
                 }
                foreach (GameObject pl in Players)
                {
                    playerJob = pl.GetComponent<PlayerBehavior>().job;
                    if (playerJob == "Thief")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    else if (playerJob == "Berserker")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    else if (playerJob == "Knight")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    else if (playerJob == "Wanderer")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }
                    else if (playerJob == "Soldier")
                    {
                        Vector3 diff = pl.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (friendSet == false)
                        {
                            distance = curDistance;
                            Player = pl;
                        }
                        else if (curDistance < distance)
                        {
                            Player = pl;
                            distance = curDistance;
                        }
                        friendSet = true;
                    }


                }
                break;
         }
         
    }

    public new void GetTarget() { FindCharacters(); AttackPriority(); }

    // Use this for initialization
    protected void BattleStart()
    {
        
        FindUI();
       // SetBodyToHead();
        NameOverSkill();
        GetTarget();
        ClassStatusBalance();
        StatusBalance();
        DamageCalculator();
        DefenseCalculator();
        HealthSet();
        SkillsCooldownSet();
    }
    protected virtual void Start ()
    {
        BattleStart();
        Anim = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	protected virtual void Update () {
        if (attackDealt == false || Enemy == null)
        {
            GetTarget();
        }
        if (move == true)
        {
            MoveToOponent();
        }
        else if (move == false && attackDealt == true && w84 == false)
        {
            MoveAwayFromOponent();
            Movement();
        }
        else
        {
            Movement();
            enemySet = false;
        }
        SkillsCooldown();
        HealthBar();
        MovBar();
        ChargeBar();
        Die();
    }
}

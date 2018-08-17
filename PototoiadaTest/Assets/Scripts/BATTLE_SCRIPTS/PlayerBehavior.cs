using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour {


    // Status
    protected float lv = 1, atk, matk, def, mdef, spd, hp;
    // Status per level
    protected float latk, lmatk, ldef, lmdef, lspd, lhp;

    //Important variables
    protected float movTik = 0;
    public int currentHealth;
    public float  damage, magicDamage, defense, magicDefense;
    protected int iDamage, iMagicDamage, iDefense, iMagicDefense;
    protected float movTotal = 0;
    protected int maxCharge = 10;
    protected float aSkillCooldown, bSkillCooldown, aCooldownTimer, bCooldownTimer;
    public string job, positionInGame;
    protected GameObject[] Enemies = null;
    public GameObject Enemy = null;
    protected GameObject[] Players = null;
    public GameObject Player = null;
    protected bool move;
    public float allyDist, playerDist, damageDist = 4F;
    public int iDamageDeal;
    protected float damageDeal;
    protected GameObject HpSlider, MvSlider, AButtonGameObject, ASliderObject, BButtonGameObject, BSliderObject, UButtonGameObject, USliderObject, PositionInGameGameObject, NameOverSkillObject;
    protected Slider healthSlider, movSlider, ultSlider, aSlider, bSlider;
    public Button ultimateButton, aSkillButton, bSkillButton;
    protected Text nameOverSkill;
    protected bool attackDealt;
    protected bool enemySet, friendSet;
    protected string enemyJob, playerJob;

    protected Animator Anim;
    public float time; 
    public bool w84;

    private IEnumerator WaitForAttack(float time)
    {
        do
        {
            time -= Time.deltaTime;
            yield return null;
        } while (time > 0);
        w84 = false;
    }

    protected void AnimationAttack()
    {
        RuntimeAnimatorController ac = Anim.runtimeAnimatorController;    
        for (int i = 0; i < ac.animationClips.Length; i++)                 
        {
            if (ac.animationClips[i].name == "Attack")        
            {
                time = ac.animationClips[i].length;
                StartCoroutine(WaitForAttack(time));
                Anim.SetBool("Attack", false);
            }
        }
    }

    protected enum Jobs
    {
        Null = 0,
        Beserker = 1,
        Priest = 2,
        Knight = 3,
        Soldier = 4,
        Tactician = 5,
        Thief = 6,
        Wanderer = 7,
        Wizard = 8
    };

    // Child only
    protected void NameOverSkill()
    {
        nameOverSkill.text = this.name;
    }

    public virtual void Ultimate()
    {
        maxCharge = 10;
        ultimateButton.interactable = false;
    }

    protected virtual void Passive() {}

    public virtual void SkillA()
    {
        aSkillButton.interactable = false;
        aSkillCooldown = aCooldownTimer;
    }

    public virtual void SkillB()
    {
        bSkillButton.interactable = false;
        bSkillCooldown = bCooldownTimer;
    }

    protected void EquippedWeapon() {}

    protected void JobChosen(int i)
    {
        Jobs jo = (Jobs)i;
        job = jo.ToString();
    }

    protected void ClassStatusBalance()
    {
        float resto = 0;
        if (job == "Thief")
        {
            if (atk-30 < 0)
            {
                resto = -((int)atk - 30);
                atk += resto - 30;
                spd += 30 - resto;
            }
            else
            {
                atk -= 30;
                spd += 30;
            }
            
        }
        else if (job == "Knight")
        {
            if (mdef - 30 < 0)
            {
                resto = -((int)mdef - 30);
                mdef += resto - 30;
                def += 30 - resto;
            }
            else
            {
                mdef -= 30;
                def += 30;
            }

            if (spd - 30 < 0)
            {
                resto = -((int)spd - 30);
                spd += resto - 30;
                hp += 30 - resto;
            }
            else
            {
                spd -= 30;
                hp += 30;
            }
        }
        else if (job == "Wanderer")
        {
            if (def - 30 < 0)
            {
                resto = -((int)def - 30);
                def += resto - 30;
                mdef += 30 - resto;
            }
            else
            {
                def -= 30;
                mdef += 30;
            }

            if (spd - 30 < 0)
            {
                resto = -((int)spd - 30);
                spd += resto - 30;
                hp += 30 - resto;
            }
            else
            {
                spd -= 30;
                hp += 30;
            }
        }
        else if (job == "Soldier")
        {
            hp += 5;
            atk += 5;
            matk += 5;
            def += 5;
            mdef += 5;
            spd += 5;
        }
        else if (job == "Tactician")
        {
            // tirar atk e matk de tactician -15 e adicionar em def e mdef
            hp += 2;
            atk += 2;
            matk += 2;
            def += 2;
            mdef += 2;
            spd += 2;
        }
    }

    // Status

    protected void StatusBalance()
    {
        //Status balance baseado no level 100
        /*
        lhp = ((hp * 4) / 50) * lv + 10;
        latk = ((atk * 2) / 50) * lv + 5;
        lmatk = ((matk * 2) / 50) * lv + 5;
        ldef = ((def * 2) / 50) * lv + 5;
        lmdef = ((mdef * 2) / 50) * lv + 5;
        lspd = ((spd * 2) / 50) * lv + 5;
        */
        lhp = 4 * (hp + 5);
        latk = (atk / 120) * lv + 1;
        latk = (int)latk;
        lmatk = (matk / 120) * lv + 1;
        lmatk = (int)matk;
        ldef = (def / 120) * lv + 1;
        ldef = (int)ldef;
        lmdef = (mdef / 120) * lv + 1;
        lmdef = (int)lmdef;
        lspd = (spd / 120) * lv + 1;
        lspd = (int)lspd;
    }

    protected void HealthSet() {
        currentHealth = (int)lhp;
        healthSlider.maxValue = (int)lhp;
        healthSlider.value = (int)lhp;
    }

    // Combat

    public void Charge(int counts)
    {
        maxCharge -= counts;
        if (maxCharge < 0)
        {
            maxCharge = 0;
        }
    }

    protected void Movement()
    {   //baseado no balanceamento lv 100
        //movTik = (lspd + 115)/12;
        movTik = ((lspd + 23.75F)/2.475F)/2;
        movTotal += movTik * Time.deltaTime;
        if (movTotal > 100)
        {
            move = true;
            movTotal -= 100;
        }
    }

    protected void DamageCalculator()
    {
        magicDamage = ((lv/4) + lmatk + (lspd/10));  
        damage  = ((lv / 4) + latk + (lspd / 10));
        iMagicDamage = (int)magicDamage;
        iDamage = (int)damage;
        damage = iDamage;
        magicDamage = iMagicDamage;
    }
 
    protected void DefenseCalculator()
    {
        //Porcemtagem de defesa
        //magicDefense = ((4000 + (lmdef * 10)) / (4000 + ((lmdef * 10) * 10)));
        //defense = ((4000 + (ldef * 10)) / (4000 + ((ldef * 10) * 10)));

    }

    protected void Attack()
    {
        Anim.SetBool("Attack", true);
        w84 = true;
        StartCoroutine(WaitForAttack(time));
        if (gameObject.tag == "Player")
        {
            if (job == "Priest" || job == "Wanderer" || job == "Wizard")
            {
                // damageDeal = magicDamage * Enemy.GetComponent<PlayerBehavior>().magicDefense;
                if (magicDamage - Enemy.GetComponent<PlayerBehavior>().lmdef < 0)
                {
                    damageDeal = 0;
                }
                else damageDeal = magicDamage - Enemy.GetComponent<PlayerBehavior>().lmdef;

                damageDeal += ((magicDamage * (((lmatk - 1) / 3.3F) / 100) * -1) - magicDamage) * -1;
            }
            else
            {
                // damageDeal = damage * Enemy.GetComponent<PlayerBehavior>().defense;
                if (damage - Enemy.GetComponent<PlayerBehavior>().ldef < 0)
                {
                    damageDeal = 0;
                }
                else damageDeal = damage - Enemy.GetComponent<PlayerBehavior>().ldef;

                damageDeal += ((damage * (((latk - 1) / 3.3F) / 100) * -1) - damage) * -1;
            }
            iDamageDeal = (int)damageDeal;
            Charge(2);
            Enemy.GetComponent<PlayerBehavior>().Charge(1);
            Enemy.GetComponent<PlayerBehavior>().currentHealth -= iDamageDeal;
            attackDealt = true;

        }
        else if (gameObject.tag == "Enemy")
        {
            if (job == "Priest" || job == "Wanderer" || job == "Wizard")
            {
                // damageDeal = magicDamage * Player.GetComponent<PlayerBehavior>().magicDefense;
                if (magicDamage - Player.GetComponent<PlayerBehavior>().lmdef < 0)
                {
                    damageDeal = 0;
                }
                else damageDeal = magicDamage - Player.GetComponent<PlayerBehavior>().lmdef;

                damageDeal += ((magicDamage * (((lmatk - 1) / 3.3F) / 100) * -1) - magicDamage) * -1;
            }
            else
            {
                // damageDeal = damage * Player.GetComponent<PlayerBehavior>().defense;
                if (damage - Player.GetComponent<PlayerBehavior>().ldef < 0)
                {
                    damageDeal = 0;
                }
                else damageDeal = damage - Player.GetComponent<PlayerBehavior>().ldef;

                damageDeal += ((damage * (((latk - 1) / 3.3F) / 100) * -1) - damage) * -1;
            }
            iDamageDeal = (int)damageDeal;
            Charge(2);
            Player.GetComponent<PlayerBehavior>().Charge(1);
            Player.GetComponent<PlayerBehavior>().currentHealth -= iDamageDeal;
            
            attackDealt = true;
        }
        
    }

    protected void MoveToOponent()
    {
        // AI com o movimento do personagem
        if (gameObject.tag == "Player")
        {
            if (Enemy != null)
            {
                Anim.SetBool("Run", true);
                if (job == "Tactician" || job == "Priest" || job == "Wizard")
                {
                    transform.LookAt(Enemy.transform.position);
                   
                    allyDist = Vector3.Distance(transform.position, Enemy.transform.position);
                    if (allyDist < damageDist * 4)
                    {
                        Anim.SetBool("Run", false);
                        Attack();          
                        enemySet = false;
                        move = false;
                    }
                    else transform.position += transform.forward * Time.deltaTime * (lspd + 157.4F) / 19.8F;

                }
                else
                {
                    transform.LookAt(Enemy.transform.position);

                    allyDist = Vector3.Distance(transform.position, Enemy.transform.position);
                    if (allyDist < damageDist)
                    {
                        Anim.SetBool("Run", false);
                        Attack();
                        enemySet = false;
                        move = false;
                    }
                    else transform.position += transform.forward * Time.deltaTime * (lspd + 157.4F) / 19.8F;
                }
            }
        }
        else if (gameObject.tag == "Enemy")
        {
            if (Player != null)
            {
                Anim.SetBool("Run", true);
                if (job == "Tactician" || job == "Priest" || job == "Wizard")
                {
                    transform.LookAt(Player.transform.position);

                    allyDist = Vector3.Distance(transform.position, Player.transform.position);
                    if (allyDist < damageDist * 4)
                    {
                        Anim.SetBool("Run", false);
                        Attack();
                        enemySet = false;
                        move = false;
                    }
                    else transform.position += transform.forward * Time.deltaTime * (lspd + 157.4F) / 19.8F;

                }
                else
                {
                    transform.LookAt(Player.transform.position);

                    allyDist = Vector3.Distance(transform.position, Player.transform.position);
                    if (allyDist < damageDist)
                    {
                        Anim.SetBool("Run", false);
                        Attack();
                        enemySet = false;
                        move = false;
                    }
                    else transform.position += transform.forward * Time.deltaTime * (lspd + 157.4F) / 19.8F;
                }
            }
        }
    }

    protected void MoveAwayFromOponent()
    {
        Anim.SetBool("Backwards", true);
        Anim.SetBool("Attack", false);
        if (gameObject.tag == "Player")
        {
            if (job == "Thief" || job == "Berserker")
            {
                if (Player != null && Enemy != null)
                {
                    
                    Vector3 Vetor = -(Enemy.transform.position - Player.transform.position);
                    Vetor = Vetor / Vector3.Magnitude(Vetor);
                    allyDist = Vector3.Distance(Player.transform.position, Enemy.transform.position);
                    playerDist = Vector3.Distance(transform.position, Enemy.transform.position);
                    //transform.LookAt(Player.transform.position);
                    if (allyDist + 2 > playerDist)
                    {
                        transform.position += Vetor * Time.deltaTime * (lspd + 157.4F) / 19.8F;

                    }
                    else
                    {
                        // Anim.SetBool("Run", false);
                        Anim.SetBool("Backwards", false);
                        if (Enemy != null)
                        {
                            transform.LookAt(Enemy.transform.position);
                        }
                        attackDealt = false; 
                    }

                    /*  transform.LookAt(Player.transform.position + new Vector3(0, 0, -3));
                      dist = Vector3.Distance(transform.position, Player.transform.position + new Vector3(0, 0, -3));
                      if (dist < damageDist)
                      {
                          if (Enemy != null)
                          {
                              transform.LookAt(Enemy.transform.position);
                          }
                          attackDealt = false;
                      }
                      else transform.position += transform.forward * Time.deltaTime * (lspd + 157.4F) / 19.8F;
                      */
                }  else Anim.SetBool("Backwards", false);//Anim.SetBool("Run", false);
            }
            else if (job == "Tactician" || job == "Priest" || job == "Wizard")
            {
                if (Player != null && Enemy != null)
                {
                    playerJob = Player.GetComponent<PlayerBehavior>().job;
                    if (playerJob == "Knight" || playerJob == "Wanderer" || playerJob == "Soldier")
                    {
                        Vector3 Vetor = -(Enemy.transform.position - Player.transform.position);
                        Vetor = Vetor / Vector3.Magnitude(Vetor);
                        allyDist = Vector3.Distance(Player.transform.position, Enemy.transform.position);
                        playerDist = Vector3.Distance(transform.position, Enemy.transform.position);
                        transform.LookAt(Player.transform.position);
                        if (allyDist + 4 > playerDist)
                        {
                            transform.position += Vetor * Time.deltaTime * (lspd + 157.4F) / 19.8F;

                        }
                        else
                        {
                            // Anim.SetBool("Run", false);
                            Anim.SetBool("Backwards", false);
                            if (Enemy != null)
                            {
                                transform.LookAt(Enemy.transform.position);
                            }
                            attackDealt = false;
                        }
                    }
                    else if (playerJob == "Thief" || playerJob == "Berserker")
                    {
                        Vector3 Vetor = -(Enemy.transform.position - Player.transform.position);
                        Vetor = Vetor / Vector3.Magnitude(Vetor);
                        allyDist = Vector3.Distance(Player.transform.position, Enemy.transform.position);
                        playerDist = Vector3.Distance(transform.position, Enemy.transform.position);
                        transform.LookAt(Player.transform.position);
                        if (allyDist + 2 > playerDist)
                        {
                            transform.position += Vetor * Time.deltaTime * (lspd + 157.4F) / 19.8F;

                        }
                        else
                        {
                            //Anim.SetBool("Run", false);
                            Anim.SetBool("Backwards", false);
                            if (Enemy != null)
                            {
                                transform.LookAt(Enemy.transform.position);
                            }
                            attackDealt = false;
                        }
                    }
                }else Anim.SetBool("Backwards", false);//Anim.SetBool("Run", false);
            }
            else Anim.SetBool("Backwards", false);//Anim.SetBool("Run", false);
        }
        else if (gameObject.tag == "Enemy")
        {
            if (job == "Thief" || job == "Berserker")
            {
                if (Enemy != null && Player != null)
                {
                    Vector3 Vetor = -(Player.transform.position - Enemy.transform.position);
                    Vetor = Vetor / Vector3.Magnitude(Vetor);
                    allyDist = Vector3.Distance(Enemy.transform.position, Player.transform.position);
                    playerDist = Vector3.Distance(transform.position, Player.transform.position);
                    transform.LookAt(Enemy.transform.position);
                    if (allyDist + 2 > playerDist)
                    {
                        transform.position += Vetor * Time.deltaTime * (lspd + 157.4F) / 19.8F;

                    }
                    else
                    {
                        //Anim.SetBool("Run", false);
                        Anim.SetBool("Backwards", false);
                        if (Player != null)
                        {
                            transform.LookAt(Player.transform.position);
                        }
                        attackDealt = false;
                    }
                    /*transform.LookAt(Enemy.transform.position + new Vector3(0, 0, 2));
                    allyDist = Vector3.Distance(transform.position, Enemy.transform.position + new Vector3(0, 0, 2));
                    if (allyDist < damageDist)
                    {
                        if (Player != null)
                        {
                            transform.LookAt(Player.transform.position);
                        }
                        attackDealt = false;
                    }
                    else transform.position += transform.forward * Time.deltaTime * (lspd + 157.4F) / 19.8F;
                    */
                }
                else Anim.SetBool("Backwards", false);// Anim.SetBool("Run", false);
            }
            else if (job == "Tactician" || job == "Priest" || job == "Wizard")
            {
                if (Enemy != null && Player != null)
                {
                    enemyJob = Enemy.GetComponent<PlayerBehavior>().job;
                    if (playerJob == "Knight" || playerJob == "Wanderer" || playerJob == "Soldier")
                    {
                        Vector3 Vetor = -(Player.transform.position - Enemy.transform.position);
                        Vetor = Vetor / Vector3.Magnitude(Vetor);
                        allyDist = Vector3.Distance(Enemy.transform.position, Player.transform.position);
                        playerDist = Vector3.Distance(transform.position, Player.transform.position);
                        transform.LookAt(Enemy.transform.position);
                        if (allyDist + 4 > playerDist)
                        {
                            transform.position += Vetor * Time.deltaTime * (lspd + 157.4F) / 19.8F;

                        }
                        else
                        {
                            //Anim.SetBool("Run", false);
                            Anim.SetBool("Backwards", false);
                            if (Player != null)
                            {
                                transform.LookAt(Player.transform.position);
                            }
                            attackDealt = false;
                        }
                    }
                    else Anim.SetBool("Backwards", false);//Anim.SetBool("Run", false);
                }
                else if (playerJob == "Thief" || playerJob == "Berserker")
                {
                    if (Enemy != null && Player != null)
                    {
                        Vector3 Vetor = -(Player.transform.position - Enemy.transform.position);
                        Vetor = Vetor / Vector3.Magnitude(Vetor);
                        allyDist = Vector3.Distance(Enemy.transform.position, Player.transform.position);
                        playerDist = Vector3.Distance(transform.position, Player.transform.position);
                        transform.LookAt(Enemy.transform.position);
                        if (allyDist + 2 > playerDist)
                        {
                            transform.position += Vetor * Time.deltaTime * (lspd + 157.4F) / 19.8F;

                        }
                        else
                        {
                            //Anim.SetBool("Run", false);
                            Anim.SetBool("Backwards", false);
                            if (Player != null)
                            {
                                transform.LookAt(Player.transform.position);
                            }
                            attackDealt = false;
                        }
                    }
                    else Anim.SetBool("Backwards", false);//Anim.SetBool("Run", false);
                }
            } else Anim.SetBool("Backwards", false);//Anim.SetBool("Run", false);
        }
    }

    protected void AttackPriority() { }

    protected void DefensePriority() { }

    protected void Die()
    {
        if (gameObject.tag == "Player")
        {
            if (currentHealth <= 0)
            {
                aSkillButton.interactable = false;
                bSkillButton.interactable = false;
                ultimateButton.interactable = false;
                Destroy(ASliderObject);
                Destroy(BSliderObject);
                Destroy(USliderObject);
                Destroy(HpSlider);
                Destroy(MvSlider);
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "Enemy")
        {
            if (currentHealth <= 0)
            {
                Destroy(HpSlider);
                Destroy(MvSlider);
                Destroy(gameObject);
            }
        }
    }

    protected void FindCharacters()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    protected void HealthBar()
    {
        healthSlider.value = currentHealth;
        if (gameObject.tag == "Player")
        {
            var wantedPos = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, 1, 0));
            healthSlider.transform.position = wantedPos;
        }
        if (gameObject.tag == "Enemy")
        {
            var wantedPos = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, -1, 0));
            healthSlider.transform.position = wantedPos;
        }
        
    }

    protected void MovBar()
    {
        movSlider.value = movTotal;
        if (gameObject.tag == "Player")
        {
            var wantedPos = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, 0.9F, 0));
            movSlider.transform.position = wantedPos;
        }
        if (gameObject.tag == "Enemy")
        {
            var wantedPos = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, -0.9F, 0));
            movSlider.transform.position = wantedPos;
        }

    }

    protected void ChargeBar()
    {
        ultSlider.value = maxCharge;       
        if (maxCharge == 0)
        {
            ultimateButton.interactable = true;
            ultSlider.gameObject.SetActive(false);
        }
        else ultSlider.gameObject.SetActive(true);
    }

    protected void SkillsCooldownSet()
    {
        aCooldownTimer = 10;
        bCooldownTimer = 8;
        aSkillCooldown = aCooldownTimer;
        bSkillCooldown = bCooldownTimer;
        aSlider.maxValue = aCooldownTimer;
        aSlider.value = aSkillCooldown;
        bSlider.maxValue = bCooldownTimer;
        bSlider.value = bSkillCooldown;
    }

    protected void SkillsCooldown()
    {
        aSkillCooldown -= Time.deltaTime;
        bSkillCooldown -= Time.deltaTime;
        aSlider.value = aSkillCooldown;
        bSlider.value = bSkillCooldown;
        if (aSkillCooldown <= 0)
        {
            aSkillButton.interactable = true;
        }
        if (bSkillCooldown <= 0)
        {
            bSkillButton.interactable = true;
        }
    }

    protected void FindUI()
    {
        if (gameObject.tag == "Player")
        {
            HpSlider = GameObject.Find("Health_Slider_" + positionInGame);
            MvSlider = GameObject.Find("Mov_Slider_" + positionInGame);
            PositionInGameGameObject = GameObject.Find(positionInGame);
            AButtonGameObject = GameObject.Find(positionInGame + "/Button_Skill_A");
            BButtonGameObject = GameObject.Find(positionInGame + "/Button_Skill_B");
            UButtonGameObject = GameObject.Find(positionInGame + "/Button_Ultimate");
            ASliderObject = GameObject.Find(positionInGame + "/Button_Skill_A" + "/Slider");
            BSliderObject = GameObject.Find(positionInGame + "/Button_Skill_B" + "/Slider");
            USliderObject = GameObject.Find(positionInGame + "/Button_Ultimate" + "/Slider");
            NameOverSkillObject = GameObject.Find(positionInGame + "/Image_Under_Name_" + positionInGame + "/Name_" + positionInGame);

            healthSlider = HpSlider.GetComponent<Slider>();
            movSlider = MvSlider.GetComponent<Slider>();
            aSkillButton = AButtonGameObject.GetComponent<Button>();
            aSkillButton.onClick.AddListener(SkillA);
            bSkillButton = BButtonGameObject.GetComponent<Button>();
            bSkillButton.onClick.AddListener(SkillB);
            ultimateButton = UButtonGameObject.GetComponent<Button>();
            aSlider = ASliderObject.GetComponent<Slider>();
            bSlider = BSliderObject.GetComponent<Slider>();
            ultSlider = USliderObject.GetComponent<Slider>();
            nameOverSkill = NameOverSkillObject.GetComponent<Text>();
        }
        else if (gameObject.tag == "Enemy")
        {
            HpSlider = GameObject.Find("Health_Slider_" + positionInGame);
            MvSlider = GameObject.Find("Mov_Slider_" + positionInGame);
            PositionInGameGameObject = GameObject.Find(positionInGame);
            AButtonGameObject = null;
            BButtonGameObject = null;
            UButtonGameObject = null;
            ASliderObject = null;
            BSliderObject = null;
            USliderObject = null;

            healthSlider = HpSlider.GetComponent<Slider>();
            movSlider = MvSlider.GetComponent<Slider>();
            aSkillButton = null;
            bSkillButton = null;
            ultimateButton = null;
            aSlider = null;
            bSlider = null;
            ultSlider = null;
        }
    }

    //---------------------------------------------------------------------------------
    public string GetJob(){ return job; }
    public float GetHp() { return currentHealth; }
    public void GetTarget() { }

}

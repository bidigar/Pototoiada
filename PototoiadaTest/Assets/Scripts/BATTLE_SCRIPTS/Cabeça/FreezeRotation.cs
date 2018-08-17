using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRotation : MonoBehaviour {

    public GameObject body, head;
    public Animator anim, goAnim;
    public float Health;
    public bool hea = false;

	// Use this for initialization
	void Start () {
        body = GameObject.Find(name);
        anim = this.GetComponent<Animator>();
        goAnim = body.GetComponent<Animator>();
        head = GameObject.Find(body.name + "/mixamorig:Hips" + "/mixamorig:Spine" + "/mixamorig:Spine1" + "/mixamorig:Spine2" + "/mixamorig:Neck" + "/mixamorig:Head");
    }
	
	// Update is called once per frame
	void Update () {  
        
        if (body != null)
        {
            if (Health != body.GetComponent<PlayerBehavior>().currentHealth && hea == false)
            {
                Health = body.GetComponent<PlayerBehavior>().currentHealth;
                anim.SetBool("Damaged", false);
                hea = true;
            }
            if (body.tag == "Player")
            {
                this.transform.parent.position = head.transform.position + new Vector3(0.5F, 1F, 0) ;
            }
            else this.transform.parent.position = head.transform.position + new Vector3(0.5F, 1F, 0) ;
            if (goAnim.GetBool("Attack"))
            {
                anim.SetBool("Attack", true);
            }
            if (body.GetComponent<PlayerBehavior>().w84 == false)
            {
                anim.SetBool("Attack", false);
            }
            if (body.GetComponent<PlayerBehavior>().currentHealth != Health && hea == true)
            {
                anim.SetBool("Damaged", true);
                hea = false;
            }

        } else Destroy(gameObject);
    }
}

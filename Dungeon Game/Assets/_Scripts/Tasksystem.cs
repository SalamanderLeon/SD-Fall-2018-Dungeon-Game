using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

[RequireComponent(typeof(Animator))]
public class Tasksystem : MonoBehaviour {

    Animator anim;
    public Map mkey;
    public int keycount;
    public Flowchart fc;
    [Header("Player Attributes")]
    public static int hp;
    [Range(0,100)]
    public int hpmax = 100;
    public static bool invincibled = false;
    public static float invincibledTime = 0.0f;

    [Header("Player UI")]
    public Text hptext;
    public Image hpbar;

	// Use this for initialization
	void Start () {
        
        hp = hpmax;
        if(hpbar != null)
        {
            hpbar.fillAmount = (float)hp / (float)hpmax;
        }
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if(hpbar != null)
        {
            hpbar.fillAmount = (float)hp / (float)hpmax;
        }
        if (hp <= 0)
        {
            hp = 0;
            anim.Play("1handedDeath");
           
            //Debug.Log("Dead!");
        }

        if(fc != null)
            fc.SetIntegerVariable("keynumber", mkey.keysOnFloor);

        if (invincibledTime > 0.0f)
            invincibledTime -= Time.deltaTime;
        else
            invincibled = false;
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Health health = gameObject.GetComponent<Health>();
        if ( collision.gameObject.tag == "Arm" || collision.gameObject.tag == "Player")
        {
           // Debug.Log("Damager to Player by object TAG: " + collision.gameObject.tag);
           // hp -= 10;
           // Debug.Log("Current Health: " + hp);

             //Apply damage to health
            if (hp <= 0)
            {
                hp = 0;
                gameObject.GetComponent<Animator>().Play("Die");
                //Debug.Log("Dead!");
            }
        }
    }

    public void keylogs()
    {
        //if (keycount == 1)
        //{
        //    Fungus.Flowchart.BroadcastFungusMessage("onekey");
        //}
       

        keycount++;
        if (keycount == 1)
        { Fungus.Flowchart.BroadcastFungusMessage("onekey");
          Fungus.Flowchart.BroadcastFungusMessage("TaskGoal");
        }
        else if (keycount == 2)
        { Fungus.Flowchart.BroadcastFungusMessage("twokeys");
          Fungus.Flowchart.BroadcastFungusMessage("TaskGoal");
        }
        else if (keycount == 3)
        { Fungus.Flowchart.BroadcastFungusMessage("threekeys");
          Fungus.Flowchart.BroadcastFungusMessage("TaskGoal");
        }
        if (keycount == mkey.keysOnFloor)
        {
            Fungus.Flowchart.BroadcastFungusMessage("gamewin");          
            Fungus.Flowchart.BroadcastFungusMessage("Reload");
            Invoke("ReloadScene", 5);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Additive);
    }

}



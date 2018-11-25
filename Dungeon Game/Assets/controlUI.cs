using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Animator))]
public class controlUI : MonoBehaviour {

    Animator anim;
   
    [Header("Player Attributes")]
    public int hp;
    [Range(0,100)]
    public int hpmax=100;

    


    [Header("Player UI")]
    public Text hptext;
    public Image hpbar;




   



	// Use this for initialization
	void Start () {
        hp = hpmax;
        hpbar.fillAmount = (float)hp / (float)hpmax;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        hpbar.fillAmount = (float)hp / (float)hpmax;
        if (hp <= 0)
        {
            hp = 0;
            anim.Play("1handedDeath");
           
            //Debug.Log("Dead!");
        }
      
    }
    public void TakeDamage(int amount)
    {
        hp -= amount;

        //if (hp <= 0)
        //{
        //    hp = 0;
            
        //    gameObject.GetComponent<Animator>().Play("Die");
        //    //Debug.Log("Dead!");
        //}
    }
}

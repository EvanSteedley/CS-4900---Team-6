using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Enemy : MonoBehaviour
{
    //Reference to the Player - will probably only need one of these.
    [SerializeField]
    public Player p;
    [SerializeField]
    public Turns t;
    [SerializeField]
    public Text EnemyAttackValue;
    [SerializeField]
    public Text EnemyDefenseValue;
    public Animator anim;
    //Enemy's health; if <= 0, they die.
    public int health = 100;
    //How much damage the Enemy will do on its turn
    public int damage = 10;
    public bool dead = false;
    public int defense = 0;
    //Amount of gold to drop when killed
    public int goldValue = 100;
    enum states { 
    
        Fight, Defend, Buff, Poison, LowerPlayerDefense
    
    }


    [SerializeField]
    public Text HealthValue;

    // Start is called before the first frame update
    void Start()
    {
        p = FindObjectOfType<Player>();
        t = FindObjectOfType<Turns>();
        //SliderHealth.value = health;
        anim = GetComponent<Animator>();
        EnemyDefenseValue.text = defense.ToString();
        HealthValue.text = health.ToString();
        EnemyAttackValue.text = damage.ToString();
        p.CardPlayed += HandleCardPlayed;  //subscribing the handle card played to the publisher
        //HandleCardPlayed is a delegate
    }

    // Update is called once per frame
    void Update()
    {
     //This is inefficient!  Calling the Attack through a Coroutine or by any other method is much better.
     //"Once per frame" is VERY OFTEN; around 60 times per second, usually.
        //if (!t.PlayerTurn && !dead)
        //    Attack();
        
    }

    virtual public void TakeDamage(int d)
    {
        if (d - defense >= health && !dead)     
             
        {
            dead = true;
            p.gold += goldValue;
            //Ragdoll effect!
            Rigidbody rb = this.gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
            rb.AddForce(new Vector3(0f, 400f, 500f));
            rb.AddTorque(new Vector3(5f, 50f, 35f));
            Destroy(this.gameObject, 3f);
        }
        if (defense < d)
			health -= (d-defense);
        defense = 0;
        EnemyDefenseValue.text = defense.ToString();
        if (health<0) 
		{ 
			health = 0; 
		}
        //SliderHealth.value = health;
        HealthValue.text = health.ToString();
    }

    public void BuffDefense(int v)
    {
        defense += v;
        EnemyDefenseValue.text = defense.ToString();
    }

    public void BuffHealth(int v)
    {

        health += v;
        HealthValue.text = health.ToString();

        //leave this BuffHealth method empty for now for the Enemy - come back to this later
    }

    public void Heal(int v)
    {

        health += v;
        HealthValue.text = health.ToString();

        //leave this BuffHealth method empty for now for the Enemy - come back to this later
    }

    virtual public void Attack()
    {
        p.TakeDamage(damage);
        //This is controlled by the Turns class now.
            //t.PlayerTurn = true;
    }

  
    virtual public void EnemyBehaviour() {


        System.Random random = new System.Random();
        int num = random.Next(System.Enum.GetNames(typeof(states)).Length);
        if (num == (int)states.Fight) {
           Attack();
        }

        if (num == (int)states.Defend)
        {
            Defend(1);
        }

        if (num == (int)states.Buff)
        {
           Buff(2);
        }

        if(num == (int)states.Poison)
        {
            p.gameObject.AddComponent<Poison>();
        }
        if (num == (int)states.LowerPlayerDefense)
        {
            p.gameObject.AddComponent<DefenseDown>();
        }



    }

    virtual public void Defend(int d)
    {
        defense += 20;
        EnemyDefenseValue.text = defense.ToString();
        
    }

    virtual public void Buff(int value)
    {
        
            damage += value;
        EnemyAttackValue.text = damage.ToString();
    }


    //make a method in this class that takes cards 
    void HandleCardPlayed(object sender, EventBayesian e)
    {
        //Call Bayesian table with card played

        //this method should call whatever method from BayesianCardTable 
        //Enemy class has the list of all possible enemy cards - which it then sends to the BayesianCardTable (list # 1)
        //based on the probabilities, the BayesianCardTable sends a list of whatever possible cards the enemy can play
        //in response to the player (list # 2)
        //random number generator chooses what final card the enemy will play, from this list
        //if none of the cards are available/chosen for whatever reason, choose one at random from list # 1
        //if none of the options work, return null

        int NumberOfPlayerCards = 14;
        int NumberOfEnemyCards = 10;

        int IndexOfPlayerCard = ;   // retrieved from Player class
        int IndexOfEnemyCard;

        listUniqueOptions;  // read listA from EnemyTable.cs

        // listB to store cumulative probabilities from listA
        // e.g. listA = {0.1, 0.05, 0.2, 0.4, 0.15, 0.1}
        // then listB = {0.1, 0.15, 0.35, 0.75, 0.9, 1.0}
        List<string> ResultfromTable = new List<string>();

        // listC to store enemy cards chosen
        List<string> EnemyCards = new List<string>();

        ResultfromTable[0] = listUniqueOptions[0];
        for (int i = 1; i < length of listUniqueOptions; i++)
        {
            ResultfromTable.Add(ResultfromTable [i-1]+listUniqueOptions[i]);
        }

        float r = Random number in range(0, 1); // choose a random number between 0 and 1 to select enemy card

        // compare r with listB elements and choose an enemy card
        for (int j = 0; j < length of ResultfromTable; j++)
        {
            if (r <= ResultfromTable[j])
            {
                IndexOfEnemyCard = j;
                EnemyCards.Add(j)
                break;
            }
        }

    }

}









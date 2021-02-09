using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour
{
    //If true, then the player can take their turn.
    public bool PlayerTurn = true;
    [SerializeField]
    Player p;
    //List of enemies in the current fight.
    [SerializeField]
    public List<Enemy> enemies = new List<Enemy>();
    //This controls how long the "animations" will last.
    [SerializeField]
    float delayBetweenTurns = .5f;
    //For changing the camera location when one side loses.
    GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject;
        //All enemies in the scene are added to the list of active enemies.
        Enemy[] enemiesList = FindObjectsOfType<Enemy>();
        foreach (Enemy e in enemiesList)
        {
            enemies.Add(e);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator EndPlayerTurn()
    {
        PlayerTurn = false;
        //Coding transform changes is rough.
            ////p.transform.position.Set(p.transform.position.x + 1f, p.transform.position.y, p.transform.position.z);
            //p.transform.Translate(new Vector3(1f, 0f, 0f));
            //yield return StartCoroutine(EnemyDelay());
            //p.transform.Translate(new Vector3(-1f, 0f, 0f));
        yield return StartCoroutine(EnemyDelay());
        //p.transform.position.Set(p.transform.position.x - 1f, p.transform.position.y, p.transform.position.z);
        int count = 0;
        foreach (Enemy e in enemies)
        {
            //Loops through all active enemies; if they aren't dead, then they attack the player and pause for the animation to play.
            if (!e.dead)
            {
                count++;
                //StartCoroutine(EnemyDelay());
                //StartCoroutine(EnemyDelay());
                e.transform.Translate(new Vector3(-1f, 0f, 0f));
                //e.transform.position.Set(e.transform.position.x + 1f, e.transform.position.y, e.transform.position.z);
                yield return StartCoroutine(EnemyDelay());
                //Invoke("e.Attack", delayBetweenTurns);
                //System.Threading.Thread.Sleep((int)(delayBetweenTurns * 1000));
                e.Attack();
                e.transform.Translate(new Vector3(1f, 0f, 0f));
                //e.transform.position.Set(e.transform.position.x - 1f, e.transform.position.y, e.transform.position.z);
            }
        }
        //If there are enemies still alive and the player isn't dead, the Player can take their turn.
        if (count > 0 && !p.dead)
        {
            PlayerTurn = true;
            p.StartTurn();
        }

        else 
        {
            
        }

        yield return null;
    }

    public IEnumerator EnemyDelay()
    {
        float initialTime = Time.time;
        //Debug.Log("Started EnemyDelay at timestamp : " + Time.time);
        //"Time.time" accesses the current time, which is a float value counting up in seconds from the initialization of the scene.
        //Time.time - initialTime < delayBetweenTurns just calculates the difference between the current time and makes sure the right
        //amount of time has elapsed before returning.
        while(Time.time - initialTime < delayBetweenTurns)
        {
            //Debug.Log(Time.time - initialTime);
            yield return null; 
        }
        //Debug.Log("Finished EnemyDelay at timestamp : " + Time.time);
    }

    public void CamZoomOut() 
    {
        //cam.transform.Translate(0, 6, -8);
        //Updates the Camera's position to be further zoomed out.
        cam.transform.position = new Vector3(0, 9, -12);
    }

    //Counts the enemies still in the list, and not dead.
    public int EnemiesAlive()
    {
        int count = 0;
        foreach (Enemy e in enemies)
        {
            if (!e.dead)
                count++;
        }
        return count;
    }

}
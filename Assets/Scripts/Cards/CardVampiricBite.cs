using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardVampiricBite : Card
{
    public List<Enemy> Targets;
    
    // Start is called before the first frame update
    void Start()
    {
        id = 12;
        value = 30;
        mana = 5;
        name = "Vampiric Bite";
        description = "Damage an enemy and heal yourself for 30 points.";
        numberOfTargets = 2;
        Targeter = this.gameObject.GetComponent<SelectionGO>();
        Targeter.numberOfSelections = numberOfTargets;
        Targeter.exclusive = true;
        SetInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Action()
    {
        foreach (GameObject GO in Targeter.Selections)
        {
            Enemy e = GO.GetComponent<Enemy>();
            if (e != null)
                e.TakeDamage(value);
        }
        Player p = FindObjectsOfType<Player>()[0];
        p.Heal(value);
        RemoveHighlightTargets();
        ClearSelections();
        Destroy(this.gameObject);
    }

    override public void HighlightTargets()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy GO in enemies)
        {
            SelectableGO SGO = GO.GetComponentInParent<SelectableGO>();
            if (SGO != null)
            {
                SGO.enabled = true;
                if (SGO.ren == null)
                    SGO.ren = SGO.GetComponent<Renderer>();
                SGO.ren.material.color = Color.cyan;
                SGO.SGO = Targeter;
            }
        }
    }

    override public void RemoveHighlightTargets()
    {
        Enemy[] objects = FindObjectsOfType<Enemy>();
        foreach (Enemy GO in objects)
        {
            SelectableGO SGO = GO.GetComponent<SelectableGO>();
            if (SGO != null)
            {
                if (SGO.ren == null)
                    SGO.ren = SGO.GetComponent<Renderer>();
                SGO.ren.material.color = SGO.defaultColor;
                SGO.enabled = false;
            }
        }
    }

    override public void ClearSelections()
    {
        Targeter.Selections = new List<GameObject>();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class StatusEffects : MonoBehaviour
    {

    [SerializeField]
    Turns t;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int turnsLeft = 2;
    virtual public void Action()
    {

        if (turnsLeft > 0)
        {
            //Do the Action
            turnsLeft--;
        }
        else
        {
            //Revert and remove this StatusEffect
        }
    }

    }




﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;



public class EventBayesian: EventArgs
    {

    public EventBayesian(Card message)
    {
        Message = message;
    }

    public Card Message { get; set; }

}







    


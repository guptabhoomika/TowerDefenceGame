﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class turretBuleprint 
{
    public GameObject prefab;
    public int cost;
    public GameObject upgradePrefab;
    public int upgradeCost;
    
    

    [HideInInspector]
   public int sellCost;
    public int getSellamt()
        
    {

        
        sellCost = 50;

        return sellCost;
    }
   
    
}

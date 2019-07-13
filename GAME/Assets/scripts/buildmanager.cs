using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildmanager : MonoBehaviour
{
    public static buildmanager instance;
    private turretBuleprint turretTobuild;
    public node selectedNode;
    public NodeUI nodeUI;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one build manager");
            return;
        }
        instance = this;
    }
    public bool CanBuild{ get {return turretTobuild != null;}}
    public bool HasMoney { get { return playerStats.money >= turretTobuild.cost; } }

   
    public void selectTurrettobuild(turretBuleprint turret)
    {
        turretTobuild = turret;
        DeselectNode();
    }
    public void SelectNode(node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretTobuild = null;
        nodeUI.SetTarget(node);
        

    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public turretBuleprint getTurretTobuild()
    {
        return turretTobuild;
    }        
   
}










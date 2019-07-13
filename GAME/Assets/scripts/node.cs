using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class node : MonoBehaviour
{
    public Color  hoverColor;
    private Renderer rend;
    private Color startColor;
    public Color notEnoughmoney;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public  turretBuleprint bluePrint;
    [HideInInspector]
    public turretBuleprint sellBluePrint;
    [HideInInspector]
    public bool isUpgraded = false;


    buildmanager buildmanager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildmanager = buildmanager.instance;   
        
    }
    public Vector3 GetBuildposition()
    {
        return transform.position ;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildmanager.CanBuild)
            return;
        if(buildmanager.HasMoney)

        {
            rend.material.color = hoverColor;
        }
        else
        {
            
            rend.material.color = notEnoughmoney;

        }
        


    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;



        if (turret != null)
        {

            buildmanager.SelectNode(this);

            return;
        }
        if (!buildmanager.CanBuild)
            return;
        BuildTurret(buildmanager.getTurretTobuild());
            }


   public  void BuildTurret(turretBuleprint blueprint)
    {
        if (playerStats.money < blueprint.cost)
        {
            Debug.Log("Not enough money");
            return;

        }
        bluePrint = blueprint;
        playerStats.money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildposition(), Quaternion.identity);
                turret = _turret;
        
        Debug.Log("Build");
    }

        
        



    
    public void UpgradeTurret()
    {
        if (playerStats.money < bluePrint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade");
            return;

        }
        playerStats.money -= bluePrint.upgradeCost;

        Destroy(turret);
        GameObject _turret = (GameObject)Instantiate(bluePrint.upgradePrefab, GetBuildposition(), Quaternion.identity);
        turret = _turret;
        



        isUpgraded = true;

    }
    public void sellTurret()
    {
        sellBluePrint.getSellamt();

        playerStats.money += sellBluePrint.sellCost;
        Destroy(turret);
       
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

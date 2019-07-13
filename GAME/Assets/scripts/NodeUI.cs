using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;
    private node target;
    public Text upgradeCost;
    public Button upgradeButton;
    public Text upgradedText;
    public Text upgradeText;
    public Text sellText;
    

    
   
        
    public void SetTarget(node _target)
    {
        target = _target;
        transform.position = target.GetBuildposition();
        if(!target.isUpgraded)
        {
            upgradeCost.text = "₹" + target.bluePrint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.GetComponent<Text>().enabled = false;
            upgradeText.GetComponent<Text>().enabled = false;


            upgradedText.text = "UPGRADED";


            upgradeButton.interactable = false;
           
        }
        target.sellBluePrint.getSellamt();
        sellText.text = "₹"+ target.sellBluePrint.sellCost.ToString();


        ui.SetActive(true);

    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        buildmanager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.sellTurret();
        buildmanager.instance.DeselectNode();
    }
}

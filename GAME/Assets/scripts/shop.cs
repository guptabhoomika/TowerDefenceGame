using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public turretBuleprint standardTurret;
    public turretBuleprint missilelauncher;
    public turretBuleprint laserBeamer;
    buildmanager buildmanager;
    private void Start()
    {
        buildmanager = buildmanager.instance;
    }
    public void selectStandardTurret()
    {
        Debug.Log("Purchased");
        buildmanager.selectTurrettobuild(standardTurret);
    }
    public void selectMissileLauncher()
    {
        Debug.Log("Purchased");
        buildmanager.selectTurrettobuild(missilelauncher);
    }
    public void selectlaserBeamer()
    {
        buildmanager.selectTurrettobuild(laserBeamer);
    
    }
}

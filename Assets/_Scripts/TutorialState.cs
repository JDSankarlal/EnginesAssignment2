using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialState : MonoBehaviour
{
    // Start is called before the first frame update
    public enum tutorialState
    {
        learnMovementStage1,
        learnMovementStage2,
        learnPickupSmall,
        learnPickupLarge,
        learnSorting,
        //Switches to the spellcaster here
        learnPickupFromChest,
        learnTowerBuild
    }

    public GameObject player1;
    public GameObject player2;

    public tutorialState state;
    private static ObjectPool myPool;

    GameObject[] fob;
    ///var fob : GameObject[];
    void Start()
    {
        state = tutorialState.learnMovementStage1;
        myPool = ObjectPool.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == tutorialState.learnMovementStage1)
        {
            //UI: This is a tower building and movement tutorial
            //UI: Use the mouse to look around, use WASD to move, try moving over to that big beam of light!
            if (Waypoint.touchedWaypoint)
            {
                state = tutorialState.learnMovementStage2;
                //UI: Great, now walk to the next one!
            }

        }
        if (state == tutorialState.learnMovementStage2)
        {
            if (Waypoint.touchedWaypoint2)
            {
                //start pawaning small resources
                myPool.SpawnObject("Resource(WoodSmall)", new Vector3(-3, 0.5f, -60), transform.rotation);
                myPool.SpawnObject("Resource(StoneSmall)", new Vector3(0, 0.5f, -60), transform.rotation);
                myPool.SpawnObject("Resource(CrystalSmall)", new Vector3(3, 0.5f, -60), transform.rotation);
                //Debug.Log("Spawn Wood");
                state = tutorialState.learnPickupSmall;
            }
        }
        if (state == tutorialState.learnPickupSmall)
        {

            if (PlayerPickup.StoneAmount >= 1 && PlayerPickup.WoodAmount >= 1 && PlayerPickup.CrystalAmount >= 1)
            {
                //delete small resources and start spawning large resources
                myPool.SpawnObject("Resource(Wood)", new Vector3(-3, 0.5f, -70), transform.rotation);
                myPool.SpawnObject("Resource(Stone)", new Vector3(0, 0.5f, -70), transform.rotation);
                myPool.SpawnObject("Resource(Crystal)", new Vector3(3, 0.5f, -70), transform.rotation);
                state = tutorialState.learnPickupLarge;
            }
        }
        if (state == tutorialState.learnPickupLarge)
        {
            if (PlayerPickup.StoneAmount >= 3 && PlayerPickup.WoodAmount >= 3 && PlayerPickup.CrystalAmount >= 3)
            {
                //delete small resources and start spawning large resources
                state = tutorialState.learnSorting;
            }
        }
        if (state == tutorialState.learnSorting)
        {
            if (PlayerPickup.stoneStock >= 1 && PlayerPickup.woodStock >= 1 && PlayerPickup.crystalStock >= 1)
            {
               //[SerializeField]
                //player2.setactive(false);
                //player1.setactive(true);
                //Test.Equals(this).player1.setactive(false);
                player1.SetActive(true);
                player2.SetActive(false);
                state = tutorialState.learnPickupFromChest;
            }
        }
        if (state == tutorialState.learnPickupFromChest)
        {
            if (WizardResourceManager.wizardWoodAmount >= 1 && WizardResourceManager.wizardWoodAmount >= 1 && WizardResourceManager.wizardWoodAmount >= 1)
            {
                state = tutorialState.learnTowerBuild;
            }
        }
        if (state == tutorialState.learnTowerBuild)
        {
            if (TowerBuild.stage >= 1)
            {
                //end tutorial
            }
        }
    }
}

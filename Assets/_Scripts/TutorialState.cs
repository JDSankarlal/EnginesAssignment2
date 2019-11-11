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

    public tutorialState state;
    void Start()
    {
        state = tutorialState.learnMovementStage1;
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
                //Move light beam to different location on map
                //change to next state
                //UI: Great, now walk to the next one!
            }

        }
        if (state == tutorialState.learnMovementStage2)
        {
            if (Waypoint.touchedWaypoint2)
            {
                //start pawaning small resources
                state = tutorialState.learnPickupSmall;
            }
        }
        if (state == tutorialState.learnPickupSmall)
        {
            if (PlayerPickup.StoneAmount >= 1 && PlayerPickup.WoodAmount >= 1 && PlayerPickup.CrystalAmount >= 1)
            {
                //delete small resources and start spawning large resources
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
                state = tutorialState.learnPickupFromChest;
            }
        }
        if (state == tutorialState.learnPickupFromChest)
        {
            //switch to spellcaster
            if(WizardResourceManager.wizardWoodAmount >= 1 && WizardResourceManager.wizardWoodAmount >= 1 && WizardResourceManager.wizardWoodAmount >= 1)
            {
                 state = tutorialState.learnTowerBuild;
            }
        }
        if (state == tutorialState.learnTowerBuild)
        {
            //if(TowerBuild.stage >= 1)
           // {
               //end tutorial
            //}
        }






    }

    void Check(tutorialState status)
    {
        //switch (status)
        //{
        //case tutorialState.learnMovementStage1:
        //UI: This is a tower building and movement tutorial
        //UI: Use the mouse to look around, use WASD to move, try moving over to that big beam of light!
        //spawn waypoint
        //if (PlayerMovement.touchedWaypoint)
        //{
        //Move light beam to different location on map
        //change to next state
        //UI: Great, now walk to the next one!
        //break;
        //}




        //case tutorialState.learnMovementStage2:

        //if (PlayerMovement.touchedWaypoint)
        //{
        //Delete waypoint
        //change to next state
        //UI: to pick up small resources just walk over them
        //   break;
        //}                

        //if state == learnPickupSmall
        //if picked up 3 small resources
        //change to next state
        //UI: To pick up larger resources you'll have to be tuching it, then hold E for a bit

        //if state == learnPickupLarge
        //if picked up 3 large resources
        //change state
        //UI: Go place those in the chests by touching each chest!

        //if state == learnSorting
        //If all chests touched
        //switch camera, set rogue not active, switch spellcaster to active.
        //change state
        //UI: Now you're the spellcaster! To grab items out of the chests touch them and press E

        //if state == learnPickupFromChest
        //if 5 or more of each resource in inventory
        //change state
        //UI: Now walk over to the tower and press TAB to build the first phase!

        //if state == learnTowerBuild
        //if tower stage 1
        //UI: Great job, now you know the basics of the game! In order to win you will have to be the first team to have all three phases of your tower built. Good Luck!
        //Wait a few seconds
        //End Tutorial



    }
}

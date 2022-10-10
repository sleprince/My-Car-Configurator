using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //so text, buttons etc work.
//using UnityEngine.SceneManagement; //so that GetInstance() works.

public class ButtonHandler : MonoBehaviour
{

    public Transform CarSpawnPoint; //an empty GameObject with the transform position for the car.
    public int PreviousClicks = 0;
    public int NextClicks = 0;
    public GameObject Car;

    CarManager CarMan;

    //note for future reference, awake and start never get called on buttons.
    //void awake() 

    //void start()


    // On click of previous button.
    public void Previous()
    {
        CarMan = CarManager.GetInstance();
        //Car = Resources.Load("4x4_blue") as GameObject;

        //GameObject GO = Instantiate(Car) as GameObject;

        if (CarMan.Chosen[0].ClonedCar != null)//delete the one we have now if we do have one
        {
            Destroy(CarMan.Chosen[0].ClonedCar);
        }



        GameObject GO = Instantiate(
        //creates a car from the prefab
        CarManager.GetInstance().Cars[0].CarPrefab[0],
        //makes it appear at the position that I want.
        CarSpawnPoint.position,
        Quaternion.identity) as GameObject;

        CarMan.Chosen[0].ClonedCar  = GO;

    }

    // On click of next button.
    public void Next() //pass in as clicks
    {

        //if the previews potrait we had, is not the same as the active one we have
        //that means we changed characters
        //      if (CarManager.Chosen != pl.activePotrait)
        //     {
        //if (CarManager.Chosen != null)//delete the one we have now if we do have one
        //{
            //Destroy(CarManager.Chosen.ClonedCar);
        //}


        //defining the half scale.
        //var HalfScale = new Vector3(.25f, .25f, .25f);

        //and create another one
        // GameObject GO = Instantiate(
        //creates the car that's going to be in the scene using the prefab.

        //for i = 1 to 6
       // create prefab [NextClicks]
       //i++
        // CarManager.GetInstance().returnCharacterWithID(pl.activePotrait.characterId).prefab,
        //where you could maybe change the scale
        //spawn position
        //pl.charVisPos.position,
        //Quaternion.identity) as GameObject;

        //bringing the character ID number over from the Character list
        //pl.CharNum = pl.activePotrait.characterId;
        //pl.CharName is the property we want to bring in to the level to show their name under the health bar.
        //pl.CharName = CharacterManager.GetInstance().returnCharacterWithID(pl.activePotrait.characterId).CharName;



        //pl.createdCharacter = go;
        //go.transform.localScale = HalfScale;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //so text, buttons etc work.
//using UnityEngine.SceneManagement; //so that GetInstance() works.

public class ButtonHandler : MonoBehaviour
{

    public Transform CarSpawnPoint; //an empty GameObject with the transform position for the car.
    public int NextClicks; //amount of times the button has been clicked.
    public Button PreviousButton; //the buttons themselves.
    public Button NextButton;
    public Text CarName;

    CarManager CarMan; //reference to my CarManager.

    //note for future reference, awake and start never get called if you use clickon() buttons in editor.
    // void awake()

    void start()
    {

    }


    //this works instead for a disabled object.
    public ButtonHandler() //equivalent to wake.
    {
        instance = this; //part of the method that lets me use methods from this class in other scripts.

    }

     void OnEnable() //like start.
    {
        PreviousButton.onClick.AddListener(Previous); //if clicked run method Previous.
        NextButton.onClick.AddListener(Next);
    }

    public void Update()
    {
        CarName.text = CarMan.Chosen[0].CarName.text ; //make the car name appear in the UI.
        Debug.Log(CarName.text);

    }


    //on click of the next button.
    public void Next()
    {

        CarBuilder();

        if (NextClicks < 5)         //to make a different car appear each time the button is clicked.
        {
            NextClicks++;
        }

        if (NextClicks == 5) //to stop NextClicks being a higher number than that in the list of cars.
        {
            NextClicks--;
            Previous(); //to stop you having to click twice before anything happens.
            NextButton.gameObject.SetActive(false); //to stop user being able to go past the number of cars.
        }

        else
        {
            NextButton.gameObject.SetActive(true);
        }

        if (NextClicks != 0)
        {
            PreviousButton.gameObject.SetActive(true); //make the other button visible whenever relevant.
        }

    }

    //on click of the previous button.
    public void Previous() 
    {

        CarBuilder();

        //to make a different car appear each time the button is clicked.
        if (NextClicks > -1)
        {
            NextClicks--;
        }

        if (NextClicks == -1)
        {
            NextClicks++;
            Next(); //to stop you having to click twice before anything happens.
            PreviousButton.gameObject.SetActive(false);

        }

        else
        {
            PreviousButton.gameObject.SetActive(true);
        }

        if (NextClicks != 5)
        {
            NextButton.gameObject.SetActive(true);
        }

        //putting the name in Chosen, then will put the name in the CarName field in the UI.
        //Chosen.CarName = CarManager.GetInstance().ReturnCarWithID(NextClicks).CarName[0];


    }

    public void CarBuilder()
    {
        CarMan = CarManager.GetInstance();


        if (CarMan.Chosen[0].ClonedCar != null)//If there's already a car there, destroy it before making the new one.
        {
            Destroy(CarMan.Chosen[0].ClonedCar);
        }


        GameObject GO = Instantiate(
        //creates a car from the prefab
        CarManager.GetInstance().ReturnCarWithID(NextClicks).CarPrefab[0],
        //makes it appear at the position that I want.
        CarSpawnPoint.position,
        Quaternion.identity) as GameObject;

        CarMan.Chosen[0].ClonedCar = GO; //this was for debugging purposes.
        CarMan.Chosen[0].CarName = CarManager.GetInstance().ReturnCarWithID(NextClicks).CarName; //put the relevant CarName in
                                                                                                 //the Chosen list.
    }


    public static ButtonHandler instance;
    public static ButtonHandler GetInstance() //all of this is so that I can call this script from objects that do not have it attached.
    {
        return instance;
    }

}

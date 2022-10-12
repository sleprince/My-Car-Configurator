using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //so text, buttons etc work.
//using UnityEngine.SceneManagement; //so that GetInstance() works.

public class ButtonHandler : MonoBehaviour
{

    public Transform CarSpawnPoint; //an empty GameObject with the transform position for the car.
    //public int PreviousClicks = 0;
    public int NextClicks;
    public GameObject Car;
    public Button PreviousButton; //the buttons themselves.
    public Button NextButton;

    CarManager CarMan;

    //note for future reference, awake and start never get called on buttons.
    // void awake()
    void start()
    {

    }


    //this works instead for a disabled object.
    public ButtonHandler() //equivalent to wake.
    {
        instance = this;

        //PreviousButton.gameObject.SetActive(false);



    }

     void OnEnable() //like start
    {
        PreviousButton.onClick.AddListener(Previous);
        NextButton.onClick.AddListener(Next);
    }

    public void Update()
    {







    }


    //on click of the next button.
    public void Next()
    {
        CarMan = CarManager.GetInstance();


        // GameObject GO = Instantiate(Car) as GameObject;

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

        CarMan.Chosen[0].ClonedCar = GO;

        if (NextClicks < 5)
        {
            NextClicks++;
        }
        //to make a different car appear each time the button is clicked.


        if (NextClicks == 5)
        {
            NextClicks--;
            Previous(); //to stop you having to click twice before anything happens.
            NextButton.gameObject.SetActive(false);
        }

        else
        {
            NextButton.gameObject.SetActive(true);
        }

        if (NextClicks != 0)
        {
            PreviousButton.gameObject.SetActive(true);
        }

    }

    //on click of the previous button.
    public void Previous() //pass in as clicks
    {

        CarMan = CarManager.GetInstance();

        //Car = Resources.Load("4x4_blue") as GameObject;

        // GameObject GO = Instantiate(Car) as GameObject;


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

            CarMan.Chosen[0].ClonedCar = GO;

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

    public static ButtonHandler instance;
    public static ButtonHandler GetInstance() //all of this is so that I can call this script from objects that do not have it attached.
    {
        return instance;
    }

}

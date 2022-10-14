using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //so text, buttons etc work.
//using UnityEngine.SceneManagement; //so that GetInstance() works.

public class ButtonHandler : MonoBehaviour
{

    public Transform CarSpawnPoint; //an empty GameObject with the transform position for the car.
    public int NumClicks; //amount of times the button has been clicked by the user.

    public Button PreviousButton; //the buttons themselves.
    public Button NextButton;
    public Button PaintButton;
    public Button RimsButton;
    public Button InteriorButton;
    public Button GadgetsButton;

    public Text CarName;
    public Text PaintName;
    public Text RimsName;
    public Text InteriorName;
    public Text GadgetsName;

    public int v;
    public int w;
    public int x;
    public int y;
    public int z;

    public int [] UpgradesPrice;
    public int Price;
    public int TotalUpgradesPrice;

    public Text TotalPrice;


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

        PaintButton.onClick.AddListener(ChangePaint);
        RimsButton.onClick.AddListener(ChangeRims);
        InteriorButton.onClick.AddListener(ChangeInterior);
        GadgetsButton.onClick.AddListener(ChangeGadgets);

    }


    public void Update()
    {
        CarName.text = CarMan.Chosen[0].CarName.text ; //make the car name appear in the UI.

        bool UpgradeTextOn = (PaintName.gameObject.activeSelf || RimsName.gameObject.activeSelf || InteriorName.gameObject.activeSelf
                             || GadgetsName.gameObject.activeSelf);

        if (UpgradeTextOn)
        { TotalUpgradesPrice = (UpgradesPrice[0]) + (UpgradesPrice[1]) + (UpgradesPrice[2]) + (UpgradesPrice[3]); }


        Price = CarMan.Cars[NumClicks].CarPrice + TotalUpgradesPrice;
        TotalPrice.text = Price.ToString();

        //Debug.Log(CarName.text);

    }


    //on click of the next button.
    public void Next()
    {

        TotalUpgradesPrice = 0;

        PaintName.gameObject.SetActive(false);
        RimsName.gameObject.SetActive(false);
        InteriorName.gameObject.SetActive(false);
        GadgetsName.gameObject.SetActive(false);

        CarBuilder();

        if (NumClicks < 5)         //to make a different car appear each time the button is clicked.
        {
            NumClicks++;
        }

        if (NumClicks == 5) //to stop NumClicks being a higher number than that in the list of cars.
        {
            NumClicks--;
            Previous(); //to stop you having to click twice before anything happens.
            NextButton.gameObject.SetActive(false); //to stop user being able to go past the number of cars.
        }

        else
        {
            NextButton.gameObject.SetActive(true);
        }

        if (NumClicks != 0)
        {
            PreviousButton.gameObject.SetActive(true); //make the other button visible whenever relevant.
        }

    }

    //on click of the previous button.
    public void Previous() 
    {
        TotalUpgradesPrice = 0;

        CarBuilder();

        //to make a different car appear each time the button is clicked.
        if (NumClicks > -1)
        {
            NumClicks--;
        }

        if (NumClicks == -1)
        {
            NumClicks++;
            Next(); //to stop you having to click twice before anything happens.
            PreviousButton.gameObject.SetActive(false);

        }

        else
        {
            PreviousButton.gameObject.SetActive(true);
        }

        if (NumClicks != 5)
        {
            NextButton.gameObject.SetActive(true);
        }

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
        CarManager.GetInstance().ReturnCarWithID(NumClicks).CarPrefab[0],
        //makes it appear at the position that I want.
        CarSpawnPoint.position,
        Quaternion.identity) as GameObject;

        CarMan.Chosen[0].ClonedCar = GO; //this was for debugging purposes.
        CarMan.Chosen[0].CarName = CarManager.GetInstance().ReturnCarWithID(NumClicks).CarName; //put the relevant CarName in
                                                                                                //the Chosen list.
        

        TotalPrice.text = CarMan.Cars[NumClicks].CarPrice.ToString();
    }


    public static ButtonHandler instance;
    public static ButtonHandler GetInstance() //all of this is so that I can call this script from objects that do not have it attached.
    {
        return instance;
    }

    void CarPainter()
    {
        

        if (CarMan.Chosen[0].ClonedCar != null)//If there's already a car there, destroy it before making the new one.
        {
            Destroy(CarMan.Chosen[0].ClonedCar);
        }

        GameObject GO = Instantiate(
        //creates a car from the prefab
        CarManager.GetInstance().ReturnCarWithID(NumClicks - 1).CarPrefab[v],
        //makes it appear at the position that I want.
        CarSpawnPoint.position,
        Quaternion.identity) as GameObject;

        CarMan.Chosen[0].ClonedCar = GO;

        v++;

    }

        void ChangePaint()
    {
        UpgradesPrice[0] = 0;

        PaintName.gameObject.SetActive(true);

        CarMan.Chosen[0].Paint = CarMan.Upgrades[0].Paint[x];
        PaintName.text = CarMan.Upgrades[0].Paint[x].text; //make the name appear in the UI.

        UpgradesPrice[0] = CarMan.Cars[NumClicks].PaintPrice[x];

        if (v == 3)
        { v = 0; }

        CarPainter();

        x++;

        if (x== 3)
        { x = 0; }

    }

    void ChangeRims()
    {
        UpgradesPrice[1] = 0;

        RimsName.gameObject.SetActive(true);

        CarMan.Chosen[0].Rims = CarMan.Upgrades[0].Rims[y];
        RimsName.text = CarMan.Upgrades[0].Rims[y].text; //make the name appear in the UI.

        UpgradesPrice[1] = CarMan.Upgrades[0].RimsPrice[y];

        y++;

        if (y == 3)
        { y = 0; }


    }

    void ChangeInterior()
    {
        InteriorName.gameObject.SetActive(true);

        UpgradesPrice[2] = 0;

        CarMan.Chosen[0].Interior = CarMan.Upgrades[0].Interior[z];
        InteriorName.text = CarMan.Upgrades[0].Interior[z].text; //make the name appear in the UI.

        UpgradesPrice[2] = CarMan.Upgrades[0].InteriorPrice[z];

        z++;

        if (z == 3)
        { z = 0; }

    }

    void ChangeGadgets()
    {
        UpgradesPrice[3] = 0;

        GadgetsName.gameObject.SetActive(true);

        CarMan.Chosen[0].Gadgets = CarMan.Upgrades[0].Gadgets[w];
        GadgetsName.text = CarMan.Upgrades[0].Gadgets[w].text; //make the name appear in the UI.

        UpgradesPrice[3] = CarMan.Upgrades[0].GadgetsPrice[w];

        w++;

        if (w == 3)
        { w = 0; }


    }

}

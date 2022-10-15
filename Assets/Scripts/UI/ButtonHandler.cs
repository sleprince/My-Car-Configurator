using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //so text, buttons etc work.

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

    public Text CarName; //alll the texts that are attached to gameobjects within Editor.
    public Text PaintName;
    public Text RimsName;
    public Text InteriorName;
    public Text GadgetsName;

    public int w; // integers used for the amount of times the upgrades buttons have been clicked.
    public int x;
    public int y;
    public int z;
    public int Touring = 0;

    public int Price; //all the prices.
    public int [] UpgradesPrice; 
    public int TotalUpgradesPrice;

    public Text TotalPrice; //text version of price, will convert the int to string in script.


    CarManager CarMan; //reference to my CarManager.

    //note for future reference, awake and start never get called if you use onClick() buttons in Editor.

    public void Awake()
    {

        NextButton.onClick.AddListener(Next); //so that each button calls the relevant method when clicked.
        PaintButton.onClick.AddListener(ChangePaint);
        RimsButton.onClick.AddListener(ChangeRims);
        InteriorButton.onClick.AddListener(ChangeInterior);
        GadgetsButton.onClick.AddListener(ChangeGadgets);

    }

    public void Start()
    {
        NumClicks = 0; //to make the first car at the start.
        Next(); //to make a car at the start.
    }

    public void ResetUpgrades()
    {
        if (!PaintName.gameObject.activeSelf)
        { UpgradesPrice[0] = 0; } //reset this individual update type's price to 0 when button is not clicked yet.

        if (!RimsName.gameObject.activeSelf)
        { UpgradesPrice[1] = 0; }


        if (!InteriorName.gameObject.activeSelf)
        { UpgradesPrice[2] = 0; }

        if (!GadgetsName.gameObject.activeSelf)
        { UpgradesPrice[3] = 0; }
    }


    public void Update()
    {

        ResetUpgrades();

        CarName.text = CarMan.Chosen[0].CarName.text ; //make the car name appear in the UI.

        bool UpgradeTextOn = (PaintName.gameObject.activeSelf || RimsName.gameObject.activeSelf || InteriorName.gameObject.activeSelf
                             || GadgetsName.gameObject.activeSelf);

        if (UpgradeTextOn) //if any 1 of the uprade texts are visible, otherwise upgrades price remains at 0.
        { TotalUpgradesPrice = (UpgradesPrice[0] + UpgradesPrice[1] + UpgradesPrice[2] + UpgradesPrice[3]); }


        Price = CarMan.Cars[NumClicks].CarPrice + TotalUpgradesPrice; //adding car price to price of all the upgrades.
        TotalPrice.text = Price.ToString(); //converting the int to string and showing it in the UI.

        //Debug.Log(CarName.text);

    }


    //on click of the next button.
    public void Next()
    {

        Reset(); //resets so that no upgrades have been added and upgrade texts are not visible.


        CarBuilder(); //clone a car from the relevant prefab.

        if (NumClicks < 5)         //to make a different car appear each time the button is clicked.
        {
            NumClicks++;
        }

        if (NumClicks == 5) //to stop NumClicks being a higher number than that in the list of cars.
        {
            NumClicks = 0;
        }

    }

    public void Reset()
    {

        w = 0;
        x = 0;
        y = 0;
        z = 0;

        TotalUpgradesPrice = 0;
        
        PaintName.gameObject.SetActive(false);
        RimsName.gameObject.SetActive(false);
        InteriorName.gameObject.SetActive(false);
        GadgetsName.gameObject.SetActive(false);


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
        

       // TotalPrice.text = CarMan.Cars[NumClicks].CarPrice.ToString(); //adds the car price to TotalPrice to display it in the UI in update.
    }

    public void CarPainter()
    {
        

        if (CarMan.Chosen[0].ClonedCar != null)//If there's already a car there, destroy it before making the new one.
        {
            Destroy(CarMan.Chosen[0].ClonedCar);
        }

        if (NumClicks == 0)
        {
            Touring = 4; //this is for when it gets to the end of the list, so that it's not trying to get object number -1 below.
        }

        if (Touring != 4)
        {
            GameObject GO = Instantiate(
        //creates a car from the prefab, -1 because it will otherwise make the next car, also uses x to choose next car in array of colours.
        CarMan.Cars[NumClicks - 1].CarPrefab[x],
        //makes it appear at the position that I want.
        CarSpawnPoint.position,
        Quaternion.identity) as GameObject;

        CarMan.Chosen[0].ClonedCar = GO;
        }

            else
        {
            GameObject GO = Instantiate(
            //creates a car from the prefab, -1 because it will otherwise make the next car, also uses x to choose next car in array of colours.
            CarMan.Cars[Touring].CarPrefab[x],
            //makes it appear at the position that I want.
            CarSpawnPoint.position,
            Quaternion.identity) as GameObject;

            CarMan.Chosen[0].ClonedCar = GO;

            Touring = 0;

        }



    }

    public void ChangePaint()
    {

        PaintName.gameObject.SetActive(true); //make the name of the upgrade appear.

        CarMan.Chosen[0].Paint = CarMan.Upgrades[0].Paint[x]; //originally for debugging purposes.
        PaintName.text = CarMan.Upgrades[0].Paint[x].text; //make the name appear in the UI.

        UpgradesPrice[0] = CarMan.Cars[NumClicks].PaintPrice[x]; //get the price of that upgrade from car manager.

        CarPainter(); //paint the car.

        x++; //equivalent of NumClicks for each upgrade button.

        if (x== 3)
        { x = 0; }

    }

    void ChangeRims()
    {

        RimsName.gameObject.SetActive(true);

        CarMan.Chosen[0].Rims = CarMan.Upgrades[0].Rims[y];
        RimsName.text = CarMan.Upgrades[0].Rims[y].text; //make the name of the upgrade appear in the UI.

        UpgradesPrice[1] = CarMan.Upgrades[0].RimsPrice[y];

        y++;

        if (y == 3)
        { y = 0; }


    }

    void ChangeInterior()
    {
        InteriorName.gameObject.SetActive(true);

        CarMan.Chosen[0].Interior = CarMan.Upgrades[0].Interior[z];
        InteriorName.text = CarMan.Upgrades[0].Interior[z].text; //make the name appear in the UI.

        UpgradesPrice[2] = CarMan.Upgrades[0].InteriorPrice[z];

        z++;

        if (z == 3)
        { z = 0; }

    }

    void ChangeGadgets()
    {

        GadgetsName.gameObject.SetActive(true);

        CarMan.Chosen[0].Gadgets = CarMan.Upgrades[0].Gadgets[w];
        GadgetsName.text = CarMan.Upgrades[0].Gadgets[w].text; //make the name appear in the UI.

        UpgradesPrice[3] = CarMan.Upgrades[0].GadgetsPrice[w];

        w++;

        if (w == 3)
        { w = 0; }


    }

}

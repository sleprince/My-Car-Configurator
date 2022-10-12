using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CarManager : MonoBehaviour { //everything public because this will all be used outside of the class definition.

    public List<CarBase> Cars = new List<CarBase>(); //the list of all the different types of car and their characteristics.
                                                     //will include string name, int price, colour etc
                                                     //using a list because it's like an array but can have different types of
                                                     //objects per element.

    public List<ChosenCar> Chosen = new List<ChosenCar>(); //the list for the currently chosen car.
    public List<UpgradeBase> Upgrades = new List<UpgradeBase>();

    ButtonHandler Buttons;

    //we use this function to find characters from their id
    public CarBase ReturnCarWithID(int ID)
    {
        CarBase retVal = null;

        for (int i = 0; i < Cars.Count; i++)
        {
            if (int.Equals(Cars[i].CarID[i], ID))
            {
                retVal = Cars[i];
                break;
            }
        }

        return retVal;
    }

    public static CarManager instance;
    public static CarManager GetInstance() //all of this is so that I can call this script from objects that do not have it attached.
    {
        return instance;
    }

    void Awake()
    {
        instance = this;


    }

    void Start()
    {
        //to make a car appear at the start.

        Buttons = ButtonHandler.GetInstance();

        Buttons.Next();
        Buttons.PreviousButton.gameObject.SetActive(false);
    }


    [System.Serializable] //so that I can use Unity editor to set these.
    public class CarBase
    {
        public int[] CarID = new int[] { 0, 1, 2, 3, 4 }; //an ID number for each of the cars, used in functions.
        public Text CarName; //text as oppose to string so that I can use it with Unity UI.
        public GameObject[] CarPrefab; //array of prefabs, in different colours. will drag and drop the prefabs of the car here.
        public AudioClip CarSound; //audio clip to play when this car is bought, might include this feature.
        public int CarPrice; //how much the car costs in £, the total price will be this plus any modifications to the car.
        public int[] PaintPrice; //how much each different colour of paint costs.
        public Text[] PaintColours; //the colours that particular car comes in.

    }

}

[System.Serializable]
public class ChosenCar //this will be the class definition to make the list with the car & its upgrades chosen by the user.
{
    public int TotalPriceNum; //how much the car costs with the upgrades, this is calculated with CalculateTotal() function.
    public Text TotalPrice;
    public Text CarName; //text of all chosen features of the car for the print screen.
    public Text PaintColour;
    public Text Rims;
    public Text Interior;
    public Text Gadgets;
    public GameObject ClonedCar; //for debugging purposes.

}

[System.Serializable]
public class UpgradeBase //the class definition for the list of possible upgrade configuration options.
{
        public Text[] Rims;
        public Text Interior;
        public Text Gadgets;
        public int[] RimsPrice;
        public int[] InteriorPrice;
        public int[] GadgetsPrice;

}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CarManager : MonoBehaviour { //everything public because this will all be used outside of the class definition.

    public List<CarBase> cars = new List<CarBase>(); //the list of all the different types of car and their characteristics.
                                                        //will include string name, int price, colour

    [System.Serializable] //so that I can use Unity editor to set these.
    public class CarBase
    {
        public Text CarName; //text as oppose to string so that I can use it with Unity UI.
        public GameObject CarPrefab; //will drag and drop the prefab of the car here.
        public AudioClip CarHorn; //audio clip to pay when this car is bought.
        public int price; //how much the car costs in £, the total price will be this plus any modifications to the car.



        public enum CarType //dropdown box of choices, could be usined with animator, might take this out.
        {
            offroad,
            racing,
            truck
        }

    }

}
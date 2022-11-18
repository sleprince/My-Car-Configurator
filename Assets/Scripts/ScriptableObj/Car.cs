using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Car", menuName = "Car")]
public class Car : ScriptableObject
{

    public string CarName; //text as oppose to string so that I can use it with Unity UI.
    public string description;
    public Sprite CarSprite;
    public int price; //how much the car costs in £, the total price will be this plus any modifications to the car.


    public void Print()
    {
        Debug.Log(CarName + ": " + description + " The car costs: " + price);
    }

}
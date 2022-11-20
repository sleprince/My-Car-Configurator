using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Car", menuName = "Car")]
public class Car : ScriptableObject
{
    public string description;
    public int HorsePower;
    public int MPG; //how much the car costs in £, the total price will be this plus any modifications to the car.


    public void Print()
    {
        Debug.Log( description + ". The car has " + HorsePower + " BHP, and goes for " + MPG + " miles per gallon." );
    }

}
using UnityEngine;
using UnityEngine.UI;

public class CarDisplay : MonoBehaviour
{

    public Car[] car;
    //public Car car;
    public Text descriptionText;
    public Text bhpText;
    public Text mpgText;
    public int ID;

    ButtonHandler buttonHandler;

    // Use this for initialization
    public void Start()
    {

        //buttonHandler = ButtonHandler.GetInstance();

        //ID = buttonHandler.NumClicks;

        ID = -1;


    }

    public void Update()
    {
        descriptionText.text = car[ID].description;
        bhpText.text = car[ID].HorsePower.ToString() + " BHP";
        mpgText.text = car[ID].MPG.ToString() + " MPG";

        //descriptionText.text = car.description;
        //bhpText.text = car.HorsePower.ToString() + " BHP";
        //mpgText.text = car.MPG.ToString() + " MPG";

        //car[ID].Print();
    }

    public static CarDisplay instance;
    public static CarDisplay GetInstance() //all of this is so that I can call this script from objects that do not have it attached.
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

}//class
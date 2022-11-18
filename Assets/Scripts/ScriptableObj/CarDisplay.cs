using UnityEngine;
using UnityEngine.UI;

public class CarDisplay : MonoBehaviour
{

    public Car car;

    public Text nameText;
    public Text descriptionText;

    public Image carImage;

    public Text priceText;


    // Use this for initialization
    void Start()
    {
        nameText.text = car.CarName;
        descriptionText.text = car.description;

        carImage.sprite = car.CarSprite;

        priceText.text = car.price.ToString();
    }

}
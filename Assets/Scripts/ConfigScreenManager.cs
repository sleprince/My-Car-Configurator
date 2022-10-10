using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfigScreenManager : MonoBehaviour
{
    public GameObject CarSpawnPoint;
    //public Button PreviousButton;
    //public Button NextButton;
    public TMP_Text TextBox;



    // Start is called before the first frame update
    void Start()
    {
        //start by getting the reference to the car manager
        //CarManager = CarManager.GetInstance();

    }


    // Update is called once per frame
    void Update()
    {
        //transform.GetComponent<TMP_Dropdown>();

        //dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });


        //bringing playerbase info into each player interface as a new playerbase.
        //plInterfaces[i].playerBase = charManager.players[i];


        //plInterfaces[i].characterBase.CharNum = null;
        //plInterfaces[i].CharNum = null;


    }



        //if the user presses space, he has selected a character
       // if (Input.GetButtonUp("A" + playerId))
       // {
            //make a reaction on the character, because why not
            //pl.createdCharacter.GetComponentInChildren<Animator>().Play("Kick");

            //play the relevant select sound
           // Completed.SoundManager.instance.RandomizeSfx(pl.SelectSound);


            //pass the character to the character manager so that we know what prefab to create in the level
            //pl.playerBase.playerPrefab =
               //charManager.returnCharacterWithID(pl.activePotrait.characterId).prefab;

            //pass the character name to the character manager so that we can use it in the level.
            //pl.playerBase.CharName =
            //    charManager.returnCharacterWithID(pl.activePotrait.characterId).CharName;

       // }

   // void HandleCarPreview(PlayerInterfaces pl)
  //  {
        //if the previews potrait we had, is not the same as the active one we have
        //that means we changed characters
  //      if (pl.previewPotrait != pl.activePotrait)
   //     {
            //if (pl.createdCharacter != null)//delete the one we have now if we do have one
            //{
            //    Destroy(pl.createdCharacter);
            //}


            //defining the half scale.
            //var HalfScale = new Vector3(.25f, .25f, .25f);

            //and create another one
           // GameObject go = Instantiate(
                //character gets made with this function
               // CharacterManager.GetInstance().returnCharacterWithID(pl.activePotrait.characterId).prefab,
                //where you could maybe change the scale
                //spawn position
                //pl.charVisPos.position,
                //Quaternion.identity) as GameObject;

            //bringing the character ID number over from the Character list
            //pl.CharNum = pl.activePotrait.characterId;
            //pl.CharName is the property we want to bring in to the level to show their name under the health bar.
            //pl.CharName = CharacterManager.GetInstance().returnCharacterWithID(pl.activePotrait.characterId).CharName;



            //pl.createdCharacter = go;
            //go.transform.localScale = HalfScale;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{

    public GameObject CarSpawnPoint;


    // On click of previous button.
    public void Previous()
    {
        
    }

    // On click of next button.
    public void Next()
    {

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
}

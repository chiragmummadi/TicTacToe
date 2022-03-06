using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boxBehaviour : MonoBehaviour
{
   public Text boxText;
   public Button box;
   public GameController gameController;

//    Function which runs on box touch and determines few things as follows:
//    1) Enables scale animation for the X/O input
//    2) Sets text according to the switch between X/O 
//    3) Makes that specific box non interactive, to make it lock
//    4) checks win condition    

   public void updateBox()
   {
       SoundScript.PlaySound("click");
       boxText.GetComponent<Animator>().enabled = true;
       boxText.text = gameController.playerInput();
       boxText.color = Color.black;
       box.interactable = false;
       gameController.checkWin();
   }
}

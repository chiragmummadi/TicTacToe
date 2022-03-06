using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Two Classes Player and PlayerColor is made to know WHOSE TURN IS IT

[System.Serializable]
public class Player
{
  public Image turnPanel;
  public Text turnText;
}
[System.Serializable]
public class PlayerColor
{
   public Color panelColor;
   public Color textColor;
}


public class GameController : MonoBehaviour
{
  public Text[] boxArray;
  private string playerSide;
  public GameObject winScreen;
  public GameObject opac;
  public Text resultTxt;
  private int totalMoves;
  public Sprite drawPic;
  public Sprite winPic;

  public GameObject resetButton;

// On start the screen orientation is set to landscape.

  private void Start() {
      Screen.orientation = ScreenOrientation.LandscapeLeft;  
 }

// If the orientation of mobile device is changed to portrait on any instance over the course of the game, It is again set to landscape.

 private void Update() {
    if (Input.deviceOrientation==DeviceOrientation.Portrait||Input.deviceOrientation==DeviceOrientation.PortraitUpsideDown) 
           {
                 Debug.Log("Portrait Mode");
                 Screen.orientation = ScreenOrientation.LandscapeLeft;

           }  
}
// Objects of the above two classes are made here.

public Player playerX;
public Player playerO;
public PlayerColor activeColor;
public PlayerColor inactiveColor;


//   Awake function to initialize few variables.

 private void Awake() {
     winScreen.SetActive(false);
     opac.SetActive(false);  
     resetButton.SetActive(false);
     playerSide = "X";
     totalMoves = 0;
     setColor(playerX, playerO);
 }

 // String method called in boxBehaviour script to return input.

  public string playerInput()
  {
      return playerSide;
  }
// Function to check win condition, called in the boxBehaviour script. 

  public void checkWin()
  {
        // Total moves incremented by 1 on every move to check for draw condition.

      totalMoves++;
 
      // Checks win condition for the three ROWS.

      if(boxArray[0].text == playerSide && boxArray[1].text == playerSide && boxArray[2].text == playerSide ) {gameOver(playerSide);}

      if(boxArray[3].text == playerSide && boxArray[4].text == playerSide && boxArray[5].text == playerSide ) {gameOver(playerSide);}
            
      if(boxArray[6].text == playerSide && boxArray[7].text == playerSide && boxArray[8].text == playerSide ) {gameOver(playerSide);}

      // Checks win condition for the three COLUMNS.

      if(boxArray[0].text == playerSide && boxArray[3].text == playerSide && boxArray[6].text == playerSide ) {gameOver(playerSide); }
            
      if(boxArray[1].text == playerSide && boxArray[4].text == playerSide && boxArray[7].text == playerSide ) {gameOver(playerSide);}
            
      if(boxArray[2].text == playerSide && boxArray[5].text == playerSide && boxArray[8].text == playerSide ) {gameOver(playerSide);}
            
      // Checks win condition for the two DIAGONALS.

      if(boxArray[0].text == playerSide && boxArray[4].text == playerSide && boxArray[8].text == playerSide ) {gameOver(playerSide);}
                  
      if(boxArray[2].text == playerSide && boxArray[4].text == playerSide && boxArray[6].text == playerSide )  {gameOver(playerSide);}
      
      checkDraw();

      switchSide();
  }

// Game over function called when a win codition is detected.
// 1) Makes all the button non interactive 
// 2) Depending upon the result gives out a win pop up, draw if the case.
// 3) Followed by image change for the two condition.

  void gameOver(string playerWin)
  {
     setBoxesInteractive(false); 
     resetButton.SetActive(true);

     if(playerWin == "draw")
     {
         SoundScript.PlaySound("draw"); 
         winScreen.GetComponent<Image>().sprite = drawPic; 
         declareResult("It's a draw!");
     } 
     else 
     {
        SoundScript.PlaySound("win"); 
        winScreen.GetComponent<Image>().sprite = winPic;
        declareResult("Player " + playerSide + " wins!!");
     }
     
  }

  // Function with ternary operatory to switch between X and O inputs.

  void switchSide()
  {
     playerSide = (playerSide == "X") ? "O" : "X";

     if(playerSide == "X")
     {
       setColor(playerX, playerO);
     }        
     else
     {
       setColor(playerO, playerX);
     }
  }

// Checks the draw condition if total moves is equal or greater than 9 moves.

  void checkDraw()
  {
        if(totalMoves >= 9)
        {
              gameOver("draw");
        }
  }

  // Declares result by poping the win screen panel and result text passed by its respective condition.

 void declareResult(string input)
 {
       opac.SetActive(true);  
       winScreen.SetActive(true);
       resultTxt.text = input;
 }

// Resets game by reseting the variables, making all the boxes interactive and setting text to empty.

  public void resetGame()
  {
        playerSide = "X";
        totalMoves = 0;
        winScreen.SetActive(false);   
        opac.SetActive(false);
        setBoxesInteractive(true);
      
      for(int i = 0 ; i < boxArray.Length; i++)
       {
         boxArray[i].text = null;
       }       
       setColor(playerX, playerO);
       resetButton.SetActive(false);

  }
    
// Function to toggle between making the buttons interactive or non interactive. 

  void setBoxesInteractive(bool isActive)
  {
             for(int i = 0 ; i < boxArray.Length; i++)
     {
         boxArray[i].GetComponentInParent<Button>().interactable = isActive;
     }  
  }

// Color of the panel and text has been set according to the active player playing the turn.

void setColor(Player activePlayer, Player inactivePlayer)
{
  activePlayer.turnPanel.color = activeColor.panelColor;
  activePlayer.turnText.color = activeColor.textColor;

  inactivePlayer.turnPanel.color = inactiveColor.panelColor;
  inactivePlayer.turnText.color = inactiveColor.textColor;
}

}

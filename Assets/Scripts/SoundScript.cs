using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{

    public static AudioClip buttonClick,YouWinSound, drawSound;
    static AudioSource audioSrc;
     
    // Start is called before the first frame update
    void Start()
    {
        buttonClick = Resources.Load<AudioClip>("click");
        YouWinSound = Resources.Load<AudioClip>("win");
        drawSound = Resources.Load<AudioClip>("draw");
        
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch(clip){
            case "click":
                audioSrc.PlayOneShot(buttonClick);
                break;

            case "win":
                audioSrc.PlayOneShot(YouWinSound);
                break;

            case "draw":
                audioSrc.PlayOneShot(drawSound);
                break;
        }
    }
}

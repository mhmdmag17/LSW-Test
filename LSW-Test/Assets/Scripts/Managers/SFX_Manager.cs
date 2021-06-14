using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Manager : MonoBehaviour
{

     private static SFX_Manager _instance;

    public static SFX_Manager Instance { get { return _instance; } }
    public AudioSource bgMusic;
    public AudioSource popSFX;
    
public AudioSource[] movementAudios;

     private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
       
    }
    // Start is called before the first frame update
    public void PlaySound(AudioSource audio){
            if(!audio.isPlaying){
                audio.Play();
            }
    }
      public void StopSound(AudioSource audio){
           
                audio.Stop();
            
    }
     public void PopSound(){
           
                popSFX.Play();
            
    }
     
}

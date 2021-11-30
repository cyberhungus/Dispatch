using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Soundmanager Handles Sounds 
public class SoundManager : MonoBehaviour
{
    //For the ring of the phone
    //Source shall be on phone object/physicalButton
    public AudioSource phoneAudioSource;
    //clip for phone ringing
    //https://freesound.org/people/acclivity/sounds/24929/
    public AudioClip phoneRing;
    //sound of someone talking
    //https://freesound.org/people/dersuperanton/sounds/435876/
    public AudioClip babble; 

    //for playerFeedback
    public AudioSource playeAudioSource;
    //confirmSound
    public AudioClip confirm;
    //deleting Node Sound
    public AudioClip delete;
    //final confirmSound
    public AudioClip finalConfirm;

    bool phoneIsRinging = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void registerPhoneAudioSource(AudioSource source)
    {
        print("phone audio source registered");
        this.phoneAudioSource = source;
    }
    public void registerPlayerAudioSource(AudioSource source)
    {
        this.playeAudioSource = source;
    }

    public void setPhoneIsRinging(bool value)
    {
        this.phoneIsRinging = value;
    }

   public void playPhoneRinging()
    {
        if(phoneAudioSource.loop == false)
        {
            phoneAudioSource.loop = true;
        }

        if (phoneAudioSource.clip != phoneRing)
        {
            phoneAudioSource.clip = phoneRing;
        }

        phoneAudioSource.Play();
    }

   public void playPhoneBabble()
    {
        phoneAudioSource.Stop();

        phoneAudioSource.PlayOneShot(babble);
    }



}

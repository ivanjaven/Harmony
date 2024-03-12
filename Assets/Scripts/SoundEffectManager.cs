using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
   [SerializeField] AudioSource musicSource;
   [SerializeField] AudioSource SFXSource;

   public AudioClip[] backgroundClips;
   public AudioClip splat;
   public AudioClip restart;


   private void Start()
   {
        int randomNumber = new System.Random().Next(0, 6);
        musicSource.clip = backgroundClips[randomNumber];
        musicSource.Play();
   }

   public void PlaySFX(AudioClip clip){
    SFXSource.PlayOneShot(clip);
   }
}

    

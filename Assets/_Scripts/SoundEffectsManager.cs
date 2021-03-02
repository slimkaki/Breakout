using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour {

    // Este código foi retirado do seguinte tutorial:
    // https://www.youtube.com/watch?v=8pFlnyfRfRc

    public static AudioClip hit2, hit1;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start() {
        hit1 = Resources.Load<AudioClip> ("hit");
        hit2 = Resources.Load<AudioClip> ("hit2");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public static void PlaySound(string clip) {
        switch(clip) {
            case "hit2":
                audioSrc.PlayOneShot(hit2);
                break;
            case "hit":
                audioSrc.PlayOneShot(hit1);
                break;
        }
        // audioSrc.PlayOneShot(ballFxSound);
    }
}

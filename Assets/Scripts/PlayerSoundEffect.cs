using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffect : MonoBehaviour
{
    CharacterController player;
    AudioSource footStepsEff;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        footStepsEff = GetComponent<AudioSource>();
        footStepsEff.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isGrounded && (footStepsEff.enabled == false))
        {
            footStepsEff.enabled = true;
            footStepsEff.volume = Random.Range(0.7f, 1.0f);
            footStepsEff.pitch = Random.Range(0.7f, 1.2f);

        }
        else if(player.isGrounded == false)
        {
            footStepsEff.enabled = false;

        }
    }
}

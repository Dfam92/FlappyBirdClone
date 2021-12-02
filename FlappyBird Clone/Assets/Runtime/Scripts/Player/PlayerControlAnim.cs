using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlAnim : MonoBehaviour
{
    [SerializeField]private Animator playerAnim;
    
    public void FlapWings()
    {
        playerAnim.SetBool("isFlying", true);
    }

    public void StopFlapWing()
    {
        playerAnim.SetBool("isFlying", false);
    }
}

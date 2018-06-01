using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class HoleManager : MonoBehaviour {

    public Transform nextHole;
    public Transform player;
    
    public void goesThrough()
    {
        player.position = new Vector2 (nextHole.position.x,nextHole.position.y);
        DelayBeforeEnteringAgain(.5f);
    }

    public static void DelayBeforeEnteringAgain(float seconds)
    {
        DateTime dt = DateTime.Now + TimeSpan.FromSeconds(seconds);

        do { } while (DateTime.Now < dt);
    }

}

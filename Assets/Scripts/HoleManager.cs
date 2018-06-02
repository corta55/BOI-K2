using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class HoleManager : MonoBehaviour {

    public float delayHole;
    public Transform nextHole;
    public Transform player;
    
    public void goesThrough()
    {
        player.position = new Vector2 (nextHole.position.x,nextHole.position.y);
        DelayOfHole(delayHole);
    }

    public static void DelayOfHole(float seconds)
    {
        DateTime dt = DateTime.Now + TimeSpan.FromSeconds(seconds);

        do { } while (DateTime.Now < dt);
    }

}

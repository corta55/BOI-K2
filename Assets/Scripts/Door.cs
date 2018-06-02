using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable{

    [SerializeField] Transform tujuanPintu;
    Transform player;
    [SerializeField] private bool haveRequire;
    public bool grantedAccess;

	public override void interact()
    {
        GameVariables.isInteract = true;
        player = GameVariables.activePlayer.transform;
        if (haveRequire && !grantedAccess) return;
        StartCoroutine(delayMasuk());
    }

    IEnumerator delayMasuk()
    {
        //For animation in Door
        yield return new WaitForSeconds(1f);
        player.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        player.position = tujuanPintu.position;
        yield return new WaitForSeconds(1f);
        player.GetComponent<SpriteRenderer>().enabled = true;
        //For animation out Door
        yield return new WaitForSeconds(1f);
        GameVariables.isInteract = false;
    }
}

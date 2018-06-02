using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaMovement : MonoBehaviour {

    [SerializeField] private string followingPlayer; 
    public float speedFollowing = 5f;

    private Vector2 posCam;
    Vector3 newPosition;

    private bool freezeCam;

    #region Bounding Cam

        #region SizeCam
        public float right;
        public float left;
        public float up;
        public float down;
        #endregion

    [SerializeField] private Transform rightBound;
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform upBound;
    [SerializeField] private Transform downBound;

    public void setBound(Transform rightBound, Transform leftBound, Transform upBound, Transform downBound)
    {
        this.rightBound = rightBound;
        this.leftBound = leftBound;
        this.upBound = upBound;
        this.downBound = downBound;
    }

    #endregion

    void FixedUpdate()
    {
        followingPlayer = GameVariables.followingPlayer;
        posCam = transform.position;
        if (GameObject.FindGameObjectWithTag(followingPlayer)) 
        {
            newPosition = GameObject.FindGameObjectWithTag(followingPlayer).transform.position;
            newPosition.z = -10;

            if (GameVariables.boundingCam)//
            {
                if (posCam.x + right >= rightBound.position.x && newPosition.x + right >= rightBound.position.x)
                {
                    freezeCam = true;
                }

                if (posCam.x - left <= leftBound.position.x && newPosition.x - left <= leftBound.position.x)
                {
                    freezeCam = true;
                }

                if (posCam.y + up >= upBound.position.y && newPosition.y + up >= upBound.position.y)
                {
                    freezeCam = true;
                }

                if (posCam.y - down <= downBound.position.y && newPosition.y - down <= downBound.position.y)
                {
                    freezeCam = true;
                }
            }

            if (newPosition.x + right < rightBound.position.x && newPosition.x - left > leftBound.position.x && newPosition.y + up < upBound.position.y && newPosition.y - down > downBound.position.y)
            {
                freezeCam = false;
            }

            if ((posCam.x + right != rightBound.position.x || posCam.x - left != leftBound.position.x || posCam.y + up != upBound.position.y || posCam.y - down != downBound.position.y) && !freezeCam)
            {
                transform.position = Vector3.Lerp(posCam, newPosition, speedFollowing * Time.deltaTime);
            }
        }

    }
}

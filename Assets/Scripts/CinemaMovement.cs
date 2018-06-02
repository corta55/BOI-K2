using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaMovement : MonoBehaviour {

    [SerializeField] private string followingPlayer; 
    public float speedFollowing = 5f;

    private Vector2 posCam;
    Vector3 newPosition;

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

    void Update()
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
                    posCam.x = rightBound.position.x - right;
                    newPosition.x = rightBound.position.x - right;
                }

                if (posCam.x - left <= leftBound.position.x && newPosition.x - left <= leftBound.position.x)
                {
                    posCam.x = leftBound.position.x + left;
                    newPosition.x = leftBound.position.x + left;
                }

                if (posCam.y + up >= upBound.position.y && newPosition.y + up >= upBound.position.y)
                {
                    posCam.y = upBound.position.y - up;
                    newPosition.y = upBound.position.y - up;
                }

                if (posCam.y - down <= downBound.position.y && newPosition.y - down <= downBound.position.y)
                {
                    posCam.y = downBound.position.y + down;
                    newPosition.y = downBound.position.y + down;
                }
            }

            if (posCam.x + right != rightBound.position.x || posCam.x - left != leftBound.position.x || posCam.y + up != upBound.position.y || posCam.y - down != downBound.position.y)
            {
                transform.position = Vector3.Lerp(posCam, newPosition, speedFollowing * Time.deltaTime);
            }
        }

    }
}

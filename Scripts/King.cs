using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    // Start is called before the first frame update
    void Start()
    {
        setState();
        Debug.Log(this.initPos);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isDead == true){
            gc.gameOn = false;
        }
    }

    public override void showLegalMoves(){
        if(currPosX >= 1 && currPosY >= 1){
            moveDiagonally(currPosX+2, currPosY+2, currPosX-1, currPosY-1);
            moveHorizontally(currPosY+2, currPosY-1);
            moveVertically(currPosX+2, currPosX-1);
        }
        else if(currPosX < 1){
            moveDiagonally(currPosX+2, currPosY+2, 0, currPosY-1);
            moveHorizontally(currPosY+2, currPosY-1);
            moveVertically(currPosX+2, 0);
        }
        else if(currPosY < 1){
            moveDiagonally(currPosX+2, currPosY+2, currPosX-1, 0);
            moveHorizontally(currPosY+2, 0);
            moveVertically(currPosX+2, currPosX-1);
        }
    }
}

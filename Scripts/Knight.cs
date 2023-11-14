using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    // Start is called before the first frame update
    void Start()
    {
        setState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void showLegalMoves(){
        
        //GIU
        if(currPosX < gc.getBoardLength(0)-2 && currPosY < gc.getBoardLength(1)-1){
            if(isPosEmpty(currPosX+2, currPosY+1)|| hasEatablePiece(currPosX+2, currPosY+1)){
                gc.getBoardPos(currPosX+2, currPosY+1).evidencePos();
            }
        }

        if(currPosX < gc.getBoardLength(0)-2 && currPosY >= 1){
            if(isPosEmpty(currPosX+2, currPosY-1)|| hasEatablePiece(currPosX+2, currPosY-1)){
                gc.getBoardPos(currPosX+2, currPosY-1).evidencePos();
            }
        }

        //SU
        if(currPosX >= 2 && currPosY >= 1){
            if(isPosEmpty(currPosX-2, currPosY-1)|| hasEatablePiece(currPosX-2, currPosY-1)){
                gc.getBoardPos(currPosX-2, currPosY-1).evidencePos();
            }
        }

        if(currPosX >= 2 && currPosY < gc.getBoardLength(1)-1){
            if(isPosEmpty(currPosX-2, currPosY+1)|| hasEatablePiece(currPosX-2, currPosY+1)){
                gc.getBoardPos(currPosX-2, currPosY+1).evidencePos();
            }
        }

        //DESTRA
        if(currPosX >= 1 && currPosY < gc.getBoardLength(1)-2){
            if(isPosEmpty(currPosX-1, currPosY+2)|| hasEatablePiece(currPosX-1, currPosY+2)){
                gc.getBoardPos(currPosX-1, currPosY+2).evidencePos();
            }
        }

        if(currPosX < gc.getBoardLength(0)-1 && currPosY < gc.getBoardLength(1)-2){
            if(isPosEmpty(currPosX+1, currPosY+2)|| hasEatablePiece(currPosX+1, currPosY+2)){
                gc.getBoardPos(currPosX+1, currPosY+2).evidencePos();
            }
        }

        //SINISTRA
        if(currPosX < gc.getBoardLength(0)-1 && currPosY >= 2){
            if(isPosEmpty(currPosX+1, currPosY-2)|| hasEatablePiece(currPosX+1, currPosY-2)){
                gc.getBoardPos(currPosX+1, currPosY-2).evidencePos();
            }
        }

        if(currPosX >= 1 && currPosY >= 2){
            if(isPosEmpty(currPosX-1, currPosY-2)|| hasEatablePiece(currPosX-1, currPosY-2)){
                gc.getBoardPos(currPosX-1, currPosY-2).evidencePos();
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{   
    private GameObject newqueen;

    // Start is called before the first frame update
    void Start()
    {
        setState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool hasReachedBorder(){
        bool borderReached;

        if((this.tag == "BLACK_PIECE" && this.currPosX == 7) || (this.tag == "WHITE_PIECE" && this.currPosX == 0)){
            borderReached = true;
        }
        else{
            borderReached = false;
        }

        return borderReached;
    }

    public override void showLegalMoves(){

        if(this.tag == "WHITE_PIECE"){

            if(currPosX > 0){
                if (isPosEmpty(currPosX-1, currPosY)){
                    gc.getBoardPos(currPosX-1, currPosY).evidencePos();
                }
            
            
                if(currPosX > 0 && currPosY > 1){
                    if(!isPosEmpty(currPosX-1, currPosY-1)&& hasEatablePiece(currPosX-1, currPosY-1)){
                        gc.getBoardPos(currPosX-1, currPosY-1).evidencePos();
                    }
                }

                if(currPosX > 0 && currPosY < gc.getBoardLength(1)-1){
                    if(!isPosEmpty(currPosX-1, currPosY+1) && hasEatablePiece(currPosX-1, currPosY+1)){
                        gc.getBoardPos(currPosX-1, currPosY+1).evidencePos();
                    }
                }
            }
        }
        else if(this.tag == "BLACK_PIECE"){

            if ((currPosX +1) < gc.getBoardLength(0)){
                if(isPosEmpty(currPosX+1, currPosY)){
                    gc.getBoardPos(currPosX+1, currPosY).evidencePos();
                }
            
                if(currPosX < gc.getBoardLength(0)-1 && currPosY > 1){
                    if(!isPosEmpty(currPosX+1, currPosY-1) && hasEatablePiece(currPosX+1, currPosY-1)){
                        gc.getBoardPos(currPosX+1, currPosY-1).evidencePos();
                    }
                }
                if(currPosX < gc.getBoardLength(0)-1 && currPosY < gc.getBoardLength(1)-1){
                    if(!isPosEmpty(currPosX+1, currPosY+1) && hasEatablePiece(currPosX+1, currPosY+1)){
                        gc.getBoardPos(currPosX+1, currPosY+1).evidencePos();
                    }
                }
            }
        }
    }

    public void morfIntoQueen(){
        newqueen = Instantiate(gc.getQueen(this.tag));
        
        
        newqueen.GetComponent<Queen>().setInitAxis(this.currPosX, this.currPosY);
        newqueen.GetComponent<Queen>().setState();
        this.checkPos.setPiece(newqueen.GetComponent<Queen>());
        Destroy(this.gameObject);
    }
} //class

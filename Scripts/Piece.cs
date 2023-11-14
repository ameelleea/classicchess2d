using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Piece : MonoBehaviour
{   
    [SerializeField]
    protected BoardPos checkPos;

    [SerializeField]
    protected BoardPos initPos;

    [SerializeField]
    protected int currPosX, currPosY;

    [SerializeField]
    protected GameController gc;

    [SerializeField]
    protected SpriteRenderer sr;

    [SerializeField]
    protected CapsuleCollider2D coll;

    protected bool isDead;

    [SerializeField]
    protected bool selected;

    // Start is called before the first frame update
    void Start()
    {   
                
    }

    // Update is called once per frame
    void Update()
    {

    }

    //GETTERS
    public BoardPos getPos(){
        return this.checkPos;
    }

    public BoardPos getInitPos(){
        return this.initPos;
    }

    public int getPosX(){
        return this.currPosX;
    }

    public int getPosY(){
        return this.currPosY;
    }

    public GameController getController(){
        return this.gc;
    }

    public bool hasDied(){
        return this.isDead;
    }

    public bool isSelected(){
        return this.selected;
    }

    //SETTERS
    public void setState(){
        this.isDead = false;
        this.selected = false;
        this.sr = GetComponent<SpriteRenderer>();
        this.gc = GameObject.FindWithTag("GAME_CONTROLLER").GetComponent<GameController>();
        setInitPos(currPosX, currPosY);
        this.checkPos = this.initPos;
        this.coll = GetComponent<CapsuleCollider2D>();
        this.transform.position = initPos.transform.position;
    }

    public void killPiece(){
        this.isDead = true;
        Destroy(gameObject);
        gc.getUICon().showEatenPieces(this.sr.sprite, this.tag);

        if(this.gameObject.GetComponent<King>() != null){
            gc.gameOn = false;
            Debug.Log(this.tag);
            if(this.tag == "WHITE_PIECE"){
                gc.winner = "BLACK_PIECE";
            }
            else{
                gc.winner = "WHITE_PIECE";
            }
        }
    }

    public void toggleSelection(){
        if(this.selected == true){
            this.selected = false;
        }
        else{
            this.selected = true;
        }
    }

    public void setInitAxis(int i, int j){
        this.currPosX = i;
        this.currPosY = j;
    }

    public void setInitPos(int i, int j){
        this.initPos = gc.getBoardPos(i, j);
    }

    public void setPosAxis(){
        this.currPosX = checkPos.getIndexX();
        this.currPosY = checkPos.getIndexY();
    }

    public void toggleCollider(){
        
        if (coll.enabled == true){
            coll.enabled = false;
        }
        else{
            coll.enabled = true;
        }
    }

    //GAMEPLAY METHODS
    public void hasBeenClicked(){
        if(!selected){
            this.toggleSelection();
            this.showLegalMoves();
        }
        else if(selected){
            this.hideLegalMoves();
            this.toggleSelection();
            
        }

    }

    public void movePiece(BoardPos newPos){
        if(newPos.getPiece() != null){
            newPos.getPiece().killPiece();
        }

        this.checkPos.removePiece();
        Debug.Log(this);
        newPos.setPiece(this);
        this.checkPos = newPos;
        this.setPosAxis();
        this.hideLegalMoves();
        this.selected = false;

        this.transform.position = checkPos.transform.position;
        
    }

    public void moveHorizontally(int posOffset, int negOffset){
        for(int j = currPosY+1; j < posOffset && j < gc.getBoardLength(1); j++){
            if (isPosEmpty(currPosX, j)){
                gc.getBoardPos(currPosX, j).evidencePos();
            }
            else if(hasEatablePiece(currPosX, j)){
                gc.getBoardPos(currPosX, j).evidencePos();
                j = posOffset;
            }
            else{
                j = posOffset;
            }
        }
    
        for(int j = currPosY-1; j >= negOffset && j >= 0; j--){
            if (isPosEmpty(currPosX, j)){
                gc.getBoardPos(currPosX, j).evidencePos();
            }
            else if(hasEatablePiece(currPosX, j)){
                gc.getBoardPos(currPosX, j).evidencePos();
                j = negOffset - 1;
            }
            else{
                j = negOffset - 1;
            }
        }
    }

    public void moveVertically(int posOffset, int negOffset){
        for(int j = currPosX+1; j < posOffset && j < gc.getBoardLength(0); j++){
            if (isPosEmpty(j, currPosY)){
                gc.getBoardPos(j, currPosY).evidencePos();
            }
            else if(hasEatablePiece(j, currPosY)){
                gc.getBoardPos(j, currPosY).evidencePos();
                j = posOffset;
            }
            else{
                j = posOffset;
            }
        }
    
        for(int j = currPosX-1; j >= negOffset && j >= 0; j--){
            if (isPosEmpty(j, currPosY)){
                gc.getBoardPos(j, currPosY).evidencePos();
            }
            else if(hasEatablePiece(j, currPosY)){
                gc.getBoardPos(j, currPosY).evidencePos();
                j = negOffset - 1;
            }
            else{
                j = negOffset - 1;
            }
        }
    }

    public void moveDiagonally(int posOffsetX, int posOffsetY, int negOffsetX, int negOffsetY){
        for(int i = currPosX+1, j = currPosY+1; i < posOffsetX && j < posOffsetY && i < gc.getBoardLength(0) && j < gc.getBoardLength(1); i++, j++){
            if (isPosEmpty(i, j)){
                gc.getBoardPos(i, j).evidencePos();
            }
            else if(hasEatablePiece(i, j)){
                gc.getBoardPos(i, j).evidencePos();
                i = posOffsetX;
                j = posOffsetY;
            }
            else{
                i = posOffsetX;
                j = posOffsetY;
            }
        }   
    
        for(int i = currPosX-1, j = currPosY-1; i >= negOffsetX && j >= negOffsetY && i >= 0 && j >= 0; i--, j--){
            if (isPosEmpty(i, j)){
                gc.getBoardPos(i, j).evidencePos();
            }
            else if(hasEatablePiece(i, j)){
                gc.getBoardPos(i, j).evidencePos();
                i = negOffsetX - 1;
                j = negOffsetY - 1;
            }
            else{
                i = negOffsetX - 1;
                j = negOffsetY - 1;
            }
        }
    
        for(int i = currPosX-1, j = currPosY+1; i >= negOffsetX && j < posOffsetY && i >= 0 && j < gc.getBoardLength(1); i--, j++){
            if (isPosEmpty(i, j)){
                gc.getBoardPos(i, j).evidencePos();
            }
            else if(hasEatablePiece(i, j)){
                gc.getBoardPos(i, j).evidencePos();
                i = negOffsetX - 1;
                j = posOffsetY;
            }
            else{
                i = negOffsetX - 1;
                j = posOffsetY;
            }
        }
    
        for(int i = currPosX+1, j = currPosY-1; i < posOffsetX && j >= negOffsetY && i < gc.getBoardLength(0) && j >= 0; i++, j--){
            if (isPosEmpty(i, j)){
                gc.getBoardPos(i, j).evidencePos();
            }
            else if(hasEatablePiece(i, j)){
                gc.getBoardPos(i, j).evidencePos();
                i = posOffsetX;
                j = negOffsetY - 1;
            }
            else{
                i = posOffsetX;
                j = negOffsetY - 1;
            }
        }
    }

    public bool isPosEmpty(int i, int j){
        return (gc.getBoardPos(i, j).getPiece() == null); 
    }

    public bool hasEatablePiece(int i, int j){
        return (gc.getBoardPos(i, j).getPiece().tag != this.tag);
    }

    public abstract void showLegalMoves();

    public void hideLegalMoves(){
        for(int i= 0; i < gc.getBoardLength(0); i++){
            for(int j = 0; j < gc.getBoardLength(1); j++)
            {
                if(gc.getBoardPos(i, j).sr.color == BoardPos.selectionColor){
                    gc.getBoardPos(i, j).unevicencePos();
                }
            }
        }
    }
}

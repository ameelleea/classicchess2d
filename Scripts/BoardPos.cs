using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPos : MonoBehaviour
{   
    public static Color32 selectionColor = new Color32(255, 129, 29, 255);

    [SerializeField]
    private int indexX, indexY;

    [SerializeField]
    private Piece piece;

    [SerializeField]
    public SpriteRenderer sr;

    [SerializeField]
    private GameController gc;

    [SerializeField]
    private BoxCollider2D coll;

    private bool selected;

    private bool isMoveLegal;
    
    // Start is called before the first frame update
    void Start()
    {
        isMoveLegal = false;
        coll = GetComponent<BoxCollider2D>();
        coll.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //GETTERS
    public int getIndexX(){
        return this.indexX;
    }

    public int getIndexY(){
        return this.indexY;
    }

    public bool moveLegal(){
        return this.isMoveLegal;
    }

    public Piece getPiece(){
        return this.piece;
    }


    //SETTERS
    public void setPiece(Piece piece){
        this.piece = piece;
    }

    public void removePiece(){
        this.piece = null;
    }
    
    //GAMEPLAY METHODS
    public void evidencePos(){
        this.sr.color = new Color32(255, 129, 29, 255);
        this.isMoveLegal = true;
        this.toggleCollider();
        if(this.piece != null && this.piece.tag != gc.getSelectedPiece().tag){
            this.piece.toggleCollider();
        }
    }

    public void unevicencePos(){
        if(this.tag == "BLACK_CHECK"){
            this.sr.color = new Color32(155, 122, 96, 255);
        }
        else if(this.tag == "WHITE_CHECK"){
            this.sr.color = new Color32(244, 235, 214, 255);
        }
        this.toggleCollider();
        if(this.piece != null && this.piece.tag != gc.getSelectedPiece().tag){
            this.piece.toggleCollider();
        }
    }

    public void toggleCollider(){
        
        if (coll.enabled == true){
            coll.enabled = false;
        }
        else{
            coll.enabled = true;
        }
    }
}

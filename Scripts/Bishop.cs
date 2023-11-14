using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
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
        moveDiagonally(gc.getBoardLength(0), gc.getBoardLength(1), 0, 0);
    }
}

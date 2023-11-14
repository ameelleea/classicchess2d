using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
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
        moveHorizontally(gc.getBoardLength(0), 0);
        moveVertically(gc.getBoardLength(1), 0);
    }
}
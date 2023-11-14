using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField]
    private string playerName;
    [SerializeField]
    private string color;
    private string movablePieces;
    
    //[SerializeField]
    //private bool hasLost;

    [SerializeField]
    private bool isPlaying;

    void Awake()
    {
        //hasLost = false;

        if(this.color == "white")
        {
            isPlaying = true;
            movablePieces = "WHITE_PIECE";
            this.playerName = "White";
        }
        else
        {
            isPlaying = false;
            movablePieces = "BLACK_PIECE";
            this.playerName = "Black";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //GETTERS
    public string getColor(){
        return this.color;
    }

    public string getMovablePieces(){
        return this.movablePieces;
    }

    public bool Playing(){
        return this.isPlaying;
    }

    public string getPlayerName(){
        return this.playerName;
    }

    //SETTERS
    public void setPlayingState(bool state){
        this.isPlaying = state;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{   
    [SerializeField]
    private Text whiteplayername;
    [SerializeField]
    private Text blackplayername;
    [SerializeField]
    private Text victorytext, victorymessage;

    [SerializeField]
    private GameController gc;

    [SerializeField]
    private Player whiteplayer;
    [SerializeField]
    private Player blackplayer;

    [SerializeField]
    private Image[] whitepiecesicons = new Image[16];
    [SerializeField]
    private Image[] blackpiecesicons = new Image[16];

    void Awake()
    {
        this.victorytext.enabled = this.victorymessage.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        whiteplayername.text = gc.getWhitePlayer().getPlayerName();
        blackplayername.text = gc.getBlackPlayer().getPlayerName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showEatenPieces(Sprite sprite, string tag){
        bool found = false;

        if(tag == "WHITE_PIECE"){
            for(int i = 0; i < whitepiecesicons.GetLength(0) && !found; i++){
                if(whitepiecesicons[i].sprite == sprite && whitepiecesicons[i].enabled == false){
                    whitepiecesicons[i].enabled = true;
                    found = true;
                }
            }
        }
        else if(tag == "BLACK_PIECE"){
            for(int i = 0; i < blackpiecesicons.GetLength(0) && !found; i++){
                if(blackpiecesicons[i].sprite == sprite && blackpiecesicons[i].enabled == false){
                    blackpiecesicons[i].enabled = true;
                    found = true;
                }
            }
        }
    }

    public void highlightName(){
        if(gc.getCurrentPlayer() == whiteplayer)
        {
            whiteplayername.color = new Color32(244, 235, 214, 255);
            blackplayername.color = new Color32(123, 73, 33, 255);
        }
        else
        {
            blackplayername.color = new Color32(244, 235, 214, 255);
            whiteplayername.color = new Color32(123, 73, 33, 255);
        }
    }

    public void showWinner(){
        string winnerName = (gc.winner == "WHITE_PIECE"? "Bianco" : "Nero");

        this.victorytext.enabled = this.victorymessage.enabled = true;
        this.victorytext.text = (winnerName + " Vince!\n");
        Debug.Log("Il vincitore è:" + winnerName);
    }
}

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

    private int blackslots = 0;
    private int whiteslots = 0;


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

        if(tag == "WHITE_PIECE"){
            GameObject.Find("WhiteSlot (" + whiteslots.ToString() + ")").GetComponent<Image>().color = Color.white;
            GameObject.Find("WhiteSlot (" + whiteslots.ToString() + ")").GetComponent<Image>().sprite = sprite;
            whiteslots++;
            Debug.Log(whiteslots);
        }
        else if(tag == "BLACK_PIECE"){
            GameObject.Find("BlackSlot (" + blackslots.ToString() + ")").GetComponent<Image>().color = Color.white;
            GameObject.Find("BlackSlot (" + blackslots.ToString() + ")").GetComponent<Image>().sprite = sprite;
            blackslots++;
            Debug.Log(blackslots);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private UIController ui;

    private BoardPos[,] board = new BoardPos[8,8];

    [SerializeField]
    private Player whiteplayer, blackplayer;
    [SerializeField]
    private Player currentPlayer;
    
    [SerializeField]
    private GameObject chess_queen_white, chess_queen_black;

    [SerializeField]
    private GameObject selectedPiece;

    [SerializeField]
    private GameObject selectedPos;

    public bool gameOn;

    public string winner;

    void Awake(){

        for(int i =0, j = 0; j < this.board.GetLength(0); j++){
            for(int k = 0; k < this.board.GetLength(1); k++){
                this.board[j, k] = GameObject.Find("Square (" + i.ToString() + ")").GetComponent<BoardPos>();
                i++;
            }
        }

        currentPlayer = whiteplayer;        
    }

    // Start is called before the first frame update
    void Start()
    {
        ui.highlightName();
        this.gameOn = true;
    }

    // Update is called once per frame
    void Update()
    {   if(gameOn){
            if (Input.GetMouseButtonDown(0)) {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider != null){
                    //Debug.Log(hit.collider.gameObject.name);

                    if(hit.collider.gameObject.tag == currentPlayer.getMovablePieces()){
                    //if(hit.collider.gameObject.tag == "WHITE_PIECE" || hit.collider.gameObject.tag == "BLACK_PIECE"){
                        if(this.selectedPiece != null){
                            this.selectedPiece.GetComponent<Piece>().toggleSelection();
                            this.selectedPiece.GetComponent<Piece>().hideLegalMoves();
                        }
                        this.selectedPiece = hit.collider.gameObject;

                        selectedPiece.GetComponent<Piece>().hasBeenClicked();
                    }
                    else if(hit.collider.gameObject.tag == "BLACK_CHECK" || hit.collider.gameObject.tag == "WHITE_CHECK"){
                        this.selectedPos = hit.collider.gameObject;

                        if(selectedPos.GetComponent<BoardPos>().moveLegal()){
                            selectedPiece.GetComponent<Piece>().movePiece(selectedPos.GetComponent<BoardPos>());
                            if(selectedPiece.GetComponent<Pawn>() != null){
                                if(selectedPiece.GetComponent<Pawn>().hasReachedBorder())
                                {
                                    selectedPiece.GetComponent<Pawn>().morfIntoQueen();
                                }
                            }
                            changeTurn();
                        }
                    }
                }
            }
        }
        else{
            this.endGame();
        }
    }

    void LateUpdate()
    {
        
    }

    //GETTERS
    public Player getWhitePlayer(){
        return this.whiteplayer;
    }
    public Player getBlackPlayer(){
        return this.blackplayer;
    }

    public BoardPos getBoardPos(int i, int j){
        return this.board[i, j];
    }

    public int getBoardLength(int i){
        return this.board.GetLength(i);
    }

    public Piece getSelectedPiece(){
        return this.selectedPiece.GetComponent<Piece>();
    }

    public GameObject getQueen(string color){
        GameObject queen = null;

        if(color == "WHITE_PIECE"){
            queen = this.chess_queen_white;
        }
        else if(color == "BLACK_PIECE"){
            queen = chess_queen_black;
        }

        return queen;
    }

    public Player getCurrentPlayer(){
        return this.currentPlayer;
    }

    public UIController getUICon(){
        return this.ui;
    }

    //SETTERS
    public void setSelectedPiece(Piece piece){
        this.selectedPiece = piece.gameObject;
    }

    //GAMEPLAY
    public void changeTurn(){
        if(this.currentPlayer == whiteplayer){
            this.currentPlayer.setPlayingState(false);
            this.currentPlayer = blackplayer;
            
        }
        else{
            this.currentPlayer.setPlayingState(false);
            this.currentPlayer = whiteplayer;
        }

        this.currentPlayer.setPlayingState(true);
        ui.highlightName();
        this.selectedPiece = null;
    }

    public void endGame(){
       this.ui.showWinner();
       this.enabled = false;
    }
}

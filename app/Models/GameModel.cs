using System.ComponentModel.DataAnnotations;

namespace Game.Models
{

    public static class GameParameters
    {
        public const int FieldSize = 12;
    }

    public class Field
    {
        public Piece[,] Pieces {get;} = new Piece[GameParameters.FieldSize, GameParameters.FieldSize];

        public Field()
        {

        }

        public void addPiece(Piece piece)
        {
            Pieces[piece.Y,piece.X] = piece;
        }
    }

    public class Piece
    {
        [Range(0,GameParameters.FieldSize-1, ErrorMessage="正しい数字を入力してください")]
        public int X {get;}
        [Range(0,GameParameters.FieldSize-1, ErrorMessage="正しい数字を入力してください")]
        public int Y {get;}

        public int ColorNum {get;}

        public string Color {
            get {
                if(this.ColorNum == -1) {
                    return "white";
                }
                if(this.ColorNum == 1) {
                    return "black";
                }
                return "";
            }
        }
        protected Piece() {}

        public Piece(int x, int y, int colorNum=0)
        {
            this.X = x;
            this.Y = y;
            this.ColorNum = colorNum;
        }

        public Piece flip()
        {
            return new Piece(X, Y, -ColorNum);
        }
    }
}
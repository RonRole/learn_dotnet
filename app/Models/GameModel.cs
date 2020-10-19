using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Game.Models
{

    public static class GameParameters
    {
        public const int FIELD_SIZE = 12;
    }

    public class Field
    {
        public List<List<Piece>> Pieces{get;set;}

        public Field()
        {
            var innerList = new List<Piece>(new Piece[GameParameters.FIELD_SIZE]);
            Pieces = new List<List<Piece>>(Enumerable.Repeat(innerList, GameParameters.FIELD_SIZE));
        }

        public void AddPiece(Piece piece)
        {
            Pieces[piece.Y][piece.X] = piece;
        }
    }

    public class Piece
    {
        [Range(0,GameParameters.FIELD_SIZE-1, ErrorMessage="正しい数字を入力してください")]
        public int X {get;set;}
        [Range(0,GameParameters.FIELD_SIZE-1, ErrorMessage="正しい数字を入力してください")]
        public int Y {get;set;}

        public int ColorNum {get;set;}

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

        public Piece Flip()
        {
            return new Piece(X, Y, -ColorNum);
        }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Game.Models
{
    public static class GameParameters
    {
        public const int FIELD_SIZE = 8;
    }

    public class Field
    {
        public List<List<Piece>> Pieces{get;set;}
        public delegate void FlipPieces(List<List<Piece>> previousPieces, Piece newPiece);
        public static Field Initial()
        {
            var initialField = new Field();
            var initialPieces = new List<Piece> {
                new Piece(3,3,1), 
                new Piece(4,4,1), 
                new Piece(3,4,-1), 
                new Piece(4,3,-1)
            };
            foreach(var piece in initialPieces)
            {
                initialField.AddPiece(piece);
            }
            return initialField;
        }

        private Field()
        {
            Pieces = new List<List<Piece>>();
            foreach(var time in Enumerable.Range(0, GameParameters.FIELD_SIZE))
            {
                Pieces.Add(new List<Piece>(new Piece[GameParameters.FIELD_SIZE]));
            }
        }

        public void AddPiece(Piece piece)
        {
            FlipPieces flipPieces = new UpSideFlipper();
            flipPieces += new UpRightSideFlipper();
        }

        private int closestLeftIndex(Piece piece)=>
            Enumerable.Range(0,Math.Max(0, piece.X))
                        .Where(i=>Pieces[piece.Y][i]?.ColorNum == piece.ColorNum)
                        .LastOrDefault();
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

        public void Flip()
        {
            this.ColorNum = this.ColorNum*-1;
        }
    }
}
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

        public Field()
        {
            Pieces = new List<List<Piece>>();
            foreach(var time in Enumerable.Range(0, GameParameters.FIELD_SIZE))
            {
                Pieces.Add(Enumerable.Repeat(0, GameParameters.FIELD_SIZE).Select(i=>new Piece(0)).ToList());
            }
            AddPiece(3,3,1);
            AddPiece(4,4,1);
            AddPiece(3,4,-1);
            AddPiece(4,3,-1);
        }

        public void AddPiece(int row = 0, int col = 0, int colorNum = 0)
        {
            Pieces[row][col].Colored(colorNum);
        }

        public void FlipPiece(int row, int col, int colorNum)
        {
            //左側

        }

        private bool leftSideSetable(int row, int col, int colorNum)
        {
            if(col == 0)
            {
                return false;
            }
        } 
    }

    public class Piece
    {
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

        public Piece(int colorNum=0)
        {
            this.ColorNum = colorNum;
        }

        public void Colored(int colorNum=0)
        {
            if(this.ColorNum == 0)
            {
                this.ColorNum = colorNum;
            }
        }
        public void Flip()
        {
            this.ColorNum = this.ColorNum*-1;
        }
        public bool SameColorTo(Piece piece)
        {
            return this.ColorNum == piece.ColorNum;
        }
    }
}
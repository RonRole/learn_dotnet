using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Game.Models
{
    public interface IFlipper
    {
        bool Setable(int row, int col, int colorNum);
        void Flip(int row, int col, int colorNum);
    }

    public class LeftSideFlipper : IFlipper
    {
        List<List<Piece>> Pieces;
        public LeftSideFlipper(List<List<Piece>> pieces)
        {
            this.Pieces = pieces;
        }

        public bool Setable(int row, int col, int colorNum)
        {
            var rowPieces = Pieces[row];
            var closestPiece = this.ClosestPiece(row, col, colorNum);
            if(rowPieces.IndexOf(closestPiece) < 0) {
                return false;
            }
            var betweenPieces = this.BetweenPieces(row, col, colorNum);
            return betweenPieces.All(piece => piece.IsColorOf(-colorNum));
        }

        public void Flip(int row, int col, int colorNum)
        {
            //左側
            if(!this.Setable(row,col,colorNum))
            {
                return;
            }
            foreach(var piece in this.BetweenPieces(row, col, colorNum))
            {
                piece.Flip();
            }
        }

        Piece ClosestPiece(int row, int col, int colorNum)
        {
            var rowPieces = Pieces[row];
            return rowPieces.Where(item=>rowPieces.IndexOf(item) < col)
                                .Where(item=>item.IsColorOf(colorNum))
                                .LastOrDefault();
        }

        List<Piece> BetweenPieces(int row, int col, int colorNum)
        {
            var rowPieces = Pieces[row];
            var closestPiece = this.ClosestPiece(row, col, colorNum);
            return rowPieces.Where(item=>rowPieces.IndexOf(item) > rowPieces.IndexOf(closestPiece))
                            .Where(item=>rowPieces.IndexOf(item) < col)
                            .ToList();
        }

    }

    public class FieldRepository
    {
        public List<List<Piece>> Pieces {get;set;}

        public FieldRepository()
        {

        }

        public FieldRepository(List<List<Piece>> pieces)
        {
            this.Pieces = pieces;
        }
    }
    public class Field
    {
        private List<List<Piece>> Pieces;
        private List<IFlipper> Flippers;
        private Field()
        {

        }

        public static Field Initialize()
        {
            var field = new Field();
            field.Pieces = new List<List<Piece>>();
            field.Flippers = new List<IFlipper>(){
                new LeftSideFlipper(this.Pieces)
            };
            foreach(var time in Enumerable.Range(0, GameParameters.FIELD_SIZE))
            {
                field.Pieces.Add(Enumerable.Repeat(0, GameParameters.FIELD_SIZE).Select(i=>new Piece(0)).ToList());
            }
            field.AddPiece(3,3,1);
            field.AddPiece(4,4,1);
            field.AddPiece(3,4,-1);
            field.AddPiece(4,3,-1);
        }

        public static Field LoadRepository(FieldRepository repository) {
            var field = new Field();
            field.Pieces = repository.Pieces;
            field.Flippers = new List<Flipper>(){
                new LeftSideFlipper(field.Pieces)
            };
        }

        public void AddPiece(int row = 0, int col = 0, int colorNum = 0)
        {
            Pieces[row][col].Colored(colorNum);
            this.FlipPiece(row, col, colorNum);
        }

        void FlipPiece(int row, int col, int colorNum)
        {
            foreach(var flipper in this.Flippers)
            {
                flipper.Flip(row, col, colorNum);
            }
        }
        public void LoadRepository(FieldRepository repository)
        {
            this.Pieces=repository.Pieces;
            Flippers = new List<IFlipper>(){
                new LeftSideFlipper(this.Pieces)
            };
        }
        public FieldRepository ToRepository()=>new FieldRepository(this.Pieces);
    }
}
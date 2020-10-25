using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Game.Models
{
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
            // if(this.ColorNum != 0)
            // {
            //     return;
            // }
            this.ColorNum = colorNum;
        }
        public void Flip()
        {
            this.ColorNum = this.ColorNum*-1;
        }
        public bool IsColorOf(int colorNum)
        {
            return this.ColorNum == colorNum;
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Amidakuji.Models
{
    public class KujiModel
    {
        //タイトル
        [StringLength(20, ErrorMessage="タイトルは20文字以内で入力してください")]
        public string Title{get;set;}
        //くじの数
        [Range(1,9, ErrorMessage="1~9の数字を入力してください")]
        public int NumberOfKuji{get;set;}
        //くじの結果
        public List<ResultModel> Result{get;set;}
        //選択したくじ番号
        public int SelectId{get;set;}

        public KujiModel()
        {

        }
    }

    public class ResultModel
    {
        [StringLength(5, ErrorMessage = "くじの結果は5文字以内で入力してください")]
        public string Item {get;set;}

        public ResultModel()
        {

        }

        public ResultModel(string item)
        {
            Item = item;
        }
    }
}
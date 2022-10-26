using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required] //必須項目
        [Index(IsUnique =true)] //ユーザー名の重複が発生しないようにユニーク制約　文字列の長さを設定しないとエラーになる　900バイト以下
        [StringLength(256)] //文字列の長さを設定
        [DisplayName("ユーザー名")]
        public string UserName { get; set; }

        [Required] //必須項目
        [DataType(DataType.Password)]
        [DisplayName("パスワード")]
        public string Password { get; set; }

        //ナビゲーションプロパティにはvirtualをつける
        public virtual ICollection<Role> Roles { get; set; } //ユーザーモデルとロールモデルの関連を表すプロパティ　ナビゲーションプロパティと言う
    }
}
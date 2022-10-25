using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    //コードファーストではTodoClassをもとにしてテーブルが作られる　単数形の名詞
    public class Todo
    {
        // Idは自動的に主キー
        public int Id { get; set; }

        [DisplayName("概要")]
        public string Summary { get; set; }

        [DisplayName("詳細")]
        public string Detail { get; set; }

        [DisplayName("期限")]
        public DateTime Limit { get; set; }

        [DisplayName("完了")]
        public bool Done { get; set; }
    }
}
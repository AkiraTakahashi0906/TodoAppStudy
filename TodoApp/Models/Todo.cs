using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    //コードファーストではTodoClassをもとにしてテーブルが作られる　単数形の名詞
    public class Todo
    {
        // Idは自動的に主キー
        public int Id { get; set; }
        public string Summary { get; set; }
        public string Detail { get; set; }
        public DateTime Limit { get; set; }
        public bool Done { get; set; }
    }
}
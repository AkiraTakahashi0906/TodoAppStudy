using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    //コントローラクラスを作る前にビルド
    //名前はコントローラで終わる
    //Controllerを継承
    public class TodoesController : Controller
    {
        //データベースの操作を行う
        private TodoesContext db = new TodoesContext();

        // GET: Todoes
        // ブラウザからTodoesにアクセスがあると呼ばれる
        // アクションメソッド
        public ActionResult Index()
        {
            //TodoのListを与える
            //ViewResult アクションメソッドに対応したVIEWを出力
            return View(db.Todoes.ToList());
        }

        // GET: Todoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                // HTTPのステータスコードを返す
                //ヘルパークラスがないのでNEWでインスタンス化
                //badRequest400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //idが一致するTodoesを検索
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                // 404ページを出力
                return HttpNotFound();
            }

            //idが一致するデータをVIEWにセット
            return View(todo);
        }

        // GET: Todoes/Create
        //GETメソッドでリクエストがあった場合
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todoes/Create　ポストリクエスト
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。

        //ブラウザからPOSTリクエストがあった際に呼び出されるアクションメソッドを表すアノテーション
        [HttpPost]

        //クロスサイトリクエストフォージェリ攻撃を防ぐためのアノテーション
        //ポストれてきたトークンを自動的に検証
        [ValidateAntiForgeryToken]

        //bindはPOSTされたデータをTODOモデルに紐づける
        //CreateアクションメソッドはBINDを使わずにも書くことができる
        public ActionResult Create([Bind(Include = "Id,Summary,Detail,Limit,Done")] Todo todo)
        {
            //入力内容が適切か返す
            if (ModelState.IsValid)
            {
                //Add DbSetに追加
                db.Todoes.Add(todo);

                //DbSetの内容をDBに反映する
                db.SaveChanges();

                //指定のアクションメソッドに処理を転送　ヘルパメソッド
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        // GET: Todoes/Edit/5
        //指定されたIDのTODOを返す
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todoes/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        // 入力されたデータが引数のTODOオブジェクトにバインドされる
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Summary,Detail,Limit,Done")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                //引数で受け取ったTODOをセットする
                //Stateプロパティにモディファイドをセットすることで、該当のTODOを更新できる。
                db.Entry(todo).State = EntityState.Modified;

                //DBに反映
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // GET: Todoes/Delete/5
        //指定されたIDのTODO返す
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todoes/Delete/5
        //指定されたIDのTODOを取得し、そのTODOをDbSetから削除

        //ActionNameを指定する事でアクションメソッドの名前と、URLのメソッド部分を別のものにできる
        //Getの時の名称と引数が同じなのでエラーになるからメソッド名を変える
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Todo todo = db.Todoes.Find(id);
            db.Todoes.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //保持しているコンテキストを開放
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

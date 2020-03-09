using First_Web_API.Models;
using First_Web_API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace First_Web_API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ToDoController : ApiController
    {
        // List Todo
        [Route("todos")]
        public List<ToDoDTO> GetTodos()
        {
            using(APIEntities api = new APIEntities())
            {
                var todos = api.todoes.ToList();
                var todoList = (from todo todo in todos
                                select new ToDoDTO
                                    {
                                        ID = todo.todo_id,
                                        Value = todo.value,
                                        Completed = (todo.completed == 1 ? true : false)
                                    }
                               );
                return todoList.ToList();
            }
        }

        // Add Todo
        [Route("todos")]
        public string PostTodo(ToDoDTO todo) {
            using(APIEntities api = new APIEntities())
            {
                var newTodo = new todo
                {
                    todo_id = todo.ID,
                    value = todo.Value,
                    completed = (todo.Completed) ? 1 : 0
                };
                api.todoes.Add(newTodo);
                api.SaveChanges();
                return "success";
            }
        }

        // Complete Todo
        [Route("todos/{id}/completed")]
        public string GetTodoCompleted(int id)
        {
            using(APIEntities api = new APIEntities())
            {
                var todo = api.todoes.Find(id);
                var completed = todo.completed;
                todo.completed = (completed == 1) ? 0 : 1;
                api.SaveChanges();
                return "success completed ID :" + id;
            }
        }

        // Delete Todo
        [Route("todos/{id}/delete")]
        public string GetTodoDelete(int id)
        {
            using(APIEntities api = new APIEntities())
            {
                var todo = api.todoes.Find(id);
                api.todoes.Remove(todo);
                api.SaveChanges();
                return "success delete ID :" + id;
            }
        }
    }
}

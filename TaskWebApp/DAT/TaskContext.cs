using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaskWebApp.Model;

namespace TaskWebApp.DAT
{
    public class TaskContext : IContext
    {
        private readonly string _connetionString;
        private readonly IConfiguration _configuration;

        public TaskContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connetionString = configuration["ConnectionStrings:ConnectionTaskMangerDB"];
        }

        public IEnumerable<TodoTask> GetAllTodoTasks()
        {
            using (IDbConnection cnn = new SqlConnection(_connetionString))
            {
                string querySql = @"SELECT taskid,
                                        taskname,
	                                    creatorname,
	                                    description,
	                                    creationdate,
	                                    isfinished
                                    FROM dbo.TodoTasks";

                return cnn.Query<TodoTask>(querySql);
            }
        }
        public TodoTask GetTaskById(string id)
        {
            using (IDbConnection cnn = new SqlConnection(_connetionString))
            {
                string querySql = $@"SELECT taskid,
                                        taskname,
	                                    creatorname,
	                                    description,
	                                    creationdate,
	                                    isfinished
                                    FROM dbo.TodoTasks
                                    WHERE taskid = {id}";

                return cnn.QuerySingle<TodoTask>(querySql);
            }
        }
        public void RemoveTaskById(string id)
        {
            using (IDbConnection cnn = new SqlConnection(_connetionString))
            {
                string querySql = $@"DELETE FROM dbo.TodoTasks 
                                        WHERE taskid = {id}";

                cnn.Execute(querySql);
            }
        }
        public void UpdateTaskProperties(TodoTask target)
        {
            using (IDbConnection cnn = new SqlConnection(_connetionString))
            {
                string querySql = $@"UPDATE dbo.TodoTasks 
                                     SET taskname = '{target.TaskName}',
	                                     creatorname = '{target.CreatorName}',
	                                     description = '{target.Description}',
	                                     creationdate = CONVERT(datetime,'{target.CreationDate}',105),
	                                     isfinished = {(target.IsFinished ? 1 : 0)}
                                     WHERE taskid = {target.taskid}";

                cnn.Execute(querySql);
            }
        }
        public void CreateTask(TodoTask source)
        {
            using (IDbConnection cnn = new SqlConnection(_connetionString))
            {
                string querySql = $@"INSERT INTO TodoTasks(taskname,
		                                    creatorname,
		                                    description,
		                                    creationdate,
		                                    isfinished) VALUES
	                                    ('{source.TaskName}',
                                         '{source.CreatorName}',
                                         '{source.Description}',
                                         CONVERT(datetime,'{source.CreationDate}',105),
                                         {(source.IsFinished == false ? 0 : 1)})";
                cnn.Execute(querySql);
            }
        }
        public void ChangeTaskFieldIsFinshed(string id)
        {
            using (IDbConnection cnn = new SqlConnection(_connetionString))
            {
                string querySql = $@"DECLARE @isFinished BIT;
                                        BEGIN
                                            SET @isFinished = (SELECT isfinished
                                                FROM dbo.TodoTasks
                                                WHERE taskid = {id})
	                                        IF @isFinished = 0
                                                BEGIN
                                                    UPDATE dbo.TodoTasks
                                                    SET isfinished = 1
                                                    WHERE taskid = {id}
                                                END
                                                ELSE
                                                BEGIN
                                                    UPDATE dbo.TodoTasks
                                                    SET isfinished = 0
                                                    WHERE taskid = {id}
                                                END
                                            END";
                cnn.Execute(querySql);
            }
        }
    }
}

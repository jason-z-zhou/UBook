using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesManagementSystem.ViewModels;
using System.Data.Objects;
using System.Data.Common;

namespace SalesManagementSystem.Models
{
    public class DataTables
    {
        private ObjectContext objContext;
        private string tableID;
        private string action;
        private string controller;
        private string[] tableHead;
        private string[] tableWidth = null;
        private int? displayLength = null;
        private string[] select;
        private string from;
        private string sql;
        private string where;
        private string cwhere = "1=1";

        public string Where { get { return cwhere; } set { cwhere = value; } }
        public string TableID { get { return tableID; } }
        public string Action { get { return action; } }
        public string Controller { get { return controller; } }
        public string[] TableHead { get { return tableHead; } }
        public string[] TableWidth { get { return tableWidth; } }
        public int? DisplayLength { get { return displayLength; } }

        public DataTables(ObjectContext Context, string TableID, string[] Select, string From, string Action, string Controller, string[] TableHead, string[] TableWidth = null, int? DisplayLength = null)
        {
            objContext = Context;
            tableID = TableID;
            select = Select;
            from = From;
            action = Action;
            controller = Controller;
            tableHead = TableHead;
            tableWidth = TableWidth;
            displayLength = DisplayLength;
            where = "";
            string columns = " ";
            bool isFirst = true;
            var last = where;
            foreach (var item in select)
            {
                if (isFirst)
                {
                    where += String.Format(" cast({0} as System.String) like '%{{0}}%'", item);
                    columns += item;
                    isFirst = false;
                }
                else
                {
                    last = where;
                    where += String.Format(" or cast({0} as System.String) like '%{{0}}%'", item);
                    columns += ", " + item;
                }
            }
            where = last;
            sql = "select " + columns + " from " + from;
        }

        public object AjaxHandler(jQueryDataTableParamModel param)
        {
            var query = objContext.CreateQuery<DbDataRecord>("select count(" + select[select.Length - 1] + ") from " + this.from);
            var total = 0;
            try
            {
                foreach (var item in query)
                {
                    total = Convert.ToInt32(item[0]);
                    break;
                }
            }
            catch
            {
                total = 0;
            }
            var eSQL = sql;
            eSQL += " where " + cwhere;
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                eSQL += " and " + String.Format(where, param.sSearch);
            }
            var orderBy = " order by " + select[param.iSortCol_0] + " " + param.sSortDir_0;
            if (string.IsNullOrEmpty(param.sSortDir_0))
            {
                orderBy = " order by " + select[select.Count()];
            }
            eSQL += orderBy;
            var entries = objContext.CreateQuery<DbDataRecord>(eSQL);
            var result = entries
                        .Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);
            var dataList = new List<List<string>>();
            try
            {

                foreach (var item in result)
                {
                    var newRow = new List<string>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        newRow.Add(item[i].ToString());
                    }
                    dataList.Add(newRow);
                }
            }
            catch
            {
                dataList.Clear();
            }
            return (new
            {
                sEcho = param.sEcho,
                iTotalRecords = total,
                iTotalDisplayRecords = entries.Count(),
                aaData = dataList
            });
        }
    }
}
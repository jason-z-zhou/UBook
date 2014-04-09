using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesManagementSystem.Models;

namespace SalesManagementSystem.Helpers
{
    public static class DataTablesHelper
    {
        public static HtmlString DataTables<TModel>(this HtmlHelper<TModel> helper, DataTables table, string CURD = null)
        {
            UrlHelper url = new UrlHelper(helper.ViewContext.RequestContext);
            string dataTableJs = url.Content("~/Content/lib/datatables/js/jquery.dataTables.js");
            string langTxt = url.Content("~/Content/datatables/zh_CN.txt");
            string htmlCURD = string.IsNullOrEmpty(CURD) ? "{0}" : CURD;
            string flag = string.IsNullOrEmpty(CURD).ToString().ToLower();
            string result = @"		<script type=""text/javascript"" charset=""utf-8"">
			String.prototype.format=function()
			{{
				var p = arguments;
				return this.replace(/(\{{\d+\}})/g,function(){{
					return p[arguments[0].replace(/\D/g,"""")];
				}});
			}};
			$(document).ready(function() {{
				$('#{1}').dataTable( {{
					""bRetrieve"": true,
					""bProcessing"": true,
					""bServerSide"": true,
					""sAjaxSource"": ""{2}"",
					""aoColumnDefs"": [ 
						{{
							""fnRender"": function ( oObj ) {{
								return ""{6}"".format(oObj.aData[oObj.iDataColumn]);
							}},
							""bSortable"": {7},
							""aTargets"": [ -1 ]
						}}
					],
					{3}
					""bLengthChange"": true,
					""bPaginate"": true,
					""sPaginationType"": ""full_numbers"",
					""oLanguage"": {{
						""sUrl"": ""{4}""
					}}
				}} );
			}} );
		</script>
		<script type=""text/javascript"" language=""javascript"" src=""{0}""></script>
<table class=""display"" id=""{1}"">
	<thead>
		<tr>
{5}
		</tr>
	</thead>
	<tbody>
	</tbody>
</table>";

            string pramSource = url.Action(table.Action, table.Controller);
            string pramLength = "\"iDisplayLength\": " + (table.DisplayLength == null ? "15" : table.DisplayLength.ToString()) + ",\r\n";
            string pramTableID = table.TableID;
            string pramTableHead = "";
            if (table.TableWidth == null || table.TableWidth.Length != table.TableHead.Length)
            {
                foreach (var item in table.TableHead)
                {
                    pramTableHead += String.Format("			<th>{0}</th>\r\n", item);
                }
            }
            else
            {
                for (int i = 0; i < table.TableWidth.Length; i++)
                {
                    string width = table.TableWidth[i];
                    string head = table.TableHead[i];

                    pramTableHead += String.Format("			<th width=\"{0}\">{1}</th>\r\n", width, head);
                }
            }
            result = String.Format(result, dataTableJs, pramTableID, pramSource, pramLength, langTxt, pramTableHead, htmlCURD, flag);
            return new HtmlString(result);
        }
    }
}
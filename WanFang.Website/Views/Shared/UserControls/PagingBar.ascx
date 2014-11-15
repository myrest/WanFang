<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="WanFang.Core" %>
<%@ OutputCache Duration="43200" VaryByParam="None" VaryByCustom="pageurl" Shared="true" %>
            <%
                Rest.Core.Paging Page = ViewData["Page"] as Rest.Core.Paging;
                int CurrentPage = Convert.ToInt32(Page.CurrentPage);
            %>
            <script>
                page = {
                    goprev: function () {
                        var pagenum = parseInt($('#CurrentPage').val(), 10) - 1;
                        if (pagenum < 1) pagenum = 1;
                        $('#CurrentPage').val(pagenum);
                        $('#form1').submit();
                    },
                    gonext: function () {
                        var pagenum = parseInt($('#CurrentPage').val(), 10) + 1;
                        if (pagenum < <%= Page.TotalPages %> ) pagenum = <%= Page.TotalPages %> ;
                        $('#CurrentPage').val(pagenum);
                        $('#form1').submit();
                    },
                    topage: function () {
                        $this = $(this);
                        var pagenum = $this.attr('p');
                        $('#CurrentPage').val(pagenum);
                        $('#form1').submit();
                    }
                };
                $(function () {
                    $('.prev').click(page.goprev);
                    $('.next').click(page.gonext);
                    $('.toapge').click(page.topage);
                });
            </script>
            <input type="hidden" name="CurrentPage" id="CurrentPage" value="<%=CurrentPage %>" />

            &nbsp; <a href="#" class="prev">&#171;上一頁</a>&nbsp;
            <%
                for (int i = 1; i <= Page.TotalPages; i++)
                {
                    if (i == Page.CurrentPage)
                    {
                        Response.Write("<span class=\"on\">&nbsp;" + i.ToString() + "&nbsp;</span>&nbsp;");
                    }
                    else
                    {
                        Response.Write("<a href=\"#\" class=\"toapge\" p=\"" + i.ToString() + "\">&nbsp;" + i.ToString() + "&nbsp;</a> ");
                    }
                }
            %>
            <a href="#" class="next">下一頁&#187;</a>&nbsp;<!-- <a href="#">&nbsp;最後一頁&nbsp;</a> -->
            <%=Page.CurrentPage %>/<%=Page.TotalPages %>

<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Select.aspx.cs" Inherits="NewAdmin.Select" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>DIGITAL Saas </title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-content">
            <asp:ScriptManager
                ID="ScriptManager1"
                runat="server">
            </asp:ScriptManager>



            <!-- END PAGE BREADCRUMB -->
            <!-- END PAGE HEADER-->
            <!-- BEGIN PAGE CONTENT-->
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box blue">
                        <div>
                            <div class="caption" style="float: left">
                                Theme
                            </div>
                            <div class="tools" style="float: left">
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="table-group-action-input form-control input-medium">
                                    <asp:ListItem Selected="True" Value="0">--- Select ---</asp:ListItem>
                                    <asp:ListItem Value="1">Theme 1</asp:ListItem>
                                    <asp:ListItem Value="2">Theme 2</asp:ListItem>
                                    <asp:ListItem Value="3">Theme 3</asp:ListItem>
                                    <asp:ListItem Value="4">Theme 4</asp:ListItem>
                                    <asp:ListItem Value="5">Theme 5</asp:ListItem>
                                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               
                            </div>
                            <div class="caption" style="float: left">
                                Language
                            </div>
                            <div class="tools" style="float: left">
                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="table-group-action-input form-control input-medium">
                                    <asp:ListItem Selected="True" Value="0">--- Select ---</asp:ListItem>
                                    <asp:ListItem Value="1">English</asp:ListItem>
                                    <asp:ListItem Value="2">Arabic</asp:ListItem>
                                    <asp:ListItem Value="3">Hindi</asp:ListItem>

                                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               
                            </div>
                            <div class="caption" style="float: left">
                                Table Name
                            </div>
                            <div class="tools" style="float: left">
                                <asp:DropDownList ID="drpTable" runat="server" AutoPostBack="true" CssClass="table-group-action-input form-control input-medium" OnSelectedIndexChanged="drpTable_SelectedIndexChanged">
                                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               
                            </div>
                            <div class="caption" style="float: left">
                                Order By
                            </div>
                            <div class="tools" style="float: left">
                                <asp:DropDownList ID="droOrder" runat="server" CssClass="table-group-action-input form-control input-medium">
                                    <asp:ListItem Selected="True" Value="0">--- Select ---</asp:ListItem>
                                    <asp:ListItem Value="1">Ascending </asp:ListItem>
                                    <asp:ListItem Value="2">Descending </asp:ListItem>


                                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               
                            </div>
                            <div class="caption" style="float: left">
                                Order By field
                            </div>
                            <div class="tools" style="float: left">
                                <asp:DropDownList ID="drpBindTopField" runat="server" CssClass="table-group-action-input form-control input-medium">
                                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               
                            </div>

                        </div>
                        <br />
                        <br />
                        <div class="portlet-body">
                            <div class="table-toolbar">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="btn-group">
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                                <thead>
                                    <tr>
                                        <th>
                                            <asp:CheckBox ID="checkall" runat="server" class="checkall" AutoPostBack="True" OnCheckedChanged="chkall_CheckedChanged" /></th>
                                        <th>Filed Name</th>
                                        <th>Data Type</th>
                                        <th>Is Allow Null</th>
                                        <th>Key</th>
                                        <th>Label Name</th>
                                        <th>Control Name</th>
                                        <th>Mendatory</th>
                                        <th>Validation</th>
                                        <th>Bind Data with DropDown</th>
                                        <th>Lable Of DropDown</th>
                                        <th>Label Color</th>
                                        <th>GridDara Display?</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:ListView ID="Listview1" runat="server" OnItemDataBound="Listview1_ItemDataBound">
                                        <LayoutTemplate>
                                            <tr id="ItemPlaceholder" runat="server">
                                            </tr>
                                        </LayoutTemplate>
                                        <ItemTemplate>

                                            <tr role="row" class="odd">
                                                <td class="sorting_1">
                                                    <asp:CheckBox ID="CheckFields" runat="server" />
                                                </td>
                                                <%--<th>Filed Name</th>--%>
                                                <td>
                                                    <asp:Label ID="lblFieldName" runat="server" Text='<%# Eval("FiedlName") %>'></asp:Label>

                                                </td>
                                                <%--  <th>Data Type</th>--%>
                                                <td>
                                                    <asp:Label ID="lblDataType" runat="server"></asp:Label>

                                                </td>
                                                <%-- <th>Is Allow Null</th>--%>
                                                <td>
                                                    <asp:Label ID="lblIsnullavle" runat="server"></asp:Label>
                                                </td>
                                                <%--<th>Key</th>--%>
                                                <td>
                                                    <asp:CheckBox ID="chbKey" Enabled="false" runat="server" value="" />
                                                </td>
                                                <%-- <th>Label Name</th>--%>
                                                <td>
                                                    <asp:TextBox ID="txtLabelName" runat="server" class="form-control input-small" Text='<%# RenameFieldname(Eval("FiedlName").ToString().ToUpper()) %>'></asp:TextBox>
                                                </td>
                                                <%-- <th>Control Name</th>--%>
                                                <td>
                                                    <asp:DropDownList ID="drpControl" runat="server" CssClass="table-group-action-input form-control input-medium" AutoPostBack="true" OnSelectedIndexChanged="drpControl_SelectedIndexChanged">
                                                        <asp:ListItem Value="0" Selected="True">-- Select --</asp:ListItem>
                                                        <asp:ListItem Value="1">TextBox </asp:ListItem>
                                                        <asp:ListItem Value="2">TextBox with Multiline </asp:ListItem>
                                                        <asp:ListItem Value="3">TextBox for DateTime </asp:ListItem>
                                                        <asp:ListItem Value="4">DropDownList</asp:ListItem>
                                                        <asp:ListItem Value="5">CheckBox</asp:ListItem>

                                                    </asp:DropDownList>
                                                </td>
                                                <%--   <th>Mendatory</th>--%>

                                                <td class="sorting_1">
                                                    <asp:CheckBox ID="chMendatory" runat="server" />
                                                </td>
                                                <%--  <th>Validation</th>--%>
                                                <td>
                                                    <asp:DropDownList ID="drpValidation" runat="server" CssClass="table-group-action-input form-control input-medium">
                                                        <asp:ListItem Value="0" Selected="True">-- Select --</asp:ListItem>
                                                        <asp:ListItem Value="1">Numeric Only Validation</asp:ListItem>
                                                        <asp:ListItem Value="2">Numeric with Dott Validation</asp:ListItem>
                                                        <asp:ListItem Value="3">Drop Box Validation</asp:ListItem>
                                                        <asp:ListItem Value="4">Email Validation</asp:ListItem>
                                                        <asp:ListItem Value="5">Required Validation</asp:ListItem>
                                                        <asp:ListItem Value="6">DateTime Validation</asp:ListItem>

                                                    </asp:DropDownList>
                                                </td>

                                                <%--<th>Bind Data with DropDown</th>--%>
                                                <td>
                                                    <asp:DropDownList ID="drpBindData" Enabled="false" runat="server" AutoPostBack="true" CssClass="table-group-action-input form-control input-medium" OnSelectedIndexChanged="drpBindData_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>

                                                <%--<th>Lable Of DropDown</th>--%>
                                                <td>
                                                    <asp:DropDownList ID="drpBindField" Enabled="false"  runat="server" CssClass="table-group-action-input form-control input-medium">
                                                    </asp:DropDownList>
                                                </td>
                                                <%--  <th>Label Color</th>--%>

                                                <td>
                                                    <asp:TextBox ID="txtcolor" runat="server" BackColor="purple" ForeColor="purple"></asp:TextBox>
                                                    <cc1:ColorPickerExtender
                                                        ID="txtCardColor_ColorPickerExtender"
                                                        TargetControlID="txtcolor"
                                                        SampleControlID="txtcolor"
                                                        Enabled="True"
                                                        runat="server">
                                                    </cc1:ColorPickerExtender>

                                                </td>

                                                <%-- <th>GridDara Display?</th>--%>
                                                <td>
                                                    <asp:CheckBox ID="chGriddata" runat="server" value="" />
                                                </td>
                                            </tr>



                                        </ItemTemplate>
                                    </asp:ListView>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <asp:Button ID="btnGetData" runat="server" Text="Generate"
                        OnClick="btnGetData_Click" />
                    <!-- END EXAMPLE TABLE PORTLET-->
                </div>
            </div>
            <!-- END PAGE CONTENT -->
        </div>

    </form>
</body>
</html>

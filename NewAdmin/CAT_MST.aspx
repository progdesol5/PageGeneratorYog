<%@ Page Title="" Language="C#" MasterPageFile="~/AcmMaster.master" AutoEventWireup="true" CodeBehind="CAT_MST.aspx.cs" Inherits="NewAdmin.CAT_MST"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="page-content">
        <div class="col-md-12">
            <div class="tabbable-custom tabbable-noborder">
                <ul class="page-breadcrumb breadcrumb">
                    <li>
                        <a href="index.aspx">HOME </a>
                        <i class="fa fa-circle"></i>
                    </li>
                    <li>
                        <a href="#">CAT_MST </a>
                    </li>
                </ul>
                <asp:Panel ID="pnlSuccessMsg" runat="server" Visible="false">
                    <div class="alert alert-success alert-dismissable">
                        <button aria-hidden="true" data-dismiss="alert" class="close" type="button"></button>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                </asp:Panel>

                <div class="row">
                    <div class="col-md-12">
                        <div class="form-horizontal form-row-seperated">
                            <div class="portlet light">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-basket font-green-sharp"></i>
                                        <span class="caption-subject font-green-sharp bold uppercase">CAT_MST</span>
                                    </div>
                                    <div class="actions btn-set">
                                        <div class="btn-group btn-group-circle btn-group-solid">
                                            <asp:Button ID="btnFirst" class="btn red" runat="server" Text="First" />
                                            <asp:Button ID="btnNext" class="btn green" runat="server"  Text="Next" />
                                            <asp:Button ID="btnPrev" class="btn purple" runat="server"  Text="Prev" />
                                            <asp:Button ID="btnLast" class="btn blue" runat="server" Text="Last"  />
                                        </div>

                                        <asp:Button ID="btnAdd" runat="server" class="btn green-haze btn-circle" ValidationGroup="submit" Text="Update " />
                                       
                                        <asp:Button ID="btnCancel" runat="server" class="btn green-haze btn-circle"  Text="Cancel" />
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="tabbable">
                                        <div class="tab-content no-space">
                                            <div class="tab-pane active" id="tab_general1">
                                                <div class="form-body">

                                                  
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>


                    <asp:Panel runat="server" ID="pnlGrid">
                        <div class="tab-content">
                            <div id="tab_1_1" class="tab-pane active">

                                <div class="tab-content no-space">
                                    <div class="tab-pane active" id="tab_general2">
                                        <div class="table-container" style="">
                                            <div class="portlet box blue-hoki">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-globe"></i>CAT_MST List
                                                    </div>

                                                    <div class="tools">
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <table class="table table-striped table-bordered table-hover" id="sample_1">
                                                        <thead>
                                                            <tr>
                                                                <th style="width: 60px;">ACTION</th>
                                                               
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:ListView ID="Listview1" runat="server"  DataKey="ID" DataKeyNames="ID">
                                                                <LayoutTemplate>
                                                                    <tr id="ItemPlaceholder" runat="server">
                                                                    </tr>
                                                                </LayoutTemplate>
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td>
                                                                            <div class="btn-group">
                                                                                <a data-toggle="dropdown" href="#" class="btn btn-sm blue dropdown-toggle" style="width: 60px;">Action <i class="fa fa-angle-down"></i>
                                                                                </a>
                                                                                <ul class="dropdown-menu">
                                                                                    <li>
                                                                                        <asp:LinkButton ID="btnEdit" CommandName="btnEdit" CommandArgument='<%# Eval("ID")%>' runat="server">  <i class="fa fa-pencil"></i>Edit</asp:LinkButton>

                                                                                    </li>
                                                                                    <li>
                                                                                        <asp:LinkButton ID="btnDelete" CommandName="btnDelete" OnClientClick="return ConfirmMsg();" CommandArgument='<%# Eval("ID")%>' runat="server"> <i class="fa fa-pencil"></i>Delete</asp:LinkButton>

                                                                                    </li>
                                                                                    <li>
                                                                                        <asp:LinkButton ID="LinkButton2" PostBackUrl='<%# "PrintMDSF.aspx?ID="+ Eval("ID")%>' CommandName="btnPrint" CommandArgument='<%# Eval("ID")%>' runat="server"><i class="fa fa-pencil"></i>Print</asp:LinkButton>
                                                                                    </li>
                                                                                </ul>
                                                                            </div>
                                                                        </td>
                                                                        
                                                                       
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:ListView>

                                                        </tbody>
                                                    </table>

                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <asp:HiddenField ID="hideID" runat="server" Value="" />
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
        </div>
</asp:Content>








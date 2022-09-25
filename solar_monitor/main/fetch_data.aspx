<%@ Page Title="" Language="C#" MasterPageFile="~/main/solar.Master" AutoEventWireup="true" CodeBehind="fetch_data.aspx.cs" Inherits="solar_monitor.main.fetch_data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>FHIT Monitor - Fetch Data</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="content-header">
			<div class="d-flex align-items-center">
				<div class="me-auto">
					<h3 class="page-title">Fetch Data from Logger </h3>
					<div class="d-inline-block align-items-center">
						<nav>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="/main/summary"><i class="mdi mdi-home-outline"></i></a></li>
								<li class="breadcrumb-item" aria-current="page">Data Services</li>
								<li class="breadcrumb-item active" aria-current="page">Fetch Data</li>
							</ol>
						</nav>
					</div>
				</div>
				
			</div>
		</div>
		 <div id="alert" runat="server" visible="false" class="alert alert-danger col-xl-6 offset-md-3">
				<span id="innertext" runat="server">test</span>
			  </div>
	<section class="content">
			<div class="row">
					<div class="col-xl-12 col-lg-12 col-12">
					 <div class="box">
				<div class="box-header with-border">
				  <h4 class="box-title">Fetch Data for IV Curve Tracer</h4>
				</div>
				<!-- /.box-header -->
				<div class="box-body">
					 <div class="form-group">
                         <div class="row" style="margin-bottom: 20px">
                             <div class="col-3">
                                 <asp:Button ID="Button3" type="button" Style="height: 50px" OnClick="Button1_Click" class="waves-effect waves-light btn btn-success mb-5" runat="server" ForeColor="White" Text="Fetch IV Curve Tracer DATA" />
                                 <!-- /.input group -->
                             </div>
                         </div>
					<div class="row">					
						<div class="col-3">
							  <label class="form-label">FTP HostName</label>
							<div class="input-group">
							  <%--<div class="input-group-addon">
								<i class="fa fa-calendar"></i>
							  </div>--%>
							  <input type="text" class="form-control" required="required" runat="server" placeholder="FTP HostName"  id="hostnametxt" >
							</div>
							<!-- /.input group -->
						</div>
						<div class="col-3">
							  <label class="form-label">FTP Username</label>
							<div class="input-group">
							  <%--<div class="input-group-addon">
								<i class="fa fa-calendar"></i>
							  </div>--%>
							  <input type="text" class="form-control" required="required" runat="server" placeholder="FTP Username"  id="usernametxt" >
							</div>
							<!-- /.input group -->
						</div>
						<div class="col-3">
						   <label class="form-label">FTP Password</label>
							<div class="input-group">
							 <%-- <div class="input-group-addon">
								<i class="fa fa-calendar"></i>
							  </div>--%>
							  <input type="password" class="form-control" required="required" runat="server" placeholder="FTP Password"  id="username" >
							</div>
							<!-- /.input group -->
						</div>
					</div>
                         <div class="row" style="margin-top: 20px">
                             <div class="col-3">
                                 <asp:Button ID="Button1" type="button" OnClick="Button1_Click" class="waves-effect waves-light btn btn-success mb-5" runat="server" ForeColor="White" Text="Update FTP Credentials" />
                                 <asp:Button ID="Button2" type="button" class="waves-effect waves-light btn btn-warning mb-5" runat="server" Text="Clear" />
                                 <!-- /.input group -->
                             </div>
                         </div>
				  </div>
				</div>
				<!-- /.box-body -->
			  </div>
					 <div class="box">
				<div class="box-header with-border">
				  <h4 class="box-title">Fetch Data for CS Logger</h4>
				</div>
				<!-- /.box-header -->
				<div class="box-body">
						 <div class="form-group">
                         <div class="row" style="margin-bottom: 20px">
                             <div class="col-3">
                                 <asp:Button ID="Button4" type="button" Style="height: 50px" OnClick="fetch_cslogger" class="waves-effect waves-light btn btn-success mb-5" runat="server" ForeColor="White" Text="Fetch CS Logger DATA" />
                                 <!-- /.input group -->
                             </div>
                         </div>
					<div class="row">					
						<div class="col-3">
							  <label class="form-label">.Dat File Location</label>
							<div class="input-group">
							  <%--<div class="input-group-addon">
								<i class="fa fa-calendar"></i>
							  </div>--%>
							  <input type="text" class="form-control" required="required" runat="server" placeholder=".Dat File Location"  id="datfilelocationtxt" >
							</div>
							<!-- /.input group -->
						</div>
					</div>
                         <div class="row" style="margin-top: 20px">
                             <div class="col-3">
                                 <asp:Button ID="Button5" type="button" OnClick="Button1_Click" class="waves-effect waves-light btn btn-success mb-5" runat="server" ForeColor="White" Text="Update .dat File Location" />
                                 <!-- /.input group -->
                             </div>
                         </div>
				  </div>				
				</div>
				<!-- /.box-body -->
			  </div>
				</div>
				</div>
		</section>
</asp:Content>

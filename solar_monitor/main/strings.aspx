<%@ Page Title="" Language="C#" MasterPageFile="~/main/solar.Master" AutoEventWireup="true" CodeBehind="strings.aspx.cs" Inherits="solar_monitor.main.strings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>FHIT Monitor - String Analysis</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
			<div class="d-flex align-items-center">
				<div class="me-auto">
					<h3 class="page-title">String Analysis</h3>
					<div class="d-inline-block align-items-center">
						<nav>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="/main/summary"><i class="mdi mdi-home-outline"></i></a></li>
								<li class="breadcrumb-item" aria-current="page">Analysis</li>
								<li class="breadcrumb-item active" aria-current="page">String Analysis</li>
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
				  <h4 class="box-title">Report Filter</h4>
				</div>
				<!-- /.box-header -->
				<div class="box-body">
					 <div class="form-group">
					<div class="row">
						
						  <div class="col-md-3">
									<div class="form-group">
									  <label class="form-label">String Type</label>
										<asp:DropDownList ID="DropDownList1" class="form-select" runat="server">
                                            <asp:ListItem>String 1</asp:ListItem>
                                            <asp:ListItem>String 2</asp:ListItem>
                                            <asp:ListItem>String 3</asp:ListItem>
                                            <asp:ListItem>String 4</asp:ListItem>
                                            <asp:ListItem>String 5</asp:ListItem>
                                        </asp:DropDownList>
									
									</div>
								  </div>
						  <div class="col-md-3">
									<div class="form-group">
									  <label class="form-label">Unit</label>
										<asp:DropDownList ID="DropDownList2" class="form-select" runat="server">
                                            <asp:ListItem>Both</asp:ListItem>
                                            <asp:ListItem>Voltage</asp:ListItem>
                                            <asp:ListItem>Current</asp:ListItem>
                                            <asp:ListItem>Volt. VS Curr.</asp:ListItem>
                                            <asp:ListItem>Curr. VS Volt.</asp:ListItem>
                                        </asp:DropDownList>
									</div>
								  </div>
						<div class="col-3">
							  <label class="form-label">Start Date</label>
							<div class="input-group">
							  <div class="input-group-addon">
								<i class="fa fa-calendar"></i>
							  </div>
							  <input type="date" class="form-control" required="required" runat="server" id="startdatetxt" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask>
							</div>
							<!-- /.input group -->
						</div>
						<div class="col-3">
						   <label class="form-label">End Date</label>
							<div class="input-group">
							  <div class="input-group-addon">
								<i class="fa fa-calendar"></i>
							  </div>
							  <input type="date" class="form-control" required="required" runat="server" id="enddatetxt" data-inputmask="'alias': 'mm/dd/yyyy'" data-mask>
							</div>
							<!-- /.input group -->
						</div>
					</div>
						 <div class="row">
							   <div class="col-md-3">
									<div class="form-group">
									  <label class="form-label">Unit</label>
										<asp:ListBox ID="countryoforiginlistbx" class="form-control custom-select" runat="server" SelectionMode="Multiple"></asp:ListBox>
								
									</div>
								  </div>
							   <div class="col-md-3">
								 <div class="form-group">
									  <label class="form-label"></label><br /><br /><br />
<asp:Button ID="Button1" type="button" class="waves-effect waves-light btn btn-success mb-5" OnClick="Button1_Click" runat="server" ForeColor="White" Text="Get Stat" />
								 <asp:Button ID="Button2" type="button" class="waves-effect waves-light btn btn-warning mb-5" runat="server" Text="Clear" />								
									</div>
								 
							<!-- /.input group -->
						</div>
						 </div>
				  </div>
				</div>
				<!-- /.box-body -->
			  </div>
					 <div class="box">
				<div class="box-header with-border">
				  <h4 class="box-title">Graph</h4>
					
				</div>
				<!-- /.box-header -->
                         <div class="box-body">
                             <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
                             <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                             <div id="curve_chart" style="height: 750px; width: 100%"></div>
							  <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                        <div id="cslogger_graph" style="height: 750px; width: 100%"></div>

                         </div>
				<!-- /.box-body -->
			  </div>
					
					 <div class="box">
				<div class="box-header with-border">
				  <h4 class="box-title">REPORT LOG</h4>
					
				</div>
				<!-- /.box-header -->
				<div class="box-body">
					<div class="table-responsive">
					  <table id="example1" class="table table-bordered table-striped">
						<thead>

							<tr>
								<th>S/N</th>
								<th>Report Date</th>
								<th>Report Time</th>
								<th>Voltage(v)</th>
								<th>Current(A)</th>
								
							</tr>
						</thead>
						<tbody>
							<asp:Repeater ID="Repeater25" runat="server">
							<ItemTemplate>
							<tr>
								<td>  <%#Container.ItemIndex+1 %></td>
								<td><%# Convert.ToDateTime(Eval("Date")).ToString("dd/MMM/yyyy") %></td>
								<td><%# Eval("Time") %></td>
								<td><%# Eval("Voltage") %></td>
								<td><%# Eval("SCurrent") %></td>
							</tr>
							</ItemTemplate>
								</asp:Repeater>
						<%--</tbody>				  
						<tfoot>
							<tr>
									<th>S/N</th>
								<th>Report Date</th>
								<th>Cluster Name</th>
								<th>Coordinates</th>
								<th>Uploaded Location</th>
								<th>Map Location</th>
								<th>Info</th>
								<th>Status</th>
							</tr>
						</tfoot>--%>
					</table>
					</div>   
					
				</div>
				<!-- /.box-body -->
			  </div>
				
				  <!-- /. box -->
				</div>
				<!-- /.col -->

				<!-- /.col -->
			  </div>
		</section>
</asp:Content>

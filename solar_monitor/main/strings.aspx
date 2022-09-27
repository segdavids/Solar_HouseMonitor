﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main/solar.Master" AutoEventWireup="true" CodeBehind="strings.aspx.cs" Inherits="solar_monitor.main.strings" %>
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
                             <div id="curve_chart" style="height: 700px; width: 100%"></div>
							  <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                        <div id="cslogger_graph" style="height: 700px;margin-top:50px; width: 100%"></div>

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

						 <div class="box">
				<div class="box-header with-border">
				  <h4 class="box-title">TABULAR READINGS FOR DL-AVERAGE<span runat="server" id="stringspan"></span> FROM <span id="startdatespan" runat="server"></span></h4>
					
				</div>
				<!-- /.box-header -->
				<div class="box-body">
					<div class="table-responsive">
					  <table id="example" class="table table-bordered table-hover display nowrap margin-top-10 w-p100">
						<thead>
							<tr>
								<th>S/N</th>
								<th>Date/Time</th>
								<th>Record</th>
								<th>BattV_Min</th>
								<th>Rt_CNRM_Avg</th>
								<th>Rt_WKSH_Avg</th>
								<th>Rt_DkRM_Avg</th>
								<th>Rt_OUDR_Avg</th>
								<th>WDir_Std</th>
								<th>WSpd_Avg</th>
								<th>Sol_Glo_Avg</th>
								<th>Sol_tilt_Avg</th>
								<th>CHP1_Avg</th>
								<th>CMP10_Avg</th>
								<th>CMP10_Shaded_Avg</th>
								<th>SGR4_Avg</th>
								<th>Ambt_lux_Avg</th>
								<th>Temp_C_Avg(1)</th>
								<th>Temp_C_Avg(2)</th>
								<th>Temp_C_Avg(3)</th>
								<th>Temp_C_Avg(4)</th>
								<th>Temp_C_Avg(5)</th>
								<th>Temp_C_Avg(6)</th>
								<th>Temp_C_Avg(7)</th>
								<th>Temp_C_Avg(8)</th>
								<th>Temp_C_Avg(9)</th>
								<th>Temp_C_Avg(10)</th>
								<th>Temp_C_Avg(11)</th>
								<th>Temp_C_Avg(12)</th>
								<th>Temp_C_Avg(13)</th>
								<th>Temp_C_Avg(14)</th>
								<th>Temp_C_Avg(15)</th>
								<th>Temp_C_Avg(16)</th>
								<th>Temp_C_Avg(17)</th>
								<th>Temp_C_Avg(18)</th>
								<th>Temp_C_Avg(19)</th>
								<th>Temp_C_Avg(20)</th>
								<th>Tmp_Wbt_Avg</th>
								<th>Tmp_Wmd_Avg</th>
								<th>Tmp_Wtp_Avg</th>
								<th>Tmp_Ebt_Avg</th>
								<th>Tmp_Emd_Avg</th>
								<th>Tmp_Etp_Avg</th>
						</thead>
						<tbody>
							<asp:Repeater ID="Repeater1" runat="server">
							<ItemTemplate>
							<tr>
								<td><%#Container.ItemIndex+1 %></td>
								<td><%# Convert.ToDateTime(Eval("Timestamp")).ToString("dd/MMM/yyyy") %></td>
								<td><%# Eval("Record") %></td>
								<td><%# Eval("BattV_Min") %></td>
								<td><%# Eval("Rt_CNRM_Avg") %></td>
								<td><%# Eval("Rt_WKSH_Avg") %></td>
								<td><%# Eval("Rt_DkRM_Avg") %></td>
								<td><%# Eval("Rt_OUDR_Avg") %></td>
								<td><%# Eval("WDir_Std") %></td>
								<td><%# Eval("WSpd_Avg") %></td>
								<td><%# Eval("Sol_Glo_Avg") %></td>
								<td><%# Eval("Sol_tilt_Avg") %></td>
								<td><%# Eval("CHP1_Avg") %></td>
								<td><%# Eval("CMP10_Avg") %></td>
								<td><%# Eval("CMP10_Shaded_Avg") %></td>
								<td><%# Eval("SGR4_Avg") %></td>
								<td><%# Eval("Ambt_lux_Avg") %></td>
								<td><%# Eval("Temp_C_Avg_1") %></td>
								<td><%# Eval("Temp_C_Avg_2") %></td>
								<td><%# Eval("Temp_C_Avg_3") %></td>
								<td><%# Eval("Temp_C_Avg_4") %></td>
								<td><%# Eval("Temp_C_Avg_5") %></td>
								<td><%# Eval("Temp_C_Avg_6") %></td>
								<td><%# Eval("Temp_C_Avg_7") %></td>
								<td><%# Eval("Temp_C_Avg_8") %></td>
								<td><%# Eval("Temp_C_Avg_9") %></td>
								<td><%# Eval("Temp_C_Avg_10") %></td>
								<td><%# Eval("Temp_C_Avg_11") %></td>
								<td><%# Eval("Temp_C_Avg_12") %></td>
								<td><%# Eval("Temp_C_Avg_13") %></td>
								<td><%# Eval("Temp_C_Avg_14") %></td>
								<td><%# Eval("Temp_C_Avg_15") %></td>
								<td><%# Eval("Temp_C_Avg_16") %></td>
								<td><%# Eval("Temp_C_Avg_17") %></td>
								<td><%# Eval("Temp_C_Avg_18") %></td>
								<td><%# Eval("Temp_C_Avg_19") %></td>
								<td><%# Eval("Temp_C_Avg_20") %></td>
								<td><%# Eval("Tmp_Wbt_Avg") %></td>
								<td><%# Eval("Tmp_Wmd_Avg") %></td>
								<td><%# Eval("Tmp_Wtp_Avg") %></td>
								<td><%# Eval("Tmp_Ebt_Avg") %></td>
								<td><%# Eval("Tmp_Emd_Avg") %></td>
								<td><%# Eval("Tmp_Etp_Avg") %></td>
								
							</tr>
							</ItemTemplate>
						</asp:Repeater>
						</tbody>				  
						<%--<tfoot>
							<tr>
								<th>S/N</th>
								<th>Report Date</th>
								<th>Report Time</th>
								<th>Voic</th>
								<th>Isc</th>
								<th>Radiation</th>
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

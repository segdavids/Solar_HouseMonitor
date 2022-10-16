<%@ Page Title="" Language="C#" MasterPageFile="~/main/solar.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="summary.aspx.cs" Inherits="solar_monitor.main.summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>FHIT Monitor - Summary</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                        <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                        <asp:Literal ID="Literal4" runat="server"></asp:Literal>
                        <asp:Literal ID="Literal5" runat="server"></asp:Literal>

    <section class="content">
			<div id="alert" runat="server" visible="false" class="alert alert-danger col-xl-6 offset-md-3">
				<span id="innertext" runat="server">test</span>
			  </div>
			<div class="row">
				<div class="col-xl-8">	
					
				
					
					<div class="row">

						<asp:Repeater ID="Repeater25" runat="server">
							<ItemTemplate>
						<div class="col-lg-4 col-12" style="height:100px">
                            <a href="#" class="box pull-up">
                                <div class="box-header with-border " style="background-color:#4e8cc7;">
                                    <h4 class="m-0"> STRING 1 --  <%# Convert.ToDateTime(Eval("Date")).ToString("ddd dd/MM") %> | <%# Eval("time") %></h4> 
                                </div>
                               <div class="box-body">
                                    <div class="row">
                                        <div class="col-6">
<%--											 <i class="wi-day-sunny fs-20"></i>--%>
											<div class="fs-30 grey-700">
                                               <%# Eval("voltage") %>
						<span class="fs-20">V</span>
                                            </div>
											
                                           
                                        </div>
                                        <div class="col-6 text-end">
                                            <div class="fs-30 grey-700">
                                                <%# Eval("SCurrent") %>
						<span class="fs-20">A</span>
                                            </div>
<%--                                            <div class="fs-14"> <%# Convert.ToDateTime(Eval("Date")).ToString("ddd dd/MM") %> | <%# Eval("time") %> </div>--%>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-body -->

                            </a>

							</div>
								</ItemTemplate>
							</asp:Repeater>
						<asp:Repeater ID="Repeater2" runat="server">
							<ItemTemplate>
						<div class="col-lg-4 col-12">
                            <a href="#" class="box pull-up">
                                <div class="box-header with-border " style="background-color:#4e8cc7">
                                    <h4 class="m-0"> STRING 2 --  <%# Convert.ToDateTime(Eval("Date")).ToString("ddd dd/MM") %> | <%# Eval("time") %></h4> 
                                </div>
                               <div class="box-body">
                                  <div class="row">
                                        <div class="col-6">
<%--											 <i class="wi-day-sunny fs-20"></i>--%>
											<div class="fs-30 grey-700">
                                               <%# Eval("voltage") %>
						<span class="fs-20">V</span>
                                            </div>
											
                                           
                                        </div>
                                        <div class="col-6 text-end">
                                            <div class="fs-30 grey-700">
                                                <%# Eval("SCurrent") %>
						<span class="fs-20">A</span>
                                            </div>
<%--                                            <div class="fs-14"> <%# Convert.ToDateTime(Eval("Date")).ToString("ddd dd/MM") %> | <%# Eval("time") %> </div>--%>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-body -->

                            </a>

							</div>
								</ItemTemplate>
							</asp:Repeater>
						<asp:Repeater ID="Repeater4" runat="server">
							<ItemTemplate>
						<div class="col-lg-4 col-12">
                            <a href="#" class="box pull-up">
                                <div class="box-header with-border " style="background-color:#4e8cc7">
                                    <h4 class="m-0"> STRING 3 --  <%# Convert.ToDateTime(Eval("Date")).ToString("ddd dd/MM") %> | <%# Eval("time") %></h4> 
                                </div>
                               <div class="box-body">
                                     <div class="row">
                                        <div class="col-6">
<%--											 <i class="wi-day-sunny fs-20"></i>--%>
											<div class="fs-30 grey-700">
                                               <%# Eval("voltage") %>
						<span class="fs-20">V</span>
                                            </div>
											
                                           
                                        </div>
                                        <div class="col-6 text-end">
                                            <div class="fs-30 grey-700">
                                                <%# Eval("SCurrent") %>
						<span class="fs-20">A</span>
                                            </div>
                                            
                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-body -->

                            </a>

							</div>
								</ItemTemplate>
							</asp:Repeater>
						<asp:Repeater ID="Repeater6" runat="server">
							<ItemTemplate>
						<div class="col-lg-4 col-12">
                            <a href="#" class="box pull-up">
                                <div class="box-header with-border " style="background-color:#4e8cc7">
                                    <h4 class="m-0"> STRING 4 --  <%# Convert.ToDateTime(Eval("Date")).ToString("ddd dd/MM") %> | <%# Eval("time") %></h4> 
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-6">
<%--											 <i class="wi-day-sunny fs-20"></i>--%>
											<div class="fs-30 grey-700">
                                               <%# Eval("voltage") %>
						<span class="fs-20">V</span>
                                            </div>
											
                                           
                                        </div>
                                        <div class="col-6 text-end">
                                            <div class="fs-30 grey-700">
                                                <%# Eval("SCurrent") %>
						<span class="fs-20">A</span>
                                            </div>
<%--                                            <div class="fs-14"> <%# Convert.ToDateTime(Eval("Date")).ToString("ddd dd/MM") %> | <%# Eval("time") %> </div>--%>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-body -->

                            </a>

							</div>
								</ItemTemplate>
							</asp:Repeater>
						<asp:Repeater ID="Repeater7" runat="server">
							<ItemTemplate>
						<div class="col-lg-4 col-12">
                            <a href="#" class="box pull-up">
                                <div class="box-header with-border " style="background-color:#4e8cc7">
                                    <h4 class="m-0"> STRING 5 --  <%# Convert.ToDateTime(Eval("Date")).ToString("ddd dd/MM") %> | <%# Eval("time") %></h4> 
                                </div>
                               <div class="box-body">
                                    <div class="row">
                                        <div class="col-6">
<%--											 <i class="wi-day-sunny fs-20"></i>--%>
											<div class="fs-30 grey-700">
                                               <%# Eval("voltage") %>
						<span class="fs-20">V</span>
                                            </div>
											
                                           
                                        </div>
                                        <div class="col-6 text-end">
                                            <div class="fs-30 grey-700">
                                                <%# Eval("SCurrent") %>
						<span class="fs-20">A</span>
                                            </div>
<%--                                            <div class="fs-14"> <%# Convert.ToDateTime(Eval("Date")).ToString("ddd dd/MM") %> | <%# Eval("time") %> </div>--%>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-body -->

                            </a>

							</div>
								</ItemTemplate>
							</asp:Repeater>

						<div class="col-lg-4 col-12">
							<div class="box bs-5 border-warning rounded mb-10 pull-up">
							<div class="box-body" >	
								<div class="flex-grow-1">	
									<%--<div class="d-flex align-items-center pe-2 justify-content-between">							
										<h4 class="fw-500">
											H6 Summary for Today
										</h4>
														
									</div>--%>
									<%--<p class="fs-16">
										Distribution
									</p>--%>
									</div>
                                <div id="carousel-example-generic-Controls" class="carousel slide" data-bs-ride="carousel">
                                    <div class="carousel-inner" role="listbox">
                                        <div class="carousel-item active">
                                            <div class="card-info">

                                                <h5><i class="fa fa-tasks"></i>String | Date</h5>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="icon bg-success-light rounded-circle w-40 h-40 text-center l-h-60">
                                                            <span class="fs-30 fa fa-bolt"><span class="path1"></span><span class="path2"></span><span class="path3"></span><span class="path4"></span></span>
                                                        </div>
                                                        <h5 class="card-title mb-0 me-2">Volts</h5>
                                                        <small class="text-muted" style="color: white; font-weight: bold">VOP</small>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="icon bg-success-light rounded-circle w-40 h-40 text-center l-h-60">
                                                                    <span class="fs-30 fa fa-plug"><span class="path1"></span><span class="path2"></span><span class="path3"></span><span class="path4"></span></span>
                                                        </div>
                                                        <h5 class="card-title mb-0 me-2">Amps.</h5>
                                                        <small class="text-muted" style="color: white; font-weight: bold">Isc</small>
                                                    </div>
                                                   <%-- <div class="col-md-4">
                                                        <div class="icon bg-warning-light rounded-circle w-40 h-40 text-center l-h-60">
                                                                    <span class="fs-30 fa fa-exclamation-triangle"><span class="path1"></span><span class="path2"></span><span class="path3"></span><span class="path4"></span></span>
                                                        </div>
                                                        <h5 class="card-title mb-0 me-2">Rad</h5>
                                                        <small class="text-muted" style="color: white; font-weight: bold">Radiation</small>
                                                    </div>--%>
                                                </div>
                                            </div>
                                        </div>
										
                                        <asp:Repeater ID="repeater1" runat="server">
                                            <ItemTemplate>
                                                <div class="carousel-item ">
                                                    <div class="card-info">
                                                        <h5><i class="fa fa-tasks"></i>String<%# Eval("String_No") %>  | <%# Convert.ToDateTime(Eval("Date")).ToString("dd, MMM yyyy") %> <%# Eval("Time") %></h5>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="icon bg-success-light rounded-circle w-40 h-40 text-center l-h-60">
                                                                    <span class="fs-30 fa fa-bolt"><span class="path1"></span><span class="path2"></span><span class="path3"></span><span class="path4"></span></span>
                                                                </div>
                                                                <h5 class="card-title mb-0 me-2"><%# Eval("Voc") %></h5>
                                                                <small class="text-muted" style="color: white; font-weight: bold">VOC</small>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="icon bg-success-light rounded-circle w-40 h-40 text-center l-h-60">
                                                                    <span class="fs-30 fa fa-plug"><span class="path1"></span><span class="path2"></span><span class="path3"></span><span class="path4"></span></span>
                                                                </div>
                                                                <h5 class="card-title mb-0 me-2"><%# Eval("Isc") %></h5>
                                                                <small class="text-muted" style="color: white; font-weight: bold">ISC</small>
                                                            </div>
                                                           <%-- <div class="col-md-4">
                                                                <div class="icon bg-warning-light rounded-circle w-40 h-40 text-center l-h-60">
                                                                    <span class="fs-30 fa fa-exclamation-triangle"><span class="path1"></span><span class="path2"></span><span class="path3"></span><span class="path4"></span></span>
                                                                </div>
                                                                <h5 class="card-title mb-0 me-2"><%# Eval("Radiation") %></h5>
                                                                <small class="text-muted" style="color: white; font-weight: bold">Radiation</small>
                                                            </div>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>

                                </div>

								
							</div>					
						</div>
						</div>
					
					
					</div>
					
					
				</div>
				<div class="col-xl-4 col-12">
					<div class="box bg-warning" style="height:250px">
						<div class="box-body d-flex px-0">
							<div class="flex-grow-1 p-30 flex-grow-1 bg-img dask-bg bg-none-md" >
								<div class="row">
									<div class="col-12 col-xl-7">
										<h4>Welcome back,  <strong><span id="firstnametxt" runat="server">FHIT Admin</span></strong></h4>

                                            <asp:Repeater ID="Repeater5" runat="server">
                                                <ItemTemplate>

                                                    <div class="mb-30 weather-icon">

														  <span class="fs-18"> <b><%=DateTime.Now.ToString("dd, MMM yyyy HH:mm") %></b> </span><br />
															<b><%# Eval("todaytemp") %>°C | <%# Eval("weatherDesc").ToString().ToUpper() %> </b>
														
                                                       <img class="me-40 text-top" alt="" style="height: 90px; width: 90px; margin-bottom: 100px" src="<%# Eval("icon") %>"><br />
																
													
                                                        <div class="d-inline-block">
                                                      a      <span class="fs-40">
                                                            </span>
															<div class="box-controls pull-right d-md-flex d-none">
							
							</div>
                                                            <p class="text-start" style="color:white;"></p>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
										
									</div>
								</div>
							</div>
						</div>
					</div>
					<%--<div class="box no-shadow mb-0 bg-transparent">
						<div class="box-header no-border px-0">
							<h4 class="box-title">Averages</h4>							
							<div class="box-controls pull-right d-md-flex d-none">
							  <span><b>Date:</b> <%=DateTime.Now.ToString("dd/MMM/yyyy HH:mm") %> </span>
							</div>
						</div>
					</div>
					<div>
						
					
					</div>--%>						
							
				

<%--					<div class="box">
						<div class="box-header with-border">
						<h4 class="box-title">	Average  Voltage Analysis (Strings 1-5)</h4>
						</div>
						<div class="box-body">
							<div id="piechart_3d2" style="height: 400px"></div>
							<h3 class="mt-0"><span class="badge badge-sm badge-dot badge-primary me-5">
												</span>	<span style="font-size:small">All units in Voltage(V)</span>
									
									</h3>
						</div>
					</div>--%>
				<%--	<div class="box">
						<div class="box-header with-border">
<h4 class="box-title">Average  Current Analysis (Strings 1-5)</h4>				
						</div>
						<div class="box-body">
							<div id="pie_chart" style="height: 400px"></div>
							<h3 class="mt-0"><span class="badge badge-sm badge-dot badge-primary me-5">
												</span>	<span style="font-size:small">All units in Amps(A)</span>
									
									</h3>
						</div>
					</div>--%>
						
					<div>
						<asp:Repeater ID="repeater3" runat="server">
							<ItemTemplate>
						<div class="box mb-15 pull-up">
							<div class="box-body">
								<div class="d-flex align-items-center justify-content-between">
									<div class="d-flex align-items-center">
										<div class="me-15 bg-success-light h-50 w-50 l-h-60 rounded text-center">
											<span class="fa fa-anchor fs-24"><span class="path1"></span><span class="path2"></span></span>
										</div>
										<div class="d-flex flex-column fw-500">
											<a href="#" class="text-dark hover-primary mb-1 fs-16">Anchor:  <%#  Eval("anchor") %></a>
											<span class="text-fade">Total Plot Mapped: <%# String.Format("{0:N2}", Eval("totalhec")) %> Ha</span>
										</div>
									</div>
									<a href="#">
										<span class="icon-Arrow-right fs-24"><span class="path1"></span><span class="path2"></span></span>
									</a>
								</div>
							</div>
						</div>
						</ItemTemplate>
							</asp:Repeater>
					</div>		
				
				</div>
					
						<div class="col-lg-12">
							<div class="box">
								<div class="box-header">
									<h4 class="box-title">Featured Graphical Representation</h4>
								</div>
								<div class="box-body">
									<h3 class="mt-0"><span class="badge badge-sm badge-dot badge-primary me-5">
												</span>	<span style="font-size:small">Voltage</span>
										<span class="badge badge-sm badge-dot badge-danger me-5">
												 </span>	<span style="font-size:small">Current</span>
										<span class="badge badge-sm badge-dot badge-warning me-5">
												 </span>	<span style="font-size:small">Power</span>
									</h3>
									<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
									 <div id="chartt_div" style="height: 500px; width: 100%"></div>
								</div>
							</div>
						
						</div>

				<div class="box">
						<div class="box-header">
							<h4 class="box-title">H6 Summary Today</h4>
							
						</div>
						<div class="box-body">


			
				<!-- /.box-header -->
				<div class="box-body">
					<div class="table-responsive">
					  <table id="example" class="table table-bordered table-hover display nowrap margin-top-10 w-p100">
						<thead>
							<tr>
								<th>S/N</th>
								<th>Date/Time</th>
								<th>String</th>
								<th>Voc</th>
								<th>Isc</th>
<%--								<th>Radiation</th>--%>
							</tr>
						</thead>
						<tbody>
							<asp:Repeater ID="repeater34" runat="server">
								<ItemTemplate>
							<tr>
								<td><%#Container.ItemIndex+1 %></td>
								<td><%# Convert.ToDateTime(Eval("DateTime")).ToString("dd/MMM/yyyy HH:mm") %></td>
								<td><%# Eval("String_No") %></td>
								<td><%# Eval("Voc") %></td>
								<td><%# Eval("isc") %></td>
							<%--	<td><%# Eval("Radiation") %></td>--%>
							</tr>
							</ItemTemplate>
								</asp:Repeater>							
						</tbody>				  
					
					</table>
					</div>              
				</div>
				<!-- /.box-body -->



						</div>
					</div>
			</div>
		</section>
</asp:Content>

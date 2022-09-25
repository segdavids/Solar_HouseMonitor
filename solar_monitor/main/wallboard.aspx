<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wallboard.aspx.cs" Inherits="solar_monitor.main.wallboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">

    
	<!-- Vendors Style-->
	<link rel="stylesheet" href="css/vendors_css.css">
	  
	<!-- Style-->  
	<link rel="stylesheet" href="css/horizontal-menu.css"> 
	<link rel="stylesheet" href="css/style.css">
	<link rel="stylesheet" href="css/skin_color.css">
    <title>FHIT Monitor | Wallboard</title>
</head>

<body class="layout-top-nav skin-green theme-primary">
    <form id="form1" runat="server">
        <div class="wrapper">
	<div id="loader"></div>
        </div>
           <header class="main-header">
	<div class="d-flex align-items-center logo-box justify-content-start">
		<a href="#" class="waves-effect waves-light nav-link d-none d-md-inline-block mx-10 push-btn bg-transparent" data-toggle="push-menu" role="button">
			<span class="icon-Align-left"><span class="path1"></span><span class="path2"></span><span class="path3"></span></span>
		</a>	
		<!-- Logo -->
		<a href="/main/summary" class="logo">
		  <!-- logo-->
		  <div class="logo-lg">
			  <span class="light-logo"><img src="../images/logo-removebg-preview.png" alt="logo"></span>
			  <span class="dark-logo"><img src="../images/logo-removebg-preview.png" alt="logo"></span>
		  </div>
		</a>	
	</div>  
    <!-- Header Navbar -->
    <nav class="navbar navbar-static-top">
      <!-- Sidebar toggle button-->
	  <div class="app-menu">
		<ul class="header-megamenu nav">
			<li class="btn-group nav-item d-md-none">
				<a href="#" class="waves-effect waves-light nav-link push-btn" data-toggle="push-menu" role="button">
					<span class="icon-Align-left"><span class="path1"></span><span class="path2"></span><span class="path3"></span></span>
			    </a>
			</li>
			<li class="btn-group nav-item d-none d-xl-inline-block">
				<a href="/main/summary" class="waves-effect waves-light nav-link svg-bt-icon" title="Summary Home">
					<i class="fa fa-home"><span class="path1"></span><span class="path2"></span></i>
			    </a>
			</li>
			<%--<li class="btn-group nav-item d-none d-xl-inline-block">
				<a href="/history_forecast" class="waves-effect waves-light nav-link svg-bt-icon" title="Forecast & History">
					<i class="wi wi-day-sleet"><span class="path1"></span><span class="path2"></span></i>
			    </a>
			</li>--%>
			<li class="btn-group nav-item d-none d-xl-inline-block">
				<a href="/main/strings" class="waves-effect waves-light nav-link svg-bt-icon" title="Report">
					<i class="icon-Clipboard-check"><span class="path1"></span><span class="path2"></span><span class="path3"></span></i>
			    </a>
			</li>
		</ul> 
	  </div>
		
      <div class="navbar-custom-menu r-side">
        <ul class="nav navbar-nav">	
			<li class="btn-group nav-item d-lg-inline-flex d-none">
				<a href="#" data-provide="fullscreen" class="waves-effect waves-light nav-link full-screen" title="Full Screen">
					<i class="icon-Expand-arrows"><span class="path1"></span><span class="path2"></span></i>
			    </a>
			</li>	  
		
		  <!-- Notifications -->
		  <li class="dropdown notifications-menu">
			<a href="#" class="waves-effect waves-light dropdown-toggle" data-bs-toggle="dropdown" title="Notifications">
			  <i class="icon-Notifications"><span class="path1"></span><span class="path2"></span></i>
			</a>
			<ul class="dropdown-menu animated bounceIn">

			  <li class="header">
				<div class="p-20">
					<div class="flexbox">
						<div>
							<h4 class="mb-0 mt-0">Notifications</h4>
						</div>
						<div>
						</div>
					</div>
				</div>
			  </li>

			  <li>
				<!-- inner menu: contains the actual data -->
				<ul class="menu sm-scrol">
				  <li>
					<a href="#">
					  <i class="fa fa-stop text-success"></i> No Notifications to show
					</a>
				  </li>
				
				</ul>
			  </li>
			
			</ul>
		  </li>	
		  
	      <!-- User Account-->
          <li class="dropdown user user-menu">
            <a href="#" class="waves-effect waves-light dropdown-toggle" data-bs-toggle="dropdown" title="User">
				<i class="icon-User"><span class="path1"></span><span class="path2"></span></i>
            </a>
            <ul class="dropdown-menu animated flipInX">
              <li class="user-body">
				 <a class="dropdown-item" href="#"><i class="ti-user text-muted me-2"></i> Profile</a>
				 <a class="dropdown-item" href="#"><i class="ti-wallet text-muted me-2"></i> Documentation</a>
				 <a class="dropdown-item" href="#"><i class="ti-settings text-muted me-2"></i> Settings</a>
				 <div class="dropdown-divider"></div>
				 <a class="dropdown-item" href="/"><i class="ti-lock text-muted me-2"></i> Logout</a>
              </li>
            </ul>
          </li>	
		  
          <!-- Control Sidebar Toggle Button -->
        
			
        </ul>
      </div>
    </nav>
  </header>
		 <div class="content-wrapper">
			 <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                        <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                        <asp:Literal ID="Literal4" runat="server"></asp:Literal>
                        <asp:Literal ID="Literal5" runat="server"></asp:Literal>
	  <div class="container-full">
					<div id="carousel-example-generic-Indicators" class="carousel slide" data-bs-ride="carousel"> 
              <!-- Wrapper for slides -->
                                    <div class="carousel-inner" role="listbox">
                                        <div class="carousel-item active">
                                            <div class="card-info">
                                                <section class="content">
			<div id="alert" runat="server" visible="false" class="alert alert-danger col-xl-6 offset-md-3">
				<span id="innertext" runat="server">test</span>
			  </div>
			<div class="row">
				<div class="col-xl-12">	
					
				
					
					<div class="row">

						<asp:Repeater ID="Repeater25" runat="server">
							<ItemTemplate>
						<div class="col-lg-3 col-12">
                            <a href="#" class="box pull-up">
                                <div class="box-header with-border " style="background-color:#4e8cc7">
                                    <h4 class="m-0"><i class="fa fa-tasks"></i> STRING 1</h4>
                                </div>
                               <div class="box-body">
                                    <div class="row">
                                        <div class="col-6">
<%--											 <i class="wi-day-sunny fs-20"></i>--%>
											<div class="fs-40 grey-700">
                                               <%# Eval("voltage") %>
						<span class="fs-20">V</span>
                                            </div>
											
                                           
                                        </div>
                                        <div class="col-6 text-end">
                                            <div class="fs-40 grey-700">
                                                <%# Eval("SCurrent") %>
						<span class="fs-20">A</span>
                                            </div>
                                            <div class="fs-14"> <%# Convert.ToDateTime(Eval("Date")).ToString("ddd dd/MM") %> | <%# Eval("time") %> </div>
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
						<div class="col-lg-3 col-12">
                            <a href="#" class="box pull-up">
                                <div class="box-header with-border " style="background-color:#4e8cc7">
                                    <h4 class="m-0"><i class="fa fa-tasks"></i> STRING 2</h4>
                                </div>
                               <div class="box-body">
                                  <div class="row">
                                        <div class="col-6">
<%--											 <i class="wi-day-sunny fs-20"></i>--%>
											<div class="fs-40 grey-700">
                                               <%# Eval("voltage") %>
						<span class="fs-20">V</span>
                                            </div>
											
                                           
                                        </div>
                                        <div class="col-6 text-end">
                                            <div class="fs-40 grey-700">
                                                <%# Eval("SCurrent") %>
						<span class="fs-20">A</span>
                                            </div>
                                            <div class="fs-14"> <%# Convert.ToDateTime(Eval("Date")).ToString("ddd dd/MM") %> | <%# Eval("time") %> </div>
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
						<div class="col-lg-3 col-12">
                            <a href="#" class="box pull-up">
                                <div class="box-header with-border " style="background-color:#4e8cc7">
                                    <h4 class="m-0"><i class="fa fa-tasks"></i> STRING 3</h4>
                                </div>
                               <div class="box-body">
                                     <div class="row">
                                        <div class="col-6">
<%--											 <i class="wi-day-sunny fs-20"></i>--%>
											<div class="fs-40 grey-700">
                                               <%# Eval("voltage") %>
						<span class="fs-20">V</span>
                                            </div>
											
                                           
                                        </div>
                                        <div class="col-6 text-end">
                                            <div class="fs-40 grey-700">
                                                <%# Eval("SCurrent") %>
						<span class="fs-20">A</span>
                                            </div>
                                            <div class="fs-14"> <%# Convert.ToDateTime(Eval("Date")).ToString("ddd dd/MM") %> | <%# Eval("time") %> </div>
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
						<div class="col-lg-3 col-12">
                            <a href="#" class="box pull-up">
                                <div class="box-header with-border " style="background-color:#4e8cc7">
                                    <h4 class="m-0"><i class="fa fa-tasks"></i> STRING 4</h4>
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-6">
<%--											 <i class="wi-day-sunny fs-20"></i>--%>
											<div class="fs-40 grey-700">
                                               <%# Eval("voltage") %>
						<span class="fs-20">V</span>
                                            </div>
											
                                           
                                        </div>
                                        <div class="col-6 text-end">
                                            <div class="fs-40 grey-700">
                                                <%# Eval("SCurrent") %>
						<span class="fs-20">A</span>
                                            </div>
                                            <div class="fs-14"> <%# Convert.ToDateTime(Eval("Date")).ToString("ddd dd/MM") %> | <%# Eval("time") %> </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-body -->

                            </a>

							</div>
								</ItemTemplate>
							</asp:Repeater>
					
					
					</div>
					
					
				</div>
				<div class="col-xl-4 col-12">
					
			<%--		<div class="box no-shadow mb-0 bg-transparent">
						<div class="box-header no-border px-0">
							<h4 class="box-title">Averages</h4>							
							<div class="box-controls pull-right d-md-flex d-none">
							  <span><b>Date:</b> <%=DateTime.Now.ToString("dd/MMM/yyyy HH:mm") %> </span>
							</div>
						</div>
					</div>--%>
								
							
				

					<%--<div class="box">
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
					<%--<div class="box">
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
									</h3>
									<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
									 <div id="chartt_div" style="height: 600px; width: 100%"></div>
<%--									<div id="charts_widget_2_chart"></div>--%>
								</div>
							</div>
						
						</div>
			</div>
		</section>
                                            </div>
                                        </div>

                                        <div class="carousel-item">
                                            <div class="card-info">
                                                <section class="content">
                                                    <div id="Div1" runat="server" visible="false" class="alert alert-danger col-xl-6 offset-md-3">
                                                        <span id="Span1" runat="server">test</span>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-xl-8">
                                                            <div class="row">
																
						<asp:Repeater ID="Repeater7" runat="server">
							<ItemTemplate>
						<div class="col-lg-4 col-12">
                            <a href="#" class="box pull-up">
                                <div class="box-header with-border " style="background-color:#4e8cc7">
                                    <h4 class="m-0"><i class="fa fa-tasks"></i> STRING 5</h4>
                                </div>
                               <div class="box-body">
                                    <div class="row">
                                        <div class="col-6">
<%--											 <i class="wi-day-sunny fs-20"></i>--%>
											<div class="fs-40 grey-700">
                                               <%# Eval("voltage") %>
						<span class="fs-20">V</span>
                                            </div>
											
                                           
                                        </div>
                                        <div class="col-6 text-end">
                                            <div class="fs-40 grey-700">
                                                <%# Eval("SCurrent") %>
						<span class="fs-20">A</span>
                                            </div>
                                            <div class="fs-14"> <%# Convert.ToDateTime(Eval("Date")).ToString("ddd dd/MM") %> | <%# Eval("time") %> </div>
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
									<div class="d-flex align-items-center pe-2 justify-content-between">							
										<h4 class="fw-500">
											H6 Summary for Today
										</h4>
														
									</div>
									
									</div>
                            

								
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
                                                                                            <th>Report Date</th>
                                                                                            <th>Report Time (24 Hrs)</th>
                                                                                            <th>Voic</th>
                                                                                            <th>Isc</th>
                                                                                            <th>Radiation</th>
                                                                                        </tr>
                                                                                    </thead>
                                                                                    <tbody>
                                                                                        <asp:Repeater ID="repeater34" runat="server">
                                                                                            <ItemTemplate>
                                                                                                <tr>
                                                                                                    <td><%#Container.ItemIndex+1 %></td>
                                                                                                    <td><%# Convert.ToDateTime(Eval("Date")).ToString("dd/MMM/yyyy") %></td>
                                                                                                    <td><%# Eval("Time") %></td>
                                                                                                    <td><%# Eval("Voc") %></td>
                                                                                                    <td><%# Eval("isc") %></td>
                                                                                                    <td><%# Eval("Radiation") %></td>
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
                                                        </div>

                                                        <div class="col-xl-4 col-12">
                                                           <div class="box bg-warning" style="height:250px">
						<div class="box-body d-flex px-0">
							<div class="flex-grow-1 p-30 flex-grow-1 bg-img dask-bg bg-none-md" >
								<div class="row">
									<div class="col-12 col-xl-7">
										<h3>Welcome back, FHIT Admin <strong><span id="firstnametxt" runat="server"></span></strong></h3>

                                            <asp:Repeater ID="Repeater5" runat="server">
                                                <ItemTemplate>

                                                    <div class="mb-30 weather-icon">

														  <span class="fs-18"> <b><%=DateTime.Now.ToString("dd, MMM yyyy HH:mm") %></b> </span><br />
															<b><%# Eval("todaytemp") %>°C </b> <%# Eval("weatherDesc").ToString().ToUpper() %>
														
                                                       <img class="me-40 text-top" alt="" style="height: 90px; width: 90px; margin-bottom: 100px" src="<%# Eval("icon") %>"><br />
																
													
                                                        <div class="d-inline-block">
                                                            <span class="fs-40">
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
                                                        </div>
                                                    </div>
                                                </section>
                                        </div>
											</div>
                                    </div>
          </div>

		  </div>
	  </div>
		 <footer class="main-footer col-12">
   
	  &copy; <%=DateTime.Now.Year %> <b>University of Fort Hare</b>. All Rights Reserved.
  </footer>

  <div class="control-sidebar-bg"></div>
  
    </form>
	<script src="js/vendors.min.js"></script>
	<script src="js/pages/chat-popup.js"></script>
    <script src="../assets/icons/feather-icons/feather.min.js"></script>	
	<script src="../assets/vendor_plugins/bootstrap-slider/bootstrap-slider.js"></script>
	<script src="../assets/vendor_components/OwlCarousel2/dist/owl.carousel.js"></script>
	<script src="../assets/vendor_components/flexslider/jquery.flexslider.js"></script>
	
	<!-- EduAdmin App -->
	<script src="js/template.js"></script>
	
	<script src="js/pages/slider.js"></script>
</body>
</html>

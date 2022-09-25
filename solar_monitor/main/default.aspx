<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="solar_monitor.main._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="/images/favicon.ico">

    <title>FHIT Monitor - Log in </title>
  
	<!-- Vendors Style-->
	<link rel="stylesheet" href="css/vendors_css.css">
	  
	<!-- Style-->  
	<link rel="stylesheet" href="css/style.css">
	<link rel="stylesheet" href="css/skin_color.css">	
</head>
<body class="hold-transition theme-primary bg-img" style="background-image: url(/images/61198-uv8enektyi.jpg)">
    <form id="form1" runat="server">
        <div class="container h-p100">
		<div class="row align-items-center justify-content-md-center h-p100">	
			
			<div class="col-12" style="margin-top:300px">
				<div class="row justify-content-center g-0">
					<div class="col-lg-5 col-md-5 col-12">
						<div class="bg-white rounded10 shadow-lg">
							<div class="content-top-agile p-20 pb-0">
								<h2 class="text-primary">FHIT SOLAR MONITOR</h2>
<%--								<p class="mb-0">Sign in to use this Tool.</p>							--%>
							</div>
							<div class="p-40">
								<div >
									<div class="form-group">
										<div class="input-group mb-3">
											<span class="input-group-text bg-transparent"><i class="ti-user"></i></span>
											<input type="text" class="form-control ps-15 bg-transparent" id="emailtxt" runat="server" required="required" placeholder="Username">
										</div>
									</div>
									<div class="form-group">
										<div class="input-group mb-3">
											<span class="input-group-text  bg-transparent"><i class="ti-lock"></i></span>
											<input type="password" class="form-control ps-15 bg-transparent" id="userpasswordtxt" runat="server" required="required" placeholder="Password">
										</div>
									</div>
									  <div class="row">
										<div class="col-6">
										  <div class="checkbox">
											<input type="checkbox" id="basic_checkbox_1" >
											<label for="basic_checkbox_1">Remember Me</label>
										  </div>
										</div>
										<!-- /.col -->
										<div class="col-6">
										 <div class="fog-pwd text-end">
											<a href="forgot_password" class="hover-warning"><i class="ion ion-locked"></i> Forgot password?</a><br>
										  </div>
										</div>

										    <div id="alert" runat="server" visible="false" class="alert alert-danger col-xl-8 offset-md-2">
				<span id="innertext" runat="server">test</span>
			  </div>
										<!-- /.col -->
										<div class="col-12 text-center">
											<asp:Button ID="Button1" type="button" OnClick="Button1_Click" class="btn btn-danger mt-10" runat="server" Text="SIGN IN" />
<%--										  <button type="submit" class="btn btn-danger mt-10">SIGN IN</button>--%>
										</div>
										<!-- /.col -->
									  </div>
								</div>	
								<%--<div class="text-center">
									<p class="mt-15 mb-0">Don't have an account? <a href="auth_register.html" class="text-warning ms-5">Sign Up</a></p>
								</div>	--%>
							</div>						
						</div>
						<%--<div class="text-center">
						  <p class="mt-20 text-white">- Sign With -</p>
						  <p class="gap-items-2 mb-20">
							  <a class="btn btn-social-icon btn-round btn-facebook" href="#"><i class="fa fa-facebook"></i></a>
							  <a class="btn btn-social-icon btn-round btn-twitter" href="#"><i class="fa fa-twitter"></i></a>
							  <a class="btn btn-social-icon btn-round btn-instagram" href="#"><i class="fa fa-instagram"></i></a>
							</p>	
						</div>--%>
					</div>
				</div>
			</div>
		</div>
	</div>
    </form>
</body>
	
	<!-- Vendor JS -->
	<script src="js/vendors.min.js"></script>
	<script src="js/pages/chat-popup.js"></script>
    <script src="/assets/icons/feather-icons/feather.min.js"></script>	
</html>

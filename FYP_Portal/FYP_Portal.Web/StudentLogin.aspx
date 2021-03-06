﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentLogin.aspx.cs" Inherits="FYP_Portal.Web.StudentLogin" %>


<!DOCTYPE html>
<html dir="ltr" lang="en">

<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">

<link rel="stylesheet" href="css/bootstrap.min.css">
<link rel="stylesheet" href="css/style.css">
<link rel="stylesheet" href="css/responsive.css">
<title>Student</title>
<link href="images/favicon.png" sizes="128x128" rel="shortcut icon" type="image/x-icon" />
<link href="images/favicon.png" sizes="128x128" rel="shortcut icon" />
<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

     <script type="text/javascript">
        function validateAndHighlight() {
            for (var i = 0; i < Page_Validators.length; i++) {
                var val = Page_Validators[i];
                var ctrl = document.getElementById(val.controltovalidate);
                if (ctrl != null && ctrl.style != null) {
                    if (!val.isvalid) {
                      
                        ctrl.style.borderColor = '#FF0000';
                        ctrl.style.backgroundColor = '#FFFFFF';
                    }
                    else {
                       
                        ctrl.style.borderColor = '';
                        ctrl.style.backgroundColor = '';
                    }
                }
            }
        }
	 </script> 

</head>
<body>
<div class="wrapper">
	<div class="preloader"></div>

	       <header class="header-nav menu_style_home_one dashbord_pages navbar-scrolltofixed stricky main-menu">
		<div class="container-fluid">
		    <nav>
		        <div class="menu-toggle">
		            <img class="nav_logo_img img-fluid" src="images/logo bukc.png" alt="logo-bukc.png">
		            <button type="button" id="menu-btn">
		                <span class="icon-bar"></span>
		                <span class="icon-bar"></span>
		                <span class="icon-bar"></span>
		            </button>
		        </div>
		        <a href="#" class="navbar_brand float-left dn-smd">
		            <img class="logo1 img-fluid" src="images/logo bukc.png" alt="logo-bukc.png">
		            <img class="logo2 img-fluid" src="images/logo bukc.png" alt="logo-bukc.png">
		            <span>Bahria</span>
		        </a>
		      
                <ul id="respMenu" class="ace-responsive-menu" data-menu-style="horizontal">
		           <li>
		                <a href="Default.aspx"><span class="title">Home</span></a>		               
		            </li>

		             <li>
		                <a href="FYPCoordinatorLogin.aspx"><span class="title">FYP Coordinator</span></a>
		            </li>

		            <li>
		                <a href="SupervisorLogin.aspx"><span class="title">Supervisor</span></a>
		            </li>
				           
                    <li>
				        <a href="StudentLogin.aspx"><span class="title">Student</span></a>
				    </li>
		                   
		            <li>
		                <a href="AboutUs.aspx"><span class="title">About Us</span></a>		              
		            </li>

		            <li>
		                <a href="Contact.aspx"><span class="title">Contact</span></a>
		            </li>
		        </ul>
		    </nav>
		</div>
	</header>

    <div id="page" class="stylehome1 h0">
		<div class="mobile-menu">

			<div class="header stylehome1 dashbord_mobile_logo dashbord_pages">
				<div class="main_logo_home2">
		            <img class="nav_logo_img img-fluid float-left mt20" src="images/logo bukc.png" alt="header-logo.png">
		            <span>Bahria</span>
				</div>
				<ul class="menu_bar_home2">
					<li class="list-inline-item"></li>
					<li class="list-inline-item">
                      <a href="#menu"><span></span></a>
					</li>
				</ul>
			</div>
		</div>
		<nav id="menu" class="stylehome1">
			<ul>
		        <li><a href="Default.aspx">Home</a></li>
                <li><a href="FYPCoordinatorLogin.aspx">FYP Coordinator</a></li>
                <li><a href="SupervisorLogin.aspx">Supervisor </a></li> 
                <li><a href="StudentLogin.aspx">Student</a></li>
                <li><a href="AboutUs.aspx">About Us</a></li>
				<li><a href="Contact.aspx">Contact</a></li>				
			</ul>
		</nav>
	</div>

    <br /><br /><br />

	<section class="our-log bgc-fa">
		<div class="container">
			<div class="row">
				<div class="col-sm-12 col-lg-6 offset-lg-3">
					<div class="login_form inner_page">
						<form action="#" runat="server">
							<div class="heading">
								<h3 class="text-center">STUDENT LOGIN</h3>
							</div>

							 <div class="form-group">
                                 <label class="control-label"> Enrollment
 <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="enroll" Display="Dynamic" 
     ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator></label>
<asp:TextBox ID="enroll" type="text" class="form-control" runat="server" placeholder="ENROLLMENT"></asp:TextBox>
							 </div>

							<div class="form-group">
                                <label class="control-label"> Password 

<asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="pwd" Display="Dynamic" 
    ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator></label> 
  <asp:TextBox ID="pwd" type="password" class="form-control" runat="server" placeholder="Password" ></asp:TextBox>
							</div>
    
<div class="form-group">
   <label class="control-label"> Institute 
           
      <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="inst" Display="Dynamic" InitialValue="Select"
      ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator></label>

 <asp:DropDownList ID="inst" class="form-control" runat="server">
                               <asp:Listitem Value="Select" ></asp:Listitem>
                               <asp:Listitem Value="Islamabad Campus" ></asp:Listitem>
                               <asp:Listitem Value="Karachi Campus" ></asp:Listitem>
                               <asp:Listitem Value="Lahore Campus" ></asp:Listitem>
   </asp:DropDownList>	
</div>

   <div class="form-group custom-control custom-checkbox">                                
		<a class="tdu btn-fpswd float-right" href="StudentForgotPassword.aspx">Forgot Password?</a>
   </div>
                            
     <div class="form-group">
  <asp:Button class="btn btn-log btn-block btn-thm2" ID="BtnStdLogin" style="margin-left:auto;margin-right:auto;display:block;border-radius:6px" Width="200px" runat="server" Text="Login" OnClick="BtnStdLogin_Click1" />
			</div>				
						</form>
					</div>
				</div>
			</div>
		</div>
	</section>
    <a class="scrollToHome" href="#"><i class="flaticon-up-arrow-1"></i></a>
</div>

<script type="text/javascript" src="js/jquery-3.3.1.js"></script>
<script type="text/javascript" src="js/jquery-migrate-3.0.0.min.js"></script>
<script type="text/javascript" src="js/popper.min.js"></script>
<script type="text/javascript" src="js/bootstrap.min.js"></script>
<script type="text/javascript" src="js/jquery.mmenu.all.js"></script>
<script type="text/javascript" src="js/ace-responsive-menu.js"></script>
<script type="text/javascript" src="js/bootstrap-select.min.js"></script>
<script type="text/javascript" src="js/snackbar.min.js"></script>
<script type="text/javascript" src="js/simplebar.js"></script>
<script type="text/javascript" src="js/parallax.js"></script>
<script type="text/javascript" src="js/scrollto.js"></script>
<script type="text/javascript" src="js/jquery-scrolltofixed-min.js"></script>
<script type="text/javascript" src="js/jquery.counterup.js"></script>
<script type="text/javascript" src="js/wow.min.js"></script>
<script type="text/javascript" src="js/progressbar.js"></script>
<script type="text/javascript" src="js/slider.js"></script>
<script type="text/javascript" src="js/timepicker.js"></script>
<script type="text/javascript" src="js/wow.min.js"></script>
<script type="text/javascript" src="js/script.js"></script>
</body>
</html>



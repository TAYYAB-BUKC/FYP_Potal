﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDashboard.aspx.cs" Inherits="FYP_Portal.Web.StudentDashboard" %>

<!DOCTYPE html>
<html dir="ltr" lang="en">

<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">    
<link rel="stylesheet" href="css/bootstrap.min.css">
<link rel="stylesheet" href="css/style.css">
<link rel="stylesheet" href="css/dashbord_navitaion.css">
<link rel="stylesheet" href="css/responsive.css">
<title>Dashboard</title>
<link href="images/favicon.png" sizes="128x128" rel="shortcut icon" type="image/x-icon" />
<link href="images/favicon.png" sizes="128x128" rel="shortcut icon" />
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
		                <a href="Home.aspx"><span class="title">Home</span></a>		               
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

		        <ul class="header_user_notif pull-right dn-smd">
	                <li class="user_setting">
						<div class="dropdown">
	                		<a class="btn dropdown-toggle" href="#" data-toggle="dropdown">
                                  <img class="rounded-circle" runat="server" id="profileImage" src="" alt="profile.png"></a>
						    <div class="dropdown-menu">
						    	<div class="user_set_header">
                                      <img class="rounded-circle" id="p" runat="server" alt="profile.png" src="" />
                                    <br /> <br /> 
							    	<p id="sname" runat="server"></p>
						    	</div>
						    	<div class="user_setting_content">
									<a class="dropdown-item active" id="sp" runat="server" href="StudentEditProfile.aspx">Edit Profile</a>
									<a class="dropdown-item" id="cp" runat="server" href="StudentChangePassword.aspx">Change Password</a>									
									<a class="dropdown-item" href="StudentLogin.aspx">Log out</a>
						    	</div>
						    </div>
						</div>
			        </li>
	            </ul>
		    </nav>
		</div>
	</header>

	<div id="page" class="stylehome1 h0">
		<div class="mobile-menu">
	        <ul class="header_user_notif dashbord_pages_mobile_version pull-right">
                <li class="user_setting">
					<div class="dropdown">
                		<a class="btn dropdown-toggle" href="#" data-toggle="dropdown">
                             <img class="rounded-circle" runat="server" id="profileImage1" src="" alt="profile.png">
                		</a>
					    <div class="dropdown-menu">
					    	<div class="user_set_header">
                                 <img class="rounded-circle" id="p1" runat="server" alt="profile.png" src="" />
                               <br /> <br /> 
						    	<p id="sname1" runat="server"></p>
					    	</div>
					    	<div class="user_setting_content">
								<a class="dropdown-item active" id="sp1" runat="server" href="StudentEditProfile.aspx">Edit Profile</a>
									<a class="dropdown-item" id="cp1" runat="server" href="StudentChangePassword.aspx">Change Password</a>									
									<a class="dropdown-item" href="StudentLogin.aspx">Log out</a>
					    	</div>
					    </div>
					</div>
		        </li>
            </ul>
			<div class="header stylehome1 dashbord_mobile_logo dashbord_pages">
				<div class="main_logo_home2">
		            <img class="nav_logo_img img-fluid float-left mt20" src="images/logo bukc.png" alt="logo_bukc.png">
		            <span>Bahria</span>
				</div>
				<ul class="menu_bar_home2">
					<li class="list-inline-item"></li>
					<li class="list-inline-item"><a href="#menu"><span></span></a></li>
				</ul>
			</div>
		</div>
		<nav id="menu" class="stylehome1">
			<ul>
		        <li><a href="Home.aspx">Home</a></li>
                <li><a href="FYPCoordinatorLogin.aspx">FYP Coordinator</a></li>
                <li><a href="SupervisorLogin.aspx">Supervisor </a></li> 
                <li><a href="StudentLogin.aspx">Student</a></li>
                <li><a href="AboutUs.aspx">About Us</a></li>
				<li><a href="Contact.aspx">Contact</a></li>				
			</ul>
		</nav>
	</div>

	<section class="dashboard_sidebar dn-1199">
		<div class="dashboard_sidebars">
			<div class="user_board">
				<div class="dashbord_nav_list">
					<ul>                         
<li class="active"><a id="dash" runat="server" href="StudentDashboard.aspx"><span class="flaticon-puzzle-1"></span> Dashboard</a></li>
<li><a id="pInfo" runat="server" href="StudentProfileInfo.aspx"><span class="flaticon-online-learning"></span> Profile Information</a></li>						
<li><a id="notify" runat="server" href="ViewStudentNotifications.aspx"><span class="flaticon-speech-bubble"></span> Notifications</a></li>
<li><a id="view" runat="server" href="ViewAttendance.aspx"><span class="flaticon-rating"></span>Attendance</a></li>                        
<li><a id="vst" runat="server" href="ViewSupervisorTimetable.aspx"><span class="flaticon-like"></span> Supervisor Timetable</a></li>
<li><a id="sg" runat="server" href="GradeDetailsForStudent.aspx"><span class="flaticon-rating"></span> Grades</a></li>
<li><a id="doc" runat="server" href="Documents.aspx"><span class="flaticon-add-contact"></span> Documentation</a></li>
					</ul>					
				</div>
			</div>
		</div>
	</section>

	<div class="our-dashbord dashbord">
		<div class="dashboard_main_content">
			<div class="container-fluid">
				<div class="main_content_container">
					<div class="row">
						<div class="col-lg-12">
							<div class="dashboard_navigationbar dn db-1199">
								<div class="dropdown">
<button onclick="myFunction()" class="dropbtn"><i class="fa fa-bars pr10"></i> Dashboard Navigation</button>
<ul id="myDropdown" class="dropdown-content">										
	<li class="active"><a id="dash1" runat="server" href="StudentDashboard.aspx"><span class="flaticon-puzzle-1"></span> Dashboard</a></li>
	<li><a id="pInfo1" runat="server" href="StudentProfileInfo.aspx"><span class="flaticon-online-learning"></span> Profile Information</a></li>						
	<li><a id="notify1" runat="server" href="ViewStudentNotifications.aspx"><span class="flaticon-speech-bubble"></span>Notifications</a></li>
	<li><a id="view1" runat="server" href="ViewAttendance.aspx"><span class="flaticon-rating"></span> Attendance</a></li>                       
	<li><a id="vst1" runat="server" href="ViewSupervisorTimetable.aspx"><span class="flaticon-like"></span> Supervisor Timetable</a></li>
    <li><a id="sg1" runat="server" href="GradeDetailsForStudent.aspx"><span class="flaticon-rating"></span> Grades</a></li>
	<li><a id="doc1" runat="server" href="Documents.aspx"><span class="flaticon-add-contact"></span> Documentation</a></li>
</ul>
								</div>
							</div>
						</div>

						<div class="col-lg-12">
							<nav class="breadcrumb_widgets" aria-label="breadcrumb mb30">
								<h4 class="title float-left">Dashboard</h4>
							</nav>
						</div>

                        <div class="col-xl-8">
							<div class="application_statics">
								<h4>Your Profile Views</h4>
								<div class="c_container"></div>
							</div>
						</div>	
    					
					</div>
					<div class="row mt50 mb50">
						<div class="col-lg-6 offset-lg-3">
							<div class="copyright-widget text-center">
								<p class="color-black2">Copyright © 2020 Bahria University | All Rights Reserved</p>
							<asp:Label ID="enrollment" type="hidden" runat="server" ></asp:Label>
                            </div>
						</div>
					</div>
				</div>              
			</div>
		</div>
	</div>
<a class="scrollToHome" href="#"><i class="flaticon-up-arrow-1"></i></a>
</div>

<script type="text/javascript" src="js/jquery-3.3.1.js"></script>
<script type="text/javascript" src="js/jquery-migrate-3.0.0.min.js"></script>
<script type="text/javascript" src="js/popper.min.js"></script>
<script type="text/javascript" src="js/bootstrap.min.js"></script>
<script type="text/javascript" src="js/jquery.mmenu.all.js"></script>
<script type="text/javascript" src="js/ace-responsive-menu.js"></script>
<script type="text/javascript" src="js/chart.min.js"></script>
<script type="text/javascript" src="js/chart-custome.js"></script>
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
<script type="text/javascript" src="js/dashboard-script.js"></script>
<script type="text/javascript" src="js/script.js"></script>
</body>
</html>


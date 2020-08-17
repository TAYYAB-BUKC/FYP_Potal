<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorEditProfile.aspx.cs" Inherits="FYP_Portal.Web.SupervisorEditProfile" %>

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
<title>Edit Profile</title>
<link href="images/favicon.png" sizes="128x128" rel="shortcut icon" type="image/x-icon" />
<link href="images/favicon.png" sizes="128x128" rel="shortcut icon" />

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
		            <img class="nav_logo_img img-fluid" src="images/logo bukc.png" alt="logo.png">
		            <button type="button" id="menu-btn">
		                <span class="icon-bar"></span>
		                <span class="icon-bar"></span>
		                <span class="icon-bar"></span>
		            </button>
		        </div>
		        <a href="#" class="navbar_brand float-left dn-smd">
		            <img class="logo1 img-fluid" src="images/logo bukc.png" alt="logo.png">
		            <img class="logo2 img-fluid" src="images/logo bukc.png" alt="logo.png">
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
                    <img class="rounded-circle" runat="server" id="profileImage" src="" alt="profile.png">
	                		</a>
						    <div class="dropdown-menu">
						    	<div class="user_set_header">
						    	 <img class="rounded-circle" id="p" runat="server" alt="profile.png" src="" />
							    <br /><br />
						    	<p id="spname" runat="server"> </p>
						    	</div>
						    	<div class="user_setting_content">
		<a class="dropdown-item active" id="sp" runat="server" href="SupervisorEditProfile.aspx">Edit Profile</a>
		<a class="dropdown-item" id="cp" runat="server" href="SupervisorChangePassword.aspx">Change Password</a>							
		<a class="dropdown-item" href="SupervisorLogin.aspx">Log out</a>
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
                           <img class="rounded-circle" runat="server" id="profileImage1" src="" alt="profile.png"></a>
					    <div class="dropdown-menu">
					    	<div class="user_set_header">
					    	   <img id="p1" runat="server" alt="profile.png" src="" />
                              <br /><br />
						    	<p id="spname1" runat="server"> </p>
					    	</div>
					    	<div class="user_setting_content">
	<a class="dropdown-item active" id="sp1" runat="server" href="SupervisorEditProfile.aspx.aspx">Edit Profile</a>
	<a class="dropdown-item" id="cp1" runat="server" href="SupervisorChangePassword.aspx">Change Password</a>							
	<a class="dropdown-item" href="SupervisorLogin.aspx">Log out</a>
					    	</div>
					    </div>
					</div>
		        </li>
            </ul>
			<div class="header stylehome1 dashbord_mobile_logo dashbord_pages">
				<div class="main_logo_home2">
		            <img class="nav_logo_img img-fluid float-left mt20" src="images/logo bukc.png" alt="logo.png">
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
<li><a runat="server" href="SupervisorDashboard.aspx"><span class="flaticon-puzzle-1"></span> Dashboard</a></li>
<li><a runat="server" href="SupervisorProfileInfo.aspx"><span class="flaticon-online-learning"></span> Profile Information</a></li>						
<li><a runat="server" href="ViewSupervisorNotifications.aspx"><span class="flaticon-speech-bubble"></span> Notifications</a></li>						
<li><a runat="server" href="Attendance.aspx"><span class="flaticon-rating"></span>Attendance</a></li>
<li><a runat="server" href="Groups.aspx"><span class="flaticon-add-contact"></span>Groups</a></li>
<li><a runat="server" href="ViewStudentTimetable.aspx"><span class="flaticon-like"></span> Student Timetable</a></li>

            <div class="drop">               
  <button onclick="myFunction()"  class="dropbtn"> <span class="flaticon-like"></span> Evaluations</button>  
<div id="myDrop1" class="drop-content">
    <ul>
<li><a runat="server" href="PresentationEvaluation.aspx"><span class="flaticon-rating"></span>Presentation Evaluation</a></li>
<li><a runat="server" href="ReportEvaluation.aspx"><span class="flaticon-rating"></span>Report Evaluation</a></li>
<li><a runat="server" href="LogBookEvaluation.aspx"><span class="flaticon-rating"></span>LogBook Evaluation</a></li>						
    </ul>
</div>
</div>
                     <br /> <br />
            <div class="drop">               
  <button onclick="myFunction()"  class="dropbtn"> <span class="flaticon-like"></span> Evaluation Sheets</button>  
<div id="myDrop2" class="drop-content">
    <ul>
<li><a runat="server" href="PresentationSheet.aspx"><span class="flaticon-rating"></span>Presentation Sheet</a></li>
<li><a runat="server" href="ReportSheet.aspx"><span class="flaticon-rating"></span>Report Sheet</a></li>
<li><a runat="server" href="LogBookSheet.aspx"><span class="flaticon-rating"></span>LogBook Sheet</a></li>						--%>
    </ul>
</div>
</div>
                     <br /> <br />

<li><a runat="server" href="GradeDetaisForSupervisor.aspx"><span class="flaticon-rating"></span> Student Grades</a></li>                        
<li><a runat="server" href="Files.aspx"><span class="flaticon-add-contact"></span> Documentation</a></li>
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
<li><a runat="server" href="SupervisorDashboard.aspx"><span class="flaticon-puzzle-1"></span> Dashboard</a></li>
<li><a runat="server" href="SupervisorProfileInfo.aspx"><span class="flaticon-online-learning"></span> Profile Information</a></li>						
<li><a runat="server" href="ViewSupervisorNotifications.aspx"><span class="flaticon-speech-bubble"></span> Notifications</a></li>						
<li><a runat="server" href="Attendance.aspx"><span class="flaticon-rating"></span>Attendance</a></li>
<li><a runat="server" href="Groups.aspx"><span class="flaticon-add-contact"></span>Groups</a></li>

       <div class="dd">
  <button class="dbtn"><span class="flaticon-like"></span> Evaluations </button>
  <div class="dd-content">
       <ul>
<li><a runat="server" href="PresentationEvaluation.aspx"><span class="flaticon-rating"></span>Presentation Evaluation</a></li>
<li><a runat="server" href="ReportEvaluation.aspx"><span class="flaticon-rating"></span>Report Evaluation</a></li>
<li><a runat="server" href="LogBookEvaluation.aspx"><span class="flaticon-rating"></span>LogBook Evaluation</a></li>						
    </ul>
  </div>
</div>  
       <br />
        <div class="dd">
  <button class="dbtn"><span class="flaticon-like"></span> Evaluation Sheets </button>
  <div class="dd-content">
       <ul>
<li><a runat="server" href="PresentationSheet.aspx"><span class="flaticon-rating"></span>Presentation Sheet</a></li>
<li><a runat="server" href="ReportSheet.aspx"><span class="flaticon-rating"></span>Report Sheet</a></li>
<li><a runat="server" href="LogBookSheet.aspx"><span class="flaticon-rating"></span>LogBook Sheet</a></li>						--%>
    </ul>
  </div>
</div>

<li><a runat="server" href="ViewStudentTimetable.aspx"><span class="flaticon-like"></span> Student Timetable</a></li>
<li><a runat="server" href="GradeDetaisForSupervisor.aspx"><span class="flaticon-rating"></span> Student Grades</a></li>                        
<li><a runat="server" href="Files.aspx"><span class="flaticon-add-contact"></span> Documentation</a></li>
					</ul>
 

				</div>
							</div>
						</div>
						<div class="col-lg-12">
							<nav class="breadcrumb_widgets" aria-label="breadcrumb mb30">
								<h4 class="title float-left">Edit Profile </h4>
							</nav>
						</div>

						<div class="col-lg-12">
							<div class="my_course_content_container">
								<div class="my_course_content mb30">
									<div class="my_course_content_header">	                                        
<form id="form1" runat="server">							

				<div class="col-xl-12">
					<div class="row">
						<div class="col-xl-6">
							<div class="my_profile_setting_input form-group">
						    	
                                <label class="control-label"> Name </label>
   <asp:TextBox ID="uname" class="form-control" ReadOnly="true" runat="server" ></asp:TextBox>						    	

                            </div>
							<div class="my_profile_setting_input form-group">
						      <label class="control-label"> Designation </label> 
<asp:TextBox ID="Designation" type="text" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>						    	
                        </div>
						</div>

						<div class="col-xl-6">
							<div class="my_profile_setting_input form-group">
						    	 <label class="control-label">  Phone
 <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="Phone" Display="Dynamic" 
    ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>	
						    	 </label> 
<asp:TextBox ID="Phone" type="text" class="form-control" runat="server" placeholder="Phone #"></asp:TextBox>						    	
                            </div>
							<div class="my_profile_setting_input form-group">
						      <label class="control-label"> Department  </label> 
<asp:TextBox ID="depart" type="text" class="form-control" ReadOnly="true" runat="server" Text="BSE" placeholder="Department"></asp:TextBox>
							
                            </div>
						</div>

                        <div class="col-xl-6">
							<div class="my_profile_setting_input form-group">

                                <label class="control-label"> University Email </label> 
<asp:TextBox ID="uemail" type="text" class="form-control" runat="server" ReadOnly="true" placeholder="University Email"></asp:TextBox>
					</div>							
						</div>

						<div class="col-xl-6">
						<div class="my_profile_setting_input form-group">
        <div class="my_profile_setting_input form-group">
                                <label class="control-label"> Personal Email  </label> 
<asp:TextBox ID="pemail" type="text" class="form-control" ReadOnly="true" runat="server" placeholder="Personal Email"></asp:TextBox>

							</div>
                        </div>						                       
						
                         </div>
						
                    <div class="col-xl-6">
							<div class="my_profile_setting_input form-group">
					    	 <label class="control-label">  Select Image </label> <br />
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </div>							
						</div>
						
                         <div class="col-xl-6">
							<div class="my_profile_setting_input form-group">
						    
    <asp:Image ID="Image1" Visible="false" ImageUrl="~/images/gallery/7.jpg" runat="server" />
                                
                            </div>							
						</div>

					</div>
				</div>			

<asp:Button type="submit" class="btn btn-primary" ID="BtnSave" style="margin-left:auto;margin-right:auto;display:block;margin-top:1%" Width="120px" runat="server" Text="Save Profile" OnClick="BtnSave_Click" />
                        </form>
   <asp:Label ID="email" type="hidden" runat="server" ></asp:Label>
                                        </div> 
                                     </div> 
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
<!-- Custom script for all pages --> 
<script type="text/javascript" src="js/script.js"></script>
</body>
</html>

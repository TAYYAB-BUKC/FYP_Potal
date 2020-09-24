<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Files.aspx.cs" Inherits="FYP_Portal.Web.Files" %>

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
<title>Documents</title>
<link href="images/favicon.png" sizes="128x128" rel="shortcut icon" type="image/x-icon" />
<link href="images/favicon.png" sizes="128x128" rel="shortcut icon" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.4.4/jquery.min.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-datetimepicker/2.5.20/jquery.datetimepicker.min.css"/>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-datetimepicker/2.5.20/jquery.datetimepicker.min.js" type="text/javascript"></script>

  <script>
      $(document).ready(function () {
        $('#datepicker1').datetimepicker();
    });
</script>

  <script>
      $(document).ready(function () {
        $('#datepicker2').datetimepicker();
    });
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
     <img class="rounded-circle" runat="server" id="profileImage" src="" alt="profile.png"></a>	                		
						    <div class="dropdown-menu">
						    	<div class="user_set_header">						   
                                     <img id="p" runat="server" alt="profile.png" src="" />
							     <br /> <br /> 
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
                              <img class="rounded-circle" runat="server" id="profileImage1" src="" alt="profile.png">
                		</a>
					    <div class="dropdown-menu">
					    	<div class="user_set_header">
					    		
                                  <img id="p1" runat="server" alt="profile.png" src="" />
					 <br /> <br /> 
						    	<p id="spname1" runat="server"> </p>
					    	</div>
					    	<div class="user_setting_content">
									<a class="dropdown-item active" id="sp1" runat="server" href="SupervisorEditProfile.aspx">Edit Profile</a>
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
<li class="active"><a runat="server" href="Files.aspx"><span class="flaticon-add-contact"></span> Documentation</a></li>
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
<li class="active"><a runat="server" href="Files.aspx"><span class="flaticon-add-contact"></span> Documentation</a></li>
					</ul>
 

								</div>
							</div>
						</div>

           
                                               
				<div class="col-lg-12">
							<nav class="breadcrumb_widgets" aria-label="breadcrumb mb30">
								<h4 class="title float-left">Documents</h4>
							</nav>
						</div>
                        
						<div class="col-lg-12">
							<div class="my_course_content_container">
								<div class="my_course_content mb30">
									<div class="my_course_content_header">
                <form id="form1" runat="server">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCommand="GridView1_RowCommand1">
                        <Columns>
                            <asp:BoundField DataField="Document Title" ItemStyle-Width="0%" HeaderText="Document Title" />
                            <asp:BoundField DataField="Startdate" ItemStyle-Width="0%" HeaderText="Start Date" />
                            <asp:BoundField DataField="Enddate" ItemStyle-Width="0%" HeaderText="End Date" />
                           
                            <asp:TemplateField HeaderText="Format" ItemStyle-Width="0%">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>

                                <ItemTemplate>
    <asp:LinkButton ID="LinkButton1" runat="server" data-name="" CommandArgument='<%# Eval("Format") %>' CommandName="Download" Text='<%# Eval("Format") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>

                        <EmptyDataTemplate>
 <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("Format") %>' CommandName="Download" Text='<%# Eval("Format") %>'></asp:LinkButton>
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Width="900px" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>
        <asp:Label ID="email" type="hidden" runat="server" ></asp:Label>
        <br /><br /><br />                   
                         </form>
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
<script type="text/javascript" src="js/script.js"></script>
</body>
</html>


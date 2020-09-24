<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Documents.aspx.cs" Inherits="FYP_Portal.Web.Documents" %>

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
                                 <img class="rounded-circle" runat="server" id="profileImage" src="" alt="profile.png">
	                		</a>
	                		
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
                             <img class="rounded-circle" runat="server" id="profileImage1" src="" alt="profile.png"></a>
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
<li><a id="dash" runat="server" href="StudentDashboard.aspx"><span class="flaticon-puzzle-1"></span> Dashboard</a></li>
<li><a id="pInfo" runat="server" href="StudentProfileInfo.aspx"><span class="flaticon-online-learning"></span> Profile Information</a></li>						
<li><a id="notify" runat="server" href="ViewStudentNotifications.aspx"><span class="flaticon-speech-bubble"></span>Notifications</a></li>
<li><a id="view" runat="server" href="ViewAttendance.aspx"><span class="flaticon-rating"></span> Attendance</a></li>                       
<li><a id="vst" runat="server" href="ViewSupervisorTimetable.aspx"><span class="flaticon-like"></span> Supervisor Timetable</a></li>
<li><a id="sg" runat="server" href="GradeDetailsForStudent.aspx"><span class="flaticon-rating"></span> Grades</a></li>
<li class="active"><a id="doc" runat="server" href="Documents.aspx"><span class="flaticon-add-contact"></span> Documentation</a></li>
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
<li><a id="dash1" runat="server" href="StudentDashboard.aspx"><span class="flaticon-puzzle-1"></span> Dashboard</a></li>
<li><a id="pInfo1" runat="server" href="StudentProfileInfo.aspx"><span class="flaticon-online-learning"></span> Profile Information</a></li>						
<li><a id="notify1" runat="server" href="ViewStudentNotifications.aspx"><span class="flaticon-speech-bubble"></span>Notifications</a></li>
<li><a id="view1" runat="server" href="ViewAttendance.aspx"><span class="flaticon-rating"></span> Attendance</a></li>                       
<li><a id="vst1" runat="server" href="ViewSupervisorTimetable.aspx"><span class="flaticon-like"></span> Supervisor Timetable</a></li>
<li><a id="sg1" runat="server" href="GradeDetailsForStudent.aspx"><span class="flaticon-rating"></span> Grades</a></li>
<li class="active"><a id="doc1" runat="server" href="Documents.aspx"><span class="flaticon-add-contact"></span> Documentation</a></li>
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
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" 
 BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4"  
 OnRowCommand="GridView1_RowCommand1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
    OnPageIndexChanged="LnkDelete_Click" OnRowEditing="GridView1_RowEditing" DataKeyNames="Id">

   <Columns>

        <asp:TemplateField HeaderText="Document Title">
          <ItemTemplate>
              <asp:Label runat="server" Text='<%# Eval("Document Title") %>'></asp:Label>
          </ItemTemplate>

    <EditItemTemplate>
         <asp:Label runat="server" Text='<%# Eval("Document Title") %>' ></asp:Label>
    </EditItemTemplate>
      </asp:TemplateField>

        <asp:TemplateField HeaderText="Startdate">
          <ItemTemplate>
              <asp:Label runat="server" Text='<%# Eval("Startdate") %>'></asp:Label>
          </ItemTemplate>

    <EditItemTemplate>
         <asp:Label runat="server" Text='<%# Eval("Startdate") %>' ></asp:Label>
    </EditItemTemplate>
      </asp:TemplateField>

        <asp:TemplateField HeaderText="Enddate">
          <ItemTemplate>
              <asp:Label runat="server" Text='<%# Eval("Enddate") %>'></asp:Label>
          </ItemTemplate>

    <EditItemTemplate>
         <asp:Label runat="server" Text='<%# Eval("Enddate") %>' ></asp:Label>
    </EditItemTemplate>
      </asp:TemplateField>

                           
                            <asp:TemplateField HeaderText="Format">                                
                                <ItemTemplate>
    <asp:LinkButton ID="LinkButton1" runat="server" data-name="" CommandArgument='<%# Eval("Format") %>' CommandName="Download" Text='<%# Eval("Format") %>'></asp:LinkButton>
                                </ItemTemplate>

                                <ItemTemplate>
    <asp:LinkButton ID="LinkButton1" runat="server" data-name="" CommandArgument='<%# Eval("Format") %>' CommandName="Download" Text='<%# Eval("Format") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Add Submission">
                                <ItemTemplate>
     <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("SubmitFile") %>' CommandName="SDownload" Text='<%# Eval("SubmitFile") %>'></asp:LinkButton>
                                </ItemTemplate>
                            
                                <EditItemTemplate>
<asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("SubmitFile") %>' CommandName="SDownload" Text='<%# Eval("SubmitFile") %>'></asp:LinkButton>
     
                                </EditItemTemplate>   

                            </asp:TemplateField>
   <asp:CommandField HeaderText="Action(s)" ButtonType="Image" EditImageUrl="~/images/edit.png" ShowEditButton="True" >
  <ControlStyle Height="20px" Width="20px" />
      </asp:CommandField>
                        </Columns>
                        <EmptyDataTemplate>
 <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("Format") %>' CommandName="Download" Text='<%# Eval("Format") %>'></asp:LinkButton>
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>

        <br /><br />
                          <div class="sign_up_modal modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-hidden="true">
	  	<div class="modal-dialog modal-dialog-centered" role="document">
	    	<div class="modal-content">
		      	<div class="modal-header">
		        	<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
		      	</div>	    		
                <div class="tab-content" id="myTabContent">
				  	<div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
						<div class="login_form">
							<form action="#">
								<div class="heading">
									<h3 class="text-center">Submit Document</h3>									
								</div>
								 <div class="form-group">
             <asp:Label ID="assigntitle" runat="server" Text="Document Title"></asp:Label>
             <asp:Label ID="documentID" runat="server" Text="Document Title"></asp:Label>
 <asp:Label ID="title" disabled="disabled" Style="margin-left: 30px" runat="server" Text="text"></asp:Label>		
								</div>
								<div class="form-group">
                                   <asp:Label ID="Label1" runat="server" Text="Solution File"></asp:Label>
                                    <input id="submitFile" runat="server" type="file" /></div>								
                                 <br />
 <asp:Button ID="Button1" class="btn btn-default" runat="server" Text="Cancel" />
 <asp:Button ID="Button2" Style="margin-left: 175px" class="btn btn-primary" runat="server" Text="Submit Document" OnClick="LnkUpload_Click" />
                                <br /><br /><br />							
							</form>
						</div>
				  	</div>
				  	</div>
             <asp:Label ID="enrollment" type="hidden" runat="server" ></asp:Label>
		</div>
	</div>
</div>
                  
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


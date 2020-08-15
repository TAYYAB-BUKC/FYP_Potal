<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterSupervisor.aspx.cs" Inherits="FYP_Portal.Web.RegisterSupervisor" %>

<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="css/bootstrap.min.css">
<link rel="stylesheet" href="css/style.css">
<link rel="stylesheet" href="css/responsive.css">
<title>Register Supervisors</title>
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
					<li class="list-inline-item"><a href="#menu"><span></span></a></li>
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
    <br /><br />  

    <section class="our-log bgc-fa">
		<div class="container">
			<div class="row">				
					<div class="login_form inner_page">
						<form id="form1" runat="server">							
                    <h3 class="text-center">REGISTER SUPERVISOR</h3>
 		<div class="row my_setting_content_details pb0">
				<div class="col-xl-12">
					<div class="row">
						<div class="col-xl-6">
							<div class="my_profile_setting_input form-group">
						    	 <label class="control-label"> Username 
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uname" Display="Dynamic" ErrorMessage="*"
 ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
						    	 </label> 
  <asp:TextBox ID="uname" type="text" class="form-control" runat="server" placeholder="UserName"></asp:TextBox>						    	
                            </div>

							<div class="my_profile_setting_input form-group">
						      <label class="control-label">University Email 
  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uemail" Display="Dynamic" 
    ErrorMessage="" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>                    
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="uemail" ForeColor="Red" 
    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vg">Incorrect Format</asp:RegularExpressionValidator>
   </label> 
<asp:TextBox ID="uemail" type="text" class="form-control" runat="server" placeholder="University Email"></asp:TextBox>						    								
						   </div>
						</div>

						<div class="col-xl-6">
							<div class="my_profile_setting_input form-group">
						    	<label class="control-label"> Name
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="sname" Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>    
						      </label> 
<asp:TextBox ID="sname" type="text" class="form-control" runat="server" placeholder="Supervisor Name"></asp:TextBox>                    
                     </div>
							
                            <div class="my_profile_setting_input form-group">
						      <label class="control-label"> Email 
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="pemail" Display="Dynamic" 
    ErrorMessage="" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>                    
<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="pemail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vg">Incorrect Format</asp:RegularExpressionValidator>
   </label> 
<asp:TextBox ID="pemail" type="text" class="form-control" runat="server" placeholder="Personal Email"></asp:TextBox>						    	
							
                            </div>
						</div>

                        <div class="col-xl-6">
							<div class="my_profile_setting_input form-group">
                                <label class="control-label"> Password
<asp:RequiredFieldValidator ID="rfv5" runat="server" ControlToValidate="pwd" Display="Dynamic" 
    ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>	
						    	</label> 
<asp:TextBox ID="pwd" type="password" class="form-control" runat="server" placeholder="Password"></asp:TextBox>
						 	</div>

							<div class="my_profile_setting_input form-group">
                                  <label class="control-label"> Department
<asp:RequiredFieldValidator ID="rfv6" runat="server" ControlToValidate="depart" Display="Dynamic" 
    ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>	
						    	</label> 
<asp:TextBox ID="depart" type="text" class="form-control" ReadOnly="true" runat="server" Text="BSE" placeholder="Department"></asp:TextBox>
			                         	</div>
						</div>

						<div class="col-xl-6">
						<div class="my_profile_setting_input form-group">
        <label class="control-label"> Institute
<asp:RequiredFieldValidator ID="rfv7" runat="server" ControlToValidate="inst" Display="Dynamic" InitialValue="Select"
      ErrorMessage="*" ForeColor="Red" SetFocusOnError="true">
      </asp:RequiredFieldValidator>	</label>
                      <asp:DropDownList ID="inst" class="form-control" runat="server">
                               <asp:listitem text="Select"></asp:listitem>
                               <asp:listitem text="Islamabad Campus"></asp:listitem>
                               <asp:listitem text="Karachi Campus" Selected="True"></asp:listitem>
                               <asp:listitem text="Lahore Campus"></asp:listitem>
                      </asp:DropDownList>		                        
                                
                        </div>						                       
						<div class="my_profile_setting_input form-group">
						    	 <label class="control-label"> Designation 
<asp:RequiredFieldValidator ID="rfv8" runat="server" ControlToValidate="designation" Display="Dynamic" 
    ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>													
                             </label> 
<asp:TextBox ID="designation" type="text" class="form-control" runat="server" placeholder="Designation"></asp:TextBox>						    	
                    			
                        </div>
                         </div>
						
                        <div class="col-xl-6">
						<div class="my_profile_setting_input form-group">
					       				
		<label class="control-label"> Mobile Number
            <asp:RequiredFieldValidator ID="rfv9" runat="server" ControlToValidate="phnum" Display="Dynamic" 
    ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>						
 		</label> 
<asp:TextBox ID="phnum" type="text" class="form-control" runat="server" placeholder="Father Name"></asp:TextBox>						    	
                          </div>	
                             
						<div class="my_profile_setting_input form-group">

						</div>
                         </div>			
                        
                         <div class="col-xl-6">
						<div class="my_profile_setting_input form-group"> </div>	
                             
						<div class="my_profile_setting_input form-group">
                             <label class="control-label"> Image 
<asp:RequiredFieldValidator ID="rfv10" runat="server" ControlToValidate="ProfileImage" Display="Dynamic" 
    ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                             </label> <br /> 
                                <asp:FileUpload ID="ProfileImage" runat="server" />
						</div>
                         </div>			
          </div>
				</div>
			</div>
                    
  <asp:Button type="submit" class="btn btn-log btn-block btn-thm2" ID="BtnSvRegister" style="margin-left:auto;margin-right:auto;display:block;border-radius:6px" Width="250px" runat="server" Text="Register Supervisor" OnClick="BtnSvRegister_Click1" />
                 </form>
                       
                     </div>       
				</div>
			</div>				
	</section>
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
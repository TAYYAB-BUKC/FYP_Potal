<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="FYP_Portal.Web.Contact" %>

<!DOCTYPE html>
<html dir="ltr" lang="en">

<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="css/bootstrap.min.css">
<link rel="stylesheet" href="css/style.css">
<link rel="stylesheet" href="css/responsive.css">
<title>Contact</title>
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
		        <li><a href="Home.aspx">Home</a></li>
                <li><a href="FYPCoordinatorLogin.aspx">FYP Coordinator</a></li>
                <li><a href="SupervisorLogin.aspx">Supervisor </a></li> 
                <li><a href="StudentLogin.aspx">Student</a></li>
                <li><a href="AboutUs.aspx">About Us</a></li>
				<li><a href="Contact.aspx">Contact</a></li>				
			</ul>
		</nav>
	</div>

<section id="googleMap">
<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d14476.547112439233!2d67.0881958!3d24.8933157!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xf50bdb260e451aa8!2sBahria%20University%20Karachi%20Campus!5e0!3m2!1sen!2s!4v1584762901465!5m2!1sen!2s" Width="100" height="530" style="border:0;" aria-hidden="false" tabindex="0"></iframe>
</section>  

	<section class="our-contact">
		<div class="container">		
			<div class="row">
		<div class="col-lg-6 form_grid">
					<h4 class="mb5">Send a Message</h4>
					<p>Fill out all required Field to send a Message.</p>
		            <form class="contact_form" id="contact_form" name="contact_form" action="#" method="post" novalidate="novalidate" runat="server">
						<div class="row">
                             <div class="col-sm-12">
			                    <div class="form-group">
			                    	<label for="exampleInputName"> Name
<asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="name" Display="Dynamic" 
ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator></label>				              
<asp:TextBox id="name" name="form_name" class="form-control" required="required" type="text" runat="server"></asp:TextBox>
                                </div>
			                </div>

 <div class="col-sm-12">
     <div class="form-group">
     	<label for="exampleInputEmail"> Email
<asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="email" Display="Dynamic" 
    ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator> </label>
<asp:TextBox id="email" name="form_email" class="form-control required email" required="required" type="email" runat="server"></asp:TextBox>
	                         </div>
			                </div>
			                
                            <div class="col-sm-12">
			                    <div class="form-group">
			                    	<label for="exampleInputSubject"> Subject
<asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="subject" Display="Dynamic" 
    ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator> </label>
<asp:TextBox id="subject" name="form_subject" class="form-control required" required="required" type="text" runat="server"></asp:TextBox>
                                </div>
                 
	                            <div class="form-group">
	                            	<label for="exampleInputEmail1">Message
   <asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="messages" Display="Dynamic" 
 ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator></label>
 <textarea ID="messages" class="form-control" cols="90" rows="5" runat="server"></textarea>
                                    </div>
			                   
 <asp:Button class="btn dbxshad btn-lg btn-thm circle white" style="margin-left:auto;margin-right:auto;display:block" Width="150px" runat="server" Text="Send" 
     OnClick="BtnContact_Click" />
			                </div>
                           </div>		               
		            </form>
				</div>
                 <div class="col-lg-6">
                        <h3 class="text-center">Campus Address </h3>
                        <p> Email: info@bahria.edu.pk</p>

                        <h4>Islamabad Campus </h4>
                        <p>Shangrilla Road, Sector E-8, Islamabad </p>
                        <p> UAN: +92-51-111-111-028</p>
                        <p> Fax: 92-51-9260885 </p>

                        <h4> Karachi Campus</h4>
                        <p>13, National stadium Road, Karachi </p>
                        <p>UAN: +92-21-99240002-6 </p>
                        <p>Fax: 92-21-99240351 </p>
                        
                        <h4>Lahore Campus </h4>
                        <p>47C, Johar Town, Lahore- Pakistan </p>
                        <p>Phone: +92-42-99233408-15 </p>
                        <p>Fax: +92-42-99233402 </p>

  <a href="https://bahria.edu.pk/office-directory/" target="_blank"> <h2>  Office Directory </h2> </a>
					</div>
			</div>
		</div>
	</section>
    	
	<section class="footer_one">
		<div class="container">
			<div class="row">				
                    <div class="col-sm-1"></div>
                <div class="col-sm-4">
					<div class="footer_contact_widget">
						<h4>ADDRESS</h4>
						<ul class="list-unstyled">
						<p><span class="fa fa-university"></span> 13, National stadium Road, Karachi</p>
						<p><span class="fa fa-phone"></span> UAN: +92-21-99240002-6</p>
						<p><span class="fa fa-fax"></span>     Fax: 92-21-99240351</p>
                        <p><span class="fa fa-envelope"></span>    Email: info@bahria.edu.pk</p>
						</ul>
					</div>
				</div>
				<div class="col-sm-3">
					<div class="footer_company_widget">
						<h4>CAMPUS</h4>
						<ul class="list-unstyled">								
			    <li class="list-inline-item"><a href="https://www.bahria.edu.pk/buic/" target="_blank"> <span> Islamabad Campus </span> </a> </li> <br />
				<li class="list-inline-item"><a href="https://bahria.edu.pk/bukc/" target="_blank"> <span> Karachi Campus </span></a></li><br />
				<li class="list-inline-item"><a href="https://www.bahria.edu.pk/bulc/" target="_blank">  <span> Lahore Campus </span>  </a></li><br />
                <li class="list-inline-item"><a href="https://www.bahria.edu.pk/ipp/" target="_blank">  <span> Institute of Professional Psychology </span>  </a></li><br />
				</ul>
					</div>
				</div>
				<div class="col-sm-3">
					<div class="footer_program_widget">
						 <h4>LOCATION</h4>
<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d14476.547112439233!2d67.0881958!3d24.8933157!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xf50bdb260e451aa8!2sBahria%20University%20Karachi%20Campus!5e0!3m2!1sen!2s!4v1584762901465!5m2!1sen!2s" width="900" height="175" style="border:0;" aria-hidden="false" tabindex="0"></iframe>
					</div>
				</div>
			</div>
				</div>				
	</section>

		<section class="footer_middle_area p0">
		<div class="container">
			<div class="row">
                 <div class="col-sm-3"></div>
				<div class="col-sm-12 col-md-4 col-lg-3 col-xl-4 pb15 pt15">
					<div class="footer_social_widget mt15">
						<ul>
			    <li class="list-inline-item"><a href="https://www.facebook.com/officialBU" target="_blank"><i class="fa fa-facebook"></i></a></li>
				<li class="list-inline-item"><a href="https://twitter.com/official_bu" target="_blank"><i class="fa fa-twitter"></i></a></li>
				<li class="list-inline-item"><a href="https://www.instagram.com/bahriauniversityofficial/" target="_blank"><i class="fa fa-instagram"></i></a></li>
				<li class="list-inline-item"><a href="https://www.flickr.com/photos/officialbu" target="_blank"><i class="fa fa-flickr"></i></a></li>
				<li class="list-inline-item"><a href="https://vimeo.com/bahriauniversityofficial" target="_blank"><i class="fa fa-vimeo"></i></a></li>
				<li class="list-inline-item"><a href="https://www.linkedin.com/school/bahria-university/" target="_blank"><i class="fa fa-linkedin"></i></a></li>
						</ul>
					</div>
				</div>
			</div>
		</div>
	</section>

	<section class="footer_bottom_area pt25 pb25">
		<div class="container">
			<div class="row">
				<div class="col-lg-6 offset-lg-3">
					<div class="copyright-widget text-center">						
    	2020 © <a href="home.aspx" target="_blank">Bahria University</a>
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
<script type="text/javascript" src="js/googlemaps1.js"></script>
<script type="text/javascript" src="js/script.js"></script>
</body>
</html>

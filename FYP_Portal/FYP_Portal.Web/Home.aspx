<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FYP_Portal.Web.Home" %>

<!DOCTYPE html>
<html dir="ltr" lang="en">

<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="css/bootstrap.min.css">
<link rel="stylesheet" href="css/style.css">
<link rel="stylesheet" href="css/responsive.css">
<title>Home</title>
<link href="images/favicon.png" sizes="128x128" rel="shortcut icon" type="image/x-icon" />
<link href="images/favicon.png" sizes="128x128" rel="shortcut icon" />   
</head>
<body>
<div class="wrapper">
<div class="preloader"></div>
	<header class="header-nav menu_style_home_one navbar-scrolltofixed stricky main-menu">
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
			<div class="header stylehome1">
				<div class="main_logo_home2">
		            <img class="nav_logo_img img-fluid float-left mt20" src="images/logo bukc.png" alt="logo-bukc.png">
		            <span>Bahria</span>
				</div>
				<ul class="menu_bar_home2">
					<li class="list-inline-item">
	                	<div class="search_overlay"></div>
					</li>
					<li class="list-inline-item"><a href="#menu"><span></span></a></li>
				</ul>
			</div>
		</div>

		<nav id="menu" class="stylehome1">
			<ul>
				<li><a href="Home.aspx"><span class="title">Home</span></a></li>
                <li><a href="FYPCoordinatorLogin.aspx">FYP Coordinator</a></li>
                <li><a href="SupervisorLogin.aspx">Supervisor </a></li> 
                <li><a href="StudentLogin.aspx">Student</a></li>
                <li><a href="AboutUs.aspx">About Us</a></li>
				<li><a href="Contact.aspx">Contact</a></li>		
			</ul>
		</nav>
	</div>

	<div class="home1-mainslider">
		<div class="container-fluid p0">
			<div class="row">
				<div class="col-lg-12">
					<div class="main-banner-wrapper">
					    <div class="banner-style-one owl-theme owl-carousel">
					        <div class="slide slide-one" style="background-image: url(images/background/b1.jpg); height: 95vh;">
					            <div class="container">
					                <div class="row home-content">
					                    <div class="col-lg-12 text-center p0">
					                        <h3 class="banner-title">HEC Accredited University </h3>
					                        <p>Accreditation is the act of granting credit or recognition, especially to an educational institution that maintains suitable standards. </p>					                      
					                    </div>
					                </div>
					            </div>
					        </div>
					        <div class="slide slide-one" style="background-image: url(images/background/b2.png);height: 95vh;">
					            <div class="container">
					                <div class="row home-content">
					                    <div class="col-lg-12 text-center p0">
					                        <h3 class="banner-title">Ranked among Top 11 Pakistani Universities</h3>
					                        <p>Bahria University is at 11th position. Bahria University is ranked above prominent universities.</p>					                       
					                    </div>
					                </div>
					            </div>
					        </div>
					        <div class="slide slide-one" style="background-image: url(images/background/b3.jpg);height: 95vh;">
					            <div class="container">
					                <div class="row home-content">
					                    <div class="col-lg-12 text-center p0">
					                        <h3 class="banner-title">Multi-City Multi-Campus</h3>
					                        <p>Bahria University (BU) a multi-campus recognized institute of higher education, located in the major cities Islamabad, Lahore & Karachi.</p>
					                    </div>
					                </div>
					            </div>
					        </div>
					    </div>
					    <div class="carousel-btn-block banner-carousel-btn">
					        <span class="carousel-btn left-btn"><i class="flaticon-left-arrow left"></i> <span class="left">PREV</span></span>
					        <span class="carousel-btn right-btn"><span class="right">NEXT</span> <i class="flaticon-right-arrow-1 right"></i></span>
					    </div>
					</div>
				</div>
			</div>
		</div>
	</div>

  <section id="our-courses" class="our-courses">
       <div class="container">
         <div class="row">				
           <div class="text-center">
             <h3>Welcome to Bahria University</h3>
               <p>Bahria University is a Federally Chartered Public Sector University. 
                  The principal seat of Bahria University is at Islamabad and campuses are at Islamabad, Karachi and Lahore. Bahria University was established by the Pakistan Navy in 2000, and since then it has steadily grown into one of the leading higher education institutions in Pakistan. 
                  It plays a major role in grooming future leaders who can make a positive difference to the world around them. 
                  Bahria is a comprehensive university having multidisciplinary programs that includes Health Sciences, Engineering Sciences, Computer Sciences, Management Sciences, Social Sciences, Law, Earth and Environmental Sciences, Psychology and Maritime Studies.</p>
                    </div>
    			</div>		
           <br />  <br />

			<div class="row">
				<div class="col-lg-6">
				<div class="about_content">
						<h3>Vision & Mission</h3>
		<p class="color-black22 mt20">To become an internationally recognized university that contributes towards the development of nation through excellence in education and research. To emerge as a leading institute that helps promote excellence in education and research which leads towards the welfare of our nation and society.</p>
		<p class="color-black22 mt20"> To attain highest standards in teaching, learning and research, at par with the international standards. To remain committed to the attainment of highest standards in teaching, learning and research, at par with the international standards</p>	
                    </div>
				</div>
				 <div class="col-lg-6">
					<div class="about_thumb">
						<img class="img-fluid" src="images/home/a1.jpg" alt="convocation_image">
					</div>
				</div>    
			
			</div>

           <div class="row">
                <div class="col-lg-6">
					<div class="about_thumb">
						

					</div>
				</div>    
				
			</div>

		</div>
	</section>

	<section class="footer_one">
		<div class="container">
			<div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-4">
                    <div class="footer_company_widget">
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
                     <div class="footer_company_widget">
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
<script type="text/javascript" src="js/isotop.js"></script>
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
<script type="text/javascript" src="js/script.js"></script>
</body>
</html>

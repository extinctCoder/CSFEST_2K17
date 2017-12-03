<html>

<head><title>User DashBoard</title></head>

<body>
	<table border="1" align="center" width="0%">
    	<tr>
        	<td>
            	<!-- Header section -->
            	<div>
                    <table align="center" width="100%">
                        <td width="20%">
                            <img src="images/pageicon.png"/>
                        </td>
                        <td width="40%">&nbsp;</td>
                        <td width="40%">
                            <table align="right">
                                <td><strong>Logged in as </strong></td>
                                <td><a href="viewprofile.php">Bob<img src="images/user.png"></a></td>
                                <td><hr width="1" size="15"></td>
                                <td><a href="../index.html">Logout<img src="images/logout.png"></a></td>
                            </table> 
                        </td>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div>
                    
                </div>
            </td>
        </tr>
        <tr>
        	<td>
            	<!-- Body section -->
               <div>
                    <table width="100%">
                        <!-- User Menu Section -->
                        <td width="30%">
                            <fieldset>
                                <legend>
                            <strong>Personal Information</strong></legend>
                            <ul>
                                <li><a href="dashboard.php">Dashboard</a></li>
                                <li><a href="viewprofile.php">View Profile</a></li>
                                
                            </ul>
                        </fieldset>


                        <fieldset>
                            <legend>
                            <strong>Manage Prescriptions</strong></legend>
                            <?php
                            $user='root';
                            $pass='';
                            $db='HomeAutomationDb';
                            $db=new mysqli('192.168.0.106',$user,$pass,$db) or die("
                            .


                            unable to connect");
                        
                            ?>
                                <ul>
                                <li><a href="masterbed.php">Mater Bed</a></li>
                                <li><a href="room.php">Room</a></li>
                                <li><a href="kitchen.php">Kitchen</a></li>
                                <li><a href="garedge.php">Garedge</a></li>    
                            </ul>
                        </fieldset>
                    </td>
                    <td width="70%">

                     <h1>WellCome to user DashBoard</h1>
                     <img src="images/shome2.jpg" width="70%">   
                    </td>
                </table>
            </div>
        </td>
    </tr>
</table>

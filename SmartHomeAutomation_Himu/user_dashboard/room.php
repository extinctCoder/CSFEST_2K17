 <form method="post">
<html>

<head>
    <title>User DashBoard</title>
<meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="css/bootstrap.min.css">
</head>

<body>
    <table border="1" align="right" width="0%">
        <tr>
            <td>
       
                <div>
                    <table align="right" width="100%">
                        
                                
                                <td><a href="../Index.php">Logout</td>
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
                
               <div>
                    <table width="100%">
                        <!-- User Menu Section -->
                        <td width="30%">
                            <fieldset>
                                <legend>
                            <strong>Personal Information</strong></legend>
                            <ul>
                                <li><a href="dashboard.php">Dashboard</a></li>
                                
                                
                            </ul>
                        </fieldset>


                        <fieldset>
                            <legend>
                            <strong>Manage Prescriptions</strong></legend>
                           
                                <ul>
                                <li><a href="masterbed.php">Mater Bed</a></li>
                                <li><a href="room.php">Room</a></li>
                                <li><a href="kitchen.php">Kitchen</a></li>
                                <li><a href="garedge.php">Garedge</a></li>    
                            </ul>
                        </fieldset>
                    </td>
                    <td width="70%">
                         <div class="row">
                        <div class="col-sm-2"></div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <label class="control-label">LED NINES STATUS</label>
                                <div class="text-right">
                                    <div id="led_4_Group" class="btn-group" role="group" aria-label="LED FOUR STATUS">
                                        <button type="submit" id="led_4_onn" name="led_4_onn" class="btn btn-success btn-lg" aria-label="LED ONN">LED ONN</button>
                                        <button type="submit" id="led_4_off" name="led_4_off" class="btn btn-danger btn-lg" aria-label="LED OFF">LED OFF</button>
                                    </div>
                                    <p class="help-block">led number NINE control panel</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                    </td>
                    </table>
            </div>
        </td>
    </tr>
</body>
</html>
</form>
<?php
$servername="192.168.0.106";
$username="root";
$password="";
$db="HomeAutomationDb";
$con=mysqli_connect($servername,$username,$password,$db);


if(isset($_POST['led_4_onn'])){
                    echo "led_4_onn";
                    $sqlstring = "UPDATE `component` SET `mode` = '0' WHERE `component`.`id` = 9";
                    $dataquery = mysqli_query( $con,$sqlstring);
                    echo "1";
                }
                if(isset($_POST['led_4_off'])){
                    echo "led_4_off";
                    $sqlstring = "UPDATE `component` SET `mode` = '1' WHERE `component`.`id` = 9";
                    $dataquery = mysqli_query($con,$sqlstring);
                }
 ?>
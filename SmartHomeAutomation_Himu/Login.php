
<form method="post">
	<title>Login</title>
</head>
<body>
	<table>
		<div>
			<div>
				<table align="center" width="100%" border="1">
					<tr align="right">
					
						<td width="80%">&nbsp;</td>
						<td width="10%">
							<a href="Home.html" >Home</a>
						</td>
						
						<td width="10%">
							<a href="Login.php">Login</a>
						</td>
					</tr>
				</table>
			</div>

			<div>
				Please Login with your username and password
			</div>
       
			<div>
				<fieldset>
					<legend>Login</legend>
					<table align="center">
						<tr>
							<td><label>User Name</label></td>
							<td>:</td>
							<td><input type="name" name="name"/></td>
							<td><img src="images/person.png"></td>
						</tr>
						<tr>
							<td><label>Password</label></td>
							<td>:</td>
							<td><input type="password" name="password"/></td>
							<td><img src="images/password.png"></td>
						</tr>
						<tr>
							<td align="center" colspan="4">
								<input type="submit" name="submit" value="Login">
								<input type="reset" name="reset" value="Reset">
						</tr>
						<tr>
							<td colspan="4" align="center">
								<a href="ForgetPassword.html">Forget Password</a>
								
							</td>
						</tr>
					</table>
				</fieldset>
			</div>

			<div>
				<table align="center">
					<tr align="center">
						<td>
							<a href="https://www.facebook.com/">
								<img src="images/facebook.png">
							</a>
						</td>
						<td>
							<a href="https://www.twitter.com/">
								<img src="images/twitter.png">
							</a>
						</td>
					</tr>
				</table>
				
			
			</div>
		</div>
	</table>
    </table>
</div>
</form>
<?php
$Name=$_REQUEST['name'];
$Pass=$_REQUEST['password'];
$servername="192.168.0.106";
$username="root";
$password="";
$db="HomeAutomationDb";
$con=mysqli_connect($servername,$username,$password,$db);
$sql="SELECT * FROM `user` WHERE `user_name` LIKE '$Name' AND `password` LIKE '$Pass'";
$result=mysqli_query($con,$sql);
	$c=(mysqli_num_rows($result));
		if($c==1)
		{
		header("location:user_dashboard/Dashboard.php");
	}
	mysqli_close($con);
	?>

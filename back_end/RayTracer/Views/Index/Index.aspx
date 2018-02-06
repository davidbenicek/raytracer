<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html>
<html>
    <head runat="server">
    	<title></title>
    </head>
    <body>
        <h1 style="font-family:Comic Sans Ms;text-align:center;font-size:20pt;color:#00FF00">
          Simple Login Page
        </h1>
        <form name="login">
            Username<input type="text" name="userid"/>
            Password<input type="password" name="pswrd"/>
            <input type="button" onclick="check(this.form)" value="Login"/>
            <input type="reset" value="Cancel"/>
        </form>
    </body>
    <script   src="http://code.jquery.com/jquery-3.3.1.min.js"   integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8="   crossorigin="anonymous"></script>
    <script>
        function check(form)
        {
            var dataJSON = {
                "objects":
                [
                    {"shape":"sphere","size":{"x":30,"y":30,"z":30},"point":{"x":-50,"y":0,"z":60},
                    "color":{"r":0.0,"g":0.0,"b":1},"material":"flat"},
                    {"shape":"sphere","size":{"x":40,"y":40,"z":40},"point":{"x":50,"y":0,"z":0},
                    "color":{"r":1,"g":1,"b":1},"material":"flat"}
                ],
                "environment":
                {
                    "fileName":"test",
                    "winFrame":{"Width":800,"Height":600 },
                    "background":{"r":0.2,"g":0.4,"b":0.4},
                    "camera" : { "position":{"x":0,"y":0,"z":500}, "lookAt": {"x":-5,"y":0,"z":0}, "distanceViewPlane":850 },
                    "lights":[
                        {"rgbColor":{"r":0.3,"g":0.3,"b":0.3}, "intensity": 1 },
                        {"position":{"x":0,"y":55,"z":95},"rgbColor":{"r":1.0,"g":0,"b":0}, "intensity": 0.5},
                        {"position":{"x":50,"y":55,"z":75},"rgbColor":{"r":1.0,"g":0,"b":1.0}, "intensity": 0.4}
                    ]
                }
            };
            
            $.ajax({
                type: 'POST',
                url: 'http://127.0.0.1:1200/api/Render',
                data: JSON.stringify(dataJSON),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function(d)
                {

                    $("body").append(" <iframe src= '" +d.url+ "' style='display: none;' ></iframe>");
                    console.log(d + " url: " + d.url);
<!--                window.location = d;-->
                }
            });
        }
    </script>
</html>

#include <WiFi.h>
#include <WiFiMulti.h>
#include <MySQL_Connection.h>
#include <MySQL_Cursor.h>

//byte mac_addr[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };

IPAddress server_addr(192,168,0,106);  // IP of the MySQL *server* here
char user[] = "root";              // MySQL user login username
char password[] = "";        // MySQL user login password
char ssid[] = "seraphGetway";    // your SSID
char pass[] = "webGetway";       // your SSID Password
WiFiMulti WiFiMulti;
WiFiClient client;            // Use this for WiFi instead of EthernetClient
//MySQL_Connection conn((Client *)&client);

void setup()
{
    Serial.begin(115200);
    delay(10);

    // We start by connecting to a WiFi network
    WiFiMulti.addAP(ssid, pass);

    Serial.println();
    Serial.println();
    Serial.print("Wait for WiFi... ");

    while(WiFiMulti.run() != WL_CONNECTED) {
        Serial.print(".");
        delay(500);
    }

    Serial.println("");
    Serial.println("WiFi connected");
    Serial.println("IP address: ");
    Serial.println(WiFi.localIP());

    delay(500);

    Serial.begin(115200);
  while (!Serial); // wait for serial port to connect. Needed for Leonardo only
  
  Serial.println("Connecting...");
  //if (conn.connect(server_addr, 3306, user, password)) {
    //delay(1000);
  //}
//  else
    Serial.println("Connection failed.");
  //conn.close();
}


void loop()
{
    
    
}

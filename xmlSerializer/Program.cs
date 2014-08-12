using System;
using xmlSerializer;
using System.Xml;

namespace xmlSerializer
{
	class MainClass
	{

		public static void Main (string[] args)
		{
			string temp;
			string text;
			string date;
			string humidity;
			string pressure;
			string visibility;
			string sunrise;
			string sunset;
			yatomsphere (out humidity, out pressure, out visibility);
			yCondition (out temp, out text, out date);
			yastronomy (out sunrise, out sunset);
			yforcast (string[] forcast);


			Console.WriteLine ("Temp: " + temp);
			Console.WriteLine ("Condition: " + text);
			Console.WriteLine ("Humidity: " + humidity);
			Console.WriteLine ("Pressure: " + pressure);
			Console.WriteLine ("Visiblity: " + visibility);
			Console.WriteLine ("Date: " + date);
			Console.WriteLine ("Sunrise: " + sunrise);
			Console.WriteLine ("Sunset: " + sunset);

			 
			}  

		static void yatomsphere(out string humidity, out string pressure, out string visibility)
		{
			// Create a new XmlDocument  
			XmlDocument doc = new XmlDocument();  

			// Load data  
			doc.Load("http://xml.weather.yahoo.com/forecastrss?p=39503");  

			// Set up namespace manager for XPath  
			XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);  
			ns.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");  

			// Get forecast with XPath  
			XmlNodeList nodes = doc.SelectNodes("/rss/channel/yweather:atmosphere", ns);  

			// You can also get elements based on their tag name and namespace,  
			// though this isn't recommended  
			//XmlNodeList nodes = doc.GetElementsByTagName("forecast",   
			//                          "http://xml.weather.yahoo.com/ns/rss/1.0");  

			//yweatherAtmo yweatheratmo = new yweatherAtmo();
			humidity = "0";
			pressure = "0";
			visibility = "0";
		foreach (XmlNode node in nodes)
			{
				humidity = node.Attributes ["humidity"].InnerText;
				pressure = node.Attributes ["pressure"].InnerText; 
				visibility = node.Attributes ["visibility"].InnerText; 

			}
			  
		}
		static void yCondition(out string temp, out string text, out string date)
		{
			// Create a new XmlDocument  
			XmlDocument doc = new XmlDocument ();  

			// Load data  
			doc.Load ("http://xml.weather.yahoo.com/forecastrss?p=39503");  

			// Set up namespace manager for XPath  
			XmlNamespaceManager ns = new XmlNamespaceManager (doc.NameTable);  
			ns.AddNamespace ("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");  

			// Get forecast with XPath  
			XmlNodeList nodes = doc.SelectNodes ("/rss/channel/item/yweather:condition", ns);  

			// You can also get elements based on their tag name and namespace,  
			// though this isn't recommended  
			//XmlNodeList nodes = doc.GetElementsByTagName("forecast",   
			//                          "http://xml.weather.yahoo.com/ns/rss/1.0");  

			//yweatherCond yweathercond = new yweatherCond ();
			temp = "0";
			text = "Null";
			date = "Null";
			foreach (XmlNode node in nodes) {
				temp = node.Attributes ["temp"].InnerText;
				text = node.Attributes ["text"].InnerText; 
				date = node.Attributes ["date"].InnerText; 

			}
		}
		static void yastronomy(out string sunset, out string sunrise)
		{
			// Create a new XmlDocument  
			XmlDocument doc = new XmlDocument();  

			// Load data  
			doc.Load("http://xml.weather.yahoo.com/forecastrss?p=39503");  

			// Set up namespace manager for XPath  
			XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);  
			ns.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");  

			// Get forecast with XPath  
			XmlNodeList nodes = doc.SelectNodes("/rss/channel/yweather:astronomy", ns);  

			// You can also get elements based on their tag name and namespace,  
			// though this isn't recommended  
			//XmlNodeList nodes = doc.GetElementsByTagName("forecast",   
			//                          "http://xml.weather.yahoo.com/ns/rss/1.0");  

			//yweatherAtmo yweatheratmo = new yweatherAtmo();
			sunrise = "Null";
			sunset = "Null";

			foreach (XmlNode node in nodes)
			{
				sunrise = node.Attributes ["sunrise"].InnerText;
				sunset = node.Attributes ["sunset"].InnerText; 


			}

		}
		static string[.] yforcast()
		{
			// Create a new XmlDocument  
			XmlDocument doc = new XmlDocument();  

			// Load data  
			doc.Load("http://xml.weather.yahoo.com/forecastrss?p=39503");  

			// Set up namespace manager for XPath  
			XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);  
			ns.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");  

			// Get forecast with XPath  
			XmlNodeList nodes = doc.SelectNodes("/rss/channel/yweather:forcast", ns);  

			// You can also get elements based on their tag name and namespace,  
			// though this isn't recommended  
			//XmlNodeList nodes = doc.GetElementsByTagName("forecast",   
			//                          "http://xml.weather.yahoo.com/ns/rss/1.0");  

			string[,] forcast = new string[5,5]
			forcast = "Null";

			foreach (XmlNode node in nodes)
			{
				for (int i = 0; i < forcast.getlength(0); i++)
					{
					forcast[i, 0] = node.Attributes["day"].InnerText;
					forcast[i, 1] = node.Attributes["date"].InnerText;
					forcast[i, 2] = node.Attributes["low"].InnerText;
					forcast[i, 3] = node.Attributes["high"].InnerText;
					forcast[i, 4] = node.Attributes["text"].InnerText;

			}
				return forcast;
		}
}
}

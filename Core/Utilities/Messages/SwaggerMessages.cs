using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Messages
{
	public static class SwaggerMessages
	{
		public static String Version => "v1";
		public static String Title => "Mi WebAPI";
		public static String Description => "An ASP.NET Core Web API for managing My E-Commerce Project.";
		public static Uri TermsOfService => new("https://example.com/terms");
		public static String ContactName => "mi";
		public static String ContactEMail => "mi@gmail.com";
		public static Uri ContactUrl => new("https://localhost:7161/swagger/index.html");

		public static String LicenceName => "Example License";
		public static Uri LicenceUrl => new("https://example.com/terms");

		//        public static string Description => @"
		//[<center><a target='_blank' href='https://DevArchitecture.net/DevArchitectureUIpack.rar'><img src='https://angular.io/assets/images/logos/angular/angular.svg' width='48' height='48'><span><br/>Download DevArchitecture AngularUI Template</span></a></center>](https://angular.io/assets/images/logos/angular/angular.svg)";
	}
}

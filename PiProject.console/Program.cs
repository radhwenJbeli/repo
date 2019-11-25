using PiProject.data;
using PiProject.domain.entities;
using PiProject.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiProject.console
{
	public class Program
	{
		static void Main(string[] args)
		{
			/*	TestService ser = new TestService();
				TestWrapper testVar = ser.addTestAnswerAff();
				Console.WriteLine(testVar.idCollaborator);
				Console.ReadLine();

			*/

			CollaboratorService sr = new CollaboratorService();
			sr.test(13);
		

		}
	}
}
